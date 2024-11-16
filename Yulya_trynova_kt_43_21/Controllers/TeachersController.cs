using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Database;
using Yulya_trynova_kt_43_21.Filters;
using Yulya_trynova_kt_43_21.Interfaces;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TeacherController : ControllerBase
	{
		private readonly ILogger<TeacherController> _logger;
		private readonly ITeacherGetterService _teacherGetterService;
		private readonly ITeacherModifierService _teacherModifierService;

		public TeacherController(ILogger<TeacherController> logger, ITeacherGetterService teacherGetterService, ITeacherModifierService teacherModifierService)
		{
			_logger = logger;
			_teacherGetterService = teacherGetterService;
			_teacherModifierService = teacherModifierService;
		}
		[HttpPost("GetTeachersByCathedra")]
		public async Task<IActionResult> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _teacherGetterService.GetTeachersByCathedraAsync(filter, cancellationToken);
			return Ok(teachers);
		}


		[HttpPost("GetTeachersByDegree")]
		public async Task<IActionResult> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _teacherGetterService.GetTeachersByDegreeAsync(filter, cancellationToken);
			return Ok(teachers);
		}

		[HttpPost("GetTeachersByPosition")]
		public async Task<IActionResult> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _teacherGetterService.GetTeachersByPositionAsync(filter, cancellationToken);
			return Ok(teachers);
		}

		[HttpPost("GetTeachersByFIO")]
		public async Task<IActionResult> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _teacherGetterService.GetTeachersByFIOAsync(filter, cancellationToken);
			return Ok(teachers);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			await _teacherModifierService.CreateTeacherAsync(teacher, cancellationToken);
			return Ok();
		}

		[HttpPost("Edit")]
		public async Task<IActionResult> EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			await _teacherModifierService.EditTeacherAsync(teacher, cancellationToken);
			return Ok();
		}

		[HttpPost("Remove")]
		public async Task<IActionResult> RemoveTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			await _teacherModifierService.RemoveTeacherAsync(teacher, cancellationToken);
			return Ok();
		}
	}
}
