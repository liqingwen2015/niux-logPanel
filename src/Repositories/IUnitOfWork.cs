using System;
using System.Threading.Tasks;

namespace NiuX.LogPanel.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        Task Open();

        void Close();
    }
}