using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Click.core {
    /// <summary>
    /// Модуль, отвечающий за работу с реестром
    /// </summary>
    public static class RegistryModule {

        #region Константы

        /// <summary>
        /// Корневая папка реестра
        /// </summary>
        const string SOFTWARE_NODE = "Software";

        /// <summary>
        /// Название компании
        /// </summary>
        const string COMPANY_NAME = "Starrk";

        /// <summary>
        /// Название приложения
        /// </summary>
        const string SOFT_NAME = "Click!NET";

        /// <summary>
        /// Параметр "Клавиши запуска"
        /// </summary>
        const string PARAM_NAME = "ClickParam";

        #endregion

        /// <summary>
        /// Возвращает директорию приложения в реестре, или null и сообщение об ошибке
        /// </summary>
        private static RegistryKey getSoftDir (ref string errMsg) {
            try {
                var key = Registry.CurrentUser.OpenSubKey (SOFTWARE_NODE, true);
                if (key != null) {
                    var companyDir = key.OpenSubKey (COMPANY_NAME, true);
                    if (companyDir == null) {
                        companyDir = key.CreateSubKey (COMPANY_NAME);
                        if (companyDir == null) {
                            errMsg = "Не удалось создать ветку реестра";
                            return null;
                        }
                    }
                    var softDir = companyDir.OpenSubKey (SOFT_NAME, true);
                    if (softDir == null) {
                        softDir = companyDir.CreateSubKey (SOFT_NAME);
                        if (softDir == null) {
                            errMsg = "Не удалось создать ветку реестра";
                            return null;
                        }
                    }
                    return softDir;
                } else {
                    errMsg = "Не удалось получить доступ к корневой ветке реестра.";
                    return null;
                }
            } catch (Exception ex) {
                errMsg = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Попытка чтения параметров из реестра
        /// </summary>
        public static ClickParam tryRead (ref string errMsg) {
            var softDir =  getSoftDir (ref errMsg);
            if (softDir == null) {
                return null;
            }
            try {
                var data = softDir.GetValue (PARAM_NAME);
                if (data == null) {
                    return null;
                } else {
                    var formatter = new BinaryFormatter ();
                    var dataStream = new MemoryStream ((byte[])data);
                    return (ClickParam)formatter.Deserialize (dataStream);
                }
            } catch (Exception ex) {
                errMsg = ex.Message;
                return null;
            } finally {
                softDir.Close ();               
            }
        }

        /// <summary>
        /// Попытка записи параметов в реестр
        /// </summary>
        public static bool tryWrite (ref string errMsg, ClickParam clickParam) {
            var softDir =  getSoftDir (ref errMsg);
            if (softDir == null) {
                return false;
            }
            try {
                var formatter = new BinaryFormatter ();
                var dataStream = new MemoryStream ();
                formatter.Serialize(dataStream, clickParam);
                softDir.SetValue (PARAM_NAME, dataStream.ToArray(), RegistryValueKind.Binary);
                return true;
            } catch (Exception ex) {
                errMsg = ex.Message;
                return false;
            } finally {
                softDir.Close ();
            }
        }
    }
}
