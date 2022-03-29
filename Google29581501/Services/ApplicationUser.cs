using Google29581501.Config;
using Google29581501.Helpers;
using Microsoft.Extensions.Options;

namespace Google29581501
{
    public class ApplicationUser
    {
        public string Email { get; set; }

        public ApplicationUser(IOptions<ConfigSettings> config)
        {
            ConfigSettings _config = config.Value;

            //get user or from GCP header if using on app engine
            var currentUserEmail = Utility.GetCurrentUserEmail();

            //write code to check CurrentUser is in the application database

        }
    }

}