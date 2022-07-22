using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BLL.Constant
{
    public static class ResultTypeMessage
    {
        public static string Add()
        {
            return "Ekleme Başarılı";
        }
        public static string Warning()
        {
            return "Beklenmedik Sorun oluştu...";
        }
        public static string Error(Exception ex)
        {
            return "Error: " + ex.ToInnest().Message;
        }

    }
}
