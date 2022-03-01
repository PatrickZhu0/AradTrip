using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001991 RID: 6545
	internal class PKSeasonDetailFrame : ClientFrame
	{
		// Token: 0x0600FEAC RID: 65196 RVA: 0x00467539 File Offset: 0x00465939
		protected sealed override void _bindExUI()
		{
			this.mPkSeasonDetaiFashionItem = this.mBind.GetCom<PKSeasonDetaiFashionItem>("pkSeasonDetaiFashionItem");
		}

		// Token: 0x0600FEAD RID: 65197 RVA: 0x00467551 File Offset: 0x00465951
		protected sealed override void _unbindExUI()
		{
			this.mPkSeasonDetaiFashionItem = null;
		}

		// Token: 0x0600FEAE RID: 65198 RVA: 0x0046755A File Offset: 0x0046595A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKSeasonDetail";
		}

		// Token: 0x0600FEAF RID: 65199 RVA: 0x00467564 File Offset: 0x00465964
		protected override void _OnOpenFrame()
		{
			this._InitBaseGroup();
			this._InitAttrGroup();
			this._InitDailyGroup();
			this._BindGameEvent();
			ESeasonDetailType eseasonDetailType = ESeasonDetailType.Base;
			if (this.userData != null)
			{
				eseasonDetailType = (ESeasonDetailType)this.userData;
			}
			if (eseasonDetailType != ESeasonDetailType.Base)
			{
				if (eseasonDetailType != ESeasonDetailType.Attr)
				{
					if (eseasonDetailType == ESeasonDetailType.Daily)
					{
						this.m_togDaily.isOn = true;
					}
				}
				else
				{
					this.m_togAttr.isOn = true;
				}
			}
			else
			{
				this.m_togBase.isOn = true;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FEB0 RID: 65200 RVA: 0x00467601 File Offset: 0x00465A01
		protected override void _OnCloseFrame()
		{
			this._ClearBaseGroup();
			this._ClearAttrGroup();
			this._ClearDailyGroup();
			this._UnBindGameEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600FEB1 RID: 65201 RVA: 0x00467630 File Offset: 0x00465A30
		private void _BindGameEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKSelfLevelUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonRankUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SeasonStarted, new ClientEventSystem.UIEventHandler(this._OnSeasonStarted));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
		}

		// Token: 0x0600FEB2 RID: 65202 RVA: 0x004676AC File Offset: 0x00465AAC
		private void _UnBindGameEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKSelfLevelUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonRankUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SeasonStarted, new ClientEventSystem.UIEventHandler(this._OnSeasonStarted));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
		}

		// Token: 0x0600FEB3 RID: 65203 RVA: 0x00467728 File Offset: 0x00465B28
		private void _InitBaseGroup()
		{
			for (int i = 0; i < this.m_objDigitRoot.transform.childCount; i++)
			{
				this.m_objDigitRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
			int num = 0;
			int j = DataManager<SeasonDataManager>.GetInstance().seasonID;
			while (j > 0)
			{
				int num2 = j % 10;
				GameObject gameObject;
				if (num < this.m_objDigitRoot.transform.childCount)
				{
					gameObject = this.m_objDigitRoot.transform.GetChild(num).gameObject;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objDigitTemplate);
					gameObject.transform.SetParent(this.m_objDigitRoot.transform, false);
					gameObject.transform.SetAsFirstSibling();
				}
				gameObject.SetActive(true);
				Image component = gameObject.GetComponent<Image>();
				ETCImageLoader.LoadSprite(ref component, TR.Value("pk_rank_detail_digit_path", num2), true);
				j /= 10;
				num++;
			}
			this.m_repeatCallSeasonTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				this.m_labSeasonTimeLeft.text = TR.Value("pk_rank_detail_time_left", DataManager<SeasonDataManager>.GetInstance().seasonID, this._GetTimeLeft(DataManager<SeasonDataManager>.GetInstance().seasonEndTime));
			}, 9999999, true);
			this.m_rewardList.Initialize();
			this.m_rewardList.onBindItem = delegate(GameObject obj)
			{
				ComSeasonReward component2 = obj.GetComponent<ComSeasonReward>();
				component2.arrComItems.Add(base.CreateComItem(component2.objReward0));
				component2.arrComItems.Add(base.CreateComItem(component2.objReward1));
				component2.arrComItems.Add(base.CreateComItem(component2.objReward2));
				component2.arrComItems.Add(base.CreateComItem(component2.objReward3));
				component2.arrComItems.Add(base.CreateComItem(component2.objReward4));
				component2.arrComItems.Add(base.CreateComItem(component2.objReward5));
				return component2;
			};
			this.m_rewardList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				List<SeasonLevel> seasonRewards = DataManager<SeasonDataManager>.GetInstance().GetSeasonRewards();
				if (item.m_index >= 0 && item.m_index < seasonRewards.Count)
				{
					SeasonLevel seasonLevel = seasonRewards[item.m_index];
					ComSeasonReward comSeasonReward = item.gameObjectBindScript as ComSeasonReward;
					ETCImageLoader.LoadSprite(ref comSeasonReward.imgSeasonIcon, seasonLevel.levelTable.Icon, true);
					comSeasonReward.labSeasonName.text = DataManager<SeasonDataManager>.GetInstance().GetRankName(seasonLevel.levelTable.ID, false);
					int k = 0;
					while (k < comSeasonReward.arrComItems.Count)
					{
						if (k >= seasonLevel.levelTable.SeasonRewards.Count)
						{
							goto IL_13A;
						}
						string[] array = seasonLevel.levelTable.SeasonRewards[k].Split(new char[]
						{
							','
						});
						if (array.Length != 2)
						{
							goto IL_13A;
						}
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
						if (itemData == null)
						{
							goto IL_13A;
						}
						itemData.Count = int.Parse(array[1]);
						comSeasonReward.arrComItems[k].gameObject.SetActive(true);
						comSeasonReward.arrComItems[k].Setup(itemData, delegate(GameObject var1, ItemData var2)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						});
						IL_160:
						k++;
						continue;
						IL_13A:
						comSeasonReward.arrComItems[k].gameObject.transform.parent.gameObject.CustomActive(false);
						goto IL_160;
					}
					comSeasonReward.objMySeasonLevel.SetActive(DataManager<SeasonDataManager>.GetInstance().IsMainLevelSame(seasonLevel.levelTable.ID, DataManager<CountDataManager>.GetInstance().GetCount(string.Format("season_max_level", new object[0]))));
				}
			};
			this.m_rewardList.SetElementAmount(DataManager<SeasonDataManager>.GetInstance().GetSeasonRewards().Count);
			this.m_togBase.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._SelectMySeasonReward();
				}
			});
			if (this.mPkSeasonDetaiFashionItem != null)
			{
				this.mPkSeasonDetaiFashionItem.InitItem();
			}
		}

		// Token: 0x0600FEB4 RID: 65204 RVA: 0x004678F2 File Offset: 0x00465CF2
		private void _ClearBaseGroup()
		{
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallSeasonTime);
		}

		// Token: 0x0600FEB5 RID: 65205 RVA: 0x0046790C File Offset: 0x00465D0C
		private string _GetTimeLeft(int a_nEndTime)
		{
			int num = a_nEndTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num > 0)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = num % 60;
				int num6 = num / 60;
				if (num6 > 0)
				{
					num2 = num6 % 60;
					num6 /= 60;
					if (num6 > 0)
					{
						num3 = num6 % 24;
						num4 = num6 / 24;
					}
				}
				string str = string.Empty;
				str += string.Format("{0}天", num4);
				str += string.Format("{0:D2}小时", num3);
				str += string.Format("{0:D2}分", num2);
				return str + string.Format("{0:D2}秒", num5);
			}
			return string.Empty;
		}

		// Token: 0x0600FEB6 RID: 65206 RVA: 0x004679E0 File Offset: 0x00465DE0
		private void _SelectMySeasonReward()
		{
			List<SeasonLevel> seasonRewards = DataManager<SeasonDataManager>.GetInstance().GetSeasonRewards();
			for (int i = 0; i < seasonRewards.Count; i++)
			{
				if (DataManager<SeasonDataManager>.GetInstance().IsMainLevelSame(seasonRewards[i].levelTable.ID, DataManager<SeasonDataManager>.GetInstance().seasonLevel))
				{
					this.m_rewardList.EnsureElementVisable(i);
					break;
				}
			}
		}

		// Token: 0x0600FEB7 RID: 65207 RVA: 0x00467A4C File Offset: 0x00465E4C
		private void _InitAttrGroup()
		{
			this.m_labMyAttrTitle.text = TR.Value("pk_rank_detail_attr_desc", DataManager<SeasonDataManager>.GetInstance().GetRankName(DataManager<SeasonDataManager>.GetInstance().seasonAttrMappedSeasonID, true));
			SeasonLevel seasonAttr = DataManager<SeasonDataManager>.GetInstance().GetSeasonAttr(DataManager<SeasonDataManager>.GetInstance().seasonAttrID);
			if (seasonAttr != null)
			{
				this.m_labMyAttrContent.text = seasonAttr.strFormatAttr;
			}
			else
			{
				this.m_labMyAttrContent.text = string.Empty;
			}
			this.m_attrList.Initialize();
			this.m_attrList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				List<SeasonLevel> seasonAttrs = DataManager<SeasonDataManager>.GetInstance().GetSeasonAttrs();
				if (var.m_index >= 0 && var.m_index < seasonAttrs.Count)
				{
					SeasonLevel seasonLevel = seasonAttrs[var.m_index];
					ComSeasonAttr component = var.gameObject.GetComponent<ComSeasonAttr>();
					ETCImageLoader.LoadSprite(ref component.imgSeasonIcon, seasonLevel.levelTable.Icon, true);
					component.labSeasonName.text = TR.Value(string.Format("pk_rank_attr_name{0}", seasonLevel.attrTable.ID));
					component.labSeasonAttr.text = seasonLevel.strFormatAttr;
					if (seasonLevel.attrTable.ID == DataManager<SeasonDataManager>.GetInstance().GetNextAttrID())
					{
						component.objWillGet.SetActive(true);
						this.m_labAttrTime = component.labWillGetDesc;
					}
					else
					{
						component.objWillGet.SetActive(false);
					}
				}
			};
			this.m_attrList.SetElementAmount(DataManager<SeasonDataManager>.GetInstance().GetSeasonAttrs().Count);
			this.m_repeatCallAttrTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				if (this.m_labAttrTime != null)
				{
					this.m_labAttrTime.text = TR.Value("pk_rank_detail_attr_time_left", this._GetTimeLeft(DataManager<SeasonDataManager>.GetInstance().seasonAttrEndTime));
				}
			}, 9999999, true);
			this.m_togAttr.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._SelectMySeasonAttr();
				}
			});
			DataManager<SeasonDataManager>.GetInstance().RequestSelfPKRank();
		}

		// Token: 0x0600FEB8 RID: 65208 RVA: 0x00467B52 File Offset: 0x00465F52
		private void _ClearAttrGroup()
		{
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallAttrTime);
			this.m_labAttrTime = null;
		}

		// Token: 0x0600FEB9 RID: 65209 RVA: 0x00467B70 File Offset: 0x00465F70
		private void _SelectMySeasonAttr()
		{
			List<SeasonLevel> seasonAttrs = DataManager<SeasonDataManager>.GetInstance().GetSeasonAttrs();
			for (int i = 0; i < seasonAttrs.Count; i++)
			{
				if (seasonAttrs[i].attrTable.ID == DataManager<SeasonDataManager>.GetInstance().GetNextAttrID())
				{
					this.m_attrList.EnsureElementVisable(i);
					break;
				}
			}
		}

		// Token: 0x0600FEBA RID: 65210 RVA: 0x00467BD0 File Offset: 0x00465FD0
		private void _InitDailyGroup()
		{
			this._SetupDailyRewards();
		}

		// Token: 0x0600FEBB RID: 65211 RVA: 0x00467BD8 File Offset: 0x00465FD8
		private void _ClearDailyGroup()
		{
		}

		// Token: 0x0600FEBC RID: 65212 RVA: 0x00467BDC File Offset: 0x00465FDC
		private void _SetupDailyRewards()
		{
			this.m_objDailyRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.DailyProve));
			int num = 1;
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				uint nTaskID = list[i].taskID;
				if (Utility.IsDailyProve(nTaskID))
				{
					MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)nTaskID, string.Empty, string.Empty);
					Utility.DailyProveTaskConfig dailyProveTaskConfig = Utility.GetDailyProveTaskConfig((int)nTaskID);
					GameObject gameObject = Utility.FindGameObject(this.frame, string.Format("Content/Groups/Daily/Daily{0}", num), true);
					Utility.GetComponetInChild<Text>(gameObject, "Description").text = DataManager<MissionManager>.GetInstance().GetMissionName(nTaskID);
					Utility.GetComponetInChild<Text>(gameObject, "ProgressBar/Text").text = string.Format("{0}/{1}", dailyProveTaskConfig.iPreValue, dailyProveTaskConfig.iAftValue);
					string[] array = tableItem.Award.Split(new char[]
					{
						','
					});
					if (array.Length > 0)
					{
						string[] array2 = array[0].Split(new char[]
						{
							'_'
						});
						if (array2.Length == 2)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
							if (itemData != null)
							{
								itemData.Count = int.Parse(array2[1]);
								GameObject gameObject2 = Utility.FindGameObject(gameObject, "award", true);
								ComItem comItem = gameObject2.GetComponentInChildren<ComItem>();
								if (comItem == null)
								{
									comItem = base.CreateComItem(gameObject2);
								}
								comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
								});
							}
						}
					}
					GameObject gameObject3 = Utility.FindGameObject(gameObject, "Acquired", true);
					GameObject gameObject4 = Utility.FindGameObject(gameObject, "UnAcquired", true);
					GameObject gameObject5 = Utility.FindGameObject(gameObject, "UnComplete", true);
					gameObject3.SetActive(false);
					gameObject4.SetActive(false);
					gameObject5.SetActive(false);
					if (list[i].status >= 5)
					{
						gameObject3.SetActive(true);
					}
					else if (list[i].status == 2)
					{
						gameObject4.SetActive(true);
					}
					else
					{
						gameObject5.SetActive(true);
					}
					Button componetInChild = Utility.GetComponetInChild<Button>(gameObject, "UnAcquired");
					componetInChild.onClick.RemoveAllListeners();
					componetInChild.onClick.AddListener(delegate()
					{
						DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(nTaskID, TaskSubmitType.TASK_SUBMIT_UI, 0U);
					});
					num++;
					if (num > 2)
					{
						break;
					}
				}
			}
		}

		// Token: 0x0600FEBD RID: 65213 RVA: 0x00467E88 File Offset: 0x00466288
		private void _OnSeasonRankUpdated(UIEvent a_event)
		{
			this.m_attrList.SetElementAmount(DataManager<SeasonDataManager>.GetInstance().GetSeasonAttrs().Count);
		}

		// Token: 0x0600FEBE RID: 65214 RVA: 0x00467EA4 File Offset: 0x004662A4
		private void _OnMissionUpdated(UIEvent a_event)
		{
			if (!Utility.IsDailyProve((uint)a_event.Param1))
			{
				return;
			}
			this._SetupDailyRewards();
		}

		// Token: 0x0600FEBF RID: 65215 RVA: 0x00467EC2 File Offset: 0x004662C2
		private void OnPk3v3VoteEnterBattle(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<PKSeasonDetailFrame>(this, false);
		}

		// Token: 0x0600FEC0 RID: 65216 RVA: 0x00467ED1 File Offset: 0x004662D1
		private void _OnSeasonStarted(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<PKSeasonDetailFrame>(this, false);
		}

		// Token: 0x0600FEC1 RID: 65217 RVA: 0x00467EE0 File Offset: 0x004662E0
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<PKSeasonDetailFrame>(this, false);
		}

		// Token: 0x0400A0A4 RID: 41124
		private PKSeasonDetaiFashionItem mPkSeasonDetaiFashionItem;

		// Token: 0x0400A0A5 RID: 41125
		[UIControl("Content/Tabs/Viewport/Content/Tab", null, 0)]
		private Toggle m_togBase;

		// Token: 0x0400A0A6 RID: 41126
		[UIControl("Content/Tabs/Viewport/Content/Tab (1)", null, 0)]
		private Toggle m_togAttr;

		// Token: 0x0400A0A7 RID: 41127
		[UIControl("Content/Tabs/Viewport/Content/Tab (2)", null, 0)]
		private Toggle m_togDaily;

		// Token: 0x0400A0A8 RID: 41128
		[UIObject("Content/Tabs/Viewport/Content/Tab (2)/RedPoint")]
		private GameObject m_objDailyRedPoint;

		// Token: 0x0400A0A9 RID: 41129
		[UIControl("Content/Groups/Base/SeasonGroup/RightTop/Text_T", null, 0)]
		private Text m_labSeasonTimeLeft;

		// Token: 0x0400A0AA RID: 41130
		[UIControl("Content/Groups/Base/SeasonGroup/RightBottom/Scroll View", null, 0)]
		private ComUIListScript m_rewardList;

		// Token: 0x0400A0AB RID: 41131
		[UIObject("Content/Groups/Base/SeasonGroup/RightTop/TitleGroup/Name/Numbers")]
		private GameObject m_objDigitRoot;

		// Token: 0x0400A0AC RID: 41132
		[UIObject("Content/Groups/Base/SeasonGroup/RightTop/TitleGroup/Name/Numbers/Number")]
		private GameObject m_objDigitTemplate;

		// Token: 0x0400A0AD RID: 41133
		[UIControl("Content/Groups/Attr/WeekGroup/RightTop/Text_T", null, 0)]
		private Text m_labMyAttrTitle;

		// Token: 0x0400A0AE RID: 41134
		[UIControl("Content/Groups/Attr/WeekGroup/RightTop/Text_B", null, 0)]
		private Text m_labMyAttrContent;

		// Token: 0x0400A0AF RID: 41135
		[UIControl("Content/Groups/Attr/WeekGroup/RightBottom/Scroll View", null, 0)]
		private ComUIListScript m_attrList;

		// Token: 0x0400A0B0 RID: 41136
		private DelayCallUnitHandle m_repeatCallSeasonTime;

		// Token: 0x0400A0B1 RID: 41137
		private Text m_labAttrTime;

		// Token: 0x0400A0B2 RID: 41138
		private DelayCallUnitHandle m_repeatCallAttrTime;
	}
}
