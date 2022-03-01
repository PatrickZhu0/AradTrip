using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200457F RID: 17791
	internal class LinkManager : DataManager<LinkManager>
	{
		// Token: 0x06018D2E RID: 101678 RVA: 0x007C2787 File Offset: 0x007C0B87
		public override void Initialize()
		{
			this.RegisterNetHandler();
		}

		// Token: 0x06018D2F RID: 101679 RVA: 0x007C278F File Offset: 0x007C0B8F
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			this.m_kCurLinkItem = null;
		}

		// Token: 0x06018D30 RID: 101680 RVA: 0x007C279E File Offset: 0x007C0B9E
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(600803U, new Action<MsgDATA>(this.OnRecvWorldChatLinkDataRet));
		}

		// Token: 0x06018D31 RID: 101681 RVA: 0x007C27B6 File Offset: 0x007C0BB6
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(600803U, new Action<MsgDATA>(this.OnRecvWorldChatLinkDataRet));
		}

		// Token: 0x06018D32 RID: 101682 RVA: 0x007C27CE File Offset: 0x007C0BCE
		private void OnRecvWorldChatLinkDataRet(MsgDATA msg)
		{
			LinkManager.ChatLinkDecoder.Decode(msg);
		}

		// Token: 0x06018D33 RID: 101683 RVA: 0x007C27D8 File Offset: 0x007C0BD8
		private void _OnAddLinkItem(ItemData itemData)
		{
			this.m_kCurLinkItem = itemData;
			if (this.onAddLinkItem != null)
			{
				this.onAddLinkItem(itemData);
			}
			List<TipFuncButon> list = new List<TipFuncButon>();
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.ComeLink != null && tableItem.ComeLink.Count > 0)
			{
				TipFuncButon item = new TipFuncButon
				{
					text = TR.Value("tip_try_get_item"),
					callback = new OnTipFuncClicked(this._OnTryGetItem)
				};
				list.Add(item);
			}
			if (this.AttachDatas == null)
			{
				EquipSuitObj a_itemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().CreateEmptyEquipSuitObj(itemData.SuitID);
				if (list.Count > 0)
				{
					DataManager<ItemTipManager>.GetInstance().ShowOtherPlayerTip(this.m_kCurLinkItem, a_itemSuitObj, list, 4, true);
				}
				else
				{
					DataManager<ItemTipManager>.GetInstance().ShowOtherPlayerTip(this.m_kCurLinkItem, a_itemSuitObj, null, 4, true);
				}
			}
			else
			{
				EquipSuitObj a_itemSuitObj2 = null;
				this.AttachDatas.m_dictEquipSuitObjs.TryGetValue(this.m_kCurLinkItem.SuitID, out a_itemSuitObj2);
				if (list.Count > 0)
				{
					DataManager<ItemTipManager>.GetInstance().ShowOtherPlayerTip(this.m_kCurLinkItem, a_itemSuitObj2, list, 4, true);
				}
				else
				{
					DataManager<ItemTipManager>.GetInstance().ShowOtherPlayerTip(this.m_kCurLinkItem, a_itemSuitObj2, null, 4, true);
				}
				this.AttachDatas = null;
			}
		}

		// Token: 0x06018D34 RID: 101684 RVA: 0x007C293C File Offset: 0x007C0D3C
		private void _OnTryGetItem(ItemData item, object data)
		{
			if (item != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				ItemComeLink.OnLink(item.TableID, 0, false, null, false, tableItem.bNeedJump > 0, false, null, string.Empty);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x04011E25 RID: 73253
		public LinkManager.OnAddLinkItem onAddLinkItem;

		// Token: 0x04011E26 RID: 73254
		private ItemData m_kCurLinkItem;

		// Token: 0x04011E27 RID: 73255
		public ActorShowEquipData AttachDatas;

		// Token: 0x02004580 RID: 17792
		// (Invoke) Token: 0x06018D36 RID: 101686
		public delegate void OnAddLinkItem(ItemData itemData);

		// Token: 0x02004581 RID: 17793
		private class ItemLinkData
		{
			// Token: 0x04011E28 RID: 73256
			public byte type;

			// Token: 0x04011E29 RID: 73257
			public List<ItemData> itemDatas;
		}

		// Token: 0x02004582 RID: 17794
		private class ChatLinkDecoder
		{
			// Token: 0x06018D3B RID: 101691 RVA: 0x007C29A4 File Offset: 0x007C0DA4
			public static byte Decode(MsgDATA msgData)
			{
				int iPos = 0;
				byte b = 0;
				BaseDLL.decode_int8(msgData.bytes, ref iPos, ref b);
				if (b != 73)
				{
					if (b == 82)
					{
						LinkManager.ChatLinkDecoder.DecodeRetinueLink(iPos, msgData);
					}
				}
				else
				{
					LinkManager.ChatLinkDecoder.DecodeItemLink(iPos, msgData);
				}
				return 0;
			}

			// Token: 0x06018D3C RID: 101692 RVA: 0x007C29F4 File Offset: 0x007C0DF4
			private static void DecodeItemLink(int iPos, MsgDATA msgData)
			{
				List<Item> list = ItemDecoder.Decode(msgData.bytes, ref iPos, msgData.bytes.Length, false);
				if (list != null && list.Count > 0)
				{
					ItemData itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(list[0]);
					if (itemData != null)
					{
						DataManager<LinkManager>.GetInstance()._OnAddLinkItem(itemData);
					}
				}
			}

			// Token: 0x06018D3D RID: 101693 RVA: 0x007C2A50 File Offset: 0x007C0E50
			private static void DecodeRetinueLink(int iPos, MsgDATA msgData)
			{
				RetinueInfo retinueInfo = new RetinueInfo();
				retinueInfo.decode(msgData.bytes, ref iPos);
			}
		}
	}
}
