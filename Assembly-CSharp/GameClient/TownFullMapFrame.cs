using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001CBC RID: 7356
	internal class TownFullMapFrame : ClientFrame
	{
		// Token: 0x060120C0 RID: 73920 RVA: 0x005476F0 File Offset: 0x00545AF0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TownMap/FullMap";
		}

		// Token: 0x060120C1 RID: 73921 RVA: 0x005476F7 File Offset: 0x00545AF7
		protected override void _OnOpenFrame()
		{
			this.m_mapFrame = (this.frameMgr.OpenFrame<TownMapFrame>(this.m_objMapRoot, null, "full_map") as TownMapFrame);
		}

		// Token: 0x060120C2 RID: 73922 RVA: 0x0054771B File Offset: 0x00545B1B
		protected override void _OnCloseFrame()
		{
			this.frameMgr.CloseFrame<TownMapFrame>(this.m_mapFrame, false);
		}

		// Token: 0x060120C3 RID: 73923 RVA: 0x0054772F File Offset: 0x00545B2F
		[UIEventHandle("close")]
		protected void _OnClose()
		{
			this.frameMgr.CloseFrame<TownFullMapFrame>(this, false);
		}

		// Token: 0x0400BC2D RID: 48173
		[UIObject("content")]
		private GameObject m_objMapRoot;

		// Token: 0x0400BC2E RID: 48174
		private TownMapFrame m_mapFrame;
	}
}
