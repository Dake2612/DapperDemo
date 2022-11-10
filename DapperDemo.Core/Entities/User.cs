using System;
namespace DapperDemo.Core.Entities
{
	public class User
	{
		public int id { get; set; }
		
		public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }

        public string UserDNI { get; set; }

        public int UserAge { get; set; }    

    }
}

