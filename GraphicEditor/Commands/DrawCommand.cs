using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Commands
{
    public class DrawCommand : ICommand
    {

        private DrawFigure figure;
        private Graphics graphics;
        private Point currentPoint;
        private int sizeX, sizeY;
        private Pen currentPen;
        private Pen previousPen;

        public DrawCommand(Graphics g, DrawFigure figure, Point p, int sizeX, int sizeY, Pen curr, Pen prev)
        {
            this.figure = figure;
            currentPoint = p;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            currentPen = curr;
            previousPen = prev;
            graphics = g;
        }

        public void GetFigureData(out Point p, out int sizeX, out int sizeY)
        {
            p = currentPoint;
            sizeX = this.sizeX;
            sizeY = this.sizeY;
        }

        public void Execute()
        {
            switch (figure)
            {
                case DrawFigure.ELLIPSE:
                    graphics.DrawEllipse(currentPen, currentPoint.X, currentPoint.Y, sizeX, sizeY);
                    break;
                case DrawFigure.RECTANGLE:
                    graphics.DrawRectangle(currentPen, currentPoint.X, currentPoint.Y, sizeX, sizeY);
                    break;
                case DrawFigure.LINE:
                    graphics.DrawLine(currentPen, currentPoint.X, currentPoint.Y,
                        currentPoint.X + sizeX, currentPoint.Y + sizeY);
                    break;
                default: break;
            }
        }

        public void Undo()
        {
            Pen tempPen = (Pen)currentPen.Clone();
            currentPen = (Pen)previousPen.Clone();
            previousPen = tempPen;
            Execute();
        }

        public void Redo()
        {
            Pen tempPen = (Pen)previousPen.Clone();
            previousPen = (Pen)currentPen.Clone();
            currentPen = tempPen;
            Execute();
        }
    }
}
