using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001717 RID: 5911
	internal class LegendItem : CachedNormalObject<LegendItemData>
	{
		// Token: 0x0600E84D RID: 59469 RVA: 0x003D6174 File Offset: 0x003D4574
		private void _OnMallItemBuyRes(MsgDATA msg)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(msg.bytes);
			if (worldMallBuyRet.code == 0U)
			{
				this.OnUpdate();
			}
			else
			{
				SystemNotifyManager.SystemNotify((int)worldMallBuyRet.code, string.Empty);
			}
		}

		// Token: 0x0600E84E RID: 59470 RVA: 0x003D61BC File Offset: 0x003D45BC
		public override void Initialize()
		{
			this.desc = Utility.FindComponent<Text>(this.goLocal, "Text", true);
			this.goItemParent = Utility.FindChild(this.goLocal, "Items");
			this.linkText = Utility.FindComponent<Text>(this.goLocal, "LinkText", true);
			this.goDesc = Utility.FindComponent<Text>(this.goLocal, "Go/Text", true);
			this.goDesc0 = Utility.FindComponent<Text>(this.goLocal, "Over/Text", true);
			this.imgGo = Utility.FindComponent<Image>(this.goLocal, "Go", true);
			this.btnGo = Utility.FindComponent<Button>(this.goLocal, "Go", true);
			this.goLine = Utility.FindChild(this.goLocal, "Line");
			this.comStateController = Utility.FindComponent<StateController>(this.goLocal, "LinkText", true);
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this._OnMallItemBuyRes));
			this._RecycleAllComItems();
			this.btnGo.onClick.AddListener(new UnityAction(this._OnClickGo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopRefreshSuccess, new ClientEventSystem.UIEventHandler(this._RebuildAllObjects));
		}

		// Token: 0x0600E84F RID: 59471 RVA: 0x003D6304 File Offset: 0x003D4704
		private void _RereshAllGoods(UIEvent uiEvent)
		{
			this.OnUpdate();
		}

		// Token: 0x0600E850 RID: 59472 RVA: 0x003D630C File Offset: 0x003D470C
		private void _RebuildAllObjects(UIEvent uiEvent)
		{
			this.OnUpdate();
		}

		// Token: 0x0600E851 RID: 59473 RVA: 0x003D6314 File Offset: 0x003D4714
		private void _RecycleAllComItems()
		{
			for (int i = 0; i < this.comItems.Count; i++)
			{
				ComItemManager.Destroy(this.comItems[i]);
			}
			this.comItems.Clear();
		}

		// Token: 0x0600E852 RID: 59474 RVA: 0x003D635C File Offset: 0x003D475C
		private void _LoadComItems()
		{
			int num = 0;
			while (num < base.Value.methodItem.ItemIds.Count && num < base.Value.methodItem.ItemCounts.Count)
			{
				ComItem comItem = ComItemManager.Create(this.goItemParent);
				if (null != comItem)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(base.Value.methodItem.ItemIds[num], 100, 0);
					if (itemData != null)
					{
						itemData.Count = base.Value.methodItem.ItemCounts[num];
					}
					comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
					this.comItems.Add(comItem);
				}
				num++;
			}
		}

		// Token: 0x0600E853 RID: 59475 RVA: 0x003D643C File Offset: 0x003D483C
		private void _OnClickGo()
		{
			if (base.Value != null && base.Value.methodItem != null)
			{
				if (this.callback != null)
				{
					this.callback.Invoke();
				}
				else
				{
					DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(base.Value.methodItem.LinkInfo, null, false);
				}
			}
		}

		// Token: 0x0600E854 RID: 59476 RVA: 0x003D649C File Offset: 0x003D489C
		private void _OnMatchSucceed(Match match, string orgText, LegendItemRegexType eMatchType, int isShowNumber)
		{
			if (eMatchType != LegendItemRegexType.LIRT_SHOP_GOODS)
			{
				if (eMatchType != LegendItemRegexType.LIRT_DUNGENDROP)
				{
					if (eMatchType == LegendItemRegexType.LIRT_MALL_GOODS)
					{
						int id = 0;
						if (int.TryParse(match.Groups[1].Value, out id))
						{
							MallItemTable mallItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(id, string.Empty, string.Empty);
							if (mallItem != null)
							{
								MallTypeTable mallTypeTable = null;
								Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MallTypeTable>();
								foreach (KeyValuePair<int, object> keyValuePair in table)
								{
									MallTypeTable mallTypeTable2 = keyValuePair.Value as MallTypeTable;
									if (mallTypeTable2.MoneyID == mallItem.moneytype && mallItem.type == (int)mallTypeTable2.MallType)
									{
										mallTypeTable = mallTypeTable2;
										break;
									}
								}
								int num = 0;
								int num2 = 0;
								if (mallTypeTable != null)
								{
									WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
									if (mallTypeTable.MoneyID != 0)
									{
										worldMallQueryItemReq.moneyType = (byte)mallTypeTable.MoneyID;
									}
									if (mallTypeTable.MallType == MallTypeTable.eMallType.SN_HOT)
									{
										worldMallQueryItemReq.tagType = 1;
									}
									else
									{
										worldMallQueryItemReq.tagType = 0;
										worldMallQueryItemReq.type = (byte)mallTypeTable.MallType;
										if (mallTypeTable.MallSubType.Count > 0 && num < mallTypeTable.MallSubType.Count && mallTypeTable.MallSubType[num] != MallTypeTable.eMallSubType.MST_NONE)
										{
											worldMallQueryItemReq.subType = (byte)mallTypeTable.MallSubType[num];
										}
										if (mallTypeTable.ClassifyJob == 1 && num2 > 0)
										{
											worldMallQueryItemReq.occu = (byte)num2;
										}
									}
									NetManager netManager = NetManager.Instance();
									netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
									DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMallQueryItemRet>(delegate(WorldMallQueryItemRet msgRet)
									{
										MallItemInfo mallItemInfo = null;
										for (int i = 0; i < msgRet.items.Length; i++)
										{
											if ((ulong)msgRet.items[i].itemid == (ulong)((long)mallItem.itemid))
											{
												mallItemInfo = msgRet.items[i];
												break;
											}
										}
										if (mallItemInfo != null)
										{
											this.linkText.text = this._GetMallDataLimitDesc(mallItem, mallItemInfo);
											this.callback = delegate()
											{
												Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItemInfo, string.Empty);
											};
										}
									}, true, 15f, null);
								}
							}
						}
					}
				}
				else
				{
					int num3 = 0;
					if (int.TryParse(match.Groups[1].Value, out num3))
					{
						DungeonDailyDropTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonDailyDropTable>(num3, string.Empty, string.Empty);
						if (tableItem != null)
						{
							StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
							stringBuilder.Append(LegendItem.counter_key_pre);
							stringBuilder.Append(num3);
							string a_strKey = stringBuilder.ToString();
							StringBuilderCache.Release(stringBuilder);
							int num4 = 0;
							int dailyLimit = tableItem.DailyLimit;
							CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(a_strKey);
							if (countInfo != null)
							{
								num4 = (int)countInfo.value;
							}
							num4 = IntMath.Max(0, num4);
							num4 = IntMath.Min(num4, dailyLimit);
							this.linkText.text = string.Format("{0}/{1}", num4, dailyLimit);
							if (this.linkText != null)
							{
								if (isShowNumber == 1)
								{
									this.linkText.gameObject.CustomActive(true);
								}
								else
								{
									this.linkText.gameObject.CustomActive(false);
								}
							}
							if (isShowNumber == 1)
							{
								if (num4 >= dailyLimit)
								{
									this.comStateController.Key = "over";
								}
								else
								{
									this.comStateController.Key = "normal";
								}
							}
							else
							{
								this.comStateController.Key = "normal";
							}
						}
					}
				}
			}
			else
			{
				int iGoodId = 0;
				if (int.TryParse(match.Groups[1].Value, out iGoodId))
				{
					ShopItemTable shopItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(iGoodId, string.Empty, string.Empty);
					if (shopItem != null)
					{
						ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(shopItem.ShopID);
						if (goodsDataFromShop != null)
						{
							this.linkText.text = this._GetShopDataLimitDesc(iGoodId, shopItem.ShopID);
							return;
						}
						this.linkText.text = string.Empty;
						DataManager<ShopDataManager>.GetInstance().OpenShop(shopItem.ShopID, 0, -1, delegate
						{
							this.linkText.text = this._GetShopDataLimitDesc(iGoodId, shopItem.ShopID);
						}, null, ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME, 0, -1);
					}
				}
			}
		}

		// Token: 0x0600E855 RID: 59477 RVA: 0x003D68E8 File Offset: 0x003D4CE8
		private void _ParseLinkText(string orgText, int isShowNumber)
		{
			this.comStateController.Key = "normal";
			this.linkText.text = string.Empty;
			this.callback = null;
			if (string.IsNullOrEmpty(orgText))
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				Match match = LegendItem.ms_regexs[i].Match(orgText);
				if (match.Success)
				{
					this._OnMatchSucceed(match, orgText, (LegendItemRegexType)i, isShowNumber);
					break;
				}
			}
		}

		// Token: 0x0600E856 RID: 59478 RVA: 0x003D6964 File Offset: 0x003D4D64
		private string _GetShopDataLimitDesc(int iGoodID, int iShopID)
		{
			ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(iShopID);
			if (goodsDataFromShop == null)
			{
				return string.Empty;
			}
			GoodsData goodsData = goodsDataFromShop.Goods.Find(delegate(GoodsData x)
			{
				int num2 = (x.ID == null) ? 0 : x.ID.Value;
				return num2 == iGoodID;
			});
			if (goodsData == null)
			{
				return string.Empty;
			}
			ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(iGoodID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.NumLimite < 0)
			{
				return string.Empty;
			}
			int numLimite = tableItem.NumLimite;
			int num = goodsData.LimitBuyTimes;
			num = numLimite - num;
			num = IntMath.Max(0, num);
			num = IntMath.Min(num, numLimite);
			if (num >= numLimite)
			{
				this.comStateController.Key = "over";
			}
			else
			{
				this.comStateController.Key = "normal";
			}
			return string.Format("{0}/{1}", num, numLimite);
		}

		// Token: 0x0600E857 RID: 59479 RVA: 0x003D6A68 File Offset: 0x003D4E68
		private string _GetMallDataLimitDesc(MallItemTable mallItem, MallItemInfo mallItemInfo)
		{
			if (mallItem != null && mallItemInfo != null)
			{
				bool flag = false;
				int leftLimitNum = Utility.GetLeftLimitNum(mallItemInfo, ref flag);
				int num = mallItem.limitnum - leftLimitNum;
				int limitnum = mallItem.limitnum;
				num = IntMath.Max(0, num);
				num = IntMath.Min(num, limitnum);
				if (num >= limitnum)
				{
					this.comStateController.Key = "over";
				}
				else
				{
					this.comStateController.Key = "normal";
				}
				return string.Format("{0}/{1}", num, limitnum);
			}
			return string.Empty;
		}

		// Token: 0x0600E858 RID: 59480 RVA: 0x003D6AF4 File Offset: 0x003D4EF4
		public override void UnInitialize()
		{
			if (null != this.btnGo)
			{
				this.btnGo.onClick.RemoveAllListeners();
				this.btnGo = null;
			}
			this._RecycleAllComItems();
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this._OnMallItemBuyRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopRefreshSuccess, new ClientEventSystem.UIEventHandler(this._RebuildAllObjects));
		}

		// Token: 0x0600E859 RID: 59481 RVA: 0x003D6B7C File Offset: 0x003D4F7C
		public override void OnUpdate()
		{
			if (base.Value != null && base.Value.methodItem != null)
			{
				this.desc.text = base.Value.methodItem.Title;
				this._RecycleAllComItems();
				this._LoadComItems();
				this._ParseLinkText(base.Value.methodItem.KeyValueDesc, base.Value.methodItem.IsShowNumber);
				if (base.Value.methodItem.ActionDesc.Count > 0)
				{
					this.goDesc.text = base.Value.methodItem.ActionDesc[0];
				}
				if (base.Value.methodItem.ActionDesc.Count > 1)
				{
					this.goDesc0.text = base.Value.methodItem.ActionDesc[1];
				}
				this.goLine.CustomActive(!base.Value.bFirst);
				ETCImageLoader.LoadSprite(ref this.imgGo, base.Value.methodItem.Icons[0], true);
			}
		}

		// Token: 0x04008CD2 RID: 36050
		public Text desc;

		// Token: 0x04008CD3 RID: 36051
		public GameObject goItemParent;

		// Token: 0x04008CD4 RID: 36052
		public Text linkText;

		// Token: 0x04008CD5 RID: 36053
		public Text goDesc;

		// Token: 0x04008CD6 RID: 36054
		public Text goDesc0;

		// Token: 0x04008CD7 RID: 36055
		public Image imgGo;

		// Token: 0x04008CD8 RID: 36056
		public Button btnGo;

		// Token: 0x04008CD9 RID: 36057
		public GameObject goLine;

		// Token: 0x04008CDA RID: 36058
		private List<ComItem> comItems = new List<ComItem>();

		// Token: 0x04008CDB RID: 36059
		private StateController comStateController;

		// Token: 0x04008CDC RID: 36060
		private static Regex[] ms_regexs = new Regex[]
		{
			new Regex("<type=goods id=(\\d+)/>"),
			new Regex("<type=dungendropid id=(\\d+)/>"),
			new Regex("<type=mallgoods id=(\\d+)/>")
		};

		// Token: 0x04008CDD RID: 36061
		private static string counter_key_pre = "dungeon_daily_";

		// Token: 0x04008CDE RID: 36062
		private UnityAction callback;
	}
}
