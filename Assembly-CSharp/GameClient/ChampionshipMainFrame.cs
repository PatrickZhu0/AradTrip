using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001506 RID: 5382
	public class ChampionshipMainFrame : ClientFrame
	{
		// Token: 0x0600D0F2 RID: 53490 RVA: 0x003391C1 File Offset: 0x003375C1
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Main/ChampionshipMainFrame";
		}

		// Token: 0x0600D0F3 RID: 53491 RVA: 0x003391C8 File Offset: 0x003375C8
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipMainView != null)
			{
				this.mChampionshipMainView.InitView();
			}
			this.InitComTalk();
		}

		// Token: 0x0600D0F4 RID: 53492 RVA: 0x003391F2 File Offset: 0x003375F2
		protected override void _OnCloseFrame()
		{
			CommonUtility.SetClientSystemTownFrameForbidFadeIn(false);
			this.DestroyComTalk();
		}

		// Token: 0x0600D0F5 RID: 53493 RVA: 0x00339200 File Offset: 0x00337600
		private void InitComTalk()
		{
			this._comTalk = ComTalk.Create(this.mTalkParent);
		}

		// Token: 0x0600D0F6 RID: 53494 RVA: 0x00339213 File Offset: 0x00337613
		private void DestroyComTalk()
		{
			if (this._comTalk != null)
			{
				ComTalk.Recycle();
				this._comTalk = null;
			}
		}

		// Token: 0x0600D0F7 RID: 53495 RVA: 0x00339232 File Offset: 0x00337632
		protected override void _bindExUI()
		{
			this.mChampionshipMainView = this.mBind.GetCom<ChampionshipMainView>("ChampionshipMainView");
			this.mTalkParent = this.mBind.GetGameObject("talkParent");
		}

		// Token: 0x0600D0F8 RID: 53496 RVA: 0x00339260 File Offset: 0x00337660
		protected override void _unbindExUI()
		{
			this.mChampionshipMainView = null;
			this.mTalkParent = null;
		}

		// Token: 0x04007A5C RID: 31324
		private ComTalk _comTalk;

		// Token: 0x04007A5D RID: 31325
		private ChampionshipMainView mChampionshipMainView;

		// Token: 0x04007A5E RID: 31326
		private GameObject mTalkParent;
	}
}
