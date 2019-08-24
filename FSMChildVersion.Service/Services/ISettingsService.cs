using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FSMChildVersion.Service.Services
{
    public class SettingsService : ISettingsService
    {
        #region Public Methods

        public Task AddOrUpdateValue(string key, bool value)
        {
            return AddOrUpdateValueInternalAsync(key, value);
        }

        public Task AddOrUpdateValue(string key, string value)
        {
            return AddOrUpdateValueInternalAsync(key, value);
        }

        public bool GetValueOrDefault(string key, bool defaultValue)
        {
            return GetValueOrDefaultInternal(key, defaultValue);
        }

        public string GetValueOrDefault(string key, string defaultValue)
        {
            return GetValueOrDefaultInternal(key, defaultValue);
        }
        public void RemoveValueOrDefault(string key)
        {
            _ = RemoveAsync(key);
        }
        #endregion

        #region Internal Implementation

        private async Task AddOrUpdateValueInternalAsync<T>(string key, T value)
        {
            if (value == null)
                await RemoveAsync(key);

            Application.Current.Properties[key] = value;
            try
            {
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
            }
        }

        private T GetValueOrDefaultInternal<T>(string key, T defaultValue = default)
        {
            object value = null;
            if (Application.Current.Properties.ContainsKey(key))
                value = Application.Current.Properties[key];

            return null != value ? (T)value : defaultValue;
        }

        private async Task RemoveAsync(string key)
        {
            try
            {
                if (Application.Current.Properties[key] != null)
                {
                    Application.Current.Properties.Remove(key);
                    await Application.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove: " + key, " Message: " + ex.Message);
            }
        }

        #endregion

    }
    public interface ISettingsService
    {
        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, string value);
        void RemoveValueOrDefault(string key);
    }
}
