using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Livros
    {

        public double multa;    

        public Dictionary<string, int> catalogo = new Dictionary<string, int>() // Nome dos livros e seu estoque
            {
                {"Pai rico, pai pobre", 250 },
                {"Rápido e devagar: maneiras de pensar", 300 },
                {"A arte da guerra", 450 },
                {"Mindset", 350 },
                {"Como hackear seu cérebro", 500 },
                {"O alquimista", 225 },
                {"Manual de persuasão do FBI", 330 },
                {"As 48 leis do poder", 325 },
                {"A lei da atração", 450 },
                {"O que é impossível para você?", 425 }
            };

        public List<string> listaAlugados = new List<string>();

    }
}
