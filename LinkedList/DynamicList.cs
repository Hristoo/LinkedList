using System.Drawing;

namespace LinkedList
{
    public class DynamicList
    {
        private class Node
        {
            private object element;
            private Node next;
            private Node prev;

            public object Element
            {
                get { return element; }
                set { element = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node Prev
            {
                get { return prev; }
                set { prev = value; }
            }

            public Node(object element, Node prevNode, Node nextNode)
            {
                this.element = element;
                prevNode.next = this;
                nextNode.prev = this;
            }
            public Node(object element)
            {
                this.element = element;
                next = null;
                prev = null;
            }
        }
        private Node head;
        private Node tail;
        private int count;
        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public void Add(object item, int position)
        {
            var node = new Node(item);

            if (head == null)
            {
                head = new Node(item);
                tail = head;
            }
            else if (position == 0)
            {
                node.Next = head;
                node.Prev = null;
                head.Prev = node;
                head = node;
            }
            else if (position >= count)
            {   

                node.Next = null;
                tail.Next = node;
                node.Prev = tail;
                tail = node;

            }
            else
            {
                Node tempNode = head;
                int index = 0;
                Node nextNode = null;
                while (index < position - 1)
                {
                    tempNode = tempNode.Next;
                    index++;
                }

                node.Next = tempNode.Next;
                node.Prev = tempNode;
                nextNode = tempNode.Next;
                nextNode.Prev = node;
                tempNode.Next = node;
                head = tempNode;
                

                //node.Next = tempNode.Next;
                //node.Prev = tempNode;
                //tempNode.Next = node;
                //node.Next = 
                //node.getNext().setPrev(node);
            }
            count++;
        }

        public object Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                      "Invalid index: " + index);
            }

            int currentIndex = 0;
            Node currentNode = head;
            Node prevNode = null;
            Node nextNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode.Prev;
                nextNode = currentNode.Next;
                currentIndex++;
            }
            count--;

            if (count == 0)
            {
                head = null;
            }
            else if (prevNode == null)
            {
                nextNode = currentNode.Next;
                nextNode.Prev = currentNode.Prev;
                head = currentNode.Next;
            }
            else if(nextNode == null)
            {
                prevNode.Next = null;
            }
            else
            {
                prevNode.Next = currentNode.Next;
                nextNode = currentNode.Next;
                nextNode.Prev = currentNode.Prev;
            }

            Node lastElement = null;

            if (this.head != null)
            {
                lastElement = this.head;

                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }
            tail = lastElement;

            return currentNode.Element;
        }

        public int Remove(object item)
        {
            int currentIndex = 0;
            Node currentNode = head;
            Node prevNode = null;
            Node nextNode = null;

            while (currentNode != null)
            {
                if ((currentNode.Element != null &&
                       currentNode.Element.Equals(item)) ||
                      (currentNode.Element == null) && (item == null))
                {
                    break;
                }

                prevNode = currentNode;
                nextNode = currentNode.Next;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                count--;

                if (count == 0)
                {
                    head = null;
                }
                else if (prevNode == null)
                {
                    nextNode = currentNode.Next;
                    nextNode.Prev = currentNode.Prev;
                    head = currentNode.Next;
                }
                else if (nextNode == null)
                {
                    prevNode.Next = null;
                }
                else
                {
                    prevNode.Next = currentNode.Next;
                    nextNode = currentNode.Next;
                    nextNode.Prev = currentNode.Prev;
                }

                Node lastElement = null;

                if (this.head != null)
                {
                    lastElement = this.head;

                    while (lastElement.Next != null)
                    {
                        lastElement = lastElement.Next;
                    }
                }

                tail = lastElement;

                return currentIndex;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(object item)
        {
            int index = 0;
            Node current = head;

            while (current != null)
            {
                if ((current.Element != null &&
                       current.Element == item) ||
                      (current.Element == null) && (item == null))
                {
                    return index;
                }
                current = current.Next;
                index++;

            }
            return -1;
        }

        public bool Contains(object item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);

            return found;
        }

        public object this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                          "Invalid index: " + index);
                }

                Node currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Element;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                          "Invalid index: " + index);
                }

                Node currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Element = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

        }
    }
}
