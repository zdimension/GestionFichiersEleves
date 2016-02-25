/*
This file is part of GestionFichiersEleves.

GestionFichiersEleves is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

GestionFichiersEleves is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with GestionFichiersEleves.  If not, see <http://www.gnu.org/licenses/>.
*/

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
