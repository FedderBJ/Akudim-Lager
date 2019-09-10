using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class LanguageTool
    {
/*        private void ChangeLanguage(string lang)
        {
            var ci = new CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(this.GetType());
                resources.ApplyResources(c, c.Name, ci);
                if (c.GetType() == typeof(DataGridView))
                {
                    var dgv = (DataGridView)c;
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        resources.ApplyResources(col, col.Name);
                    }
                }
            }
}*/

        private void ChangeLanguageOld(string lang, Form o)
        {
            foreach (Control c in o.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(o.GetType());
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        /*
        private void ChangeLanguageSimple(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(this.GetType());
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
        */
/*
        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmPIDInfo));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
*/
    }
}
