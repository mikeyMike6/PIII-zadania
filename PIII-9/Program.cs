using System;
using System.Collections.Generic;

namespace PIII_9
{
    //Stwórz aplikację inspirowaną działaniem YouTube. 
    class Program
    {
        static void Main(string[] args)
        {
            // Stwórz kolekcję użytkowników i 1 Kanał.Niech wszyscy użytkownicy subskrybują ten kanał. 
            List<User> user = new List<User>();
            Channel channel = new Channel(1, "channel");
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    user.Add(new User(i, "user" + i, Message));
                }
                else
                {
                    user.Add(new User(i, "user" + i, MessagePL));
                }
                user[i].SubscribeChannel(channel);
            }
            channel.ReleaseTheMovie();
            for (int i = 0; i < 10; i++)
            {
                user[i].WatchMovie(channel);
            }
            //Wywołaj Extension Method.
            channel.ShowInfo();
        }

        //W event handlerze wypisz krótkie potwierdzenie, np. "użytkownik X otrzymał powiadomienie o nowym filmie". 
        static void Message(string userName, string channelName)
        {
            Console.WriteLine($"Hi {userName}, there is new movie from {channelName}");
        }
        static void MessagePL(string userName, string channelName)
        {
            Console.WriteLine($"Czesc {userName}, pojawil sie nowy film od {channelName}");
        }
    }
}
