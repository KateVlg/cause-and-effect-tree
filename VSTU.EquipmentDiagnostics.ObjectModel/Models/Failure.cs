namespace VSTU.EquipmentDiagnostics.ObjectModel
{
    public class Failure : BaseModel
    {
        public string Name { get; set; }        
        private const string Symbol = "F";
        public string Code
        {
            get
            {
                return Symbol;
            }
        }
    }
}
