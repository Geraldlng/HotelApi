using hotelApi.Context;
using hotelApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarangayController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public BarangayController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<Barangay>> GetAllBarangays()
        {
            var barangay = await databaseContext.Barangays.ToListAsync();
            return barangay;
        }

        [HttpGet("{id}")]
        public async Task<Barangay?> GetIdBarangay([FromRoute] int id)
        {
            var barangay = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);
            return barangay;
        }

        [HttpPost()]
        public async Task<Barangay> CreateBarangay([FromBody] Barangay barangay)
        {
            databaseContext.Barangays.Add(barangay);
            await databaseContext.SaveChangesAsync();
            return barangay;
        }

        [HttpPut("{id}")]
        public async Task<Barangay?> UpdateBarangay([FromRoute] int id, [FromBody] Barangay barangay)
        {
            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return null;
            }

            barangayRecord.BarangayCode = barangay.BarangayCode;
            barangayRecord.BarangayName = barangay.BarangayName;

            await databaseContext.SaveChangesAsync();
            return barangayRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool?> DeleteBarangay([FromRoute] int id)
        {
            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return null;
            }

            databaseContext.Barangays.Remove(barangayRecord);

            await databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
