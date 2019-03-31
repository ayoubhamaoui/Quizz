using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace quizz.Models
{
    public partial class quizzContext : DbContext
    {
        public quizzContext()
        {
        }

        public quizzContext(DbContextOptions<quizzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eleves> Eleves { get; set; }
        public virtual DbSet<Enseignant> Enseignant { get; set; }
        public virtual DbSet<Matiere> Matiere { get; set; }
        public virtual DbSet<Passer> Passer { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Quizz> Quizz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=quizz");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Eleves>(entity =>
            {
                entity.HasKey(e => e.Codeelev);

                entity.ToTable("eleves", "quizz");

                entity.Property(e => e.Codeelev)
                    .HasColumnName("CODEELEV")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Anneediplom)
                    .HasColumnName("ANNEEDIPLOM")
                    .HasColumnType("date");

                entity.Property(e => e.CodeFil)
                    .HasColumnName("CODE_FIL")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Dateinsc)
                    .HasColumnName("DATEINSC")
                    .HasColumnType("date");

                entity.Property(e => e.Elevscol)
                    .HasColumnName("ELEVSCOL")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Niveau)
                    .HasColumnName("NIVEAU")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enseignant>(entity =>
            {
                entity.HasKey(e => e.Codeens);

                entity.ToTable("enseignant", "quizz");

                entity.Property(e => e.Codeens)
                    .HasColumnName("CODEENS")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matiere>(entity =>
            {
                entity.HasKey(e => e.Codemat);

                entity.ToTable("matiere", "quizz");

                entity.HasIndex(e => e.Codeens)
                    .HasName("FK_GERE");

                entity.HasIndex(e => e.IdQuizz)
                    .HasName("FK_POSSEDE");

                entity.Property(e => e.Codemat)
                    .HasColumnName("CODEMAT")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Codeens)
                    .IsRequired()
                    .HasColumnName("CODEENS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Codemodule)
                    .HasColumnName("CODEMODULE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasColumnName("DESIGNATION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdQuizz)
                    .IsRequired()
                    .HasColumnName("ID_QUIZZ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Poids).HasColumnName("POIDS");

                entity.HasOne(d => d.CodeensNavigation)
                    .WithMany(p => p.Matiere)
                    .HasForeignKey(d => d.Codeens)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GERE");

                entity.HasOne(d => d.IdQuizzNavigation)
                    .WithMany(p => p.Matiere)
                    .HasForeignKey(d => d.IdQuizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSSEDE");
            });

            modelBuilder.Entity<Passer>(entity =>
            {
                entity.HasKey(e => new { e.IdQuizz, e.Codeelev });

                entity.ToTable("passer", "quizz");

                entity.HasIndex(e => e.Codeelev)
                    .HasName("FK_PASSER");

                entity.Property(e => e.IdQuizz)
                    .HasColumnName("ID_QUIZZ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Codeelev)
                    .HasColumnName("CODEELEV")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DatePass)
                    .HasColumnName("DATE_PASS")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Note).HasColumnName("NOTE");

                entity.HasOne(d => d.CodeelevNavigation)
                    .WithMany(p => p.Passer)
                    .HasForeignKey(d => d.Codeelev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PASSER");

                entity.HasOne(d => d.IdQuizzNavigation)
                    .WithMany(p => p.Passer)
                    .HasForeignKey(d => d.IdQuizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PASSER2");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Idquestion);

                entity.ToTable("questions", "quizz");

                entity.HasIndex(e => e.IdQuizz)
                    .HasName("FK_CONTIENT");

                entity.Property(e => e.Idquestion)
                    .HasColumnName("IDQUESTION")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.A).IsUnicode(false);

                entity.Property(e => e.Answer)
                    .HasColumnName("ANSWER")
                    .HasColumnType("char(1)");

                entity.Property(e => e.B).IsUnicode(false);

                entity.Property(e => e.C).IsUnicode(false);

                entity.Property(e => e.D).IsUnicode(false);

                entity.Property(e => e.IdQuizz)
                    .IsRequired()
                    .HasColumnName("ID_QUIZZ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Poid)
                    .HasColumnName("POID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Question)
                    .HasColumnName("QUESTION")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdQuizzNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.IdQuizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTIENT");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.HasKey(e => e.IdQuizz);

                entity.ToTable("quizz", "quizz");

                entity.HasIndex(e => e.Codeens)
                    .HasName("FK_CREE");

                entity.Property(e => e.IdQuizz)
                    .HasColumnName("ID_QUIZZ")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Codeens)
                    .IsRequired()
                    .HasColumnName("CODEENS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sujet)
                    .HasColumnName("SUJET")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeensNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.Codeens)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREE");
            });
        }
    }
}
