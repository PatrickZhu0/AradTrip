using System;
using System.Collections;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001606 RID: 5638
	internal class GuildCrossManorFrame : ClientFrame
	{
		// Token: 0x0600DCD1 RID: 56529 RVA: 0x0037D193 File Offset: 0x0037B593
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildCrossManor";
		}

		// Token: 0x0600DCD2 RID: 56530 RVA: 0x0037D19C File Offset: 0x0037B59C
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(382, string.Empty, string.Empty);
			this.iAreaNum = tableItem.Value;
			for (int i = 8; i < 8 + this.iAreaNum; i++)
			{
				GameObject gameObject = Utility.FindGameObject(string.Format("Map/Manor{0}", i), true);
				if (!(gameObject == null))
				{
					gameObject.CustomActive(false);
					int nID = i;
					GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(nID, true);
					if (guildTerritoryTable != null)
					{
						if (guildTerritoryTable.IsOpen == 1)
						{
							gameObject.CustomActive(true);
							Button componetInChild = Utility.GetComponetInChild<Button>(gameObject, "Func");
							if (componetInChild != null)
							{
								componetInChild.onClick.RemoveAllListeners();
								componetInChild.onClick.AddListener(delegate()
								{
									DataManager<GuildDataManager>.GetInstance().RequestManorInfo(nID);
								});
							}
							if (i != 8)
							{
								Text componetInChild2 = Utility.GetComponetInChild<Text>(gameObject, "Name/Text");
								if (componetInChild2 != null)
								{
									componetInChild2.text = guildTerritoryTable.Name;
								}
							}
							if (!DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.StartGuildCrossBattle, EGuildDuty.Invalid))
							{
								Utility.FindGameObject(gameObject, "ClickToSignup", true).CustomActive(true);
							}
							else
							{
								Utility.FindGameObject(gameObject, "ClickToSignup", true).CustomActive(false);
							}
							Utility.FindGameObject(gameObject, "AlreadySignup", true).CustomActive(nID == DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() >= EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() <= EGuildBattleState.Firing);
							GuildTerritoryBaseInfo guildTerritoryBaseInfo = DataManager<GuildDataManager>.GetInstance().GetGuildTerritoryBaseInfo(nID);
							if (guildTerritoryBaseInfo != null)
							{
								if (guildTerritoryBaseInfo.guildName != string.Empty)
								{
									Utility.GetComponetInChild<Text>(gameObject, "Owner").SafeSetText(string.Format("【{0}】", guildTerritoryBaseInfo.guildName));
								}
								else
								{
									Utility.GetComponetInChild<Text>(gameObject, "Owner").SafeSetText(string.Empty);
								}
								if (guildTerritoryBaseInfo.serverName != string.Empty)
								{
									Utility.GetComponetInChild<Text>(gameObject, "ServerName").SafeSetText(string.Format("{0}", guildTerritoryBaseInfo.serverName));
								}
								else
								{
									Utility.GetComponetInChild<Text>(gameObject, "ServerName").SafeSetText(string.Empty);
								}
							}
						}
					}
				}
			}
			this._UpdateCurrentManaor();
			this._UpdateTargetManaor();
			this._UpdateJoin();
			this._UpdateShowTitle();
			this._UpdateLotteryShow();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_CROSS);
			DataManager<GuildDataManager>.GetInstance().SetGuildBattleSignUpRedPoint(false);
		}

		// Token: 0x0600DCD3 RID: 56531 RVA: 0x0037D49F File Offset: 0x0037B89F
		protected sealed override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DCD4 RID: 56532 RVA: 0x0037D4A8 File Offset: 0x0037B8A8
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildSignupSuccess, new ClientEventSystem.UIEventHandler(this._OnSignupSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildManorInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnManorInfoUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildManorOwnerUpdated, new ClientEventSystem.UIEventHandler(this._OnManorOwnerUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnGuildLotteryResultRes));
		}

		// Token: 0x0600DCD5 RID: 56533 RVA: 0x0037D574 File Offset: 0x0037B974
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildSignupSuccess, new ClientEventSystem.UIEventHandler(this._OnSignupSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildManorInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnManorInfoUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBaseInfoUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildBaseInfoUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildManorOwnerUpdated, new ClientEventSystem.UIEventHandler(this._OnManorOwnerUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildLotteryResultRes, new ClientEventSystem.UIEventHandler(this._OnGuildLotteryResultRes));
		}

		// Token: 0x0600DCD6 RID: 56534 RVA: 0x0037D640 File Offset: 0x0037BA40
		private void _OnInspireSuccess(UIEvent a_event)
		{
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_CROSS);
		}

		// Token: 0x0600DCD7 RID: 56535 RVA: 0x0037D684 File Offset: 0x0037BA84
		private void _OnSignupSuccess(UIEvent a_event)
		{
			this._UpdateTargetManaor();
			this._UpdateManor();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_CROSS);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildCrossManorInfoFrame>(null, false);
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_manor_signup_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0600DCD8 RID: 56536 RVA: 0x0037D6F0 File Offset: 0x0037BAF0
		private void _OnManorInfoUpdated(UIEvent a_event)
		{
			GuildTerritoryBaseInfo guildTerritoryBaseInfo = a_event.Param1 as GuildTerritoryBaseInfo;
			if (guildTerritoryBaseInfo != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildCrossManorInfoFrame>(FrameLayer.Middle, guildTerritoryBaseInfo, string.Empty);
			}
		}

		// Token: 0x0600DCD9 RID: 56537 RVA: 0x0037D724 File Offset: 0x0037BB24
		private void _OnGuildBaseInfoUpdated(UIEvent a_event)
		{
			this._UpdateCurrentManaor();
			this._UpdateTargetManaor();
			this._UpdateManor();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_CROSS);
		}

		// Token: 0x0600DCDA RID: 56538 RVA: 0x0037D778 File Offset: 0x0037BB78
		private void _OnGuildBattleStateUpdated(UIEvent a_event)
		{
			this._UpdateJoin();
			this._UpdateManor();
			this._UpdateLotteryShow();
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireIcon, ref this.mInspireCount, ref this.mEnableInspire, GuildBattleOpenType.GBOT_CROSS);
		}

		// Token: 0x0600DCDB RID: 56539 RVA: 0x0037D7CC File Offset: 0x0037BBCC
		private void _OnManorOwnerUpdate(UIEvent a_event)
		{
			this._UpdateManor();
		}

		// Token: 0x0600DCDC RID: 56540 RVA: 0x0037D7D4 File Offset: 0x0037BBD4
		private void _OnGuildLotteryResultRes(UIEvent a_event)
		{
			this._UpdateLotteryShow();
		}

		// Token: 0x0600DCDD RID: 56541 RVA: 0x0037D7DC File Offset: 0x0037BBDC
		private void _UpdateCurrentManaor()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().HasSelfCrossManor())
			{
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(DataManager<GuildDataManager>.GetInstance().myGuild.nSelfCrossManorID, true);
				this.mCurManorName.text = guildTerritoryTable.Name;
			}
			else
			{
				this.mCurManorName.text = TR.Value("guild_manor_none_manor");
			}
		}

		// Token: 0x0600DCDE RID: 56542 RVA: 0x0037D84C File Offset: 0x0037BC4C
		private void _UpdateTargetManaor()
		{
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().HasTargetManor())
			{
				GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID, true);
				if (guildTerritoryTable != null)
				{
					this.mTargetManorName.text = guildTerritoryTable.Name;
				}
				else
				{
					this.mTargetManorName.text = TR.Value("guild_manor_none_manor");
				}
			}
			else
			{
				this.mTargetManorName.text = TR.Value("guild_manor_none_manor");
			}
		}

		// Token: 0x0600DCDF RID: 56543 RVA: 0x0037D8DC File Offset: 0x0037BCDC
		private void _UpdateJoin()
		{
			bool enable = DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Preparing || DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Firing);
			this.mEnableJoin.SetEnable(enable);
			this.mJoinRedPoint.gameObject.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildBattleEnter));
		}

		// Token: 0x0600DCE0 RID: 56544 RVA: 0x0037D968 File Offset: 0x0037BD68
		private void _UpdateShowTitle()
		{
			GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(8, true);
			if (guildTerritoryTable == null)
			{
				return;
			}
			if (guildTerritoryTable.LeaderReward.Count > 0 && guildTerritoryTable.LeaderReward[0] != "-" && guildTerritoryTable.LeaderReward[0] != string.Empty)
			{
				string[] array = guildTerritoryTable.LeaderReward[0].Split(new char[]
				{
					'_'
				});
				if (array.Length >= 2)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
					itemData.Count = int.Parse(array[1]);
					ComItem comItem = base.CreateComItem(this.mLeaderRewardPos);
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
				}
			}
			if (guildTerritoryTable.MemberReward.Count > 0 && guildTerritoryTable.MemberReward[0] != "-" && guildTerritoryTable.MemberReward[0] != string.Empty)
			{
				string[] array2 = guildTerritoryTable.MemberReward[0].Split(new char[]
				{
					'_'
				});
				if (array2.Length >= 2)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					itemData2.Count = int.Parse(array2[1]);
					ComItem comItem2 = base.CreateComItem(this.mMemberRewardPos);
					comItem2.Setup(itemData2, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
				}
			}
		}

		// Token: 0x0600DCE1 RID: 56545 RVA: 0x0037DB08 File Offset: 0x0037BF08
		private void _UpdateLotteryShow()
		{
		}

		// Token: 0x0600DCE2 RID: 56546 RVA: 0x0037DB0C File Offset: 0x0037BF0C
		private void _UpdateManor()
		{
			for (int i = 8; i < 8 + this.iAreaNum; i++)
			{
				GameObject gameObject = Utility.FindGameObject(string.Format("Map/Manor{0}", i), false);
				if (!(gameObject == null))
				{
					int num = i;
					GuildTerritoryTable guildTerritoryTable = this._GetTerritoryTableData(num, true);
					if (guildTerritoryTable != null)
					{
						if (guildTerritoryTable.IsOpen != 1)
						{
							gameObject.CustomActive(false);
						}
						else
						{
							gameObject.CustomActive(true);
							if (!DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Signup && DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.StartGuildCrossBattle, EGuildDuty.Invalid))
							{
								Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(true);
							}
							else
							{
								Utility.FindGameObject(gameObject, "ClickToSignup", true).SetActive(false);
							}
							Utility.FindGameObject(gameObject, "AlreadySignup", true).SetActive(num == DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID);
							GuildTerritoryBaseInfo guildTerritoryBaseInfo = DataManager<GuildDataManager>.GetInstance().GetGuildTerritoryBaseInfo(num);
							if (guildTerritoryBaseInfo != null)
							{
								if (guildTerritoryBaseInfo.guildName != string.Empty)
								{
									Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Format("【{0}】", guildTerritoryBaseInfo.guildName);
								}
								else
								{
									Utility.GetComponetInChild<Text>(gameObject, "Owner").text = string.Empty;
								}
								if (guildTerritoryBaseInfo.serverName != string.Empty)
								{
									Utility.GetComponetInChild<Text>(gameObject, "ServerName").text = string.Format("{0}", guildTerritoryBaseInfo.serverName);
								}
								else
								{
									Utility.GetComponetInChild<Text>(gameObject, "ServerName").text = string.Empty;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600DCE3 RID: 56547 RVA: 0x0037DCD8 File Offset: 0x0037C0D8
		private GuildTerritoryTable _GetTerritoryTableData(int a_nID, bool a_bShowError = true)
		{
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(a_nID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			return tableItem;
		}

		// Token: 0x0600DCE4 RID: 56548 RVA: 0x0037DD04 File Offset: 0x0037C104
		protected sealed override void _bindExUI()
		{
			this.mDetail = this.mBind.GetCom<Button>("Detail");
			this.mDetail.onClick.AddListener(new UnityAction(this._onDetailButtonClick));
			this.mInspireLevel = this.mBind.GetCom<Text>("InspireLevel");
			this.mCurManorName = this.mBind.GetCom<Text>("CurManorName");
			this.mTargetManorName = this.mBind.GetCom<Text>("TargetManorName");
			this.mCurAttr = this.mBind.GetCom<Text>("CurAttr");
			this.mInspire = this.mBind.GetCom<Button>("Inspire");
			this.mInspire.onClick.AddListener(new UnityAction(this._onInspireButtonClick));
			this.mJoin = this.mBind.GetCom<Button>("Join");
			this.mJoin.onClick.AddListener(new UnityAction(this._onJoinButtonClick));
			this.mEnableInspire = this.mBind.GetCom<ComButtonEnbale>("EnableInspire");
			this.mEnableJoin = this.mBind.GetCom<ComButtonEnbale>("EnableJoin");
			this.mInspireMax = this.mBind.GetGameObject("InspireMax");
			this.mJoinRedPoint = this.mBind.GetCom<Image>("JoinRedPoint");
			this.mInspireIcon = this.mBind.GetCom<Image>("InspireIcon");
			this.mInspireCount = this.mBind.GetCom<Text>("InspireCount");
			this.mLeaderRewardPos = this.mBind.GetGameObject("LeaderRewardPos");
			this.mMemberRewardPos = this.mBind.GetGameObject("MemberRewardPos");
		}

		// Token: 0x0600DCE5 RID: 56549 RVA: 0x0037DEB0 File Offset: 0x0037C2B0
		protected sealed override void _unbindExUI()
		{
			this.mDetail.onClick.RemoveListener(new UnityAction(this._onDetailButtonClick));
			this.mDetail = null;
			this.mInspireLevel = null;
			this.mCurManorName = null;
			this.mTargetManorName = null;
			this.mCurAttr = null;
			this.mInspire.onClick.RemoveListener(new UnityAction(this._onInspireButtonClick));
			this.mInspire = null;
			this.mJoin.onClick.RemoveListener(new UnityAction(this._onJoinButtonClick));
			this.mJoin = null;
			this.mEnableInspire = null;
			this.mEnableJoin = null;
			this.mInspireMax = null;
			this.mJoinRedPoint = null;
			this.mInspireIcon = null;
			this.mInspireCount = null;
			this.mLeaderRewardPos = null;
			this.mMemberRewardPos = null;
		}

		// Token: 0x0600DCE6 RID: 56550 RVA: 0x0037DF7A File Offset: 0x0037C37A
		private void _onDetailButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildInspireDetailFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DCE7 RID: 56551 RVA: 0x0037DF8E File Offset: 0x0037C38E
		private void _onInspireButtonClick()
		{
			DataManager<GuildDataManager>.GetInstance().SendInspire();
		}

		// Token: 0x0600DCE8 RID: 56552 RVA: 0x0037DF9C File Offset: 0x0037C39C
		private void _onJoinButtonClick()
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_GUILD_CROSS_BATTLE))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("跨服公会战系统目前已关闭", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._requestNewTitleTakeUpGuildPost());
		}

		// Token: 0x0600DCE9 RID: 56553 RVA: 0x0037DFF8 File Offset: 0x0037C3F8
		private IEnumerator _requestNewTitleTakeUpGuildPost()
		{
			MessageEvents msg = new MessageEvents();
			WorldNewTitleTakeUpGuildPostReq req = new WorldNewTitleTakeUpGuildPostReq();
			WorldNewTitleTakeUpGuildPostRes res = new WorldNewTitleTakeUpGuildPostRes();
			yield return MessageUtility.WaitWithResend<WorldNewTitleTakeUpGuildPostReq, WorldNewTitleTakeUpGuildPostRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f, null);
			if (msg.IsAllMessageReceived())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null && DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					int nTargetCrossManorID = DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID;
					GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(nTargetCrossManorID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (clientSystemTown.CurrentSceneID != tableItem.SceneID)
						{
							clientSystemTown.ChangeScene(tableItem.SceneID, 0, clientSystemTown.CurrentSceneID, 0, null);
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
							DataManager<GuildDataManager>.GetInstance().SetGuildBattleEnterRedPoint(false);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04008266 RID: 33382
		private string AttackCityEffectPath = "Effects/Scene_effects/EffectUI/EffUI_chuizi";

		// Token: 0x04008267 RID: 33383
		private int iAreaNum;

		// Token: 0x04008268 RID: 33384
		private Button mDetail;

		// Token: 0x04008269 RID: 33385
		private Text mInspireLevel;

		// Token: 0x0400826A RID: 33386
		private Text mCurManorName;

		// Token: 0x0400826B RID: 33387
		private Text mTargetManorName;

		// Token: 0x0400826C RID: 33388
		private Text mCurAttr;

		// Token: 0x0400826D RID: 33389
		private Button mInspire;

		// Token: 0x0400826E RID: 33390
		private Button mJoin;

		// Token: 0x0400826F RID: 33391
		private ComButtonEnbale mEnableInspire;

		// Token: 0x04008270 RID: 33392
		private ComButtonEnbale mEnableJoin;

		// Token: 0x04008271 RID: 33393
		private GameObject mInspireMax;

		// Token: 0x04008272 RID: 33394
		private Image mJoinRedPoint;

		// Token: 0x04008273 RID: 33395
		private Image mInspireIcon;

		// Token: 0x04008274 RID: 33396
		private Text mInspireCount;

		// Token: 0x04008275 RID: 33397
		private GameObject mLeaderRewardPos;

		// Token: 0x04008276 RID: 33398
		private GameObject mMemberRewardPos;
	}
}
