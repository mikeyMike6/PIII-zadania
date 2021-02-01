using System;
using System.Collections.Generic;
using System.Text;

namespace PIII_9
{
    //Stwórz klasy Użytkownik i Kanał.
    class Channel : Account
    {
        public event Action<string> MovieReleasedMessage; //event OpublikowanoFilm.
        public int ViewCounter { get; set; }  //Do klasy Kanał dodaj pole LicznikWyswietlen,
        public Channel(int id, string name) : base(id, name)
        {

        }
        public void ViewTheMovie(int id) //metodę WyswietlFilm(int id),
        {
            ViewCounter++; //Metoda WyświetlFilm powinna zwiększać ilość wyświetleń o 1. 
        }
        public int CountSubscribers()
        {
            return MovieReleasedMessage.GetInvocationList().Length;
        }
        public void ReleaseTheMovie() //metodę OpublikujFilm
        {
            MovieReleasedMessage?.Invoke(this.Name); // Metoda OpublikujFilm powinna publikować event. 
        }
      
    }
}
