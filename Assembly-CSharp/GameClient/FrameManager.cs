using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001100 RID: 4352
	internal class FrameManager : Singleton<FrameManager>
	{
		// Token: 0x0600A508 RID: 42248 RVA: 0x00220929 File Offset: 0x0021ED29
		public override void Init()
		{
		}

		// Token: 0x0600A509 RID: 42249 RVA: 0x0022092C File Offset: 0x0021ED2C
		public override void UnInit()
		{
			for (int i = 0; i < this.m_arrFrames.Count; i++)
			{
				this.m_arrFrames[i].Clear();
			}
			this.m_arrFrames.Clear();
		}

		// Token: 0x0600A50A RID: 42250 RVA: 0x00220971 File Offset: 0x0021ED71
		private void _RegisterFrame(ClientFrame a_frame)
		{
			if (a_frame != null)
			{
				a_frame.Init();
				this.m_arrFrames.Add(a_frame);
			}
		}

		// Token: 0x04005C17 RID: 23575
		private List<ClientFrame> m_arrFrames = new List<ClientFrame>();
	}
}
