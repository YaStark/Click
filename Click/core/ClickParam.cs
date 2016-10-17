using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Click.core {
    /// <summary>
    /// Параметры приложения
    /// </summary>
    [Serializable]
    public class ClickParam {
        
        /// <summary>
        /// Комбинация клавиш для запуска
        /// </summary>
        public Keys KeyStart { get; set; }

        /// <summary>
        /// Комбинация клавиш для остановки
        /// </summary>
        public Keys KeyStop { get; set; }

        /// <summary>
        /// Комбинация клавиш для выхода
        /// </summary>
        public Keys KeyExit { get; set; }

        /// <summary>
        /// Выбранный период
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Список последних периодов
        /// </summary>
        public List<int> PeriodList { get; set; }
            
    }
}
