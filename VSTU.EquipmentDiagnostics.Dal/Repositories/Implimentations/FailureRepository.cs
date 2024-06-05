using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class FailureRepository
    {
        readonly string _connString;

        public FailureRepository(string connString)
        {
            _connString = connString;
        }

        public List<Failure> Get(Func<Failure, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Failure>().Where(expr).ToList();
        }

        public Failure GetFirstItem(Func<Failure, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Failure>().FirstOrDefault(expr);
        }

        public Failure Create(Failure model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Failure>().Add(model);
                Context.SaveChanges();
                return model;
            }
        }

        public void Delete(Failure model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Failure>().Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
