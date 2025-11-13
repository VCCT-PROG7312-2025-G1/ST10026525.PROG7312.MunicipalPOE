using System;
using System.Collections.Generic;

namespace ST10026525.PROG7312.MunicipalPOE.DataStructures
{
    // Basic node structure for the BST
    public class BSTNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public BSTNode<TKey, TValue> Left { get; set; }
        public BSTNode<TKey, TValue> Right { get; set; }

        public BSTNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // Simple Binary Search Tree that can store any comparable key-value pair
    public class BSTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private BSTNode<TKey, TValue> _root;

        // Insert a key-value pair into the tree
        public void Insert(TKey key, TValue value)
        {
            _root = InsertRec(_root, key, value);
        }

        private BSTNode<TKey, TValue> InsertRec(BSTNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
                return new BSTNode<TKey, TValue>(key, value);

            int compare = key.CompareTo(node.Key);

            if (compare < 0)
                node.Left = InsertRec(node.Left, key, value);
            else if (compare > 0)
                node.Right = InsertRec(node.Right, key, value);
            else
                node.Value = value; // Overwrite if key exists

            return node;
        }

        // Search by key
        public TValue Search(TKey key)
        {
            var node = _root;
            while (node != null)
            {
                int compare = key.CompareTo(node.Key);
                if (compare == 0)
                    return node.Value;
                node = compare < 0 ? node.Left : node.Right;
            }
            return default;
        }

        // Traverse the tree in order (sorted)
        public List<TValue> InOrderTraversal()
        {
            var list = new List<TValue>();
            InOrderRec(_root, list);
            return list;
        }

        private void InOrderRec(BSTNode<TKey, TValue> node, List<TValue> list)
        {
            if (node == null) return;
            InOrderRec(node.Left, list);
            list.Add(node.Value);
            InOrderRec(node.Right, list);
        }
    }
}
