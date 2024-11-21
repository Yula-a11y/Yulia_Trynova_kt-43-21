
using Yulya_trynova_kt_43_21.Database;
using Yulya_trynova_kt_43_21.Filters;
using Yulya_trynova_kt_43_21.Interfaces;
using Yulya_trynova_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Models.Yulya_trynova_kt_43_21.Models;


namespace Yulya_trynova_kt_43_21.Tests
{
    public class TeacherIntegrationTests
    {

        //Настраивает параметры контекста для использования базы данных в памяти.
        //Вызывает метод ArrangeData для наполнения базы тестовыми данными.

        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
                .UseInMemoryDatabase("db_pp")
                .Options;

            ArrangeData();
        }

        //Удаляет предыдущую базу данных (если она существует).
        //Создаёт новую базу данных.
        //Добавляет в базу две кафедры и трёх преподавателей.
       // Сохраняет данные в базе.
        private void ArrangeData()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var cathedras = new List<Cathedra>
            {
                new Cathedra
                {
                    CathedraId = 1,
                    Name = "Кафедра 1",
                },
                new Cathedra
                {
                    CathedraId = 2,
                    Name = "Кафедра 2",
                }
            };
            ctx.Set<Cathedra>().AddRange(cathedras);

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "t",
                    LastName = "t",
                    MiddleName = "t",
                    Position = "1",
                    Degree = "Степень",
                    CathedraId = 1
                },
                new Teacher
                {
                    FirstName = "t",
                    LastName = "t",
                    MiddleName = "t",
                    Position = "2",
                    Degree = "Степень",
                    CathedraId = 2,
                },
                new Teacher
                {
                    FirstName = "t",
                    LastName = "t",
                    MiddleName = "b",
                    Position = "3",
                    CathedraId = 1,
                }
            };
            ctx.Set<Teacher>().AddRange(teachers);
            ctx.SaveChanges();
        }


        //Метод GetTeachersByCathedraAsync возвращает 2 преподавателей, принадлежащих к кафедре с названием "Кафедра 1"

        [Fact]
        public async Task GetTeachersByCathedraAsync_Kafedra1_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherCathedraFilter()
            {
                CathedraName = "Кафедра 2"
            };

            var teachersResult = await teacherGetterService.GetTeachersByCathedraAsync(filter);

            // Assert
            Assert.Equal(1, teachersResult.Length);
        }

        //Метод GetTeachersByDegreeAsync возвращает 2 преподавателей, у которых степень равна "Степень"
        [Fact]
        public async Task GetTeachersByDegreeAsync_Stepen_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherDegreeFilter()
            {
                Degree = "Степень"
            };

            var teachersResult = await teacherGetterService.GetTeachersByDegreeAsync(filter);

            // Assert
            Assert.Equal(2, teachersResult.Length);
        }

        //возвращает 2 преподавателей, у которых айди кафедры равно 2
        [Fact]
        public async Task GetTeachersByCathedraIDAsync_TwoObjects()
        {
            // Arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherGetterService = new TeacherGetterService(ctx);

            // Act
            var filter = new TeacherCathedraIDFilter()
            {
                CathedraID = 1
            };

            var teachersResult = await teacherGetterService.GetTeachersByCathedraIDAsync(filter);

            // Assert
            Assert.Equal(2, teachersResult.Length);
        }

        
    }
}
