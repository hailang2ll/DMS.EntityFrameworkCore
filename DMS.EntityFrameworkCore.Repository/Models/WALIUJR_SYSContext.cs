using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class WALIUJR_SYSContext : DbContext
    {
        public WALIUJR_SYSContext()
        {
        }

        public WALIUJR_SYSContext(DbContextOptions<WALIUJR_SYSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysAddress> SysAddress { get; set; }
        public virtual DbSet<SysAddressInfo> SysAddressInfo { get; set; }
        public virtual DbSet<SysAddressInfoNew> SysAddressInfoNew { get; set; }
        public virtual DbSet<SysAdminOperationLog> SysAdminOperationLog { get; set; }
        public virtual DbSet<SysAppversionRecord> SysAppversionRecord { get; set; }
        public virtual DbSet<SysCacheInfo> SysCacheInfo { get; set; }
        public virtual DbSet<SysDapperProduct> SysDapperProduct { get; set; }
        public virtual DbSet<SysDapperTest> SysDapperTest { get; set; }
        public virtual DbSet<SysJobLog> SysJobLog { get; set; }
        public virtual DbSet<SysJobWorkQueue> SysJobWorkQueue { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysMonitorLog> SysMonitorLog { get; set; }
        public virtual DbSet<SysPageAreaConfig> SysPageAreaConfig { get; set; }
        public virtual DbSet<SysPageAreaOption> SysPageAreaOption { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=False;server=192.168.0.100;database=WALIUJR_SYS;User ID=sa;Password=SA-jinglih;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysAddress>(entity =>
            {
                entity.ToTable("Sys_Address");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MergerShortName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysAddressInfo>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("Sys_AddressInfo");

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodePath)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NameCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamePath)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysAddressInfoNew>(entity =>
            {
                entity.ToTable("Sys_AddressInfoNew");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Lng)
                    .IsRequired()
                    .HasColumnName("lng")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.MergerName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Pinyin)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysAdminOperationLog>(entity =>
            {
                entity.HasKey(e => e.OperId);

                entity.ToTable("Sys_AdminOperationLog");

                entity.Property(e => e.OperId).HasColumnName("OperID");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.LocalAddr)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LocalIp)
                    .IsRequired()
                    .HasColumnName("LocalIP")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysAppversionRecord>(entity =>
            {
                entity.HasKey(e => new { e.Versions, e.Equipment });

                entity.ToTable("Sys_APPVersionRecord");

                entity.Property(e => e.Versions).HasMaxLength(50);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysCacheInfo>(entity =>
            {
                entity.HasKey(e => e.CacheKey);

                entity.ToTable("Sys_CacheInfo");

                entity.Property(e => e.CacheKey).ValueGeneratedNever();

                entity.Property(e => e.CacheData)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CacheName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiryTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.MemVersion)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateBy).HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.UpdateByName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.XsltControlLastUpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.XsltFilePath)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XsltLastUpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");
            });

            modelBuilder.Entity<SysDapperProduct>(entity =>
            {
                entity.ToTable("Sys_DapperProduct");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysDapperTest>(entity =>
            {
                entity.ToTable("Sys_DapperTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysJobLog>(entity =>
            {
                entity.HasKey(e => e.JobLogId);

                entity.ToTable("Sys_JobLog");

                entity.Property(e => e.JobLogId).HasColumnName("JobLogID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServerIp)
                    .IsRequired()
                    .HasColumnName("ServerIP")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysJobWorkQueue>(entity =>
            {
                entity.HasKey(e => e.WorkQueueId);

                entity.ToTable("Sys_JobWorkQueue");

                entity.Property(e => e.WorkQueueId).HasColumnName("WorkQueueID");

                entity.Property(e => e.CloseRemark)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CloseTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PlanSendTime).HasColumnType("datetime");

                entity.Property(e => e.RelateKey)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendResult)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.SendUserCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServerIp)
                    .IsRequired()
                    .HasColumnName("serverIP")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToUserId).HasColumnName("ToUserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidateCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkContent)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkHtmlcontent)
                    .IsRequired()
                    .HasColumnName("WorkHTMLContent")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkTitle)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.HasKey(e => new { e.MemberName, e.LogId });

                entity.ToTable("Sys_Log");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LogId)
                    .HasColumnName("LogID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubSysId).HasColumnName("SubSysID");

                entity.Property(e => e.SubSysName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysMonitorLog>(entity =>
            {
                entity.ToTable("Sys_MonitorLog");

                entity.HasIndex(e => e.Time);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.HostName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HostNameUser)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HttpMethod)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QueryParams)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RequesHead)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysPageAreaConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigKey);

                entity.ToTable("Sys_PageAreaConfig");

                entity.Property(e => e.ConfigKey).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CodePath)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfigImage)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.NamePath)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.RelationLink)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RelationName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");
            });

            modelBuilder.Entity<SysPageAreaOption>(entity =>
            {
                entity.HasKey(e => e.AreaKey);

                entity.ToTable("Sys_PageAreaOption");

                entity.Property(e => e.AreaKey).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaCount).HasDefaultValueSql("((999))");

                entity.Property(e => e.AreaDesc)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaImage)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CacheFileName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodePath)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");

                entity.Property(e => e.IisCacheName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NamePath)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1900)-(1))-(1))");
            });
        }
    }
}
