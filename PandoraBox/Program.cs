using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraBox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string connetionString;
            //SqlConnection cnn;
            //connetionString = @"Data Source=CELAB2-PC;Initial Catalog=PandoraBox;Integrated Security=True;Pooling=False";
            //cnn = new SqlConnection(connetionString);
            //cnn.Open();
            //MessageBox.Show("Connection Open  !");
            //cnn.Close();
            //Model1 db = new Model1();
            //db.Songs.Add(new Song()
            //{
            //    SId = 1,
            //    SName = "Garmi",
            //    Duration=2,
            //    Photo="asd",
            //    AlbumId=2
              
            //});
            Application.Run(new Login());

        }
    }
}
