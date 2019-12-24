using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab9
{
    class MyList 
    {
        public class Node
        {
            public DigitPairs<int> Data { get; set; }
            public Node NextNode { get; set; }
            public Node()
            {
                NextNode = null;
                Data = null;
            }
            public Node(DigitPairs<int> data)
            {
                NextNode = null;
                Data = data;
            }
            public Node DeleteNode(Node toDelete)
            {
                if (toDelete != null)
                    toDelete = DeleteNode(toDelete.NextNode);
                return toDelete;                    
            }
        }
        private Node head;
        private int size;

        public MyList()
        {
            size = 0;
            head = null;
        }
        /// <summary>
        /// Добавляет в конец
        /// </summary>
        /// <param name="data"></param>
        public void Add(DigitPairs<int> data)
        {
            if (head == null)
                head = new Node(data);
            Node currentNode = head;
            while (currentNode.NextNode != null)
                currentNode = currentNode.NextNode;
            currentNode.NextNode = new Node(data);
            size++;
        }

        public void Clear()
        {
            head = head.DeleteNode(head);
            size = 0;
        }
        /// <summary>
        /// Вернет узел, содержащий пару с нужным элементом или служебную пару (проверяй сам)
        /// если передать туда null, то поиск начнется с head. Вернет null, если следущей служебной пары не встретил и 
        /// список закончился.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public Node FindFromCurrentNode(Node currentNode, int col)
        {
            if (currentNode == null)
                currentNode = head;
            if (currentNode != null)
            {
                while (currentNode.Data.FirstDigit != -1)
                {
                    if (currentNode.Data.FirstDigit == col)
                        break;
                    currentNode = currentNode.NextNode;
                    if (currentNode == null)
                        break;
                }
            }
            return currentNode;
        }
        /// <summary>
        /// Находит узел с заданной строкой. Вернет null, если не найдет, иначе вернет тот узел.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Node FindNodeWithRow(int row)
        {
            if (head == null)
                return null;
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data.FirstDigit == -1)
                    if (currentNode.Data.SecondDigit == row)
                        break;
                currentNode = currentNode.NextNode;
            }
            return currentNode;
        }
    }
}
