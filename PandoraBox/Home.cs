using PandoraBox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PandoraBox
{
    public partial class Home : Form
    {
        private SoundPlayer player;
        Model1 m = new Model1();
        public Home()
        {
            InitializeComponent();
            player = new SoundPlayer();
            var s = m.Songs.Select(u => u.SName);
            foreach(string i in s)
            {
                listBox1.Items.Add(i);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Song s = new Song();
            s.SId = 1;
            s.SName = textBox1.Text;
            
            m.Songs.Add(s);
            m.SaveChanges();

        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            //Song s = new Song();
            ////Song s1 = s.displaySong(textBox1.Text);
            //label1.Text = s1.SName;
            //label2.Text = s1.Duration.ToString();
            //Album al = m.Albums.SingleOrDefault(a => a.AlbumId == s1.AlbumId);
            //label3.Text = al.AlbumName;

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            player.SoundLocation = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem +".wav";
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Stop";
                player.Play();
            }
            else
            {
                checkBox1.Text = "Play";
                player.Stop();
                
            }
        }

     
    }
}
