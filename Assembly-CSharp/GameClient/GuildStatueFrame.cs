using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001655 RID: 5717
	internal class GuildStatueFrame : ClientFrame
	{
		// Token: 0x0600E0DE RID: 57566 RVA: 0x00398C7D File Offset: 0x0039707D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStatueFrame";
		}

		// Token: 0x0600E0DF RID: 57567 RVA: 0x00398C84 File Offset: 0x00397084
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.eStatueType = (StatueType)this.userData;
			}
			this.InitInterface();
		}

		// Token: 0x0600E0E0 RID: 57568 RVA: 0x00398CA8 File Offset: 0x003970A8
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600E0E1 RID: 57569 RVA: 0x00398CB0 File Offset: 0x003970B0
		private void ClearData()
		{
			this.eStatueType = StatueType.TownStatue;
		}

		// Token: 0x0600E0E2 RID: 57570 RVA: 0x00398CBC File Offset: 0x003970BC
		private void InitInterface()
		{
			if (this.eStatueType == StatueType.TownStatue)
			{
				this.mTitle.text = "城主雕像";
				this.mName.CustomActive(true);
				this.mViceName.CustomActive(false);
				this.mMemList.CustomActive(true);
				this.mViceMemList.CustomActive(false);
			}
			else if (this.eStatueType == StatueType.ViceTownStatue)
			{
				this.mTitle.text = "副城主雕像";
				this.mName.CustomActive(false);
				this.mViceName.CustomActive(true);
				this.mMemList.CustomActive(false);
				this.mViceMemList.CustomActive(true);
			}
		}

		// Token: 0x0600E0E3 RID: 57571 RVA: 0x00398D68 File Offset: 0x00397168
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mName = this.mBind.GetGameObject("Name");
			this.mViceName = this.mBind.GetGameObject("ViceName");
			this.mMemList = this.mBind.GetGameObject("MemList");
			this.mViceMemList = this.mBind.GetGameObject("ViceMemList");
		}

		// Token: 0x0600E0E4 RID: 57572 RVA: 0x00398E18 File Offset: 0x00397218
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTitle = null;
			this.mName = null;
			this.mViceName = null;
			this.mMemList = null;
			this.mViceMemList = null;
		}

		// Token: 0x0600E0E5 RID: 57573 RVA: 0x00398E6B File Offset: 0x0039726B
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<GuildStatueFrame>(this, false);
		}

		// Token: 0x040085C6 RID: 34246
		private StatueType eStatueType;

		// Token: 0x040085C7 RID: 34247
		private Button mBtClose;

		// Token: 0x040085C8 RID: 34248
		private Text mTitle;

		// Token: 0x040085C9 RID: 34249
		private GameObject mName;

		// Token: 0x040085CA RID: 34250
		private GameObject mViceName;

		// Token: 0x040085CB RID: 34251
		private GameObject mMemList;

		// Token: 0x040085CC RID: 34252
		private GameObject mViceMemList;
	}
}
