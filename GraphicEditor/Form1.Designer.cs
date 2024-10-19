namespace GraphicEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox_Main = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteSelectedToolStripMenuItem = new ToolStripMenuItem();
            panel_Intruments = new Panel();
            groupBox4 = new GroupBox();
            button_Redo = new Button();
            button_Undo = new Button();
            button_Select = new Button();
            button_Color_Pick = new Button();
            groupBox3 = new GroupBox();
            button_Ellipse = new Button();
            button_Rectangle = new Button();
            button_Line = new Button();
            groupBox2 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            groupBox1 = new GroupBox();
            button_Fill_Color = new Button();
            button_Eraser = new Button();
            button_pencil = new Button();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Main).BeginInit();
            menuStrip1.SuspendLayout();
            panel_Intruments.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_Main
            // 
            pictureBox_Main.BackColor = Color.White;
            pictureBox_Main.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_Main.Location = new Point(3, 93);
            pictureBox_Main.Name = "pictureBox_Main";
            pictureBox_Main.Size = new Size(829, 479);
            pictureBox_Main.TabIndex = 0;
            pictureBox_Main.TabStop = false;
            pictureBox_Main.Paint += pictureBox_Main_Paint;
            pictureBox_Main.MouseClick += pictureBox_Main_MouseClick;
            pictureBox_Main.MouseDown += pictureBox_Main_MouseDown;
            pictureBox_Main.MouseMove += pictureBox_Main_MouseMove;
            pictureBox_Main.MouseUp += pictureBox_Main_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(838, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteSelectedToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(180, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(180, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(180, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteSelectedToolStripMenuItem
            // 
            deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            deleteSelectedToolStripMenuItem.Size = new Size(180, 22);
            deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            deleteSelectedToolStripMenuItem.Click += deleteSelectedToolStripMenuItem_Click;
            // 
            // panel_Intruments
            // 
            panel_Intruments.BorderStyle = BorderStyle.FixedSingle;
            panel_Intruments.Controls.Add(groupBox4);
            panel_Intruments.Controls.Add(button_Select);
            panel_Intruments.Controls.Add(button_Color_Pick);
            panel_Intruments.Controls.Add(groupBox3);
            panel_Intruments.Controls.Add(groupBox2);
            panel_Intruments.Controls.Add(groupBox1);
            panel_Intruments.Location = new Point(3, 27);
            panel_Intruments.Name = "panel_Intruments";
            panel_Intruments.Size = new Size(829, 60);
            panel_Intruments.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button_Redo);
            groupBox4.Controls.Add(button_Undo);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(82, 52);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "History";
            // 
            // button_Redo
            // 
            button_Redo.BackColor = Color.White;
            button_Redo.BackgroundImage = Properties.Resources.icons8_redo_48;
            button_Redo.BackgroundImageLayout = ImageLayout.Zoom;
            button_Redo.FlatStyle = FlatStyle.Flat;
            button_Redo.Location = new Point(42, 16);
            button_Redo.Name = "button_Redo";
            button_Redo.Size = new Size(30, 30);
            button_Redo.TabIndex = 4;
            button_Redo.TabStop = false;
            button_Redo.UseVisualStyleBackColor = false;
            button_Redo.Click += button_Redo_Click;
            // 
            // button_Undo
            // 
            button_Undo.BackColor = Color.White;
            button_Undo.BackgroundImage = Properties.Resources.icons8_undo_48;
            button_Undo.BackgroundImageLayout = ImageLayout.Zoom;
            button_Undo.FlatStyle = FlatStyle.Flat;
            button_Undo.Location = new Point(6, 16);
            button_Undo.Name = "button_Undo";
            button_Undo.Size = new Size(30, 30);
            button_Undo.TabIndex = 3;
            button_Undo.TabStop = false;
            button_Undo.UseVisualStyleBackColor = false;
            button_Undo.Click += button_Undo_Click;
            // 
            // button_Select
            // 
            button_Select.BackColor = Color.White;
            button_Select.BackgroundImage = Properties.Resources.icons8_selection_tool_64;
            button_Select.BackgroundImageLayout = ImageLayout.Zoom;
            button_Select.FlatStyle = FlatStyle.Flat;
            button_Select.Location = new Point(508, 18);
            button_Select.Name = "button_Select";
            button_Select.Size = new Size(30, 30);
            button_Select.TabIndex = 7;
            button_Select.TabStop = false;
            button_Select.UseVisualStyleBackColor = false;
            button_Select.Click += button_Select_Click;
            // 
            // button_Color_Pick
            // 
            button_Color_Pick.BackColor = Color.White;
            button_Color_Pick.BackgroundImage = Properties.Resources.icons8_colors_60;
            button_Color_Pick.BackgroundImageLayout = ImageLayout.Zoom;
            button_Color_Pick.FlatStyle = FlatStyle.Flat;
            button_Color_Pick.Location = new Point(462, 18);
            button_Color_Pick.Name = "button_Color_Pick";
            button_Color_Pick.Size = new Size(30, 30);
            button_Color_Pick.TabIndex = 6;
            button_Color_Pick.TabStop = false;
            button_Color_Pick.UseVisualStyleBackColor = false;
            button_Color_Pick.Click += button_Color_Pick_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button_Ellipse);
            groupBox3.Controls.Add(button_Rectangle);
            groupBox3.Controls.Add(button_Line);
            groupBox3.Location = new Point(321, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(115, 52);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Figures";
            // 
            // button_Ellipse
            // 
            button_Ellipse.BackColor = Color.White;
            button_Ellipse.BackgroundImage = Properties.Resources.icons8_ellipse_48;
            button_Ellipse.BackgroundImageLayout = ImageLayout.Zoom;
            button_Ellipse.FlatStyle = FlatStyle.Flat;
            button_Ellipse.Location = new Point(78, 15);
            button_Ellipse.Name = "button_Ellipse";
            button_Ellipse.Size = new Size(30, 30);
            button_Ellipse.TabIndex = 5;
            button_Ellipse.TabStop = false;
            button_Ellipse.UseVisualStyleBackColor = false;
            button_Ellipse.Click += button_Ellipse_Click;
            // 
            // button_Rectangle
            // 
            button_Rectangle.BackColor = Color.White;
            button_Rectangle.BackgroundImage = Properties.Resources.icons8_rectangle_48;
            button_Rectangle.BackgroundImageLayout = ImageLayout.Zoom;
            button_Rectangle.FlatStyle = FlatStyle.Flat;
            button_Rectangle.Location = new Point(42, 16);
            button_Rectangle.Name = "button_Rectangle";
            button_Rectangle.Size = new Size(30, 30);
            button_Rectangle.TabIndex = 4;
            button_Rectangle.TabStop = false;
            button_Rectangle.UseVisualStyleBackColor = false;
            button_Rectangle.Click += button_Rectangle_Click;
            // 
            // button_Line
            // 
            button_Line.BackColor = Color.White;
            button_Line.BackgroundImage = Properties.Resources.icons8_line_50;
            button_Line.BackgroundImageLayout = ImageLayout.Zoom;
            button_Line.FlatStyle = FlatStyle.Flat;
            button_Line.Location = new Point(6, 16);
            button_Line.Name = "button_Line";
            button_Line.Size = new Size(30, 30);
            button_Line.TabIndex = 3;
            button_Line.TabStop = false;
            button_Line.UseVisualStyleBackColor = false;
            button_Line.Click += button_Line_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Location = new Point(224, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(91, 52);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Line Width";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(25, 22);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(34, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_Fill_Color);
            groupBox1.Controls.Add(button_Eraser);
            groupBox1.Controls.Add(button_pencil);
            groupBox1.Location = new Point(102, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(116, 52);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Instruments";
            // 
            // button_Fill_Color
            // 
            button_Fill_Color.BackColor = Color.White;
            button_Fill_Color.BackgroundImage = Properties.Resources.icons8_fill_color_48;
            button_Fill_Color.BackgroundImageLayout = ImageLayout.Zoom;
            button_Fill_Color.FlatStyle = FlatStyle.Flat;
            button_Fill_Color.Location = new Point(42, 16);
            button_Fill_Color.Name = "button_Fill_Color";
            button_Fill_Color.Size = new Size(30, 30);
            button_Fill_Color.TabIndex = 3;
            button_Fill_Color.TabStop = false;
            button_Fill_Color.UseVisualStyleBackColor = false;
            button_Fill_Color.Click += button_Fill_Color_Click;
            // 
            // button_Eraser
            // 
            button_Eraser.BackColor = Color.White;
            button_Eraser.BackgroundImage = Properties.Resources.icons8_eraser_64;
            button_Eraser.BackgroundImageLayout = ImageLayout.Zoom;
            button_Eraser.FlatStyle = FlatStyle.Flat;
            button_Eraser.Location = new Point(78, 15);
            button_Eraser.Name = "button_Eraser";
            button_Eraser.Size = new Size(30, 30);
            button_Eraser.TabIndex = 2;
            button_Eraser.TabStop = false;
            button_Eraser.UseVisualStyleBackColor = false;
            button_Eraser.Click += button_Eraser_Click;
            // 
            // button_pencil
            // 
            button_pencil.BackColor = Color.White;
            button_pencil.BackgroundImage = Properties.Resources.icons8_pencil_48;
            button_pencil.BackgroundImageLayout = ImageLayout.Zoom;
            button_pencil.FlatStyle = FlatStyle.Flat;
            button_pencil.Location = new Point(6, 16);
            button_pencil.Name = "button_pencil";
            button_pencil.Size = new Size(30, 30);
            button_pencil.TabIndex = 1;
            button_pencil.TabStop = false;
            button_pencil.UseVisualStyleBackColor = false;
            button_pencil.Click += button_pencil_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 574);
            Controls.Add(panel_Intruments);
            Controls.Add(pictureBox_Main);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Graphic Editor";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Main).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel_Intruments.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_Main;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private Panel panel_Intruments;
        private GroupBox groupBox1;
        private Button button_pencil;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDown1;
        private Button button_Eraser;
        private GroupBox groupBox3;
        private Button button_Ellipse;
        private Button button_Rectangle;
        private Button button_Line;
        private Button button_Color_Pick;
        private ColorDialog colorDialog1;
        private Button button_Fill_Color;
        private Button button_Select;
        private GroupBox groupBox4;
        private Button button_Redo;
        private Button button_Undo;
    }
}
