
namespace TemplateEngine;

public class TemplateEngine
{
    private string _template = string.Empty;
    private string _name = string.Empty;
    private string _value = string.Empty;
    private IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();
    public void SetTemplate(string aTemplate)
    {
        _template = aTemplate;
    } 

    public string Evaluate()
    {
        string fullname = _template;
        foreach (var keyValuePair in keyValuePairs)
        {
            fullname = fullname.Replace("{" + keyValuePair.Key + "}", keyValuePair.Value);
        }

        return fullname;
    }

    public void SetVariable(string theName, string theValue)
    {
        _name = theName;
        _value = theValue;
        keyValuePairs.Add(theName, theValue);
    }
}
