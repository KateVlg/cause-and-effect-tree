using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public class EquipmentService : IEquipmentService
    {
        readonly EquipmentRepository _repository;
        public EquipmentService(string connString)
        {
            _repository = new EquipmentRepository(connString);
        }

        public List<Equipment> GetEquipments()
        {

            Func<Equipment, bool> expr = (Equipment equipment) => { return true; };

            return _repository.Get(expr);
        }

        public List<Equipment> GetEquipmentsByName(string name)
        {

            Func<Equipment, bool> expr = (Equipment equipment) => { return equipment.Name.ToLower().StartsWith(name.ToLower()); };

            return _repository.Get(expr);
        }

        public Equipment? GetEquipmentById(Guid Id)
        {

            Func<Equipment, bool> expr = (Equipment equipment) => { return equipment.Id == Id; };

            return _repository.GetFirstItem(expr);
        }

        public void DeleteEquipment(Guid Id)
        {
            Equipment? model = GetEquipmentById(Id);
            if(model != null)
                _repository.Delete(model);
        }

        public List<FailureComplect> GetFailureComplects(Guid idEquipment)
        {

            Func<Equipment, bool> expr = (Equipment equipment) => { return equipment.Id == idEquipment; };

            Equipment equipment = _repository.GetFirstItem(expr);

            if (equipment == null)
            {
                return new List<FailureComplect>();
            }

            return equipment.FailureComplects;
        }

        public Equipment CreateEquipment(Equipment equipment)
        {
            return _repository .Create(equipment);
        }
    }
}
