using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GridGame
{

    public enum EnuTipoConstrucao {
        StartPoint = 1,
        Resources = 2,
        Combat = 3
    }

    class CellData
    {



        DataGridViewCell Parent;
        public CellData(DataGridViewCell parent)
        {
            this.Parent = parent;
        }

        public EnuTipoConstrucao Tipo;
        private float _Value;
        private Player _Player;
        private bool _Locked;
        public float Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                Parent.Value = ShowText;
                if (_Value == 0)
                {
                    Player = null;
                }
            }
        }

        public Player Player
        {
            get
            {
                return _Player;
            }
            set
            {
                _Player = value;
                Parent.Style.BackColor = Backcolor;
                //Parent.Style.i

            }
        }
        public bool Locked
        {
            get { return _Locked; }
            set
            {
                _Locked = value;
                Parent.Value = "";
                Parent.Style.BackColor = Backcolor;

            }
        }
        public int RowIndex { get { return Parent.RowIndex; } }
        public int ColumnIndex { get { return Parent.ColumnIndex; } }

        public Color Backcolor
        {
            get
            {
                if (Locked) {
                    return Color.Black;
                }


                if (Player == null)
                {
                    return Color.WhiteSmoke;
                }
                else {
                    return Player.Cor;
                }


            }
        }

        public string ShowText
        {
            get
            {
                if (Tipo == EnuTipoConstrucao.StartPoint) {
                    return "#";
                }
                if (Value == 0)
                {
                    
                    return "";
                }
                else
                {

                    return Convert.ToString(Value);
                }
            }
        }

        public void IncreaseValue(float v) {

            Value += v;
        
        }
    }
}
