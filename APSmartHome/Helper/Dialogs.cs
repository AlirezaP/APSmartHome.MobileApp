using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.Helper
{
    public class Dialogs
    {
        public static async Task ShowBasicMessage(string msg, string title = "هشدار", string okLbl = "تایید")
        {
           await Acr.UserDialogs.UserDialogs.Instance.AlertAsync(msg, title, "OK");
        }

        public static void ShowToastMessage(string msg)
        {
            Acr.UserDialogs.UserDialogs.Instance.Toast(msg);
        }

        public static async Task<bool> ShowConfirm(string msg, string title = "هشدار")
        {
            return await Acr.UserDialogs.UserDialogs.Instance.ConfirmAsync(new Acr.UserDialogs.ConfirmConfig
            {
                Title = title,
                Message = msg,
                OkText = "تایید",
                CancelText = "لغو",

            });
        }

        public static void Loading(string msg="لطفا صبر کنید")
        {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading(msg);
        }

        public static void HideLoading()
        {
            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
        }
    }
}
