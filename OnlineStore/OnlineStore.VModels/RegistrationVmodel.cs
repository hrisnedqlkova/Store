using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.VModels
{
	public class RegistrationVmodel
	{
		[Required]
		public string FName { get; set; }
		[Required]
		public string SName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[StringLength(15, MinimumLength = 4)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[StringLength(15, MinimumLength = 4)]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }


	}
}
