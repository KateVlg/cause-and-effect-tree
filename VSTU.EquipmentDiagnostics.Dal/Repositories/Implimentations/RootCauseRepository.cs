using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class RootCauseRepository
    {
        readonly string _connString;

        public RootCauseRepository(string connString)
        {
            _connString = connString;
        }

        public List<RootCause> Get(Func<RootCause, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<RootCause>().Where(expr).ToList();
        }

        public RootCause GetFirstItem(Func<RootCause, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<RootCause>().FirstOrDefault(expr);
        }

        public RootCause Create(RootCause model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<RootCause>().Add(model);
                Context.SaveChanges();
                return model;
            }
        }

        public void Delete(RootCause model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<RootCause>().Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
