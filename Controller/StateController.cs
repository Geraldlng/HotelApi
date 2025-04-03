using hotelApi.Context;
using hotelApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public StateController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<List<State>> GetAllState()
        {
            var state = await databaseContext.States.ToListAsync();
            return state;
        }

        [HttpGet("{id}")]
        public async Task<State?> GetIdState([FromRoute] int id)
        {
            var state = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);
            return state;
        }

        [HttpPost()]
        public async Task<State> CreateState([FromBody] State state)
        {
            databaseContext.States.Add(state);
            await databaseContext.SaveChangesAsync();
            return state;
        }

        [HttpPut("{id}")]
        public async Task<State?> UpdateState([FromRoute] int id, [FromBody] State state)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return null;
            }

            stateRecord.StateCode = state.StateCode;
            stateRecord.StateName = state.StateName;

            await databaseContext.SaveChangesAsync();
            return stateRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool?> DeleteState([FromRoute] int id)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return null;
            }

            databaseContext.States.Remove(stateRecord);

            await databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
