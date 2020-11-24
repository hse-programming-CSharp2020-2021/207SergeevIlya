using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для описания продавца.
    /// </summary>
    public class SalesEmployee : Employee 
    {
        /// <summary>
        /// Надбавки.
        /// </summary>
        private decimal salesbonus;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public SalesEmployee(string name, decimal basepay,
                  decimal salesbonus) : base(name, basepay)
        {
            this.salesbonus = salesbonus;
        }

        /// <summary>
        /// Метод для получения значения заплаты.
        /// </summary>
        public override decimal CalculatePay()
        {
            return basepay + salesbonus;
        }
    }
}
