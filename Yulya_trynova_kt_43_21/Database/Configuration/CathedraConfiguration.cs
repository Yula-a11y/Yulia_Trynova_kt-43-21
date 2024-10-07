using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Database.Helpers;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Database.Configuration
{
    public class CathedraConfiguration : IEntityTypeConfiguration<Cathedra>
	{
		private const string TableName = "cathedras";

		public void Configure(EntityTypeBuilder<Cathedra> builder)
		{
			builder
				.ToTable(TableName)
				.HasKey(p => p.CathedraId);
			builder.Property(p => p.CathedraId)
				.ValueGeneratedOnAdd()
				.HasColumnName("cathedra_id")
				.HasComment("Идентификатор записи кафедры");
			builder.Property(p => p.Name)
				.IsRequired()
				.HasColumnName("cathedra_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название кафедры");
		}
	}
}
