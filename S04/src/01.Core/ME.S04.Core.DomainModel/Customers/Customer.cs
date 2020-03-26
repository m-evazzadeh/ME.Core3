using ME.S04.Command.ErrorHandling;
using ME.S04.Core.DomainModel.Addresses;
using ME.S04.Core.DomainModel.General;

namespace ME.S04.Core.DomainModel.Customers
{
    public class Customer : IBaseEntity, ISoftDelete
    {
        private string fName;
        private string lName;

        public int CustomerId { get; set; }
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

        public bool IsDeleted { get; set; }

        public Address Address { get; set; }
        public AddressType AddressType { get; set; }

        public override string ToString()
        {
            return string.Concat(FName, " ", LName);
        }

    }
}
