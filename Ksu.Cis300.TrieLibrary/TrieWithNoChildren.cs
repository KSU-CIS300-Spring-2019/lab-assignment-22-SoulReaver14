using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _emptyStringIsRooted = false;
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyStringIsRooted = true;
            }
            else
            {
                return new TrieWithOneChild(s, _emptyStringIsRooted);
            }
            return this;
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyStringIsRooted;
            }
            else return false;
            
        }
    }
}
