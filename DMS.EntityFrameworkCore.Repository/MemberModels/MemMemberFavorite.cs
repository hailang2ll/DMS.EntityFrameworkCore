using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.MemberModels
{
    public partial class MemMemberFavorite
    {
        public long FavoriteId { get; set; }
        public long MemberId { get; set; }
        public int RelationType { get; set; }
        public long RelationId { get; set; }
        public string RelationName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
