using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridGame
{
    public partial class MainForm : Form
    {

        private Game game = new Game();


        public MainForm()
        {
            InitializeComponent();

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (objCombat.Checked)
            {
                game.CliqueUsuario(e.RowIndex, e.ColumnIndex, EnuTipoConstrucao.Combat);
            }
            else if (objResource.Checked)
            {
                game.CliqueUsuario(e.RowIndex, e.ColumnIndex, EnuTipoConstrucao.Resources);
            }
            UpdateScoreScreen();

        }

        private void UpdateScoreScreen()
        {

            int restantes = game.UpdatePlayerScore();
            listView1.Items.Clear();


            foreach (Player p in game.Players)
            {
                AddLvwValue(p);

            }

            lblRemaining.Text = "Remaning blocks: " + restantes;

            //TODO: Refaze fim do jogo
            //if (restante == 0)
            //{
            //    if (blocksPlayer1 == blocksPlayer2)
            //    {
            //        if (scorePlayer1 == scorePlayer2)
            //        {
            //            FimDoJogo(0);
            //        }
            //        else if (scorePlayer1 > scorePlayer2)
            //        {
            //            FimDoJogo(1);
            //        }
            //        else
            //        {
            //            FimDoJogo(2);
            //        }
            //    }
            //    else if (blocksPlayer1 > blocksPlayer2)
            //    {
            //        FimDoJogo(1);
            //    }
            //    else
            //    {
            //        FimDoJogo(2);
            //    }

            //}


        }

        void FimDoJogo(int JogadorVencedor)
        {

            string msg = "Fim do jogo\n";


            if (JogadorVencedor > 0)
            {
                msg = "O Jogador " + JogadorVencedor + " venceu.";
            }
            else
            {
                msg = "O jogo empatou";
            }
            MessageBox.Show(msg);
        }

        void AddLvwValue(Player p)
        {

            ListViewItem lvi = listView1.Items.Add(p.Name);
            lvi.UseItemStyleForSubItems = false;
            if (p == game.CurrentPlayer)
            {
                lvi.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                lvi.BackColor = Color.White;
            }

            ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("●");
            lvsi.ForeColor = p.Cor;
            lvsi.BackColor = p.Cor;
            lvi.SubItems.Add(Convert.ToString(p.Money));
            lvi.SubItems.Add(Convert.ToString(p.Score));
            lvi.SubItems.Add(Convert.ToString(p.CntBlocks));

            //lvi.ForeColor = p.Cor;

        }





        private void btnStart_Click(object sender, EventArgs e)
        {
            game.StartNewGame(dataGridView1, Convert.ToInt32(txtPlayers.Value));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }


}
