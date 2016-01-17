using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class PrivateNetworkConfiguration
  {
    public PrivateNetworkConfiguration(string configPrefix = "config")
    {
      _configPrefix = configPrefix;
    }

    private readonly string _configPrefix;
    private PrivateNetworkTypes _networkType = PrivateNetworkTypes.dhcp;
    private string _ipAddress = string.Empty;
    private string _ipV6Address = string.Empty;
    private string _ipv6NetMask = string.Empty;
    private bool? _autoConfig = null;

    public PrivateNetworkConfiguration SetPrivateNetworkType(PrivateNetworkTypes pvtNetworkType)
    {
      _networkType = pvtNetworkType;
      return this;
    }

    public PrivateNetworkConfiguration SetIpAddress(string ip)
    {
      _ipAddress = ip;
      return this;
    }

    public PrivateNetworkConfiguration SetAutoConfiguration(bool? autoConfig)
    {
      _autoConfig = autoConfig;
      return this;
    }

    public PrivateNetworkConfiguration SetIpAddressV6(string ipV6, string netmask = "")
    {
      _ipV6Address = ipV6;
      if (netmask.Length > 0)
      {
        _ipv6NetMask = netmask;
      }
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder(_configPrefix + ".vm.network \"private_network\"");
      switch (_networkType)
      {
        case PrivateNetworkTypes.dhcp:
          sb.Append(", type: \"dhcp\"");
          break;
        case PrivateNetworkTypes.staticIP:
          sb.Append(string.Format(", ip: \"{0}\"", _ipAddress));
          break;
        case PrivateNetworkTypes.staticIPv6:
          sb.Append(string.Format(", ip: \"{0}\"", _ipV6Address));
          if (_ipv6NetMask != null)
          {
            sb.Append(string.Format(", netmask: \"{0}\"", _ipv6NetMask));
          }
          break;
      }
      if (_autoConfig == false)
      {
        sb.Append(", auto_config: false");
      }
      return sb.ToString();
    }
  }

  public enum PrivateNetworkTypes
  {
    dhcp,
    staticIP,
    staticIPv6
  }
}
