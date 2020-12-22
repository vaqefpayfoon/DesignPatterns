namespace FacetedBuilder
{
    public class Person
    {
        public string StreetAddress, PostCode, City;
        public string CompanyName, Position;
        public int AnnualIncome;
        public override string ToString()
        {
            return string.Format("StreetAddress: {0}, PostCode: {1}, City: {2}, CompanyName: {3}, Position: {4}, AnnualIncome: {5}", StreetAddress, PostCode, City,CompanyName, Position, AnnualIncome);
        }
    }
    public class PersonBuilder //facade
    {
        protected Person person = new Person();
        public PersonJobBuilder works => new PersonJobBuilder(person);//subBuilder
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);//subBuilder
        public static implicit operator Person(PersonBuilder pb) => pb.person;
    }
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }
        public PersonJobBuilder At(string companyName)
        {
            this.person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            this.person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int amount)
        {
            this.person.AnnualIncome = amount;
            return this;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string StreetAddress)
        {
            person.StreetAddress = StreetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostCode(string PostCode)
        {
            person.PostCode = PostCode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
}