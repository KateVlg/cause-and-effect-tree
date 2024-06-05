using VSTU.EquipmentDiagnostics.ObjectModel;
using VSTU.EquipmentDiagnostics.Dal;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class RootCauseService : IRootCauseService
    {
        readonly RootCauseRepository _repository;
        public RootCauseService(string connString)
        {
            _repository = new RootCauseRepository(connString);
        }

        public List<RootCause> GetRootCauses()
        {

            Func<RootCause, bool> expr = (RootCause rootCause) => { return true; };

            return _repository.Get(expr);
        }

        public List<RootCause> GetRootCausesByName(string name)
        {

            Func<RootCause, bool> expr = (RootCause rootCause) => { return rootCause.Name.ToLower().StartsWith(name.ToLower()); };

            return _repository.Get(expr);
        }

        public RootCause GetRootCauseById(Guid Id)
        {

            Func<RootCause, bool> expr = (RootCause rootCause) => { return rootCause.Id == Id; };

            return _repository.GetFirstItem(expr);
        }

        public RootCause CreateRootCause(string newName)
        {
            return _repository.Create(new RootCause
            {
                Name = newName
            }); ;
        }

        public void DeleteRootCause(Guid Id)
        {
            RootCause model = GetRootCauseById(Id);
            _repository.Delete(model);
            return;

        }
    }
}
