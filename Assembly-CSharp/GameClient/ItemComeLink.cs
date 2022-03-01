using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000076 RID: 118
	internal class ItemComeLink : MonoBehaviour
	{
		// Token: 0x06000284 RID: 644 RVA: 0x000131B8 File Offset: 0x000115B8
		private void Start()
		{
			this.button = base.GetComponent<Button>();
			if (this.button == null)
			{
				this.button = base.gameObject.AddComponent<Button>();
			}
			if (this.button != null)
			{
				this.button.onClick.AddListener(new UnityAction(this.OnClickLink));
			}
			this.comFrameBinder = base.GetComponentInParent<ClientFrameBinder>();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001322C File Offset: 0x0001162C
		private void OnDestroy()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button = null;
			}
			this.onClick = null;
			ItemComeLink.ms_co_purchase = null;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00013264 File Offset: 0x00011664
		public static bool LinkCommonPurchase(int iNeedCount, int iLinkID, ComLinkFrame.OnClick onClick, bool bIgnoreConfirm, UnityAction onFailed)
		{
			QuickBuyTable item = Singleton<TableManager>.GetInstance().GetTableItem<QuickBuyTable>(iLinkID, string.Empty, string.Empty);
			if (item == null || iNeedCount <= 0)
			{
				return false;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(item.ID);
			ItemData commonItemTableDataByID2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(item.CostItemID);
			if (commonItemTableDataByID == null || commonItemTableDataByID2 == null)
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return false;
			}
			if (!bIgnoreConfirm)
			{
				string text = string.Format(TR.Value("common_link_hint"), new object[]
				{
					commonItemTableDataByID.GetColorName(string.Empty, false),
					iNeedCount,
					iNeedCount * item.CostNum,
					commonItemTableDataByID2.GetColorName(string.Empty, false)
				});
				ItemComeLink.multiple = item.multiple;
				MallItemMultipleIntegralData mallItemMultipleIntegralData = DataManager<MallNewDataManager>.GetInstance().CheckMallItemMultipleIntegral(item.ID);
				if (mallItemMultipleIntegralData != null)
				{
					ItemComeLink.multiple += mallItemMultipleIntegralData.multiple;
					ItemComeLink.endTime = mallItemMultipleIntegralData.endTime;
				}
				if (ItemComeLink.endTime > 0)
				{
					ItemComeLink.isTimer = ((long)ItemComeLink.endTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()) > 0L);
				}
				if (ItemComeLink.multiple > 0)
				{
					int num = MallNewUtility.GetTicketConvertIntergalNumnber(iNeedCount * item.CostNum) * ItemComeLink.multiple;
					string str = string.Empty;
					if (ItemComeLink.multiple <= 1)
					{
						str = TR.Value("mall_fast_buy_intergral_single_multiple_desc", num);
					}
					else
					{
						str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num, ItemComeLink.multiple, string.Empty);
					}
					if (ItemComeLink.isTimer)
					{
						str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num, ItemComeLink.multiple, TR.Value("mall_fast_buy_intergral_many_multiple_remain_time_desc", Function.SetShowTimeDay(ItemComeLink.endTime)));
					}
					text += str;
				}
				CommonPurChaseHintFrame.Open(text, TR.Value("common_link_hint_ok"), TR.Value("common_link_hint_cancel"), delegate()
				{
					ItemComeLink._OnClickConfirm(iNeedCount, item, iLinkID, onClick, onFailed);
				}, delegate()
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				});
			}
			else
			{
				ItemComeLink._OnClickConfirm(iNeedCount, item, iLinkID, onClick, onFailed);
			}
			return true;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00013508 File Offset: 0x00011908
		public static void _OnClickConfirm(int iNeedCount, QuickBuyTable item, int iLinkID, ComLinkFrame.OnClick onClick, UnityAction onFailed)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(item.CostItemID, true);
			int iCostCount = iNeedCount * item.CostNum;
			if (ownedItemCount < iCostCount)
			{
				if (!ItemComeLink.IsLinkMoney(item.CostItemID, onClick, onFailed))
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				}
			}
			else
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
				{
					nMoneyID = item.CostItemID,
					nCount = iCostCount
				}, delegate
				{
					if (ItemComeLink.multiple > 0)
					{
						string text = string.Empty;
						if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
						{
							text = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
							string content = text;
							if (ItemComeLink.<>f__mg$cache0 == null)
							{
								ItemComeLink.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content, ItemComeLink.<>f__mg$cache0, delegate
							{
								ItemComeLink.StartCoroutineAnsyCommonPurchase(iNeedCount, iLinkID, onClick);
							});
						}
						else
						{
							int num = MallNewUtility.GetTicketConvertIntergalNumnber(iCostCount) * ItemComeLink.multiple;
							int num2 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num;
							if (num2 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
							{
								text = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
								string content2 = text;
								if (ItemComeLink.<>f__mg$cache1 == null)
								{
									ItemComeLink.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
								}
								MallNewUtility.CommonIntergralMallPopupWindow(content2, ItemComeLink.<>f__mg$cache1, delegate
								{
									ItemComeLink.StartCoroutineAnsyCommonPurchase(iNeedCount, iLinkID, onClick);
								});
							}
							else
							{
								ItemComeLink.StartCoroutineAnsyCommonPurchase(iNeedCount, iLinkID, onClick);
							}
						}
					}
					else
					{
						ItemComeLink.StartCoroutineAnsyCommonPurchase(iNeedCount, iLinkID, onClick);
					}
				}, "common_money_cost", delegate
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				});
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000135EB File Offset: 0x000119EB
		private static void StartCoroutineAnsyCommonPurchase(int iNeedCount, int iLinkID, ComLinkFrame.OnClick onClick)
		{
			if (ItemComeLink.ms_co_purchase == null)
			{
				ItemComeLink.ms_co_purchase = MonoSingleton<GameFrameWork>.instance.StartCoroutine(ItemComeLink._AnsyCommonPurchase(iNeedCount, iLinkID, onClick));
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00013610 File Offset: 0x00011A10
		private static IEnumerator _AnsyCommonPurchase(int iNeedCount, int iLinkID, ComLinkFrame.OnClick onClick)
		{
			MessageEvents events = new MessageEvents();
			SceneQuickBuyReq req = new SceneQuickBuyReq();
			SceneQuickBuyRes res = new SceneQuickBuyRes();
			req.type = 1;
			req.param1 = (ulong)((long)iLinkID);
			req.param2 = (ulong)iNeedCount;
			yield return MessageUtility.Wait<SceneQuickBuyReq, SceneQuickBuyRes>(ServerType.GATE_SERVER, events, req, res, true, 10f);
			if (!events.IsAllMessageReceived())
			{
				Logger.LogErrorFormat("快速购买失败!! 网络连接超时!!!", new object[0]);
				ItemComeLink.ms_co_purchase = null;
				yield break;
			}
			if (res.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
				ItemComeLink.ms_co_purchase = null;
				yield break;
			}
			if (onClick != null)
			{
				onClick();
			}
			ItemComeLink.ms_co_purchase = null;
			yield break;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0001363C File Offset: 0x00011A3C
		public static bool IsLinkMoney(int iItemLinkID, ComLinkFrame.OnClick onClick = null, UnityAction onFailed = null)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iItemLinkID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.Type != ItemTable.eType.INCOME)
			{
				return false;
			}
			if (tableItem.SubType == ItemTable.eSubType.BindPOINT || tableItem.SubType == ItemTable.eSubType.POINT)
			{
				SystemNotifyManager.SystemNotify(1207, delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				}, delegate()
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
				});
				return true;
			}
			if (tableItem.SubType == ItemTable.eSubType.GOLD)
			{
				SystemNotifyManager.SystemNotify(2302005, string.Empty);
				return true;
			}
			return false;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000136E0 File Offset: 0x00011AE0
		public static bool TryDirectlyJump2Link(int iItemLinkID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iItemLinkID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.bNeedJump == 1 && tableItem.ComeLink.Count > 0)
			{
				AcquiredMethodTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(tableItem.ComeLink[0], string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.IsLink != 0)
				{
					DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem2.LinkInfo, null, false);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00013770 File Offset: 0x00011B70
		public static void OnLink(int iItemLinkID, int iNeedCount, bool bNotEnough = true, ComLinkFrame.OnClick onClick = null, bool bLinkMoney = false, bool bTryJumpDirectly = false, bool bIgnoreCommonPurchaseConfirm = false, UnityAction onFailed = null, string titleContent = "")
		{
			if (iNeedCount > 0 && bNotEnough)
			{
				if (bLinkMoney && ItemComeLink.IsLinkMoney(iItemLinkID, onClick, null))
				{
					return;
				}
				if (ItemComeLink.LinkCommonPurchase(iNeedCount, iItemLinkID, onClick, bIgnoreCommonPurchaseConfirm, onFailed))
				{
					return;
				}
			}
			if (bTryJumpDirectly && ItemComeLink.TryDirectlyJump2Link(iItemLinkID))
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iItemLinkID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.ID);
				if (commonItemTableDataByID != null)
				{
					ComLinkFrame.ComLinkFrameData comLinkFrameData = new ComLinkFrame.ComLinkFrameData();
					comLinkFrameData.item = tableItem;
					comLinkFrameData.bOrgLink = true;
					comLinkFrameData.bNotEnough = bNotEnough;
					comLinkFrameData.onClick = onClick;
					comLinkFrameData.titleContent = titleContent;
					if (!bNotEnough)
					{
						comLinkFrameData.title = string.Format("{0} <color=#FFFFFFFF>获取途径</color>", commonItemTableDataByID.GetColorName(string.Empty, false));
					}
					else
					{
						comLinkFrameData.title = string.Format("{0} <color=#FFFFFFFF>不足</color>", commonItemTableDataByID.GetColorName(string.Empty, false));
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ComLinkFrame>(FrameLayer.Middle, comLinkFrameData, string.Empty);
				}
				return;
			}
			AcquiredMethodTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(iItemLinkID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				ComLinkFrame.ComLinkFrameData comLinkFrameData2 = new ComLinkFrame.ComLinkFrameData();
				comLinkFrameData2.item = null;
				comLinkFrameData2.bOrgLink = false;
				comLinkFrameData2.linkItem = tableItem2;
				comLinkFrameData2.bNotEnough = bNotEnough;
				comLinkFrameData2.onClick = onClick;
				if (!bNotEnough)
				{
					comLinkFrameData2.title = string.Format("<color=#00FF1Eff>{0}</color> <color=#FFFFFFFF>获取途径</color>", tableItem2.Name);
				}
				else
				{
					comLinkFrameData2.title = string.Format("<color=#FFFFFFFF>{0}不足</color>", tableItem2.Name);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ComLinkFrame>(FrameLayer.Middle, comLinkFrameData2, string.Empty);
				return;
			}
			Logger.LogErrorFormat("can not find item which id is {0}!", new object[]
			{
				iItemLinkID
			});
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00013928 File Offset: 0x00011D28
		public void OnClickLink()
		{
			if (this.onEvent != null)
			{
				this.onEvent.Invoke();
			}
			ItemComeLink.OnLink(this.iItemLinkID, 0, this.bNotEnough, delegate
			{
				if (this.onClick != null)
				{
					this.onClick();
				}
				if (this.comFrameBinder != null)
				{
					this.comFrameBinder.CloseFrame(false);
				}
			}, false, true, false, null, string.Empty);
		}

		// Token: 0x04000278 RID: 632
		public int iItemLinkID;

		// Token: 0x04000279 RID: 633
		public bool bNotEnough;

		// Token: 0x0400027A RID: 634
		public ComLinkFrame.OnClick onClick;

		// Token: 0x0400027B RID: 635
		public UnityEvent onEvent;

		// Token: 0x0400027C RID: 636
		private Button button;

		// Token: 0x0400027D RID: 637
		private ClientFrameBinder comFrameBinder;

		// Token: 0x0400027E RID: 638
		private static int multiple;

		// Token: 0x0400027F RID: 639
		private static int endTime;

		// Token: 0x04000280 RID: 640
		private static bool isTimer;

		// Token: 0x04000281 RID: 641
		public static Coroutine ms_co_purchase;

		// Token: 0x04000282 RID: 642
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x04000283 RID: 643
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}
