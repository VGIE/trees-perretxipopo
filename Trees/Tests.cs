
using System;
namespace Trees
{
    public static class Tests
    {
        public static bool TestGenericTree(Action<string> onProgress, Action<string> onError)
        {
            Tree<int> tree = new Tree<int>();

            tree.RootNode = new TreeNode<int>(1);

            onProgress("Testing Add()...");

            TreeNode<int> child1 = tree.RootNode.Add(2);
            if (child1 == null)
            {
                onError("Error. Add() returned null. It should return the node that was added to the tree");
                return false;
            }
            TreeNode<int> child2 = tree.RootNode.Add(3);
            TreeNode<int> child11 = child1.Add(4);
            TreeNode<int> child12 = child1.Add(5);
            TreeNode<int> child13 = child1.Add(6);
            TreeNode<int> child21 = child2.Add(7);
            TreeNode<int> child22 = child2.Add(8);
            child11.Add(9);
            child12.Add(10);
            child12.Add(11);
            child13.Add(12);
            child21.Add(13);
            child22.Add(14);
            child22.Add(15);

            string asString = tree.ToString();
            if (asString == null)
            {
                onError("Error. ToString() returned null. Did you forget to uncomment ToString()?");
                return false;
            }

            for (int i = 1; i < 16; i++)
            {
                if (!asString.Contains($"[{i}]"))
                {
                    onError($"Error. Value {i} wasn't added to the tree:");
                    return false;
                }
            }
            onProgress("Ok");

            onProgress("Testing Count()...");
            int count = tree.RootNode.Count();
            if (count != 15)
            {
                onError($"Error. Count() returned {count} instead of 15");
                return false;
            }

            onProgress("Ok");

            onProgress("Testing Height()...");
            int height = tree.RootNode.Height();
            if (height != 3)
            {
                onError($"Error. Height() returned {height} instead of 3");
                return false;
            }

            onProgress("Ok");

            onProgress("Testing Remove()...");
            tree.RootNode.Remove(15);
            count = tree.RootNode.Count();
            if (count != 14)
            {
                onError($"Error. Count() returned {count} instead of 14 after Remove(15)");
                return false;
            }
            tree.RootNode.Remove(3);
            count = tree.RootNode.Count();
            if (count != 9)
            {
                onError($"Error. Count() returned {count} instead of 9 after Remove(3)");
                return false;
            }

            TreeNode<int> found = tree.RootNode.Find(12);
            if (found == null)
            {
                onError($"Error. Find(12) returned null");
                return false;
            }
            found = tree.RootNode.Find(9);
            if (found == null)
            {
                onError($"Error. Find(9) returned null");
                return false;
            }
            found = tree.RootNode.Find(1);
            if (found == null)
            {
                onError($"Error. Find(1) returned null");
                return false;
            }

            found = tree.RootNode.Find(12);
            tree.RootNode.Remove(found);
            found = tree.RootNode.Find(12);
            if (found != null)
            {
                onError($"Error. Remove(TreeNode<T>) failed to delete item with value 12");
                return false;
            }

            found = tree.RootNode.Find(9);
            tree.RootNode.Remove(found);
            found = tree.RootNode.Find(9);
            if (found != null)
            {
                onError($"Error. Remove(TreeNode<T>) failed to delete item with value 9");
                return false;
            }

            onProgress("Ok");

            return true;
        }
    }
}