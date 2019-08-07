using System.Collections.Generic;

namespace ExampleSimpleWebserver
{
    public class DomainLookUp
    {
        public Dictionary<string, string> domainPathDictionary = new Dictionary<string, string>();
        public void AddDomainPath(string domain,string path)
        {
            domainPathDictionary[domain] = path;
        }
        public string GetDomainPath(string domain)
        {
            return domainPathDictionary[domain];
        }
    }
}