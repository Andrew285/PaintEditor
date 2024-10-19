

namespace GraphicEditor
{

    public enum DrawFigure
    {
        RECTANGLE,
        ELLIPSE,
        LINE,
        NONE,
    }

    public enum DrawInstrument
    {
        PENCIL,
        ERASER,
        FILL_COLOR,
        NONE
    }

    public abstract class Figure
    {
        public int x, y;
        public int sizeX, sizeY;

        public abstract void Draw(Graphics g, Pen p);
    }

    public class Rectangle : Figure
    {
        public Rectangle(int _x, int _y, int _sX, int _sY)
        {
            x = _x;
            y = _y;
            sizeX = _sX;
            sizeY = _sY;
        }

        public override void Draw(Graphics g, Pen p)
        {
            g.DrawRectangle(p, x, y, sizeX, sizeY);
        }
    }
    class Ellipse : Figure
    {
        public Ellipse(int _x, int _y, int _sX, int _sY)
        {
            x = _x;
            y = _y;
            sizeX = _sX;
            sizeY = _sY;
        }

        public override void Draw(Graphics g, Pen p)
        {
            g.DrawEllipse(p, x, y, sizeX, sizeY);
        }
    }
    class Line : Figure
    {
        public Line(int _x, int _y, int _sX, int _sY)
        {
            x = _x;
            y = _y;
            sizeX = _sX;
            sizeY = _sY;
        }

        public override void Draw(Graphics g, Pen p)
        {
            g.DrawLine(p, x, y, sizeX, sizeY);
        }
    }



    public class DrawController
    {
        private static DrawController instance;
        private Graphics graphics;
        public Pen Pen { get; set; }
        public Pen Eraser;
        private Color DrawColor = Color.Black;
        public Color FillColor { get; set; } = Color.Black;
        public Color PrevFillColor { get; set; } = Color.White;
        public int LineWidth { get; set; } = 1;

        private int activeCommand = 0;  // index to redo or undo commands
        public Stack<ICommand> commands = new Stack<ICommand>(); //Store all command

        public static DrawController GetInstance(Graphics g)
        {
            if (instance == null)
            {
                instance = new DrawController(g);
            }

            return instance;
        }

        public DrawController(Graphics g)
        {
            graphics = g;
            Pen = new Pen(DrawColor, LineWidth);
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            Eraser = new Pen(Color.White, 10);
        }

        public Graphics GetGraphics()
        {
            return graphics;
        }

        public void DrawLine(DrawInstrument instrument, Point p1, Point p2)
        {
            switch (instrument)
            {
                case DrawInstrument.PENCIL:
                    graphics.DrawLine(Pen, p1, p2);
                    break;
                case DrawInstrument.ERASER:
                    graphics.DrawLine(Eraser, p1, p2);
                    break;
                default: break;
            }
        }


        public void Update()
        {
            Pen = new Pen(DrawColor, LineWidth);
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public Bitmap CopyRegion(System.Drawing.Rectangle selectionRect, Bitmap canvas)
        {
            // Copy the selected portion of the canvas
            Bitmap selectedRegion = new Bitmap(selectionRect.Width, selectionRect.Height);
            using (Graphics g = Graphics.FromImage(selectedRegion))
            {
                System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(0, 0, selectedRegion.Width, selectedRegion.Height);
                System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle(selectionRect.X, selectionRect.Y, selectedRegion.Width, selectedRegion.Height);
                g.DrawImage(canvas, destRect, srcRect, GraphicsUnit.Pixel);
            }
            return selectedRegion;
        }

        public void PasteRegion(Image clipboardImage, Bitmap bm, Point pasteLocation)
        {
            if (clipboardImage != null)
            {
                // Draw the image onto the canvas at the current mouse position
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawImage(clipboardImage, new System.Drawing.Rectangle(pasteLocation, clipboardImage.Size));
                }
            }
        }

        public void PushCommand(ICommand command)
        {
            commands.Push(command);
        }

        public ICommand PopCommand() 
        {
            if (commands.Count > 0)
            {
                return commands.Pop();
            }
            return null;
        }

        public void ExecuteActiveCommand()
        {
            commands.ElementAt(activeCommand).Execute();
        }

        public void UndoActiveCommand()
        {
            if (activeCommand < commands.Count)
            {
                commands.ElementAt(activeCommand).Undo();
                activeCommand++;
            }
        }

        public void RedoActiveCommand()
        {

            if (activeCommand > 0)
            {
                activeCommand--;
                commands.ElementAt(activeCommand).Redo();
            }
        }

        public ICommand GetActiveCommand()
        {
            return commands.Peek();
        }
    }
}
