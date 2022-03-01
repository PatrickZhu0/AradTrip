using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010A7 RID: 4263
	public class DungeonHellGuideFrame : ClientFrame
	{
		// Token: 0x0600A0C6 RID: 41158 RVA: 0x00207A62 File Offset: 0x00205E62
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Hell/DungeonHellGuide";
		}

		// Token: 0x0600A0C7 RID: 41159 RVA: 0x00207A69 File Offset: 0x00205E69
		protected override void _bindExUI()
		{
			this.mDesc = this.mBind.GetCom<Text>("desc");
			this.mCount = this.mBind.GetCom<Text>("count");
		}

		// Token: 0x0600A0C8 RID: 41160 RVA: 0x00207A97 File Offset: 0x00205E97
		protected override void _unbindExUI()
		{
			this.mDesc = null;
			this.mCount = null;
		}

		// Token: 0x0600A0C9 RID: 41161 RVA: 0x00207AA7 File Offset: 0x00205EA7
		public void SetDescription(string desc)
		{
			this.mDesc.text = desc;
		}

		// Token: 0x0600A0CA RID: 41162 RVA: 0x00207AB5 File Offset: 0x00205EB5
		public void SetLeftCount(int cnt)
		{
		}

		// Token: 0x0400594A RID: 22858
		private Text mDesc;

		// Token: 0x0400594B RID: 22859
		private Text mCount;
	}
}
