﻿namespace Yulya_trynova_kt_43_21.Models
{
	public class Discipline
	{
		public int DisciplineId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		public Teacher? Teacher { get; set; }
	}
}
