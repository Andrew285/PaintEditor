using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Commands
{
    public class FillCommand : ICommand
    {
        private Bitmap bm;
        private PictureBox pictureBox;
        private Point startPoint;
        private Color fillColor;
        private Color previousFillColor;

        public FillCommand(Bitmap bm, PictureBox pb, Point startPoint, Color fillColor, Color prevColor)
        {
            this.bm = bm;
            this.startPoint = startPoint;
            this.fillColor = fillColor;
            previousFillColor = prevColor;
            pictureBox = pb;
        }

        public void Execute()
        {
            Point point = AdjustPointCoordinates(pictureBox, startPoint);
            FloodFill(bm, point.X, point.Y, fillColor);
        }

        public void Undo()
        {
            Point point = AdjustPointCoordinates(pictureBox, startPoint);
            FloodFill(bm, point.X, point.Y, previousFillColor);
        }

        public void Redo()
        {
            Point point = AdjustPointCoordinates(pictureBox, startPoint);
            FloodFill(bm, point.X, point.Y, fillColor);
        }

        static Point AdjustPointCoordinates(PictureBox pictureBox, Point point)
        {
            float scaleX = 1f * pictureBox.Width / pictureBox.Width;
            float scaleY = 1f * pictureBox.Height / pictureBox.Height;
            return new Point((int)(point.X * scaleX), (int)(point.Y * scaleY));
        }

        private void ValidatePixel(Bitmap bitmap, Stack<Point> stack, int x, int y, Color oldColor, Color newColor)
        {
            Color currentColor = bitmap.GetPixel(x, y);
            if (currentColor == oldColor)
            {
                stack.Push(new Point(x, y));
                bitmap.SetPixel(x, y, newColor);
            }
        }

        public void FloodFill(Bitmap bitmap, int x, int y, Color fillColor)
        {
            Color targetColor = bitmap.GetPixel(x, y);
            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(x, y));
            bitmap.SetPixel(x, y, fillColor);
            if (targetColor == fillColor) { return; }

            while (pixels.Count > 0)
            {
                Point currentPoint = pixels.Pop();
                int currentX = currentPoint.X;
                int currentY = currentPoint.Y;

                if (currentX > 0 && currentY > 0 && currentX < bitmap.Width - 1 && currentY < bitmap.Height - 1)
                {
                    ValidatePixel(bitmap, pixels, currentX - 1, currentY, targetColor, fillColor);
                    ValidatePixel(bitmap, pixels, currentX, currentY - 1, targetColor, fillColor);
                    ValidatePixel(bitmap, pixels, currentX + 1, currentY, targetColor, fillColor);
                    ValidatePixel(bitmap, pixels, currentX, currentY + 1, targetColor, fillColor);
                }
            }
        }
    }
}
