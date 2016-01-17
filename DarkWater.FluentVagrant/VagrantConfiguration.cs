using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class VagrantConfiguration
  {
    public VagrantConfiguration(string configPrefix = "config")
    {
      _configPrefix = configPrefix;
    }

    private NetworkConfiguration _networking = null;
    private IVMProvider _provider = null;
    private IProvisioner _provisioner = null;
    private VirtualMachineConfiguration _vm = null;
    private SSHConfiguration _ssh = null;
    private WinRMConfiguration _winrm = null;
    private int _configurationVersion = 2;
    private readonly string _configPrefix;

    public VagrantConfiguration SetVirtualMachineConfiguration(VirtualMachineConfiguration vmConfig)
    {
      _vm = vmConfig;
      return this;
    }

    public VagrantConfiguration SetSSHConfiguration(SSHConfiguration ssh)
    {
      _ssh = ssh;
      return this;
    }

    public VagrantConfiguration SetWinRMConfiguration(WinRMConfiguration winrm)
    {
      _winrm = winrm;
      return this;
    }

    public VagrantConfiguration SetNetworkingConfiguration(NetworkConfiguration networking)
    {
      _networking = networking;
      return this;
    }

    public VagrantConfiguration SetVirtualMachineProviderConfiguration(IVMProvider provider)
    {
      _provider = provider;
      return this;
    }

    public VagrantConfiguration SetProvisioningConfiguration(IProvisioner provisioner)
    {
      _provisioner = provisioner;
      return this;
    }

    public VagrantConfiguration SetConfigurationVersion(int version)
    {
      _configurationVersion = version;
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendLine("# -*- mode: ruby -*-");
      sb.AppendLine("# vi: set ft=ruby :");
      sb.AppendLine();
      sb.AppendLine(string.Format("Vagrant.configure({0}) do |{1}|", _configurationVersion, _configPrefix));
      sb.AppendLine();
      if (_vm != null)
      {
        sb.Append(_vm.ToString());
        sb.AppendLine();
      }
      if (_networking != null)
      {
        sb.Append(_networking.ToString());
        sb.AppendLine();
      }
      if (_ssh != null)
      {
        sb.Append(_ssh.ToString());
        sb.AppendLine();
      }
      if (_winrm != null)
      {
        sb.Append(_winrm.ToString());
        sb.AppendLine();
      }
      if (_provider != null)
      {
        sb.Append(_provider.ToString());
        sb.AppendLine();
      }
      if (_provisioner != null)
      {
        sb.Append(_provisioner.ToString());
        sb.AppendLine();
      }
      sb.AppendLine("end");
      return sb.ToString();
    }
  }
}
