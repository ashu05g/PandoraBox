using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraBox
{
    public partial class PlaylistWindow : Form
    {
        public int flagP;
        Model1 m1 = new Model1();
        Song song;
        //Login l;
        public Models.Playlist plist;
        public Models.PlaylistSong plsg;
        public event EventHandler ButtonFirstFormClicked;
        private Main mainForm = null;

        public PlaylistWindow()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            
            flagP = 0;
            var pl = m1.Playlists.Where(u=>u.UId== Login.Cuser.UId).Select(s => s.PName);
            foreach (string i in pl)
            {
                comboBox1.Items.Add(i);
            }
        }
        public PlaylistWindow(Song song, Form callingForm)
        {
            mainForm = callingForm as Main;
            this.song = song;
            InitializeComponent();
            groupBox1.Visible = false;

            flagP = 0;
            var pl = m1.Playlists.Where(u => u.UId == Login.Cuser.UId).Select(s => s.PName);
            foreach (string i in pl)
            {
                comboBox1.Items.Add(i);
            }
            button5.Enabled = false;
            button4.Enabled = false;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                Models.Playlist playl = new Models.Playlist();
                playl.PName = textBox1.Text;
                playl.UId = Login.Cuser.UId;
                m1.Playlists.Add(playl);
                m1.SaveChanges();
                comboBox1.Items.Clear();
                var pl = m1.Playlists.Where(u => u.UId == Login.Cuser.UId).Select(s => s.PName).Distinct();
                foreach (string i in pl)
                {
                    comboBox1.Items.Add(i);
                }

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Models.Playlist pl = m1.Playlists.SingleOrDefault(u => u.PName==comboBox1.SelectedItem.ToString() && u.UId==Login.Cuser.UId);
            Models.PlaylistSong ps = new Models.PlaylistSong();
            ps.PId = pl.PId;
            ps.SId = song.SId;
            m1.PlaylistSongs.Add(ps);
            m1.SaveChanges();
            listBox1.Items.Clear();
            var s = m1.PlaylistSongs.Where(u => u.PId == pl.PId).Select(u => u.Song.SName);
            foreach (string i in s)
            {
                listBox1.Items.Add(i);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            plist = m1.Playlists.SingleOrDefault(u => u.PName == comboBox1.SelectedItem.ToString() && u.UId == Login.Cuser.UId);
            if (song != null)
                button5.Enabled = true;
            listBox1.Items.Clear();
            var s = m1.PlaylistSongs.Where(u=>u.PId==plist.PId).Select(u => u.Song.SName);
            foreach (string i in s)
            {
                listBox1.Items.Add(i);
            }
            
            button4.Enabled = true;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem !=null)
            {
                Models.Playlist pl = m1.Playlists.SingleOrDefault(u => u.PName == comboBox1.SelectedItem.ToString() && u.UId == Login.Cuser.UId);
                
                Models.PlaylistSong ps = m1.PlaylistSongs.SingleOrDefault(u => u.PId == pl.PId && u.Song.SName == listBox1.SelectedItem.ToString());
                
                m1.PlaylistSongs.Remove(ps);
                m1.SaveChanges();
                listBox1.Items.Clear();
                var s = m1.PlaylistSongs.Where(u => u.PId == pl.PId).Select(u => u.Song.SName);
                foreach (string i in s)
                {
                    listBox1.Items.Add(i);
                }
            }
            
        }

        public void Button4_Click(object sender, EventArgs e)
        {
            //if (ButtonFirstFormClicked != null)
            //    ButtonFirstFormClicked(sender, e);
            this.mainForm.axWindowsMediaPlayer1.close();
            //this.mainForm.listBox1.Items.Clear();
            this.listBox1.DataSource = m1.PlaylistSongs.Where(u => u.PId == plist.PId).Select(u => u.Song.SName).ToList();
            //var s = m1.PlaylistSongs.Where(u => u.PId == plist.PId).Select(u => u.Song.SName);
            //foreach (string i in s)
            //{
            //    this.mainForm.listBox1.Items.Add(i);
            //}

        }
    }
}
