using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Models
{
	public class LoginModel:BaseModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string User { get; set; }



	}
}
