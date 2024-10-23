using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraBox
{
    public partial class Main : Form
    {
        private SoundPlayer player;
        Model1 m = new Model1();
        List<Song> sl;

        public Main()
        {
            InitializeComponent();

            player = new SoundPlayer();
            comboBox1.Items.Add("All Songs");
            var c = m.Genres.Select(u => u.Name);
            foreach (string i in c)
            {
                comboBox1.Items.Add(i);
            }
            sl = m.Songs.Select(u => u).ToList();
            comboBox1.Text = "--select--";
            var s = m.Songs.Select(u => u.SName);
            foreach (string i in s)
            {
                listBox1.Items.Add(i);
            }
            groupBox1.Visible = false;

            //listBox1.ScrollAlwaysVisible = true;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            if(listBox1.SelectedItem!=null)
            {
                button4.BackColor = Color.DarkViolet;
                label3.Font=new Font("Charlemagne Std",label3.Font.Size);
                axWindowsMediaPlayer1.URL = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem + ".mp3";
                Song s1 = m.Songs.SingleOrDefault(i => i.SName == listBox1.SelectedItem.ToString());
                pictureBox1.Image = Image.FromFile(s1.Photo);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label3.Text = s1.Duration.ToString();
                label6.Text = s1.SName;
                linkLabel1.Text = s1.Album.AlbumName.ToString();
                linkLabel2.Text = s1.Artist.ArtistName.ToString();
            }
            
            ////linkLabel2.Text=s1.Ar

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=(listBox1.Items.Count-1))
            {
                listBox1.SelectedIndex++;
                axWindowsMediaPlayer1.URL = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem + ".mp3";
            }
            else
            {
                listBox1.SelectedIndex=0;
                axWindowsMediaPlayer1.URL = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem + ".mp3";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=0)
            {
                listBox1.SelectedIndex--;
                axWindowsMediaPlayer1.URL = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem + ".mp3";
            }
            else
            {
                listBox1.SelectedIndex=listBox1.Items.Count-1;
                axWindowsMediaPlayer1.URL = "F:/Sem6/OOSE/PandoraBox/PandoraBox/Content/" + listBox1.SelectedItem + ".mp3";
            }
            

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Sufi")
            {
                axWindowsMediaPlayer1.close();
                Models.Sufi sufi = new Models.Sufi();
                //listBox1.Items.Clear();
                listBox1.DataSource = sufi.meets(sl);
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Deshbhakti")
            {
                axWindowsMediaPlayer1.close();
                Models.Deshbhakti desh = new Models.Deshbhakti();
                //listBox1.Items.Clear();
                listBox1.DataSource = desh.meets(sl);
            }
            else if (comboBox1.SelectedItem.ToString() == "Disco")
            {
                axWindowsMediaPlayer1.close();
                Models.Disco disc = new Models.Disco();
                //listBox1.Items.Clear();
                listBox1.DataSource = disc.meets(sl);
            }
            else if (comboBox1.SelectedItem.ToString() == "Motivational")
            {
                axWindowsMediaPlayer1.close();
                Models.Motivational moti = new Models.Motivational();
                //listBox1.Items.Clear();
                listBox1.DataSource = moti.meets(sl);
            }
            else if (comboBox1.SelectedItem.ToString() == "Remix")
            {
                axWindowsMediaPlayer1.close();
                Models.Remix rem = new Models.Remix();
               // listBox1.Items.Clear();
                listBox1.DataSource = rem.meets(sl);
            }
            else if(comboBox1.SelectedItem.ToString() == "Romantic")
            {
                axWindowsMediaPlayer1.close();
                Models.Romantic rom = new Models.Romantic();
               // listBox1.Items.Clear();
                listBox1.DataSource = rom.meets(sl);
            }
            else
            {
                axWindowsMediaPlayer1.close();
                listBox1.DataSource = m.Songs.Select(u => u.SName).ToList();

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            PlaylistWindow pw = new PlaylistWindow(m.Songs.SingleOrDefault(i => i.SName == listBox1.SelectedItem.ToString()),this);
            pw.Show();
           
            
        }

        private void Playlist_btn_Click(object sender, EventArgs e)
        {
            PlaylistWindow pw = new PlaylistWindow(null, this);
            pw.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //favourites
            Models.Favourite fav = new Models.Favourite();
            fav.UId = Login.Cuser.UId;
            fav.SId = m.Songs.SingleOrDefault(i => i.SName == listBox1.SelectedItem.ToString()).SId;
            m.Favourites.Add(fav);
            m.SaveChanges();
            button4.BackColor = Color.Pink;


        }

        private void Myfav_btn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.close();
            listBox1.Items.Clear();
            listBox1.DataSource = m.Favourites.Where(f => f.UId == Login.Cuser.UId).Select(s=>s.Song.SName).ToList();

        }
    }
}
