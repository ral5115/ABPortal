using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class Pedidos
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();

        public DataSet Nacional()
        {
            return _BDConsultar.QueryNacional("Sp_PedidosNacional");
        }

        public DataSet Internacional()
        {
            return _BDConsultar.QueryInternacional("Sp_PedidosInternacional");
        }
    }
}
