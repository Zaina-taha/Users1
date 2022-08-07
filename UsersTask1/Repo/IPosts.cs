using Microsoft.AspNetCore.Mvc;
using UserTask1.Module;

namespace UserTask1.Repo
{
    public interface IPosts : IGenRepo<Posts>
    {
        public Task<List<Posts>> Search(int Page, int Size, string search);
    }
}
