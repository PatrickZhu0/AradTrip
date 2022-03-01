using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001229 RID: 4649
	public class CostItemManager : DataManager<CostItemManager>
	{
		// Token: 0x17001AC1 RID: 6849
		// (get) Token: 0x0600B2CC RID: 45772 RVA: 0x0027AD53 File Offset: 0x00279153
		// (set) Token: 0x0600B2CD RID: 45773 RVA: 0x0027AD5B File Offset: 0x0027915B
		public bool isNotify
		{
			get
			{
				return this.m_bNotify;
			}
			set
			{
				this.m_bNotify = value;
			}
		}

		// Token: 0x0600B2CE RID: 45774 RVA: 0x0027AD64 File Offset: 0x00279164
		public override void Initialize()
		{
			this.ClearData();
		}

		// Token: 0x0600B2CF RID: 45775 RVA: 0x0027AD6C File Offset: 0x0027916C
		public override void Clear()
		{
			this.ClearData();
		}

		// Token: 0x0600B2D0 RID: 45776 RVA: 0x0027AD74 File Offset: 0x00279174
		private void ClearData()
		{
			this.isNotify = true;
			this._isNotShowBindTicketWithCreditTicketTipFrame = false;
			this._isNotShowBindTicketWithCreditTicketAndTicketTipFrame = false;
			this._isNotShowCreditTicketOnlyTipFrame = false;
			this._isNotShowCreditTicketAndTicketTipFrame = false;
		}

		// Token: 0x0600B2D1 RID: 45777 RVA: 0x0027AD9C File Offset: 0x0027919C
		public void TryCostMoneiesDefault(List<CostItemManager.CostInfo> a_arrCostInfos, Action a_delDefaultCanCost, Action a_cancel = null, string a_strDefaultCanCostDesc = "common_money_cost")
		{
			List<CostItemManager.CostInfo> list = new List<CostItemManager.CostInfo>();
			int num = 0;
			for (int i = 0; i < a_arrCostInfos.Count; i++)
			{
				CostItemManager.CostInfo costInfo = a_arrCostInfos[i];
				if (costInfo.IsValid())
				{
					List<CostItemManager.CostInfo> list2 = this._CalculateRealCostInfos(costInfo);
					int num2 = 0;
					for (int j = 0; j < list2.Count; j++)
					{
						num2 += list2[j].nCount;
					}
					if (num2 < costInfo.nCount)
					{
						this.CommonCannotCostMoneyHandle(costInfo, list2.ToArray());
						return;
					}
					if (this._IsIncomeType(costInfo.nMoneyID))
					{
						list.AddRange(list2);
						num++;
					}
				}
			}
			if (list.Count > num && this.isNotify)
			{
				CostItemManager.CostInfo[] a_infos = list.ToArray();
				CostItemNotifyData costItemNotifyData = new CostItemNotifyData();
				costItemNotifyData.strContent = TR.Value(a_strDefaultCanCostDesc, this._GetMainCostMoneiesDesc(a_infos), this._GetEqualCostMoneiesDesc(a_infos));
				costItemNotifyData.delOnOkCallback = delegate()
				{
					if (a_delDefaultCanCost != null)
					{
						for (int l = 0; l < a_arrCostInfos.Count; l++)
						{
							int nMoneyID2 = a_arrCostInfos[l].nMoneyID;
							if ((nMoneyID2 == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT) || nMoneyID2 == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
							{
								return;
							}
						}
						a_delDefaultCanCost();
					}
				};
				costItemNotifyData.delOnCancelCallback = delegate()
				{
					if (a_cancel != null)
					{
						a_cancel();
					}
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<CostItemNotifyFrame>(FrameLayer.Middle, costItemNotifyData, string.Empty);
			}
			else if (a_delDefaultCanCost != null)
			{
				for (int k = 0; k < a_arrCostInfos.Count; k++)
				{
					int nMoneyID = a_arrCostInfos[k].nMoneyID;
					if ((nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT) || nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
					{
						return;
					}
				}
				a_delDefaultCanCost();
			}
		}

		// Token: 0x0600B2D2 RID: 45778 RVA: 0x0027AF84 File Offset: 0x00279384
		public void TryCostMoneyDefault(CostItemManager.CostInfo a_costInfo, Action a_delDefaultCanCost, string a_strDefaultCanCostDesc = "common_money_cost", Action a_cancel = null)
		{
			if (!a_costInfo.IsValid())
			{
				return;
			}
			if (a_costInfo.IsCreditPointDeduction && (a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)))
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_CREDIT_POINT);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, false);
				if (ownedItemCount > 0)
				{
					this.TryCostMoneyDefaultByPointOrBindPointWithCreditTicket(a_costInfo, a_delDefaultCanCost, a_cancel);
					return;
				}
			}
			List<CostItemManager.CostInfo> list = this._CalculateRealCostInfos(a_costInfo);
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				num += list[i].nCount;
			}
			if (num < a_costInfo.nCount)
			{
				if (a_cancel != null)
				{
					a_cancel();
				}
				this.CommonCannotCostMoneyHandle(a_costInfo, list.ToArray());
			}
			else if ((this._IsIncomeType(a_costInfo.nMoneyID) || this._IsTicketType(a_costInfo.nMoneyID)) && list.Count > 1 && this.isNotify)
			{
				CostItemManager.CostInfo[] a_infos = list.ToArray();
				CostItemNotifyData costItemNotifyData = new CostItemNotifyData();
				costItemNotifyData.strContent = TR.Value(a_strDefaultCanCostDesc, this._GetMainCostMoneiesDesc(a_infos), this._GetEqualCostMoneiesDesc(a_infos));
				costItemNotifyData.delOnOkCallback = delegate()
				{
					if (a_delDefaultCanCost != null)
					{
						if ((a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
						{
							return;
						}
						a_delDefaultCanCost();
					}
				};
				costItemNotifyData.delOnCancelCallback = delegate()
				{
					if (a_cancel != null)
					{
						a_cancel();
					}
				};
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<CostItemNotifyFrame>(FrameLayer.Middle, costItemNotifyData, string.Empty);
			}
			else if (a_delDefaultCanCost != null)
			{
				if ((a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				a_delDefaultCanCost();
			}
		}

		// Token: 0x0600B2D3 RID: 45779 RVA: 0x0027B1CC File Offset: 0x002795CC
		private void TryCostMoneyDefaultByPointOrBindPointWithCreditTicket(CostItemManager.CostInfo costInfo, Action canCostAction = null, Action cancelAction = null)
		{
			if (costInfo == null)
			{
				return;
			}
			int nMoneyID = costInfo.nMoneyID;
			int nCount = costInfo.nCount;
			int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
			int moneyIDByType2 = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			int moneyIDByType3 = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_CREDIT_POINT);
			if (nMoneyID == moneyIDByType)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(nMoneyID, false);
				if (ownedItemCount >= nCount)
				{
					this.DoCanCostAction(canCostAction);
				}
				else
				{
					int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType3, false);
					if (ownedItemCount + ownedItemCount2 >= nCount)
					{
						if (this._isNotShowBindTicketWithCreditTicketTipFrame)
						{
							this.DoCanCostAction(canCostAction);
						}
						else
						{
							int num = nCount - ownedItemCount;
							string tipContent = TR.Value("Bind_Ticket_With_Credit_Ticket_Format", ownedItemCount, num);
							CommonUtility.OnShowCommonMsgBoxWithToggleButton(tipContent, new OnCommonMsgBoxToggleClick(this.OnUpdateShowBindTicketWithCreditTicketTip), delegate
							{
								this.DoCancelCostAction(cancelAction);
							}, delegate
							{
								this.DoCanCostAction(canCostAction);
							});
						}
					}
					else
					{
						int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType2, false);
						if (ownedItemCount + ownedItemCount2 + ownedItemCount3 >= nCount)
						{
							if (this._isNotShowBindTicketWithCreditTicketAndTicketTipFrame)
							{
								this.DoCanCostAction(canCostAction);
							}
							else
							{
								int num2 = nCount - ownedItemCount - ownedItemCount2;
								string tipContent2 = TR.Value("Bind_Ticket_With_Credit_Ticket_And_Ticket_Format", ownedItemCount, ownedItemCount2, num2);
								CommonUtility.OnShowCommonMsgBoxWithToggleButton(tipContent2, new OnCommonMsgBoxToggleClick(this.OnUpdateShowBindTicketWithCreditTicketAndTicketTip), delegate
								{
									this.DoCancelCostAction(cancelAction);
								}, delegate
								{
									this.DoCanCostAction(canCostAction);
								});
							}
						}
						else
						{
							this.ShowJumpToVipFrameTip();
						}
					}
				}
			}
			else
			{
				int ownedItemCount4 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType3, false);
				if (ownedItemCount4 >= nCount)
				{
					if (this._isNotShowCreditTicketOnlyTipFrame)
					{
						this.DoCanCostAction(canCostAction);
					}
					else
					{
						string tipContent3 = TR.Value("Ticket_Just_With_Credit_Ticket_Format", ownedItemCount4);
						CommonUtility.OnShowCommonMsgBoxWithToggleButton(tipContent3, new OnCommonMsgBoxToggleClick(this.OnUpdateShowCreditTicketOnlyTip), delegate
						{
							this.DoCancelCostAction(cancelAction);
						}, delegate
						{
							this.DoCanCostAction(canCostAction);
						});
					}
				}
				else
				{
					int ownedItemCount5 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType2, false);
					if (ownedItemCount4 + ownedItemCount5 >= nCount)
					{
						if (this._isNotShowCreditTicketAndTicketTipFrame)
						{
							this.DoCanCostAction(canCostAction);
						}
						else
						{
							int num3 = nCount - ownedItemCount4;
							string tipContent4 = TR.Value("Ticket_Just_With_Credit_Ticket_And_Ticket_Format", ownedItemCount4, num3);
							CommonUtility.OnShowCommonMsgBoxWithToggleButton(tipContent4, new OnCommonMsgBoxToggleClick(this.OnUpdateShowCreditTicketAndTicketTip), delegate
							{
								this.DoCancelCostAction(cancelAction);
							}, delegate
							{
								this.DoCanCostAction(canCostAction);
							});
						}
					}
					else
					{
						this.ShowJumpToVipFrameTip();
					}
				}
			}
		}

		// Token: 0x0600B2D4 RID: 45780 RVA: 0x0027B489 File Offset: 0x00279889
		private void OnUpdateShowBindTicketWithCreditTicketTip(bool value)
		{
			this._isNotShowBindTicketWithCreditTicketTipFrame = value;
		}

		// Token: 0x0600B2D5 RID: 45781 RVA: 0x0027B492 File Offset: 0x00279892
		private void OnUpdateShowBindTicketWithCreditTicketAndTicketTip(bool value)
		{
			this._isNotShowBindTicketWithCreditTicketAndTicketTipFrame = value;
		}

		// Token: 0x0600B2D6 RID: 45782 RVA: 0x0027B49B File Offset: 0x0027989B
		private void OnUpdateShowCreditTicketOnlyTip(bool value)
		{
			this._isNotShowCreditTicketOnlyTipFrame = value;
		}

		// Token: 0x0600B2D7 RID: 45783 RVA: 0x0027B4A4 File Offset: 0x002798A4
		private void OnUpdateShowCreditTicketAndTicketTip(bool value)
		{
			this._isNotShowCreditTicketAndTicketTipFrame = value;
		}

		// Token: 0x0600B2D8 RID: 45784 RVA: 0x0027B4AD File Offset: 0x002798AD
		private void DoCancelCostAction(Action cancelAction)
		{
			if (cancelAction != null)
			{
				cancelAction();
			}
		}

		// Token: 0x0600B2D9 RID: 45785 RVA: 0x0027B4BB File Offset: 0x002798BB
		private void DoCanCostAction(Action canCostAction)
		{
			if (canCostAction != null)
			{
				if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				canCostAction();
			}
		}

		// Token: 0x0600B2DA RID: 45786 RVA: 0x0027B4DB File Offset: 0x002798DB
		public void ShowJumpToVipFrameTip()
		{
			SystemNotifyManager.SystemNotify(1207, delegate()
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VipFrame>(null))
				{
					VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(VipFrame)) as VipFrame;
					if (vipFrame != null)
					{
						vipFrame.SwitchPage(VipTabType.PAY, true);
					}
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
				}
			});
		}

		// Token: 0x0600B2DB RID: 45787 RVA: 0x0027B504 File Offset: 0x00279904
		public void TryCostMoney(CostItemManager.CostInfo a_costInfo, Action<CostItemManager.CostInfo, CostItemManager.CostInfo[]> a_delCanCost, Action<CostItemManager.CostInfo, CostItemManager.CostInfo[]> a_delCanotCost)
		{
			if (!a_costInfo.IsValid())
			{
				return;
			}
			List<CostItemManager.CostInfo> list = this._CalculateRealCostInfos(a_costInfo);
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				num += list[i].nCount;
			}
			if (num < a_costInfo.nCount)
			{
				if (a_delCanotCost != null)
				{
					a_delCanotCost(a_costInfo, list.ToArray());
				}
			}
			else if (a_delCanCost != null)
			{
				if ((a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || a_costInfo.nMoneyID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
				{
					return;
				}
				a_delCanCost(a_costInfo, list.ToArray());
			}
		}

		// Token: 0x0600B2DC RID: 45788 RVA: 0x0027B5C4 File Offset: 0x002799C4
		public void CommonCannotCostMoneyHandle(CostItemManager.CostInfo a_costInfo, CostItemManager.CostInfo[] a_arrRealCostInfos)
		{
			if (a_arrRealCostInfos == null || a_costInfo == null)
			{
				return;
			}
			bool flag = false;
			int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			for (int i = 0; i < a_arrRealCostInfos.Length; i++)
			{
				if (a_arrRealCostInfos[i].nMoneyID == moneyIDByType)
				{
					SystemNotifyManager.SystemNotify(1207, delegate()
					{
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VipFrame>(null))
						{
							VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(VipFrame)) as VipFrame;
							if (vipFrame != null)
							{
								vipFrame.SwitchPage(VipTabType.PAY, true);
							}
						}
						else
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
						}
					});
					flag = true;
					break;
				}
			}
			if (!flag && a_arrRealCostInfos.Length > 0)
			{
				ItemComeLink.OnLink(a_costInfo.nMoneyID, a_costInfo.nCount, true, null, false, false, false, null, string.Empty);
			}
		}

		// Token: 0x0600B2DD RID: 45789 RVA: 0x0027B668 File Offset: 0x00279A68
		public string GetCostMoneiesDesc(params CostItemManager.CostInfo[] a_infos)
		{
			string text = string.Empty;
			if (a_infos == null)
			{
				return text;
			}
			for (int i = 0; i < a_infos.Length; i++)
			{
				if (a_infos[i].nCount > 0)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_infos[i].nMoneyID);
					if (commonItemTableDataByID != null)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += '、';
						}
						text += TR.Value("common_money_format", commonItemTableDataByID.GetColorName(string.Empty, false), a_infos[i].nCount);
					}
				}
			}
			return text;
		}

		// Token: 0x0600B2DE RID: 45790 RVA: 0x0027B708 File Offset: 0x00279B08
		private string _GetMainCostMoneiesDesc(params CostItemManager.CostInfo[] a_infos)
		{
			string text = string.Empty;
			if (a_infos == null)
			{
				return text;
			}
			for (int i = 0; i < a_infos.Length; i++)
			{
				if (a_infos[i].bMainCost)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += '、';
					}
					text += TR.Value("common_money_format", DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_infos[i].nMoneyID).GetColorName(string.Empty, false), a_infos[i].nCount);
				}
			}
			return text;
		}

		// Token: 0x0600B2DF RID: 45791 RVA: 0x0027B79C File Offset: 0x00279B9C
		private string _GetEqualCostMoneiesDesc(params CostItemManager.CostInfo[] a_infos)
		{
			string text = string.Empty;
			if (a_infos == null)
			{
				return text;
			}
			for (int i = 0; i < a_infos.Length; i++)
			{
				if (!a_infos[i].bMainCost && a_infos[i].nCount > 0)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += '、';
					}
					text += TR.Value("common_money_format", DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_infos[i].nMoneyID).GetColorName(string.Empty, false), a_infos[i].nCount);
				}
			}
			return text;
		}

		// Token: 0x0600B2E0 RID: 45792 RVA: 0x0027B840 File Offset: 0x00279C40
		private List<CostItemManager.CostInfo> _CalculateRealCostInfos(CostItemManager.CostInfo a_costInfo)
		{
			List<int> list = new List<int>();
			EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(a_costInfo.nMoneyID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				list.AddRange(tableItem.EqualItemIDs);
			}
			list.Add(a_costInfo.nMoneyID);
			if (this._IsIncomeType(a_costInfo.nMoneyID))
			{
				int nMoneyID = a_costInfo.nMoneyID;
				list.RemoveAt(list.Count - 1);
				list.Insert(0, nMoneyID);
			}
			int num = 0;
			List<CostItemManager.CostInfo> list2 = new List<CostItemManager.CostInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = list[i];
				if (i == 0)
				{
					costInfo.bMainCost = true;
				}
				else
				{
					costInfo.bMainCost = false;
				}
				list2.Add(costInfo);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costInfo.nMoneyID, false);
				if (num + ownedItemCount >= a_costInfo.nCount)
				{
					costInfo.nCount = a_costInfo.nCount - num;
					num = a_costInfo.nCount;
					break;
				}
				costInfo.nCount = ownedItemCount;
				num += ownedItemCount;
			}
			return list2;
		}

		// Token: 0x0600B2E1 RID: 45793 RVA: 0x0027B968 File Offset: 0x00279D68
		private bool _IsIncomeType(int a_nItemID)
		{
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nItemID);
			return commonItemTableDataByID != null && commonItemTableDataByID.Type == ItemTable.eType.INCOME;
		}

		// Token: 0x0600B2E2 RID: 45794 RVA: 0x0027B992 File Offset: 0x00279D92
		private bool _IsTicketType(int a_nItemID)
		{
			return a_nItemID == 200000004 || a_nItemID == 200000003;
		}

		// Token: 0x0600B2E3 RID: 45795 RVA: 0x0027B9B0 File Offset: 0x00279DB0
		public CostItemManager.eCostEnoughType GetCostEnoughType(CostItemManager.CostInfo a_costInfo)
		{
			if (a_costInfo == null || !a_costInfo.IsValid())
			{
				return CostItemManager.eCostEnoughType.Invalid;
			}
			List<CostItemManager.CostInfo> list = this._CalculateRealCostInfos(a_costInfo);
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				num += list[i].nCount;
			}
			if (num < a_costInfo.nCount)
			{
				return CostItemManager.eCostEnoughType.NotEnough;
			}
			if (list.Count > 1)
			{
				return CostItemManager.eCostEnoughType.UseEqualItemEnough;
			}
			return CostItemManager.eCostEnoughType.UseOriginItemEnough;
		}

		// Token: 0x0600B2E4 RID: 45796 RVA: 0x0027BA20 File Offset: 0x00279E20
		public bool IsEnough2Cost(CostItemManager.CostInfo info)
		{
			CostItemManager.eCostEnoughType costEnoughType = this.GetCostEnoughType(info);
			return costEnoughType != CostItemManager.eCostEnoughType.Invalid && CostItemManager.eCostEnoughType.NotEnough != costEnoughType;
		}

		// Token: 0x0600B2E5 RID: 45797 RVA: 0x0027BA48 File Offset: 0x00279E48
		public bool IsEnough2Cost(List<CostItemManager.CostInfo> infos)
		{
			for (int i = 0; i < infos.Count; i++)
			{
				if (!this.IsEnough2Cost(infos[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400647D RID: 25725
		private bool m_bNotify = true;

		// Token: 0x0400647E RID: 25726
		private bool _isNotShowBindTicketWithCreditTicketTipFrame;

		// Token: 0x0400647F RID: 25727
		private bool _isNotShowBindTicketWithCreditTicketAndTicketTipFrame;

		// Token: 0x04006480 RID: 25728
		private bool _isNotShowCreditTicketOnlyTipFrame;

		// Token: 0x04006481 RID: 25729
		private bool _isNotShowCreditTicketAndTicketTipFrame;

		// Token: 0x0200122A RID: 4650
		public class CostInfo
		{
			// Token: 0x0600B2E9 RID: 45801 RVA: 0x0027BB58 File Offset: 0x00279F58
			public bool IsValid()
			{
				return this.nMoneyID > 0 && Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.nMoneyID, string.Empty, string.Empty) != null && this.nCount >= 0;
			}

			// Token: 0x04006484 RID: 25732
			public int nMoneyID;

			// Token: 0x04006485 RID: 25733
			public int nCount;

			// Token: 0x04006486 RID: 25734
			public bool bMainCost = true;

			// Token: 0x04006487 RID: 25735
			public bool IsCreditPointDeduction;
		}

		// Token: 0x0200122B RID: 4651
		public enum eCostEnoughType
		{
			// Token: 0x04006489 RID: 25737
			Invalid,
			// Token: 0x0400648A RID: 25738
			NotEnough,
			// Token: 0x0400648B RID: 25739
			UseEqualItemEnough,
			// Token: 0x0400648C RID: 25740
			UseOriginItemEnough
		}
	}
}
