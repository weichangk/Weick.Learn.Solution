using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Memcache
{
    public class MemcacheConfig : ConfigurationSection
    {

        public static MemcacheConfig GetConfig()
        {
            return GetConfig("memcachedconfig");
        }
        public static MemcacheConfig GetConfig(string sectionName)
        {
            MemcacheConfig section = (MemcacheConfig)ConfigurationManager.GetSection(sectionName);
            if (section == null)
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            return section;
        }


        [ConfigurationProperty("ServerList", IsRequired = false)]
        public string ServerList
        {
            get
            {
                return (string)base["ServerList"];
            }
            set
            {
                base["ServerList"] = value;
            }
        }

        [ConfigurationProperty("InitConnections", IsRequired = false, DefaultValue = 3)]
        public int InitConnections
        {
            get
            {
                int InitConnections = (int)base["InitConnections"];
                return InitConnections > 0 ? InitConnections : 3;
            }
            set
            {
                base["InitConnections"] = value;
            }
        }

        [ConfigurationProperty("MinConnections", IsRequired = false, DefaultValue = 3)]
        public int MinConnections
        {
            get
            {
                int MinConnections = (int)base["MinConnections"];
                return MinConnections > 0 ? MinConnections : 3;
            }
            set
            {
                base["MinConnections"] = value;
            }
        }

        [ConfigurationProperty("MaxConnections", IsRequired = false, DefaultValue = 5)]
        public int MaxConnections
        {
            get
            {
                int MaxConnections = (int)base["MaxConnections"];
                return MaxConnections > 0 ? MaxConnections : 5;
            }
            set
            {
                base["MaxConnections"] = value;
            }
        }


        [ConfigurationProperty("SocketConnectTimeout", IsRequired = false, DefaultValue = 1000)]
        public int SocketConnectTimeout
        {
            get
            {
                int SocketConnectTimeout = (int)base["SocketConnectTimeout"];
                return SocketConnectTimeout > 0 ? SocketConnectTimeout : 1000;
            }
            set
            {
                base["SocketConnectTimeout"] = value;
            }
        }

        [ConfigurationProperty("SocketTimeout", IsRequired = false, DefaultValue = 3000)]
        public int SocketTimeout
        {
            get
            {
                int SocketTimeout = (int)base["SocketTimeout"];
                return SocketTimeout > 0 ? SocketTimeout : 3000;
            }
            set
            {
                base["SocketTimeout"] = value;
            }
        }

        [ConfigurationProperty("MaintenanceSleep", IsRequired = false, DefaultValue = 30)]
        public int MaintenanceSleep
        {
            get
            {
                int MaintenanceSleep = (int)base["MaintenanceSleep"];
                return MaintenanceSleep > 0 ? MaintenanceSleep : 30;
            }
            set
            {
                base["MaintenanceSleep"] = value;
            }
        }

        [ConfigurationProperty("Failover", IsRequired = false, DefaultValue = true)]
        public bool Failover
        {
            get
            {
                return (bool)base["Failover"];
            }
            set
            {
                base["Failover"] = value;
            }
        }

        [ConfigurationProperty("Nagle", IsRequired = false, DefaultValue = false)]
        public bool Nagle
        {
            get
            {
                return (bool)base["Nagle"];
            }
            set
            {
                base["Nagle"] = value;
            }
        }

        [ConfigurationProperty("EnableCompression", IsRequired = false, DefaultValue = false)]
        public bool EnableCompression
        {
            get
            {
                return (bool)base["EnableCompression"];
            }
            set
            {
                base["EnableCompression"] = value;
            }
        }

    }
}
