using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public interface IEquipmentService
    {
        List<Equipment> GetEquipmentsByName(string name);

        Equipment GetEquipmentById(Guid id);

        List<Equipment> GetEquipments();

        Equipment CreateEquipment(Equipment equipment);

        void DeleteEquipment(Guid id);

        List<FailureComplect> GetFailureComplects(Guid idEquipment);
    }
}
