using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Services.Interfaces;

namespace Nik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLogoesController : ControllerBase
    {
        private readonly NikDbContext _context;
        private readonly ICompanyLogoRepository _companyrepo;

        public CompanyLogoesController(NikDbContext context, ICompanyLogoRepository companyLogoRepository)
        {
            _context = context;
            _companyrepo = companyLogoRepository;
        }

        // GET: api/CompanyLogoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyLogo>>> GetCompanyLogos()
        {
            if (_context.CompanyLogos == null)
            {
                return NotFound();
            }
            return await _companyrepo.getAllLogoCompany();
        }

        // GET: api/CompanyLogoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyLogo>> GetCompanyLogo(int id)
        {
            if (_context.CompanyLogos == null)
            {
                return NotFound();
            }
            var companyLogo = await _companyrepo.getCompanyById(id);

            return companyLogo;
        }

        // PUT: api/CompanyLogoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyLogo(int id, [FromForm] CompanyLogo companyLogo)
        {
            if (id != companyLogo.CompanyLogosId)
            {
                return BadRequest();
            }

            _context.Entry(companyLogo).State = EntityState.Modified;

            try
            {
                await _companyrepo.putCompanyLogo(id, companyLogo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyLogoExists(id))
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

        // POST: api/CompanyLogoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyLogo>> PostCompanyLogo([FromForm] CompanyLogo companyLogo)
        {
            if (_context.CompanyLogos == null)
            {
                return Problem("Entity set 'NikDbContext.CompanyLogos'  is null.");
            }
            await _companyrepo.postCompanyLogo(companyLogo);

            return CreatedAtAction("GetCompanyLogo", new { id = companyLogo.CompanyLogosId }, companyLogo);
        }

        // DELETE: api/CompanyLogoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyLogo(int id)
        {
            if (_context.CompanyLogos == null)
            {
                return NotFound();
            }
            _companyrepo.deleteCompanyLogo(id);
            return NoContent();
        }

        private bool CompanyLogoExists(int id)
        {
            return (_context.CompanyLogos?.Any(e => e.CompanyLogosId == id)).GetValueOrDefault();
        }
    }
}
