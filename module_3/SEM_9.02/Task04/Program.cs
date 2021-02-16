using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                Node current = head,
                     res = null;

                if (head != null)
                {
                    res = head;

                    while (current != null)
                    {
                        if (current.Data > res.Data)
                            res = current;

                        current = current.Next;
                    }
                }

                return res;
            }

            public Node Min()
            {
                Node current = head,
                     res = null;

                if (head != null)
                {
                    res = head;

                    while (current != null)
                    {
                        if (current.Data < res.Data)
                            res = current;

                        current = current.Next;
                    }
                }

                return res;
            }

            public Node Middle()
            {
                // 1 2 3 4 5 6 7 -> 4
                // 1 2 3 4 5 6 -> 4

                if (head != null)
                {
                    Node current = head;
                    int prev = 0;

                    while (current != null)
                    {
                        if (prev == Count / 2)
                        {
                            return current;
                        }

                        prev++;
                        current = current.Next;
                    }
                }

                return null;
            }

            public bool Remove(int data)
            {
                // 1 2 3 4 5 6 7 8 5, 5 -> 1 2 3 4 6 7 8 5
                // если список пуст, если список из 1 элемента, если удаляемый элемент стоит в середине, в конце, в начале

                Node current = head,
                     prev = null;

                if (head != null)
                {
                    while (current != null)
                    {
                        if (current.Data == data)
                        {
                            if (prev != null && current.Next != null)
                            {
                                prev.Next = current.Next;
                            }

                            return true;
                        }

                        prev = current;
                        current = current.Next;
                    }
                }
                return false;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();

            }
        }
    }
}