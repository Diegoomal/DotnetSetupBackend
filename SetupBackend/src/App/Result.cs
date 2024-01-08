using System.Collections;

public class Result {

    public string Msg { get; set; }
    public IEnumerable<IEntity> Entities { get; set; }

    public Result() {
        this.Msg = string.Empty;
        this.Entities = new List<IEntity>();
    }

    public override string ToString() {
        return UtilString.GetDataClass(this);
    }

}