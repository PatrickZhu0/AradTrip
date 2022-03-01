using System;
using System.Collections;
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
	// Token: 0x020013D7 RID: 5079
	public class ComActiveGroupMain : MonoBehaviour
	{
		// Token: 0x0600C4DA RID: 50394 RVA: 0x002F4CAC File Offset: 0x002F30AC
		public void OnMenuClicked(int channel)
		{
			if (this._menuData != null)
			{
				if (channel >= 0 && channel < this.mChatTypes.Length)
				{
					ChatType chatType = this.mChatTypes[channel];
					string content = string.Empty;
					int type = this._menuData.Type;
					if (type >= 0 && type < this.mFmtContents.Length)
					{
						content = this.mFmtContents[type];
					}
					if (!string.IsNullOrEmpty(content))
					{
						string arg = string.Empty;
						if (this._menuData.Type >= 0 && this._menuData.Type < this.mLinkIDs.Length)
						{
							arg = string.Format("{{X {0} {1}}}", this.mLinkIDs[this._menuData.Type], this._menuData.ID);
						}
						content = string.Format(content, arg);
						DataManager<ChatManager>.GetInstance().TrySendChatContent(chatType, delegate
						{
							this._OnShareAchievementItem(chatType, content);
						});
					}
				}
				this._menuData = null;
			}
		}

		// Token: 0x0600C4DB RID: 50395 RVA: 0x002F4DD4 File Offset: 0x002F31D4
		private void _OnShareAchievementItem(ChatType eChatType, string content)
		{
			DataManager<ChatManager>.GetInstance().SendChat(eChatType, content, 0UL, 0);
		}

		// Token: 0x0600C4DC RID: 50396 RVA: 0x002F4DE8 File Offset: 0x002F31E8
		private void _OnNetSyncChat(MsgDATA msg)
		{
			SceneSyncChat sceneSyncChat = new SceneSyncChat();
			sceneSyncChat.decode(msg.bytes);
			if (sceneSyncChat == null || sceneSyncChat.objid != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			SystemNotifyManager.SysNotifyTextAnimation(this.mShareHint, CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
		}

		// Token: 0x0600C4DD RID: 50397 RVA: 0x002F4E30 File Offset: 0x002F3230
		public void UpdateTabProcess()
		{
			if (null != this.tabProcessInfo)
			{
				int subItemsAValue = DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsAValue(this._MainItem, this._MenuItem, true);
				int subItemsAValue2 = DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsAValue(this._MainItem, this._MenuItem, false);
				float value = Mathf.Clamp01((float)subItemsAValue * 1f / (float)subItemsAValue2);
				this.tabProcessInfo.text = string.Format(this.fmtPointProcess, subItemsAValue, subItemsAValue2);
				if (null != this.tabSlider)
				{
					this.tabSlider.value = value;
				}
			}
		}

		// Token: 0x0600C4DE RID: 50398 RVA: 0x002F4ED0 File Offset: 0x002F32D0
		public void UpdateTabBaseInfo()
		{
			if (null != this.tabItemName)
			{
				if (this._MenuItem != null)
				{
					this.tabItemName.text = this._MenuItem.Name;
				}
				else if (this._MainItem != null)
				{
					this.tabItemName.text = this._MainItem.PureName;
				}
			}
			if (null != this.tabItemIcon)
			{
				if (this._MenuItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.tabItemIcon, this._MenuItem.Icon, true);
				}
				else if (this._MainItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.tabItemIcon, this._MainItem.Icon, true);
				}
			}
		}

		// Token: 0x0600C4DF RID: 50399 RVA: 0x002F4F94 File Offset: 0x002F3394
		public void InitTabDropDown()
		{
			this.mAchievementFilter = ComActiveGroupMain.AchievementFilter.AF_ALL;
			if (null != this.tabDropDown)
			{
				this.tabDropDown.onValueChanged.RemoveListener(new UnityAction<int>(this._OnDropDownChanged));
				this.tabDropDown.options.Clear();
				for (int i = 0; i < this.dropCaptions.Length; i++)
				{
					this.tabDropDown.options.Add(new Dropdown.OptionData(this.dropCaptions[i]));
				}
				this.tabDropDown.value = 0;
				if (null != this.tabDropDown.captionText && this.dropCaptions.Length > this.tabDropDown.value && this.tabDropDown.value >= 0)
				{
					this.tabDropDown.captionText.text = this.dropCaptions[this.tabDropDown.value];
				}
				this.tabDropDown.onValueChanged.AddListener(new UnityAction<int>(this._OnDropDownChanged));
			}
		}

		// Token: 0x0600C4E0 RID: 50400 RVA: 0x002F50A4 File Offset: 0x002F34A4
		private void _OnDropDownChanged(int option)
		{
			if (option >= 0 && option < this.dropValues.Length)
			{
				this.mAchievementFilter = this.dropValues[option];
				this._AnsyInvoke();
			}
		}

		// Token: 0x0600C4E1 RID: 50401 RVA: 0x002F50CF File Offset: 0x002F34CF
		public void ChangeTabStatus(bool bEnable)
		{
			if (null != this.comTabStatus)
			{
				this.comTabStatus.Key = ((!bEnable) ? "Disable" : "Enable");
			}
			this.ResetScrollViewSize(bEnable);
		}

		// Token: 0x0600C4E2 RID: 50402 RVA: 0x002F510C File Offset: 0x002F350C
		public void ResetScrollViewSize(bool bMin)
		{
			Vector2 anchoredPosition = (!bMin) ? this.anchorPos1 : this.anchorPos0;
			float num = (!bMin) ? this.sizeY1 : this.sizeY0;
			if (null != this.rectScrollView)
			{
				this.rectScrollView.SetSizeWithCurrentAnchors(1, num);
				this.rectScrollView.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x0600C4E3 RID: 50403 RVA: 0x002F5174 File Offset: 0x002F3574
		private void Awake()
		{
			if (this.itemParents != null)
			{
				for (int i = 0; i < this.itemParents.Length; i++)
				{
					if (null != this.itemParents[i])
					{
						this.comItems.Add(ComItemManager.Create(this.itemParents[i]));
					}
				}
			}
			this._InitAchievementList();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementSecondMenuTabChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementSecondMenuTabChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementGroupSubTabChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementGroupSubTabChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementGroupSubTabChangedRepeated, new ClientEventSystem.UIEventHandler(this._OnAchievementGroupSubTabChangedRepeated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementMaskPropertyChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementMaskPropertyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShareAchievementItem, new ClientEventSystem.UIEventHandler(this._OnShareAchievementItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
			NetProcess.AddMsgHandler(500803U, new Action<MsgDATA>(this._OnNetSyncChat));
			this._InitRank();
		}

		// Token: 0x0600C4E4 RID: 50404 RVA: 0x002F5306 File Offset: 0x002F3706
		private void _mainToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				this._UpdateRank();
			}
		}

		// Token: 0x0600C4E5 RID: 50405 RVA: 0x002F5314 File Offset: 0x002F3714
		private void _InitRank()
		{
			if (null != this.rank)
			{
				this.rank.text = this.rankDisable;
			}
		}

		// Token: 0x0600C4E6 RID: 50406 RVA: 0x002F5338 File Offset: 0x002F3738
		private void _UpdateRank()
		{
			if (!this._query)
			{
				this._query = true;
				this._RequestRanklist(0, 100, delegate(AchievementScoreSortListEntry data)
				{
					if (data != null)
					{
						if (null != this.rank)
						{
							if (data.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								this.rank.text = string.Format(this.rankEnableFmt, data.ranking);
							}
							else
							{
								this.rank.text = this.rankDisable;
							}
						}
					}
					else if (null != this.rank)
					{
						this.rank.text = this.rankDisable;
					}
					this._query = false;
				}, delegate
				{
					this._query = false;
				});
			}
		}

		// Token: 0x0600C4E7 RID: 50407 RVA: 0x002F5370 File Offset: 0x002F3770
		public void UpdateAwardStatus()
		{
			if (null != this.comAwardStatus && this.awardKeys.Length == 3)
			{
				int firstUnAcquiredID = DataManager<AchievementGroupDataManager>.GetInstance().GetFirstUnAcquiredID();
				if (firstUnAcquiredID == 0)
				{
					this.comAwardStatus.Key = this.awardKeys[2];
				}
				else
				{
					AchievementLevelInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(firstUnAcquiredID, string.Empty, string.Empty);
					if (tableItem == null)
					{
						this.comAwardStatus.Key = this.awardKeys[0];
						Logger.LogErrorFormat("it is impossible !!!", new object[0]);
					}
					else
					{
						int achievementScore = DataManager<PlayerBaseData>.GetInstance().AchievementScore;
						if (achievementScore >= tableItem.Max)
						{
							this.comAwardStatus.Key = this.awardKeys[1];
						}
						else
						{
							this.comAwardStatus.Key = this.awardKeys[0];
						}
					}
				}
			}
		}

		// Token: 0x0600C4E8 RID: 50408 RVA: 0x002F544B File Offset: 0x002F384B
		private void _OnAddNewMission(uint taskID)
		{
			this.UpdateAchievementPoint();
			this._AnsyInvoke();
			this.UpdateTabProcess();
		}

		// Token: 0x0600C4E9 RID: 50409 RVA: 0x002F545F File Offset: 0x002F385F
		private void _OnUpdateMission(uint taskID)
		{
			this.UpdateAchievementPoint();
			this._AnsyInvoke();
			this.UpdateTabProcess();
		}

		// Token: 0x0600C4EA RID: 50410 RVA: 0x002F5473 File Offset: 0x002F3873
		private void _OnDeleteMission(uint taskID)
		{
			this.UpdateAchievementPoint();
			this._AnsyInvoke();
			this.UpdateTabProcess();
		}

		// Token: 0x0600C4EB RID: 50411 RVA: 0x002F5488 File Offset: 0x002F3888
		private void _OnAchievementGroupSubTabChanged(UIEvent uiEvent)
		{
			AchievementGroupMainItemTable achievementGroupMainItemTable = uiEvent.Param1 as AchievementGroupMainItemTable;
			this._MainItem = achievementGroupMainItemTable;
			this._MenuItem = null;
			if (null != this.tabDropDown)
			{
				this.tabDropDown.value = 0;
			}
			GameObject gameObject = uiEvent.Param2 as GameObject;
			if (achievementGroupMainItemTable != null && null != this.comSubTabItems)
			{
				this.comSubTabItems.SetFlags(achievementGroupMainItemTable);
			}
			if (null != gameObject && null != this.comSubTabItems)
			{
				Utility.AttachTo(this.comSubTabItems.gameObject, gameObject, false);
			}
			this.ChangeTabStatus(this._MainItem != null && this._MainItem.ChildTabs.Count == 1);
			this._AnsyInvoke();
			this.UpdateTabProcess();
			this.UpdateTabBaseInfo();
		}

		// Token: 0x0600C4EC RID: 50412 RVA: 0x002F5564 File Offset: 0x002F3964
		private void _OnAchievementGroupSubTabChangedRepeated(UIEvent uiEvent)
		{
			AchievementGroupMainItemTable mainItem = uiEvent.Param1 as AchievementGroupMainItemTable;
			this._MainItem = mainItem;
			this._MenuItem = null;
			if (null != this.tabDropDown)
			{
				this.tabDropDown.value = 0;
			}
			GameObject gameObject = uiEvent.Param2 as GameObject;
			if (null != this.comSubTabItems)
			{
				this.comSubTabItems.SetFlags(null);
			}
			this.ChangeTabStatus(this._MainItem != null && this._MainItem.ChildTabs.Count == 1);
			this._AnsyInvoke();
			this.UpdateTabProcess();
			this.UpdateTabBaseInfo();
		}

		// Token: 0x0600C4ED RID: 50413 RVA: 0x002F560A File Offset: 0x002F3A0A
		private void _OnAchievementMaskPropertyChanged(UIEvent uiEvent)
		{
			this.UpdateAwardStatus();
			this._UpdateLevelAwardDesc();
		}

		// Token: 0x0600C4EE RID: 50414 RVA: 0x002F5618 File Offset: 0x002F3A18
		private void _OnAchievementScoreChanged(UIEvent uiEvent)
		{
			this.UpdateAwardStatus();
			this.UpdateAchievementPoint();
			this._UpdateLevelAwardDesc();
		}

		// Token: 0x0600C4EF RID: 50415 RVA: 0x002F562C File Offset: 0x002F3A2C
		private void _OnShareAchievementItem(UIEvent uiEvent)
		{
			this._menuData = (uiEvent.Param1 as AchievementGroupSubItemTable);
			if (null != this.menuRect)
			{
				Vector2 one = Vector2.one;
				GameObject gameObject = GameObject.Find("UIRoot/UI2DRoot");
				if (null != gameObject)
				{
					Canvas component = gameObject.GetComponent<Canvas>();
					if (null != component)
					{
						RectTransformUtility.ScreenPointToLocalPointInRectangle(this.menuRect.parent.transform as RectTransform, Input.mousePosition, component.worldCamera, ref one);
					}
				}
				one.y = Mathf.Clamp(one.y, this.menuRange.x, this.menuRange.y);
				one.x = this.menuRect.anchoredPosition.x;
				this.menuRect.anchoredPosition = one;
			}
		}

		// Token: 0x0600C4F0 RID: 50416 RVA: 0x002F5708 File Offset: 0x002F3B08
		private void _OnAchievementSecondMenuTabChanged(UIEvent uiEvent)
		{
			this._MenuItem = (uiEvent.Param1 as AchievementGroupSecondMenuTable);
			if (null != this.tabDropDown)
			{
				this.tabDropDown.value = 0;
			}
			this.ChangeTabStatus(false);
			this._AnsyInvoke();
			this.UpdateTabProcess();
			this.UpdateTabBaseInfo();
		}

		// Token: 0x0600C4F1 RID: 50417 RVA: 0x002F575C File Offset: 0x002F3B5C
		private void _AnsyInvoke()
		{
			InvokeMethod.RemoveInvokeCall(this);
			InvokeMethod.Invoke(this, 0.05f, new UnityAction(this._UpdateItems));
		}

		// Token: 0x0600C4F2 RID: 50418 RVA: 0x002F577C File Offset: 0x002F3B7C
		private int _SortAll(AchievementGroupSubItemTable l, AchievementGroupSubItemTable r)
		{
			MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)l.ID);
			MissionManager.SingleMissionInfo mission2 = DataManager<MissionManager>.GetInstance().GetMission((uint)r.ID);
			if (mission.status != mission2.status)
			{
				if (mission.status == 5)
				{
					return 1;
				}
				if (mission2.status == 5)
				{
					return -1;
				}
				return (int)(mission2.status - mission.status);
			}
			else
			{
				if (l.sort0 != r.sort0)
				{
					return l.sort0 - r.sort0;
				}
				if (mission.taskID != mission2.taskID)
				{
					return (mission.taskID >= mission2.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600C4F3 RID: 50419 RVA: 0x002F5830 File Offset: 0x002F3C30
		private int _SortTabItem(AchievementGroupSubItemTable l, AchievementGroupSubItemTable r)
		{
			MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)l.ID);
			MissionManager.SingleMissionInfo mission2 = DataManager<MissionManager>.GetInstance().GetMission((uint)r.ID);
			if (mission.status != mission2.status)
			{
				if (mission.status == 5)
				{
					return 1;
				}
				if (mission2.status == 5)
				{
					return -1;
				}
				return (int)(mission2.status - mission.status);
			}
			else
			{
				if (l.sort1 != r.sort1)
				{
					return l.sort1 - r.sort1;
				}
				if (mission.taskID != mission2.taskID)
				{
					return (mission.taskID >= mission2.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600C4F4 RID: 50420 RVA: 0x002F58E4 File Offset: 0x002F3CE4
		private void _GetValidItems(ref List<AchievementGroupSubItemTable> items)
		{
			for (int i = 0; i < this.mListItems.Count; i++)
			{
				if (this.mListItems[i] == null)
				{
					this.mListItems.RemoveAt(i--);
				}
				else
				{
					MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)this.mListItems[i].ID);
					if (mission == null || mission.missionItem == null)
					{
						this.mListItems.RemoveAt(i--);
					}
				}
			}
		}

		// Token: 0x0600C4F5 RID: 50421 RVA: 0x002F5978 File Offset: 0x002F3D78
		private void _UpdateItems()
		{
			this.mListItems = null;
			if (this._MainItem.ChildTabs.Count == 1)
			{
				DataManager<AchievementGroupDataManager>.GetInstance().GetAllItems(ref this.mListItems);
				this._GetValidItems(ref this.mListItems);
				this.mListItems.Sort(new Comparison<AchievementGroupSubItemTable>(this._SortAll));
			}
			else
			{
				DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsByTag(this._MainItem, this._MenuItem, ref this.mListItems);
				this._GetValidItems(ref this.mListItems);
				this.mListItems.Sort(new Comparison<AchievementGroupSubItemTable>(this._SortTabItem));
			}
			if (this.mListItems != null && this.mAchievementFilter != ComActiveGroupMain.AchievementFilter.AF_ALL)
			{
				for (int i = 0; i < this.mListItems.Count; i++)
				{
					if (this.mListItems[i] == null)
					{
						this.mListItems.RemoveAt(i--);
					}
					else
					{
						MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)this.mListItems[i].ID);
						if (mission == null || mission.missionItem == null)
						{
							Logger.LogErrorFormat("can not get mission id = {0}", new object[]
							{
								this.mListItems[i].ID
							});
							this.mListItems.RemoveAt(i--);
						}
						else if (this.mAchievementFilter == ComActiveGroupMain.AchievementFilter.AF_FINISHED)
						{
							if (mission.status < 2)
							{
								this.mListItems.RemoveAt(i--);
							}
						}
						else if (this.mAchievementFilter == ComActiveGroupMain.AchievementFilter.AF_UNFINISHED && mission.status > 1)
						{
							this.mListItems.RemoveAt(i--);
						}
					}
				}
			}
			if (null != this.comAchievementList && this.mListItems != null)
			{
				this.comAchievementList.SetElementAmount(this.mListItems.Count);
				this.comAchievementList.EnsureElementVisable(0);
			}
		}

		// Token: 0x0600C4F6 RID: 50422 RVA: 0x002F5B7C File Offset: 0x002F3F7C
		public void CreateMainTabs()
		{
			if (null == this.mPrefabMainTab)
			{
				return;
			}
			this.mPrefabMainTab.CustomActive(false);
			this.goExpandParentPrefab.CustomActive(false);
			this.mDatas.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AchievementGroupMainItemTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AchievementGroupMainItemTable achievementGroupMainItemTable = keyValuePair.Value as AchievementGroupMainItemTable;
				if (achievementGroupMainItemTable != null)
				{
					ComActiveGroupMainTab comActiveGroupMainTab = Object.Instantiate<ComActiveGroupMainTab>(this.mPrefabMainTab);
					comActiveGroupMainTab.name = achievementGroupMainItemTable.Name;
					Utility.AttachTo(comActiveGroupMainTab.gameObject, this.goParent, false);
					comActiveGroupMainTab.mainItem = achievementGroupMainItemTable;
					comActiveGroupMainTab.CustomActive(true);
					GameObject gameObject = Object.Instantiate<GameObject>(this.goExpandParentPrefab);
					gameObject.name = achievementGroupMainItemTable.Name + "_p";
					Utility.AttachTo(gameObject.gameObject, this.goParent, false);
					comActiveGroupMainTab.expandParent = gameObject;
					gameObject.CustomActive(true);
					this.mDatas.Add(new ComActiveGroupMain.MainTabData
					{
						tab = comActiveGroupMainTab,
						value = achievementGroupMainItemTable,
						expandParent = gameObject
					});
					comActiveGroupMainTab.SetBinderID(achievementGroupMainItemTable.ID, -1);
				}
			}
			for (int i = 0; i < this.mDatas.Count; i++)
			{
				this.mDatas[i].tab.UpdateItemValue();
				this.mDatas[i].tab.OnValueChanged(false);
			}
			this._registerMainTab();
		}

		// Token: 0x0600C4F7 RID: 50423 RVA: 0x002F5D1C File Offset: 0x002F411C
		private void _registerMainTab()
		{
			if (this.mDatas != null && this.mDatas.Count > 0 && null != this.mDatas[0].tab && null != this.mDatas[0].tab.toggle)
			{
				this.mDatas[0].tab.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._mainToggleValueChanged));
			}
		}

		// Token: 0x0600C4F8 RID: 50424 RVA: 0x002F5DB8 File Offset: 0x002F41B8
		private void _unregisterMainTab()
		{
			if (this.mDatas != null && this.mDatas.Count > 0 && null != this.mDatas[0].tab && null != this.mDatas[0].tab.toggle)
			{
				this.mDatas[0].tab.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._mainToggleValueChanged));
			}
		}

		// Token: 0x0600C4F9 RID: 50425 RVA: 0x002F5E54 File Offset: 0x002F4254
		public void SelectTab(int iTabId)
		{
			for (int i = 0; i < this.mDatas.Count; i++)
			{
				for (int j = 0; j < this.mDatas[i].value.ChildTabs.Count; j++)
				{
					if (this.mDatas[i].value.ChildTabs[j] == iTabId)
					{
						this.mDatas[i].tab.OnValueChanged(true);
						return;
					}
				}
			}
		}

		// Token: 0x0600C4FA RID: 50426 RVA: 0x002F5EF0 File Offset: 0x002F42F0
		public void UpdateAchievementPoint()
		{
			int achievementScore = DataManager<PlayerBaseData>.GetInstance().AchievementScore;
			AchievementLevelInfoTable achievementLevelByPoint = DataManager<AchievementGroupDataManager>.GetInstance().GetAchievementLevelByPoint(achievementScore);
			if (null != this.levelName && achievementLevelByPoint != null)
			{
				this.levelName.text = achievementLevelByPoint.Name;
			}
			if (null != this.levelImg && achievementLevelByPoint != null)
			{
				ETCImageLoader.LoadSprite(ref this.levelImg, achievementLevelByPoint.Icon, true);
			}
			if (null != this.levelInfoIcon && achievementLevelByPoint != null)
			{
				ETCImageLoader.LoadSprite(ref this.levelInfoIcon, achievementLevelByPoint.TextIcon, true);
			}
			if (null != this.achievementPoint)
			{
				this.achievementPoint.text = string.Format(this.fmtPointString, achievementScore);
			}
			if (null != this.processInfo && achievementLevelByPoint != null)
			{
				int num = achievementScore;
				int subItemsAValue = DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsAValue(null, null, false);
				float value = Mathf.Clamp01((float)num * 1f / (float)subItemsAValue);
				this.processInfo.text = string.Format(this.fmtPointProcess, num, subItemsAValue);
				if (null != this.slider)
				{
					this.slider.value = value;
				}
			}
			this._UpdateLevelAwardDesc();
		}

		// Token: 0x0600C4FB RID: 50427 RVA: 0x002F603C File Offset: 0x002F443C
		private void _UpdateLevelAwardDesc()
		{
			int pointSum = this.GetPointSum();
			AchievementLevelInfoTable achievementLevelByPoint = DataManager<AchievementGroupDataManager>.GetInstance().GetAchievementLevelByPoint(pointSum);
			if (achievementLevelByPoint != null)
			{
				for (int i = 0; i < this.itemParents.Length; i++)
				{
					this.itemParents[i].CustomActive(i < achievementLevelByPoint.AwardID.Count);
				}
				for (int j = 0; j < achievementLevelByPoint.AwardID.Count; j++)
				{
					if (j < this.comItems.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(achievementLevelByPoint.AwardID[j], 100, 0);
						if (itemData != null && j < achievementLevelByPoint.AwardCount.Count)
						{
							itemData.Count = achievementLevelByPoint.AwardCount[j];
						}
						this.comItems[j].Setup(itemData, new ComItem.OnItemClicked(this._OnItemClicked));
					}
				}
			}
			if (null != this.levelAwardDesc)
			{
				this.levelAwardDesc.text = string.Format(this.levelAwardDescFmt, pointSum);
			}
		}

		// Token: 0x0600C4FC RID: 50428 RVA: 0x002F6150 File Offset: 0x002F4550
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C4FD RID: 50429 RVA: 0x002F6168 File Offset: 0x002F4568
		public int GetPointSum()
		{
			int num = DataManager<AchievementGroupDataManager>.GetInstance().GetFirstUnAcquiredID();
			if (num == 0)
			{
				num = DataManager<AchievementGroupDataManager>.GetInstance().GetLastAcquiredID();
			}
			if (num != 0)
			{
				AchievementLevelInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(num, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Max;
				}
			}
			return 0;
		}

		// Token: 0x0600C4FE RID: 50430 RVA: 0x002F61BC File Offset: 0x002F45BC
		private IEnumerator AnsyGetRank()
		{
			if (null != this.rank)
			{
				int rankNum = 25;
				yield return new WaitForEndOfFrame();
				if (rankNum == -1)
				{
					this.rank.text = this.rankDisable;
				}
				else
				{
					this.rank.text = string.Format(this.rankEnableFmt, rankNum);
				}
			}
			yield break;
		}

		// Token: 0x0600C4FF RID: 50431 RVA: 0x002F61D8 File Offset: 0x002F45D8
		private void _RequestRanklist(int a_startIndex, int a_count, UnityAction<AchievementScoreSortListEntry> ok, UnityAction failed)
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 16;
			worldSortListReq.start = (ushort)a_startIndex;
			worldSortListReq.num = (ushort)a_count;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet != null)
				{
					int num = 0;
					BaseSortList baseSortList = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
					if (baseSortList != null)
					{
						for (int i = 0; i < baseSortList.entries.Count; i++)
						{
							AchievementScoreSortListEntry achievementScoreSortListEntry = baseSortList.entries[i] as AchievementScoreSortListEntry;
							if (achievementScoreSortListEntry != null && achievementScoreSortListEntry.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								baseSortList.selfEntry = achievementScoreSortListEntry;
								break;
							}
						}
						AchievementScoreSortListEntry achievementScoreSortListEntry2 = baseSortList.selfEntry as AchievementScoreSortListEntry;
						if (achievementScoreSortListEntry2 != null && ok != null)
						{
							ok.Invoke(achievementScoreSortListEntry2);
							return;
						}
					}
				}
				if (failed != null)
				{
					failed.Invoke();
				}
			}, true, 15f, delegate()
			{
				if (failed != null)
				{
					failed.Invoke();
				}
			});
		}

		// Token: 0x0600C500 RID: 50432 RVA: 0x002F6255 File Offset: 0x002F4655
		public void OnClickLookUpRank()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<RanklistFrame>(FrameLayer.Middle, SortListType.SORTLIST_ACHIEVEMENT_SCORE, string.Empty);
		}

		// Token: 0x0600C501 RID: 50433 RVA: 0x002F6270 File Offset: 0x002F4670
		public void OnClickGetLevelAwards()
		{
			if (DataManager<ItemDataManager>.GetInstance().IsPackageFull(EPackageType.Invalid))
			{
				SystemNotifyManager.SystemNotify(9058, string.Empty);
				return;
			}
			int firstUnAcquiredID = DataManager<AchievementGroupDataManager>.GetInstance().GetFirstUnAcquiredID();
			if (firstUnAcquiredID != 0)
			{
				DataManager<AchievementGroupDataManager>.GetInstance().SendGetAward(firstUnAcquiredID);
				AchievementAwardPlayFrame.CommandOpen(new AchievementAwardPlayFrameData
				{
					iId = firstUnAcquiredID
				});
			}
		}

		// Token: 0x0600C502 RID: 50434 RVA: 0x002F62CC File Offset: 0x002F46CC
		protected void _InitAchievementList()
		{
			if (null != this.comAchievementList)
			{
				this.comAchievementList.Initialize();
				this.comAchievementList.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComAchievementSubItem>();
					}
					return null;
				};
				this.comAchievementList.onItemVisiable = delegate(ComUIListElementScript item)
				{
					if (this.mListItems != null && null != item && item.m_index >= 0 && item.m_index < this.mListItems.Count)
					{
						ComAchievementSubItem comAchievementSubItem = item.gameObjectBindScript as ComAchievementSubItem;
						if (null != comAchievementSubItem)
						{
							comAchievementSubItem.OnItemVisible(this.mListItems[item.m_index]);
						}
					}
				};
			}
		}

		// Token: 0x0600C503 RID: 50435 RVA: 0x002F6334 File Offset: 0x002F4734
		public void StopInvoke()
		{
			InvokeMethod.RemoveInvokeCall(this);
			InvokeMethod.RmoveInvokeIntervalCall(this);
		}

		// Token: 0x0600C504 RID: 50436 RVA: 0x002F6344 File Offset: 0x002F4744
		private void OnDestroy()
		{
			NetProcess.RemoveMsgHandler(500803U, new Action<MsgDATA>(this._OnNetSyncChat));
			this._unregisterMainTab();
			this.goParent = null;
			this.mPrefabMainTab = null;
			this.mListItems = null;
			if (null != this.comAchievementList)
			{
				this.comAchievementList.onBindItem = null;
				this.comAchievementList.onItemVisiable = null;
			}
			for (int i = 0; i < this.comItems.Count; i++)
			{
				ComItemManager.Destroy(this.comItems[i]);
			}
			this.comItems.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementGroupSubTabChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementGroupSubTabChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementGroupSubTabChangedRepeated, new ClientEventSystem.UIEventHandler(this._OnAchievementGroupSubTabChangedRepeated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementSecondMenuTabChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementSecondMenuTabChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementMaskPropertyChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementMaskPropertyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShareAchievementItem, new ClientEventSystem.UIEventHandler(this._OnShareAchievementItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
			if (null != this.tabDropDown)
			{
				this.tabDropDown.onValueChanged.RemoveListener(new UnityAction<int>(this._OnDropDownChanged));
				this.tabDropDown = null;
			}
			this.mAchievementFilter = ComActiveGroupMain.AchievementFilter.AF_ALL;
			this._menuData = null;
			this._query = false;
			this.StopInvoke();
		}

		// Token: 0x04007025 RID: 28709
		public GameObject goParent;

		// Token: 0x04007026 RID: 28710
		public ComActiveGroupMainTab mPrefabMainTab;

		// Token: 0x04007027 RID: 28711
		public Text levelName;

		// Token: 0x04007028 RID: 28712
		public Image levelImg;

		// Token: 0x04007029 RID: 28713
		public Image levelInfoIcon;

		// Token: 0x0400702A RID: 28714
		public string fmtPointString;

		// Token: 0x0400702B RID: 28715
		public Text achievementPoint;

		// Token: 0x0400702C RID: 28716
		public string fmtPointProcess;

		// Token: 0x0400702D RID: 28717
		public Text processInfo;

		// Token: 0x0400702E RID: 28718
		public Slider slider;

		// Token: 0x0400702F RID: 28719
		public Text rank;

		// Token: 0x04007030 RID: 28720
		public string rankDisable;

		// Token: 0x04007031 RID: 28721
		public string rankEnableFmt;

		// Token: 0x04007032 RID: 28722
		public GameObject[] itemParents;

		// Token: 0x04007033 RID: 28723
		private List<ComItem> comItems = new List<ComItem>(4);

		// Token: 0x04007034 RID: 28724
		public string levelAwardDescFmt;

		// Token: 0x04007035 RID: 28725
		public Text levelAwardDesc;

		// Token: 0x04007036 RID: 28726
		public ComUIListScript comAchievementList;

		// Token: 0x04007037 RID: 28727
		public ComAchievementGroupSubTabItems comSubTabItems;

		// Token: 0x04007038 RID: 28728
		public GameObject goExpandParentPrefab;

		// Token: 0x04007039 RID: 28729
		public StateController comTabStatus;

		// Token: 0x0400703A RID: 28730
		public Text tabItemName;

		// Token: 0x0400703B RID: 28731
		public Image tabItemIcon;

		// Token: 0x0400703C RID: 28732
		public Text tabProcessInfo;

		// Token: 0x0400703D RID: 28733
		public Slider tabSlider;

		// Token: 0x0400703E RID: 28734
		public string[] dropCaptions = new string[0];

		// Token: 0x0400703F RID: 28735
		public ComActiveGroupMain.AchievementFilter[] dropValues = new ComActiveGroupMain.AchievementFilter[0];

		// Token: 0x04007040 RID: 28736
		public Dropdown tabDropDown;

		// Token: 0x04007041 RID: 28737
		public string[] awardKeys = new string[0];

		// Token: 0x04007042 RID: 28738
		public StateController comAwardStatus;

		// Token: 0x04007043 RID: 28739
		public Vector2 anchorPos0 = Vector2.zero;

		// Token: 0x04007044 RID: 28740
		public Vector2 anchorPos1 = Vector2.zero;

		// Token: 0x04007045 RID: 28741
		public float sizeY0;

		// Token: 0x04007046 RID: 28742
		public float sizeY1;

		// Token: 0x04007047 RID: 28743
		public RectTransform rectScrollView;

		// Token: 0x04007048 RID: 28744
		public RectTransform menuRect;

		// Token: 0x04007049 RID: 28745
		public Vector2 menuRange;

		// Token: 0x0400704A RID: 28746
		private ComActiveGroupMain.AchievementFilter mAchievementFilter;

		// Token: 0x0400704B RID: 28747
		public ChatType[] mChatTypes = new ChatType[0];

		// Token: 0x0400704C RID: 28748
		public string[] mFmtContents = new string[0];

		// Token: 0x0400704D RID: 28749
		public int[] mLinkIDs = new int[]
		{
			18,
			19,
			20
		};

		// Token: 0x0400704E RID: 28750
		public string mShareHint = string.Empty;

		// Token: 0x0400704F RID: 28751
		private AchievementGroupSubItemTable _menuData;

		// Token: 0x04007050 RID: 28752
		private bool _query;

		// Token: 0x04007051 RID: 28753
		private AchievementGroupMainItemTable _MainItem;

		// Token: 0x04007052 RID: 28754
		private AchievementGroupSecondMenuTable _MenuItem;

		// Token: 0x04007053 RID: 28755
		private List<ComActiveGroupMain.MainTabData> mDatas = new List<ComActiveGroupMain.MainTabData>(12);

		// Token: 0x04007054 RID: 28756
		private List<AchievementGroupSubItemTable> mListItems = new List<AchievementGroupSubItemTable>(32);

		// Token: 0x020013D8 RID: 5080
		public enum AchievementFilter
		{
			// Token: 0x04007057 RID: 28759
			AF_ALL,
			// Token: 0x04007058 RID: 28760
			AF_UNFINISHED,
			// Token: 0x04007059 RID: 28761
			AF_FINISHED
		}

		// Token: 0x020013D9 RID: 5081
		private struct MainTabData
		{
			// Token: 0x0400705A RID: 28762
			public AchievementGroupMainItemTable value;

			// Token: 0x0400705B RID: 28763
			public ComActiveGroupMainTab tab;

			// Token: 0x0400705C RID: 28764
			public GameObject expandParent;
		}
	}
}
