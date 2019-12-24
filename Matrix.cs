using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgLab9
{
    class Matrix<T>
    {
        /// <summary>
        /// число строк в матрице
        /// </summary>
        protected int rows;
        /// <summary>
        /// Вернет или установит число строк в матрице
        /// </summary>
        public virtual int Rows
        {
            get
            {
                return rows;
            }
            protected set
            {
                if (value < 1)
                    rows = 1;
                else
                    rows = value;
            }
        }
        /// <summary>
        /// число столбцов в матрице
        /// </summary>
        protected int cols;
        /// <summary>
        /// Вернет или установит число столбцов в матрице
        /// </summary>
        public virtual int Cols
        {
            get
            {
                return cols;
            }
            protected set
            {
                if (value < 1)
                    cols = 1;
                else
                    cols = value;
            }
        }
        /// <summary>
        /// Сама матрица
        /// </summary>
        protected T[][] matrix;
        /// <summary>
        /// Вернет значение по заданным координатам
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="col">столбец</param>
        /// <returns></returns>
        public virtual T GetElem(int row, int col)
        {
            if (row >= rows || row < 0)
                throw new IndexOutOfRangeException("Выход за пределы матрицы по строкам");
            else if (col >= cols || col < 0)
                throw new IndexOutOfRangeException("Выход за пределы матрицы по столбцам");
            return matrix[row][col];
        }
        /// <summary>
        /// Установит значение по заданным координатам
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="col">столбец</param>
        /// <param name="data">данные</param>
        public virtual void SetElem(int row, int col, T data)
        {
            if (row >= rows || row < 0)
                throw new IndexOutOfRangeException("Выход за пределы матрицы по строкам");
            else if (col >= cols || col < 0)
                throw new IndexOutOfRangeException("Выход за пределы матрицы по столбцам");
            matrix[row][col] = data;
        }
        public Matrix(int row, int col)
        {
            Rows = row;
            Cols = col;
            matrix = new T[Rows][];
            for (int i = 0; i < Rows; i++)
                matrix[i] = new T[Cols];
        }

        public virtual void Create()
        {

        }

        public Matrix()
        {
            rows = 1;
            cols = 1;
            matrix = new T[Rows][];
            for (int i = 0; i < Rows; i++)
                matrix[i] = new T[Cols];
        }
    }
}
