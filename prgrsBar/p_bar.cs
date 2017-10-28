using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prgrsBar
{
    public static class p_bar
    {
        public static void Init(ProgressBar p_bar, int max_value)
        {
            p_bar.Value = 0;
            p_bar.Maximum = max_value;
        }

        public static void Run(ProgressBar p_bar, int filesCount)
        {
            if (p_bar.Value < filesCount) p_bar.Value++;
        }
    }
}
