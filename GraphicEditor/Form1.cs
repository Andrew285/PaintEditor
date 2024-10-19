using System.Drawing.Drawing2D;
using GraphicEditor.Commands;

namespace GraphicEditor
{
    public partial class Form1 : Form
    {
        private DrawController controller;
        private FileController fileController;

        private Bitmap bm;
        private bool isDraw = false;

        DrawFigure selectedFigure = DrawFigure.NONE;
        DrawInstrument selectedInstrument = DrawInstrument.NONE;

        Point px, py;
        int x, y, sizeX, sizeY, currentX, currentY;

        ColorDialog cd = new ColorDialog();
        private bool isSelectedClicked = false;
        private bool isSelectedFigure = false;
        private bool isFilling = false;

        private bool isDragging = false;
        private Point pasteLocation;
        private Image clipboardImage;

        private System.Drawing.Rectangle selectionRect;
        private System.Drawing.Rectangle pasteRectangle;

        private Cursor customCursor = Cursors.Default;

        struct Line
        {
            public Point Point1;
            public Point Point2;

            public Line(Point p1, Point p2)
            {
                Point1 = p1;
                Point2 = p2;
            }
        }

        public Form1()
        {
            InitializeComponent();
            fileController = new FileController();
            bm = new Bitmap(pictureBox_Main.Width, pictureBox_Main.Height);
            Graphics g = Graphics.FromImage(bm);
            controller = DrawController.GetInstance(g);
            g.Clear(Color.White);
            pictureBox_Main.Image = bm;
        }


        private void pictureBox_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Check if the mouse is within the bounds of the pasted image
                if (clipboardImage != null && IsWithinImage(e.Location, clipboardImage))
                {
                    isDragging = true;
                    pasteLocation = e.Location;
                    isDraw = false;
                }
                else if (isSelectedClicked) 
                {
                    isSelectedFigure = true;
                    isDraw = true;
                }
                else
                {
                    isDraw = true;
                }

