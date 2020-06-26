using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace APSmartHome.Helper
{
   public class Security
    {
        internal static async Task SaveSecureString(string key,string val)
        {
            try
            {
                await SecureStorage.SetAsync(key, val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<string> GetSecureString(string key)
        {
            try
            {
               return await SecureStorage.GetAsync(key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<bool> BioAuthentication()
        {
            try
            {
                var request = new AuthenticationRequestConfiguration("Prove you have fingers!");
                var result = await CrossFingerprint.Current.AuthenticateAsync(request);
                if (result.Authenticated)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
