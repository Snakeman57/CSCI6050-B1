using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CineWeb.Data;
using CineWeb.Models;
using CineWeb.Areas.Identity.Services;

namespace CineWeb.Controllers
{
    // [Route("Book")]
    public class OrderController: Controller {
        private readonly WebContext _context;
        public OrderController(WebContext context) {
            _context = context;
        }
        // get order history by user
    }
}