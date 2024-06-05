using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class FailureComplectService : IFailureComplectService
    {
        readonly FailureComplectRepository _repository;
        public FailureComplectService(string connString)
        {
            _repository = new FailureComplectRepository(connString);
        }

        public List<FailureComplect> GetFailureComplects()
        {

            Func<FailureComplect, bool> expr = (FailureComplect FailureComplect) => { return true; };

            return _repository.Get(expr);
        }

        public FailureComplect GetFailureComplectById(Guid Id)
        {

            Func<FailureComplect, bool> expr = (FailureComplect FailureComplect) => { return FailureComplect.Id == Id; };

            return _repository.GetFirstItem(expr);
        }

        public void DeleteFailureComplect(Guid Id)
        {
            FailureComplect model = GetFailureComplectById(Id);
            _repository.Delete(model);
            return;

        }
    }
}
