namespace VSTU.EquipmentDiagnostics.ObjectModel
{
    public class RootCause : BaseModel
    {
        public string Name { get; set; }
        private const string Symbol = "RC";
        public string Code
        {
            get
            {
                return Symbol;
            }
        }
    }
}
