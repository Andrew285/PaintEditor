namespace GraphicEditor.Commands
{

    internal class ImageDrawCommand : ICommand
    {
        private Image image;
        private Bitmap bitmap;
        private Point location;

        public ImageDrawCommand(Image clipboardImage, Bitmap bm, Point pasteLocation)
        {
            image = clipboardImage;
            bitmap = bm;
            location = pasteLocation;
        }

        public void Execute()
        {
            if (image != null)
            {
                // Draw the image onto the canvas at the current mouse position
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(image, new System.Drawing.Rectangle(location, image.Size));
                }
            }
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            // Clear the selected area
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, new System.Drawing.Rectangle(location, image.Size));
            }
        }
    }
}
