using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab9
{
    class MonkeyMatrix
    {
        /// <summary>
        /// Список с парами
        /// </summary>
        protected MyList elements;
        /// <summary>
        /// Пара, хранящая размерность
        /// </summary>
        protected DigitPairs<int> dimension;
        /// <summary>
        /// Пара разделитель: первое число - просто -1, второе - текущая строка
        /// </summary>
        protected DigitPairs<int> publicElement;
        /// <summary>
        /// Устанавливает размерность матрицы
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        
        
        
        protected virtual void SetDimension(int first, int second)
        {
            dimension = new DigitPairs<int>(first, second);
        }
        /// <summary>
        /// Вернет пару чисел - размернсть
        /// </summary>
        /// <returns></returns>
        public virtual DigitPairs<int> GetDimension()
        {
            return dimension;
        }

        protected virtual void SetPublicElemet(int publicElement)
        {
            this.publicElement.FirstDigit = -1;
            this.publicElement.SecondDigit = publicElement;
        }
        public virtual int GetPublicElement()
        {
            return publicElement.SecondDigit;
        }

        public MonkeyMatrix(Matrix<int> matrix, int publicElement)
        {
            Create(ref matrix, publicElement);            
        }
        /// <summary>
        /// Создать матрицу, уплотненную методом пар, из обычной матрицы
        /// </summary>
        /// <param name="matrix"></param>
        public void Create(ref Matrix<int> matrix, int publicElement)
        {
            int rows = matrix.Rows;
            int cols = matrix.Cols;
            SetDimension(rows, cols);
            SetPublicElemet(publicElement);
            for (int i = 0; i < rows; i++)
            {
                // добавляем строку
                elements.Add(new DigitPairs<int>(-1, i));
                for (int j = 0; j < cols; j++)
                {

                    if (matrix.GetElem(i, j) != GetPublicElement())
                    {
                        // добавляем столбец
                        elements.Add(new DigitPairs<int>(j, matrix.GetElem(i, j)));
                    }
                }
            }
        }
        public virtual void Clear()
        {
            dimension = null;
            publicElement = null;
            elements.Clear();
        }
        // Проверить его
        public bool FindElement(int yourRow, int yourCol, out int toReturn)
        {
            MyList.Node node = elements.FindNodeWithRow(yourRow);
            MyList.Node node1 = elements.FindFromCurrentNode(node, yourCol);
            if (node1 != null)
            {
                if (node1.Data.FirstDigit != -1)
                {
                    toReturn = node1.Data.SecondDigit;
                    return true;
                }
                else
                {
                    toReturn = node1.Data.SecondDigit;
                    return false;
                }
            }
            else
            {
                toReturn = 0;
                return false;
            }
        }
    }
}
