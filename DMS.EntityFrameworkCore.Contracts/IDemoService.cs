
using DMS.EntityFrameworkCore.Repository.Models;

namespace DMS.EntityFrameworkCore.Contracts
{
    /// <summary>
    /// 扩展接口，一般继承类没有的接口
    /// </summary>
    public interface IDemoService
    {
         SysJobLog GetEntity(int id);
    }
}