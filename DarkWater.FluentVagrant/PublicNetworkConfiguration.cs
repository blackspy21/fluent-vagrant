using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class PublicNetworkConfiguration
  {
    public PublicNetworkConfiguration(string configPrefix = "config")
    {
      _configPrefix = configPrefix;
    }

    private readonly string _configPrefix;
    private PublicNetworkTypes _networkType = PublicNetworkTypes.dhcp;
    private string _ipAddress = string.Empty;
    private bool? _useDHCPAssignedDefaultRoute = null;
    private List<string> _bridgeInterfaces = new List<string>();
    private bool? _autoConfig = null;

    public PublicNetworkConfiguration SetNetworkType(PublicNetworkTypes networkType)
    {
      _networkType = networkType;
      return this;
    }

    public PublicNetworkConfiguration SetIpAddress(string ip)
    {
      _ipAddress = ip;
      return this;
    }

    public PublicNetworkConfiguration SetAutoConfiguration(bool? autoConfig)
    {
      _autoConfig = autoConfig;
      return this;
    }

    public PublicNetworkConfiguration SetUserDHCPAssignedDefaultRoute(bool? useAssignedRoute)
    {
      _useDHCPAssignedDefaultRoute = useAssignedRoute;
      return this;
    }

    public PublicNetworkConfiguration AddBridgedInterface(string interfaceName)
    {
      _bridgeInterfaces.Add(interfaceName);
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder(_configPrefix + ".vm.network \"public_network\"");
      switch(_networkType)
      {
        case PublicNetworkTypes.dhcp:
          if (_useDHCPAssignedDefaultRoute != null)
          {
            sb.Append(string.Format(", use_dhcp_assigned_default_route: {0}", _useDHCPAssignedDefaultRoute));
          }
          break;
        case PublicNetworkTypes.staticIP:
          sb.Append(string.Format(", ip: \"{0}\"", _ipAddress));
          break;
      }
      if (_bridgeInterfaces.Count > 0)
      {
        if (_bridgeInterfaces.Count == 1)
        {
          sb.Append(string.Format(", bridge: \"{0}\"", _bridgeInterfaces[0]));
        }
        else
        {
          sb.Append(", [");
          for (int i=0; i < _bridgeInterfaces.Count; i++)
          {
            sb.Append("\"" + _bridgeInterfaces[i] + "\"");
            if (i != _bridgeInterfaces.Count - 1)
            {
              sb.Append(",");
            }
          }
          sb.Append("]");
        }
      }
      if (_autoConfig == false)
      {
        sb.Append(", auto_config: false");
      }
      return sb.ToString();
    }
  }

  public enum PublicNetworkTypes
  {
    dhcp,
    staticIP
  }
}
