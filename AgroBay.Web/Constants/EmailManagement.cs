using AgroBay.Core.Tasks;

namespace AgroBay.Web.Constants
{
  public class EmailManagement
  {
    private IConfiguration _config;
    public EmailManagement(IConfiguration configRoot)
    {
      _config = configRoot;
    }

    public EmailArguement GetEmailData()
    {
      EmailArguement emailArguement = new EmailArguement()
      {
        Email = _config["MailCredentials:Email"],
        Password = _config["MailCredentials:Password"],
        Website = _config["MailCredentials:Website"]
      };
      return emailArguement;
    }


  }
}
