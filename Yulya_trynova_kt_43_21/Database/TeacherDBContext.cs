using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Database.Configuration;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Database
{
	public class TeacherDBContext : DbContext
	{
		public TeacherDBContext(DbContextOptions<TeacherDBContext> options) : base(options)
		{

		}

			DbSet<Cathedra> Cathedras { get; set; }
			DbSet<Teacher> Teachers { get; set; }
			DbSet<Discipline> Disciplines { get; set; }
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//добавляем конфигурации к таблицам
			modelBuilder.ApplyConfiguration(new CathedraConfiguration());
			modelBuilder.ApplyConfiguration(new TeacherConfiguration());
			modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
		}

	}
}
