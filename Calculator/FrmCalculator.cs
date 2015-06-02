using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace Calculator
{
    public partial class FrmCalculator : Form
    {
        public FrmCalculator()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text.Trim();
            txtInput.SelectionStart = txtInput.Text.Length;
            lblResult.Text = Evaluate(txtInput.Text);
        }
        private string Evaluate(string expression)
        {
            try
            {
                string str = expression.Replace("\r\n", "");
                str = str.Replace("%", "*0.01");
                var loDataTable = new DataTable();
                var loDataColumn = new DataColumn("Eval", typeof(string), str);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);
                return (string)(loDataTable.Rows[0]["Eval"]);
            }
            catch
            {
                return lblResult.Text;
            }
        }

    }
}
