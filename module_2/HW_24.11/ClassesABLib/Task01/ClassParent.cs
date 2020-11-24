using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Родительский класс для A и B.
    /// Содержит виртуальный метод getA.
    /// </summary>
    public class ClassParent
    {
        /// <summary>
        /// Id экземпляра класса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Виртуальный метод getA.
        /// </summary>
        public virtual string getA ()
        {
            return Id.ToString();
        }
    }
}
