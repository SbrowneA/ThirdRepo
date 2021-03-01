using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNameSpace
{
    public partial class TicketsForm : Form
    {
        TicketPrice mTicketPrice;
        int mSection = 2;
        int mQuantity = 0;
        bool mDiscount = false;
        bool mChildDiscount = false;

        public TicketsForm()
        {
            InitializeComponent();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            mQuantity = int.Parse(txtQuantity.Text);

            if (chkDiscount.Checked)
                { mDiscount = true; }
            if (chkChildDiscount.Checked) 
                { mChildDiscount = true; }
            if (radBalcony.Checked)
                { mSection = 1; }
            if (radGeneral.Checked)
                { mSection = 2; }
            if (radBox.Checked)
                { mSection = 3; }
            if (radBackStall.Checked) 
                { mSection = 4; }

            mTicketPrice = new TicketPrice(mSection, mQuantity, mDiscount, mChildDiscount);

            mTicketPrice.calculatePrice();
            lblAmount.Text = System.Convert.ToString(mTicketPrice.AmountDue);
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChildDiscount.Checked) {
                chkChildDiscount.Checked = false;
                //chkDiscount.Checked = true;
            }
        }

        private void chkChildDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                chkDiscount.Checked = false;
                //chkChildDiscount.Checked = true;
            }
        }
    }
}
