namespace VSTU.EquipmentDiagnostics.ObjectModel
{
    public class FailureComplect : BaseModel
    {
        public Failure Failure { get; set; }
        public List <RootCause> RootCauses { get; set; }
        public List <Symptom> Symptoms { get; set; }
        public List<Failure> Predecessors { get; set; }
        public List<Failure> Successors { get; set; }
    }
}
