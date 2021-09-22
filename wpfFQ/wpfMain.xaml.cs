using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace wpfFQ
{
    /// <summary>
    /// Логика взаимодействия для wpfMain.xaml
    /// </summary>
    public partial class wpfMain : Window
    {
        private static string token { get; set; } = "2014272170:AAHDzsJOmmD0v4yWkAz9ttZC7JTzctKKBZ4";
        private static TelegramBotClient client;

        public wpfMain()
        {
            InitializeComponent();

            client = new TelegramBotClient(token);
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"Username {me.Username} c ID {me.Id}");


            client.StartReceiving();
            client.OnMessage += onMessageHandler;
            
            Console.ReadLine();
            client.StopReceiving();


        }

        private void onMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg != null) 
            {
                Console.WriteLine($"пришло сообщение с текстом: {msg.Text}");
            }
        }
    }
}
