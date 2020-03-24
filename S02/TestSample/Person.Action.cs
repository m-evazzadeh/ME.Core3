using System;

namespace TestSample
{
    public partial class Person
    {
        public Person(int personId, string fName, string lName, DateTime birthDate)
        {
            PersonId = personId;
            FName = fName;
            LName = lName;
            BirthDate = birthDate;
        }
        public override string ToString()
        {
            return string.Concat(this.FName, " ", this.LName);
        }
        public int Age()
        {
            return DateTime.Now.AddYears(-1 * this.BirthDate.Year).Year;

        }
        public void ThrowEx01()
        {
            throw new NotImplementedException("error1");
        }

        public void ThrowEx02()
        {
            throw new FormatException("error1");
        }
    }
}
