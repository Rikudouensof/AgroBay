using System;
using System.Collections.Generic;
using System.Text;

namespace AgroBay.Core.Constants
{
  public  class EmailCredentialsAchives
  {
   


    public static EmailCredentials GetEmailCredentials()
    {
      var MailCredential = new EmailCredentials()
      {
        Email = "Support@lusatiae.com",
        Name = "lusatiae.com",
        Password = "*Io1uo30"
      };


    


      return MailCredential;
    }

    

  }


  public class EmailCredentials
  {
    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }
  }
}
