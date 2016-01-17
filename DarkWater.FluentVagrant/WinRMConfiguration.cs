using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class WinRMConfiguration
  {
    public WinRMConfiguration(string configPrefix = "config")
    {
      _configPrefix = configPrefix;
    }

    private readonly string _configPrefix;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _host = string.Empty;
    private int _port = 5985;
    private int _guestPort = 5985;

    #region Fluent Interface
    public WinRMConfiguration SetUsername(string username)
    {
      _username = username;
      return this;
    }
    public WinRMConfiguration SetPassword(string password)
    {
      _password = password;
      return this;
    }
    public WinRMConfiguration Sethost(string host)
    {
      _host = host;
      return this;
    }
    public WinRMConfiguration SetPort(int port)
    {
      _port = port;
      return this;
    }
    public WinRMConfiguration SetGuestPort(int port)
    {
      _guestPort = port;
      return this;
    }
    #endregion

    public override string ToString()
    {
      string prefix = _configPrefix + ".winrm.";
      var sb = new StringBuilder();
      if (_username.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "username = \"{0}\"", _username));
      }
      if (_password.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "password = \"{0}\"", _password));
      }
      if (_host.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "host = \"{0}\"", _host));
      }
      sb.AppendLine(string.Format(prefix + "port = {0}", _port));
      sb.AppendLine(string.Format(prefix + "guest_port = {0}", _guestPort));
      return sb.ToString();
    }
  }
}
