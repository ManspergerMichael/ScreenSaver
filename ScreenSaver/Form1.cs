using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class frmScreenSaver : Form
    {
        //image objects
        List<Image> BGImages = new List<Image>();
        //location objects
        List<BritPic> BritPics = new List<BritPic>();
        Random rand = new Random();

        //this class will instatiate a location object for the pictures
        class BritPic
        {
            public int PicNum;
            public float x;
            public float y;
            public float Speed;
        }


        public frmScreenSaver()
        {
            InitializeComponent();
        }

        private void frmScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void frmScreenSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("Images");

            //take all files in the directory and add them to List<Image>
            foreach (string image in images)
            {
                BGImages.Add(new Bitmap(image));
            }

            //create 50 images on screen
            for(int ii=0; ii <50; ii++)
            {
                BritPic mp = new BritPic();
                mp.PicNum = ii % BGImages.Count;
                mp.x = rand.Next(0, Width);
                mp.y = rand.Next(0, Height);
                                
                BritPics.Add(mp);
            }
        }
        //refreshes the screen after an interval
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach (BritPic bp in BritPics)
            {
                e.Graphics.DrawImage(BGImages[bp.PicNum], bp.x, bp.y);
                bp.x -= 2;

                if (bp.x < -250)
                {
                    bp.x = Width + rand.Next(20, 100);
                }
            }
        }
    }
}
