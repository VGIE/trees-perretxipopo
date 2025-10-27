namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Previous = null;


    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;

    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        
        if(index < 0 || index >= Count())
        {
            return default(T);
        }
            
        ListNode<T> node = First;
        int i= 0;
        while(i < index)
        {
            node = node.Next;
            i++;
        }
        
        return node.Value;
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> node = new ListNode<T>(value);
        if (First == null)
        {
            First = node;
        }
        else
        {
            Last.Next = node;
            node.Previous = Last;
        }
        Last = node;
        
        m_numItems++;
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds

        //si estamos fuera de los rangos
            if(index < 0 || index >= Count())
            {
                return default(T);
            }

        //Si el elemento a eliminar es el primero
        if (index == 0)
        {
            T value1 = First.Value;
            First = First.Next;
            if (First != null)
            {
                First.Previous = null;
            }
            else
            {
                Last = null;
            }
            m_numItems--;
            return value1;

        }
        //Si el elemento a eliminar es el último
        if (index == Count() - 1)
        {
            T value2 = Last.Value;
            Last = Last.Previous;
            if (Last != null)
            {
                Last.Next = null;
            }
            else
            {
                First = null;
            }
            m_numItems--;
            return value2;
        }
        //Si el elemento a eliminar está en medio
        ListNode<T> node = First;
        int i = 0;
        while (i < index)
        {
            node = node.Next;
            i++;
        }
        T value = node.Value; //guerdamos el valor de lo que queremos eliminar para devolverlo al final
        node.Previous.Next = node.Next; //hacemos que le nodo anterior sea el siguiente del nodo actual
        node.Next.Previous = node.Previous; //hacemos que el nodo siguiente sea el anterior del nodo actual
        m_numItems--;
        return value;
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        Last = null;
        m_numItems = 0;
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        ListNode<T> node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }   
        
    }
}