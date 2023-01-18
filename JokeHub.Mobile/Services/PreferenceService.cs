using JokeHub.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeHub.Mobile.Services
{
    public class PreferenceService
    {
        public event Action SwipeDirectionUpdated;


        
        // Events
        public virtual void OnSwipeDirectionUpdated()
        {
            SwipeDirectionUpdated.Invoke();
        }


        public List<string> GetFilters()
        {
            List<string> filters = new List<string>();

            if (GetDarkJoke() is true)
                filters.Add("Dark");

            if (GetYoMamaJoke() is true)
                filters.Add("Yo mama");

            if (GetSexualJoke() is true)
                filters.Add("Sexual");


            return filters;
        }


        // Methods
        // SET
        public void SetSwipeDirection(SwipeListItem direction)
        {
            Preferences.Default.Set("SwipeDirection", direction.Direction.ToString());
            OnSwipeDirectionUpdated();
        }


        public void SetDarkJoke(bool showDarkJokes)
        {
            Preferences.Default.Set("ShowDarkJokes", showDarkJokes);
        }

        public void SetYoMamaJoke(bool showYoMamaJokes)
        {
            Preferences.Default.Set("ShowYoMamaJokes", showYoMamaJokes);
        }

        public void SetSexualJoke(bool showSexualJokes)
        {
            Preferences.Default.Set("ShowSexualJokes", showSexualJokes);
        }



        // GETS
        public string GetSwipeDirection()
        {
            return Preferences.Get("SwipeDirection", SwipeDirection.Left.ToString());
        }

        public bool GetDarkJoke()
        {
            return Preferences.Get("ShowDarkJokes", false);
        }

        public bool GetYoMamaJoke()
        {
            return Preferences.Get("ShowYoMamaJokes", false);
        }

        public bool GetSexualJoke()
        {
            return Preferences.Get("ShowSexualJokes", false);
        }

    }
}
