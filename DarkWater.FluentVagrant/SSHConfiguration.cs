using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class SSHConfiguration
  {
    public SSHConfiguration(string configPrefix = "config")
    {
      _configPrefix = configPrefix;
    }

    #region Members
    private readonly string _configPrefix;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _host = string.Empty;
    private int _port = 22;
    private int _guestPort = 22;
    private string _privateKeyPath = string.Empty;
    private bool? _forwardAgent = null;
    private bool? _forwardX11 = null;
    private List<string> _forwardEnvironment = new List<string>();
    private bool? _insertKey = null;
    private string _proxyCommand = string.Empty;
    private bool? _pty = null;
    private string _shell = string.Empty;
    private string _sudoCommand = string.Empty;
    #endregion

    #region FluentInterface

    public SSHConfiguration SetUsername(string username)
    {
      _username = username;
      return this;
    }
    public SSHConfiguration SetPassword(string password)
    {
      _password = password;
      return this;
    }
    public SSHConfiguration Sethost(string host)
    {
      _host = host;
      return this;
    }
    public SSHConfiguration SetPort(int port)
    {
      _port = port;
      return this;
    }
    public SSHConfiguration SetGuestPort(int port)
    {
      _guestPort = port;
      return this;
    }
    public SSHConfiguration SetPrivateKeyPath(string privateKeyPath)
    {
      _privateKeyPath = privateKeyPath;
      return this;
    }
    public SSHConfiguration SetForwardAgent(bool? forwardAgent)
    {
      _forwardAgent = forwardAgent;
      return this;
    }
    public SSHConfiguration SetForwardX11(bool? forwardX11)
    {
      _forwardX11 = forwardX11;
      return this;
    }
    public SSHConfiguration AddForwardEnvironmentOption(string option)
    {
      _forwardEnvironment.Add(option);
      return this;
    }
    public SSHConfiguration SetInsertKey(bool? insertKey)
    {
      _insertKey = insertKey;
      return this;
    }
    public SSHConfiguration SetProxyCommand(string proxyCommand)
    {
      _proxyCommand = proxyCommand;
      return this;
    }
    public SSHConfiguration SetPty(bool? pty)
    {
      _pty = pty;
      return this;
    }
    public SSHConfiguration SetShell(string shell)
    {
      _shell = shell;
      return this;
    }
    public SSHConfiguration SetSudoCommand(string sudoCmd)
    {
      _sudoCommand = sudoCmd;
      return this;
    }
    #endregion

    public override string ToString()
    {
      string prefix = _configPrefix + ".ssh.";
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
      if (_privateKeyPath.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "private_key_path = \"{0}\"", _privateKeyPath));
      }
      if (_forwardAgent != null)
      {
        sb.AppendLine(string.Format(prefix + "forward_agent = {0}", _forwardAgent.ToString().ToLower()));
      }
      if (_forwardX11 != null)
      {
        sb.AppendLine(string.Format(prefix + "forward_x11 = {0}", _forwardX11.ToString().ToLower()));
      }
      if (_forwardEnvironment.Count > 0)
      {
        sb.Append(prefix + "forward_env: [");
        for (int i = 0; i < _forwardEnvironment.Count; i++)
        {
          sb.Append("\"" + _forwardEnvironment[i] + "\"");
          if (i != _forwardEnvironment.Count - 1)
          {
            sb.Append(",");
          }
        }
        sb.Append("]");
        sb.AppendLine();
      }
      if (_insertKey != null)
      {
        sb.AppendLine(string.Format(prefix + "insert_key = {0}", _insertKey.ToString().ToLower()));
      }
      if (_proxyCommand.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "proxy_command = \"{0}\"", _proxyCommand));
      }
      if (_pty != null)
      {
        sb.AppendLine(string.Format(prefix + "pty = {0}", _pty.ToString().ToLower()));
      }
      if (_shell.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "shell = \"{0}\"", _shell));
      }
      if (_sudoCommand.Length > 0)
      {
        sb.AppendLine(string.Format(prefix + "sudo_command = \"{0}\"", _sudoCommand));
      }
      return sb.ToString();
    }
  }
}
