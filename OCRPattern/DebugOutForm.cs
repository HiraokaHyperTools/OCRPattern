using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace OCRPattern {
    public partial class DebugOutForm : Form {
        public DebugOutForm() {
            InitializeComponent();
        }

        class TL : TraceListener {
            DebugOutForm form;

            public TL(DebugOutForm form) {
                this.form = form;
            }

            public override void Write(string message) {
                TextBox tb = form.tbOut;
                if (tb.IsDisposed) return;

                int x1 = tb.TextLength;
                tb.AppendText(message);
                int x2 = tb.TextLength;

            }

            public override void WriteLine(string message) {
                TextBox tb = form.tbOut;
                if (tb.IsDisposed) return;

                int x1 = tb.TextLength;
                tb.AppendText(message + "\r\n");
                int x2 = tb.TextLength;
            }
        }

        private void DebugOutForm_Load(object sender, EventArgs e) {
            Program.appTrace.Listeners.Add(new TL(this));
        }
    }
}