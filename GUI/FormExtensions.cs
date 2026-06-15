namespace PharmacyManagementSystem;

internal static class FormExtensions
{
    internal static void WireClickOutsideToBlur(this Form form) =>
        Attach(form, form);

    private static void Attach(Control c, Form owner)
    {
        if (c is TextBox or ComboBox or ListBox or NumericUpDown or DateTimePicker
               or DataGridView or Button or CheckBox or RadioButton
               or VScrollBar or HScrollBar or TrackBar)
            return;

        if (c.GetType().Name is "RoundedTextBox" or "RoundedButton")
            return;

        c.MouseDown += (_, _) => owner.ActiveControl = null;

        foreach (Control child in c.Controls)
            Attach(child, owner);
    }
}
