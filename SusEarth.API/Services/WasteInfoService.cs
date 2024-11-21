using SusEarth.API.Data;
using SusEarth.API.Models;
using System.Threading.Tasks;

namespace SusEarth.API.Services
{
    public class WasteInfoService
    {
        private readonly OracleDbContext _context;

        public WasteInfoService(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveWasteInfoAsync(WasteInfo wasteInfo)
        {
            try
            {
                _context.Add(wasteInfo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
