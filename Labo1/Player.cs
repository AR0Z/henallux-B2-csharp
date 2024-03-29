﻿using System;
using System.Linq;
using System.Text;

namespace Labo1Player 
{
    public class Player 
    {
        
        #region attributes
        public const int NB_MAX_MAPS = 5;
        
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private int skillRating;
        private bool sponsored;
        private Map[] maps = new Map[NB_MAX_MAPS];
        #endregion
        
        #region constructors
        public Player(string firstName, string lastName, DateTime birthday, bool isRanked) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthday = birthday;
            skillRating = isRanked ? 1 : 0;
        }
        
        public Player(string firstName, string lastName, DateTime birthday) : 
            this(firstName, lastName, birthday, true) {}
        #endregion

        public string GetName() 
        {
            return this.lastName + " " + this.firstName;
        }

        public string GetBirthday() {
            return birthday.Day + "/" + birthday.Month + "/" + birthday.Year;
        }

        public void SetRanked() 
        {
            if (!IsRanked())
                skillRating = 1;
        }

        private bool IsRanked() 
        {
            return skillRating >= 1;
        }

        public void ModifySkillRating(int point) 
        {
            if (IsRanked()) {
                skillRating += point;

                if (skillRating > 5000)
                    skillRating = 5000;
                if (skillRating < 1)
                    skillRating = 1;
            }
        }

        public void AddMap(Map map) 
        {
            if (!maps.Contains(map)) 
            {
                for (int i = NB_MAX_MAPS-1; i > 0; i--) 
                {
                    maps[i] = maps[i-1];
                }
                maps[0] = map;
            } 
            else 
            {
                for (int i = Array.IndexOf(maps, map); i > 0; i--) 
                {
                    maps[i] = maps[i-1];
                }
                maps[0] = map;
            }
        }

        public string ListingMaps()
        {
            StringBuilder output = new StringBuilder();
            int i = 1;
            foreach (Map map in maps)
            {
                output.Append($"{i} - {map}{Environment.NewLine}");
                i++;
            }

            return output.ToString();
        }

        public override string ToString() 
        {
            return $"Nom et prénom : {GetName()}{Environment.NewLine}Date de naissance : {GetBirthday()}{Environment.NewLine}{(IsRanked() ? "Compétiteur" : "Non compétiteur")}";
        }
    }
}