using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GridGame
{
    class Player
    {

        public int Money;
        public float Score;
        public int CntBlocks;
        public int PlayerId;
        public bool isComputer;
        private string _name;

        public Player(int plid)
        {
            PlayerId = plid;

            switch (plid)
            {
                case 1:
                    Cor = Color.Blue;
                    break;
                case 2:
                    Cor = Color.Red;
                    break;
                case 3:
                    Cor = Color.GreenYellow  ;
                    break;
                case 4:
                    Cor = Color.Purple ;
                    break;
                case 5:
                    Cor = Color.Yellow;
                    break;
                default:
                    Cor = Color.WhiteSmoke;
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Player)
            {
                return ((Player)obj).PlayerId == this.PlayerId;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public Color Cor;

        public string Name
        {
            get
            {

                if (_name == null)
                {
                    return "Player: " + PlayerId;
                }
                else
                {
                    return _name;
                }
            }
            set
            {
                _name = value;
            }
        }
    }
}
