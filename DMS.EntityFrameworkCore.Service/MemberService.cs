using DMS.BaseFramework.Common.BaseResult;
using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.MemberModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Service
{
    public class MemberService: ServiceBase
    {
        public MemberService()
           : base(new trydou_memberContext()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<ResponsePageResult<MemMemberAccount>> GetPageList(int pageIndex, int pageSize, string searchText)
        {
            ResponsePageResult<MemMemberAccount> result = new ResponsePageResult<MemMemberAccount>() { data = new DataResultList<MemMemberAccount>() };
            //IQueryable<MemMemberAccount> queryList =  GetQueryable<MemMemberAccount>();
            //if (!string.IsNullOrEmpty(searchText))
            //{
            //    queryList = queryList.Where(q => q.TrueName.Contains(searchText));
            //}
            //执行分页查询
            result.data = await GetQueryable<MemMemberAccount>()
                .OrderByDescending(q => q.CreateTime)
                //.ThenBy(q => q.MemberId)
                .ToPageListAsync(pageIndex, pageSize);

            return result;
        }

    }
}
