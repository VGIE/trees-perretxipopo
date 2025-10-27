
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        List<TreeNode<T>> Children = null;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>>();
            
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;

        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class TreeNode<T> with Value=value. Return the instance we just created

            TreeNode<T> newNode = new TreeNode<T>(value);
            Children.Add(newNode);
            return newNode;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree

            int numElements = 1; // Si hay un árbol, siempre habra al menos un nodo (la raiz)
            for (int i = 0; i < Children.Count(); i++)
            {
                numElements += Children.Get(i).Count();
            }
            return numElements;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            //Si es un nodo sin hijos(leaf), la altura es 1
            if (Children.Count() == 0)
            {
                return 1;
            }
            else
            {
                int alturaMaximaHijo = 0;
                for (int i = 0; i < Children.Count(); i++)
                {
                    int alturaHijo = Children.Get(i).Height();
                    if (alturaHijo > alturaMaximaHijo)
                    {
                        alturaMaximaHijo = alturaHijo;
                    }
                }
                return 1 + alturaMaximaHijo;
            }
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively

            for (int i = 0; i < Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                //Si el hijo actual tiene el valor que queremos eliminar
                if (child.Value.Equals(value))
                {
                    //lo removemos de la lista de hijos
                    Children.Remove(i);
                    return;
                }
                else
                {
                    // Si no coincide, buscamos recursivamente dentro de ese hijo, para quitar todos los hijos de ese hijo
                    child.Remove(value);
                }
            }
            
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            
        }
    }
}