using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001A3D RID: 6717
	public class BlackMarketMerchantTradeFrame : ClientFrame
	{
		// Token: 0x060107F6 RID: 67574 RVA: 0x004A54B2 File Offset: 0x004A38B2
		protected sealed override void _bindExUI()
		{
			this.mBlackMarketMerchanTradeView = this.mBind.GetCom<BlackMarketMerchantTradeView>("BlackMarketMerchanTradeView");
		}

		// Token: 0x060107F7 RID: 67575 RVA: 0x004A54CA File Offset: 0x004A38CA
		protected sealed override void _unbindExUI()
		{
			this.mBlackMarketMerchanTradeView = null;
		}

		// Token: 0x060107F8 RID: 67576 RVA: 0x004A54D3 File Offset: 0x004A38D3
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/BlackMarketMerchantFrame/BlackMarketMerchanTradeSettingFrame";
		}

		// Token: 0x060107F9 RID: 67577 RVA: 0x004A54DC File Offset: 0x004A38DC
		protected sealed override void _OnOpenFrame()
		{
			this.mData = (this.userData as ApplyTradData);
			if (this.mData != null)
			{
				this.mBlackMarketMerchanTradeView.InitView(this.mData, new OnItemSelect(this.OnItemSelect), new OnSetPrice(this.OnSetPrice), new UnityAction(this.OnConfirmClick));
			}
		}

		// Token: 0x060107FA RID: 67578 RVA: 0x004A553A File Offset: 0x004A393A
		private void OnItemSelect(ulong guid)
		{
			this.GUID = guid;
		}

		// Token: 0x060107FB RID: 67579 RVA: 0x004A5543 File Offset: 0x004A3943
		private void OnSetPrice(uint price)
		{
			this.mPrice = price;
		}

		// Token: 0x060107FC RID: 67580 RVA: 0x004A554C File Offset: 0x004A394C
		private void OnConfirmClick()
		{
			if (this.GUID == 0UL)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_selectEquip"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.GUID);
			if (item == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_selectEquip"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (item.bLocked)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_bLockEquip"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (item.Type == ItemTable.eType.EQUIP && item.DeadTimestamp > 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_deadTimestamp"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (item.AuctionCoolTimeStamp > 0U && item.AuctionCoolTimeStamp > DataManager<TimeManager>.GetInstance().GetServerTime())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_auctionCooTimestamp"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (item.EquipType == EEquipType.ET_REDMARK)
			{
				string msgContent = TR.Value("growth_equip_desc", "确定要申请交易吗");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnOnSendWorldBlackMarketAuctionReq(this.mData);
				}, null, 0f, false);
			}
			else
			{
				this.OnOnSendWorldBlackMarketAuctionReq(this.mData);
			}
		}

		// Token: 0x060107FD RID: 67581 RVA: 0x004A565C File Offset: 0x004A3A5C
		private void OnOnSendWorldBlackMarketAuctionReq(ApplyTradData mData)
		{
			if (mData.mInfo.back_buy_type == 1)
			{
				DataManager<BlackMarketMerchantDataManager>.GetInstance().OnSendWorldBlackMarketAuctionReq(mData.mInfo.guid, this.GUID, mData.mInfo.price);
			}
			else
			{
				if (this.mPrice == 0U)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("blackMarketMerchan_inputPrice"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				DataManager<BlackMarketMerchantDataManager>.GetInstance().OnSendWorldBlackMarketAuctionReq(mData.mInfo.guid, this.GUID, this.mPrice);
			}
			base.Close(false);
		}

		// Token: 0x060107FE RID: 67582 RVA: 0x004A56E9 File Offset: 0x004A3AE9
		protected sealed override void _OnCloseFrame()
		{
			this.mData = null;
			this.GUID = 0UL;
			this.mPrice = 0U;
		}

		// Token: 0x0400A7C1 RID: 42945
		private BlackMarketMerchantTradeView mBlackMarketMerchanTradeView;

		// Token: 0x0400A7C2 RID: 42946
		private ApplyTradData mData;

		// Token: 0x0400A7C3 RID: 42947
		private ulong GUID;

		// Token: 0x0400A7C4 RID: 42948
		private uint mPrice;
	}
}
