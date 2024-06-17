using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shopping.API.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<MasterLookup> MasterLookup { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionResponse> QuestionResponse { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<RegularExpression> RegularExpression { get; set; }
        public virtual DbSet<Response> Response { get; set; }
        public virtual DbSet<ResponseType> ResponseType { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyAccess> SurveyAccess { get; set; }
        public virtual DbSet<SurveyFieldRule> SurveyFieldRule { get; set; }
        public virtual DbSet<SurveyFieldRuleAction> SurveyFieldRuleAction { get; set; }
        public virtual DbSet<SurveyFieldRuleCondition> SurveyFieldRuleCondition { get; set; }
        public virtual DbSet<SurveySubType> SurveySubType { get; set; }
        public virtual DbSet<SurveyTemplate> SurveyTemplate { get; set; }
        public virtual DbSet<SurveyTemplateRegularExpression> SurveyTemplateRegularExpression { get; set; }
        public virtual DbSet<SurveyType> SurveyType { get; set; }
        public virtual DbSet<VwApplication> VwApplication { get; set; }
        public virtual DbSet<VwDepartment> VwDepartment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=GSS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<MasterLookup>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.ColumnName, e.ColumnValue })
                    .HasName("Code_Table_PK_UC1");

                entity.Property(e => e.TableName).IsUnicode(false);

                entity.Property(e => e.ColumnName).IsUnicode(false);

                entity.Property(e => e.ColumnValue).IsUnicode(false);

                entity.Property(e => e.ColumnDesc).IsUnicode(false);

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuestionText).IsUnicode(false);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_QuestionType");
            });

            modelBuilder.Entity<QuestionResponse>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionResponse)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionResponse_Question");

                entity.HasOne(d => d.Response)
                    .WithMany(p => p.QuestionResponse)
                    .HasForeignKey(d => d.ResponseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionResponse_Response");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuestionTypeCode).IsUnicode(false);

                entity.Property(e => e.QuestionTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<RegularExpression>(entity =>
            {
                entity.Property(e => e.RegularExpressionId).ValueGeneratedNever();

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegularExpressionDescription).IsUnicode(false);

                entity.Property(e => e.RegularExpressionName).IsUnicode(false);

                entity.Property(e => e.RegularExpressionValidationMessage).IsUnicode(false);
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ResponseText).IsUnicode(false);

                entity.HasOne(d => d.ResponseType)
                    .WithMany(p => p.Response)
                    .HasForeignKey(d => d.ResponseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Response_ResponseType");
            });

            modelBuilder.Entity<ResponseType>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ResponseTypeCode).IsUnicode(false);

                entity.Property(e => e.ResponseTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SectionDescription).IsUnicode(false);

                entity.Property(e => e.SectionName).IsUnicode(false);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurveyDescription).IsUnicode(false);

                entity.Property(e => e.SurveyName).IsUnicode(false);

                entity.HasOne(d => d.SurveySubType)
                    .WithMany(p => p.Survey)
                    .HasForeignKey(d => d.SurveySubTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Survey_SurveySubType");
            });

            modelBuilder.Entity<SurveyAccess>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurveyAccessType).IsUnicode(false);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyAccess)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyAccess_Survey");
            });

            modelBuilder.Entity<SurveyFieldRule>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogicalOperator).IsUnicode(false);

                entity.Property(e => e.RuleName).IsUnicode(false);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyFieldRule)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyFieldRule_Survey");
            });

            modelBuilder.Entity<SurveyFieldRuleAction>(entity =>
            {
                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SurveyFieldRule)
                    .WithMany(p => p.SurveyFieldRuleAction)
                    .HasForeignKey(d => d.SurveyFieldRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyFieldRuleAction_SurveyFieldRule");
            });

            modelBuilder.Entity<SurveyFieldRuleCondition>(entity =>
            {
                entity.Property(e => e.ComparisonOperator).IsUnicode(false);

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SurveyFieldRule)
                    .WithMany(p => p.SurveyFieldRuleCondition)
                    .HasForeignKey(d => d.SurveyFieldRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyFieldRuleCondition_SurveyFieldRule");
            });

            modelBuilder.Entity<SurveySubType>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurveySubTypeDescription).IsUnicode(false);

                entity.Property(e => e.SurveySubTypeName).IsUnicode(false);

                entity.HasOne(d => d.SurveyType)
                    .WithMany(p => p.SurveySubType)
                    .HasForeignKey(d => d.SurveyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveySubType_SurveyType");
            });

            modelBuilder.Entity<SurveyTemplate>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SurveyTemplate)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTemplate_Question");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SurveyTemplate)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_SurveyTemplate_Section");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyTemplate)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTemplate_Survey");
            });

            modelBuilder.Entity<SurveyTemplateRegularExpression>(entity =>
            {
                entity.Property(e => e.SurveyTemplateRegularExpressionId).ValueGeneratedNever();

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegularExpressionValidationMessage).IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SurveyTemplateRegularExpression)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTemplateRegularExpression_Question");

                entity.HasOne(d => d.RegularExpression)
                    .WithMany(p => p.SurveyTemplateRegularExpression)
                    .HasForeignKey(d => d.RegularExpressionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTemplateRegularExpression_RegularExpression");

                entity.HasOne(d => d.SurveyTemplate)
                    .WithMany(p => p.SurveyTemplateRegularExpression)
                    .HasForeignKey(d => d.SurveyTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyTemplateRegularExpression_SurveyTemplate");
            });

            modelBuilder.Entity<SurveyType>(entity =>
            {
                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurveyTypeDescription).IsUnicode(false);

                entity.Property(e => e.SurveyTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<VwApplication>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwApplication", "GSS");

                entity.Property(e => e.ApplicationId).ValueGeneratedOnAdd();

                entity.Property(e => e.ApplicationName).IsUnicode(false);

                entity.Property(e => e.ApplicationType).IsUnicode(false);

                entity.Property(e => e.ShortName).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<VwDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwDepartment", "GSS");

                entity.Property(e => e.DepartmentId).ValueGeneratedOnAdd();

                entity.Property(e => e.DepartmentName).IsUnicode(false);

                entity.Property(e => e.DepartmentShortName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
