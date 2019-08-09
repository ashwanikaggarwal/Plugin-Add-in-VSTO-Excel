using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;
using Usiminas.PluginExcel.Util;

namespace Usiminas.PluginExcel.Ux
{
    public partial class F_Pedido
    {
        /// <summary>
        /// validate if user are autorized
        /// </summary>
        public bool ValidLogin()
        {
            if (auth.Token == null)
            {
                if (this.TabControl.Controls.Contains(OvAbaDados) == true)
                {
                    this.TabControl.Controls.Remove(this.OvAbaDados);
                    this.TabControl.Controls.Remove(this.OvAbaConfiguracao);
                }
                OvAbaConfiguracao.Focus();
                SelectContext(this.OvAbaConfiguracao.ToString());
                return false;
            }
            else
            {
                if (this.TabControl.Controls.Contains(OvAbaDados) == false)
                {
                    this.TabControl.Controls.Add(this.OvAbaDados);
                }
                TabControl.SelectedTab = OvAbaDados;
                return true;
            }
        }

        public void SelectContext(string context)
        {

            foreach (TabPage item in this.TabControl.TabPages)
            {
                if (item.Name.Contains(context))
                {
                    if (TabControl.InvokeRequired)
                    {
                        TabControl.Invoke(new Action(() =>
                         {
                             TabControl.SelectedTab = item;
                         }
                        ));
                    }
                    else
                    {
                        TabControl.SelectedTab = item;
                    }
                }
            }

        }

