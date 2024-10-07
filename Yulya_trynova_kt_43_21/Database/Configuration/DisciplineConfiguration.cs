﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Database.Helpers;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Database.Configuration
{
	public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
	{
		
			private const string TableName = "disciplines";
			public void Configure(EntityTypeBuilder<Discipline> builder)
			{
				builder
					.ToTable(TableName)
					.HasKey(p => p.DisciplineId);
				builder.Property(p => p.DisciplineId)
					.ValueGeneratedOnAdd()
					.HasColumnName("discipline_id")
					.HasComment("Идентификатор записи дисциплины");
				builder.Property(p => p.Name)
					.IsRequired()
					.HasColumnName("discipline_name")
					.HasColumnType(ColumnType.String).HasMaxLength(100)
					.HasComment("Название дисциплины");
				builder.Property(p => p.TeacherId)
					.IsRequired()
					.HasColumnName("f_teacher_id")
					.HasColumnType(ColumnType.Int)
					.HasComment("Идентификатор преподавателя");
				builder.ToTable(TableName)
					.HasOne(p => p.Teacher)
					.WithMany()
					.HasForeignKey(p => p.TeacherId)
					.OnDelete(DeleteBehavior.Cascade);
				builder.Navigation(p => p.Teacher)
					.AutoInclude();
			}
	}
}
