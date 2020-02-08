using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Unified.Wmi.Orm
{
    public class WmiQueryBuilder
    {
        const string Select = "SELECT";
        const string From = "FROM";
        const string Space = " ";
        const string Separator = ",";

        readonly string _wmiClassName;

        public WmiQueryBuilder(string wmiClassName)
        {
            _wmiClassName = wmiClassName;
        }

        private readonly List<string> _parameters = new List<string>();

        public void AddParameter(string name)
        {
            _parameters.Add(name);
        }

        public override string ToString()
        {
            // initialise with select string
            var sb = new StringBuilder(Select + Space);

            var isFirst = true;
            foreach (var param in _parameters)
            {
                if (isFirst == true)
                {
                    isFirst = false;
                    sb.Append(param);                    
                }
                else
                {
                    sb.Append(Separator + Space + param);
                }
            }

            sb.Append(Space + From + Space + _wmiClassName);

            return sb.ToString();
        }
    }
}
