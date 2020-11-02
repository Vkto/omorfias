using API.Omorfias.Data.Base;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Omorfias.Data.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly OmorfiasContext _dbContext;
        public EnterpriseRepository(OmorfiasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Enterprise> GetBetterRated()
        {
            var enterprises = _dbContext.Enterprise.Where(userDb => (userDb.Evaluation > 0)).Take(5).ToList();
                                       
            return enterprises;
        }
      
    }
}
