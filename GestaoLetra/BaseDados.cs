using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLetra
{
    public static class BaseDados
    {
        private static string token_letra = "38484cc97fe73bc4f8d46953ab7ca3f8";

        public static string GetToken
        {
            get { return token_letra; }
        }

    }
}
