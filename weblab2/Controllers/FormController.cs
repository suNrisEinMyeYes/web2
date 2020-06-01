using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weblab2.Models;

namespace weblab2.Controllers
{
    public class FormController : Controller
    {
        private int calculate(int first, int second, string operation)
        {
            switch (operation)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "*":
                    return first * second;

                case "/":
                    if (second == 0)
                    {
                        return 0;
                    }
                    return first / second;
                default:
                    return 0;
            }
        }

        public IActionResult ManualSingle(int first, string operation, int second)
        {
            if (Request.Method == "GET")
            {
                ViewBag.h1 = "ManualSingle";
                return View("MainForm");
            }
            if (Request.Method == "POST")
            {
                int result = this.calculate(first, second, operation);
                ViewBag.result = $"{result}";
                return View("ResultForm");
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult ManualSep()
        {
            ViewBag.h1 = "ManualSep";
            return View("MainForm");
        }
        [HttpPost]
        public IActionResult ManualSep(int first, string operation, int second)
        {
            int result = this.calculate(first, second, operation);
            ViewBag.result = $"{result}";
            return View("ResultForm");
        }

        [HttpGet]
        public IActionResult ModelBindPar()
        {
            ResultModel rm = new ResultModel();
            ViewBag.h1 = "ModelBindPar";
            return View("MainFormModel", rm);
        }

        [HttpPost]
        public IActionResult ModelBindPar(int first, int second, string operation)
        {
            ResultModel rm = new ResultModel(first, second, operation);
            rm.calculationResult = this.calculate(rm.first, rm.second, rm.operation);
            return View("ResultFormModel", rm);
        }
        [HttpGet]
        public IActionResult ModelBindSep()
        {
            ResultModel rm = new ResultModel();
            ViewBag.h1 = "ModelBindSep";
            return View("MainFormModel", rm);
        }

        [HttpPost]
        public IActionResult ModelBindSep(ResultModel rm)
        {
            //ResultModel rm = new ResultModel(first, second, operation);
            rm.calculationResult = this.calculate(rm.first, rm.second, rm.operation);
            return View("ResultFormModel", rm);
        }
    }
}