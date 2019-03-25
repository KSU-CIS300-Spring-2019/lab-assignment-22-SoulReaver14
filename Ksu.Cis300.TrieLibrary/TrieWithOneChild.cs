using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        private bool _hasEmptyString;

        private ITrie _onlyChild;

        private char _label;

        public TrieWithOneChild (string s, bool emptystring)
        {
            if (s == "" || s[0] > 'z' || s[0] < 'a')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = emptystring;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));

        }
        public ITrie Add(string s)
        {
            if (s == "")
            {
               _hasEmptyString = true;
            }
            else if(s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _onlyChild);
            }
            return this;
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmptyString;
            }
            else if(s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
