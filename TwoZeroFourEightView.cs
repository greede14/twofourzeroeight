using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
        TwoZeroFourEightModel a;
        private Random rnd = new Random();

        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
            UpdateScore(m);
            showGameOver(m);
        }

        private void showGameOver(Model m)
        {
            if (((TwoZeroFourEightModel)m).Check() == true)
            {
                label1.Visible = true;
                System.Windows.Forms.MessageBox.Show("Game Over");
            }
        }

        private void UpdateScore(Model m)
        {
            label2.Text = Convert.ToString(((TwoZeroFourEightModel)m).GetScore()); ;
           // return Convert.ToString(((TwoZeroFourEightModel)m).GetScore());
        }
        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                case 16:
                    l.BackColor = Color.Yellow;
                    break;
                case 32:
                    l.BackColor = Color.Blue;
                    break;
                case 64:
                    l.BackColor = Color.Brown;
                    break;
                case 128:
                    l.BackColor = Color.LawnGreen;
                    break;
                case 256:
                    l.BackColor = Color.Indigo;
                    break;
                case 512:
                    l.BackColor = Color.Moccasin;
                    break;
                case 1024:
                    l.BackColor = Color.MediumSlateBlue;
                    break;
                case 2048:
                    l.BackColor = Color.Purple;
                    break;
                default:
                    l.BackColor = Color.Goldenrod;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // if(controller.ActionPerformed(TwoZeroFourEightController.HIDE)==true)
            label1.Visible = false;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
           // label2.Text = UpdateScore(m);
            //label2.Text = Convert.ToString(a.GetScore());
           // label2.Text = UpdateScore(a);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Right))
            {
                btnRight.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Left))
            {
                btnLeft.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Up))
            {
                btnUp.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Down))
            {
                btnDown.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
 }


