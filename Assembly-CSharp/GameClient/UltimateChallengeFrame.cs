using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B7 RID: 5047
	public class UltimateChallengeFrame : ClientFrame
	{
		// Token: 0x0600C3D0 RID: 50128 RVA: 0x002EED45 File Offset: 0x002ED145
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/UltimateChallenge";
		}

		// Token: 0x0600C3D1 RID: 50129 RVA: 0x002EED4C File Offset: 0x002ED14C
		protected override void _OnOpenFrame()
		{
			this.itemDataList = null;
			this.InitDropUIList();
			this.InitItems();
			this.UpdateUltimateChallengeFloorInfoItems();
			this.UpdateUltimateChallengeCountInfos();
			this.BindUIEvent();
			this.UpdateDropItems();
			this.UpdateBufItems();
			if (this.mUltimateChallengeRewardInfoView != null)
			{
				this.mUltimateChallengeRewardInfoView.RefreshView();
			}
			int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
			if (this.itemDataList != null && num < this.itemDataList.Count && num >= 0)
			{
				UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num].tableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneDungeonZjslRefreshBuffReq(tableItem.dungeonID, false);
				}
			}
			if (this.firstMoney != null)
			{
				this.firstMoney.InitMoneyItem(600002541);
			}
			this.effect0.CustomActive(false);
			this.effect1.CustomActive(false);
		}

		// Token: 0x0600C3D2 RID: 50130 RVA: 0x002EEE4C File Offset: 0x002ED24C
		protected override void _OnCloseFrame()
		{
			if (this.dropDataList != null)
			{
				this.dropDataList.Clear();
			}
			this.itemDataList = null;
			this.UnInitDropUIList();
			this.UnBindUIEvent();
		}

		// Token: 0x0600C3D3 RID: 50131 RVA: 0x002EEE78 File Offset: 0x002ED278
		protected override void _bindExUI()
		{
			this.itemList = this.mBind.GetCom<ComUIListScript>("itemList");
			this.HP = this.mBind.GetCom<Slider>("HP");
			this.MP = this.mBind.GetCom<Slider>("MP");
			this.maxFloor = this.mBind.GetCom<Text>("maxFloor");
			this.enterCount = this.mBind.GetCom<Text>("enterCount");
			this.challengeCount = this.mBind.GetCom<Text>("challengeCount");
			this.btnChallenge = this.mBind.GetCom<Button>("btnChallenge");
			this.btnChallenge.SafeSetOnClickListener(delegate
			{
				if (!DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_ZJSL_TOWER))
				{
					SystemNotifyManager.SystemNotify(4500005, string.Empty);
					return;
				}
				int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
				if (this.itemDataList != null && num < this.itemDataList.Count && num >= 0 && this.itemDataList[num] != null)
				{
					UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num].tableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						SceneDungeonStartReq sceneDungeonStartReq = new SceneDungeonStartReq();
						sceneDungeonStartReq.dungeonId = (uint)tableItem.dungeonID;
						NetManager.Instance().SendCommand<SceneDungeonStartReq>(ServerType.GATE_SERVER, sceneDungeonStartReq);
					}
				}
			});
			this.currentFloorInfo = this.mBind.GetCom<Text>("currentFloorInfo");
			this.btnRefresh = this.mBind.GetCom<Button>("btnRefresh");
			this.btnRefresh.SafeSetOnClickListener(delegate
			{
				int num = 0;
				int num2 = 0;
				this.GetCostInfo(ref num, ref num2);
				if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true) < num2)
				{
					List<int> list = new List<int>();
					if (list != null)
					{
						list.Add(num);
						ItemComeLink.OnLink(list[0], 0, true, null, false, false, false, null, string.Empty);
					}
					return;
				}
				UnityAction unityAction = delegate()
				{
					int num3 = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
					if (this.itemDataList != null && num3 < this.itemDataList.Count && num3 >= 0)
					{
						UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num3].tableID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							DataManager<ActivityDataManager>.GetInstance().SendSceneDungeonZjslRefreshBuffReq(tableItem.dungeonID, true);
						}
					}
				};
				if (DataManager<ActivityDataManager>.GetInstance().NotPopUpRefreshBufMsgBox)
				{
					unityAction.Invoke();
				}
				else
				{
					this.frameMgr.OpenFrame<UltimateChallengeRefreshBufMsgBoxFrame>(FrameLayer.Middle, new UltimateChallengeRefreshBufMsgBoxFrame.MsgBoxData
					{
						content = TR.Value("refresh_buf_tip", DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(num), num2),
						cancelCallBack = null,
						okCallBack = unityAction
					}, string.Empty);
				}
			});
			this.Drop = this.mBind.GetCom<ComUIListScript>("Drop");
			this.bufItem0 = this.mBind.GetCom<ComBufItem>("bufItem0");
			this.bufItem1 = this.mBind.GetCom<ComBufItem>("bufItem1");
			this.Level = this.mBind.GetCom<Text>("Level");
			this.Name = this.mBind.GetCom<Text>("Name");
			this.Icon = this.mBind.GetCom<Image>("Icon");
			this.moneyIcon = this.mBind.GetCom<ComItem>("moneyIcon");
			this.moneyNum = this.mBind.GetCom<Text>("moneyNum");
			this.HPText = this.mBind.GetCom<Text>("HPText");
			this.MPText = this.mBind.GetCom<Text>("MPText");
			this.finishedAllFloor = this.mBind.GetGameObject("finishedAllFloor");
			this.firstMoney = this.mBind.GetCom<ShopNewMoneyItem>("firstMoney");
			this.shop = this.mBind.GetCom<Button>("shop");
			this.shop.SafeSetOnClickListener(delegate
			{
				DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(30, 0, 0, -1);
			});
			this.effect0 = this.mBind.GetCom<ComEffect>("effect0");
			this.effect1 = this.mBind.GetCom<ComEffect>("effect1");
			this.todayOpenFloor = this.mBind.GetCom<Text>("todayOpenFloor");
			this.btnChallengeText1 = this.mBind.GetGameObject("btnChallengeText1");
			this.btnChallengeText2 = this.mBind.GetGameObject("btnChallengeText2");
			this.sustainFloor = this.mBind.GetCom<Text>("sustainFloor");
			this.bufName = this.mBind.GetCom<Text>("bufName");
			this.mUltimateChallengeRewardInfoView = this.mBind.GetCom<UltimateChallengeRewardInfoView>("UltimateChallengeRewardInfoView");
		}

		// Token: 0x0600C3D4 RID: 50132 RVA: 0x002EF170 File Offset: 0x002ED570
		protected override void _unbindExUI()
		{
			this.itemList = null;
			this.HP = null;
			this.MP = null;
			this.maxFloor = null;
			this.enterCount = null;
			this.challengeCount = null;
			this.btnChallenge = null;
			this.currentFloorInfo = null;
			this.Drop = null;
			this.bufItem0 = null;
			this.bufItem1 = null;
			this.Level = null;
			this.Name = null;
			this.Icon = null;
			this.moneyIcon = null;
			this.moneyNum = null;
			this.HPText = null;
			this.MPText = null;
			this.finishedAllFloor = null;
			this.firstMoney = null;
			this.shop = null;
			this.effect0 = null;
			this.effect1 = null;
			this.todayOpenFloor = null;
			this.btnChallengeText1 = null;
			this.btnChallengeText2 = null;
			this.sustainFloor = null;
			this.bufName = null;
			this.mUltimateChallengeRewardInfoView = null;
		}

		// Token: 0x0600C3D5 RID: 50133 RVA: 0x002EF248 File Offset: 0x002ED648
		private void InitDropUIList()
		{
			if (this.Drop != null)
			{
				this.Drop.Initialize();
				ComUIListScript drop = this.Drop;
				drop.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(drop.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript drop2 = this.Drop;
				drop2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(drop2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600C3D6 RID: 50134 RVA: 0x002EF2C0 File Offset: 0x002ED6C0
		private void UnInitDropUIList()
		{
			if (this.Drop != null)
			{
				ComUIListScript drop = this.Drop;
				drop.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(drop.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript drop2 = this.Drop;
				drop2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(drop2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600C3D7 RID: 50135 RVA: 0x002EF32C File Offset: 0x002ED72C
		private CommonNewItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<CommonNewItem>();
		}

		// Token: 0x0600C3D8 RID: 50136 RVA: 0x002EF334 File Offset: 0x002ED734
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			CommonNewItem commonNewItem = item.gameObjectBindScript as CommonNewItem;
			if (commonNewItem != null && item.m_index >= 0 && item.m_index < this.dropDataList.Count)
			{
				CommonSplitDataModel commonSplitDataModel = this.dropDataList[item.m_index];
				commonNewItem.InitItem(commonSplitDataModel.FirstNumber, commonSplitDataModel.SecondNumber);
			}
		}

		// Token: 0x0600C3D9 RID: 50137 RVA: 0x002EF39F File Offset: 0x002ED79F
		private void OnSetElementAmount()
		{
			if (this.Drop != null)
			{
				this.Drop.SetElementAmount(this.dropDataList.Count);
			}
		}

		// Token: 0x0600C3DA RID: 50138 RVA: 0x002EF3C8 File Offset: 0x002ED7C8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshDungeonBufSuccess, new ClientEventSystem.UIEventHandler(this._OnRefreshDungeonBufSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshInspireBufSuccess, new ClientEventSystem.UIEventHandler(this._OnRefreshInspireBufSuccess));
		}

		// Token: 0x0600C3DB RID: 50139 RVA: 0x002EF428 File Offset: 0x002ED828
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshDungeonBufSuccess, new ClientEventSystem.UIEventHandler(this._OnRefreshDungeonBufSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshInspireBufSuccess, new ClientEventSystem.UIEventHandler(this._OnRefreshInspireBufSuccess));
		}

		// Token: 0x0600C3DC RID: 50140 RVA: 0x002EF488 File Offset: 0x002ED888
		private string GetFloorDungeonName()
		{
			int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
			if (num == this.itemDataList.Count)
			{
				num = this.itemDataList.Count - 1;
			}
			if (this.itemDataList != null && num < this.itemDataList.Count && num >= 0)
			{
				UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num].tableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.dungeonID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						return tableItem2.Name;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x0600C3DD RID: 50141 RVA: 0x002EF540 File Offset: 0x002ED940
		private void GetCostInfo(ref int costItemID, ref int costNum)
		{
			int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
			if (num == this.itemDataList.Count)
			{
				num = this.itemDataList.Count - 1;
			}
			if (this.itemDataList != null && num < this.itemDataList.Count && num >= 0)
			{
				UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num].tableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					string[] array = tableItem.expendItem.Split(new char[]
					{
						'_'
					});
					if (array.Length >= 2)
					{
						int num2 = int.Parse(array[0]);
						int num3 = int.Parse(array[1]);
						costItemID = num2;
						costNum = num3;
					}
				}
			}
		}

		// Token: 0x0600C3DE RID: 50142 RVA: 0x002EF604 File Offset: 0x002EDA04
		private void InitItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = delegate(GameObject go)
			{
				UltimateChallengeFloorInfoItem result = null;
				if (go)
				{
					result = go.GetComponent<UltimateChallengeFloorInfoItem>();
				}
				return result;
			};
			this.itemList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				this.UpdateUltimateChallengeFloorInfoItem(var1);
			};
			this.itemList.onItemSelected = delegate(ComUIListElementScript var1)
			{
				if (var1 != null)
				{
				}
			};
		}

		// Token: 0x0600C3DF RID: 50143 RVA: 0x002EF698 File Offset: 0x002EDA98
		private void UpdateUltimateChallengeFloorInfoItem(ComUIListElementScript var1)
		{
			if (var1 == null)
			{
				return;
			}
			UltimateChallengeFloorInfoItem ultimateChallengeFloorInfoItem = var1.gameObjectBindScript as UltimateChallengeFloorInfoItem;
			if (ultimateChallengeFloorInfoItem == null)
			{
				return;
			}
			int index = var1.m_index;
			if (index >= 0 && this.itemDataList != null && index < this.itemDataList.Count)
			{
				ultimateChallengeFloorInfoItem.SetUp(this.itemDataList[this.itemDataList.Count - index - 1]);
			}
			else if (index == this.itemDataList.Count)
			{
				ultimateChallengeFloorInfoItem.SetUp(this.bottonFloorData);
			}
		}

		// Token: 0x0600C3E0 RID: 50144 RVA: 0x002EF738 File Offset: 0x002EDB38
		private void CalItemDataList()
		{
			this.itemDataList = null;
			this.itemDataList = new List<ActivityDataManager.UltimateChallengeFloorData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<UltimateChallengeDungeonTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					UltimateChallengeDungeonTable ultimateChallengeDungeonTable = keyValuePair.Value as UltimateChallengeDungeonTable;
					if (ultimateChallengeDungeonTable != null)
					{
						ActivityDataManager.UltimateChallengeFloorData ultimateChallengeFloorData = new ActivityDataManager.UltimateChallengeFloorData();
						if (ultimateChallengeFloorData != null)
						{
							ultimateChallengeFloorData.floor = ultimateChallengeDungeonTable.level;
							ultimateChallengeFloorData.tableID = ultimateChallengeDungeonTable.ID;
							this.itemDataList.Add(ultimateChallengeFloorData);
						}
					}
				}
			}
			UltimateChallengeFrame.totalFloorCount = this.itemDataList.Count;
		}

		// Token: 0x0600C3E1 RID: 50145 RVA: 0x002EF7EC File Offset: 0x002EDBEC
		private void UpdateUltimateChallengeFloorInfoItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.CalItemDataList();
			if (this.itemDataList != null)
			{
				this.itemList.SetElementAmount(this.itemDataList.Count + 1);
				this.itemList.m_scrollRect.verticalNormalizedPosition = (float)(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1) / (float)this.itemDataList.Count;
			}
			this.AdjustSrollBarValue(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor());
		}

		// Token: 0x0600C3E2 RID: 50146 RVA: 0x002EF870 File Offset: 0x002EDC70
		private void AdjustSrollBarValue(int floor)
		{
			if (this.itemList == null || this.itemList.m_scrollRect == null)
			{
				return;
			}
			int num = Math.Max(1, floor);
			RectTransform component = this.itemList.GetComponent<RectTransform>();
			float num2 = (float)(num - 3) * ((this.itemList.contentSize.y + this.itemList.m_elementSpacing.y) / (float)this.itemList.m_elementAmount) / (this.itemList.contentSize.y - component.rect.height);
			num2 += 0.03f;
			num2 = Math.Min(1f, num2);
			num2 = Math.Max(0f, num2);
			this.itemList.m_scrollRect.verticalNormalizedPosition = num2;
		}

		// Token: 0x0600C3E3 RID: 50147 RVA: 0x002EF948 File Offset: 0x002EDD48
		private void UpdateUltimateChallengeCountInfos()
		{
			if (this.itemDataList == null)
			{
				return;
			}
			this.HP.SafeSetValue((float)DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeHPPercent() / 100f);
			this.MP.SafeSetValue((float)DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMPPercent() / 100f);
			this.HPText.SafeSetText(string.Format("{0}%", DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeHPPercent()));
			this.MPText.SafeSetText(string.Format("{0}%", DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMPPercent()));
			this.maxFloor.SafeSetText(TR.Value("best_max_floor_record", DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMaxFloorRecord()));
			this.enterCount.SafeSetText(TR.Value("enter_count", DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftEnterCount(), DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMaxEnterCount()));
			this.challengeCount.SafeSetText(TR.Value("challenge_count", DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftCount(), DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeMaxCount()));
			this.currentFloorInfo.SafeSetText(TR.Value("current_floor_info", this.GetFloorDungeonName()));
			this.Name.SafeSetText(DataManager<PlayerBaseData>.GetInstance().Name);
			this.Level.SafeSetText(string.Format("{0}", DataManager<PlayerBaseData>.GetInstance().Level.ToString()));
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.Icon.SafeSetImage(tableItem2.IconPath, false);
				}
			}
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			if (dateTime.Hour < 6)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			int num = (int)dateTime.DayOfWeek;
			if (dateTime.DayOfWeek == DayOfWeek.Sunday)
			{
				num = 7;
			}
			int num2 = num * DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonDailyOpenFloor();
			bool bGray = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftEnterCount() <= 0 || DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftCount() <= 0 || DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() > this.itemDataList.Count || DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() > num2;
			this.btnChallenge.SafeSetGray(bGray, true);
			this.btnRefresh.SafeSetGray(bGray, true);
			bool flag = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() > num2;
			this.btnChallengeText1.CustomActive(!flag);
			this.btnChallengeText2.CustomActive(flag);
			int num3 = 0;
			int num4 = 0;
			this.GetCostInfo(ref num3, ref num4);
			this.moneyIcon.Setup(ItemDataManager.CreateItemDataFromTable(num3, 100, 0), delegate(GameObject go, ItemData itemData)
			{
				if (itemData != null)
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
				}
			});
			string arg = (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num3, true) < num4) ? "FF0000FF" : "00FF00FF";
			this.moneyNum.SafeSetText(TR.Value("cost_info", CommonUtility.GetItemColorName(Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty)), arg, num4));
			bool flag2 = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeLeftCount() == 0;
			UIGray uigray = this.Icon.gameObject.SafeAddComponent(false);
			if (uigray != null)
			{
				uigray.enabled = false;
				uigray.enabled = flag2;
			}
			if (flag2)
			{
				this.HP.SafeSetValue(0f);
				this.MP.SafeSetValue(0f);
				this.HPText.SafeSetText(string.Format("{0}%", 0));
				this.MPText.SafeSetText(string.Format("{0}%", 0));
			}
			if (DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() > this.itemDataList.Count)
			{
				this.finishedAllFloor.CustomActive(true);
				this.btnChallenge.CustomActive(false);
				this.challengeCount.CustomActive(false);
				this.enterCount.CustomActive(false);
			}
			else
			{
				this.finishedAllFloor.CustomActive(false);
				this.btnChallenge.CustomActive(true);
				this.challengeCount.CustomActive(true);
				this.enterCount.CustomActive(true);
			}
			this.todayOpenFloor.SafeSetText(TR.Value("today_open_floor", Math.Min(num2, this.itemDataList.Count)));
		}

		// Token: 0x0600C3E4 RID: 50148 RVA: 0x002EFDF4 File Offset: 0x002EE1F4
		private void UpdateDropItems()
		{
			if (this.itemDataList == null)
			{
				return;
			}
			int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeTodayStartFloor() - 1;
			if (num == this.itemDataList.Count)
			{
				num = this.itemDataList.Count - 1;
			}
			if (num < 0 || num >= this.itemDataList.Count)
			{
				return;
			}
			if (this.itemDataList[num] == null)
			{
				return;
			}
			UltimateChallengeDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UltimateChallengeDungeonTable>(this.itemDataList[num].tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.dropDataList = CommonUtility.GetSplitDataModelListByTwoSplitChar(tableItem.RewardShow, '|', '_');
			this.OnSetElementAmount();
		}

		// Token: 0x0600C3E5 RID: 50149 RVA: 0x002EFEAC File Offset: 0x002EE2AC
		private void UpdateBufItems()
		{
			if (this.bufItem0 != null)
			{
				this.bufItem0.SetBufData(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufID(), DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufLv());
				this.bufItem0.CustomActive(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufID() > 0);
			}
			if (this.bufItem1 != null)
			{
				this.bufItem1.SetBufData(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufID(), DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufLv());
				this.bufItem1.CustomActive(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufID() > 0);
			}
			int num = DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufBeginFloor() + DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufDurationFloor(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeDungeonBufID()) - 1;
			int num2 = Mathf.Clamp(num, 1, UltimateChallengeFrame.totalFloorCount);
			this._SetText(this.sustainFloor, TR.Value("buf_sustain_floor", num2));
			this._SetText(this.bufName, this.bufName.text);
		}

		// Token: 0x0600C3E6 RID: 50150 RVA: 0x002EFFAB File Offset: 0x002EE3AB
		private void _SetText(Text text, string content)
		{
			if (text == null || content == null)
			{
				return;
			}
			text.font.RequestCharactersInTexture(content, text.fontSize, text.fontStyle);
			text.text = content;
		}

		// Token: 0x0600C3E7 RID: 50151 RVA: 0x002EFFDF File Offset: 0x002EE3DF
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
			this.UpdateUltimateChallengeCountInfos();
			this.UpdateBufItems();
		}

		// Token: 0x0600C3E8 RID: 50152 RVA: 0x002EFFED File Offset: 0x002EE3ED
		private void _OnRefreshDungeonBufSuccess(UIEvent uiEvent)
		{
			if (this.effect0 != null)
			{
				this.effect0.CustomActive(true);
				this.effect0.Stop("UsedEffect");
				this.effect0.Play("UsedEffect");
			}
		}

		// Token: 0x0600C3E9 RID: 50153 RVA: 0x002F002C File Offset: 0x002EE42C
		private void _OnRefreshInspireBufSuccess(UIEvent uiEvent)
		{
			if (this.effect1 != null)
			{
				this.effect1.CustomActive(true);
				this.effect1.Stop("UsedEffect");
				this.effect1.Play("UsedEffect");
			}
		}

		// Token: 0x04006F58 RID: 28504
		private List<ActivityDataManager.UltimateChallengeFloorData> itemDataList;

		// Token: 0x04006F59 RID: 28505
		private ActivityDataManager.UltimateChallengeFloorData bottonFloorData = new ActivityDataManager.UltimateChallengeFloorData
		{
			floor = 0,
			tableID = 0
		};

		// Token: 0x04006F5A RID: 28506
		private int currentFloorIndex;

		// Token: 0x04006F5B RID: 28507
		private static int totalFloorCount;

		// Token: 0x04006F5C RID: 28508
		private ComUIListScript itemList;

		// Token: 0x04006F5D RID: 28509
		private Slider HP;

		// Token: 0x04006F5E RID: 28510
		private Slider MP;

		// Token: 0x04006F5F RID: 28511
		private Text maxFloor;

		// Token: 0x04006F60 RID: 28512
		private Text enterCount;

		// Token: 0x04006F61 RID: 28513
		private Text challengeCount;

		// Token: 0x04006F62 RID: 28514
		private Button btnChallenge;

		// Token: 0x04006F63 RID: 28515
		private Text currentFloorInfo;

		// Token: 0x04006F64 RID: 28516
		private Button btnRefresh;

		// Token: 0x04006F65 RID: 28517
		private ComUIListScript Drop;

		// Token: 0x04006F66 RID: 28518
		private ComBufItem bufItem0;

		// Token: 0x04006F67 RID: 28519
		private ComBufItem bufItem1;

		// Token: 0x04006F68 RID: 28520
		private Text Level;

		// Token: 0x04006F69 RID: 28521
		private Text Name;

		// Token: 0x04006F6A RID: 28522
		private Image Icon;

		// Token: 0x04006F6B RID: 28523
		private ComItem moneyIcon;

		// Token: 0x04006F6C RID: 28524
		private Text moneyNum;

		// Token: 0x04006F6D RID: 28525
		private Text HPText;

		// Token: 0x04006F6E RID: 28526
		private Text MPText;

		// Token: 0x04006F6F RID: 28527
		private GameObject finishedAllFloor;

		// Token: 0x04006F70 RID: 28528
		private ShopNewMoneyItem firstMoney;

		// Token: 0x04006F71 RID: 28529
		private Button shop;

		// Token: 0x04006F72 RID: 28530
		private ComEffect effect0;

		// Token: 0x04006F73 RID: 28531
		private ComEffect effect1;

		// Token: 0x04006F74 RID: 28532
		private Text todayOpenFloor;

		// Token: 0x04006F75 RID: 28533
		private GameObject btnChallengeText1;

		// Token: 0x04006F76 RID: 28534
		private GameObject btnChallengeText2;

		// Token: 0x04006F77 RID: 28535
		private Text sustainFloor;

		// Token: 0x04006F78 RID: 28536
		private Text bufName;

		// Token: 0x04006F79 RID: 28537
		private UltimateChallengeRewardInfoView mUltimateChallengeRewardInfoView;

		// Token: 0x04006F7A RID: 28538
		private List<CommonSplitDataModel> dropDataList = new List<CommonSplitDataModel>();
	}
}
