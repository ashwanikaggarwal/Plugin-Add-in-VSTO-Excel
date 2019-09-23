using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usiminas.PluginExcel.Dto;

namespace Usiminas.PluginExcel.Ux
{
    public partial class F_RetornoPedido : Form
    {
        public F_RetornoPedido()
        {
            InitializeComponent();
        }
        public void BuldingTempInvoce<T>(T construir)
        {
            try
            {
                if (!ValidTypeClassGeneric(construir))
                {
                    throw new Exception("Objeto enviado para construção não corresponde a uma lista de classe");
                }
                PopulateDados(construir);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        private bool ValidTypeClassGeneric<T>(T DataValid)
        {
            try
            {
                var criarObjeto = Activator.CreateInstance<T>();

                var type = criarObjeto.GetType().GetTypeInfo().GenericTypeArguments[0].BaseType.IsClass;

                Type typeParameterType = typeof(T);

                if (criarObjeto.GetType().GetTypeInfo().GenericTypeArguments[0].BaseType.IsClass == true && typeParameterType.Name.Contains("List"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        private void PopulateDados<T>(T data)
        {
            try
            {
                if (GridRetorno.InvokeRequired == true)
                {
                    GridRetorno.Invoke(new Action(() =>
                    {
                        GridRetorno.Controls.Clear();
                    }));
                }
                else
                {
                    GridRetorno.Controls.Clear();
                }
                foreach (var item in (IList<EmitirPedidoRespDto>)data)
                {
                    if (GridRetorno.InvokeRequired == true)
                    {
                        GridRetorno.Invoke(new Action(() =>
                        {
                        GridRetorno.Rows.Add(item.OVCriada, item.OVModelo, item.ItemModelo, item.PartNumberModelo, item.Status, item.Mensagem);
                        }));
                    }
                    else
                    {
                        GridRetorno.Rows.Add(item.OVCriada, item.OVModelo, item.ItemModelo, item.PartNumberModelo, item.Status, item.Mensagem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
