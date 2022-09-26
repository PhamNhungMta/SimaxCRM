using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Model.Entity;

namespace SimaxCrm.Data.Context
{
    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<LeadProjectMapping> LeadProjectMapping { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<OtpLog> OtpLog { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<LeadType> LeadType { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<CustomerQuery> CustomerQuery { get; set; }
        public DbSet<AttachmentProductMapping> AttachmentProductMapping { get; set; }
        public DbSet<TempLead> TempLead { get; set; }
        public DbSet<ProjectTagMapping> ProjectTagMapping { get; set; }
        public DbSet<AttachmentProjectMapping> AttachmentProjectMapping { get; set; }
        public DbSet<EmailSent> EmailSent { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        //public DbSet<LeadLanguage> LeadLanguage { get; set; }
        public DbSet<LeadSource> LeadSource { get; set; }
        public DbSet<Tcf> Tcf { get; set; }
        public DbSet<LeadTag> LeadTag { get; set; }
        public DbSet<LeadTagMapping> LeadTagMapping { get; set; }
        public DbSet<LeadProductMapping> LeadProductMapping { get; set; }
        public DbSet<LeadRemarks> LeadRemarks { get; set; }
        public DbSet<CallLog> CallLog { get; set; }
        public DbSet<CallLogProduct> CallLogProduct { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<EmailSetup> EmailSetup { get; set; }
        public DbSet<LeadAutoAssign> LeadAutoAssign { get; set; }
        public DbSet<LeadAutoAssignSourceMapping> LeadAutoAssignSourceMapping { get; set; }
        public DbSet<LeadAutoAssignLog> LeadAutoAssignLog { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<UserRating> UserRating { get; set; }
        public DbSet<SystemSetup> SystemSetup { get; set; }
        public DbSet<InventoryTag> InventoryTag { get; set; }
        public DbSet<InventoryTagMapping> InventoryTagMapping { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Society> Society { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageDetail> MessageDetail { get; set; }
        public DbSet<PhoneCallProductLog> PhoneCallProductLog { get; set; }
        public DbSet<PhoneCallLeadLog> PhoneCallLeadLog { get; set; }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletDetail> WalletDetail { get; set; }
        public DbSet<LeadOrder> LeadOrder { get; set; }
        public DbSet<LeadOrderDetail> LeadOrderDetail { get; set; }
        public DbSet<PaymentLog> PaymentLog { get; set; }
        public DbSet<UploadCategory> UploadCategory { get; set; }
        public DbSet<Seo> Seo { get; set; }
        public DbSet<Slider> Slider { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<LeadAutoAssignLog>()
              .HasOne(u => u.LeadSource)
              .WithMany(u => u.LeadAutoAssignLog).IsRequired()
              .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Lead>()
            .HasOne(u => u.DeletedBy)
            .WithMany(u => u.LeadDeletedBy).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<Lead>()
            //.HasOne(u => u.Product)
            //.WithMany(u => u.Lead).IsRequired(false)
            //.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
            .HasOne(u => u.Project)
              .WithMany(u => u.Product).IsRequired(false)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AttachmentProductMapping>()
          .HasOne(u => u.UploadCategory)
            .WithMany(u => u.AttachmentProductMapping).IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserRating>()
        .HasOne(u => u.User)

          .WithMany(u => u.UserRating).IsRequired(false)
          .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserRating>()
     .HasOne(u => u.CreatedByUser)
       .WithMany(u => u.UserRatingCreatedBy).IsRequired(false)
       .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
