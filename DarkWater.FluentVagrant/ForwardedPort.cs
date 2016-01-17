using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class ForwardedPort
  {
    public ForwardedPort(int host, int guest, string configPrefix = "config")
    {
      _hostPort = host;
      _guestPort = guest;
      _configPrefix = configPrefix;
    }

    private readonly string _configPrefix;
    private int _guestPort;
    private string _guestIp = string.Empty;
    private int _hostPort;
    private string _hostIp = string.Empty;
    private Protocols _protocol = Protocols.none;

    public ForwardedPort SetHostIP(string hostIp)
    {
      _hostIp = hostIp;
      return this;
    }

    public ForwardedPort SetGuesttIP(string guestIp)
    {
      _guestIp = guestIp;
      return this;
    }

    public ForwardedPort SetProtocol(Protocols protocol)
    {
      _protocol = protocol;
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(string.Format(_configPrefix + ".vm.network \"forwarded_port\", guest: {0}, host: {1}", _guestPort, _hostPort));
      if (_guestIp.Length > 0)
      {
        sb.Append(string.Format(", guest_ip: \"{0}\"", _guestIp));
      }
      if (_hostIp.Length > 0)
      {
        sb.Append(string.Format(", host_ip: \"{0}\"", _hostIp));
      }
      if (_protocol != Protocols.none)
      {
        sb.Append(string.Format(", protocol: \"{0}\"", _protocol.ToString()));
      }
      return sb.ToString();
    }
  }

  public enum Protocols
  {
    none,
    udp,
    tcp
  }
}
