using System.Threading.Tasks;
using TRMWPFDesktopUserInterface.Models;

namespace TRMWPFDesktopUserInterface.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}