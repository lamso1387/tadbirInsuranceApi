using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using tadbirInsuranceApi.Repository;

namespace tadbirInsuranceApi.Services
{
    public class InsurancePolicyService : GenericService<InsurancePolicy>
    { 
        public InsurancePolicyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
        }

        public override async Task Add(InsurancePolicy entity)
        {
            var coverages = await _unitOfWork._coverageRepo.GetByIdList(entity.coverages!.Select(x => x.coverage_id).ToList());
            if (coverages == null)
                throw new GlobalException(ErrorCode.BadRequest, MessageText.covarage_id_wrong);

            foreach (var item in entity.coverages!)
            {
                item.coverage = coverages.First(x => x.id == item.coverage_id);
                if (!item.IsCapitalRangeValid())
                    throw new GlobalException(ErrorCode.BadRequest, MessageText.covarage_capital_not_in_valid_range);

                item.rate = item.coverage.rate;
                item.CalcCoveragePermium();
            }
            entity.CalcTotalPermium();
            await _unitOfWork._insurancePolicyRepo.Add(entity);
            await _unitOfWork.SaveAsync();
        }

    }


}