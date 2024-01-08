public class PersonRuleBuilder {

    public PersonRuleBuilder(IEntity entity, IDictionary<string, IDAO> daos, IDictionary<string, IDictionary<EventTypeDAO, IEnumerable<IStrategy>>> rns) 
    {
        string className = entity.GetType().Name.ToString();

        daos.Add(className, new PersonDAO());

        ICollection<IStrategy> rulesCreate = new List<IStrategy>();
        rulesCreate.Add(new EntityNotNull());
        rulesCreate.Add(new CompleteRegisterDate());

        ICollection<IStrategy> rulesUpdate = new List<IStrategy>();
        rulesUpdate.Add(new EntityNotNull());
        rulesUpdate.Add(new CompleteRegisterDate());
        
        ICollection<IStrategy> rulesRead = new List<IStrategy>();
        rulesRead.Add(new EntityNotNull());

        ICollection<IStrategy> rulesDelete = new List<IStrategy>();
        rulesDelete.Add(new EntityNotNull());

        IDictionary<EventTypeDAO, IEnumerable<IStrategy>> rulesByOperation = new Dictionary<EventTypeDAO, IEnumerable<IStrategy>>();
        rulesByOperation.Add(EventTypeDAO.CREATE, rulesCreate);
        rulesByOperation.Add(EventTypeDAO.UPDATE, rulesUpdate);
        rulesByOperation.Add(EventTypeDAO.READ,   rulesRead);
        rulesByOperation.Add(EventTypeDAO.DELETE, rulesDelete);

        rns.Add(className, rulesByOperation);
    }

}// class