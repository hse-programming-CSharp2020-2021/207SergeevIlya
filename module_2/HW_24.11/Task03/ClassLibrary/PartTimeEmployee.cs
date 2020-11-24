using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для описания внештаных сотрудников. 
    /// </summary>
    public class PartTimeEmployee : Employee
    {
        /// <summary>
        /// Кол-во рабочих дней.
        /// </summary>
        public int workingDays { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name"> 
        /// Имя сотрудника.
        /// </param>
        /// <param name="basepay">
        /// Оплата за 25 дней работы.
        /// </param>
        /// <param name="days">
        /// Кол-во рабочих дней.
        /// </param>
        public PartTimeEmployee(string name, decimal basepay, int days) : base(name, basepay)
        {
            workingDays = days;
        }

        /// <summary>
        /// Метод для вычисления заработной платы.
        /// </summary>
        /// <returns></returns>
        public override decimal CalculatePay()
        {
            return basepay * workingDays / 25;
        }
    }
}
