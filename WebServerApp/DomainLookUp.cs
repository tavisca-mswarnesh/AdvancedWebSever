using System.Collections.Generic;

namespace ExampleSimpleWebserver
{
    public class DomainLookUp
    {
        private Dictionary<string, string> _domainPathDictionary = new Dictionary<string, string>();
        public void AddDomainPath(string domain,string path)
        {
            _domainPathDictionary[domain] = path;
        }
        public string GetDomainPath(string domain)
        {
            return _domainPathDictionary[domain];
        }
        public Dictionary<string,string>GetDomainPathDictionary()
        {
            return _domainPathDictionary;
        }
    }
}