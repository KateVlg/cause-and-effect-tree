using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class FailureComplectRepository
    {
        readonly string _connString;

        public FailureComplectRepository(string connString)
        {
            _connString = connString;
        }


        public List<FailureComplect> Get(Func<FailureComplect, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<FailureComplect>().Where(expr).ToList();
        }


        public FailureComplect GetFirstItem(Func<FailureComplect, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<FailureComplect>().FirstOrDefault(expr);
        }

        public FailureComplect Create(FailureComplect model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<FailureComplect>().Add(model);
                Context.SaveChanges();
                return model;
            }
        }

        public void Delete(FailureComplect model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<FailureComplect>().Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
