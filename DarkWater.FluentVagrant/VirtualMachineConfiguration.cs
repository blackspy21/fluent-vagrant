using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant
{
  public class VirtualMachineConfiguration
  {
    #region Constructors
    public VirtualMachineConfiguration(string boxName, CommunicatorTypes communicator, string configPrefix = "config")
    {
      _boxName = boxName;
      _communicator = communicator;
      _configPrefix = configPrefix;
    }
    #endregion

    #region Members
    private readonly string _configPrefix;
    private bool? _checkForUpdates = null;
    private readonly string _boxName;
    private string _boxUrl = string.Empty;
    private string _boxVersion = string.Empty;
    private int _bootTimeout = 300;
    private List<Tuple<string, string>> _syncedFolders = new List<Tuple<string, string>>();
    private string _downloadCheckSum = string.Empty;
    private CheckSumType _downloadCheckSumType = CheckSumType.none;
    private string _pathToDownloadClientCert = string.Empty;
    private string _pathToDownloadCACert = string.Empty;
    private string _pathToDownloadCACertBundle = string.Empty;
    private bool? _downloadInsecure = null;
    private bool? _downloadLocationTrusted = null;
    private CommunicatorTypes _communicator = CommunicatorTypes.ssh;
    private int _gracefulHaltTimeout = 60;
    private GuestTypes _guestType = GuestTypes.linux;
    private string _guestHostName = string.Empty;
    private string _postUpMessage = string.Empty;
    private string _usablePortRange = string.Empty;
    #endregion


    public override string ToString()
    {
      string prefix = _configPrefix + ".vm.";
      var sb = new StringBuilder();
      if (_bootTimeout != 300)
      {
        sb.AppendLine(prefix + "boot_timeout = " + _bootTimeout.ToString());
      }
      sb.AppendLine(string.Format("{0}box = \"{1}\"", prefix, _boxName));
      if (_checkForUpdates != null)
      {
        sb.AppendLine(string.Format("{0}box_check_update = {1}", prefix, _checkForUpdates.ToString().ToLower()));
      }
      if (_downloadCheckSum.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_download_checksum = \"{1}\"", prefix, _downloadCheckSum));
        sb.AppendLine(string.Format("{0}config.vm.box_download_checksum_type = \"{1}\"", prefix, _downloadCheckSumType.ToString()));
      }
      if (_boxUrl.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_url = \"{1}\"", prefix, _boxUrl));
      }
      if (_pathToDownloadClientCert.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_download_client_cert = \"{1}\"", prefix, _pathToDownloadClientCert));
      }
      if (_pathToDownloadCACertBundle.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_download_ca_cert = \"{1}\"", prefix, _pathToDownloadCACertBundle));
      }
      if (_pathToDownloadCACert.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_download_ca_path = \"{1}\"", prefix, _pathToDownloadCACert));
      }
      if (_downloadInsecure != null)
      {
        sb.AppendLine(string.Format("{0}box_download_insecure = {1}", prefix, _downloadInsecure.ToString().ToLower()));
      }
      if (_downloadLocationTrusted != null)
      {
        sb.AppendLine(string.Format("{0}box_download_location_trusted = {1}", prefix, _downloadLocationTrusted.ToString().ToLower()));
      }
      if (_boxVersion.Length > 0)
      {
        sb.AppendLine(string.Format("{0}box_version = \"{1}\"", prefix, _boxVersion));
      }
      if (_communicator == CommunicatorTypes.winrm)
      {
        sb.AppendLine(string.Format("{0}communicator  = :{1}", prefix, _communicator.ToString()));
      }
      if (_gracefulHaltTimeout != 60)
      {
        sb.AppendLine(string.Format("{0}graceful_halt_timeout = {1}", prefix, _gracefulHaltTimeout.ToString()));
      }
      if (_guestType == GuestTypes.windows)
      {
        sb.AppendLine(string.Format("{0}guest  = :windows", prefix));
      }
      if (_guestHostName.Length > 0)
      {
        sb.AppendLine(string.Format("{0}hostname = \"{1}\"", prefix, _guestHostName));
      }
      if (_postUpMessage.Length > 0)
      {
        sb.AppendLine(string.Format("{0}post_up_message = \"{1}\"", prefix, _postUpMessage));
      }
      if (_usablePortRange.Length > 0)
      {
        sb.AppendLine(string.Format("{0}usable_port_range = \"{1}\"", prefix, _usablePortRange));
      }
      return sb.ToString();
    }

    #region Fluent Interface
    public VirtualMachineConfiguration SetDownloadClientCertificatePath(string downloadCertificatePath)
    {
      _pathToDownloadClientCert = downloadCertificatePath;
      return this;
    }

    public VirtualMachineConfiguration SetDownloadCACertificateBundlePath(string downloadCACertificateBundlePath)
    {
      _pathToDownloadCACertBundle = downloadCACertificateBundlePath;
      return this;
    }

    public VirtualMachineConfiguration SetGuestHostname(string guestHostname)
    {
      _guestHostName = guestHostname;
      return this;
    }

    public VirtualMachineConfiguration SetGracefulHaltTimeout(int timeout)
    {
      _gracefulHaltTimeout = timeout;
      return this;
    }

    public VirtualMachineConfiguration SetBoxUrl(string boxUrl)
    {
      _boxUrl = boxUrl;
      return this;
    }

    public VirtualMachineConfiguration SetPostUpMessage(string message)
    {
      _postUpMessage = message;
      return this;
    }

    public VirtualMachineConfiguration SetBoxVersion(string boxVersion)
    {
      _boxVersion = boxVersion;
      return this;
    }

    public VirtualMachineConfiguration SetUsablePortRange(int start, int end)
    {
      _usablePortRange = string.Format("({0}..{1})", start, end);
      return this;
    }

    public VirtualMachineConfiguration MustCheckForUpdates(bool? check)
    {
      _checkForUpdates = check;
      return this;
    }

    public VirtualMachineConfiguration AllowInsecureUpdates(bool? allow)
    {
      _downloadInsecure = allow;
      return this;
    }

    public VirtualMachineConfiguration SetDownloadLoacationTrusted(bool? trusted)
    {
      _downloadLocationTrusted = trusted;
      return this;
    }

    public VirtualMachineConfiguration AddSyncedFolder(string folderPath, string mountPath)
    {
      _syncedFolders.Add(new Tuple<string, string>(folderPath, mountPath));
      return this;
    }

    public VirtualMachineConfiguration SetBootTimeout(int timeout)
    {
      _bootTimeout = timeout;
      return this;
    }

    public VirtualMachineConfiguration SetGuestType(GuestTypes guestType)
    {
      _guestType = guestType;
      return this;
    }

    public VirtualMachineConfiguration SetDownloadChecksum(string checksum, CheckSumType checksumType)
    {
      _downloadCheckSum = checksum;
      _downloadCheckSumType = checksumType;
      return this;
    } 
    #endregion
  }

  #region Enums
  public enum CheckSumType
  {
    none,
    md5,
    sha1,
    sha256
  }

  public enum CommunicatorTypes
  {
    ssh,
    winrm
  }

  public enum GuestTypes
  {
    windows,
    linux
  } 
  #endregion
}
