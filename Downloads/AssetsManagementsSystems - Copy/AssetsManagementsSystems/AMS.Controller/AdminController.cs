// AdminController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AMS.Dal;
using AMS.Dal.Models;
using AssetsManagementsSystems.DAL;
using Microsoft.AspNetCore.Authorization;

namespace AMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly AssetDbContext _context;

        public AdminController(AssetDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

       
    }
}