#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/v1/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TenantsController(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: api/Tenants
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Tenant>>> GetTenant()
        //{
        //    var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        //    var employeeRegistrations = _context.Employee.Where(employee => employee.UserFK == userId);
        //    return await _context.Tenant.Where(tenant => employeeRegistrations.Any(registration => registration.TenantFK == tenant.Id)).ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<Tenant>> GetTenant()
        {
            var tenantId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "TenantIdentifier")?.Value);

            var tenant = await _context.Tenant.FindAsync(tenantId);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        // GET: api/Tenants/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tenant>> GetTenant(Guid id)
        //{
        //    var tenant = await _context.Tenant.FindAsync(id);

        //    if (tenant == null)
        //    {
        //        return NotFound();
        //    }

        //    return tenant;
        //}

        // PUT: api/Tenants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenant(Guid id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tenants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tenant>> PostTenant(Tenant tenant)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            tenant.AdminUserFK = userId;
            tenant.Created = DateTime.UtcNow;
            _context.Tenant.Add(tenant);
            await _context.SaveChangesAsync();

            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.TenantFK = tenant.Id;
            user.IsSuperUser = true;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenant", new { id = tenant.Id }, tenant);
        }

        // DELETE: api/Tenants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            var tenant = await _context.Tenant.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            _context.Tenant.Remove(tenant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TenantExists(Guid id)
        {
            return _context.Tenant.Any(e => e.Id == id);
        }
    }
}
