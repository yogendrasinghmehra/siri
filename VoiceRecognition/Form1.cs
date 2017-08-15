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
using System.IO;
using System.Diagnostics;
using CommandsLibrary;
using System.Windows;
using System.Net.NetworkInformation;


namespace VoiceRecognition
{


    public partial class Form1 : Form
    {

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
      
        public Boolean search = false;
        public Boolean awake = false;

        public Form1()
        {
            InitializeComponent();
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                Choices commands = new Choices();
                commands.Add(File.ReadAllLines(@"C:\Users\GHANSHYAM SINGH\Documents\Visual Studio 2013\Projects\VoiceRecognition\VoiceRecognition\commands.txt"));
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commands);
                Grammar grammer = new Grammar(gBuilder);
                recEngine.LoadGrammarAsync(grammer);
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                
                throw;
            }
          
        

        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

           

            CommandsOperations commandsOpertion = new CommandsOperations();
            if (search == true && e.Result.Text.Equals("stop searching"))
            {
                search = false;
                synthesizer.SpeakAsync("Ok sir I will stop searching now.");
                chatbox.Text += "\n Siri >> " + "Ok sir I will stop searching now.";
            }
            if (search)
            {
                Process.Start("https://www.google.co.in/search?q=" + e.Result.Text);
            }
            if (e.Result.Text.Equals("hi Siri"))
            {
                synthesizer.SpeakAsync(commandsOpertion.ReplyHi());
                chatbox.Text += "\n Siri > " + commandsOpertion.ReplyHi() + "\n";
                awake = true;
            }

            if (awake)
            {
                chatbox.Text += "\n you >" + e.Result.Text;
                switch (e.Result.Text)
                {

                    
                    case "Who Are You":
                        synthesizer.SpeakAsync("Aap Chutiaa hai");
                        break;
                    
                   
                    case "close this window":
                        SendKeys.Send("%{f4}");
                        break;

                    case "next window":

                        SendKeys.Send("%{TAB}");
                        break;

                    case "goodbye Siri":
                        synthesizer.SpeakAsync(commandsOpertion.ReplyGoodBye());
                        chatbox.Text += "\n Siri >" + commandsOpertion.ReplyGoodBye() + "\n";
                        System.Threading.Thread.Sleep(3000);
                        recEngine.RecognizeAsyncStop();
                        Application.Exit();
                        break;

                    case "how are you":
                        synthesizer.SpeakAsync(commandsOpertion.ReplyHowAreYou());
                        chatbox.Text += "\n Siri >" + commandsOpertion.ReplyHowAreYou() + "\n";
                        break;

                    case "what time is it":
                        DateTime getTime = DateTime.Now;
                        synthesizer.SpeakAsync(commandsOpertion.ReplyTime());
                        chatbox.Text += "\n Siri >" + commandsOpertion.ReplyTime() + "\n";
                        break;

                    case "what is today":
                        DateTime getDate = DateTime.Now;
                        synthesizer.SpeakAsync(commandsOpertion.ReplyDate());
                        chatbox.Text += "\n Siri >" + commandsOpertion.ReplyDate() + "\n";
                        break;

                    case "search for":
                        if (search == false)
                        {
                            search = true;
                            synthesizer.SpeakAsync("What you want to search?");
                            chatbox.Text += "\n Siri >" + "What you want to search?" + "\n";
                        }
                        break;

                    case "go to desktop":
                        synthesizer.SpeakAsync(commandsOpertion.goToDesktop());
                        chatbox.Text += "\n Siri >" + "We are now on desktop screen." + "\n";
                        break;

                    case "check my mails":
                        
                        synthesizer.SpeakAsync("opening your mails sir.");
                        chatbox.Text += "\n Siri >" + "opening your mails sir." + "\n";
                        Process.Start("https://mail.google.com/mail/u/0/#inbox");
                        break;

                    case "commands":
                        if (commandsList.Visible == false)
                        {
                            string[] allCommands = File.ReadAllLines(@"C:\Users\GHANSHYAM SINGH\Documents\Visual Studio 2013\Projects\VoiceRecognition\VoiceRecognition\commands.txt");
                            foreach (var i in allCommands)
                            {
                                commandsList.Items.Add(i);
                            }
                            commandsList.Visible = true;
                        }
                        break;


                    case "Go Away":
                       this.WindowState = FormWindowState.Minimized;
                       synthesizer.SpeakAsync("I'm Gone");
        
                        break;

                    case "Come Back Siri":
                        this.WindowState = FormWindowState.Maximized;
                        synthesizer.SpeakAsync("I'm Back sir,Tell me what to do.");
                        break;

                    case "play music":

                        synthesizer.SpeakAsync("Here you go, put your dancing shoes on.");
                        chatbox.Text += "\n Siri >" + "Here you go, put your dancing shoes on." + "\n";
                        Task.Delay(3000);
                        Process.Start("wmplayer.exe", @"D:\yogi\songs\Sia.mp3");
                        break;

                    case "stop music":
                        var music_process = Process.GetProcessesByName("wmplayer");
                        music_process[0].Kill();
                        synthesizer.SpeakAsync("music player has been stoped sir.");
                        chatbox.Text += "\n Siri >" + "music player has been stoped sir." + "\n";
                        break;



                    case "go to my Computer":
                        synthesizer.SpeakAsync("Opening my computer.");
                        chatbox.Text += "\n Siri >" + "Opening my computer." + "\n";
                        string myComputerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                        Process.Start("explorer", myComputerPath);
                        break;

                    case "clear my chats":
                        chatbox.Text = "";
                        synthesizer.SpeakAsync("Cleared.");                      
                        break;



                }
            }

        }
    }
}
