using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.BL.Repository;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        #region feild
        //loosly coupled
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        //tightly coupled
        //DepartmentRep department;
        #endregion

        #region Ctor
        public DepartmentController(IDepartmentRep department , IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
            //this.department= new DepartmentRep(); //kdh fe elmomory akhd instance fkl fnction mwgoden fkdh msh 7yakhd object m3 khl function
        }
        #endregion

        #region Action
        public IActionResult Index()
        {
            var data = department.Get();
            var model = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);
            } 
            catch(Exception ex) 
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details( int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit( int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Edit(data);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var data = mapper.Map<Department>(model);
                    department.Delete(data);
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        #endregion

    }
}
