using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Dal
{
    public class SymptomRepository 
    {
        readonly string _connString;

        public SymptomRepository(string connString)
        {
            _connString = connString;
        }

        public List <Symptom> Get(Func<Symptom, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Symptom>().Where(expr).ToList();
        }

        public Symptom GetFirstItem(Func<Symptom, bool> expr)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
                return Context.Set<Symptom>().FirstOrDefault(expr);
        }

        public Symptom Create(Symptom model)
        {
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Symptom>().Add(model);
                Context.SaveChanges();
                return model;
            }
        }

        public void Delete(Symptom model)
        { 
            using (ApplicationContext Context = new ApplicationContext(_connString))
            {
                Context.Set<Symptom>().Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
