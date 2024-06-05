namespace VSTU.EquipmentDiagnostics.ObjectModel
{
    public class Equipment : BaseModel
    {
        public string Name { get; set; }
        
        public List <FailureComplect> FailureComplects { get; set; }
    }
}
