using System;
using System.Drawing;
//using System.Media;
using EloBuddy;
using EloBuddy.SDK.Events;
using Kalista.Champions;
using Kalista.Database.Icons;
using Kalista.Menu_Settings;
using Kalista.Utility;
using Activator = System.Activator;

namespace Kalista
{
    internal class Brain
    {
        public static Kalista Champion;

        //private static SoundPlayer _welcomeSound;

        private static void Main(string[] args)
        {
            try
            {
                Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Chat.Print(
                    "<font color='#23ADDB'>Kalista:</font><font color='#E81A0C'> an error ocurred. (Code 1)</font>");
            }
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            MainMenu.Init();

            UtilityManager.Initialize();
            Value.Init();
            var champion = Type.GetType("Kalista.Champions." + Player.Instance.ChampionName);
            if (champion != null)
            {
                Console.WriteLine("[Kalista] " + Player.Instance.ChampionName + " Loaded");
                IconManager.Init();
                Champion = (Kalista) Activator.CreateInstance(champion);
                Events.Init();

                Value.Init();
                Champion.Init();
                //JsonSettings.Init();
                UtilityManager.Activator.LoadSpells();
                // if (MainMenu.Menu["playsound"].Cast<CheckBox>().CurrentValue) PlayWelcome(); 
                Chat.Print("MarksmanAIO: " + Player.Instance.ChampionName + " Loaded", Color.CornflowerBlue);
            }
            else
            {
                Chat.Print("MarksmanAIO doesn't support: " + Player.Instance.ChampionName);
            }

            Humanizer.Init();
        }

        /*private static void PlayWelcome()
        {
            try
            {
                var sandBox = SandboxConfig.DataDirectory + @"\Kalista\";

                if (!Directory.Exists(sandBox))
                {
                    Directory.CreateDirectory(sandBox);
                }

                if (!File.Exists(sandBox + Player.Instance.ChampionName + ".wav"))
                {
                    var client = new WebClient();
                    client.DownloadFile(
                        "http://oktraio.com/VoiceAssistant/" + Player.Instance.ChampionName + ".wav",
                        sandBox + Player.Instance.ChampionName + ".wav");
                    client.DownloadFileCompleted += Client_DownloadFileCompleted;
                }

                if (File.Exists(sandBox + Player.Instance.ChampionName + ".wav"))
                {
                    _welcomeSound = new SoundPlayer
                    {
                        SoundLocation =
                            SandboxConfig.DataDirectory + @"\Kalista\" + Player.Instance.ChampionName
                            + ".wav"
                    };

                    _welcomeSound.Load();
                    if (_welcomeSound == null || !_welcomeSound.IsLoadCompleted)
                        return;
                    _welcomeSound.Play();
                }
            }
            catch (Exception e)
            {
                Chat.Print("Failed to load Sound File: \"" + Player.Instance.ChampionName + ".wav\": " + e);
            }
        }

        private static void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _welcomeSound = new SoundPlayer
            {
                SoundLocation =
                    SandboxConfig.DataDirectory + @"\Kalista\" + Player.Instance.ChampionName + ".wav"
            };
            _welcomeSound.Load();
            _welcomeSound.Play();
        }*/
        //Function will be enabled again with the new Kalista.
    }
}