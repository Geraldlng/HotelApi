using hotelApi.Context;
using hotelApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public CountryController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<Country>> GetAllCountry()
        {
            var country = await databaseContext.Countries.ToListAsync();
            return country;
        }

        [HttpGet("{id}")]
        public async Task<Country?> GetIdCountry([FromRoute] int id)
        {
            var country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
            return country;
        }

        [HttpPost()]
        public async Task<Country> CreateCountry([FromBody] Country country)
        {
            databaseContext.Countries.Add(country);
            await databaseContext.SaveChangesAsync();
            return country;
        }

        [HttpPut("{id}")]
        public async Task<Country?> UpdateCountry([FromRoute] int id, [FromBody] Country country)
        {
            var countryRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (countryRecord == null)
            {
                return null;
            }

            countryRecord.CountryCode = country.CountryCode;
            countryRecord.CountryName = country.CountryName;

            await databaseContext.SaveChangesAsync();
            return countryRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool?> DeleteCountry([FromRoute] int id)
        {
            var countryRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (countryRecord == null)
            {
                return null;
            }

            databaseContext.Countries.Remove(countryRecord);

            await databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
