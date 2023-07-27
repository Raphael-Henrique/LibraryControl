using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Cliente
    {
            private int codigo;
            private string nome;
            private int qtdeLivros;

            public int Codigo { get => codigo; set => codigo = value; }
            public string Nome { get => nome; set => nome = value; }
            public int QtdeLivros { get => qtdeLivros; set => qtdeLivros = value; }



    }
}
