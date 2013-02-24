using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZkFingerDemo
{
    static class Program
    {
        public static AxZKFPEngXControl.AxZKFPEngX g_ZKFP;
        public static int g_zkfp_handle = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FingerMainForm());
            //Application.Run(new FingerDemo());
        }
    }
}
