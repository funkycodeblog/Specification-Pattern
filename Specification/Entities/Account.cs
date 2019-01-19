namespace FunkyCode.Specification
{
    public class Account : Entity
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}