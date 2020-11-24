using System;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для описания работника.
    /// </summary>
    public class Employee : IComparable <Employee>
    {
        public int CompateTo (Employee Other)
        {
            if (CalculatePay() == Other.CalculatePay())
                return 0;
            else if (CalculatePay() < Other.CalculatePay())
                return -1;
            else
                return 1;
        }

        public string name;
        protected decimal basepay;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Employee(string name, decimal basepay)
        {
            this.name = name;
            this.basepay = basepay;
        }

        /// <summary>
        /// Метод для получения значения зарплаты.
        /// </summary>
        public virtual decimal CalculatePay()
        {
            return basepay;
        }

        public int CompareTo(Employee other)
        {
            throw new NotImplementedException();
        }
    }

}
