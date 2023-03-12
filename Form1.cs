using Microsoft.VisualBasic.Devices;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Beroepsproduct
{
    public partial class TTT : Form
    {


        #region Misc
        bool turn;
        bool WinorNot = false;
        public readonly string PlayPC = "PC";
        public readonly string WinTitle = "You Win!";
        public readonly string nul = "";
        public readonly string zero = "0";
        public readonly string FillinBoth = "Please fill in both player names";
        public readonly string Fillin1 = "Please fill in Player 1";
        public readonly string Fillin2 = "Please fill in Player2";
        public readonly string Exit = "Are you sure you want to exit the game?";
        public readonly string ExitTitle = "Exit";
        public readonly string Reset = "Are you sure you want to reset the game?";
        public readonly string ResetTitle = "Reset";
        public readonly string Info = "1. Fill in the names for Player 1 and Player 2\n2. Click Start\n3. Play the game!\n\nPress Reset to start over";
        public readonly string InfoTitle = "Info";
        public readonly string space = " - ";



        //string FillinCheckbox = "Please fill in Player 2 or play against PC";
        //string FillinTitle = "Fill in";

        public readonly Color Blue = Color.DarkBlue;
        public readonly Color Red = Color.DarkRed;
        public readonly Color Gray = Color.Gray;
        public readonly Color White = Color.White;
        public readonly Color Green = Color.DarkGreen;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public TTT()
        {
            InitializeComponent();

            #region ButtonDisable
            button1Game.Enabled = false;
            button2Game.Enabled = false;
            button3Game.Enabled = false;
            button4Game.Enabled = false;
            button5Game.Enabled = false;
            button6Game.Enabled = false;
            button7Game.Enabled = false;
            button8Game.Enabled = false;
            button9Game.Enabled = false;


            CheckWin1.Enabled = false;
            CheckWin1.Visible = false;
            CheckWin2.Enabled = false;
            CheckWin2.Visible = false;
            CheckWin3.Enabled = false;
            CheckWin3.Visible = false;
            CheckWin4.Enabled = false;
            CheckWin4.Visible = false;
            CheckWin5.Enabled = false;
            CheckWin5.Visible = false;
            CheckWin6.Enabled = false;
            CheckWin6.Visible = false;
            CheckWin7.Enabled = false;
            CheckWin7.Visible = false;
            CheckWin8.Enabled = false;
            CheckWin8.Visible = false;
            CheckWin9.Enabled = false;
            CheckWin9.Visible = false;
            #endregion

            textBoxPlayer1.MaxLength = 8;
            textBoxPlayer2.MaxLength = 8;

        }

        public void AddToList()
        {


            int Label1 = Convert.ToInt32(labelWin1.Text);
            int Label2 = Convert.ToInt32(labelWin2.Text);

            string[] PlayerScoreNames = new string[2];
            PlayerScoreNames[0] = textBoxPlayer1.Text;
            PlayerScoreNames[1] = textBoxPlayer2.Text;

            int RemoveLabelWin1 = Label1 - 1;
            int RemoveLabelWin2 = Label2 - 1;

            string Player1Name = textBoxPlayer1.Text + space + Label1;
            string Player2Name = textBoxPlayer2.Text + space + Label2;



            if (!scoreBox.Items.Contains(PlayerScoreNames[0] + space + Label1))
            {
                scoreBox.Items.Add(Player1Name);
            }
            else if (scoreBox.Items.Contains(PlayerScoreNames[0] + space + RemoveLabelWin1))
            {
                scoreBox.Items.Remove(PlayerScoreNames[0] + space + RemoveLabelWin1);
                scoreBox.Items.Add(Player1Name);
            }



            //else if (scoreBox.Items.Contains(scoreBox.FindString(PlayerScoreNames[0])))
            //{
            //    scoreBox.Text.Replace(PlayerScoreNames[0], Player1Name);
            //}
            //if (!scoreBox.Items.Contains(scoreBox.FindString(PlayerScoreNames[1])))
            //{
            //    scoreBox.Items.Add(Player2Name);
            //}
            //else if (scoreBox.Items.Contains(scoreBox.FindString(PlayerScoreNames[1])))
            //{
            //    scoreBox.Text.Replace(PlayerScoreNames[1], Player2Name);
            //}




            //List<string> nameList = new List<string>();
            //nameList.Add(textBoxPlayer1.Text + " - " + labelWin1.Text);

            //if (scoreBox.Text.Contains(textBoxPlayer1.Text + " - " + labelWin1.Text) != true)
            //{
            //    scoreBox.Text.AddRange(nameList.ToArray());
            //}
            //else if (scoreBox.Text.Contains(textBoxPlayer1.Text + " - " + labelWin1.Text) == true)
            //{
            //    scoreBox.Text.Remove(textBoxPlayer1.Text);

            //}

            //int Score1 = Convert.ToInt32(labelWin1.Text);
            //int Score2 = Convert.ToInt32(labelWin2.Text);

            //List<string> nameList = new List<string>();
            //nameList.Add(textBoxPlayer1.Text + space + Score1.ToString());
            //nameList.Add(textBoxPlayer2.Text + space + Score2.ToString());

            //if (scoreBox.Items.Contains(nameList) != true)
            //{
            //    scoreBox.Items.AddRange(nameList.ToArray());
            //}
            //else
            //{
            //    return;
            //}


            //if (!scoreBox.Equals(nameList))
            //{
            //    scoreBox.Text.Add();
            //}







            //if (scoreBox.Text.Contains(textBoxPlayer1.Text + space + Score1) != true)
            //{
            //    scoreBox.Text.Add(textBoxPlayer1.Text + space + Score1);

            //}
            //else
            //{
            //    return;
            //}







            //if (!scoreBox.Text.Contains(textBoxPlayer1.Text) || !scoreBox.Text.Contains(textBoxPlayer2.Text))
            //{
            //    List<string> nameList = new List<string>();
            //    nameList.Add(textBoxPlayer1.Text + " - " + labelWin1.Text);
            //    nameList.Add(textBoxPlayer2.Text + " - " + labelWin2.Text);
            //    scoreBox.Text.AddRange(nameList.ToArray());
            //}
            //if (scoreBox.Text.Contains(textBoxPlayer1.Text + " - 0"))
            //{
            //    scoreBox.Text.Remove(textBoxPlayer1.Text + " - 0");

            //}
            //if (scoreBox.Text.Contains(textBoxPlayer2.Text))
            //{
            //    scoreBox.Text.Remove(textBoxPlayer2.Text);
            //}
        }

        public void WinAdd()
        {
            if (turn == false)
            {
                int Win1 = Convert.ToInt32(labelWin1.Text);
                Win1++;
                labelWin1.Text = Win1.ToString();
            }
            else
            {
                int Win1 = Convert.ToInt32(labelWin2.Text);
                Win1++;
                labelWin2.Text = Win1.ToString();
            }
        }

        public void WinLines()
        {
            #region WinLines
            if ((button1Game.BackColor == button2Game.BackColor) && (button2Game.BackColor == button3Game.BackColor) && (button3Game.BackColor != Color.Gray)) //1-2-3
            {
                WinorNot = true;
                CheckWin1.Visible = true;
                CheckWin2.Visible = true;
                CheckWin3.Visible = true;
            }
            if ((button4Game.BackColor == button5Game.BackColor) && (button5Game.BackColor == button6Game.BackColor) && (button6Game.BackColor != Color.Gray)) //4-5-6
            {
                WinorNot = true;
                CheckWin4.Visible = true;
                CheckWin5.Visible = true;
                CheckWin6.Visible = true;
            }
            if ((button7Game.BackColor == button8Game.BackColor) && (button8Game.BackColor == button9Game.BackColor) && (button9Game.BackColor != Color.Gray)) //7-8-9
            {
                WinorNot = true;
                CheckWin7.Visible = true;
                CheckWin8.Visible = true;
                CheckWin9.Visible = true;
            }
            if ((button1Game.BackColor == button4Game.BackColor) && (button4Game.BackColor == button7Game.BackColor) && (button7Game.BackColor != Color.Gray)) //1-4-7
            {
                WinorNot = true;
                CheckWin1.Visible = true;
                CheckWin4.Visible = true;
                CheckWin7.Visible = true;
            }
            if ((button2Game.BackColor == button5Game.BackColor) && (button5Game.BackColor == button8Game.BackColor) && (button8Game.BackColor != Color.Gray)) //2-5-8
            {
                WinorNot = true;
                CheckWin2.Visible = true;
                CheckWin5.Visible = true;
                CheckWin8.Visible = true;
            }
            if ((button3Game.BackColor == button6Game.BackColor) && (button6Game.BackColor == button9Game.BackColor) && (button9Game.BackColor != Color.Gray)) //3-6-9
            {
                WinorNot = true;
                CheckWin3.Visible = true;
                CheckWin6.Visible = true;
                CheckWin9.Visible = true;
            }
            if ((button1Game.BackColor == button5Game.BackColor) && (button5Game.BackColor == button9Game.BackColor) && (button9Game.BackColor != Color.Gray)) //1-5-9
            {
                WinorNot = true;
                CheckWin1.Visible = true;
                CheckWin5.Visible = true;
                CheckWin9.Visible = true;
            }
            if ((button3Game.BackColor == button5Game.BackColor) && (button5Game.BackColor == button7Game.BackColor) && (button7Game.BackColor != Color.Gray)) //3-5-7
            {
                WinorNot = true;
                CheckWin3.Visible = true;
                CheckWin5.Visible = true;
                CheckWin7.Visible = true;
            }
            #endregion

        }

        public void ResetAll()
        {
            #region Variables
            WinorNot = false;
            #endregion

            #region Button
            checkBoxPC.Enabled = true;
            checkBoxPC.Checked = false;

            button1Game.Enabled = false;
            button1Game.BackColor = Gray;
            button2Game.Enabled = false;
            button2Game.BackColor = Gray;
            button3Game.Enabled = false;
            button3Game.BackColor = Gray;
            button4Game.Enabled = false;
            button4Game.BackColor = Gray;
            button5Game.Enabled = false;
            button5Game.BackColor = Gray;
            button6Game.Enabled = false;
            button6Game.BackColor = Gray;
            button7Game.Enabled = false;
            button7Game.BackColor = Gray;
            button8Game.Enabled = false;
            button8Game.BackColor = Gray;
            button9Game.Enabled = false;
            button9Game.BackColor = Gray;

            buttonGameStart.Enabled = true;
            buttonGameStart.BackColor = White;

            CheckWin1.Visible = false;
            CheckWin2.Visible = false;
            CheckWin3.Visible = false;
            CheckWin4.Visible = false;
            CheckWin5.Visible = false;
            CheckWin6.Visible = false;
            CheckWin7.Visible = false;
            CheckWin8.Visible = false;
            CheckWin9.Visible = false;
            #endregion

            #region TextBox
            textBoxPlayer1.Text = nul;
            textBoxPlayer1.Enabled = true;
            textBoxPlayer2.Text = nul;
            textBoxPlayer2.Enabled = true;
            #endregion

            #region Label
            labelWin1.Visible = false;
            labelWin1.Text = "";
            labelWin2.Visible = false;
            labelWin2.Text = "";
            labelPlayerTurn.Visible = false;
            labelPlayerTurn.Text = "";
            labelWin1.Text = "0";
            labelWin2.Text = "0";
            #endregion
        }

        public void ResetWin()
        {
            #region Variables
            WinorNot = false;
            #endregion

            #region Button
            button1Game.Enabled = false;
            button1Game.BackColor = Gray;
            button2Game.Enabled = false;
            button2Game.BackColor = Gray;
            button3Game.Enabled = false;
            button3Game.BackColor = Gray;
            button4Game.Enabled = false;
            button4Game.BackColor = Gray;
            button5Game.Enabled = false;
            button5Game.BackColor = Gray;
            button6Game.Enabled = false;
            button6Game.BackColor = Gray;
            button7Game.Enabled = false;
            button7Game.BackColor = Gray;
            button8Game.Enabled = false;
            button8Game.BackColor = Gray;
            button9Game.Enabled = false;
            button9Game.BackColor = Gray;
            buttonGameStart.Enabled = true;
            buttonGameStart.BackColor = White;

            CheckWin1.Visible = false;
            CheckWin2.Visible = false;
            CheckWin3.Visible = false;
            CheckWin4.Visible = false;
            CheckWin5.Visible = false;
            CheckWin6.Visible = false;
            CheckWin7.Visible = false;
            CheckWin8.Visible = false;
            CheckWin9.Visible = false;
            #endregion

            #region Labels
            labelPlayerTurn.Visible = false;
            labelPlayerTurn.Text = "";
            #endregion
        }

        public void Game()
        {
            #region Fillin
            if (checkBoxPC.Checked == true && textBoxPlayer1.Text.Length > 0)
            {
                Gamestart();
                textBoxPlayer2.Text = PlayPC;
            }
            if (textBoxPlayer1.Text.Length > 0 && textBoxPlayer2.Text.Length > 0)
            {
                Gamestart();
            }
            if (textBoxPlayer1.Text.Length > 0 && checkBoxPC.Checked == true)
            {
                textBoxPlayer2.Text = PlayPC;
                Gamestart();
            }
            if (checkBoxPC.Checked == true && textBoxPlayer1.Text == nul)
            {
                MessageBox.Show(Fillin1);
            }
            if (textBoxPlayer1.Text == nul && textBoxPlayer2.Text == nul && checkBoxPC.Checked == false)
            {
                MessageBox.Show(FillinBoth);
            }
            if (textBoxPlayer2.Text.Length > 0 && textBoxPlayer1.Text.Length == 0 && checkBoxPC.Checked == false)
            {
                MessageBox.Show(Fillin1);
            }
            if (textBoxPlayer1.Text.Length > 0 && textBoxPlayer2.Text.Length == 0 && checkBoxPC.Checked == false)
            {
                MessageBox.Show(Fillin2);
            }
            #endregion

            if (!scoreBox.Text.Contains(textBoxPlayer1.Text))
            {

            }
        }

        public void Gamestart()
        {
            #region Button
            button1Game.Enabled = true;
            button2Game.Enabled = true;
            button3Game.Enabled = true;
            button4Game.Enabled = true;
            button5Game.Enabled = true;
            button6Game.Enabled = true;
            button7Game.Enabled = true;
            button8Game.Enabled = true;
            button9Game.Enabled = true;
            buttonGameStart.Enabled = false;
            buttonGameStart.BackColor = Green;
            checkBoxPC.Enabled = false;
            #endregion

            #region Textbox
            textBoxPlayer1.Enabled = false;
            textBoxPlayer2.Enabled = false;
            #endregion

            #region Label
            labelWin1.Visible = true;
            labelWin2.Visible = true;
            labelPlayerTurn.Visible = true;

            #endregion

            #region CaseSwitch
            int CaseSwitch;
            CaseSwitch = new Random().Next(2);

            switch (CaseSwitch)
            {
                case 0:
                    labelPlayerTurn.Text = textBoxPlayer1.Text;
                    turn = false;
                    return;
                case 1:
                    labelPlayerTurn.Text = textBoxPlayer2.Text;
                    turn = true;
                    return;
            }
            #endregion

        }

        public void WinrNot(object sender)
        {
            #region Misc
            Button Bpressed = (Button)sender;
            string Winner = "Congratulations " + labelPlayerTurn.Text + "!\n\n              You won!";
            #endregion
            if (Bpressed.BackColor == Blue || Bpressed.BackColor == Red)
            {
                return;
            }
            else
            {
                if (checkBoxPC.Checked == true)
                {
                    if (turn == true)
                    {
                        Bpressed.BackColor = Red;
                        WinLines();
                        if (WinorNot == true)
                        {
                            WinAdd();
                            #region MessageBoxWin
                            DialogResult OKreset = MessageBox.Show(Winner, WinTitle, MessageBoxButtons.OK);
                            if (OKreset == DialogResult.OK)
                            {
                                ResetWin();
                            }
                            #endregion

                        }
                        else
                        {
                            labelPlayerTurn.Text = textBoxPlayer1.Text;
                            turn = false;
                        }
                    }
                    else
                    {
                        AItimer.Start();
                        Bpressed.BackColor = Blue;
                        WinLines();
                        if (WinorNot == true)
                        {
                            #region MessageBoxWin
                            DialogResult OKreset = MessageBox.Show(Winner, WinTitle, MessageBoxButtons.OK);
                            if (OKreset == DialogResult.OK)
                            {
                                ResetWin();
                            }
                            #endregion
                            WinAdd();
                        }
                        else
                        {
                            labelPlayerTurn.Text = textBoxPlayer2.Text;
                            turn = true;
                        }
                    }

                }
                else
                {
                    if (turn == true)
                    {
                        Bpressed.BackColor = Red;
                        WinLines();
                        if (WinorNot == true)
                        {
                            WinAdd();
                            #region MessageBoxWin
                            DialogResult OKreset = MessageBox.Show(Winner, WinTitle, MessageBoxButtons.OK);
                            if (OKreset == DialogResult.OK)
                            {
                                ResetWin();
                                AddToList();
                            }
                            #endregion
                        }
                        else
                        {
                            labelPlayerTurn.Text = textBoxPlayer1.Text;
                            turn = false;
                        }
                    }
                    else
                    {
                        Bpressed.BackColor = Blue;
                        WinLines();
                        if (WinorNot == true)
                        {
                            WinAdd();
                            #region MessageBoxWin
                            DialogResult OKreset = MessageBox.Show(Winner, WinTitle, MessageBoxButtons.OK);
                            if (OKreset == DialogResult.OK)
                            {
                                ResetWin();
                                AddToList();
                            }
                            #endregion

                        }
                        else
                        {
                            labelPlayerTurn.Text = textBoxPlayer2.Text;
                            turn = true;
                        }
                    }
                }

            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Info, InfoTitle, MessageBoxButtons.OK);
            if (dialogResult == DialogResult.OK)
            {
                return;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Reset, ResetTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ResetAll();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Exit, ExitTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            Game();
        }

        private void buttonGame_Click(object sender, EventArgs e)
        {
            WinrNot(sender);
        }

        private void AIT(object sender, EventArgs e)
        {

        }

        private void checkBoxPC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPC.Checked != true)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = nul;
            }
            if (checkBoxPC.Checked != false)
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = nul;
            }
        }


        //public void PlayerScoreInfo()
        //{
        //    if (!scoreBox.Items.Contains(textBoxPlayer1.Text + space + Enumerable.Range(0, 100)))
        //    {

        //    }
        //}
    }
}






//           if (textBoxPlayer1.Text == nul && textBoxPlayer2.Text == nul)
//          {
//              if (checkBoxPC.Checked == true)
//              {
//                 MessageBox.Show(Fillin, FillinTitle, MessageBoxButtons.OK);
//               }
//                else
//               {
//                  MessageBox.Show(Fillin, FillinTitle, MessageBoxButtons.OK);
//               }
//           }
//           else
//           {
//              GameStart();
//            }
