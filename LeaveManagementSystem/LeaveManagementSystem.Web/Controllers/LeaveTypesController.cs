using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Data.Models;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using AutoMapper;
using LeaveManagementSystem.Web.Contracts;

namespace LeaveManagementSystem.Web.Controllers
{
	public class LeaveTypesController(ILeaveTypesService leaveTypesService) : Controller
	{
		
		private readonly ILeaveTypesService _leaveTypesService = leaveTypesService;
		// GET: LeaveTypes
		public async Task<IActionResult> Index()
		{
			var viewData = await _leaveTypesService.GetAllLeaveTypesAsync();
			return View(viewData);
		}

		// GET: LeaveTypes/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var viewData = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);

			return View(viewData);
		}

		// GET: LeaveTypes/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: LeaveTypes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(LeaveTypeCreateViewModel leaveTypeCreate)
		{
			if(await _leaveTypesService.CheckIfNameAlreadyExists(leaveTypeCreate.Name))
			{
				ModelState.AddModelError(nameof(leaveTypeCreate.Name), "This leave type already exists");
			}
			if (ModelState.IsValid)
			{
				await _leaveTypesService.Create(leaveTypeCreate);
				return RedirectToAction(nameof(Index));
			}
			return View(leaveTypeCreate);
		}

		

		// GET: LeaveTypes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var viewData = await _leaveTypesService.Get<LeaveTypeEditViewModel>(id.Value);

			return View(viewData);
		}

		// POST: LeaveTypes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,  LeaveTypeEditViewModel leaveTypeEdit)
		{
			if (id != leaveTypeEdit.Id)
			{
				return NotFound();
			}
			if(await _leaveTypesService.CheckIfEditNameExists(leaveTypeEdit))
			{
				ModelState.AddModelError(nameof(leaveTypeEdit.Name), "This leave type already exists");
			}
			if (ModelState.IsValid)
			{
				try
				{
					await _leaveTypesService.Edit(leaveTypeEdit);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(leaveTypeEdit);
		}

		// GET: LeaveTypes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var viewData = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);

			return View(viewData);
		}

		// POST: LeaveTypes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _leaveTypesService.Remove(id);
			return RedirectToAction(nameof(Index));
		}

		
	}
}
