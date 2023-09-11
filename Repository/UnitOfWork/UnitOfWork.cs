using tadbirInsuranceApi.Data;  


namespace tadbirInsuranceApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InsuranceCommandDbContext _dbCommandContext;
        private readonly InsuranceQueryDbContext _dbQueryContext;
        public IInsurancePolicyCommandRepository _insurancePolicyRepo { get; private set; }
        public ICoverageCommandRepository _coverageRepo { get; private set; }
        public IUserCommandRepository _userRepo { get; private set; }

        public UnitOfWork(InsuranceCommandDbContext command_context,
            InsuranceQueryDbContext query_context)
        {
            _dbCommandContext = command_context;
            _dbQueryContext = query_context;
            _insurancePolicyRepo = new InsurancePolicyCommandRepository (_dbCommandContext, _dbQueryContext);
            _userRepo = new UserCommandRepository(_dbCommandContext, _dbQueryContext);
            _coverageRepo = new CoverageCommandRepository(_dbCommandContext, _dbQueryContext);

        }

        public int Save()
        {
            return _dbCommandContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbCommandContext.Dispose();
            }
        } 

        public async Task<bool> SaveAsync()
        {
            return await _dbCommandContext.SaveChangesAsync() > 0;
        }
         
    }
}
