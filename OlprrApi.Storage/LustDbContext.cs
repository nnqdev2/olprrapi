﻿using Microsoft.EntityFrameworkCore;
using OlprrApi.Storage.Entities;

namespace OlprrApi.Storage
{
    public class LustDbContext : DbContext
    {
        public DbSet<ConfirmationType> ConfirmationType { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<DiscoveryType> DiscoveryType { get; set; }
        public DbSet<QuadrantT> QuadrantT { get; set; }
        public DbSet<ReleaseCauseType> ReleaseCauseType { get; set; }
        public DbSet<SiteTypeT> SiteTypeT { get; set; }
        public DbSet<SourceType> SourceType { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<StreetTypeT> StreetTypeT { get; set; }
        public DbSet<DeqOfficeT> DeqOfficeT { get; set; }
        public DbSet<IncidentStatusT> IncidentStatusT { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<FileStatus> FileStatus { get; set; }
        public DbSet<TankStatus> TankStatus { get; set; }
        public DbSet<ZipCode> ZipCode { get; set; }
        public DbSet<CleanupSiteType> CleanupSiteType { get; set; }
        public DbSet<DateCompare> DateCompare { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<ProjectManager> ProjectManager { get; set; }


        public DbSet<ApOlprrGetLustLookup> ApOLPRRGetLustLookup { get; set; }
        public DbSet<ApGetLustSearchData> ApGetLustSearchData { get; set; }
        public DbSet<ApOlprrGetUstLookupData> ApOlprrGetUstLookupData { get; set; }


        public DbSet<ApOlprrInsertIncident> ApOLPRRInsertIncident { get; set; }
        public DbSet<ApOlprrGetIncidentById> ApOlprrGetIncidentById { get; set; }
        public DbSet<ApOlprrGetIncidents> ApOlprrGetIncidents { get; set; }
        public DbSet<ApOlprrGetIncidentDataById> ApOlprrGetIncidentDataById { get; set; }

        public LustDbContext(DbContextOptions<LustDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}