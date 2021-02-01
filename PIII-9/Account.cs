using System;
using System.Collections.Generic;
using System.Text;

namespace PIII_9
{
    abstract class Account
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public Account(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
