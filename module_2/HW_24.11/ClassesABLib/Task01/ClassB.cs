using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Класс B.
    /// </summary>
    public class B : ClassParent
    {
        /// <summary>
        /// Добавил от себя поле Count, обозначающее кол-во созданных экземпляров класса.
        /// </summary>
        static public int Count = 0;

        public B()
        {
            Id = Count;
            Count++;
        }

        /// <summary>
        /// Возвращает букву, которой соответствует id экземпляра класса.
        /// </summary>
        public override string getA()
        {
            return ""+((char)('A' + (Id % 26)));
        }
    }
}
