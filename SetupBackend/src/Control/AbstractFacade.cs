using System.Diagnostics;
using System.Text;

public abstract class AbstractFacade : IFacade
{
    private Result result;
    protected IDictionary<string, IDAO> daos;
    protected IDictionary<string, IDictionary<EventTypeDAO, IEnumerable<IStrategy>>> rns;

    public AbstractFacade() {
        this.result = new Result();
        this.daos = new Dictionary<string, IDAO>();
        this.rns = new Dictionary<string, IDictionary<EventTypeDAO, IEnumerable<IStrategy>>>();
    }

    private string ExecuteRules(IEntity entity, EventTypeDAO eventTypeDAO) {

        StringBuilder msg = new StringBuilder();
        
        IDictionary<EventTypeDAO, IEnumerable<IStrategy>> operationRules = this.rns[ entity.GetType().Name.ToString() ];

        if (operationRules == null) return string.Empty;

        IEnumerable<IStrategy> rules = operationRules[ eventTypeDAO ];
        
        if (rules == null) return string.Empty;
        
        foreach (IStrategy s in rules) {
            Debug.WriteLine(s.ToString());
            string m = s.Execute(entity);
            if (!string.IsNullOrEmpty(m)) msg.Append(m).Append("\n");
        }

        return string.IsNullOrEmpty(msg.ToString()) ? string.Empty : msg.ToString();

    }

    private Result ProcessOperation(IEntity entity, EventTypeDAO eventTypeDAO) {

        string msg = ExecuteRules(entity, eventTypeDAO);
        if (!string.IsNullOrEmpty(msg)) { this.result.Msg = msg; return this.result; }

        string className = entity.GetType().Name.ToString();

        try {
    
            IDAO dao = this.daos[ className ];

            if(EventTypeDAO.CREATE.Equals(eventTypeDAO)) {
                dao.Create(entity);
                this.result.Entities = new List<IEntity>() { entity };
            } else if(EventTypeDAO.DELETE.Equals(eventTypeDAO)) {
                dao.Delete(entity);
                this.result.Entities = new List<IEntity>() { entity };
            } else if(EventTypeDAO.READ.Equals(eventTypeDAO)) {
                IEnumerable<IEntity> Entities = dao.Read(entity);
                this.result.Entities = Entities;
            } else if(EventTypeDAO.UPDATE.Equals(eventTypeDAO)) {
                dao.Update(entity);
                this.result.Entities = new List<IEntity>() { entity };
            } else {
                this.result.Msg = "Operation not implemented yet";
            }
            
        } catch (Exception ex) {
            this.result.Msg = "DB_INSERT_ERROR -> class: " + className + " - operation: " + eventTypeDAO.ToString();
        }

        return this.result;

    }

    public Result Create(IEntity entity)
    {
        // string msg = ExecuteRules(entity, EventTypeDAO.CREATE);
        // if (!string.IsNullOrEmpty(msg)) { this.result.Msg = msg; return this.result; }

        // try {
        //     IDAO dao = this.daos[ entity.GetType().Name.ToString() ];
        //     dao.Create(entity);
        //     this.result.Entities = new List<IEntity>() { entity };
        // } catch (Exception) {
        //     this.result.Msg = "DB_INSERT_ERROR";
        // }

        // return this.result;

        return this.ProcessOperation(entity, EventTypeDAO.CREATE);
    }

    public Result Delete(IEntity entity)
    {
        // string msg = ExecuteRules(entity, EventTypeDAO.DELETE);
        // if (!string.IsNullOrEmpty(msg)) { this.result.Msg = msg; return this.result; }

        // try {
        //     IDAO dao = this.daos[ entity.GetType().Name.ToString() ];
        //     dao.Delete(entity);
        //     this.result.Entities = new List<IEntity>() { entity };
        // } catch (Exception) {
        //     this.result.Msg = "DB_INSERT_ERROR";
        // }

        // return this.result;

        return this.ProcessOperation(entity, EventTypeDAO.DELETE);
    }

    public Result Read(IEntity entity)
    {
        // string msg = ExecuteRules(entity, EventTypeDAO.READ);
        // if (!string.IsNullOrEmpty(msg)) { this.result.Msg = msg; return this.result; }

        // try {            
        //     IDAO dao = this.daos[ entity.GetType().Name.ToString() ];
        //     this.result.Entities = dao.Read(entity);
        // } catch (Exception) {
        //     this.result.Msg = "DB_READ_ERROR";
        // }

        // return this.result;

        return this.ProcessOperation(entity, EventTypeDAO.READ);
    }

    public Result Update(IEntity entity)
    {
        // string msg = ExecuteRules(entity, EventTypeDAO.UPDATE);
        // if (!string.IsNullOrEmpty(msg)) { this.result.Msg = msg; return this.result; }

        // try {
        //     IDAO dao = this.daos[ entity.GetType().Name.ToString() ];
        //     dao.Update(entity);
        //     this.result.Entities = new List<IEntity>() { entity };
        // } catch (Exception) {
        //     this.result.Msg = "DB_INSERT_ERROR";
        // }

        // return this.result;

        return this.ProcessOperation(entity, EventTypeDAO.UPDATE);
    }

}// class