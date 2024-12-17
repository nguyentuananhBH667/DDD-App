namespace LoginApp
{
    internal class Order
    {
        private int customerId;
        private int employeeId;
        private string? customerName;

        public Order(int customerId, int employeeId, string? customerName)
        {
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.customerName = customerName;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}