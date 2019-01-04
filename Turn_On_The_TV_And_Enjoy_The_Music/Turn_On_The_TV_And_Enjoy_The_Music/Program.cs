using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace @event
{
    // By creating two classes TV and RemoteController we try to turn on the TV and enjoy the music. :)

    public class TV
    {
        public void On()
        {
            Process.Start("https://www.youtube.com/watch?v=75QNBORp_qc");
        }

        public void NextChannel(string url)
        {
            Process.Start(url);
        }
    }

    public class RemoteController
    {
        public event ButtonClickDelegate ONButtonClick;

        public event ButtonClickNextChannel NextChannelButtonClick;

        public void OnONButtonClick()
        {
            if (ONButtonClick != null)
            {
                ONButtonClick.Invoke();
            }
        }

        public void OnNextChannelButtonClick(string url)
        {
            if (NextChannelButtonClick != null)
            {
                NextChannelButtonClick.Invoke(url);
            }
        }
    }

    public delegate void ButtonClickNextChannel(string url);

    public delegate void ButtonClickDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            TV newTV = new TV();

            RemoteController pult = new RemoteController();
            pult.ONButtonClick += newTV.On;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("TV is on. Enjoy music !");
            pult.OnONButtonClick();

            pult.NextChannelButtonClick += newTV.NextChannel;

            Thread.Sleep(100000);

            pult.OnNextChannelButtonClick("https://www.youtube.com/watch?v=8Uq9KY1EcKs&list=RD8Uq9KY1EcKs&start_radio=1");
            Console.ReadKey();
        }
    }
}
