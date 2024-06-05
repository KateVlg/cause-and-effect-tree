using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.Services
{
    public interface IFailureComplectService
    {
        FailureComplect GetFailureComplectById(Guid id);

        List<FailureComplect> GetFailureComplects();

        void DeleteFailureComplect(Guid id);
    }
}
