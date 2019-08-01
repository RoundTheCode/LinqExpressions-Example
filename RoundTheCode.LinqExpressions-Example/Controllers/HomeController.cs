using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoundTheCode.LinqExpressions_Example.Data;
using RoundTheCode.LinqExpressions_Example.Expressions;
using RoundTheCode.LinqExpressions_Example.Models;

namespace RoundTheCode.LinqExpressions_Example.Controllers
{
    public class HomeController : Controller
    {
        protected readonly LinqExpressionsDbContext _context;

        public HomeController(LinqExpressionsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var anyExample = new AnyExpression().GetExampleQuery(_context);
            var includeExample = new IncludeExpression().GetExampleQuery(_context);
            var andOrExample = new AndOrExpression().GetExampleQuery(_context);

            var result = new ExpressionResult(anyExample.ToList(), includeExample.ToList(), andOrExample.ToList());

            return View(result);
        }
    }
}
