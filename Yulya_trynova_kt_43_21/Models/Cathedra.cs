﻿namespace Yulya_trynova_kt_43_21.Models
{
	public class Cathedra
	{
		public int CathedraId { get; set; }
		public required string Name { get; set; }

		public int? HeadOfDepartmentId { get; set; }
		public Teacher? HeadOfDepartment { get; set; }
	}
}
