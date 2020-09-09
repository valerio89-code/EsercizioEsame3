using EsameCSharp.Music;
using EsercizioEsame3.Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsercizioEsame3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //recupero i dati
            List<Album> listaDiAlbum = AlbumDataManager.GetAlbums();
            //modifico i dati separando titolo e autore
            List<AlbumConTitolo> listaDiAlbumConTitolo = new List<AlbumConTitolo>();           
            foreach (Album album in listaDiAlbum)
            {                
                var albumConTitolo = new AlbumConTitolo();
                albumConTitolo.Anno = album.Anno;
                albumConTitolo.Genere = album.Genere;
                albumConTitolo.Prezzo = album.Prezzo;
                albumConTitolo.Denominazione = album.Denominazione;

                //var splitted = album.Denominazione.Split('-');
                //albumConTitolo.Autore = splitted[0];
                //albumConTitolo.Titolo = splitted[1];
                listaDiAlbumConTitolo.Add(albumConTitolo);
            }

            //mostro i dati nella grid
            dataGridView1.DataSource = listaDiAlbumConTitolo;
            //dataGridView1.Columns["Denominazione"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listaDaSalvare = dataGridView1.DataSource as List<AlbumConTitolo>;
            
            string path = null;

            //Se non voglio far scegliere all'utente il percorso
            path = "C:\\EsameCartella\\EsameCSharp.txt";


            //se voglio far sceglere all'utente il percorso
            //var result = saveFileDialog1.ShowDialog();
            //if(result == DialogResult.OK)
            //{
            //    path = saveFileDialog1.FileName;
            //}

            var listaJson = JsonConvert.SerializeObject(listaDaSalvare);
            File.WriteAllText(path, listaJson);
        }
    }
}
