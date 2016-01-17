using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class NetworkConfiguration
  {
    private List<ForwardedPort> _forwardedPorts = new List<ForwardedPort>();
    private PrivateNetworkConfiguration _privateNetworkConfiguration = null;
    private PublicNetworkConfiguration _publicNetworkConfiguration = null;

    public NetworkConfiguration AddForwardedPort(ForwardedPort port)
    {
      _forwardedPorts.Add(port);
      return this;
    }

    public NetworkConfiguration SetPrivateNetworkConfiguration(PrivateNetworkConfiguration configuration)
    {
      _privateNetworkConfiguration = configuration;
      return this;
    }

    public NetworkConfiguration SetPublicNetworkConfiguration(PublicNetworkConfiguration configuration)
    {
      _publicNetworkConfiguration = configuration;
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      if (_forwardedPorts.Count > 0)
      {
        foreach (var port in _forwardedPorts)
        {
          sb.AppendLine(port.ToString());
        }
        sb.AppendLine();
      }
      if (_privateNetworkConfiguration != null)
      {
        sb.Append(_privateNetworkConfiguration.ToString());
        sb.AppendLine();
      }
      if (_publicNetworkConfiguration != null)
      {
        sb.Append(_publicNetworkConfiguration.ToString());
        sb.AppendLine();
      }
      return sb.ToString();
    }
  }
}
