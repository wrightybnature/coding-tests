// Doubly Linked List practice
// NOTE: this list only works for integers but this can be changed by amending the data type passed to Node on line 13

using System;

class Node
{
    public int Data; // data stored in the node
    public Node Previous; // pointer to the previous node
    public Node Next; // pointer to the next node

    // data contructors
    public Node(int data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}

class DoublyLinkedList
{
    private Node head;

    public DoublyLinkedList()
    {
        head = null;
    }

    // creates and populates the list
    public void CreateList()
    {
        Console.Write("Number of nodes to create: ");
        int n = int.Parse(Console.ReadLine()); // reading number of nodes from user's input

        if (n == 0)
        {
            return; // exit if no input/input is 0
        }

        // creating the head node
        Console.Write("Enter the element for node 1: ");
        int data = int.Parse(Console.ReadLine()); // proceses user input 
        head = AddToEmpty(data); // adds it to head node's data

        // creating additional normal nodes and adding them to the list
        for (int i = 1; i < n; i++)
        {
            Console.Write($"Enter the element for node {i + 1}: ");
            data = int.Parse(Console.ReadLine());
            AddAtEnd(data);
        }
    }

    // adding the first node in an empty list
    private Node AddToEmpty(int data)
    {
        Node newNode = new Node(data); // initialising first node obj, which is the head node
        head = newNode;
        return head;
    }

    // adding a node at the end of the list
    private void AddAtEnd(int data)
    {
        Node newNode = new Node(data); // initialise new node obj

        // check if the list is empty
        if (head == null)
        {
            head = newNode; // if it's empty (no more nodes after head) then we just return the head node
            return;
        }

        Node temp = head; // if it's not empty then we make head the first temp node
        while (temp.Next != null) // continue until there are no more next nodes (go to the end)
        {
            temp = temp.Next; // temp becomes the next node, so that we iterate to the end of the node list
        }

        // linking the new node at the end with next and previous pointers
        temp.Next = newNode;
        newNode.Previous = temp;
    }

    // display the list
    public void DisplayList()
    {
        Node temp = head;
        while (temp != null) // going through each node and dispalying the data in it using temp to store the data in the current node 
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }
}

// instatiate a new doubly linked list
DoublyLinkedList list = new DoublyLinkedList();
list.CreateList(); // create/populate it
Console.WriteLine("Elements in the list:"); // display the list back to the user
list.DisplayList();