                py = e.Location;
                currentX = e.X;
                currentY = e.Y;
            }
        }

        private void pictureBox_Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ICommand command = null;

                if (isDraw)
                {
                    sizeX = x - currentX;
                    sizeY = y - currentY;

                    if (isSelectedClicked)
                    {
                        selectedFigure = DrawFigure.RECTANGLE;

                        if (isSelectedFigure)
                        {
                            controller.Pen = new Pen(Color.Black);
                            controller.Pen.DashStyle = DashStyle.Dash;
                            command = new DrawCommand(controller.GetGraphics(), selectedFigure, new Point(currentX, currentY),
                                                            sizeX, sizeY, controller.Pen, controller.Eraser);
                            isSelectedFigure = false;
                        }
                        else
                        {
                            controller.Pen.DashStyle = DashStyle.Solid;
                            command = new DrawCommand(controller.GetGraphics(), selectedFigure, new Point(currentX, currentY),
                                                            sizeX, sizeY, controller.Pen, controller.Eraser);
                        }
                    }
                    else
                    {
                        controller.Pen.DashStyle = DashStyle.Solid;
                        command = new DrawCommand(controller.GetGraphics(), selectedFigure, new Point(currentX, currentY),
                                                        sizeX, sizeY, controller.Pen, controller.Eraser);
                    }

                    isDraw = false;
                }
                else if (isDragging && clipboardImage != null)
                {
                    controller.PasteRegion(clipboardImage, bm, pasteRectangle.Location);

                    ImageDrawCommand imageDrawCommand = new ImageDrawCommand(clipboardImage, bm, pasteRectangle.Location);
                    controller.PushCommand(imageDrawCommand);

                    // Revert to default cursor when dragging ends
                    customCursor = Cursors.Default;
                    pictureBox_Main.Cursor = customCursor;
                }

                if (command != null)
                {
                    controller.PushCommand(command);
                    controller.ExecuteActiveCommand();
                    pictureBox_Main.Refresh();
                }

                isDragging = false;
                isDraw = false;
            }
        }

        private void pictureBox_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                if (selectedInstrument == DrawInstrument.PENCIL)
                {
                    px = e.Location;
                    controller.DrawLine(DrawInstrument.PENCIL, px, py);
                    py = px;
                }
                if (selectedInstrument == DrawInstrument.ERASER)
                {
                    px = e.Location;
                    controller.DrawLine(DrawInstrument.ERASER, px, py);
                    py = px;
                }
            }

             if (isDragging)
            {
                // Set custom cursor while dragging
                customCursor = Cursors.SizeAll;
                pictureBox_Main.Cursor = customCursor;

                ClearRegion(pasteRectangle);

                // Calculate the offset by which to move the pasted image
                int offsetX = e.X - pasteLocation.X;
                int offsetY = e.Y - pasteLocation.Y;

                // Update the position of the pasted image
                pasteRectangle.X += offsetX;
                pasteRectangle.Y += offsetY;

                // Update the pasteLocation
                pasteLocation = e.Location;

                // Redraw the canvas
                pictureBox_Main.Refresh();
            }

            pictureBox_Main.Refresh();

            x = e.X;
            y = e.Y;
            sizeX = e.X - currentX;
            sizeY = e.Y - currentY;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                isDraw = false;
                pictureBox_Main.Refresh();
                selectedInstrument = DrawInstrument.NONE;

                currentX = 0;
                currentY = 0;
                sizeX = 0;
                sizeY = 0;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                if (e.Shift)
                {
                    controller.RedoActiveCommand();
                }
                else
                {
                    controller.UndoActiveCommand();
                }

                pictureBox_Main.Refresh();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Copy();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                Paste();
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                Cut();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                Delete();
            }
        }


        private void pictureBox_Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (isDraw)
            {
                switch (selectedFigure)
                {
                    case DrawFigure.ELLIPSE:
                        g.DrawEllipse(controller.Pen, currentX, currentY, sizeX, sizeY);
                        break;
                    case DrawFigure.RECTANGLE:
                        g.DrawRectangle(controller.Pen, currentX, currentY, sizeX, sizeY);
                        break;
                    case DrawFigure.LINE:
                        g.DrawLine(controller.Pen, currentX, currentY, x, y);
                        break;
                    default: break;
                }
            }

            // Draw the selection rectangle if it's not empty
            if (!pasteRectangle.IsEmpty)
            {
                using (Pen pen = new Pen(Color.White))
                {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, pasteRectangle);
                }
            }


        }

        private void Copy()
        {
            if (isSelectedClicked)
            {
                ICommand command = controller.GetActiveCommand();

                Point p;
                int sizeX, sizeY;
                ((DrawCommand)command).GetFigureData(out p, out sizeX, out sizeY);
                selectionRect = new System.Drawing.Rectangle(p.X, p.Y, sizeX, sizeY);
                Bitmap copied = controller.CopyRegion(selectionRect, bm);
                Clipboard.SetImage(copied);

                isSelectedClicked = false;
            }
        }

        private void Paste()
        {
            if (Clipboard.ContainsImage())
            {
                controller.PopCommand().Undo();

                clipboardImage = Clipboard.GetImage();
                pasteLocation = pictureBox_Main.PointToClient(Cursor.Position);
                pasteRectangle = new System.Drawing.Rectangle(pasteLocation, clipboardImage.Size);
                ImageDrawCommand command = new ImageDrawCommand(clipboardImage, bm, pasteLocation);

                controller.PushCommand(command);
                controller.ExecuteActiveCommand();
                pictureBox_Main.Refresh();
            }
        }

        private void Cut()
        {
            Copy();
            ClearRegion(selectionRect);
        }

        private void Delete()
        {
            Copy();
            ClearRegion(selectionRect);
            Clipboard.Clear();
        }

        private void ClearRegion(System.Drawing.Rectangle rectangle)
        {
            // Clear the selected area
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.FillRectangle(Brushes.White, rectangle.X, rectangle.Y, rectangle.Width+1, rectangle.Height+1);
            }
        }

        private bool IsWithinImage(Point location, Image image)
        {
            // Check if the specified location is within the bounds of the image
            System.Drawing.Rectangle imageBounds = new System.Drawing.Rectangle(pasteLocation, image.Size);
            return imageBounds.Contains(location);
        }

        //--------------- HISTORY --------------------------
        private void button_Undo_Click(object sender, EventArgs e)
        {
            controller.UndoActiveCommand();
            pictureBox_Main.Refresh();
        }

        private void button_Redo_Click(object sender, EventArgs e)
        {
            controller.RedoActiveCommand();
            pictureBox_Main.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            controller.LineWidth = (int)numericUpDown1.Value;
            controller.Update();
        }
        //-----------------------------------------------------



        //--------------- INSTRUMENTS --------------------------
        private void button_pencil_Click(object sender, EventArgs e)
        {
            selectedInstrument = DrawInstrument.PENCIL;
            selectedFigure = DrawFigure.NONE;
        }

        private void button_Eraser_Click(object sender, EventArgs e)
        {
            selectedInstrument = DrawInstrument.ERASER;
            selectedFigure = DrawFigure.NONE;
        }

        private void button_Fill_Color_Click(object sender, EventArgs e)
        {
            selectedInstrument = DrawInstrument.FILL_COLOR;
            selectedFigure = DrawFigure.NONE;

            isFilling = true;
        }
        //-----------------------------------------------------



        //--------------- FIGURES --------------------------

        private void button_Line_Click(object sender, EventArgs e)
        {
            selectedFigure = DrawFigure.LINE;
            selectedInstrument = DrawInstrument.NONE;
        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            selectedFigure = DrawFigure.RECTANGLE;
            selectedInstrument = DrawInstrument.NONE;
        }

        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            selectedFigure = DrawFigure.ELLIPSE;
            selectedInstrument = DrawInstrument.NONE;
        }
        //-----------------------------------------------------


        private void button_Color_Pick_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            pictureBox_Main.BackColor = cd.Color;

            if (selectedInstrument == DrawInstrument.PENCIL)
            {
                controller.Pen.Color = cd.Color;
            }
            else if (selectedInstrument == DrawInstrument.FILL_COLOR)
            {
                controller.FillColor = cd.Color;
            }
            else
            {
                controller.Pen.Color = cd.Color;
            }
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            isSelectedClicked = true;
            isFilling = false;
        }

        private void pictureBox_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedInstrument == DrawInstrument.FILL_COLOR && isFilling)
            {
                FillCommand fillCommand = new FillCommand(bm, pictureBox_Main, e.Location, controller.FillColor, controller.PrevFillColor);
                controller.PushCommand(fillCommand);
                controller.ExecuteActiveCommand();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = fileController.OpenImageFile();
            if (bitmap != null)
            {
                bm = bitmap;
                Graphics g = Graphics.FromImage(bm);
                controller = DrawController.GetInstance(g);
                pictureBox_Main.Image = bm;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.SaveImageAs(bm);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.SaveImage(bm);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.OpenNewProject(bm);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
