namespace VSTU.EquipmentDiagnostics.ObjectModel
{
    public class Symptom : BaseModel
    {
        public string Name { get; set; }
        private const string Symbol = "S";
        public string Code
        {
            get
            {
                return Symbol;
            }
        }
    }
}
