using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Voice_Rocognition
{
    class koneksi
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        private void myPingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            synth.SetOutputToDefaultAudioDevice();

            if (e.Cancelled)
                return;

            if (e.Error != null)
            {
                synth.Speak("Looks like we're having a little problem with the internet connection sir!");
                return;
            }
               
               

            if (e.Reply.Status == IPStatus.Success)
            {
                synth.Speak("You're connected to the Intenet sir!");
            }
        }

        public void checkInternet()
        {
            Ping myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(myPingCompletedCallback);
            try
            {
                myPing.SendAsync("google.com", 3000 /*3 secs timeout*/, new byte[8], new PingOptions(64, true));
            }
            catch
            {
            }
        }

        
        public void Network()
        {
            IsNetworkAvailable(0);
        }

       
        public static bool IsNetworkAvailable(long minimumSpeed)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                synth.Speak("Sorry, You're not connected to the Network sir!");
                return false;
            }

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                    continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                synth.Speak("You're connected to the Network sir!");
                return true;
            }
            return false;
        }

        public void pingGoogle()
        {
            string strCmdText;
            strCmdText = "ping www.google.com -t -l 8";
            System.Diagnostics.Process.Start("CMD.exe", "/C ping www.google.com -t -l 8");
        }
    }
}
