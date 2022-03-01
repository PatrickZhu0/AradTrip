using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010AB RID: 4267
	public class DungeonMenuFrame : ClientFrame
	{
		// Token: 0x0600A0E6 RID: 41190 RVA: 0x00208A5E File Offset: 0x00206E5E
		[UIEventHandle("r/ButtonRoot/Root/Reporter")]
		private void _OnOpenReporter()
		{
		}

		// Token: 0x0600A0E7 RID: 41191 RVA: 0x00208A60 File Offset: 0x00206E60
		protected override void _bindExUI()
		{
			this.mCounter = this.mBind.GetCom<ComCountScript>("counter");
			this.mFriendAddRoot = this.mBind.GetGameObject("friendAddRoot");
			this.mOnAgain = this.mBind.GetCom<Button>("onAgain");
			if (null != this.mOnAgain)
			{
				this.mOnAgain.onClick.AddListener(new UnityAction(this._onOnAgainButtonClick));
			}
			this.mOnBack = this.mBind.GetCom<Button>("onBack");
			if (null != this.mOnBack)
			{
				this.mOnBack.onClick.AddListener(new UnityAction(this._onOnBackButtonClick));
			}
			this.mMissionRoot = this.mBind.GetGameObject("missionRoot");
			this.mMissionInfo = this.mBind.GetCom<Text>("missionInfo");
			this.mMissionDesc = this.mBind.GetCom<Text>("missionDesc");
			this.mAgain = this.mBind.GetGameObject("Again");
			this.mNpcTalkBtn = this.mBind.GetCom<Button>("NpcTalkBtn");
			if (null != this.mNpcTalkBtn)
			{
				this.mNpcTalkBtn.onClick.AddListener(new UnityAction(this._onNpcTalkBtnButtonClick));
			}
			this.mBuinessmanBtn = this.mBind.GetCom<Button>("BuinessmanBtn");
			if (null != this.mBuinessmanBtn)
			{
				this.mBuinessmanBtn.onClick.AddListener(new UnityAction(this._onBuinessmanBtnButtonClick));
			}
			this.mBuinessmanImage = this.mBind.GetCom<Image>("BuinessmanImage");
			this.mMissionBack = this.mBind.GetCom<Button>("missionBack");
			if (null != this.mMissionBack)
			{
				this.mMissionBack.onClick.AddListener(new UnityAction(this._onMissionBackButtonClick));
			}
			this.mPlayerInformationItemRoot = this.mBind.GetGameObject("PlayerInformationItemRoot");
			this.mPlayerInformation = this.mBind.GetGameObject("PlayerInformation");
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileSucc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUploadFileClose, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileClose));
		}

		// Token: 0x0600A0E8 RID: 41192 RVA: 0x00208CB8 File Offset: 0x002070B8
		protected void _OnUpLoadFileSucc(UIEvent a_event)
		{
		}

		// Token: 0x0600A0E9 RID: 41193 RVA: 0x00208CBA File Offset: 0x002070BA
		protected void _OnUpLoadFileClose(UIEvent a_event)
		{
		}

		// Token: 0x0600A0EA RID: 41194 RVA: 0x00208CBC File Offset: 0x002070BC
		protected override void _unbindExUI()
		{
			this.mCounter = null;
			this.mFriendAddRoot = null;
			if (null != this.mOnAgain)
			{
				this.mOnAgain.onClick.RemoveListener(new UnityAction(this._onOnAgainButtonClick));
			}
			this.mOnAgain = null;
			if (null != this.mOnBack)
			{
				this.mOnBack.onClick.RemoveListener(new UnityAction(this._onOnBackButtonClick));
			}
			this.mOnBack = null;
			this.mMissionRoot = null;
			this.mMissionInfo = null;
			this.mMissionDesc = null;
			this.mAgain = null;
			if (null != this.mNpcTalkBtn)
			{
				this.mNpcTalkBtn.onClick.RemoveListener(new UnityAction(this._onNpcTalkBtnButtonClick));
			}
			this.mNpcTalkBtn = null;
			if (null != this.mBuinessmanBtn)
			{
				this.mBuinessmanBtn.onClick.RemoveListener(new UnityAction(this._onBuinessmanBtnButtonClick));
			}
			this.mBuinessmanBtn = null;
			this.mBuinessmanImage = null;
			if (null != this.mMissionBack)
			{
				this.mMissionBack.onClick.RemoveListener(new UnityAction(this._onMissionBackButtonClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUploadFileSucc, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileSucc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUploadFileClose, new ClientEventSystem.UIEventHandler(this._OnUpLoadFileClose));
			this.mMissionBack = null;
			this.mPlayerInformationItemRoot = null;
			this.mPlayerInformation = null;
		}

		// Token: 0x0600A0EB RID: 41195 RVA: 0x00208E42 File Offset: 0x00207242
		private void _onOnAgainButtonClick()
		{
			if ((float)this.mCounter.mLeftTime < 1.2f)
			{
				return;
			}
			this._sendSceneDungeonStartRep();
			Singleton<GameStatisticManager>.GetInstance().DoStartSingleBoardDoAgainButton("OnAgain");
		}

		// Token: 0x0600A0EC RID: 41196 RVA: 0x00208E70 File Offset: 0x00207270
		private void _onOnBackButtonClick()
		{
			this._ReturnToTown();
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("BattleOnBack");
		}

		// Token: 0x0600A0ED RID: 41197 RVA: 0x00208E88 File Offset: 0x00207288
		private void _onMissionBackButtonClick()
		{
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			if (DataManager<MissionManager>.GetInstance().IsMainTaskDungeon(dungeonID))
			{
				int mainTaskMainMission = DataManager<MissionManager>.GetInstance().GetMainTaskMainMission(dungeonID);
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)mainTaskMainMission, out singleMissionInfo);
				if (singleMissionInfo != null)
				{
					Singleton<ClientSystemManager>.instance.Push2FrameStack(new MissionTraceTargetCmd(mainTaskMainMission));
				}
			}
			this._ReturnToTown();
		}

		// Token: 0x0600A0EE RID: 41198 RVA: 0x00208EFC File Offset: 0x002072FC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonMenu";
		}

		// Token: 0x0600A0EF RID: 41199 RVA: 0x00208F03 File Offset: 0x00207303
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A0F0 RID: 41200 RVA: 0x00208F06 File Offset: 0x00207306
		private void _onNpcTalkBtnButtonClick()
		{
			this.mNpcTalkBtn.CustomActive(false);
			this.GotoBuinessmanShop();
		}

		// Token: 0x0600A0F1 RID: 41201 RVA: 0x00208F1A File Offset: 0x0020731A
		private void _onBuinessmanBtnButtonClick()
		{
			this.GotoBuinessmanShop();
		}

		// Token: 0x0600A0F2 RID: 41202 RVA: 0x00208F24 File Offset: 0x00207324
		protected override void _OnOpenFrame()
		{
			this.mDungeonState = DungeonMenuFrame.eDungeonMenu.None;
			this.returned = false;
			this.mIsSendMessage = false;
			this.mysticalMerchantId = DataManager<ShopDataManager>.GetInstance().MysticalMerchantID;
			if (this.m_reportBtn != null)
			{
				this.m_reportBtn.CustomActive(false);
			}
			if (this.mysticalMerchantId == -1)
			{
				int mLeftTime = this.mCounter.mLeftTime;
				this.mCounter.StartCount(delegate
				{
					if (this.mMissionRoot.activeSelf)
					{
						if (Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID() == NewbieGuideTable.eNewbieGuideTask.ReturnToTownGuide)
						{
							Singleton<NewbieGuideManager>.GetInstance().ManagerFinishGuide(Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID());
						}
						this._onMissionBackButtonClick();
					}
					else
					{
						this._ReturnToTown();
					}
				}, mLeftTime);
			}
			else if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType != DungeonTable.eSubType.S_RAID_DUNGEON)
			{
				this.ShowBattleNpc();
			}
			this._loadFriend();
			this._updateMainMissionInfo();
			this._updatePlayerAgain();
			if (BattleMain.battleType != BattleType.AnniversaryPVE_III)
			{
				this._InitPlayerInformation();
			}
			else
			{
				this.mPlayerInformation.CustomActive(false);
			}
			if (BattleMain.instance != null && BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().GetDungeonDataManager() != null && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id != null)
			{
				int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
				if (DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(dungeonID))
				{
					this.mOnAgain.CustomActive(false);
				}
			}
		}

		// Token: 0x0600A0F3 RID: 41203 RVA: 0x0020907F File Offset: 0x0020747F
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.mysticalMerchantId != -1)
			{
				this.CheckDistance();
				this.UpdateTalkBtnPos(timeElapsed);
			}
		}

		// Token: 0x0600A0F4 RID: 41204 RVA: 0x0020909A File Offset: 0x0020749A
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A0F5 RID: 41205 RVA: 0x002090A0 File Offset: 0x002074A0
		private void AddDialog(int id, UnityAction action)
		{
			TaskDialogFrame.OnDialogOver onDialogOver = new TaskDialogFrame.OnDialogOver();
			if (action != null)
			{
				onDialogOver.AddListener(action);
			}
			DataManager<MissionManager>.GetInstance().CreateDialogFrame(id, 0, onDialogOver);
			Singleton<DeviceVibrateManager>.GetInstance().TriggerDeviceVibrateByType(VibrateSwitchType.MysteryShop);
		}

		// Token: 0x0600A0F6 RID: 41206 RVA: 0x002090DC File Offset: 0x002074DC
		private void _updatePlayerAgain()
		{
			bool flag = this._isShowAgainButton();
			this.mAgain.CustomActive(flag);
			if (flag && !this._isCanAgainEnterDungeon())
			{
				this.mAgain.SafeAddComponent(true);
			}
		}

		// Token: 0x0600A0F7 RID: 41207 RVA: 0x0020911C File Offset: 0x0020751C
		private void _InitPlayerInformation()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.instance.GetPlayerManager() == null)
			{
				return;
			}
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			if (allPlayers.Count > 3)
			{
				Logger.LogErrorFormat("战斗结算伤害统计界面显示角色个数异常：playerList count = {0}", new object[]
				{
					allPlayers.Count
				});
			}
			List<BattlePlayer> list = new List<BattlePlayer>();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				list.Add(allPlayers[i]);
			}
			list.Sort(new Comparison<BattlePlayer>(this.SortList));
			long num = 0L;
			long num2 = 0L;
			int num3 = -1;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] != null && list[j].playerActor != null)
				{
					BeEntity topOwner = list[j].playerActor.GetTopOwner(list[j].playerActor);
					if (topOwner != null && topOwner.GetEntityData() != null && topOwner.GetEntityData().battleData != null)
					{
						long totalDamage = topOwner.GetEntityData().battleData.GetTotalDamage();
						if (totalDamage > num)
						{
							num = totalDamage;
							num3 = j;
						}
						num2 += totalDamage;
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				bool isHighest = k == num3 && list.Count > 1;
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonMenuPlayerItem", true, 0U);
				if (!(null == gameObject))
				{
					DungeonMenuPlayerItem component = gameObject.GetComponent<DungeonMenuPlayerItem>();
					if (component != null)
					{
						component.InitPlayerItem(list[k], num, num2, isHighest);
						Utility.AttachTo(gameObject, this.mPlayerInformationItemRoot, false);
					}
				}
			}
		}

		// Token: 0x0600A0F8 RID: 41208 RVA: 0x00209314 File Offset: 0x00207714
		private int SortList(BattlePlayer a, BattlePlayer b)
		{
			if (a == null || b == null)
			{
				return 0;
			}
			if (a.playerActor == null || b.playerActor == null)
			{
				return 0;
			}
			BeEntity topOwner = a.playerActor.GetTopOwner(a.playerActor);
			BeEntity topOwner2 = b.playerActor.GetTopOwner(b.playerActor);
			if (topOwner == null || topOwner2 == null)
			{
				return 0;
			}
			if (topOwner.GetEntityData() == null || topOwner2.GetEntityData() == null)
			{
				return 0;
			}
			if (topOwner.GetEntityData().battleData == null || topOwner2.GetEntityData().battleData == null)
			{
				return 0;
			}
			long totalDamage = topOwner.GetEntityData().battleData.GetTotalDamage();
			long totalDamage2 = topOwner2.GetEntityData().battleData.GetTotalDamage();
			if (totalDamage > totalDamage2)
			{
				return -1;
			}
			if (totalDamage < totalDamage2)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600A0F9 RID: 41209 RVA: 0x002093E8 File Offset: 0x002077E8
		private bool _isCanAgainEnterDungeon()
		{
			int num = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			num = ChapterUtility.GetOriginDungeonId(num);
			return ChapterUtility.GetDungeonCanEnter(num, false, true, false) && ChapterUtility.IsCanComsumeFatigue(num) && DungeonUtility.IsWeekHellDungeonCanAgain(num);
		}

		// Token: 0x0600A0FA RID: 41210 RVA: 0x00209444 File Offset: 0x00207844
		private bool _isShowAgainButton()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			if (BattleMain.battleType == BattleType.AnniversaryPVE_III)
			{
				return false;
			}
			DungeonID id = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id;
			return id.prestoryID <= 0 && id.dungeonIDWithOutDiff != 720000 && id.dungeonIDWithOutDiff != 600000 && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType != DungeonTable.eSubType.S_CITYMONSTER && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType != DungeonTable.eSubType.S_GUILD_DUNGEON && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType != DungeonTable.eSubType.S_RAID_DUNGEON && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table.SubType != DungeonTable.eSubType.S_TREASUREMAP && DungeonUtility.IsWeekHellDungeonCanAgain(id.dungeonID) && BattleMain.instance.GetBattle().GetMode() == eDungeonMode.LocalFrame;
		}

		// Token: 0x0600A0FB RID: 41211 RVA: 0x0020955E File Offset: 0x0020795E
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600A0FC RID: 41212 RVA: 0x00209560 File Offset: 0x00207960
		private void _bindEvent()
		{
		}

		// Token: 0x0600A0FD RID: 41213 RVA: 0x00209562 File Offset: 0x00207962
		private void _unbindEvent()
		{
		}

		// Token: 0x0600A0FE RID: 41214 RVA: 0x00209564 File Offset: 0x00207964
		private bool _isMyFriend(ulong id)
		{
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(id);
			return relationByRoleID != null && (relationByRoleID.IsFriend() || relationByRoleID.IsMater() || relationByRoleID.IsDisciple());
		}

		// Token: 0x0600A0FF RID: 41215 RVA: 0x002095A8 File Offset: 0x002079A8
		private void _loadFriend()
		{
			if (this.CheckRaidBattle() || BattleMain.battleType == BattleType.AnniversaryPVE_III)
			{
				return;
			}
			this.mFriendAddRoot.SetActive(false);
			string prefabPath = this.mBind.GetPrefabPath("unit");
			this.mBind.ClearCacheBinds(prefabPath);
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				ulong roleID = allPlayers[i].playerInfo.roleId;
				if (roleID != mainPlayer.playerInfo.roleId && !this._isMyFriend(roleID))
				{
					ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
					if (null != comCommonBind)
					{
						this.mFriendAddRoot.SetActive(true);
						Utility.AttachTo(comCommonBind.gameObject, this.mFriendAddRoot, false);
						Image com = comCommonBind.GetCom<Image>("icon");
						Text com2 = comCommonBind.GetCom<Text>("name");
						Button com3 = comCommonBind.GetCom<Button>("onAdd");
						GameObject addRoot = comCommonBind.GetGameObject("addRoot");
						GameObject hasAddRoot = comCommonBind.GetGameObject("hasAddRoot");
						TeamUtility.GetSpriteByOccu(ref com, allPlayers[i].playerInfo.occupation);
						com2.text = allPlayers[i].playerInfo.name;
						addRoot.SetActive(true);
						hasAddRoot.SetActive(false);
						com3.onClick.RemoveAllListeners();
						com3.onClick.AddListener(delegate()
						{
							DataManager<RelationDataManager>.GetInstance().AddFriendByID(roleID);
							addRoot.SetActive(false);
							hasAddRoot.SetActive(true);
						});
					}
				}
			}
		}

		// Token: 0x0600A100 RID: 41216 RVA: 0x00209780 File Offset: 0x00207B80
		private void _ReturnToTown()
		{
			this.mDungeonState = DungeonMenuFrame.eDungeonMenu.BackTown;
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLICK_RETURN, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentAreaID(), string.Empty);
			if (this.returned)
			{
				return;
			}
			this.returned = true;
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			DataManager<ShopDataManager>.GetInstance().MysticalMerchantID = -1;
		}

		// Token: 0x0600A101 RID: 41217 RVA: 0x002097FC File Offset: 0x00207BFC
		private void _updateMainMissionInfo()
		{
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			this.mMissionRoot.SetActive(false);
			if (DataManager<MissionManager>.GetInstance().IsMainTaskDungeon(dungeonID))
			{
				int mainTaskMainMission = DataManager<MissionManager>.GetInstance().GetMainTaskMainMission(dungeonID);
				MissionManager.SingleMissionInfo singleMissionInfo;
				DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)mainTaskMainMission, out singleMissionInfo);
				if (singleMissionInfo != null)
				{
					this.mMissionRoot.SetActive(true);
					this.mMissionInfo.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)mainTaskMainMission) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)singleMissionInfo.status, singleMissionInfo.missionItem.ID);
				}
			}
		}

		// Token: 0x0600A102 RID: 41218 RVA: 0x002098A8 File Offset: 0x00207CA8
		private void _sendSceneDungeonStartRep()
		{
			int num = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			num = ChapterUtility.GetOriginDungeonId(num);
			if (!ChapterUtility.IsCanComsumeFatigue(num))
			{
				return;
			}
			if (!ChapterUtility.GetDungeonCanEnter(num, true, true, false))
			{
				return;
			}
			MonoSingleton<NetManager>.instance.ClearReSendData();
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendSceneDungeonStart(num));
			DataManager<ShopDataManager>.GetInstance().MysticalMerchantID = -1;
		}

		// Token: 0x0600A103 RID: 41219 RVA: 0x00209918 File Offset: 0x00207D18
		private IEnumerator _sendSceneDungeonStart(int dungeonID)
		{
			if (!this.mIsSendMessage)
			{
				this.mDungeonState = DungeonMenuFrame.eDungeonMenu.Again;
				SceneDungeonStartReq req = new SceneDungeonStartReq();
				req.dungeonId = (uint)dungeonID;
				req.isRestart = 1;
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				this.mIsSendMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, true, 5f);
				this.mIsSendMessage = false;
			}
			yield break;
		}

		// Token: 0x0600A104 RID: 41220 RVA: 0x0020993C File Offset: 0x00207D3C
		protected void ShowBattleNpc()
		{
			this.HideCounter();
			MysticalMerchantTable tableItem = Singleton<TableManager>.instance.GetTableItem<MysticalMerchantTable>(this.mysticalMerchantId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			NpcTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<NpcTable>(tableItem.ShopNpcID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			this.SetTalkBtnImage(tableItem2);
			this.ShowDialog(int.Parse(tableItem2.NpcTalk));
			this.CreateNpc(tableItem2);
		}

		// Token: 0x0600A105 RID: 41221 RVA: 0x002099B2 File Offset: 0x00207DB2
		protected void SetTalkBtnImage(NpcTable npcData)
		{
			ETCImageLoader.LoadSprite(ref this.mBuinessmanImage, npcData.FunctionIcon, true);
		}

		// Token: 0x0600A106 RID: 41222 RVA: 0x002099C7 File Offset: 0x00207DC7
		protected void HideCounter()
		{
			this.mBuinessmanBtn.CustomActive(true);
			this.mCounter.CustomActive(false);
		}

		// Token: 0x0600A107 RID: 41223 RVA: 0x002099E4 File Offset: 0x00207DE4
		protected void ShowDialog(int talkId)
		{
			if (Singleton<TableManager>.instance.GetTableItem<TalkTable>(talkId, string.Empty, string.Empty) == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
			{
				this.AddDialog(talkId, delegate
				{
					this.GotoBuinessmanShop();
					this.MysticalMerchantDungeonTypeTigger();
				});
			}, 0, 0, false);
		}

		// Token: 0x0600A108 RID: 41224 RVA: 0x00209A48 File Offset: 0x00207E48
		protected void CreateNpc(NpcTable npcData)
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			BeActor playerActor = mainPlayer.playerActor;
			GeActorEx geActorEx = playerActor.CurrentBeScene.currentGeScene.CreateActor(npcData.ResID, 0, 0, true, true, true, false);
			geActorEx.CreateInfoBar(npcData.NpcName, PlayerInfoColor.TOWN_NPC, 0, null, 0f);
			this.npcPos = this.GetNpcPosition(playerActor, playerActor.CurrentBeScene);
			this.localActor = playerActor;
			geActorEx.SetPosition(this.npcPos);
		}

		// Token: 0x0600A109 RID: 41225 RVA: 0x00209AC4 File Offset: 0x00207EC4
		protected Vector3 GetNpcPosition(BeActor localActor, BeScene scene)
		{
			return scene.GetPosInXAxis(localActor, 10).vector3;
		}

		// Token: 0x0600A10A RID: 41226 RVA: 0x00209AE4 File Offset: 0x00207EE4
		protected void CheckDistance()
		{
			if (this.localActor == null)
			{
				return;
			}
			Vector3 vector = this.localActor.GetPosition().vector3;
			bool bActive = Vector3.Distance(vector, this.npcPos) <= this.showBtnDis;
			this.mNpcTalkBtn.CustomActive(bActive);
		}

		// Token: 0x0600A10B RID: 41227 RVA: 0x00209B38 File Offset: 0x00207F38
		protected void UpdateTalkBtnPos(float deltaTime)
		{
			if (!this.mNpcTalkBtn.gameObject.activeInHierarchy)
			{
				return;
			}
			Vector2 vector = Vector3.zero;
			if (Camera.main == null)
			{
				return;
			}
			Vector3 vector2 = Camera.main.WorldToScreenPoint(this.npcPos);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.frame.transform as RectTransform, vector2, Singleton<ClientSystemManager>.GetInstance().UICamera, ref vector);
			this.mNpcTalkBtn.transform.localPosition = vector;
		}

		// Token: 0x0600A10C RID: 41228 RVA: 0x00209BC6 File Offset: 0x00207FC6
		protected void GotoBuinessmanShop()
		{
			DataManager<ShopDataManager>.GetInstance().OpenMysteryShopFrame();
		}

		// Token: 0x0600A10D RID: 41229 RVA: 0x00209BD4 File Offset: 0x00207FD4
		protected void MysticalMerchantDungeonTypeTigger()
		{
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			MysticalMerchantTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<MysticalMerchantTable>(this.mysticalMerchantId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			ShopTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(tableItem2.ShopId, string.Empty, string.Empty);
			if (tableItem3 == null)
			{
				return;
			}
			string dungeonName = Singleton<GameStatisticManager>.GetInstance().DungeonName((GameStatisticManager.DungeonsType)tableItem.SubType);
			string shopName = tableItem3.ShopName;
			Singleton<GameStatisticManager>.GetInstance().DoStartMysticalMerchantDungeon(dungeonName, shopName);
		}

		// Token: 0x0600A10E RID: 41230 RVA: 0x00209C84 File Offset: 0x00208084
		private bool CheckRaidBattle()
		{
			return BattleMain.battleType == BattleType.RaidPVE;
		}

		// Token: 0x0600A10F RID: 41231 RVA: 0x00209C98 File Offset: 0x00208098
		private int GetCountNum(int originCount)
		{
			int result = originCount;
			BattleType battleType = BattleMain.battleType;
			if (battleType == BattleType.RaidPVE)
			{
				result = 5;
			}
			return result;
		}

		// Token: 0x04005977 RID: 22903
		private DungeonMenuFrame.eDungeonMenu mDungeonState;

		// Token: 0x04005978 RID: 22904
		private bool returned;

		// Token: 0x04005979 RID: 22905
		private int mysticalMerchantId;

		// Token: 0x0400597A RID: 22906
		private const string dungeonMenuPlayerItemPath = "UIFlatten/Prefabs/BattleUI/DungeonMenuPlayerItem";

		// Token: 0x0400597B RID: 22907
		private ComCountScript mCounter;

		// Token: 0x0400597C RID: 22908
		private GameObject mFriendAddRoot;

		// Token: 0x0400597D RID: 22909
		private Button mOnAgain;

		// Token: 0x0400597E RID: 22910
		private Button mOnBack;

		// Token: 0x0400597F RID: 22911
		private GameObject mMissionRoot;

		// Token: 0x04005980 RID: 22912
		private Text mMissionInfo;

		// Token: 0x04005981 RID: 22913
		private Text mMissionDesc;

		// Token: 0x04005982 RID: 22914
		private GameObject mAgain;

		// Token: 0x04005983 RID: 22915
		private Button mNpcTalkBtn;

		// Token: 0x04005984 RID: 22916
		private Button mBuinessmanBtn;

		// Token: 0x04005985 RID: 22917
		private Image mBuinessmanImage;

		// Token: 0x04005986 RID: 22918
		private Button mMissionBack;

		// Token: 0x04005987 RID: 22919
		private GameObject mPlayerInformationItemRoot;

		// Token: 0x04005988 RID: 22920
		private GameObject mPlayerInformation;

		// Token: 0x04005989 RID: 22921
		[UIObject("r/ButtonRoot/Root/Reporter")]
		private GameObject m_reportBtn;

		// Token: 0x0400598A RID: 22922
		private bool mIsSendMessage;

		// Token: 0x0400598B RID: 22923
		protected int borderDis = 2;

		// Token: 0x0400598C RID: 22924
		protected float showBtnDis = 5f;

		// Token: 0x0400598D RID: 22925
		protected Vector3 npcPos = Vector3.zero;

		// Token: 0x0400598E RID: 22926
		protected BeActor localActor;

		// Token: 0x020010AC RID: 4268
		private enum eDungeonMenu
		{
			// Token: 0x04005990 RID: 22928
			None,
			// Token: 0x04005991 RID: 22929
			Again,
			// Token: 0x04005992 RID: 22930
			Next,
			// Token: 0x04005993 RID: 22931
			ChapterSelect,
			// Token: 0x04005994 RID: 22932
			BackTown
		}
	}
}
