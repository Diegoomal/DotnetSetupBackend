public class Facade : AbstractFacade 
{

    public Facade() : base() {
        new PersonRuleBuilder(new Person(), this.daos, this.rns);
    }

}// class