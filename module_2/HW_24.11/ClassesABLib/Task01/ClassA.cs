using System;

namespace Task01
{
    /// <summary>
    /// Класс A.
    /// </summary>
    public class A : ClassParent
    {
        /// <summary>
        /// Добавил от себя поле Count, обозначающее кол-во созданных экземпляров класса.
        /// Именно Count и будет выводиться в getA.
        /// </summary>
        static public int Count = 0; 

        public A ()
        {
            Id = Count;
            Count++;
        }
    }
}
