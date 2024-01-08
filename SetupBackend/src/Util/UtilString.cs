using System.Reflection;
using System.Text;

public class UtilString {
    public static string GetDataClass(object thisClass) {
        StringBuilder result = new StringBuilder();
        
        Type type = thisClass.GetType();
        PropertyInfo[] properties = type.GetProperties();

        result.AppendLine($"{type.Name} Properties:");

        foreach (PropertyInfo property in properties) {
            object value = property.GetValue(thisClass);
            result.AppendLine($"{property.Name}: {value}");
        }

        return result.ToString();
    }
}