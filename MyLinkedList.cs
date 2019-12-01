class MyLinkedList<T>
    {
        private Node head;
        private Node tail;

        class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Item = item;
                this.Next = null;
            }
        }

        public void AddToHead(T item)
        {
            Node newNode = new Node(item);

            if (head is null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        public void AddToTail(T item)
        {
            Node newNode = new Node(item);

            if (head is null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Delete(T item)
        {
            if (head is null)
                return;
            if (head.Item.Equals(item))
            {
                head = head.Next;
                return;
            }

            for (Node node = head; node.Next != null; node = node.Next)
            {
                if (node.Next.Item.Equals(item))
                {
                    node.Next = node.Next.Next;
                    break;
                }
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public void Traverse(Action<T> action)
        {
            for (Node node = head; node != null; node = node.Next)
            {
                action(node.Item);
            }
        }
    }
