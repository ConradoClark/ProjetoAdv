using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Comum
{
    public static class GrausParentesco
    {
        public static readonly List<ModeloGrauParentesco> Lista = new List<ModeloGrauParentesco>(){
            new ModeloGrauParentesco(0,"Pai"),
            new ModeloGrauParentesco(1,"Mãe"),
            new ModeloGrauParentesco(2,"Filho(a)"),
            new ModeloGrauParentesco(3,"Irmão(ã)"),
            new ModeloGrauParentesco(4,"Avô(ó)"),
            new ModeloGrauParentesco(5,"Tio(a)"),
            new ModeloGrauParentesco(6,"Sobrinho(a)"),
            new ModeloGrauParentesco(7,"Bisavô(ó)"),
            new ModeloGrauParentesco(8,"Primo(a)"),
            new ModeloGrauParentesco(9,"Sogro(a)"),
            new ModeloGrauParentesco(10,"Genro/Nora"),
            new ModeloGrauParentesco(11,"Cunhado(a)"),
            new ModeloGrauParentesco(12,"Padrasto/Madrasta"),
            new ModeloGrauParentesco(13,"Enteado(a)")
        };
        public static readonly ModeloGrauParentesco Pai = Lista[0];
        public static readonly ModeloGrauParentesco Mae = Lista[1];
        public static readonly ModeloGrauParentesco Filho = Lista[2];
        public static readonly ModeloGrauParentesco Irmao = Lista[3];
        public static readonly ModeloGrauParentesco Avo = Lista[4];
        public static readonly ModeloGrauParentesco Tio = Lista[5];
        public static readonly ModeloGrauParentesco Sobrinho = Lista[6];
        public static readonly ModeloGrauParentesco Bisavo = Lista[7];
        public static readonly ModeloGrauParentesco Primo = Lista[8];
        public static readonly ModeloGrauParentesco Sogro = Lista[9];
        public static readonly ModeloGrauParentesco Genro = Lista[10];
        public static readonly ModeloGrauParentesco Cunhado = Lista[11];
        public static readonly ModeloGrauParentesco Padrasto = Lista[12];
        public static readonly ModeloGrauParentesco Enteado = Lista[13];

    }
}
