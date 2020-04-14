using System;

namespace Datastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AVLTree<int> avlTree = new AVLTree<int>();
            for (var i = 0; i < 10; ++i)
            {
                avlTree.Insert(i);
            }
            avlTree.Print();
            avlTree.Remove(7);
            avlTree.Print();
            avlTree.Remove(5);
            avlTree.Print();
            avlTree.Remove(1);
            avlTree.Print();
        }
    }
}
