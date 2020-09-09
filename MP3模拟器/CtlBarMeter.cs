using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3模拟器
{
    public partial class CtlBarMeter : UserControl
    {
        public CtlBarMeter()
        {
            InitializeComponent();
        }


        public override Color BackColor { get => base.BackColor; set { base.BackColor = value; mask.BackColor = value; } }

        float smoothfactor = 0.19f;

        float animedValue = 0;

        float _value = 0;
        public float Value {
            get { return _value; }
            set {
                _value = value;
                if (_value > 1) { _value = 1; }
                if (_value < 0) { _value = 0; }

                valuehistory[ptr] = _value;

                ptr++;
                if (ptr >= valuehistory.Length) { ptr = 0; }

                animedValue = animedValue + (valuehistory[ptr] - animedValue) * smoothfactor;

                mask.Height = (int)(this.Height * (1- animedValue)) + 1;
                //mask.Height = (int)(this.Height * (1- valuehistory[ptr])) + 1;
            }
        }

        public float[] valuehistory = new float[19];
        public int ptr = 0;
        private void CtlBarMeter_Load(object sender, EventArgs e)
        {

        }
    }
}
