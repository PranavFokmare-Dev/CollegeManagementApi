using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CollegeManagementApi.Models
{
    public partial class CollegeManagementContext : DbContext
    {
        public CollegeManagementContext()
        {
        }

        public CollegeManagementContext(DbContextOptions<CollegeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignmentUpload> AssignmentUploads { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseMark> CourseMarks { get; set; }
        public virtual DbSet<CoursePage> CoursePages { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<GroupChat> GroupChats { get; set; }
        public virtual DbSet<GroupPartOf> GroupPartOfs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<ProjectMark> ProjectMarks { get; set; }
        public virtual DbSet<Registerd> Registerds { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<SlotDuration> SlotDurations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TaughtBy> TaughtBies { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=CollegeManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssignmentUpload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Assignment_upload");

                entity.Property(e => e.AssignmentName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("assignment_name");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.Path)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("path");

                entity.Property(e => e.RegisterdId).HasColumnName("registerd_id");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("date")
                    .HasColumnName("upload_date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Registerd)
                    .WithMany()
                    .HasForeignKey(d => d.RegisterdId)
                    .HasConstraintName("assignment_upload_registerd_id_fk");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Attendance");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegisterdId).HasColumnName("registerd_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Registerd)
                    .WithMany()
                    .HasForeignKey(d => d.RegisterdId)
                    .HasConstraintName("attendance_registerd_id_fk");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.CourseStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("course_status")
                    .IsFixedLength(true);

                entity.Property(e => e.CourseType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("course_type");

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.SyllabusPath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("syllabus_path");
            });

            modelBuilder.Entity<CourseMark>(entity =>
            {
                entity.HasKey(e => e.RegisteredId)
                    .HasName("marks_primary_key");

                entity.ToTable("Course_marks");

                entity.Property(e => e.RegisteredId)
                    .ValueGeneratedNever()
                    .HasColumnName("registered_id");

                entity.Property(e => e.Cat1).HasColumnName("cat1");

                entity.Property(e => e.Cat2).HasColumnName("cat2");

                entity.Property(e => e.Da1).HasColumnName("da1");

                entity.Property(e => e.Da2).HasColumnName("da2");

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Quiz1).HasColumnName("quiz1");

                entity.Property(e => e.Quiz2).HasColumnName("quiz2");
            });

            modelBuilder.Entity<CoursePage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Course_page");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Path)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("path");

                entity.Property(e => e.TaughtById).HasColumnName("taught_by_id");

                entity.HasOne(d => d.TaughtBy)
                    .WithMany()
                    .HasForeignKey(d => d.TaughtById)
                    .HasConstraintName("course_page_taught_by_id");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.ToTable("Degree");

                entity.Property(e => e.DegreeId).HasColumnName("degree_id");

                entity.Property(e => e.DegreeDuration).HasColumnName("degreeDuration");

                entity.Property(e => e.DegreeName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("degreeName");

                entity.Property(e => e.DegreeType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("degreeType")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.DesignationId).HasColumnName("designation_id");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("designation_name");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<GroupChat>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("group_of_people_pk");

                entity.ToTable("Group_chat");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<GroupPartOf>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.RegisterNumber })
                    .HasName("group_part_of_pk");

                entity.ToTable("Group_part_of");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.RegisterNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("register_number")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPartOfs)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_part_of_group_id");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Message");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.MessageId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("message_id");

                entity.Property(e => e.RecieverId).HasColumnName("reciever_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.SentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("sentAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("message_group_id");
            });

            modelBuilder.Entity<ProjectMark>(entity =>
            {
                entity.HasKey(e => e.RegisterdId)
                    .HasName("project_marks_primary_key");

                entity.ToTable("Project_marks");

                entity.Property(e => e.RegisterdId)
                    .ValueGeneratedNever()
                    .HasColumnName("registerd_id");

                entity.Property(e => e.Review1).HasColumnName("review1");

                entity.Property(e => e.Review2).HasColumnName("review2");

                entity.Property(e => e.Review3).HasColumnName("review3");
            });

            modelBuilder.Entity<Registerd>(entity =>
            {
                entity.ToTable("Registerd");

                entity.Property(e => e.RegisterdId).HasColumnName("registerd_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TaughtById).HasColumnName("taught_by_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Registerds)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("registerd_student_id_fk");

                entity.HasOne(d => d.TaughtBy)
                    .WithMany(p => p.Registerds)
                    .HasForeignKey(d => d.TaughtById)
                    .HasConstraintName("registerd_taught_by_id_fk");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("building_name");

                entity.Property(e => e.FloorNumber).HasColumnName("floor_number");

                entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("School");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("building_name");

                entity.Property(e => e.DeanId).HasColumnName("dean_id");

                entity.Property(e => e.HodId).HasColumnName("hod_id");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("school_name");

                entity.HasOne(d => d.Dean)
                    .WithMany(p => p.SchoolDeans)
                    .HasForeignKey(d => d.DeanId)
                    .HasConstraintName("School_dean_id_fk");

                entity.HasOne(d => d.Hod)
                    .WithMany(p => p.SchoolHods)
                    .HasForeignKey(d => d.HodId)
                    .HasConstraintName("School_hod_id_fk");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Session");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.Property(e => e.TaughtById).HasColumnName("taught_by_id");

                entity.HasOne(d => d.Slot)
                    .WithMany()
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("slot_id_fk");

                entity.HasOne(d => d.TaughtBy)
                    .WithMany()
                    .HasForeignKey(d => d.TaughtById)
                    .HasConstraintName("taught_by_id");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.Property(e => e.SlotName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("slot_name");
            });

            modelBuilder.Entity<SlotDuration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Slot_duration");

                entity.Property(e => e.Day)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("day")
                    .IsFixedLength(true);

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.HasOne(d => d.Slot)
                    .WithMany()
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("slot_duration_slot_id_fk");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.DegreeId).HasColumnName("degree_id");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailid");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagePath");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ProctorId).HasColumnName("proctor_id");

                entity.Property(e => e.RegisterNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("register_number")
                    .HasComputedColumnSql("(concat('S',right('0000'+CONVERT([varchar](4),[student_id]),(4))))", false);

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.Property(e => e.YearOfJoining)
                    .HasColumnName("yearOfJoining")
                    .HasDefaultValueSql("(CONVERT([smallint],datepart(year,getdate())))");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("student_degree_id_fk");

                entity.HasOne(d => d.Proctor)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ProctorId)
                    .HasConstraintName("student_proctor_id_fk");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("student_school_id_fk");
            });

            modelBuilder.Entity<TaughtBy>(entity =>
            {
                entity.ToTable("taught_by");

                entity.Property(e => e.TaughtById).HasColumnName("taught_by_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.FilledSeats).HasColumnName("filled_seats");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.TotalSeats).HasColumnName("total_seats");

                entity.Property(e => e.WaitingSeats).HasColumnName("waiting_seats");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TaughtBies)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("taught_by_course_id_fk");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TaughtBies)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("taught_by_room_id_fk");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TaughtBies)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("taught_by_teacher_id");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.DesignationId).HasColumnName("designation_id");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailid");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagePath");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RegisterNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("register_number")
                    .HasComputedColumnSql("(concat('T',right('0000'+CONVERT([varchar](4),[teacher_id]),(4))))", false);

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("teacher_designation_id_fk");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("teacher_school_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
