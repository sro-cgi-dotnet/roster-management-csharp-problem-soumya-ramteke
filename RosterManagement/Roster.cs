using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }
        
        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)
        {   //first check whether the wave exists or not
            if(_roster.ContainsKey(wave))
            {   //add cadet to the particular wave
                _roster[wave].Add(cadet);
            }
            else
            {   //if the wave doesnt exist, create a new wave
                _roster.Add(wave, new List<string>() );
                //add cadet
                _roster[wave].Add(cadet);
            }
        }
        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            var cadets = new List<string>();
            //get all the waves, store them in a list
            var waves= new List<int>();
            waves=_roster.Keys.ToList();
            //sort them
            waves.Sort();
            //loop through each wave
            foreach(int w in waves)
            {   //first sort names alphabetically
                _roster[w].Sort();
                //loop through to get the cadet names
                foreach(string cadet_name in _roster[w])
                {
                    //add to cadets list
                    cadets.Add(cadet_name);
                }
            }
            return cadets;
        }
        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            var list = new List<string>();
            //find the wave
            if(_roster.ContainsKey(wave))
            {   //loop through the wave
                foreach(string s in _roster[wave])
                {   //add the cadet name
                    list.Add(s);
                }
                //sort the list
                list.Sort();
            }
            return list;
        }      
}
}


