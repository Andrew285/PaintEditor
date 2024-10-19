using System.Drawing.Imaging;

namespace GraphicEditor
{
    public class FileController
    {
        private string currentFilePath = "";

        public Bitmap OpenImageFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image (*bmp)|*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                return (System.Drawing.Bitmap)Image.FromFile(openFileDialog.FileName);
            }

            return null;
        }

        public void SaveImageAs(Bitmap bm)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set initial directory and filter for allowed file types
            saveFileDialog.Filter = "Image (*bmp)|*.bmp|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bm.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                currentFilePath = saveFileDialog.FileName;
            }
        }

        public void SaveImage(Bitmap bm)
        {
            if (currentFilePath != "")
            {
                bm.Save(currentFilePath, ImageFormat.Bmp);
            }
            else
            {
                SaveImageAs(bm);
            }
        }

        public void OpenNewProject(Bitmap bm)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set initial directory and filter for allowed file types
            saveFileDialog.Filter = "Image (*bmp)|*.bmp|All Files|*.*";
            saveFileDialog.Title = "New Project";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bm.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                currentFilePath = saveFileDialog.FileName;
            }
        }
    }
}
