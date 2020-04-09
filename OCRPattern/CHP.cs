using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

namespace OCRPattern
{
    [ProvideProperty("HelpKeyword", typeof(ToolStripItem))]
    [ProvideProperty("HelpNavigator", typeof(ToolStripItem))]
    [ProvideProperty("HelpString", typeof(ToolStripItem))]
    [ProvideProperty("ShowHelp", typeof(ToolStripItem))]
    public class CHP : Component, IExtenderProvider
    {

        #region IExtenderProvider ƒƒ“ƒo

        public bool CanExtend(object extendee)
        {
            return extendee is ToolStripItem;
        }

        #endregion

        String helpNamespace = null;

        [DefaultValue(null)]
        public String HelpNamespace { get { return helpNamespace; } set { helpNamespace = value; } }

        Hashtable navigators = new Hashtable();

        [DefaultValue(HelpNavigator.AssociateIndex)]
        public virtual HelpNavigator GetHelpNavigator(ToolStripItem ctl)
        {
            Object r = navigators[ctl];
            return (r != null) ? (HelpNavigator)r : HelpNavigator.AssociateIndex;
        }

        public virtual void SetHelpNavigator(ToolStripItem ctl, HelpNavigator navigator)
        {
            navigators[ctl] = navigator;
            SetShowHelp(ctl, true);
            UpdateEventBinding(ctl);
        }

        Hashtable keywords = new Hashtable();

        public virtual void SetHelpKeyword(ToolStripItem ctl, String keyword)
        {
            keywords[ctl] = keyword;
            if (!String.IsNullOrEmpty(keyword))
            {
                SetShowHelp(ctl, true);
            }
            UpdateEventBinding(ctl);
        }

        [DefaultValue(null)]
        public virtual string GetHelpKeyword(ToolStripItem ctl)
        {
            return (string)keywords[ctl];
        }

        Hashtable showHelp = new Hashtable();

        public virtual void SetShowHelp(ToolStripItem ctl, bool value)
        {
            showHelp[ctl] = value;
            UpdateEventBinding(ctl);
        }

        [DefaultValue(false)]
        public virtual bool GetShowHelp(ToolStripItem ctl)
        {
            Object r = showHelp[ctl];
            return r != null && (bool)r;
        }

        public virtual void ResetShowHelp(ToolStripItem ctl)
        {
            showHelp.Remove(ctl);
        }

        Hashtable helpStrings = new Hashtable();

        [DefaultValue(null)]
        public virtual string GetHelpString(ToolStripItem ctl)
        {
            return (string)helpStrings[ctl];
        }

        public virtual void SetHelpString(ToolStripItem ctl, string helpString)
        {
            helpStrings[ctl] = helpString;
            if (!String.IsNullOrEmpty(helpString))
                SetShowHelp(ctl, true);
            UpdateEventBinding(ctl);
        }

        Hashtable boundControls = new Hashtable();

        private void UpdateEventBinding(ToolStripItem ctl)
        {
            Control own = (ctl != null) ? ctl.Owner : null;
            if (GetShowHelp(ctl) && !boundControls.ContainsKey(own))
            {
                own.HelpRequested += new HelpEventHandler(OnControlHelp);
                own.QueryAccessibilityHelp += new QueryAccessibilityHelpEventHandler(OnQueryAccessibilityHelp);
                boundControls[own] = own;
                return;
            }
            if (!GetShowHelp(ctl) && boundControls.ContainsKey(own))
            {
                own.HelpRequested -= new HelpEventHandler(OnControlHelp);
                own.QueryAccessibilityHelp -= new QueryAccessibilityHelpEventHandler(OnQueryAccessibilityHelp);
                boundControls.Remove(own);
            }
        }

        void OnControlHelp(object sender, HelpEventArgs hevent)
        {
            Control control = (Control)sender;
            string helpString = GetHelpString(control, hevent);
            string helpKeyword = GetHelpKeyword(control, hevent);
            HelpNavigator helpNavigator = GetHelpNavigator(control, hevent);
            if (!GetShowHelp(control, hevent))
            {
                return;
            }
            if (Control.MouseButtons != MouseButtons.None && helpString != null && helpString.Length > 0)
            {
                Help.ShowPopup(control, helpString, hevent.MousePos);
                hevent.Handled = true;
            }
            if (!hevent.Handled && this.helpNamespace != null)
            {
                if (helpKeyword != null && helpKeyword.Length > 0)
                {
                    Help.ShowHelp(control, this.helpNamespace, helpNavigator, helpKeyword);
                    hevent.Handled = true;
                }
                if (!hevent.Handled)
                {
                    Help.ShowHelp(control, this.helpNamespace, helpNavigator);
                    hevent.Handled = true;
                }
            }
            if (!hevent.Handled && helpString != null && helpString.Length > 0)
            {
                Help.ShowPopup(control, helpString, hevent.MousePos);
                hevent.Handled = true;
            }
            if (!hevent.Handled && this.helpNamespace != null)
            {
                Help.ShowHelp(control, this.helpNamespace);
                hevent.Handled = true;
            }
        }

        private bool GetShowHelp(Control control, HelpEventArgs hevent)
        {
            ToolStrip ts = control as ToolStrip;
            if (ts != null)
                return GetShowHelp(ts.GetItemAt(hevent.MousePos));
            return false;
        }

        private HelpNavigator GetHelpNavigator(Control control, HelpEventArgs hevent)
        {
            ToolStrip ts = control as ToolStrip;
            if (ts != null)
                return GetHelpNavigator(ts.GetItemAt(hevent.MousePos));
            return HelpNavigator.AssociateIndex;
        }

        private string GetHelpKeyword(Control control, HelpEventArgs hevent)
        {
            ToolStrip ts = control as ToolStrip;
            if (ts != null)
                return GetHelpKeyword(ts.GetItemAt(hevent.MousePos));
            return null;
        }

        private string GetHelpString(Control control, HelpEventArgs hevent)
        {
            ToolStrip ts = control as ToolStrip;
            if (ts != null)
                return GetHelpString(ts.GetItemAt(hevent.MousePos));
            return null;
        }

        void OnQueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            ToolStripItem ctl = (ToolStripItem)sender;
            e.HelpString = GetHelpString(ctl);
            e.HelpKeyword = GetHelpKeyword(ctl);
            e.HelpNamespace = HelpNamespace;
        }
    }
}
