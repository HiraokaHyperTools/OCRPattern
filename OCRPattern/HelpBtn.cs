using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace OCRPattern {
    public class HelpBtn {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage
            (IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_CONTEXTHELP = 0xf180;

        public static void Send(Control Ctrl) {
            Ctrl.Capture = false;
            SendMessage(Ctrl.FindForm().Handle, WM_SYSCOMMAND, (IntPtr)SC_CONTEXTHELP, IntPtr.Zero);
        }
    }

    public class HelpBtn2 {
        Form form;

        public HelpBtn2(Control Src) {
            Control C = new Control();
            C.Parent = (this.form = Src.FindForm());
            C.Capture = true;
            C.Cursor = Cursors.Help;
            C.MouseDown += new MouseEventHandler(C_MouseDown);
        }

        void C_MouseDown(object sender, MouseEventArgs e) {
            ((Control)sender).Capture = false;
            ((Control)sender).Dispose();

            Control parent = form;
            Point pt = e.Location;
            while (true) {
                Control child = parent.GetChildAtPoint(pt);
                if (child == null || parent is ToolStrip) {
                    HELPINFO hi = new HELPINFO();
                    hi.cbSize = Marshal.SizeOf(hi);
                    hi.iContextType = HELPINFO_WINDOW;
                    hi.iCtrlId = GetDlgCtrlID(parent.Handle);
                    hi.hItemHandle = parent.Handle;
                    hi.dwContextId = GetWindowContextHelpId(parent.Handle);
                    hi.x = pt.X;
                    hi.y = pt.Y;
                    IntPtr pv = Marshal.AllocCoTaskMem(Marshal.SizeOf(hi));
                    try {
                        Marshal.StructureToPtr(hi, pv, false);
                        SendMessage(parent.Handle, WM_HELP, IntPtr.Zero, pv);
                    }
                    finally {
                        Marshal.FreeCoTaskMem(pv);
                    }
                    break;
                }
                else {
                    pt -= new Size(child.Location);
                    parent = child;
                    continue;
                }
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowContextHelpId(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [StructLayout(LayoutKind.Sequential)]
        public struct HELPINFO {
            public int cbSize;
            public int iContextType;
            public int iCtrlId;
            public IntPtr hItemHandle;
            public IntPtr dwContextId;
            public int x;
            public int y;
        };

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_HELP = 0x0053;
        const int HELPINFO_WINDOW = 1;
    }
}
