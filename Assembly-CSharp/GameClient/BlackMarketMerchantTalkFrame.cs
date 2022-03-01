using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A3C RID: 6716
	public class BlackMarketMerchantTalkFrame : ClientFrame
	{
		// Token: 0x060107EF RID: 67567 RVA: 0x004A52F0 File Offset: 0x004A36F0
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

		// Token: 0x060107F0 RID: 67568 RVA: 0x004A5398 File Offset: 0x004A3798
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

		// Token: 0x060107F1 RID: 67569 RVA: 0x004A53F5 File Offset: 0x004A37F5
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<BlackMarketMerchantTalkFrame>(this, false);
		}

		// Token: 0x060107F2 RID: 67570 RVA: 0x004A5404 File Offset: 0x004A3804
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/BlackMarketMerchantFrame/BlackMarketMerchantTalkFrame";
		}

		// Token: 0x060107F3 RID: 67571 RVA: 0x004A540C File Offset: 0x004A380C
		protected sealed override void _OnOpenFrame()
		{
			BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)BlackMarketMerchantDataManager.BlackMarketType, string.Empty, string.Empty);
			if (tableItem != null)
			{
				NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.NpcID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref this.mNpcPic, tableItem2.NpcBody, true);
					this.mNpcName.text = tableItem2.NpcName;
				}
			}
			this.mTalk.text = TR.Value("BlackMarketMerchantTalk");
			this.mFunctionUnlockDes.text = TR.Value("BlackMarketMerchantFunctionUnLockDes");
		}

		// Token: 0x060107F4 RID: 67572 RVA: 0x004A54A8 File Offset: 0x004A38A8
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0400A7BC RID: 42940
		private Image mNpcPic;

		// Token: 0x0400A7BD RID: 42941
		private Text mTalk;

		// Token: 0x0400A7BE RID: 42942
		private Text mFunctionUnlockDes;

		// Token: 0x0400A7BF RID: 42943
		private Text mNpcName;

		// Token: 0x0400A7C0 RID: 42944
		private Button mClose;
	}
}
