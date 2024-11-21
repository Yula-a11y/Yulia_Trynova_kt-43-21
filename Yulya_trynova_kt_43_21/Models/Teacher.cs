using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Yulya_trynova_kt_43_21.Models;
using System.Net.Sockets;
using Yulya_trynova_kt_43_21.Models.Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Models
{
	public class Teacher
	{
		public int TeacherId { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string MiddleName { get; set; } = string.Empty;

		public string Position { get; set; } = string.Empty;

		public string? Degree { get; set; }

		public int CathedraId { get; set; }

		[JsonIgnore]
		public Cathedra? Cathedra { get; set; }

		public bool HasDegree() => Degree != null;

		public bool IsValidPosition() => Regex.IsMatch(Position, @"^[А-ЯЁ][а-яё\s\.][а-яё\s\.]*$");
	}
}
