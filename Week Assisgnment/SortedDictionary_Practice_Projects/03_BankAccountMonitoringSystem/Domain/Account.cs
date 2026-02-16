namespace Domain
{
    public class Account{
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }

        // public abstract void Validate(); // TODO: Implement validation
    }
}
