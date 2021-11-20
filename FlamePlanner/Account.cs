using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlamePlanner
{
 
    /// <summary>
    /// Account class. Has a username,password, and list of itineraries
    /// </summary>
    public class Account
    {

        public string username; //username
        public Dictionary<string,Itinerary> itineraryDict; //Dictioray of account's itineraries key=title value=itinerary object


        private string password; //Private password for 'Security' :)


        /// <summary>
        /// Constructor for Account class
        /// Intitializes empty list of itineraries
        /// </summary>
        /// <param name="uName">username</param>
        /// <param name="pWord">password</param>
        public Account(string uName, string pWord)
        {
            this.username = uName;
            this.password = pWord;
            this.itineraryDict = new Dictionary<string, Itinerary>();
        }

        public Account(Account a2)
        {
            this.username = a2.username;
            this.password = a2.password;
            this.itineraryDict = new Dictionary<string,Itinerary>(a2.itineraryDict);
        }


        /// <summary>
        /// Tests whether argument is equal to the account password
        /// </summary>
        /// <param name="testPassword"></param>
        /// <returns></returns>
        public bool CheckPassword(string testPassword)
        {
            return this.password.Equals(testPassword);
        }

        //Commented out as it is insecure, can be uncommented if we allow user to change pwd
        //public void changePassword(string newPwd)
        //{
        //    this.password = newPwd;
        //}
    }
}
