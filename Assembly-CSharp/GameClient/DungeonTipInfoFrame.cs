using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010BC RID: 4284
	[LoggerModel("Chapter")]
	public class DungeonTipInfoFrame : ClientFrame
	{
		// Token: 0x0600A1CC RID: 41420 RVA: 0x0020F8A4 File Offset: 0x0020DCA4
		public sealed override string GetPrefabPath()
		{
			return "UI/Prefabs/Battle/DungeonTipUnitInfo";
		}

		// Token: 0x0600A1CD RID: 41421 RVA: 0x0020F8AB File Offset: 0x0020DCAB
		protected sealed override void _OnLoadPrefabFinish()
		{
		}

		// Token: 0x0600A1CE RID: 41422 RVA: 0x0020F8AD File Offset: 0x0020DCAD
		protected sealed override void _OnOpenFrame()
		{
			this._updateRoot();
		}

		// Token: 0x0600A1CF RID: 41423 RVA: 0x0020F8B5 File Offset: 0x0020DCB5
		protected sealed override void _OnCloseFrame()
		{
			this.mRoot = null;
		}

		// Token: 0x0600A1D0 RID: 41424 RVA: 0x0020F8BE File Offset: 0x0020DCBE
		private new void _updateRoot()
		{
			if (null == this.mRoot)
			{
				this.mRoot = Utility.FindGameObject(this.frame, "Root", true);
			}
		}

		// Token: 0x04005A44 RID: 23108
		private GameObject mRoot;
	}
}
