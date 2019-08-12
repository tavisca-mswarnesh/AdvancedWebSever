using System.Collections.Generic;

namespace SimpleWebserver
{
    public class DomainLookUp
    {
        private Dictionary<string, string> _domainPathDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> _apiPath = new Dictionary<string, string>();
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

        public void AddApiPath(string domain, string path)
        {
            _apiPath[domain] = path;
        }
        public string GetApiPath(string domain)
        {
            return _apiPath[domain];
        }
        public Dictionary<string, string> GetApiPathDictionary()
        {
            return _apiPath;
        }
    }
}