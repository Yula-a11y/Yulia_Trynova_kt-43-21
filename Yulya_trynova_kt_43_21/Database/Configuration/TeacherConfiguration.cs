using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yulya_trynova_kt_43_21.Database.Helpers;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Database.Configuration
{
	public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
	{
		private const string TableName = "teachers";
		public void Configure(EntityTypeBuilder<Teacher> builder)
		{
			builder
				.ToTable(TableName)
				.HasKey(p => p.TeacherId);
			builder.Property(p => p.TeacherId)
				.ValueGeneratedOnAdd()
				.HasColumnName("teacher_id")
				.HasComment("Идентификатор записи преподавателя");

			builder.Property(p => p.FirstName)
				.IsRequired()
				.HasColumnName("teacher_firstname")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Имя преподавателя");

			builder.Property(p => p.LastName)
				.IsRequired()
				.HasColumnName("teacher_lastname")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Фамилия преподавателя");

			builder.Property(p => p.MiddleName)
				.HasColumnName("teacher_middlename")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Отчество преподавателя");

			builder.Property(p => p.CathedraId)
				.IsRequired()
				.HasColumnName("f_department_id")
				.HasColumnType(ColumnType.Int)
				.HasComment("Идентификатор кафедры");

			builder.ToTable(TableName)
				.HasOne(p => p.Cathedra)
				.WithMany()
				.HasForeignKey(p => p.CathedraId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.Navigation(p => p.Cathedra)
				.AutoInclude();
		}
	}
}
