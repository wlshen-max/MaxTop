using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    public partial class DataChanger : Form
    {
        TxtHelper txthelper = new TxtHelper();

        string shop = string.Empty;
        string eqid = string.Empty;
        string eqip = string.Empty;
        string inputData = string.Empty;
        object[] shoplist = new object[0];
        object[] eqidlist = new object[0];
        object[] eqiplist = new object[0];



        public DataChanger()
        {
            InitializeComponent();
        }

        private void DataChanger_Load(object sender, EventArgs e)
        {
            shoplist = txthelper.splitArray("shop");
            eqidlist = txthelper.splitArray("eqid");
            eqiplist = txthelper.splitArray("eqip");

            this.shop_box.Items.AddRange(shoplist);
            this.eqid_box.Items.AddRange(eqidlist);
        }

        public void frmReload()
        {
            this.DataChanger_Load(this, null);
        }

        private void DataChanger_FormClosed(object sender, EventArgs e)
        {
            Remote frm = new Remote();
            frm.frmReload();
        }

        public void setBtnValue(string btnValue)
        {
            if (btnValue.Equals("Create"))
            {
                left_btn.Text = "Create";
                shop_box.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (btnValue.Equals("Modify"))
            {
                left_btn.Text = ("Modify");
            }
            else if (btnValue.Equals("Delete"))
            {
                shop_box.Enabled = false;
                eqip_box.Enabled = false;
                left_btn.Text = ("Delete");
            }
            else
            {
                MessageBox.Show("Value shoud not be Null", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void left_btn_Click(object sender, EventArgs e)
        {
            shop = shop_box.Text.Trim().ToString().ToUpper();
            eqid = eqid_box.Text.Trim().ToString().ToUpper();
            eqip = eqip_box.Text.Trim().ToString();

            if (left_btn.Text.Equals("Create"))
            {
                CreateAction();
            }
            else if (left_btn.Text.Equals("Modify"))
            {
                modifyAction();
            }
            else
            {

                deleteAction();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateAction()
        {
            Remote remote = new Remote();
            if (createChecker(eqid) && createChecker(eqip))
            {
                getInputData();

                if (!string.IsNullOrEmpty(inputData))
                {
                    txthelper.txtWrite(inputData);

                    MessageBox.Show("Create complete!", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    remote.frmReload();
                }
            }
            else
            {
                return;
            }

        }


        private void modifyAction()
        {
            Remote remote = new Remote();
            DataTable dt = txthelper.txtToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string tempEqid = dt.Rows[i]["Eqid"].ToString();
                string tempEqip = dt.Rows[i]["Ip"].ToString();

                if (!(tempEqid == eqid && tempEqip == eqip))
                {
                    dr.BeginEdit();
                    dr["Shop"] = shop;
                    dr["Eqid"] = eqid;
                    dr["Ip"] = eqip;
                    dr.EndEdit();
                    dt.AcceptChanges();

                    txthelper.writeAction(dt);
                    break;
                }
            }
            MessageBox.Show("Modification Complete!", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            remote.frmReload();
        }


        private void deleteAction()
        {
            Remote remote = new Remote();
            DataTable dt = txthelper.txtToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string tempEqid = dt.Rows[i]["Eqid"].ToString();

                if (tempEqid == eqid)
                {
                    dt.Rows.Remove(dr);
                    dt.AcceptChanges();

                    txthelper.writeAction(dt);
                    break;
                }
            }
            MessageBox.Show("Deleted Complete!", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            remote.frmReload();
        }


        private void getInputData()
        {
            inputData = shop + ":" + eqid + ":" + eqip;
        }

        private void ipMaker(string Value)
        {
            try
            {
                IPAddress tempIP = IPAddress.Parse(Value);

                if (tempIP != null)
                {
                    eqip = tempIP.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool createChecker(string value)
        {
            bool result = false;

            try
            {
                if (!string.IsNullOrEmpty(shop) && !string.IsNullOrEmpty(eqid) && !string.IsNullOrEmpty(eqip))
                {
                    ipMaker(eqip);

                    if (value.Length < 6)
                    {
                        foreach (char tempeqid in eqid)
                        {
                            if (value.ToUpper().Equals(tempeqid.ToString()))
                            {
                                MessageBox.Show("EQID shoud not be repeated", "Value Repeated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = false;
                                break;
                            }
                            else
                            {
                                result = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (char tempeqip in eqip)
                        {
                            if (value.ToUpper().Equals(tempeqip.ToString()))
                            {
                                MessageBox.Show("EQIP shoud not be repeated", "Value Repeated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = false;
                                break;
                            }
                            else
                            {
                                result = true;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Value shoud not be Null", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result;
        }

    }
}
