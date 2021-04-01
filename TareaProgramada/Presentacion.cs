using System;
using System.Windows.Forms;

namespace TareaProgramada
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        Dominio.Apis.IcommktCorreo _IcommktCorreo = new Dominio.Apis.IcommktCorreo();
        Dominio.Apis.IcommktSMS _IcommktSMS = new Dominio.Apis.IcommktSMS();
        Dominio.Conectores.ClientesPos _ClientesPos = new Dominio.Conectores.ClientesPos();

        private void Presentacion_Load(object sender, EventArgs e)
        {
            String[] argumento = Environment.GetCommandLineArgs();

            if (argumento.Length == 2)
            {
                switch (argumento[1].ToString())
                {
                    case "1":
                        _IcommktCorreo.ValidarConfirmacionCorreo();
                        Application.Exit();
                        break;

                    case "2":
                        _IcommktCorreo.InsertarClienteEnIcommkt();
                        Application.Exit();
                        break;

                    case "3":
                        _IcommktSMS.ValidarConfirmacionSMS();
                        Application.Exit();
                        break;

                    case "4":
                        _IcommktSMS.InsertarClienteEnIcommkt();
                        Application.Exit();
                        break;

                    case "5":
                        _ClientesPos.Importar();
                        Application.Exit();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
