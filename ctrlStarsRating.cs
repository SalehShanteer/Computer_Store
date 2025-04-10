using Computer_Store.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlStarsRating : UserControl
    {

        public int RateFrom { get; set; }
        private float _Rate { get 
            { 
                return (float)RateFrom / 10f;
            } 
        }

        public ctrlStarsRating()
        {
            InitializeComponent();
        }

        public void DisplayRating(decimal? rating)
        {
            if (rating is null) return;

            float Rating = (float)rating;

            PictureBox[] starControls = { pbStar1, pbStar2, pbStar3, pbStar4, pbStar5 };

            for (int i = 0; i < starControls.Length; i++)
            {
                if (Rating >= i + _Rate)
                {
                    starControls[i].Image = Resources.FullStar;
                }
                else
                {
                    starControls[i].Image = Resources.EmptyStar;
                }
            }
        }
    }
}
