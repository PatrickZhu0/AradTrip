using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001811 RID: 6161
	public class AnniversaryPartyTalkFrame : ClientFrame
	{
		// Token: 0x0600F2B8 RID: 62136 RVA: 0x00417A88 File Offset: 0x00415E88
		protected sealed override void _bindExUI()
		{
			this.mNpcPic = this.mBind.GetCom<Image>("NpcPic");
			this.mTalk = this.mBind.GetCom<Text>("Talk");
			this.mFunctionUnlockDes = this.mBind.GetCom<Text>("FunctionUnlockDes");
			this.mNpcName = this.mBind.GetCom<Text>("NpcName");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0600F2B9 RID: 62137 RVA: 0x00417B30 File Offset: 0x00415F30
		protected sealed override void _unbindExUI()
		{
			this.mNpcPic = null;
			this.mTalk = null;
			this.mFunctionUnlockDes = null;
			this.mNpcName = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0600F2BA RID: 62138 RVA: 0x00417B8D File Offset: 0x00415F8D
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<AnniversaryPartyTalkFrame>(this, false);
		}

		// Token: 0x0600F2BB RID: 62139 RVA: 0x00417B9C File Offset: 0x00415F9C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Item/AnniversaryPartyTalkFrame";
		}

		// Token: 0x0600F2BC RID: 62140 RVA: 0x00417BA4 File Offset: 0x00415FA4
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			int id = (int)this.userData;
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.mNpcPic, tableItem.NpcBody, true);
				this.mNpcName.text = tableItem.NpcName;
			}
			this.mTalk.text = TR.Value("AnniversaryPartyTalk");
			this.mFunctionUnlockDes.text = TR.Value("AnniversaryPartyFunctionUnLockDes");
		}

		// Token: 0x0600F2BD RID: 62141 RVA: 0x00417C2D File Offset: 0x0041602D
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0400952D RID: 38189
		private Image mNpcPic;

		// Token: 0x0400952E RID: 38190
		private Text mTalk;

		// Token: 0x0400952F RID: 38191
		private Text mFunctionUnlockDes;

		// Token: 0x04009530 RID: 38192
		private Text mNpcName;

		// Token: 0x04009531 RID: 38193
		private Button mClose;
	}
}
