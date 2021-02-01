using System;
using System.Collections.Generic;
using System.Text;

namespace PIII_9
{
    //Stwórz klasy Użytkownik i Kanał.
    class User : Account
    {
        public Action<string, string> Notification;
        public User(int id, string name, Action<string, string> notification) : base(id, name)
        {
            Notification = notification;
        }
        public void WatchMovie(Channel channel)
        {
            channel.ViewTheMovie(ID);
        }
        public void SubscribeChannel(Channel channel) //Do klasy Użytkownik dodaj metodę SubskrybujKanał, która jako parametr przyjmie obiekt typu Kanał. 
        {
            channel.MovieReleasedMessage += ShowNotification; //Metoda ta powinna podpiąć Event Handler Użytkownika pod Event Kanału. 
        }
        public void ShowNotification(string channelName)
        {
            Notification?.Invoke(Name, channelName); // W event handlerze wypisz krótkie potwierdzenie,
        }
    }
}
