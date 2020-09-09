using EsameCSharp.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioEsame3.Code
{
    class AlbumConTitolo : Album
    {
        public string Titolo { get { return Denominazione.Split('-')[1]; } }
        public string Autore { get { return Denominazione.Split('-')[0]; } }
    }
}
