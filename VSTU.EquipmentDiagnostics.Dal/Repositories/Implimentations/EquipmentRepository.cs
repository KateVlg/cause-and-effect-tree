using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class EquipmentRepository
    {
        readonly string _connString;

        public EquipmentRepository(string connString)
        {
            _connString = connString;
        }

        public List<Equipment> Get(Func<Equipment, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Equipment>().Where(expr).ToList();
        }

        public Equipment? GetFirstItem(Func<Equipment, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Equipment>().FirstOrDefault(expr);
        }

        public Equipment Create(Equipment model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Equipment>().Add(model);
                Context.SaveChanges();
                return model;
            }
        }

        public void Delete(Equipment model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Equipment>().Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
