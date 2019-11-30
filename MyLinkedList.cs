class MyLinkedList<T>
    {
        private Node head;

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
            if (head is null)
            {
                head = new Node(item);
            }
            else
            {
                Node node = new Node(item);

                node.Next = head;
                head = node;
            }
        }

        public void AddToTail(T item)
        {
            if (head is null)
            {
                head = new Node(item);
            }
            else
            {
                Node node = head;

                for ( ; node.Next != null; node = node.Next)
                    ;

                Node toAdd = new Node(item);
                node.Next = toAdd;
                toAdd.Next = null;
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
        }

        public void Traverse()
        {
            for (Node node = head; node != null; node = node.Next)
            {
                Console.Write($"{node.Item} => ");
            }

            Console.Write("NULL");
        }
    }
