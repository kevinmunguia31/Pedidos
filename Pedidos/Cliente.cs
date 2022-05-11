using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos
{
    class Cliente
    {
        private int codigo;
        private String nombre;
        private String apellido;
        private int edad;
        private float salario;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public float Salario { get => salario; set => salario = value; }
    }
}
