

namespace tadbirInsuranceApi.Domain;

public partial class InsurancePolicyCoverage
{
    public bool IsCapitalRangeValid() =>
        capital <= coverage!.max_capial && capital >= coverage!.min_capial;
    public void CalcCoveragePermium() =>
        coverage_premium = (long)(capital * rate);
    


}
