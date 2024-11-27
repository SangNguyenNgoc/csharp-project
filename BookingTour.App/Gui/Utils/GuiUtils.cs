using FontAwesome.Sharp;

namespace BookingTour.App.Gui.Utils;

public static class GuiUtils
{
    public static float GetScaleInScreen(Form form)
    {
        using var g = form.CreateGraphics();
        var dpiX = g.DpiX; 
        var scaleFactor = dpiX / 96.0f;
        return scaleFactor;
    }
    
    public static void Scale(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            // Điều chỉnh kích thước và vị trí
            control.Width = (int)(control.Width * scaleFactor);
            control.Height = (int)(control.Height * scaleFactor);
            control.Location = new Point((int)(control.Location.X * scaleFactor),
                (int)(control.Location.Y * scaleFactor));


            if (control is IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }

            // Nếu control có children, gọi đệ quy
            if (control.HasChildren)
            {
                Scale(control, scaleFactor);
            }
        }
    }
    
    public static void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is DataGridView dataGridView)
            {
                dataGridView.Font = new Font(dataGridView.Font.FontFamily, dataGridView.Font.Size * scaleFactor);
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Height = (int)(row.Height * scaleFactor);
                }
                dataGridView.ColumnHeadersHeight = (int)(dataGridView.ColumnHeadersHeight * scaleFactor);
            }
            if (control is FontAwesome.Sharp.IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }
            if (control.HasChildren)
            {
                ScaleControls(control, scaleFactor);
            }
        }
    }
}