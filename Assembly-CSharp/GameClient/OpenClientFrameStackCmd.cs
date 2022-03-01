using System;

namespace GameClient
{
	// Token: 0x020010F2 RID: 4338
	public class OpenClientFrameStackCmd : BaseClientFrameStackCmd, IClientFrameStackCmd
	{
		// Token: 0x0600A451 RID: 42065 RVA: 0x0021C8DA File Offset: 0x0021ACDA
		public OpenClientFrameStackCmd(Type type, object data = null) : base(eClientFrameStackCmd.OpenFrame)
		{
			this.mFrame = type;
			this.mData = data;
		}

		// Token: 0x0600A452 RID: 42066 RVA: 0x0021C8F4 File Offset: 0x0021ACF4
		public bool Do()
		{
			bool result;
			try
			{
				if (Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemTown)
				{
					Singleton<ClientSystemManager>.instance.OpenFrame(this.mFrame, FrameLayer.Middle, this.mData, string.Empty);
				}
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x04005BDC RID: 23516
		protected Type mFrame;

		// Token: 0x04005BDD RID: 23517
		protected object mData;
	}
}
