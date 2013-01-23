﻿using Linphone.Resources;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Linphone.Model
{
    public class SettingsManager
    {
        private IsolatedStorageSettings settings;
        private ResourceManager resourceManager;

        const string DebugSettingKeyName = "Debug";
        const string TransportSettingKeyName = "Transport";
        const string AMRNBSettingKeyName = "AMRNB";
        const string AMRWBSettingKeyName = "AMRWB";
        const string Speex16SettingKeyName = "Speex16";
        const string Speex8SettingKeyName = "Speex8";
        const string PCMUSettingKeyName = "PCMU";
        const string PCMASettingKeyName = "PCMA";
        const string G722SettingKeyName = "G722";
        const string ILBCSettingKeyName = "ILBC";
        const string SILK16SettingKeyName = "SILK16";
        const string GSMSettingKeyName = "GSM";

        public SettingsManager()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;

            // Default values for the settings
            resourceManager = new ResourceManager("Linphone.Resources.DefaultValues", typeof(DefaultValues).Assembly);
        }

        public static bool isDebugEnabled
        {
            get
            {
                SettingsManager sm = new SettingsManager();
                return sm.DebugEnabled != null;
            }
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <returns>true if the value changed, false otherwise</returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            if (settings.Contains(Key))
            {
                if (settings[Key] != value)
                {
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }

        /// <summary>
        /// Property to get and set the Debug mode
        /// </summary>
        public bool? DebugEnabled
        {
            get
            {
                return GetValueOrDefault<bool?>(DebugSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(DebugSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public string Transport
        {
            get
            {
                return GetValueOrDefault<string>(TransportSettingKeyName, resourceManager.GetString("TransportDefault"));
            }
            set
            {
                if (AddOrUpdateValue(TransportSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        #region Codecs Settings
        public bool? AMRNB
        {
            get
            {
                return GetValueOrDefault<bool?>(AMRNBSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(AMRNBSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? AMRWB
        {
            get
            {
                return GetValueOrDefault<bool?>(AMRWBSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(AMRWBSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? Speex16
        {
            get
            {
                return GetValueOrDefault<bool?>(Speex16SettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(Speex16SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? Speex8
        {
            get
            {
                return GetValueOrDefault<bool?>(Speex8SettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(Speex8SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? PCMU
        {
            get
            {
                return GetValueOrDefault<bool?>(PCMUSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(PCMUSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? PCMA
        {
            get
            {
                return GetValueOrDefault<bool?>(PCMASettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(PCMASettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? G722
        {
            get
            {
                return GetValueOrDefault<bool?>(G722SettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(G722SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? ILBC
        {
            get
            {
                return GetValueOrDefault<bool?>(ILBCSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(ILBCSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? SILK16
        {
            get
            {
                return GetValueOrDefault<bool?>(SILK16SettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(SILK16SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool? GSM
        {
            get
            {
                return GetValueOrDefault<bool?>(GSMSettingKeyName, false);
            }
            set
            {
                if (AddOrUpdateValue(GSMSettingKeyName, value))
                {
                    Save();
                }
            }
        }
        #endregion
    }
}