using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200162F RID: 5679
	internal class GuildManorInfoFrame : ClientFrame
	{
		// Token: 0x0600DF0C RID: 57100 RVA: 0x0038E455 File Offset: 0x0038C855
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildManorInfo";
		}

		// Token: 0x0600DF0D RID: 57101 RVA: 0x0038E45C File Offset: 0x0038C85C
		protected sealed override void _OnOpenFrame()
		{
			this.m_guildTerritoryBaseInfo = (this.userData as GuildTerritoryBaseInfo);
			if (this.m_guildTerritoryBaseInfo == null)
			{
				Logger.LogErrorFormat("打开领地详情界面错误，缺少参数", new object[0]);
				return;
			}
			this.m_objRewardTemplate.SetActive(false);
			this.m_objDayRewardTemplate.SetActive(false);
			GuildTerritoryTable tableData = this._GetTerritoryTableData((int)this.m_guildTerritoryBaseInfo.terrId, true);
			this.m_labTitle.text = tableData.Name;
			this.m_labSignupManorName.text = tableData.Name;
			this.m_labSignupSignUpCount.text = this.m_guildTerritoryBaseInfo.enrollSize.ToString();
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(tableData.NeedTerritoryId, string.Empty, string.Empty);
			this.mLevelRoot.CustomActive(tableItem == null);
			this.mSignUpConditionRoot.CustomActive(tableItem != null);
			this.mLevel.text = string.Format("{0}级", tableData.Level);
			for (int i = 0; i < tableData.LeaderReward.Count; i++)
			{
				if (!(tableData.LeaderReward[i] == "-"))
				{
					string[] array = tableData.LeaderReward[i].Split(new char[]
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
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
					itemData.Count = int.Parse(array[1]);
					ComItem comItem = base.CreateComItem(Utility.FindGameObject(gameObject, "Icon", true));
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem.labCount.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject, "Name").text = itemData.Name;
				}
			}
			for (int j = 0; j < tableData.MemberReward.Count; j++)
			{
				if (!(tableData.MemberReward[j] == "-"))
				{
					string[] array2 = tableData.MemberReward[j].Split(new char[]
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
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					itemData2.Count = int.Parse(array2[1]);
					ComItem comItem2 = base.CreateComItem(Utility.FindGameObject(gameObject4, "Icon", true));
					comItem2.Setup(itemData2, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem2.labCount.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject4, "Name").text = itemData2.Name;
				}
			}
			for (int k = 0; k < tableData.LeaderDayReward.Count; k++)
			{
				string[] array3 = tableData.LeaderDayReward[k].Split(new char[]
				{
					'_'
				});
				if (array3.Length >= 2)
				{
					GameObject gameObject7 = Object.Instantiate<GameObject>(this.m_objDayRewardTemplate);
					gameObject7.transform.SetParent(this.m_objDayRewardRoot.transform, false);
					gameObject7.SetActive(true);
					GameObject gameObject8 = Utility.FindGameObject(gameObject7, "Leader", true);
					GameObject gameObject9 = Utility.FindGameObject(gameObject7, "Member", true);
					if (gameObject8 != null)
					{
						gameObject8.CustomActive(true);
					}
					if (gameObject9 != null)
					{
						gameObject9.CustomActive(false);
					}
					ItemData itemData3 = ItemDataManager.CreateItemDataFromTable(int.Parse(array3[0]), 100, 0);
					itemData3.Count = int.Parse(array3[1]);
					ComItem comItem3 = base.CreateComItem(Utility.FindGameObject(gameObject7, "Icon", true));
					comItem3.Setup(itemData3, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem3.labCount.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject7, "Name").text = itemData3.Name;
				}
			}
			for (int l = 0; l < tableData.DayReward.Count; l++)
			{
				string[] array4 = tableData.DayReward[l].Split(new char[]
				{
					'_'
				});
				if (array4.Length >= 2)
				{
					GameObject gameObject10 = Object.Instantiate<GameObject>(this.m_objDayRewardTemplate);
					gameObject10.transform.SetParent(this.m_objDayRewardRoot.transform, false);
					gameObject10.SetActive(true);
					GameObject gameObject11 = Utility.FindGameObject(gameObject10, "Leader", true);
					GameObject gameObject12 = Utility.FindGameObject(gameObject10, "Member", true);
					if (gameObject11 != null)
					{
						gameObject11.CustomActive(false);
					}
					if (gameObject12 != null)
					{
						gameObject12.CustomActive(true);
					}
					ItemData itemData4 = ItemDataManager.CreateItemDataFromTable(int.Parse(array4[0]), 100, 0);
					itemData4.Count = int.Parse(array4[1]);
					ComItem comItem4 = base.CreateComItem(Utility.FindGameObject(gameObject10, "Icon", true));
					comItem4.Setup(itemData4, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					comItem4.labCount.fontSize = 24;
					Utility.GetComponetInChild<Text>(gameObject10, "Name").text = itemData4.Name;
				}
			}
			this.m_btnSignup.onClick.RemoveAllListeners();
			this.m_btnSignup.onClick.AddListener(delegate()
			{
				this.OnClickSignUp(this.m_guildTerritoryBaseInfo, tableData);
			});
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
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
			GuildTerritoryTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>((int)this.m_guildTerritoryBaseInfo.terrId, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.icon.SafeSetImage(tableItem2.iconPath, true);
			}
		}

		// Token: 0x0600DF0E RID: 57102 RVA: 0x0038EC18 File Offset: 0x0038D018
		protected sealed override void _OnCloseFrame()
		{
			this.m_guildTerritoryBaseInfo = null;
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DF0F RID: 57103 RVA: 0x0038EC27 File Offset: 0x0038D027
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DF10 RID: 57104 RVA: 0x0038EC29 File Offset: 0x0038D029
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DF11 RID: 57105 RVA: 0x0038EC2C File Offset: 0x0038D02C
		private void OnClickSignUp(GuildTerritoryBaseInfo data, GuildTerritoryTable tableData)
		{
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
				if (string.IsNullOrEmpty(text))
				{
					DataManager<GuildDataManager>.GetInstance().BattleSignup((int)data.terrId);
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("guild_manor_signup_cost", tableData.Level, text), delegate()
					{
						DataManager<GuildDataManager>.GetInstance().BattleSignup((int)data.terrId);
					}, null, 0f, false);
				}
			}
		}

		// Token: 0x0600DF12 RID: 57106 RVA: 0x0038ED50 File Offset: 0x0038D150
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

		// Token: 0x0600DF13 RID: 57107 RVA: 0x0038ED93 File Offset: 0x0038D193
		[UIEventHandle("Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildManorInfoFrame>(this, false);
		}

		// Token: 0x0600DF14 RID: 57108 RVA: 0x0038EDA4 File Offset: 0x0038D1A4
		protected override void _bindExUI()
		{
			this.mLevelRoot = this.mBind.GetGameObject("LevelRoot");
			this.mSignUpConditionRoot = this.mBind.GetGameObject("SignUpConditionRoot");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mCondition = this.mBind.GetCom<Text>("Condition");
			this.icon = this.mBind.GetCom<Image>("icon");
		}

		// Token: 0x0600DF15 RID: 57109 RVA: 0x0038EE1F File Offset: 0x0038D21F
		protected override void _unbindExUI()
		{
			this.mLevelRoot = null;
			this.mSignUpConditionRoot = null;
			this.mLevel = null;
			this.mCondition = null;
			this.icon = null;
		}

		// Token: 0x04008462 RID: 33890
		[UIControl("Title/Text", null, 0)]
		private Text m_labTitle;

		// Token: 0x04008463 RID: 33891
		[UIControl("Name/Text", null, 0)]
		private Text m_labSignupManorName;

		// Token: 0x04008464 RID: 33892
		[UIControl("SignupCount/Text", null, 0)]
		private Text m_labSignupSignUpCount;

		// Token: 0x04008465 RID: 33893
		[UIObject("Reward/ScrollView/Viewport/Content")]
		private GameObject m_objRewardRoot;

		// Token: 0x04008466 RID: 33894
		[UIObject("Reward/ScrollView/Viewport/Content/Template")]
		private GameObject m_objRewardTemplate;

		// Token: 0x04008467 RID: 33895
		[UIControl("SignUp", typeof(Button), 0)]
		private Button m_btnSignup;

		// Token: 0x04008468 RID: 33896
		[UIControl("SignUp", typeof(ComButtonEnbale), 0)]
		private ComButtonEnbale m_comBtnEnableSignup;

		// Token: 0x04008469 RID: 33897
		[UIControl("SignUp/Text", null, 0)]
		private Text m_labSignup;

		// Token: 0x0400846A RID: 33898
		private GuildTerritoryBaseInfo m_guildTerritoryBaseInfo = new GuildTerritoryBaseInfo();

		// Token: 0x0400846B RID: 33899
		[UIObject("DayReward/ScrollView/Viewport/Content")]
		private GameObject m_objDayRewardRoot;

		// Token: 0x0400846C RID: 33900
		[UIObject("DayReward/ScrollView/Viewport/Content/Template")]
		private GameObject m_objDayRewardTemplate;

		// Token: 0x0400846D RID: 33901
		private GameObject mLevelRoot;

		// Token: 0x0400846E RID: 33902
		private GameObject mSignUpConditionRoot;

		// Token: 0x0400846F RID: 33903
		private Text mLevel;

		// Token: 0x04008470 RID: 33904
		private Text mCondition;

		// Token: 0x04008471 RID: 33905
		private Image icon;
	}
}
