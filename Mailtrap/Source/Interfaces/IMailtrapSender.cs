using Mailtrap.Source.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Mailtrap.Source.Interfaces
{
    public interface IMailtrapSender
    {
        void Send(Email email);
        Task SendAsync(Email email, CancellationToken cancellationToken = default);
    }
}