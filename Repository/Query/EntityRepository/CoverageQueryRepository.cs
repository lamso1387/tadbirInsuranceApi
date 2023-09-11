
using Microsoft.EntityFrameworkCore;
using tadbirInsuranceApi.Data;
using tadbirInsuranceApi.Domain; 

namespace tadbirInsuranceApi.Repository
{
    public class CoverageQueryRepository : GenericQueryRepository<Coverage>, ICoverageQueryRepository
    {
        public CoverageQueryRepository(InsuranceQueryDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Coverage>?> GetByIdList(List<long> ids)
        {
            var coverages=new List<Coverage>();
            foreach (var id in ids) {
                var coverage=await table_query.FirstOrDefaultAsync(x => x.id==id);
                if (coverage == null) return null;
                coverages.Add(coverage);
            }
            return coverages;
        }
    }
}
