using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    public class ReadOnlyRichTextBox : RichTextBox
    {

        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        public ReadOnlyRichTextBox()
        {
            MouseDown += ReadOnlyRichTextBox_Mouse;
            MouseUp += ReadOnlyRichTextBox_Mouse;
            base.ReadOnly = true;
            base.TabStop = false;
            HideCaret(Handle);
            Cursor = Cursors.Default;
        }


        protected override void OnGotFocus(EventArgs e)
        {
            HideCaret(Handle);
        }

        protected override void OnEnter(EventArgs e)
        {
            HideCaret(Handle);
        }

        [DefaultValue(true)]
        public new bool ReadOnly
        {
            get { return true; }
            set { }
        }

        [DefaultValue(false)]
        public new bool TabStop
        {
            get { return false; }
            set { }
        }

        private void ReadOnlyRichTextBox_Mouse(object sender, MouseEventArgs e)
        {
            HideCaret(Handle);
        }

        private void InitializeComponent()
        {
            //
            // ReadOnlyRichTextBox
            //
            Resize += ReadOnlyRichTextBox_Resize;

        }

        private void ReadOnlyRichTextBox_Resize(object sender, EventArgs e)
        {
            HideCaret(Handle);

        }
    }
}
