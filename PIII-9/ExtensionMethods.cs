using System;
using System.Collections.Generic;
using System.Text;

namespace PIII_9
{
    //Dodaj także ExtensionMethod dla typu Kanał, która wypisze na konsolę nazwę kanału, jego ilość subskrypcji i wyświetleń. 
    static class ExtensionMethods
    {
        public static void ShowInfo(this Channel channel)
        {
            Console.WriteLine($"Channel name: {channel.Name}\nViews: {channel.ViewCounter}\nSubscribers: {channel.CountSubscribers()}");
        }
    }
}
