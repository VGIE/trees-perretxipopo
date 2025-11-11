
using System;
namespace BinaryTrees
{
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;
        public BinaryTreeNode<TKey, TValue> LeftChild;
        public BinaryTreeNode<TKey, TValue> RightChild;

        public BinaryTreeNode(TKey key, TValue value)
        {
            //TODO #1: Initialize member variables/attributes
            Key = key;
            Value = value;
            
        }

        public string ToString(int depth)
        {
            string output = null;

            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            if (Value != null)
                output += $"{leftSpace}[{Key.ToString()}-{Value.ToString()}]\n";

            if (LeftChild != null)
                output += $"{LeftChild?.ToString(depth + 1)}";

            if (RightChild != null)
                output += $"{RightChild?.ToString(depth + 1)}";

            return output;
        }

        public void Add(BinaryTreeNode<TKey, TValue> node)
        {
            //TODO #2: Add the new node following the order:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the new node should be on this node's left.
            //              a) If the left child is null, the added node should be this node's left node side
            //              b) Else, we should ask the LeftChild to add it recursively
            //          -If the current node has a lower key that the new node (use CompareTo()), the new node should be on this node's right side.
            //          -If the current node and the new node have the same key, just update this node's value with the new node's value

            int comparar = this.Key.CompareTo(node.Key);
            if (comparar > 0)
            {
                //el nuevo nodo debe ir a la izquierda
                if (LeftChild == null)
                {
                    LeftChild = node;
                }
                else
                {
                    this.LeftChild.Add(node);
                }
            }
            if (comparar < 0)
            {
                //el nuevo nodo debe ir a la derecha
                if (RightChild == null)
                {
                    RightChild = node;
                }
                else
                {
                    RightChild.Add(node);
                }
            }
            else
            {
                //las claves son iguales, actualizamos el valor
                Value = node.Value;
            }
            
        }

        public int Count()
        {
            //TODO #3: Return the total number of elements in this tree
            
            int numElements = 1; // empieza en 1 porque un árbol ya contiene al menos un nodo
            if (LeftChild != null)
            {
                numElements += LeftChild.Count();
            }
            if (RightChild != null)
            {
                numElements += RightChild.Count();
            }
            return numElements;
            
        }

        public int Height()
        {
            //TODO #4: Return the height of this tree

            int alturaIzquierda = 0;
            int alturaDerecha = 0;
            //si no hay un nodo, la altura es -1
            if (this == null)
            {
                return -1;
            }
            //si no tiene hijos, la altura es 0
            if (LeftChild == null && RightChild == null)
            {
                return 0;
            }
            //Si tiene hijos, calculamos la altura de cada uno y devolvemos la mayor + 1
            if (LeftChild != null)
            {
                alturaIzquierda = LeftChild.Height();
            }
            if (RightChild != null)
            {
                alturaDerecha = RightChild.Height();
            }
            return 1 + Math.Max(alturaIzquierda, alturaDerecha);
            
        }

        public TValue Get(TKey key)
        {
            //TODO #5: Find the node that has this key:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the key we are searching for should be on this node's left side.
            //              a) If the left child is null, return null. We haven't found it
            //              b) Else, we should ask the LeftChild to find the node recursively. It must be below LeftChild
            //          -If the current node has a lower key that the new node (use CompareTo()), the key should be on this node's right side.
            //          -If the current node and the new node have the same key, just return this node's value. We found it

            int comparar = this.Key.CompareTo(key);
            if (comparar > 0)
            {
                //la clave que buscamos está a la izquierda
                if (LeftChild == null)
                {
                    return default;
                }
                else
                {
                    return LeftChild.Get(key);
                }
            }
            if (comparar < 0)
            {
                //la clave que buscamos está a la derecha
                if (RightChild == null)
                {
                    return default;
                }
                else
                {
                    return RightChild.Get(key);
                }
            }
            else
            {
                //las claves son iguales, devolvemos el valor
                return Value;
            }
            
        }

        

        public BinaryTreeNode<TKey, TValue> Remove(TKey key)
        {
            //TODO #6: Remove the node that has this key. The parent may need to update one of its children,
            //so this method returns the node with which this node needs to be replaced. If this node isn't the
            //one we are looking for, we will return this, so that the parent node can replace LeftChild/RightChild
            //with the same node it had.

            //si la clave que queremos eliminar es menos que mi clave
            if (this.Key.CompareTo(key) > 0)
            {
                //la clave que buscamos está a la izquierda
                if (this.LeftChild != null)
                {
                    //lo que devuelva el hijo pasa a ser mi hijo izquierdo
                    this.LeftChild = this.LeftChild.Remove(key);
                }
                return this;
            }
            //si la clave que queremos eliminar es mayor que mi clave
            if (this.Key.CompareTo(key) < 0)
            {
                //la clave que buscamos está a la derecha
                if (this.RightChild != null)
                {
                    //lo que devuelva el hijo pasa a ser mi hijo derecho
                    this.RightChild = this.RightChild.Remove(key);
                }
                return this;
            }
            //else
            
            //las claves son iguales, este es el nodo a eliminar
            //caso 1: nodo sin hijos
            if (this.LeftChild == null && this.RightChild == null)
            {
                return null;
            }
            //caso 2: nodo con un hijo
            //si no tiene hijo izquierdo
            if (this.LeftChild == null)
            {
                return this.RightChild;
            }
            //si no tiene hijo derecho
            if (this.RightChild == null)
            {
                return this.LeftChild;
            }
            //caso 3: nodo con dos hijos
            //guardamos subarboles
            BinaryTreeNode<TKey, TValue> subarbolIzquierdo = this.LeftChild;
            BinaryTreeNode<TKey, TValue> subarbolDerecho = this.RightChild;
            //le asignamos al subarbol izquierdo el subarbol derecho como hijo derecho
            subarbolIzquierdo.Add(subarbolDerecho);
            return subarbolIzquierdo;
            
            
        }

        public int KeysToArray(TKey[] keys, int index)
        {
            if (LeftChild != null)
                index = LeftChild.KeysToArray(keys, index);
            keys[index] = Key;
            index++;
            if (RightChild != null)
                index = RightChild.KeysToArray(keys, index);
            return index;
        }

        public int ValuesToArray(TValue[] values, int index)
        {
            if (LeftChild != null)
                index = LeftChild.ValuesToArray(values, index);
            values[index] = Value;
            index++;
            if (RightChild != null)
                index = RightChild.ValuesToArray(values, index);
            return index;
        }
    }
}