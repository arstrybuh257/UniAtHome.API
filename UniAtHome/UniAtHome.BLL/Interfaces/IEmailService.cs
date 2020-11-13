using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string receiver, string subject, string bodyHtml);
    }
}