        /// <summary>
        /// actions Handlers for textbox
        /// </summary>
        public void ReadOnlySelectField()
        {
            if (this.OvTxSelecaoRefCliente.InvokeRequired == true)
            {
                this.OvTxSelecaoRefCliente.Invoke(new Action(() => { this.OvTxSelecaoRefCliente.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoRefCliente.ReadOnly = true; }

            if (this.OvTxSelecaoRecebedor.InvokeRequired == true)
            {
                this.OvTxSelecaoRecebedor.Invoke(new Action(() => { this.OvTxSelecaoRecebedor.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoRecebedor.ReadOnly = true; }

            if (this.OvTxSelecaoLocalEntrega.InvokeRequired == true)
            {
                this.OvTxSelecaoLocalEntrega.Invoke(new Action(() => { this.OvTxSelecaoLocalEntrega.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoLocalEntrega.ReadOnly = true; }

            if (this.OvTxSelecaoPeriodo.InvokeRequired == true)
            {
                this.OvTxSelecaoPeriodo.Invoke(new Action(() => { this.OvTxSelecaoPeriodo.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoPeriodo.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD1.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD1.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD1.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD1.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD2.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD2.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD2.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD2.ReadOnly = true; }

            if (this.OvTxSelecaoTonelagemD3.InvokeRequired == true)
            {
                this.OvTxSelecaoTonelagemD3.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD3.ReadOnly = true; }));
            }
            else { this.OvTxSelecaoTonelagemD3.ReadOnly = true; }

            switch (FieldEdit)
            {
                case 1:
                    this.OvTxSelecaoRefCliente.ReadOnly = false; //1
                    break;
                case 2:
                    this.OvTxSelecaoRecebedor.ReadOnly = false;
                    break;
                case 3:
                    this.OvTxSelecaoLocalEntrega.ReadOnly = false;
                    break;
                case 4:
                    this.OvTxSelecaoPeriodo.ReadOnly = false;
                    break;
                case 5:
                    this.OvTxSelecaoTonelagemD1.ReadOnly = false;
                    break;
                case 6:
                    this.OvTxSelecaoTonelagemD2.ReadOnly = false;
                    break;
                case 7:
                    this.OvTxSelecaoTonelagemD3.ReadOnly = false;
                    break;
                default:
                    break;
            }
            FPTimer.Start();
        }

        /// <summary>
        /// actions Handlers for sort button 
        /// </summary>
        public void VisibleBtnClass()
        {
            if(this.OvBtnClassRefCliente.InvokeRequired == true)
            {
                this.OvBtnClassRefCliente.Invoke(new Action(() => { this.OvBtnClassRefCliente.Visible = false; }));
            }
            else { this.OvBtnClassRefCliente.Visible = false; }

            if (this.OvBtnClassRecebedor.InvokeRequired == true)
            {
                this.OvBtnClassRecebedor.Invoke(new Action(() => { this.OvBtnClassRecebedor.Visible = false; }));
            }
            else { this.OvBtnClassRecebedor.Visible = false; }

            if (this.OvBtnClassLocalEntrega.InvokeRequired == true)
            {
                this.OvBtnClassLocalEntrega.Invoke(new Action(() => { this.OvBtnClassLocalEntrega.Visible = false; }));
            }
            else { this.OvBtnClassLocalEntrega.Visible = false; }

            if (this.OvBtnClassPeriodo.InvokeRequired == true)
            {
                this.OvBtnClassPeriodo.Invoke(new Action(() => { this.OvBtnClassPeriodo.Visible = false; }));
            }
            else { this.OvBtnClassPeriodo.Visible = false; }

            if (this.OvBtnClassTonelagemD1.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD1.Invoke(new Action(() => { this.OvBtnClassTonelagemD1.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD1.Visible = false; }

            if (this.OvBtnClassTonelagemD2.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD2.Invoke(new Action(() => { this.OvBtnClassTonelagemD2.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD2.Visible = false; }

            if (this.OvBtnClassTonelagemD3.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD3.Invoke(new Action(() => { this.OvBtnClassTonelagemD3.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD3.Visible = false; }


            switch (FieldEdit)
            {
                case 1:

                    this.OvBtnClassRefCliente.Visible = true;
                    break;
                case 2:
                    this.OvBtnClassRecebedor.Visible = true;
                    break;
                case 3:
                    this.OvBtnClassLocalEntrega.Visible = true;
                    break;
                case 4:
                    this.OvBtnClassPeriodo.Visible = true;
                    break;
                case 5:
                    this.OvBtnClassTonelagemD1.Visible = true;
                    break;
                case 6:
                    this.OvBtnClassTonelagemD2.Visible = true;
                    break;
                case 7:
                    this.OvBtnClassTonelagemD3.Visible = true;
                    break;
                default:

                    break;
            }
        }

        /// <summary>
        /// actions Handlers for button Cancel 
        /// </summary>
        public void VisibleBtnCancel()
        {
            if (this.OvBtnClassRefClienteCancel.InvokeRequired == true)
            {
                this.OvBtnClassRefClienteCancel.Invoke(new Action(() => { this.OvBtnClassRefClienteCancel.Visible = false; }));
            }
            else { this.OvBtnClassRefClienteCancel.Visible = false; }

            if (this.OvBtnClassRecebedorCancel.InvokeRequired == true)
            {
                this.OvBtnClassRecebedorCancel.Invoke(new Action(() => { this.OvBtnClassRecebedorCancel.Visible = false; }));
            }
            else { this.OvBtnClassRecebedorCancel.Visible = false; }

            if (this.OvBtnClassLocalEntregaCancel.InvokeRequired == true)
            {
                this.OvBtnClassLocalEntregaCancel.Invoke(new Action(() => { this.OvBtnClassLocalEntregaCancel.Visible = false; }));
            }
            else { this.OvBtnClassLocalEntregaCancel.Visible = false; }
            if (this.OvBtnClassPeriodoCancel.InvokeRequired == true)
            {
                this.OvBtnClassPeriodoCancel.Invoke(new Action(() => { this.OvBtnClassPeriodoCancel.Visible = false; }));
            }
            else { this.OvBtnClassPeriodoCancel.Visible = false; }
            if (this.OvBtnClassTonelagemD1Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD1Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD1Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD1Cancel.Visible = false; }
            if (this.OvBtnClassTonelagemD2Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD2Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD2Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD2Cancel.Visible = false; }
            if (this.OvBtnClassTonelagemD3Cancel.InvokeRequired == true)
            {
                this.OvBtnClassTonelagemD3Cancel.Invoke(new Action(() => { this.OvBtnClassTonelagemD3Cancel.Visible = false; }));
            }
            else { this.OvBtnClassTonelagemD3Cancel.Visible = false; }

            switch (FieldEdit)
            {
                case 1:
                    this.OvBtnClassRefClienteCancel.Visible = true;
                    break;
                case 2:
                    this.OvBtnClassRecebedorCancel.Visible = true;
                    break;
                case 3:
                    this.OvBtnClassLocalEntregaCancel.Visible = true;
                    break;
                case 4:
                    this.OvBtnClassPeriodoCancel.Visible = true;
                    break;
                case 5:
                    this.OvBtnClassTonelagemD1Cancel.Visible = true;
                    break;
                case 6:
                    this.OvBtnClassTonelagemD2Cancel.Visible = true;
                    break;
                case 7:
                    this.OvBtnClassTonelagemD3Cancel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Bind specific text to Field SalesDto
        /// </summary>
        public void SaleDtoEdit()
        {
            switch (FieldEdit)
            {
                case 1:
                    salesdto.RefClient = this.OvTxSelecaoRefCliente.Text;
                    break;
                case 2:
                    salesdto.Receiver = this.OvTxSelecaoRecebedor.Text;
                    break;
                case 3:
                    salesdto.Place = this.OvTxSelecaoLocalEntrega.Text;
                    break;
                case 4:
                    salesdto.DesiredPeriod = this.OvTxSelecaoPeriodo.Text;
                    break;
                case 5:
                    salesdto.D1 = this.OvTxSelecaoTonelagemD1.Text;
                    break;
                case 6:
                    salesdto.D2 = this.OvTxSelecaoTonelagemD2.Text;
                    break;
                case 7:
                    salesdto.D3 = this.OvTxSelecaoTonelagemD3.Text;
                    break;
            }
        }

        /// <summary>
        /// Data Bind adress from salesDto to text fields 
        /// </summary>
        public void FormSalesDtoBind()
        {

            if (OvTxSelecaoRefCliente.InvokeRequired == true)
            {
                OvTxSelecaoRefCliente.Invoke(new Action(() => { this.OvTxSelecaoRefCliente.Text = salesdto.RefClient; }));
            }
            else { this.OvTxSelecaoRefCliente.Text = salesdto.RefClient; }

            if (OvTxSelecaoRecebedor.InvokeRequired == true)
            {
                OvTxSelecaoRecebedor.Invoke(new Action(() => { this.OvTxSelecaoRecebedor.Text = salesdto.Receiver; }));
            }
            else { this.OvTxSelecaoRecebedor.Text = salesdto.Receiver; }

            if (OvTxSelecaoLocalEntrega.InvokeRequired == true)
            {
                OvTxSelecaoLocalEntrega.Invoke(new Action(() => { this.OvTxSelecaoLocalEntrega.Text = salesdto.Place; }));
            }
            else { this.OvTxSelecaoLocalEntrega.Text = salesdto.Place; }
            if (OvTxSelecaoPeriodo.InvokeRequired == true)
            {
                OvTxSelecaoPeriodo.Invoke(new Action(() => { this.OvTxSelecaoPeriodo.Text = salesdto.DesiredPeriod; }));
            }
            else { this.OvTxSelecaoPeriodo.Text = salesdto.DesiredPeriod; }

            if (OvTxSelecaoTonelagemD1.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD1.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD1.Text = salesdto.D1; }));
            }
            else { this.OvTxSelecaoTonelagemD1.Text = salesdto.D1; }

            if (OvTxSelecaoTonelagemD2.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD2.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD2.Text = salesdto.D2; }));
            }
            else { this.OvTxSelecaoTonelagemD2.Text = salesdto.D2; }

            if (OvTxSelecaoTonelagemD3.InvokeRequired == true)
            {
                OvTxSelecaoTonelagemD3.Invoke(new Action(() => { this.OvTxSelecaoTonelagemD3.Text = salesdto.D3; }));
            }
            else { this.OvTxSelecaoTonelagemD3.Text = salesdto.D3; }

        }
        public void InitialStageSelectfields()
        {
            FieldEdit = 0;
            ReadOnlySelectField();
            VisibleBtnClass();
            VisibleBtnCancel();
            FPTimer.Stop();
            FormSalesDtoBind();
            OvRdnull.Checked = true;
        }

    }
}

