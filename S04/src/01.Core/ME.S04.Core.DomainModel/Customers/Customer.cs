using ME.S04.Command.ErrorHandling;

namespace ME.S04.Core.DomainModel.Customers
{
    public class Customer
    {
        private int customerId;
        private string fName;
        private string lName;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new MEException("نام مشتری نباید خالی از مقدار باشد");

                fName = value;
            }
        }
        public string LName
        {
            get { return lName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new MEException("نام خانوادگی مشتری نباید خالی از مقدار باشد");

                lName = value;
            }
        }


    }
}
