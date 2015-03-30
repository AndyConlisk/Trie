using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class Tries
    {
        private readonly TrieNode root = new TrieNode();
        public TrieNode Insert(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            foreach (char c in charArray)
            {
                node = Insert(c, node);
            }
            node.isEnd = true;
            return root;
        }
        private TrieNode Insert(char c, TrieNode node)
        {
            if (node.Contains(c)) return node.GetChild(c);
            else
            {
                int n = Convert.ToByte(c) - TrieNode.ASCIIA;
                TrieNode t = new TrieNode();
                node.nodes[n] = t;
                return t;
            }
        }
        public bool Contains(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            bool contains = true;
            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    contains = false;
                    break;
                }
            }
            if ((node == null) || (!node.isEnd))
                contains = false;
            return contains;
        }
        private TrieNode Contains(char c, TrieNode node)
        {
            if (node.Contains(c))
            {
                return node.GetChild(c);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Search the trie for word
        /// </summary>
        /// <param name="word">the word to search for</param>
        /// <returns>TrieResultEnum if full, partial, or no match</returns>
        public TrieResultEnum Search(string word)
        {
            char[] charArray = word.ToLower().ToCharArray();
            TrieNode node = root;
            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    return TrieResultEnum.NoMatch;
                }
            }

            if (node != null && node.isEnd)
                return TrieResultEnum.FullMatch;
            else if (node == null || !node.isEnd)
                return TrieResultEnum.PartialMatch;
            else
                return TrieResultEnum.NoMatch;
        }
    }
}
