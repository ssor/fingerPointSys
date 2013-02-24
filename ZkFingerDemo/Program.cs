using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace ZkFingerDemo
{
    static class Program
    {
        public static AxZKFPEngXControl.AxZKFPEngX g_ZKFP;
        public static int g_zkfp_handle = -1;
        public static frmInputFingerPrint frmInput;
        public static SpeechSynthesizer _synth = new SpeechSynthesizer();
        public static frmUserIdentify frmIdentify;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _synth.SelectVoice("Microsoft Lili");
            //_synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 1, new System.Globalization.CultureInfo("zh-CHS"));
            _synth.Rate = -2;

            Application.Run(new FingerMainForm());
            //Application.Run(new FingerDemo());
        }
        public static void play_voice(string str)
        {
            _synth.SpeakAsyncCancelAll();
            //_synth.Speak(str);
            _synth.SpeakAsync(str);
        }
    }
}
