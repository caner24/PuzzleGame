using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Business.DepencyResolvers.Ninject;
using PuzzleGame.Entities.Concrate;
using PuzzleGame.Business.Concrate;
using System.Net;
using System.IO;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        object[] _colors = { Color.Red, Color.Brown, Color.Purple, Color.Pink, Color.PapayaWhip, Color.SpringGreen, Color.YellowGreen };
        int _number;
        Random _random = new Random(0);
        int inNullSliceIndex;
        public static Bitmap[,] bmps;
        public static Bitmap[,] bmps2 = new Bitmap[2, 1];
        LinkedList<Bitmap> lstOriginalPictureList = new LinkedList<Bitmap>();
        LinkedList<Bitmap> lstHandledPictureList = new LinkedList<Bitmap>();
        List<Bitmap> tempImage = new List<Bitmap>();
        List<Image> ImageList = new List<Image>();
        List<Image> FoundedList = new List<Image>();
        Random rnd = new Random();
        PictureBox box;
        PictureBox pbxTemp;
        PictureBox pbxTemp2;
        int sayac = 0;
        int yapilanAdim = 0;
        public static string userName;
        int randomPictureCode;
        Random pictureCode = new Random(0);
        public Form1()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUsersService>();
            _puzzleService = InstanceFactory.GetInstance<IPuzzleService>();
        }

        IUsersService _userService;
        IPuzzleService _puzzleService;

        public Image ByteArrayToImage(byte[] imageArr)
        {
            MemoryStream ms = new MemoryStream(imageArr);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            var allImages = await _puzzleService.GetAllAsync();
            foreach (var image in allImages)
            {
                ImageList.Add(ByteArrayToImage(image.puzzlepicture));
            }
            for (int i = 0; i < 16; i++)
            {
                var element = (PictureBox)pnlPuzzleItem.Controls[i];
                element.Click += new EventHandler(pictureBox_Click);
            }
            getUsers();
        }
        private async void getUsers()
        {
            listView1.Items.Clear();
            pbxReload.Visible = true;
            var userList = await _userService.GetAllAsync();
            foreach (var item in userList.OrderByDescending(_ => _.userscore))
            {
                ListViewItem elemant = new ListViewItem();
                elemant.Text = item.id;
                elemant.SubItems.Add(item.username);
                elemant.SubItems.Add(item.userscore.ToString());
                elemant.SubItems.Add(item.movesmade.ToString());
                listView1.Items.Add(elemant);
            }
            pbxReload.Visible = false;
            btnStart.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _number = _random.Next(0, _colors.Length);
            pnlHeader.BackColor = (Color)_colors[_number];
            pnlFooter.BackColor = (Color)_colors[_number];
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (userName == null)
            {
                MessageBox.Show("Lütfen Kullanici Adinizi Giriniz .");
            }
            else
            {
                loadImages();
            }
        }
        List<string> NumbList = new List<string>();
        private async void SetPbxImages()
        {
            NumbList.Clear();
            int setRandom1 = 0, setRandom2 = 0;
            Random rndNumb = new Random();


            for (int i = 0; i < 16; i++)
            {
                setRandom1 = rndNumb.Next(0, 4);
                setRandom2 = rndNumb.Next(0, 4);
                while (NumbList.Contains(setRandom1.ToString() + setRandom2.ToString()) && !FoundedList.Contains(bmps[setRandom1, setRandom2]))
                {
                    setRandom1 = rndNumb.Next(0, 4);
                    setRandom2 = rndNumb.Next(0, 4);
                }
                NumbList.Add(setRandom1.ToString() + setRandom2.ToString());
                var element = (PictureBox)pnlPuzzleItem.Controls[i];

                if (element.Enabled == true )
                {
                    element.Image = bmps[setRandom1, setRandom2];
                }
            }
        }
        private void loadImages()
        {
            FoundedList.Clear();
            randomPictureCode = pictureCode.Next(0, ImageList.Count());
            for (int i = 0; i < 16; i++)
            {
                var element = (PictureBox)pnlPuzzleItem.Controls[i];
                element.Enabled = true;
            }
            tempImage.Clear();
            bmps = null;
            btnStart.Enabled = false;
            Image img = ImageList[randomPictureCode];
            pbxPrevImg.Image = img;
            int widthThird = (int)((double)img.Width / 4.0 + 0.5);
            int heightThird = (int)((double)img.Height / 4.0 + 0.5);
            bmps = new Bitmap[4, 4];
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 3; j++)
                {
                    bmps[i, j] = new Bitmap(widthThird, heightThird);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                    g.Dispose();
                }


            pictureBox1.Image = bmps[0, 0];
            pictureBox2.Image = bmps[0, 1];
            pictureBox3.Image = bmps[0, 2];
            pictureBox4.Image = bmps[0, 3];
            pictureBox5.Image = bmps[1, 0];
            pictureBox6.Image = bmps[1, 1];
            pictureBox7.Image = bmps[1, 2];
            pictureBox8.Image = bmps[1, 3];
            pictureBox9.Image = bmps[2, 0];
            pictureBox10.Image = bmps[2, 1];
            pictureBox11.Image = bmps[2, 2];
            pictureBox12.Image = bmps[2, 3];
            pictureBox13.Image = bmps[3, 0];
            pictureBox14.Image = bmps[3, 1];
            pictureBox15.Image = bmps[3, 2];
            pictureBox16.Image = bmps[3, 3];

            for (int i = 0; i < 16; i++)
            {
                tempImage.Add((Bitmap)((PictureBox)pnlPuzzleItem.Controls[i]).Image);
                lstOriginalPictureList.AddFirst((Bitmap)((PictureBox)pnlPuzzleItem.Controls[i]).Image);
            }
            SetPbxImages();
        }

        int score = 30;
        bool oneTimes;
        bool twoTimes;
        bool CheckWin()
        {
            if (pbxTemp.Image != pbxTemp2.Image)
            {
                oneTimes = false;
                twoTimes = false;
                int i;
                for (i = 0; i < 16; i++)
                {
                    if (!oneTimes)
                    {
                        for (int a = 0; a < 16; a++)
                        {
                            if (lstHandledPictureList.First.Value == (pnlPuzzleItem.Controls[a] as PictureBox).Image && (pnlPuzzleItem.Controls[a] as PictureBox).Image == tempImage[a])
                            {
                                pbxTemp.Enabled = false;
                                FoundedList.Add(pbxTemp.Image);
                                score += 5;
                                button4.Text = score.ToString();
                                oneTimes = true;
                                a = 15;
                                break;
                            }
                        }
                    }
                    if (!twoTimes)
                    {
                        for (int b = 0; b < 16; b++)
                        {
                            if (lstHandledPictureList.Last.Value == (pnlPuzzleItem.Controls[b] as PictureBox).Image && (pnlPuzzleItem.Controls[b] as PictureBox).Image == tempImage[b])
                            {
                                pbxTemp2.Enabled = false;
                                FoundedList.Add(pbxTemp.Image);
                                score += 5;
                                button4.Text = score.ToString();
                                twoTimes = true;
                                b = 15;
                                break;
                            }
                        }
                    }
                    if ((pnlPuzzleItem.Controls[i] as PictureBox).Image != tempImage[i]) break;
                }
                lstHandledPictureList.Clear();
                if (i == 16) return true;
                else return false;
            }
            if (pbxTemp.Enabled == true && pbxTemp2.Enabled == true && pbxTemp.Image!=pbxTemp2.Image)
            {
                if (score != 0)
                {
                    score -= 10;
                    button4.Text = score.ToString();
                    if (score == 0)
                    {
                        MessageBox.Show("Kaybettiniz", "Oyun Sonu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        addScore();
                    }
                }
            }
            return false;

        }
        private async void addScore()
        {
            await _userService.CreateAsync(new Users() { username = userName, movesmade = yapilanAdim, userscore = score });
        }
        private async void pictureBox_Click(object sender, EventArgs e)
        {

            PictureBox pbx = (sender as PictureBox);
            if (pbx.BorderStyle != BorderStyle.Fixed3D)
            {
                pbx.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pbx.BorderStyle = BorderStyle.None;
            }
            if (sayac == 1)
            {

                pbxTemp2 = pbx;
                bmps2[sayac, sayac - 1] = (Bitmap)pbx.Image;
                pbxTemp2.Image = bmps2[sayac - 1, sayac - 1];
                pbxTemp.Image = bmps2[sayac, sayac - 1];
                pbx.BorderStyle = BorderStyle.None;
                sayac = -1;
                pbxTemp.BorderStyle = BorderStyle.None;
                pbxTemp2.BorderStyle = BorderStyle.None;
                if (pbxTemp.Image != pbxTemp2.Image)
                {
                    yapilanAdim++;
                    btnMove.Text = yapilanAdim.ToString();
                }
                lstHandledPictureList.AddLast((Bitmap)pbxTemp.Image);
                lstHandledPictureList.AddLast((Bitmap)pbxTemp2.Image);
                if (CheckWin())
                {
                    MessageBox.Show("Kazandiniz", "Tebrik", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    loadImages();
                    await _userService.CreateAsync(new Users() { username = userName, movesmade = yapilanAdim, userscore = score });

                };
            }
            else
            {

                pbxTemp = pbx;
                bmps2[sayac, sayac] = (Bitmap)pbx.Image;
            }
            sayac++;
        }

        private void btnKaristir_Click(object sender, EventArgs e)
        {
            SetPbxImages();
        }
        private void karistir()
        {
            do
            {
                int j = 0;
                int sayac = 15;
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
                Random r = new Random();
                for (int i = 0; i <= 15; i++)
                {

                    ((PictureBox)pnlPuzzleItem.Controls[i]).Image = tempImage[Indexes[sayac]];
                    sayac--;
                }
            } while (CheckWin());

        }
        private void btnSaveName_Click(object sender, EventArgs e)
        {
            userName = tbxUserName.Text.ToString() + "(" + Dns.GetHostName() + ")";
            btnSaveName.Enabled = false;
            btnSaveName.Enabled = false;
        }

        private void pbxRefresh_Click(object sender, EventArgs e)
        {
            getUsers();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Programdan çıkılsın mı?", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı");
            }
        }
    }
}
