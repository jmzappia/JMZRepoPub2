/*
 * Autor: Julián Marcelo Zappia
 * User: ?
 * Date: 26/07/2019
 * Time: 12:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Inventory_System.Classes
{
	public class User
	{
		private string username;
		private string password;
		private string secretQuestion;
		private string answer;
		private int userType;
        public User()
		{
		}
		public string Username
		{
			get{return username;}
			set{username = value;}
		}
		public string Password
		{
			get{return password;}
			set{password = value;}
		}
		public string SecretQuestion
		{
			get{return secretQuestion;}
			set{secretQuestion = value;}
		}
		public string Answer
		{
			get{return answer;}
			set{answer = value;}
		}

        public int UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
            }
        }
    }
}
