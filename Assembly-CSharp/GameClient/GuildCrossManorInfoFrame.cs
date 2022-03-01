using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001607 RID: 5639
	internal class GuildCrossManorInfoFrame : ClientFrame
	{
		// Token: 0x0600DCED RID: 56557 RVA: 0x0037E1E9 File Offset: 0x0037C5E9
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildCrossManorInfo";
		}

		// Token: 0x0600DCEE RID: 56558 RVA: 0x0037E1F0 File Offset: 0x0037C5F0
		protected sealed override void _OnOpenFrame()
		{
			this.m_guildTerritoryBaseInfo = (this.userData as GuildTerritoryBaseInfo);
			if (this.m_guildTerritoryBaseInfo == null)
			{
				Logger.LogErrorFormat("打开领地详情界面错误，缺少参数", new object[0]);
				return;
			}
			this.m_objRewardTemplate.SetActive(false);
			this.mReward2Template.CustomActive(false);
			GuildTerritoryTable tableData = this._GetTerritoryTableData((int)this.m_guildTerritoryBaseInfo.terrId, true);
			this.m_labTitle.text = tableData.Name;
			this.m_labSignupManorName.text = string.Format("{0}级", tableData.Level);
			this.m_labSignupSignUpCount.text = this.m_guildTerritoryBaseInfo.enrollSize.ToString();
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(tableData.NeedTerritoryId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mCondition.text = TR.Value("guild_manor_signup_requirement_1");
			}
			else
			{
				this.mCondition.text = TR.Value("guild_manor_signup_requirement_2");
			}
			if (tableData.ChestDoubleDungeons != null)
			{
				string[] array = tableData.ChestDoubleDungeons.Split(new char[]
				{
					'|'
				});
				if (array != null && array.Length > 0)
				{
					int num = 0;
					if (int.TryParse(array[0], out num))
					{
						if (num != 0)
						{
							if (tableData.ID == 8)
							{
								this.mDes2.text = string.Format("每天前{0}次<color=#00BAFFFF>通关远古地下城</color>翻牌装备数量*2", tableData.DailyChestDoubleTimes);
								this.mDungeon.text = "远古地下城";
							}
							else
							{
								DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(num, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									this.mDes2.text = string.Format("每天前{0}次通关<color=#00BAFFFF>{1}</color>翻牌装备数量*2", tableData.DailyChestDoubleTimes, tableItem2.Name);
									this.mDungeon.text = tableItem2.Name;
								}
							}
							this.mGoto.gameObject.CustomActive(true);
						}
						else
						{
							this.mDungeon.text = "无";
							this.mGoto.gameObject.CustomActive(false);
						}
					}
				}
				else
				{
					this.mDungeon.text = "无";
					this.mGoto.gameObject.CustomActive(false);
				}
			}
			else
			{
				this.mDungeon.text = "无";
				this.mGoto.gameObject.CustomActive(false);
			}
			for (int i = 0; i < tableData.LeaderReward.Count; i++)
			{
				if (!(tableData.LeaderReward[i] == "-"))
				{
					string[] array2 = tableData.LeaderReward[i].Split(new char[]
					{
						'_'
					});
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_objRewardTemplate);
					gameObject.transform.SetParent(this.m_objRewardRoot.transform, false);
					gameObject.SetActive(true);
					GameObject gameObject2 = Utility.FindGameObject(gameObject, "Leader", true);
					GameObject gameObject3 = Utility.FindGameObject(gameObject, "Member", true);
					if (gameObject2 != null)
					{
						gameObject2.CustomActive(true);
					}
					if (gameObject3 != null)
					{
						gameObject3.CustomActive(false);
					}
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					itemData.Count = int.Parse(array2[1]);
					ComItem comItem = base.CreateComItem(Utility.FindGameObject(gameObject, "Icon", true));
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem.labCount.fontSize = 24;
					comItem.labLevel.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject, "Name").text = itemData.Name;
				}
			}
			for (int j = 0; j < tableData.MemberReward.Count; j++)
			{
				if (!(tableData.MemberReward[j] == "-"))
				{
					string[] array3 = tableData.MemberReward[j].Split(new char[]
					{
						'_'
					});
					GameObject gameObject4 = Object.Instantiate<GameObject>(this.m_objRewardTemplate);
					gameObject4.transform.SetParent(this.m_objRewardRoot.transform, false);
					gameObject4.SetActive(true);
					GameObject gameObject5 = Utility.FindGameObject(gameObject4, "Leader", true);
					GameObject gameObject6 = Utility.FindGameObject(gameObject4, "Member", true);
					if (gameObject5 != null)
					{
						gameObject5.CustomActive(false);
					}
					if (gameObject6 != null)
					{
						gameObject6.CustomActive(true);
					}
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array3[0]), 100, 0);
					itemData2.Count = int.Parse(array3[1]);
					ComItem comItem2 = base.CreateComItem(Utility.FindGameObject(gameObject4, "Icon", true));
					comItem2.Setup(itemData2, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem2.labCount.fontSize = 24;
					comItem2.labLevel.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject4, "Name").text = itemData2.Name;
				}
			}
			for (int k = 0; k < tableData.DayReward.Count; k++)
			{
				string[] array4 = tableData.DayReward[k].Split(new char[]
				{
					'_'
				});
				if (array4.Length >= 2)
				{
					GameObject gameObject7 = Object.Instantiate<GameObject>(this.m_objRewardTemplate);
					gameObject7.transform.SetParent(this.m_objRewardRoot.transform, false);
					gameObject7.SetActive(true);
					ItemData itemData3 = ItemDataManager.CreateItemDataFromTable(int.Parse(array4[0]), 100, 0);
					itemData3.Count = int.Parse(array4[1]);
					ComItem comItem3 = base.CreateComItem(Utility.FindGameObject(gameObject7, "Icon", true));
					comItem3.Setup(itemData3, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem3.labCount.fontSize = 24;
					comItem3.labLevel.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject7, "Name").text = itemData3.Name;
				}
			}
			for (int l = 0; l < tableData.PropRewards.Count; l++)
			{
				string[] array5 = tableData.PropRewards[l].Split(new char[]
				{
					'_'
				});
				if (array5.Length >= 2)
				{
					GameObject gameObject8 = Object.Instantiate<GameObject>(this.mReward2Template);
					gameObject8.transform.SetParent(this.mReward2Content.transform, false);
					gameObject8.SetActive(true);
					ItemData itemData4 = ItemDataManager.CreateItemDataFromTable(int.Parse(array5[0]), 100, 0);
					itemData4.Count = int.Parse(array5[1]);
					ComItem comItem4 = base.CreateComItem(Utility.FindGameObject(gameObject8, "Icon", true));
					comItem4.Setup(itemData4, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem4.labCount.fontSize = 24;
					comItem4.labLevel.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject8, "Name").text = itemData4.Name;
				}
			}
			this.m_btnSignup.onClick.RemoveAllListeners();
			this.m_btnSignup.onClick.AddListener(delegate()
			{
				this.OnClickSignUp(this.m_guildTerritoryBaseInfo, tableData);
			});
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				if (DataManager<GuildDataManager>.GetInstance().HasTargetManor())
				{
					this.m_comBtnEnableSignup.SetEnable(false);
					this.m_labSignup.text = TR.Value("guild_manor_has_signup");
				}
				else if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup)
				{
					this.m_comBtnEnableSignup.SetEnable(true);
					this.m_labSignup.text = TR.Value("guild_manor_signup");
				}
				else
				{
					this.m_comBtnEnableSignup.SetEnable(false);
					this.m_labSignup.text = TR.Value("guild_manor_signup_not_start");
				}
			}
			else
			{
				this.m_comBtnEnableSignup.SetEnable(false);
				this.m_labSignup.text = TR.Value("guild_manor_signup_not_start");
			}
		}

		// Token: 0x0600DCEF RID: 56559 RVA: 0x0037EA9C File Offset: 0x0037CE9C
		protected sealed override void _OnCloseFrame()
		{
			this.m_guildTerritoryBaseInfo = null;
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DCF0 RID: 56560 RVA: 0x0037EAAB File Offset: 0x0037CEAB
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DCF1 RID: 56561 RVA: 0x0037EAAD File Offset: 0x0037CEAD
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DCF2 RID: 56562 RVA: 0x0037EAB0 File Offset: 0x0037CEB0
		private void OnClickSignUp(GuildTerritoryBaseInfo data, GuildTerritoryTable tableData)
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_GUILD_CROSS_BATTLE))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("跨服公会战系统目前已关闭", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<GuildDataManager>.GetInstance().HasTargetManor())
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_manor_signup_cannot_repeat"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				string text = string.Empty;
				for (int i = 0; i < tableData.ConsumeItem.Count; i++)
				{
					if (!string.IsNullOrEmpty(tableData.ConsumeItem[i]))
					{
						string[] array = tableData.ConsumeItem[i].Split(new char[]
						{
							'_'
						});
						if (array.Length == 2)
						{
							ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(int.Parse(array[0]));
							text += string.Format("{0}{1}", array[1], commonItemTableDataByID.Name);
						}
					}
				}
				bool flag = false;
				if (tableData.NeedTerritoryId != 0)
				{
					if (tableData.NeedTerritoryId == DataManager<GuildDataManager>.GetInstance().myGuild.nSelfHistoryManorID)
					{
						flag = true;
					}
				}
				else if (DataManager<GuildDataManager>.GetInstance().myGuild.nSelfHistoryManorID != 0)
				{
					flag = true;
				}
				if (flag)
				{
					DataManager<GuildDataManager>.GetInstance().BattleSignup((int)data.terrId);
				}
				else if (tableData.ID != 8)
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("guild_crossmanor_signup_cost", text), delegate()
					{
						DataManager<GuildDataManager>.GetInstance().BattleSignup((int)data.terrId);
					}, null, 0f, false);
				}
				else
				{
					SystemNotifyManager.SystemNotify(2314005, string.Empty);
				}
			}
		}

		// Token: 0x0600DCF3 RID: 56563 RVA: 0x0037EC4C File Offset: 0x0037D04C
		private GuildTerritoryTable _GetTerritoryTableData(int a_nID, bool a_bShowError = true)
		{
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(a_nID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("加载公会领地表错误，id{0}不存在", new object[]
				{
					a_nID
				});
			}
			return tableItem;
		}

		// Token: 0x0600DCF4 RID: 56564 RVA: 0x0037EC8F File Offset: 0x0037D08F
		[UIEventHandle("Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildCrossManorInfoFrame>(this, false);
		}

		// Token: 0x0600DCF5 RID: 56565 RVA: 0x0037ECA0 File Offset: 0x0037D0A0
		protected override void _bindExUI()
		{
			this.mSignUpConditionRoot = this.mBind.GetGameObject("SignUpConditionRoot");
			this.mCondition = this.mBind.GetCom<Text>("Condition");
			this.mDes2 = this.mBind.GetCom<Text>("Des2");
			this.mReward2 = this.mBind.GetGameObject("Reward2");
			this.mReward2Content = this.mBind.GetGameObject("Reward2Content");
			this.mReward2Template = this.mBind.GetGameObject("Reward2Template");
			this.mDungeon = this.mBind.GetCom<Text>("Dungeon");
			this.mGoto = this.mBind.GetCom<Button>("Goto");
			this.mGoto.onClick.AddListener(new UnityAction(this._onGotoButtonClick));
		}

		// Token: 0x0600DCF6 RID: 56566 RVA: 0x0037ED7C File Offset: 0x0037D17C
		protected override void _unbindExUI()
		{
			this.mSignUpConditionRoot = null;
			this.mCondition = null;
			this.mDes2 = null;
			this.mReward2 = null;
			this.mReward2Content = null;
			this.mReward2Template = null;
			this.mDungeon = null;
			this.mGoto.onClick.RemoveListener(new UnityAction(this._onGotoButtonClick));
			this.mGoto = null;
		}

		// Token: 0x0600DCF7 RID: 56567 RVA: 0x0037EDE0 File Offset: 0x0037D1E0
		private void _onGotoButtonClick()
		{
			GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData((int)this.m_guildTerritoryBaseInfo.terrId, true);
			if (guildTerritoryTable == null)
			{
				return;
			}
			AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(guildTerritoryTable.LinkID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.m_guildTerritoryBaseInfo.terrId != 8)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
				this.frameMgr.CloseFrame<GuildCrossManorInfoFrame>(this, false);
			}
			DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
		}

		// Token: 0x04008279 RID: 33401
		[UIControl("Title/Text", null, 0)]
		private Text m_labTitle;

		// Token: 0x0400827A RID: 33402
		[UIControl("Name/Text", null, 0)]
		private Text m_labSignupManorName;

		// Token: 0x0400827B RID: 33403
		[UIControl("SignupCount/Text", null, 0)]
		private Text m_labSignupSignUpCount;

		// Token: 0x0400827C RID: 33404
		[UIObject("Reward/ScrollView/Viewport/Content")]
		private GameObject m_objRewardRoot;

		// Token: 0x0400827D RID: 33405
		[UIObject("Reward/ScrollView/Viewport/Content/Template")]
		private GameObject m_objRewardTemplate;

		// Token: 0x0400827E RID: 33406
		[UIControl("SignUp", typeof(Button), 0)]
		private Button m_btnSignup;

		// Token: 0x0400827F RID: 33407
		[UIControl("SignUp", typeof(ComButtonEnbale), 0)]
		private ComButtonEnbale m_comBtnEnableSignup;

		// Token: 0x04008280 RID: 33408
		[UIControl("SignUp/Text", null, 0)]
		private Text m_labSignup;

		// Token: 0x04008281 RID: 33409
		private GuildTerritoryBaseInfo m_guildTerritoryBaseInfo = new GuildTerritoryBaseInfo();

		// Token: 0x04008282 RID: 33410
		private GameObject mSignUpConditionRoot;

		// Token: 0x04008283 RID: 33411
		private Text mCondition;

		// Token: 0x04008284 RID: 33412
		private Text mDes2;

		// Token: 0x04008285 RID: 33413
		private GameObject mReward2;

		// Token: 0x04008286 RID: 33414
		private GameObject mReward2Content;

		// Token: 0x04008287 RID: 33415
		private GameObject mReward2Template;

		// Token: 0x04008288 RID: 33416
		private Text mDungeon;

		// Token: 0x04008289 RID: 33417
		private Button mGoto;
	}
}
