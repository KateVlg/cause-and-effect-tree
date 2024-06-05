using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class SymptomService : ISymptomService
    {
        readonly SymptomRepository _repository ;
        public SymptomService(string connString) 
        { 
            _repository = new SymptomRepository(connString);
        }

        public List<Symptom> GetSymptoms()
        {

            Func<Symptom, bool> expr = (Symptom symptom) => { return true; };

            return _repository.Get(expr);
        }

        public List<Symptom> GetSymptomsByName(string name)
        {
            
            Func<Symptom, bool> expr = (Symptom symptom) => { return symptom.Name.ToLower().StartsWith(name.ToLower()); };

            return _repository.Get(expr);
        }

        public Symptom GetSymptomById(Guid Id)
        {

            Func<Symptom, bool> expr = (Symptom symptom) => { return symptom.Id == Id; };

            return _repository.GetFirstItem(expr);
        }

        public Symptom CreateSymptom(string newName)
        {
            return _repository.Create(new Symptom
            {
                Name = newName
            });;
        }

        public void DeleteSymptom(Guid Id)
        {
            Symptom model = GetSymptomById(Id);
            _repository.Delete(model);
            return;

        }
    }
}
