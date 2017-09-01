using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO.Ports;
using System.Diagnostics;

namespace Voice_Rocognition
{
    public partial class Form1 : Form
    {

        private SerialPort myPort;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synth = new SpeechSynthesizer();
        DateTime waktu = DateTime.Now;
        Process pr = new Process();
        NotifyIcon notifyIcon = new NotifyIcon();
        bool exitCondition = false;
        koneksi konek = new koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_aktif_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btn_aktif.Enabled = false;
            btn_nonAktif.Enabled = true;
            richTextBox1.Text = "Jarvis is Ready!!";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices perintah = new Choices();
            perintah.Add(new string[] { "Jarvis","hallo Jarvis", "print my name", "fine", "nothing", "what is your name", 
                "turn on light 1", "turn on light 2", "turn on light 3", "turn on light 4",
                "turn off light 1", "turn off light 2", "turn off light 3", "turn off light 4", 
                "turn on all light", "turn off all light", "what is your status", "thanks Jarvis", "thank you", 
                "ready for fight", "describe your self", "Zira", 
                "Current Date", "Current Day", "Current Time",
                "internet", "facebook", "youtube", "email", "exit", "yes", "invisible", "visible", "no",
                "I will go", "check connection", "check our internet connection", "check our network connection", "ping google"});
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(perintah);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Hello sir.");
            synth.Speak("Please wait for a second, I will run the programm.");
            richTextBox1.Text = "Jarvis is ready..";
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {


            if (exitCondition)
            {
                if (e.Result.Text == "yes")
                {
                    synth.Speak("Good bye sir!");
                    synth.SpeakAsyncCancelAll();
                    recEngine.RecognizeAsyncCancel();
                    Application.Exit();

                    return;
                }
                else { exitCondition = false; synth.Speak("Exit Cancelled"); return; }
            }
            
            switch(e.Result.Text){
                case "hallo Jarvis":
                    synth.SelectVoice("IVONA 2 Brian");
                    synth.Speak("Hallo sir, how are U today?");
                    break;
                case "print my name":
                    richTextBox1.Text += "\nAnanda";
                    synth.Speak("Your name is printed sir.");
                    break;
                case "fine":
                    synth.Speak("Nice, What can I do for U sir?");
                    break;
                case "nothing":
                    synth.Speak("Oke sir, I will wait for the command from you sir.");
                    break;
                case "what is your name":
                    synth.Speak("My name is Jarvis sir.");
                    break;
                case "Jarvis":
                    synth.SelectVoice("IVONA 2 Brian");
                    synth.Speak("Yes sir!");
                    break;
                case "turn on light 1":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("B");
                        myPort.Close();
                        synth.Speak("Light 1 is turned on sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn on light 2":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("D");
                        myPort.Close();
                        synth.Speak("Light 2 is turned on sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn on light 3":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("F");
                        myPort.Close();
                        synth.Speak("Light 3 is turned on sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn on light 4":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("H");
                        myPort.Close();
                        synth.Speak("Light 4 is turned on sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn on all light":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("B");
                        myPort.WriteLine("D");
                        myPort.WriteLine("F");
                        myPort.WriteLine("H");
                        myPort.Close();
                        synth.Speak("All light, is turned on sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn off light 1":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("A");
                        myPort.Close();
                        synth.Speak("Light 1 is turned off sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn off light 2":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("C");
                        myPort.Close();
                        synth.Speak("Light 2 is turned off sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn off light 3":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("E");
                        myPort.Close();
                        synth.Speak("Light 3 is turned off sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn off light 4":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("G");
                        myPort.Close();
                        synth.Speak("Light 4 is turned off sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "turn off all light":
                    try
                    {
                        myPort = new SerialPort();
                        myPort.BaudRate = 9600;
                        myPort.PortName = "COM10";
                        myPort.Open();

                        myPort.WriteLine("A");
                        myPort.WriteLine("C");
                        myPort.WriteLine("E");
                        myPort.WriteLine("G");
                        myPort.Close();
                        synth.Speak("All light, is turned off sir.");
                    }
                    catch (Exception)
                    {
                        synth.Speak("Sorry sir, you not connected to the Arduino.");

                    }
                    break;
                case "what is your status":
                    synth.Speak("I'm ready for your command sir.");
                    break;
                case "thanks Jarvis":
                    synth.SelectVoice("IVONA 2 Brian");
                    synth.Speak("You're welcome sir.");
                    break;
                case "thank you":
                    synth.Speak("Anytime sir.");
                    break;
                case "ready for fight":
                    synth.Speak("Not sir, I'm is not fighter for now.");
                    break;
                case "describe your self":
                    synth.Speak("My name is Jarvis. I'm created by Ananda, on 30 September 2015, at 15 O'clock West Indonesian Time.");
                    synth.Speak("I'm accepted command by Voice.");
                    break;
                case "Current Date":
                    synth.Speak(waktu.ToString("dd MMMM yyyy"));
                    break;
                case "Current Time":
                    synth.Speak(waktu.ToString("hh mm ss"));
                    richTextBox1.Text += waktu.ToString("hh mm ss");
                    break;
                case "internet":
                    synth.Speak("Affirmative!");
                    pr.StartInfo.FileName = "http://www.google.com/";
                    pr.Start();
                    break;
                case "youtube":
                    synth.Speak("Affirmative!");
                    pr.StartInfo.FileName = "http://www.youtube.com/";
                    pr.Start();
                    break;
                case "email":
                    synth.Speak("Affirmative!");
                    pr.StartInfo.FileName = "http://gmail.google.com/";
                    pr.Start();
                    break;
                case "exit":
                    synth.Speak("Are you sure you want to exit?");
                    exitCondition = true;
                    break;
                case "invisible":
                    synth.Speak("Affirmative!");
                        notifyIcon.Visible = true;
                        notifyIcon.ShowBalloonTip(30000, "Jarvis", "I am here sir!", ToolTipIcon.Info);

                        this.ShowInTaskbar = false;
                        this.Hide();
                        notifyIcon.Icon = SystemIcons.Information;
                        notifyIcon.BalloonTipText = "I am here";
                        notifyIcon.Text = "I am Here. -Jarvis-";

                        synth.Speak("I am now invisible. You can access me by say visible.");
                        break;
                case "visible":
                    synth.Speak("Affirmative!");
                    notifyIcon.Visible = false;
                    this.ShowInTaskbar = true;
                    this.Show();
                    synth.Speak("I am now visible.");
                    break;
                case "I will go":
                    synth.Speak("Affirmative! I will lock your laptop sir.");
                    System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                    break;
                case "check our network connection":
                    synth.Speak("Affirmative!");
                    konek.Network();
                    break;
                case "check our internet connection":
                    synth.Speak("Affirmative!");
                    konek.checkInternet();
                    break;
                case "ping google":
                    synth.Speak("Affirmative!");
                    konek.pingGoogle();
                    break;
            }
        }

        private void btn_nonAktif_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btn_nonAktif.Enabled = false;
            btn_aktif.Enabled = true;
            richTextBox1.Text = "Jarvis is Disable!!";
        }

    }
}
