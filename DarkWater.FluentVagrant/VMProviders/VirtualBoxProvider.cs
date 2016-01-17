using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkWater.FluentVagrant.VMProviders
{
  public class VirtualBoxProvider : IVMProvider
  {
    public int Memory
    {
      get;
      private set;
    }

    public int NumberOfCPUs
    {
      get;
      private set;
    }

    public bool? ShowGUI
    {
      get;
      private set;
    }

    public bool? LinkedClone
    {
      get;
      private set;
    }

    public VirtualBoxProvider SetMemory(int memoryInMB)
    {
      Memory = memoryInMB;
      return this;
    }

    public VirtualBoxProvider SetNumberOfCPUs(int numnberOfCPUs)
    {
      NumberOfCPUs = numnberOfCPUs;
      return this;
    }

    public VirtualBoxProvider SetShowGui(bool? show)
    {
      ShowGUI = show;
      return this;
    }

    public VirtualBoxProvider SetLinkedClone(bool? isLinkedClone)
    {
      LinkedClone = isLinkedClone;
      return this;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendLine("config.vm.provider \"virtualbox\" do |vb|");
      if (Memory != 0)
      {
        sb.AppendLine("   vb.memory = " + Memory.ToString());
      }
      if (NumberOfCPUs != 0)
      {
        sb.AppendLine("   vb.cpus = " + NumberOfCPUs.ToString());
      }
      if (ShowGUI != null)
      {
        sb.AppendLine("   vb.gui = " + ShowGUI.ToString().ToLower());
      }
      if (LinkedClone != null)
      {
        sb.AppendLine("   vb.linked_clone = " + LinkedClone.ToString().ToLower());
      }
      sb.AppendLine("end");
      return sb.ToString();
    }
  }
}
