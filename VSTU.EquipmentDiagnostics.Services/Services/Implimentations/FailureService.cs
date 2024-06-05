using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class FailureService : IFailureService
    {
        readonly FailureRepository _repository;
        public FailureService(string connString)
        {
            _repository = new FailureRepository(connString);
        }

        public List<Failure> GetFailures()
        {

            Func<Failure, bool> expr = (Failure failure) => { return true; };

            return _repository.Get(expr);
        }

        public List<Failure> GetFailuresByName(string name)
        {

            Func<Failure, bool> expr = (Failure failure) => { return failure.Name.ToLower().StartsWith(name.ToLower()); };

            return _repository.Get(expr);
        }

        public Failure GetFailureById(Guid Id)
        {

            Func<Failure, bool> expr = (Failure failure) => { return failure.Id == Id; };

            return _repository.GetFirstItem(expr);
        }

        public Failure CreateFailure(string newName)
        {
            return _repository.Create(new Failure
            {
                Name = newName
            }); ;
        }

        public void DeleteFailure(Guid Id)
        {
            Failure model = GetFailureById(Id);
            _repository.Delete(model);
            return;

        }
    }
}
