
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Tests
{
    public class TeacherTests
    {
        [Fact]
        //false, если у преподавателя нет степени
        public void HasDegree_Null_False()
        {
            //Создаётся объект Teacher с Degree = null.
            var teacher = new Teacher
            {
                Degree = null,
            };

            var result = teacher.HasDegree();

            Assert.False(result);
        }

        [Fact]
        //true, если у преподавателя есть степень.
        public void HasDegree_Ktn_True()
        {
            var teacher = new Teacher
            {
                Degree = "к.п.н.",
            };

            var result = teacher.HasDegree();

            Assert.True(result);
        }

        [Fact]
        //false, если позиция преподавателя указана с неверным форматом (например, с маленькой буквы).
        public void IsValidPotition_zavkaf_False()
        {
            var teacher = new Teacher
            {
                Position = "зав. каф."
            };

            var result = teacher.IsValidPosition();

            Assert.False(result);
        }

        [Fact]
        public void IsValidPotition_Zavkaf_True()
        {
            var teacher = new Teacher
            {
                Position = "Зз. кю."
            };

            var result = teacher.IsValidPosition();

            Assert.True(result);
        }
    }
}
