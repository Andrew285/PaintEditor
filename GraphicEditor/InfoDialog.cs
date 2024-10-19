namespace GraphicEditor
{
    public static class InfoDialog
    {
        public static void ShowError(string header, string messageBody)
        {
            MessageBox.Show(
            messageBody,
            header,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public static void ShowInfo(string header, string messageBody)
        {
            MessageBox.Show(
            messageBody,
            header,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }

        public static void ShowWarning(string header, string messageBody)
        {
            MessageBox.Show(
            messageBody,
            header,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
