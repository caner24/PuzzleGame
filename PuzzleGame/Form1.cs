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

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        object[] _colors = { Color.Red, Color.Brown, Color.Purple, Color.Pink, Color.PapayaWhip, Color.SpringGreen, Color.YellowGreen };
        int _number;
        Random _random = new Random(0);

        public Form1()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUsersService>();
        }

        IUsersService _userService;
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _number = _random.Next(0, _colors.Length);
            pnlHeader.BackColor = (Color)_colors[_number];
            pnlFooter.BackColor = (Color)_colors[_number];
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var list = await _userService.GetAllAsync();


        }

        private async void button1_Click(object sender, EventArgs e)
        {
        var returned =    await _userService.CreateAsync(new Users() { username = "ali ata bak" });
        }
    }
}
