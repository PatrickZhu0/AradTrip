using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02004510 RID: 17680
	public class FrameCommandPool
	{
		// Token: 0x06018980 RID: 100736 RVA: 0x007AE614 File Offset: 0x007ACA14
		public IFrameCommand GetFrameCommand(uint typeID)
		{
			List<IFrameCommand> list = null;
			if (!this.m_FrameCommandPool.TryGetValue(typeID, out list))
			{
				list = new List<IFrameCommand>();
				this.m_FrameCommandPool.Add(typeID, list);
			}
			if (list.Count > 0)
			{
				int index = list.Count - 1;
				IFrameCommand frameCommand = list[index];
				list.RemoveAt(index);
				frameCommand.Reset();
				return frameCommand;
			}
			return FrameCommandFactory.CreateCommand(typeID);
		}

		// Token: 0x06018981 RID: 100737 RVA: 0x007AE680 File Offset: 0x007ACA80
		public void RecycleFrameCommand(IFrameCommand command)
		{
			if (command != null)
			{
				uint id = (uint)command.GetID();
				List<IFrameCommand> list = null;
				if (!this.m_FrameCommandPool.TryGetValue(id, out list))
				{
					list = new List<IFrameCommand>();
					this.m_FrameCommandPool.Add(id, list);
				}
				list.Add(command);
			}
		}

		// Token: 0x04011C02 RID: 72706
		private Dictionary<uint, List<IFrameCommand>> m_FrameCommandPool = new Dictionary<uint, List<IFrameCommand>>();
	}
}
