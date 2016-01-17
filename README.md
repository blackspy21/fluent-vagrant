# fluent-vagrant
A fluent interface for creating a Vagrantfile.

For example, the following C# code will create a new vagrant file in "c:\temp":

```C#
var config = new VagrantConfiguration()
              .SetVirtualMachineConfiguration(new VirtualMachineConfiguration("hashicorp/precise64", CommunicatorTypes.winrm))
              .SetNetworkingConfiguration(
                new NetworkConfiguration()
                  .AddForwardedPort(new ForwardedPort(8008, 80))
                  .AddForwardedPort(new ForwardedPort(8143, 1433)))
              .SetVirtualMachineProviderConfiguration(
                new VirtualBoxProvider()
                  .SetMemory(4096)
                  .SetShowGui(true)
                  .SetNumberOfCPUs(2))
              .SetWinRMConfiguration(
                new WinRMConfiguration()
                  .SetUsername("Administrator")
                  .SetPassword("password"));
      File.WriteAllText(@"c:\temp\VagrantFile", config.ToString());
```

The generated VagrantFile will contain:

```ruby
# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure(2) do |config|

config.vm.box = "hashicorp/precise64"
config.vm.communicator  = :winrm

config.vm.network "forwarded_port", guest: 80, host: 8008
config.vm.network "forwarded_port", guest: 1433, host: 8143


config.winrm.username = "Administrator"
config.winrm.password = "password"
config.winrm.port = 5985
config.winrm.guest_port = 5985

config.vm.provider "virtualbox" do |vb|
   vb.memory = 4096
   vb.cpus = 2
   vb.gui = true
end

end
```
