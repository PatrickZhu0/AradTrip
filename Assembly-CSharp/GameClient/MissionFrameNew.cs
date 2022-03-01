using System;
using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017B1 RID: 6065
	internal class MissionFrameNew : ClientFrame
	{
		// Token: 0x0600EF1B RID: 61211 RVA: 0x004031F8 File Offset: 0x004015F8
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length == 1)
				{
					MissionFrameNewData missionFrameNewData = new MissionFrameNewData();
					missionFrameNewData.iFirstFilter = int.Parse(array[0]);
					missionFrameNewData.bCycle = false;
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<MissionFrameNew>(null, false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionFrameNew>(FrameLayer.Middle, missionFrameNewData, string.Empty);
				}
				else if (array.Length == 2)
				{
					MissionFrameNewData missionFrameNewData2 = new MissionFrameNewData();
					missionFrameNewData2.iFirstFilter = int.Parse(array[0]);
					missionFrameNewData2.bCycle = (int.Parse(array[1]) == 1);
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<MissionFrameNew>(null, false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionFrameNew>(FrameLayer.Middle, missionFrameNewData2, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600EF1C RID: 61212 RVA: 0x004032D0 File Offset: 0x004016D0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/MissionFrame.prefab";
		}

		// Token: 0x0600EF1D RID: 61213 RVA: 0x004032D7 File Offset: 0x004016D7
		[UIEventHandle("BG/Title/Close")]
		private void OnClickClose()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMission, null, null, null, null);
			this.frameMgr.CloseFrame<MissionFrameNew>(this, false);
		}

		// Token: 0x0600EF1E RID: 61214 RVA: 0x004032F9 File Offset: 0x004016F9
		public void OnFilterZeroChanged(MissionFrameNew.FilterZeroType eFilterZeroType)
		{
			this.m_akFilterZeros.GetObject(eFilterZeroType).toggle.isOn = true;
		}

		// Token: 0x0600EF1F RID: 61215 RVA: 0x00403314 File Offset: 0x00401714
		private void _InitFilter0()
		{
			this.m_akFilterZeros.Clear();
			GameObject gameObject = Utility.FindChild(this.frame, "Content/HorizenFilter");
			GameObject gameObject2 = Utility.FindChild(gameObject, "Filter");
			gameObject2.CustomActive(false);
			this.m_eFilterZeroType = MissionFrameNew.FilterZeroType.FZT_COUNT;
			for (int i = 0; i < 2; i++)
			{
				this.m_akFilterZeros.Create((MissionFrameNew.FilterZeroType)i, new object[]
				{
					gameObject,
					gameObject2,
					(MissionFrameNew.FilterZeroType)i,
					this
				});
			}
		}

		// Token: 0x0600EF20 RID: 61216 RVA: 0x00403391 File Offset: 0x00401791
		private void _OnFilterChanged0(MissionFrameNew.FilterZeroType eCurrent)
		{
			this.m_eFilterZeroType = eCurrent;
			this.m_kMainMissionList.Filter(this.m_eFilterZeroType);
		}

		// Token: 0x0600EF21 RID: 61217 RVA: 0x004033AC File Offset: 0x004017AC
		private void _InitFilter1()
		{
			this.m_akFilterFirsts.Clear();
			GameObject gameObject = Utility.FindChild(this.frame, "VerticalFilter");
			GameObject gameObject2 = Utility.FindChild(gameObject, "Filter");
			gameObject2.CustomActive(false);
			for (int i = 0; i < 3; i++)
			{
				if (i == 0)
				{
					MissionFrameNew.FilterFirst filterFirst = this.m_akFilterFirsts.Create((MissionFrameNew.FilterFirstType)i, new object[]
					{
						gameObject,
						gameObject2,
						(MissionFrameNew.FilterFirstType)i,
						this
					});
					if (filterFirst != null)
					{
						this.m_akFilterFirsts.FilterObject((MissionFrameNew.FilterFirstType)i, null);
					}
				}
			}
		}

		// Token: 0x0600EF22 RID: 61218 RVA: 0x00403440 File Offset: 0x00401840
		private void _OnFilterChanged1(MissionFrameNew.FilterFirstType eCurrent)
		{
			this.m_eFilterFirstType = eCurrent;
			this._InitializeTab(this.m_eFilterFirstType);
			this.goContent.CustomActive(this.m_eFilterFirstType == MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH);
			this.goAchievementContent.CustomActive(this.m_eFilterFirstType == MissionFrameNew.FilterFirstType.FFT_ACHIEVEMENT);
		}

		// Token: 0x0600EF23 RID: 61219 RVA: 0x00403480 File Offset: 0x00401880
		private bool CanFastFinishMainTask(MissionManager.SingleMissionInfo missionInfo)
		{
			return missionInfo != null && missionInfo.missionItem != null && missionInfo.status == 1 && missionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN && PlayerBaseData.IsJobChanged() && PlayerUtility.GetFullLevelRoleCount() >= 1 && missionInfo.missionItem.FinishRightNowLevel != 0 && missionInfo.missionItem.FinishRightNowLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x0600EF24 RID: 61220 RVA: 0x0040350C File Offset: 0x0040190C
		public void OnMissionSelected(MissionManager.SingleMissionInfo value)
		{
			this.m_kCurrent = value;
			this.goDescribe.CustomActive(this.m_kCurrent != null);
			this.levelHint.CustomActive(this.m_kCurrent != null && !DataManager<MissionManager>.GetInstance().IsLevelFit(value.missionItem.ID));
			if (this.m_kCurrent != null)
			{
				this.levelHint.text = TR.Value("mission_level_hint", value.missionItem.MinPlayerLv);
				this.kCurrentName.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)value.missionItem.ID);
				this.kCurrentDesc.SetText(Utility.ParseMissionText(this.m_kCurrent.missionItem.ID, false, false, false), true);
				ETCImageLoader.LoadSprite(ref this.kCurrentIcon, Utility.GetMissionIcon(this.m_kCurrent.missionItem.TaskType), true);
				if (value.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(17, string.Empty, string.Empty);
					int value2 = tableItem.Value;
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_CYCLE_REFRESH_TIMES);
					if (value2 > count)
					{
						this.m_kCycleOrgHint.CustomActive(true);
						this.m_goCostHint.CustomActive(false);
					}
					else
					{
						this.m_kCycleOrgHint.CustomActive(false);
						this.m_goCostHint.CustomActive(true);
						int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, true);
						tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(18, string.Empty, string.Empty);
						int num = 0;
						if (tableItem != null)
						{
							num = tableItem.Value;
						}
						if (ownedItemCount >= num)
						{
							Graphic kRefreshPre = this.m_kRefreshPre;
							Color color = Color.white;
							this.m_kRefreshCount.color = color;
							kRefreshPre.color = color;
						}
						else
						{
							Graphic kRefreshPre2 = this.m_kRefreshPre;
							Color color = Color.red;
							this.m_kRefreshCount.color = color;
							kRefreshPre2.color = color;
						}
						this.m_kRefreshCount.text = num.ToString();
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(moneyIDByType, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref this.m_kRefreshCoin, tableItem2.Icon, true);
						}
					}
				}
				this.btnFastFinish.CustomActive(false);
				bool flag = false;
				if (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN)
				{
					flag = this.CanFastFinishMainTask(this.m_kCurrent);
				}
				else if (this.m_kCurrent.missionItem.FinishRightNowLevel != 0 && this.m_kCurrent.missionItem.FinishRightNowLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level && this.m_kCurrent.status == 1)
				{
					flag = true;
				}
				if (flag)
				{
					this.btnFastFinish.CustomActive(true);
					this.mFastFinishCount.text = this.m_kCurrent.missionItem.FinishRightNowItemNum.ToString();
					bool flag2 = this.m_kCurrent.missionItem.FinishRightNowItemNum > DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.m_kCurrent.missionItem.FinishRightNowItemType, false);
					this.mFastFinishCount.color = ((!flag2) ? Color.white : Color.red);
					ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kCurrent.missionItem.FinishRightNowItemType, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						ETCImageLoader.LoadSprite(ref this.mFastFinishIcon, tableItem3.Icon, true);
					}
				}
				if (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE || this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
				{
					this.goBtnGiveUp.CustomActive(this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_CHANGEJOB && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_CYCLE && this.m_kCurrent.status != 2 && this.m_kCurrent.status != 0);
					this.goBtnComplete.CustomActive(this.m_kCurrent.status == 2);
					this.goBtnTrace.CustomActive(true);
					this.btnTrace.enabled = true;
					this.comTrace.enabled = false;
					this.goBtnAccept.CustomActive(this.m_kCurrent.status == 0);
					this.btnAccept.enabled = true;
					this.comAccept.enabled = false;
					this.goBtnAward.CustomActive(false);
					this.goBtnRefresh.CustomActive(this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE);
					this.comGrayGiveUp.enabled = (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN);
				}
				else if (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
				{
					this.goBtnGiveUp.CustomActive(this.m_kCurrent.status != 2 && this.m_kCurrent.status != 0);
					this.goBtnComplete.CustomActive(this.m_kCurrent.status == 2);
					int minPlayerLv = this.m_kCurrent.missionItem.MinPlayerLv;
					bool flag3 = minPlayerLv <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
					this.goBtnAccept.CustomActive(this.m_kCurrent.status == 0);
					this.btnAccept.enabled = flag3;
					this.comAccept.enabled = !this.btnAccept.enabled;
					this.goBtnTrace.CustomActive(true);
					bool enabled = true;
					if (this.m_kCurrent.status == 0 && !flag3)
					{
						enabled = false;
					}
					this.btnTrace.enabled = enabled;
					this.comTrace.enabled = !this.btnTrace.enabled;
					this.goBtnAward.CustomActive(false);
					this.goBtnRefresh.CustomActive(false);
					this.comGrayGiveUp.enabled = false;
				}
				else if (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT)
				{
					this.goBtnGiveUp.CustomActive(false);
					this.goBtnTrace.CustomActive(false);
					this.btnTrace.enabled = true;
					this.comTrace.enabled = false;
					this.goBtnAccept.CustomActive(false);
					this.btnAccept.enabled = true;
					this.comAccept.enabled = false;
					this.goBtnComplete.CustomActive(false);
					this.goBtnAward.CustomActive(true);
					this.comGray.enabled = (this.m_kCurrent.status != 2);
					this.comGrayGiveUp.enabled = false;
				}
				else
				{
					this.goBtnGiveUp.CustomActive(false);
					this.goBtnTrace.CustomActive(false);
					this.btnTrace.enabled = true;
					this.comTrace.enabled = false;
					this.goBtnAccept.CustomActive(false);
					this.btnAccept.enabled = true;
					this.comAccept.enabled = false;
					this.goBtnComplete.CustomActive(false);
					this.goBtnRefresh.CustomActive(false);
					this.goBtnAward.CustomActive(true);
					this.comGray.enabled = (this.m_kCurrent.status != 2);
					this.comGrayGiveUp.enabled = false;
				}
				List<ComItem> list = new List<ComItem>();
				for (int i = 0; i < this.goAwardArray.transform.childCount; i++)
				{
					Transform child = this.goAwardArray.transform.GetChild(i);
					if (child != null)
					{
						ComItem component = child.GetComponent<ComItem>();
						if (component != null)
						{
							component.Setup(null, null);
							component.gameObject.CustomActive(false);
							list.Add(component);
						}
					}
				}
				List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(this.m_kCurrent.missionItem.ID, -1);
				for (int j = 0; j < missionAwards.Count; j++)
				{
					AwardItemData awardItemData = missionAwards[j];
					ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(awardItemData.ID, string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(awardItemData.ID, 100, 0);
						if (itemData != null)
						{
							ComItem comItem;
							if (list.Count > 0)
							{
								comItem = list[0];
								list.RemoveAt(0);
							}
							else
							{
								comItem = base.CreateComItem(this.goAwardArray);
							}
							itemData.Count = awardItemData.Num;
							itemData.StrengthenLevel = awardItemData.StrengthenLevel;
							itemData.EquipType = (EEquipType)awardItemData.EquipType;
							if (comItem != null)
							{
								comItem.gameObject.CustomActive(true);
								comItem.Setup(itemData, new ComItem.OnItemClicked(this._OnAwardItemClicked));
							}
						}
					}
				}
				SystemValueTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(614, string.Empty, string.Empty);
				if (tableItem5 == null)
				{
					return;
				}
				if (this.m_kCurrent.taskID == (uint)tableItem5.Value)
				{
					SystemValueTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(615, string.Empty, string.Empty);
					if (tableItem6 == null)
					{
						return;
					}
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(tableItem6.Value, 100, 0);
					if (this.skillComItem == null)
					{
						if (itemData2 != null)
						{
							this.skillComItem = base.CreateComItem(this.goAwardArray);
							this.skillComItem.Setup(itemData2, new ComItem.OnItemClicked(this._OnAwardItemClicked));
							this.skillComItem.gameObject.CustomActive(true);
						}
					}
					else
					{
						this.skillComItem.Setup(itemData2, new ComItem.OnItemClicked(this._OnAwardItemClicked));
						this.skillComItem.gameObject.CustomActive(true);
					}
				}
				else if (this.skillComItem != null)
				{
					this.skillComItem.Setup(null, null);
					this.skillComItem.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600EF25 RID: 61221 RVA: 0x00403F57 File Offset: 0x00402357
		private void _OnAwardItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600EF26 RID: 61222 RVA: 0x00403F6C File Offset: 0x0040236C
		private void _InitItemObjects()
		{
			this.goParent = Utility.FindChild(this.frame, "Content/MissionArray/ScrollView/ViewPort/Content");
			this.goPrefab = Utility.FindChild(this.goParent, "ItemObject");
			this.goPrefab.CustomActive(false);
			this.goDescribe = Utility.FindChild(this.frame, "Content/Describe");
			this.kCurrentName = Utility.FindComponent<Text>(this.goDescribe, "tittle/Text", true);
			this.kCurrentIcon = Utility.FindComponent<Image>(this.goDescribe, "tittle/typeIcon", true);
			this.kCurrentDesc = Utility.FindComponent<LinkParse>(this.goDescribe, "MissionDescribe/ViewPort/Content", true);
			this.goAwardArray = Utility.FindChild(this.goDescribe, "MissionAward/AwardArray");
			this.goBtnGiveUp = Utility.FindChild(this.goDescribe, "BtnGiveUp");
			this.goBtnComplete = Utility.FindChild(this.goDescribe, "BtnComplete");
			this.goBtnTrace = Utility.FindChild(this.goDescribe, "BtnTrace");
			this.goBtnAccept = Utility.FindChild(this.goDescribe, "BtnAccept");
			this.goBtnAward = Utility.FindChild(this.goDescribe, "BtnAward");
			this.goBtnRefresh = Utility.FindChild(this.goDescribe, "BtnRefresh");
			this.comGray = Utility.FindComponent<UIGray>(this.goDescribe, "BtnAward", true);
			this.comGrayGiveUp = Utility.FindComponent<UIGray>(this.goDescribe, "BtnGiveUp", true);
			this.m_kCycleOrgHint = Utility.FindComponent<Text>(this.frame, "Content/Describe/BtnRefresh/renwutishi", true);
			this.m_goCostHint = Utility.FindChild(this.frame, "Content/Describe/BtnRefresh/Hint");
			this.m_kRefreshPre = Utility.FindComponent<Text>(this.frame, "Content/Describe/BtnRefresh/Hint/refresh", true);
			this.m_kRefreshCount = Utility.FindComponent<Text>(this.frame, "Content/Describe/BtnRefresh/Hint/Count", true);
			this.m_kRefreshCoin = Utility.FindComponent<Image>(this.frame, "Content/Describe/BtnRefresh/Hint/Image", true);
			this.mFastFinishIcon = Utility.FindComponent<Image>(this.btnFastFinish.gameObject, "Hint/Image", true);
			this.mFastFinishCount = Utility.FindComponent<Text>(this.btnFastFinish.gameObject, "Hint/Count", true);
		}

		// Token: 0x0600EF27 RID: 61223 RVA: 0x00404180 File Offset: 0x00402580
		private MissionFrameNew.FilterFirstType GetDefaultFirstType(int iFirstFilter)
		{
			MissionFrameNew.FilterFirstType result;
			if (iFirstFilter == 1)
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(10, string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.FinishLevel)
				{
					return (MissionFrameNew.FilterFirstType)iFirstFilter;
				}
				result = MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH;
			}
			else if (iFirstFilter == 2)
			{
				FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(4, string.Empty, string.Empty);
				if (tableItem2 != null && (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem2.FinishLevel)
				{
					return (MissionFrameNew.FilterFirstType)iFirstFilter;
				}
				result = MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH;
			}
			else
			{
				result = MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH;
			}
			return result;
		}

		// Token: 0x0600EF28 RID: 61224 RVA: 0x00404218 File Offset: 0x00402618
		protected override void _OnOpenFrame()
		{
			base.SetIsNeedClearWhenChangeScene(true);
			this.data = (this.userData as MissionFrameNewData);
			this.goContent = Utility.FindChild(this.frame, "Content");
			this.goMainDescribe = Utility.FindChild(this.frame, "Content/Describe");
			this.goAchievementContent = Utility.FindChild(this.frame, "AchievementContent");
			this.goMainDescribe.CustomActive(false);
			this._InitItemObjects();
			this._InitFilter0();
			this._InitFilter1();
			this._CheckMainMission(false);
			this._CheckAchievementMission(false);
			this._InitDefaultMission();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance2.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
		}

		// Token: 0x0600EF29 RID: 61225 RVA: 0x00404318 File Offset: 0x00402718
		private void _InitializeTab(MissionFrameNew.FilterFirstType eFilterFirstType)
		{
			if (eFilterFirstType != MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH)
			{
				if (eFilterFirstType == MissionFrameNew.FilterFirstType.FFT_ACHIEVEMENT)
				{
					if (!this.m_kAchievementList.Initialized)
					{
						this.m_kAchievementList.Initialize(this, Utility.FindChild(this.frame, "AchievementContent"), new AchievementMissionList.OnRedPointChanged(this._CheckAchievementMission));
					}
				}
			}
			else if (!this.m_kMainMissionList.Initialized)
			{
				if (!this.data.bCycle)
				{
					this.m_kMainMissionList.Initialize(this, Utility.FindChild(this.frame, "Content/MissionArray"), new MainMissionList.OnRedPointChanged(this._CheckMainMission), MissionFrameNew.FilterZeroType.FZT_COUNT, false, false);
				}
				else
				{
					this.m_kMainMissionList.Initialize(this, Utility.FindChild(this.frame, "Content/MissionArray"), new MainMissionList.OnRedPointChanged(this._CheckMainMission), MissionFrameNew.FilterZeroType.FZT_ACCEPTED, true, true);
				}
			}
		}

		// Token: 0x0600EF2A RID: 61226 RVA: 0x004043F4 File Offset: 0x004027F4
		private void _InitDefaultMission()
		{
			if (this.data == null)
			{
				this.data = new MissionFrameNewData();
				this.data.iFirstFilter = 0;
			}
			else if (this.data.iFirstFilter != 0)
			{
				this.data.iFirstFilter = 0;
				Logger.LogErrorFormat("MissionDaily and MissionAchievement has been removed from this frame , please link other frame !!!", new object[0]);
			}
			this.m_akFilterFirsts.GetObject((MissionFrameNew.FilterFirstType)this.data.iFirstFilter).toggle.isOn = true;
		}

		// Token: 0x0600EF2B RID: 61227 RVA: 0x00404478 File Offset: 0x00402878
		private void _CheckMainMission(bool bCheck)
		{
			MissionFrameNew.FilterFirst @object = this.m_akFilterFirsts.GetObject(MissionFrameNew.FilterFirstType.FFT_MAIN_OR_BRANCH);
			if (@object != null)
			{
				List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
				bool redPointOn = false;
				for (int i = 0; i < list.Count; i++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = list[i];
					if (singleMissionInfo != null && singleMissionInfo.missionItem != null)
					{
						if (singleMissionInfo.status == 2)
						{
							if (singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
							{
								redPointOn = true;
								break;
							}
						}
					}
				}
				@object.SetRedPointOn(redPointOn);
			}
			MissionFrameNew.FilterFirst object2 = this.m_akFilterFirsts.GetObject(MissionFrameNew.FilterFirstType.FFT_ACHIEVEMENT);
			if (object2 != null)
			{
				List<MissionManager.SingleMissionInfo> list2 = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
				bool redPointOn2 = false;
				for (int j = 0; j < list2.Count; j++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo2 = list2[j];
					if (singleMissionInfo2 != null && singleMissionInfo2.missionItem != null)
					{
						if (singleMissionInfo2.status == 2)
						{
							if (singleMissionInfo2.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && singleMissionInfo2.missionItem.SubType == MissionTable.eSubType.Daily_Null)
							{
								redPointOn2 = true;
								break;
							}
						}
					}
				}
				object2.SetRedPointOn(redPointOn2);
			}
			MissionFrameNew.FilterZero object3 = this.m_akFilterZeros.GetObject(MissionFrameNew.FilterZeroType.FZT_ACCEPTED);
			if (object3 != null)
			{
				List<MissionManager.SingleMissionInfo> list3 = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
				bool redPointOn3 = false;
				for (int k = 0; k < list3.Count; k++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo3 = list3[k];
					if (singleMissionInfo3 != null && singleMissionInfo3.missionItem != null)
					{
						if (singleMissionInfo3.status == 2)
						{
							if (singleMissionInfo3.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || singleMissionInfo3.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE || singleMissionInfo3.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH)
							{
								redPointOn3 = true;
								break;
							}
						}
					}
				}
				object3.SetRedPointOn(redPointOn3);
			}
			MissionFrameNew.FilterZero object4 = this.m_akFilterZeros.GetObject(MissionFrameNew.FilterZeroType.FZT_TITLE_TASK);
			if (object4 != null)
			{
				List<MissionManager.SingleMissionInfo> list4 = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
				bool redPointOn4 = false;
				for (int l = 0; l < list4.Count; l++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo4 = list4[l];
					if (singleMissionInfo4 != null && singleMissionInfo4.missionItem != null)
					{
						if (singleMissionInfo4.status == 2)
						{
							if (singleMissionInfo4.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
							{
								redPointOn4 = true;
								break;
							}
						}
					}
				}
				object4.SetRedPointOn(redPointOn4);
			}
		}

		// Token: 0x0600EF2C RID: 61228 RVA: 0x00404784 File Offset: 0x00402B84
		private void _CheckDailyMission(bool bCheck)
		{
			MissionFrameNew.FilterFirst @object = this.m_akFilterFirsts.GetObject(MissionFrameNew.FilterFirstType.FFT_DAILY);
			if (@object != null)
			{
				bool flag = bCheck;
				if (!flag)
				{
					List<MissionFrameNew.MissionScoreItem> list = this.m_akMissionScoreItems.ActiveObjects.Values.ToList<MissionFrameNew.MissionScoreItem>();
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i] != null && list[i].CanAcquire)
						{
							flag = true;
							break;
						}
					}
				}
				@object.SetRedPointOn(flag);
			}
		}

		// Token: 0x0600EF2D RID: 61229 RVA: 0x00404804 File Offset: 0x00402C04
		private void _CheckAchievementMission(bool bCheck)
		{
			MissionFrameNew.FilterFirst @object = this.m_akFilterFirsts.GetObject(MissionFrameNew.FilterFirstType.FFT_ACHIEVEMENT);
			if (@object != null)
			{
				List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
				bool redPointOn = false;
				for (int i = 0; i < list.Count; i++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = list[i];
					if (singleMissionInfo != null && singleMissionInfo.missionItem != null)
					{
						if (singleMissionInfo.status == 2)
						{
							if (singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && singleMissionInfo.missionItem.SubType == MissionTable.eSubType.Daily_Null)
							{
								redPointOn = true;
								break;
							}
						}
					}
				}
				@object.SetRedPointOn(redPointOn);
			}
		}

		// Token: 0x0600EF2E RID: 61230 RVA: 0x004048BC File Offset: 0x00402CBC
		protected override void _OnCloseFrame()
		{
			this.m_kAchievementList.UnInitialize();
			this.m_kMainMissionList.UnInitialize();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance2.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
			this.m_akFilterZeros.DestroyAllObjects();
			this.m_akFilterFirsts.DestroyAllObjects();
			this.goContent = null;
			this.goMainDescribe = null;
			this.goParent = null;
			this.goPrefab = null;
			this.goDescribe = null;
			this.kCurrentName = null;
			this.kCurrentIcon = null;
			this.kCurrentDesc = null;
			this.goAwardArray = null;
			this.goBtnGiveUp = null;
			this.goBtnComplete = null;
			this.goBtnTrace = null;
			this.goBtnAccept = null;
			this.goBtnAward = null;
			this.goBtnRefresh = null;
			this.comGray = null;
			this.m_kCycleOrgHint = null;
			this.m_goCostHint = null;
			this.m_kRefreshPre = null;
			this.m_kRefreshCount = null;
			this.m_kRefreshCoin = null;
			this.m_akMissionScoreItems.DestroyAllObjects();
			this.goMissionScoreItemParent = null;
			this.goMissionScoreItemPrefabs = null;
			this.btnFastFinish = null;
			this.mFastFinishCount = null;
			this.mFastFinishIcon = null;
			this.skillComItem = null;
		}

		// Token: 0x0600EF2F RID: 61231 RVA: 0x00404A24 File Offset: 0x00402E24
		[UIEventHandle("Content/Describe/BtnGiveUp")]
		private void OnGiveUpMission()
		{
			if (this.m_kCurrent != null && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_ACHIEVEMENT && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_DIALY)
			{
				DataManager<MissionManager>.GetInstance().sendCmdAbandomTask((uint)this.m_kCurrent.missionItem.ID);
			}
		}

		// Token: 0x0600EF30 RID: 61232 RVA: 0x00404A84 File Offset: 0x00402E84
		[UIEventHandle("Content/Describe/BtnComplete")]
		private void OnCompleteMission()
		{
			if (this.m_kCurrent != null && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_ACHIEVEMENT && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_DIALY && DataManager<MissionManager>.GetInstance().OnExecuteSubmitTask(this.m_kCurrent.missionItem.ID, null, null, false))
			{
				base.Close(false);
			}
		}

		// Token: 0x0600EF31 RID: 61233 RVA: 0x00404AF0 File Offset: 0x00402EF0
		[UIEventHandle("Content/Describe/BtnAward")]
		private void OnAward()
		{
			if (this.m_kCurrent != null && (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT || this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_DIALY))
			{
				DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.m_kCurrent.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
			}
		}

		// Token: 0x0600EF32 RID: 61234 RVA: 0x00404B50 File Offset: 0x00402F50
		[UIEventHandle("Content/Describe/BtnTrace")]
		private void OnTraceMission()
		{
			if (this.m_kCurrent != null && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_ACHIEVEMENT && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_DIALY)
			{
				if (this.m_kCurrent.missionItem.LinkParam == 1)
				{
					this.frameMgr.CloseFrame<MissionFrameNew>(this, true);
				}
				DataManager<MissionManager>.GetInstance().AutoTraceTask(this.m_kCurrent.missionItem.ID, null, null, false);
			}
		}

		// Token: 0x0600EF33 RID: 61235 RVA: 0x00404BD4 File Offset: 0x00402FD4
		[UIEventHandle("Content/Describe/BtnAccept")]
		private void OnAcceptMission()
		{
			if (this.m_kCurrent == null)
			{
				return;
			}
			if (!DataManager<MissionManager>.GetInstance().IsLevelFit(this.m_kCurrent.missionItem.ID))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("mission_accept_need_level", this.m_kCurrent.missionItem.MinPlayerLv), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_ACHIEVEMENT && this.m_kCurrent.missionItem.TaskType != MissionTable.eTaskType.TT_DIALY)
			{
				DataManager<MissionManager>.GetInstance().OnExecuteAcceptTask(this.m_kCurrent.missionItem.ID, true, null, null, false);
			}
			else if (this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT)
			{
				DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.m_kCurrent.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
			}
			else
			{
				DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.m_kCurrent.missionItem.ID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
			}
		}

		// Token: 0x0600EF34 RID: 61236 RVA: 0x00404CD4 File Offset: 0x004030D4
		[UIEventHandle("Content/Describe/BtnFastFinish")]
		private void OnFastFinishMission()
		{
			if (this.m_kCurrent == null)
			{
				return;
			}
			if (this.m_kCurrent.missionItem == null)
			{
				return;
			}
			if (!DataManager<MissionManager>.GetInstance().IsLevelFit(this.m_kCurrent.missionItem.ID))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("mission_accept_need_level", this.m_kCurrent.missionItem.MinPlayerLv), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int finishRightNowItemType = this.m_kCurrent.missionItem.FinishRightNowItemType;
			int finishRightNowItemNum = this.m_kCurrent.missionItem.FinishRightNowItemNum;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = finishRightNowItemType,
				nCount = finishRightNowItemNum
			}, delegate
			{
				DataManager<MissionManager>.GetInstance().sendUnFinishTask((uint)this.m_kCurrent.missionItem.ID, TaskSubmitType.TASK_SUBMIT_RIGHTNOW, 0U);
			}, "common_money_cost", null);
		}

		// Token: 0x0600EF35 RID: 61237 RVA: 0x00404D98 File Offset: 0x00403198
		[UIEventHandle("Content/Describe/BtnRefresh")]
		private void OnRefresh()
		{
			if (this.m_kCurrent != null && this.m_kCurrent.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(17, string.Empty, string.Empty);
				int value = tableItem.Value;
				int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_CYCLE_REFRESH_TIMES);
				if (value <= count)
				{
					int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
					if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(moneyIDByType, string.Empty, string.Empty) == null)
					{
						Logger.LogErrorFormat("bindpoint id is error can not find in table ItemTable!", new object[0]);
						return;
					}
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, false);
					tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(18, string.Empty, string.Empty);
					if (tableItem == null)
					{
						Logger.LogErrorFormat("error! ProtoTable.SystemValueTable.eType.SVT_CYCLE_TASK_REFRESH_CONSUME can not find in table ProtoTable.SystemValueTable !!", new object[0]);
						return;
					}
					int value2 = tableItem.Value;
					if (ownedItemCount < value2)
					{
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						costInfo.nMoneyID = moneyIDByType;
						costInfo.nCount = value2;
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							DataManager<MissionManager>.GetInstance().sendCmdRefreshTask(0U);
						}, "common_money_cost", null);
						return;
					}
				}
				DataManager<MissionManager>.GetInstance().sendCmdRefreshTask(0U);
			}
		}

		// Token: 0x0600EF36 RID: 61238 RVA: 0x00404EE0 File Offset: 0x004032E0
		private void OnLevelChanged(int iPre, int iCur)
		{
			this.m_akFilterFirsts.Filter(null);
			this.OnMissionSelected(this.m_kCurrent);
		}

		// Token: 0x0600EF37 RID: 61239 RVA: 0x00404EFA File Offset: 0x004032FA
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.OnMissionSelected(this.m_kCurrent);
		}

		// Token: 0x0600EF38 RID: 61240 RVA: 0x00404F08 File Offset: 0x00403308
		private void OnJobIDChanged(UIEvent uiEvent)
		{
			this.OnMissionSelected(this.m_kCurrent);
		}

		// Token: 0x0600EF39 RID: 61241 RVA: 0x00404F18 File Offset: 0x00403318
		private int _SortedItem(MissionManager.SingleMissionInfo left, MissionManager.SingleMissionInfo right)
		{
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				if (left.missionItem.SortID != right.missionItem.SortID)
				{
					return left.missionItem.SortID - right.missionItem.SortID;
				}
				if (left.taskID != right.taskID)
				{
					return (left.taskID >= right.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600EF3A RID: 61242 RVA: 0x00404FC0 File Offset: 0x004033C0
		private void _LoadMissionScoreItems()
		{
			if (this.goMissionScoreItemParent == null)
			{
				this.goMissionScoreItemParent = Utility.FindChild(this.frame, "DailyContent/ScoreBar/process/Boxes");
				this.goMissionScoreItemPrefabs = Utility.FindChild(this.frame, "DailyContent/ScoreBar/process/Boxes/Box");
				this.goMissionScoreItemPrefabs.CustomActive(false);
			}
			this.m_akMissionScoreItems.RecycleAllObject();
			List<MissionManager.MissionScoreData> missionScoreDatas = DataManager<MissionManager>.GetInstance().MissionScoreDatas;
			for (int i = 0; i < missionScoreDatas.Count; i++)
			{
				MissionFrameNew.MissionScoreItem missionScoreItem = this.m_akMissionScoreItems.Create(missionScoreDatas[i].missionScoreItem.ID, new object[]
				{
					this.goMissionScoreItemParent,
					this.goMissionScoreItemPrefabs,
					missionScoreDatas[i],
					this
				});
				if (missionScoreItem != null)
				{
					missionScoreItem.SetAsLastSibling();
				}
			}
		}

		// Token: 0x0600EF3B RID: 61243 RVA: 0x00405092 File Offset: 0x00403492
		private void _InitMissionScore()
		{
			this.m_kScore = Utility.FindComponent<Text>(this.frame, "DailyContent/ScoreBar/Score", true);
			this.m_kSlider = Utility.FindComponent<Slider>(this.frame, "DailyContent/ScoreBar/process/back", true);
		}

		// Token: 0x0600EF3C RID: 61244 RVA: 0x004050C4 File Offset: 0x004034C4
		private void _UpdateMissionScore()
		{
			this.m_kScore.text = string.Format(TR.Value("mission_score"), DataManager<MissionManager>.GetInstance().Score);
			float num = (float)DataManager<MissionManager>.GetInstance().Score * 1f / (float)DataManager<MissionManager>.GetInstance().MaxScore;
			num = Mathf.Clamp01(num);
			this.m_kSlider.value = num;
		}

		// Token: 0x0600EF3D RID: 61245 RVA: 0x0040512B File Offset: 0x0040352B
		private void _UnInitMissionScore()
		{
			this.m_kScore = null;
		}

		// Token: 0x0600EF3E RID: 61246 RVA: 0x00405134 File Offset: 0x00403534
		private void OnDailyScoreChanged(int score)
		{
			this._UpdateMissionScore();
			this.m_akMissionScoreItems.RefreshAllObjects(null);
			this._CheckDailyMission(this.m_kDailyMissionList.CheckRedPoint());
		}

		// Token: 0x0600EF3F RID: 61247 RVA: 0x00405159 File Offset: 0x00403559
		private void OnChestIdsChanged()
		{
			this._UpdateMissionScore();
			this.m_akMissionScoreItems.RefreshAllObjects(null);
			this._CheckDailyMission(this.m_kDailyMissionList.CheckRedPoint());
		}

		// Token: 0x0400925D RID: 37469
		private ComItem skillComItem;

		// Token: 0x0400925E RID: 37470
		[UIControl("Content/Describe/LevelHint", typeof(Text), 0)]
		private Text levelHint;

		// Token: 0x0400925F RID: 37471
		private CachedObjectDicManager<MissionFrameNew.FilterZeroType, MissionFrameNew.FilterZero> m_akFilterZeros = new CachedObjectDicManager<MissionFrameNew.FilterZeroType, MissionFrameNew.FilterZero>();

		// Token: 0x04009260 RID: 37472
		private MissionFrameNew.FilterZeroType m_eFilterZeroType;

		// Token: 0x04009261 RID: 37473
		private CachedObjectDicManager<MissionFrameNew.FilterFirstType, MissionFrameNew.FilterFirst> m_akFilterFirsts = new CachedObjectDicManager<MissionFrameNew.FilterFirstType, MissionFrameNew.FilterFirst>();

		// Token: 0x04009262 RID: 37474
		private GameObject goContent;

		// Token: 0x04009263 RID: 37475
		private GameObject goAchievementContent;

		// Token: 0x04009264 RID: 37476
		private GameObject goMainDescribe;

		// Token: 0x04009265 RID: 37477
		private MissionFrameNew.FilterFirstType m_eFilterFirstType;

		// Token: 0x04009266 RID: 37478
		private GameObject goParent;

		// Token: 0x04009267 RID: 37479
		private GameObject goPrefab;

		// Token: 0x04009268 RID: 37480
		private GameObject goDescribe;

		// Token: 0x04009269 RID: 37481
		private Text kCurrentName;

		// Token: 0x0400926A RID: 37482
		private Image kCurrentIcon;

		// Token: 0x0400926B RID: 37483
		private LinkParse kCurrentDesc;

		// Token: 0x0400926C RID: 37484
		private GameObject goAwardArray;

		// Token: 0x0400926D RID: 37485
		private GameObject goBtnGiveUp;

		// Token: 0x0400926E RID: 37486
		private GameObject goBtnComplete;

		// Token: 0x0400926F RID: 37487
		private GameObject goBtnTrace;

		// Token: 0x04009270 RID: 37488
		private GameObject goBtnAccept;

		// Token: 0x04009271 RID: 37489
		private GameObject goBtnAward;

		// Token: 0x04009272 RID: 37490
		private GameObject goBtnRefresh;

		// Token: 0x04009273 RID: 37491
		private UIGray comGrayGiveUp;

		// Token: 0x04009274 RID: 37492
		private UIGray comGray;

		// Token: 0x04009275 RID: 37493
		[UIControl("Content/Describe/BtnTrace", typeof(UIGray), 0)]
		private UIGray comTrace;

		// Token: 0x04009276 RID: 37494
		[UIControl("Content/Describe/BtnTrace", typeof(Button), 0)]
		private Button btnTrace;

		// Token: 0x04009277 RID: 37495
		[UIControl("Content/Describe/BtnAccept", typeof(UIGray), 0)]
		private UIGray comAccept;

		// Token: 0x04009278 RID: 37496
		[UIControl("Content/Describe/BtnAccept", typeof(Button), 0)]
		private Button btnAccept;

		// Token: 0x04009279 RID: 37497
		[UIControl("Content/Describe/BtnFastFinish", typeof(Button), 0)]
		private Button btnFastFinish;

		// Token: 0x0400927A RID: 37498
		private Text m_kCycleOrgHint;

		// Token: 0x0400927B RID: 37499
		private GameObject m_goCostHint;

		// Token: 0x0400927C RID: 37500
		private Text m_kRefreshPre;

		// Token: 0x0400927D RID: 37501
		private Text m_kRefreshCount;

		// Token: 0x0400927E RID: 37502
		private Image m_kRefreshCoin;

		// Token: 0x0400927F RID: 37503
		private Image mFastFinishIcon;

		// Token: 0x04009280 RID: 37504
		private Text mFastFinishCount;

		// Token: 0x04009281 RID: 37505
		private MissionManager.SingleMissionInfo m_kCurrent;

		// Token: 0x04009282 RID: 37506
		private MissionFrameNewData data = new MissionFrameNewData();

		// Token: 0x04009283 RID: 37507
		private MainMissionList m_kMainMissionList = new MainMissionList();

		// Token: 0x04009284 RID: 37508
		private AchievementMissionList m_kAchievementList = new AchievementMissionList();

		// Token: 0x04009285 RID: 37509
		private DailyMissionList m_kDailyMissionList = new DailyMissionList();

		// Token: 0x04009286 RID: 37510
		private CachedObjectDicManager<int, MissionFrameNew.MissionScoreItem> m_akMissionScoreItems = new CachedObjectDicManager<int, MissionFrameNew.MissionScoreItem>();

		// Token: 0x04009287 RID: 37511
		private GameObject goMissionScoreItemParent;

		// Token: 0x04009288 RID: 37512
		private GameObject goMissionScoreItemPrefabs;

		// Token: 0x04009289 RID: 37513
		private Text m_kScore;

		// Token: 0x0400928A RID: 37514
		private Slider m_kSlider;

		// Token: 0x020017B2 RID: 6066
		public enum FilterZeroType
		{
			// Token: 0x0400928D RID: 37517
			[Description("已领取")]
			FZT_ACCEPTED,
			// Token: 0x0400928E RID: 37518
			[Description("称号任务")]
			FZT_TITLE_TASK,
			// Token: 0x0400928F RID: 37519
			FZT_COUNT
		}

		// Token: 0x020017B3 RID: 6067
		private class FilterZero : CachedObject
		{
			// Token: 0x0600EF43 RID: 61251 RVA: 0x004051B4 File Offset: 0x004035B4
			public override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.eCurrent = MissionFrameNew.FilterZeroType.FZT_COUNT;
				this.THIS = null;
				this.goRedPoint = null;
				this.normalText = null;
				this.checkText = null;
				if (this.toggle != null)
				{
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle = null;
				}
			}

			// Token: 0x0600EF44 RID: 61252 RVA: 0x00405224 File Offset: 0x00403624
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eCurrent = (MissionFrameNew.FilterZeroType)param[2];
				this.THIS = (param[3] as MissionFrameNew);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.normalText = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.checkText = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
					this.goRedPoint = Utility.FindChild(this.goLocal, "RedPoint");
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this.OnSelected();
						}
					});
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600EF45 RID: 61253 RVA: 0x0040532A File Offset: 0x0040372A
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF46 RID: 61254 RVA: 0x00405349 File Offset: 0x00403749
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600EF47 RID: 61255 RVA: 0x00405352 File Offset: 0x00403752
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0600EF48 RID: 61256 RVA: 0x0040535A File Offset: 0x0040375A
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600EF49 RID: 61257 RVA: 0x00405379 File Offset: 0x00403779
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF4A RID: 61258 RVA: 0x00405398 File Offset: 0x00403798
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600EF4B RID: 61259 RVA: 0x0040539B File Offset: 0x0040379B
			public void SetRedPointOn(bool bOn)
			{
				this.goRedPoint.CustomActive(bOn);
			}

			// Token: 0x0600EF4C RID: 61260 RVA: 0x004053AC File Offset: 0x004037AC
			private void _Update()
			{
				Text text = this.normalText;
				string enumDescription = Utility.GetEnumDescription<MissionFrameNew.FilterZeroType>(this.eCurrent);
				this.checkText.text = enumDescription;
				text.text = enumDescription;
				this.goLocal.name = this.eCurrent.ToString();
			}

			// Token: 0x0600EF4D RID: 61261 RVA: 0x004053F9 File Offset: 0x004037F9
			private void OnSelected()
			{
				this.THIS._OnFilterChanged0(this.eCurrent);
			}

			// Token: 0x04009290 RID: 37520
			private GameObject goLocal;

			// Token: 0x04009291 RID: 37521
			private GameObject goPrefab;

			// Token: 0x04009292 RID: 37522
			private GameObject goParent;

			// Token: 0x04009293 RID: 37523
			private MissionFrameNew.FilterZeroType eCurrent;

			// Token: 0x04009294 RID: 37524
			private MissionFrameNew THIS;

			// Token: 0x04009295 RID: 37525
			private GameObject goRedPoint;

			// Token: 0x04009296 RID: 37526
			private Text normalText;

			// Token: 0x04009297 RID: 37527
			private Text checkText;

			// Token: 0x04009298 RID: 37528
			public Toggle toggle;
		}

		// Token: 0x020017B4 RID: 6068
		public enum FilterFirstType
		{
			// Token: 0x0400929A RID: 37530
			[Description("任务手册")]
			FFT_MAIN_OR_BRANCH,
			// Token: 0x0400929B RID: 37531
			[Description("每日")]
			FFT_DAILY,
			// Token: 0x0400929C RID: 37532
			[Description("成就")]
			FFT_ACHIEVEMENT,
			// Token: 0x0400929D RID: 37533
			FFT_COUNT
		}

		// Token: 0x020017B5 RID: 6069
		private class FilterFirst : CachedObject
		{
			// Token: 0x0600EF50 RID: 61264 RVA: 0x00405424 File Offset: 0x00403824
			public override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.eCurrent = MissionFrameNew.FilterFirstType.FFT_COUNT;
				this.THIS = null;
				this.goRedPoint = null;
				this.normalText = null;
				this.checkText = null;
				this.eFuncType = FunctionUnLock.eFuncType.None;
				if (this.toggle != null)
				{
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle = null;
				}
			}

			// Token: 0x0600EF51 RID: 61265 RVA: 0x00405498 File Offset: 0x00403898
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eCurrent = (MissionFrameNew.FilterFirstType)param[2];
				this.THIS = (param[3] as MissionFrameNew);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.goRedPoint = Utility.FindChild(this.goLocal, "RedPoint");
					this.normalText = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.checkText = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this.OnSelected();
						}
					});
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600EF52 RID: 61266 RVA: 0x0040559E File Offset: 0x0040399E
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF53 RID: 61267 RVA: 0x004055BD File Offset: 0x004039BD
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600EF54 RID: 61268 RVA: 0x004055C6 File Offset: 0x004039C6
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0600EF55 RID: 61269 RVA: 0x004055CE File Offset: 0x004039CE
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600EF56 RID: 61270 RVA: 0x004055ED File Offset: 0x004039ED
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF57 RID: 61271 RVA: 0x0040560C File Offset: 0x00403A0C
			public override bool NeedFilter(object[] param)
			{
				if (this.eFuncType == FunctionUnLock.eFuncType.None)
				{
					return false;
				}
				if (this.eFuncType == FunctionUnLock.eFuncType.DailyTask)
				{
					return true;
				}
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)this.eFuncType, string.Empty, string.Empty);
				return tableItem == null || (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel;
			}

			// Token: 0x0600EF58 RID: 61272 RVA: 0x00405670 File Offset: 0x00403A70
			private void _Update()
			{
				Text text = this.normalText;
				string enumDescription = Utility.GetEnumDescription<MissionFrameNew.FilterFirstType>(this.eCurrent);
				this.checkText.text = enumDescription;
				text.text = enumDescription;
				this.goLocal.name = this.eCurrent.ToString();
				this.eFuncType = FunctionUnLock.eFuncType.None;
				if (this.eCurrent == MissionFrameNew.FilterFirstType.FFT_ACHIEVEMENT)
				{
					this.eFuncType = FunctionUnLock.eFuncType.Achievement;
				}
				else if (this.eCurrent == MissionFrameNew.FilterFirstType.FFT_DAILY)
				{
					this.eFuncType = FunctionUnLock.eFuncType.DailyTask;
				}
			}

			// Token: 0x0600EF59 RID: 61273 RVA: 0x004056F0 File Offset: 0x00403AF0
			private void OnSelected()
			{
				this.THIS._OnFilterChanged1(this.eCurrent);
			}

			// Token: 0x0600EF5A RID: 61274 RVA: 0x00405703 File Offset: 0x00403B03
			public void SetRedPointOn(bool bOn)
			{
				this.goRedPoint.CustomActive(bOn);
			}

			// Token: 0x0400929E RID: 37534
			private GameObject goLocal;

			// Token: 0x0400929F RID: 37535
			private GameObject goPrefab;

			// Token: 0x040092A0 RID: 37536
			private GameObject goParent;

			// Token: 0x040092A1 RID: 37537
			private MissionFrameNew.FilterFirstType eCurrent;

			// Token: 0x040092A2 RID: 37538
			private MissionFrameNew THIS;

			// Token: 0x040092A3 RID: 37539
			private GameObject goRedPoint;

			// Token: 0x040092A4 RID: 37540
			private Text normalText;

			// Token: 0x040092A5 RID: 37541
			private Text checkText;

			// Token: 0x040092A6 RID: 37542
			private FunctionUnLock.eFuncType eFuncType;

			// Token: 0x040092A7 RID: 37543
			public Toggle toggle;
		}

		// Token: 0x020017B6 RID: 6070
		private class MissionScoreItem : CachedObject
		{
			// Token: 0x0600EF5D RID: 61277 RVA: 0x00405728 File Offset: 0x00403B28
			public override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.data = null;
				this.THIS = null;
				this.score = null;
				this.image = null;
				if (this.button != null)
				{
					this.button.onClick.RemoveAllListeners();
					this.button = null;
				}
				this.comBinder = null;
				this.tween = null;
			}

			// Token: 0x0600EF5E RID: 61278 RVA: 0x0040579C File Offset: 0x00403B9C
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (param[2] as MissionManager.MissionScoreData);
				this.THIS = (param[3] as MissionFrameNew);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.score = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.image = Utility.FindComponent<Image>(this.goLocal, "Bg/Icon", true);
					this.button = this.goLocal.GetComponent<Button>();
					this.comBinder = Utility.FindComponent<MissionScoreRedBinder>(this.goLocal, "Bg/RedPoint", true);
					this.goEffect = Utility.FindChild(this.goLocal, "Bg/Baoxiangbeijing");
					this.tween = Utility.FindComponent<DOTweenAnimation>(this.goLocal, "Bg/Icon", true);
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(new UnityAction(this._OnOpenChest));
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600EF5F RID: 61279 RVA: 0x004058D0 File Offset: 0x00403CD0
			private void _OnOpenChest()
			{
				MissionScoreAwardFrame.Open(this.data.missionScoreItem.ID);
			}

			// Token: 0x0600EF60 RID: 61280 RVA: 0x004058E7 File Offset: 0x00403CE7
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF61 RID: 61281 RVA: 0x00405906 File Offset: 0x00403D06
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600EF62 RID: 61282 RVA: 0x0040590F File Offset: 0x00403D0F
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.data = (param[0] as MissionManager.MissionScoreData);
				}
				this._Update();
			}

			// Token: 0x0600EF63 RID: 61283 RVA: 0x00405934 File Offset: 0x00403D34
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x0600EF64 RID: 61284 RVA: 0x00405957 File Offset: 0x00403D57
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600EF65 RID: 61285 RVA: 0x00405976 File Offset: 0x00403D76
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600EF66 RID: 61286 RVA: 0x00405995 File Offset: 0x00403D95
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x17001CE3 RID: 7395
			// (get) Token: 0x0600EF67 RID: 61287 RVA: 0x00405998 File Offset: 0x00403D98
			public bool CanAcquire
			{
				get
				{
					return this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID);
				}
			}

			// Token: 0x0600EF68 RID: 61288 RVA: 0x004059EC File Offset: 0x00403DEC
			private void _Update()
			{
				if (this.data != null)
				{
					this.score.text = this.data.missionScoreItem.Name;
					this.data.bOpen = (this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID));
					this.data.GetIcon(ref this.image);
					Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(this.goParent.transform);
					this.goLocal.transform.localPosition = new Vector3(1800f * this.data.fPostion, this.goLocal.transform.localPosition.y, 0f);
					this.comBinder.LinkID = this.data.missionScoreItem.ID;
					this.goEffect.CustomActive(this.data.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.data.missionScoreItem.ID));
					if (this.goEffect.activeSelf)
					{
						this.tween.DOPlay();
					}
					else
					{
						this.tween.DOPause();
					}
				}
			}

			// Token: 0x040092A8 RID: 37544
			private GameObject goLocal;

			// Token: 0x040092A9 RID: 37545
			private GameObject goPrefab;

			// Token: 0x040092AA RID: 37546
			private GameObject goParent;

			// Token: 0x040092AB RID: 37547
			private MissionManager.MissionScoreData data;

			// Token: 0x040092AC RID: 37548
			private MissionFrameNew THIS;

			// Token: 0x040092AD RID: 37549
			private DOTweenAnimation tween;

			// Token: 0x040092AE RID: 37550
			private Text score;

			// Token: 0x040092AF RID: 37551
			private Image image;

			// Token: 0x040092B0 RID: 37552
			private GameObject goEffect;

			// Token: 0x040092B1 RID: 37553
			private Button button;

			// Token: 0x040092B2 RID: 37554
			private MissionScoreRedBinder comBinder;
		}
	}
}
