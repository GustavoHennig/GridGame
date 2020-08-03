using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GridGame
{
    /// <summary>
    /// Regras:
    ///     Só pode construir perto de outra construção
    ///     Existem dois tipos de construções: Recursos e Combate
    ///         Recursos geram recursos a cada rodada que permitem construir mais
    ///         Combate: Protegem dos inimigos e os atacam.
    /// 
    /// 
    /// </summary>
    class Game
    {

        public DataGridView gridView;

        public Player CurrentPlayer = null;

        public List<Player> Players = null;
        float PlayValue = 1;
        int GridSize;

        public void StartNewGame(DataGridView dtgrd, int NroPlayers)
        {

            gridView = dtgrd;
            GridSize = 10;

            GenerateGrid(GridSize);
            Players = new List<Player>();
            for (int i = 1; i < NroPlayers + 1; i++)
            {
                Players.Add(new Player(i));
            }
            foreach (Player p in Players)
            {

                p.Money = 5;

                CellData cd = null;

                switch (p.PlayerId)
                {
                    case 1:
                        cd = getCellData(gridView[0, 0]);

                        break;
                    case 2:
                        cd = getCellData(gridView[GridSize-1, GridSize-1]);
                        break;
                    case 3:
                        cd = getCellData(gridView[0, GridSize-1]);
                        break;
                    case 4:
                        cd = getCellData(gridView[GridSize -1 , 0]);
                        break;
                }

                cd.Locked = false;
                cd.Tipo = EnuTipoConstrucao.StartPoint;
                cd.Player = p;

            }
            CurrentPlayer = Players[0];
        }


        public void UpdateNeighbor(CellData cd)
        {
            foreach (DataGridViewCell dc in getNeighbors(cd.ColumnIndex, cd.RowIndex, false))
            {
                if (dc != null)
                {
                    CellData cdn = getCellData(dc);
                    if (!cdn.Locked)
                    {
                        if (cdn.Player == CurrentPlayer)
                        {
                            cdn.IncreaseValue(PlayValue / 2);
                        }
                        else
                        {
                            cdn.IncreaseValue((PlayValue * -1) / 2);

                            if (cdn.Value <= 0)
                            {
                                cdn.Player = CurrentPlayer;
                                cdn.Value = cdn.Value * -1;
                            }
                        }
                    }
                }

            }

        }

        public DataGridViewCell[] getNeighbors(int c, int r, bool Plus)
        {

            DataGridViewCell[] ret = new DataGridViewCell[8];

            if (c - 1 >= 0)
            {
                ret[0] = gridView[c - 1, r];
            }

            if (r - 1 >= 0)
            {
                ret[1] = gridView[c, r - 1];
            }

            if (c + 1 < gridView.ColumnCount)
            {
                ret[2] = gridView[c + 1, r];
            }

            if (r + 1 < gridView.RowCount)
            {
                ret[3] = gridView[c, r + 1];
            }
            if (Plus) {
                if (c - 1 >= 0 && r - 1 >= 0)
                {
                    ret[4] = gridView[c - 1, r - 1];
                }

                if (r - 1 >= 0 && c + 1 < gridView.ColumnCount)
                {
                    ret[5] = gridView[c + 1, r - 1];
                }

                if (c + 1 < gridView.ColumnCount && r + 1 < gridView.RowCount)
                {
                    ret[6] = gridView[c + 1, r + 1];
                }

                if (c - 1 >= 0 && r + 1 < gridView.RowCount)
                {
                    ret[7] = gridView[c - 1, r + 1];
                } 
            
            }
            return ret;
        }

        public void ExecuteAPlay(CellData cd)
        {



            if (cd.Player == CurrentPlayer)
            {
                cd.IncreaseValue(PlayValue);
            }
            else
            {
                cd.IncreaseValue((PlayValue * -1));

                if (cd.Value <= 0)
                {
                    cd.Player = CurrentPlayer;
                    cd.Value = cd.Value * -1;
                }
            }

            UpdateNeighbor(cd);

            CurrentPlayer = NextPlayer;
            if (CurrentPlayer.isComputer)
            {
                ComputerPlay();

            }


        }


        public void GenerateGrid(int gridSize)
        {

            this.GridSize = gridSize;

            for (int i = 0; i < gridSize; i++)
            {
                //; 
                gridView.Columns.Add("cn" + i, "");//new DataGridViewImageColumn());
            }

            foreach (DataGridViewColumn dc in gridView.Columns)
            {
                dc.Width = 24;
                //dc.CellTemplate = new DataGridViewImageCell();

            }



            gridView.Rows.Add(gridSize);

            foreach (DataGridViewRow dgvr in gridView.Rows)
            {

                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {

                    dgvc.Tag = new CellData(dgvc);
                    // dgvc.ValueType = typeof(string);
                    dgvc.Value = 0;

                }
                dgvr.Height = 24;
            }

            RandonLockCells();

        }

        public void RandonLockCells()
        {

            int nroCellsLocked = 10;

            do
            {
                DataGridViewCell sortedCell = getRandomCell();

                getCellData(sortedCell).Locked = true;
                sortedCell.Style.BackColor = Color.Black;

                nroCellsLocked--;
            }
            while (nroCellsLocked > 0);
        }

        public void ComputerPlay()
        {

            ExecuteAPlay(getCellData(getMelhorJogadaPossivel2()));
        }

        public DataGridViewCell getRandomCell()
        {
            Random rnd = new Random();
            DataGridViewCell ret = null;
            CellData cd = null;
            do
            {
                int c = rnd.Next(0, gridView.ColumnCount - 1);
                int r = rnd.Next(0, gridView.RowCount - 1);
                ret = gridView[c, r];
                cd = getCellData(ret);
            } while (cd.Locked || !(cd.Value <= 0 || cd.Player == CurrentPlayer));

            return ret;

        }

        public CellData getCellData(DataGridViewCell dc)
        {
            return (CellData)dc.Tag;
        }

        public float getCellDataIndividualPoints(CellData cd)
        {

            float ret = 0;
            if (!cd.Locked)
            {
                if (cd.Player == null)
                {
                    ret++;
                }
                else if (cd.Player == CurrentPlayer)
                {
                    ret += (float).1;
                }
                else
                {
                    if (cd.Value - (PlayValue / 2) <= 0)
                    {
                        ret += (float).5;
                    }
                    else if (cd.Value - (PlayValue / 2) <= .5)
                    {
                        ret += (float).3;
                    }
                    else if (cd.Value - (PlayValue / 2) <= 1)
                    {
                        ret += (float).2;

                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Como funciona este cálculo:
        /// Se for em branco ganha 1 ponto
        ///     adversário 0,5 ponto
        ///     no próprio 0,1 ponto
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        public float QntBlocosJogada(CellData cd)
        {



            float blk = 0;

            blk = getCellDataIndividualPoints(cd);

            foreach (DataGridViewCell dc in getNeighbors(cd.ColumnIndex, cd.RowIndex, false))
            {
                if (dc != null)
                {
                    CellData cdn = getCellData(dc);
                    blk += getCellDataIndividualPoints(cdn);
                }
            }
            return blk;

        }


        public DataGridViewCell getMelhorJogadaPossivel(int minimoVizinhosBrancos, float maximoDePontosAdversariosUnitario)
        {
            // Passos para uma boa jogada:
            // 1. Preencher o mairo nro de brancos possíveis
            // 2. Desfazer o maior nro de blocos adversários possíveis por jogoda

            //TA tudo errado.

            //É bem mais simples: Varrer todas jogadas possíveis e calcular em quais jogadas se ganha mais blocos.

            if (minimoVizinhosBrancos < 0)
            {
                return getRandomCell();
            }



            foreach (DataGridViewRow dgvr in gridView.Rows)
            {
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    CellData cd = getCellData(dgvc);
                    int cntBlk = 0;
                    int cntAdv = 0;

                    if ((cd.Player == null || cd.Player == ComputerPlayer) && !cd.Locked)
                    {
                        foreach (DataGridViewCell dc in getNeighbors(cd.ColumnIndex, cd.RowIndex, false))
                        {
                            if (dc != null)
                            {
                                CellData cdn = getCellData(dc);
                                if (!cdn.Locked)
                                {
                                    if (cdn.Player == null)
                                    {
                                        cntBlk++;
                                    }
                                    else if (cdn.Value <= maximoDePontosAdversariosUnitario)
                                    {
                                        cntAdv++;
                                    }
                                }
                            }
                        }
                    }
                    if (cntBlk >= minimoVizinhosBrancos)
                    {
                        return dgvc;
                    }
                    if (cntAdv + cntBlk == 4)
                    {
                        return dgvc;
                    }


                }
            }


            maximoDePontosAdversariosUnitario += (float)0.5;

            if (maximoDePontosAdversariosUnitario > 1)
            {
                //maximoDePontosAdversariosUnitario
                minimoVizinhosBrancos--;
            }


            return getMelhorJogadaPossivel(minimoVizinhosBrancos, maximoDePontosAdversariosUnitario);




        }




        public DataGridViewCell getMelhorJogadaPossivel2()
        {


            DataGridViewCell melhorjogada = getRandomCell();
            float pontosMelhorJogada = 0;

            foreach (DataGridViewRow dgvr in gridView.Rows)
            {
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    CellData cd = getCellData(dgvc);

                    if ((cd.Player == null || cd.Player == CurrentPlayer) && !cd.Locked)
                    {
                        float vlc = QntBlocosJogada(cd);
                        if (vlc > pontosMelhorJogada)
                        {
                            pontosMelhorJogada = vlc;
                            melhorjogada = dgvc;
                        }
                    }
                }
            }

            return melhorjogada;
        }


        public void CliqueUsuario(int row, int col, EnuTipoConstrucao opt)
        {
            if (col >= 0 && row >= 0)
            {

                CellData cd = getCellData(gridView[col, row]);

                if(ValidPlay(cd))
                {

                    if (cd.Value <= 0 || cd.Player == CurrentPlayer)
                    {
                        cd.Tipo = opt;
                        ExecuteAPlay(cd);
                        // UpdatePlayerScore();
                    }
                }
            }

        }

        public List<CellData> getNeighbors(CellData cd, bool Plus) { 
        
            List<CellData> ret = new List<CellData>();

            foreach (DataGridViewCell dc in getNeighbors(cd.ColumnIndex, cd.RowIndex, Plus))
            {
                if (dc != null)
                {
                    ret.Add(getCellData(dc));

                }
            }

            return ret;
        }

         
        public bool ValidPlay(CellData cd) {

            if (cd.Tipo == EnuTipoConstrucao.StartPoint) {
                return false;
            }

            if (cd.Locked) {
                return false;
            }

            if (cd.Player == CurrentPlayer) {
                return true;
            }


            foreach (CellData c in getNeighbors(cd, true)) {
                if (c.Player == CurrentPlayer) {
                    return true;
                }

            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna o nro de blocos restantes</returns>
        public int UpdatePlayerScore()
        {


            int restante = 0;

            foreach (Player p in Players)
            {
                p.CntBlocks = 0;
                p.Score = 0;
            }

            foreach (DataGridViewRow dgvr in gridView.Rows)
            {
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    CellData cd = getCellData(dgvc);

                    if (cd.Player != null)
                    {
                        cd.Player.Score += cd.Value;
                        cd.Player.CntBlocks++;
                    }
                    else
                    {
                        if (!cd.Locked)
                        {
                            restante++;
                        }

                    }
                }
            }

            return restante;
        }

        public Player ComputerPlayer
        {
            get
            {

                foreach (Player p in Players)
                {
                    if (p.isComputer)
                    {
                        return p;
                    }
                }
                return null;

            }
        }

        public Player NextPlayer
        {
            get
            {

                if (CurrentPlayer == null)
                {
                    return Players[0];
                }
                else
                {

                    foreach (Player p in Players)
                    {
                        if (p.PlayerId > CurrentPlayer.PlayerId)
                        {
                            {
                                return p;
                            }
                        }
                    }
                    return Players[0];
                }
            }
        }
    }


}

