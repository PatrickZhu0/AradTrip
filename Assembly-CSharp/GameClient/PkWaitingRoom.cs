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
	// Token: 0x020019A1 RID: 6561
	public class PkWaitingRoom : ClientFrame
	{
		// Token: 0x0600FF62 RID: 65378 RVA: 0x0046BCFF File Offset: 0x0046A0FF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkWaitingRoom";
		}

		// Token: 0x0600FF63 RID: 65379 RVA: 0x0046BD08 File Offset: 0x0046A108
		private void _UpdateStatus()
		{
			if (null != this.comState)
			{
				if (DataManager<MoneyRewardsDataManager>.GetInstance().needEnterance)
				{
					this.comState.Key = "moneyrewards";
				}
				else if (DataManager<GuildDataManager>.GetInstance().IsInGuildBattle())
				{
					this.comState.Key = "guildfighter";
				}
				else if (DataManager<BudoManager>.GetInstance().IsOpen)
				{
					this.comState.Key = "budofighter";
				}
				else
				{
					this.comState.Key = "normal";
				}
			}
		}

		// Token: 0x0600FF64 RID: 65380 RVA: 0x0046BDA4 File Offset: 0x0046A1A4
		protected override void _OnOpenFrame()
		{
			this.RoomData = (this.userData as PkWaitingRoomData);
			Singleton<TableManager>.instance.LoadData();
			this.currLevel = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			this.currJob = Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			DataManager<ShopDataManager>.GetInstance().InitBaseWeaponData(this.currJob);
			this.InitInterface();
			this.BindUIEvent();
			this._UpdateStatus();
			this.TryOpenSkilltreeFrame();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(321, string.Empty, string.Empty);
			this.duelTuiJianEquipMaxLevel = tableItem.Value;
			this._QueryShopData(5, delegate
			{
				this._RefreshWeaponShow();
			});
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null)
			{
				DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
			}
			if (Singleton<ReplayServer>.GetInstance().IsLastPlaying())
			{
				Singleton<ReplayServer>.GetInstance().SetLastPlaying(false);
				if (Singleton<ReplayServer>.GetInstance().replaySource == ReplayPlayFrom.VIDEO_FRAME)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkVideoFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			this.mFairDuel.CustomActive(DataManager<FairDuelDataManager>.GetInstance().IsShowFairDuelEnterBtn());
			this.mCancelGo.CustomActive(false);
			this.Update2V2PointRaceBtn(new UIEvent
			{
				Param1 = (byte)DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus()
			});
			this.Update3V3PointRaceBtn(new UIEvent
			{
				Param1 = (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus()
			});
		}

		// Token: 0x0600FF65 RID: 65381 RVA: 0x0046BF1C File Offset: 0x0046A31C
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3RoomListFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.DailyProve);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OutPkWaitingScene, null, null, null, null);
		}

		// Token: 0x0600FF66 RID: 65382 RVA: 0x0046BF94 File Offset: 0x0046A394
		private void ClearData()
		{
			this.RoomData.Clear();
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Clear();
				this.m_comPKRank = null;
			}
			if (this.getDuleWeaponList != null)
			{
				this.getDuleWeaponList.Clear();
			}
			this.bIsAddGuide = false;
			this.fTimeIntrval = 0f;
			this.fTime = 0f;
			this.duelTuiJianEquipMaxLevel = 0;
			PkWaitingRoom.bBeginSeekPlayer = false;
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallAttrTime);
		}

		// Token: 0x0600FF67 RID: 65383 RVA: 0x0046C044 File Offset: 0x0046A444
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnPkMatchStartSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnPkMatchCancelSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.pkGuideStart, new ClientEventSystem.UIEventHandler(this.OnPkGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.pkGuideEnd, new ClientEventSystem.UIEventHandler(this.OnPkGuideEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkCoinChanged, new ClientEventSystem.UIEventHandler(this._OnPkCoinUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnSelfLevelUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._OnShopBuyGoodsSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._GuildBattleStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._OnBudoInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateFairDuelEntryState, new ClientEventSystem.UIEventHandler(this._OnUpdateFairDuelEntryState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK2V2CrossButton, new ClientEventSystem.UIEventHandler(this.Update2V2PointRaceBtn));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.Update3V3PointRaceBtn));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600FF68 RID: 65384 RVA: 0x0046C23C File Offset: 0x0046A63C
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnPkMatchStartSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnPkMatchCancelSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.pkGuideStart, new ClientEventSystem.UIEventHandler(this.OnPkGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.pkGuideEnd, new ClientEventSystem.UIEventHandler(this.OnPkGuideEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._OnPkRankChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataSeasonUpdated, new ClientEventSystem.UIEventHandler(this._OnSeasonDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this._OnMissionUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkCoinChanged, new ClientEventSystem.UIEventHandler(this._OnPkCoinUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnSelfLevelUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._OnShopBuyGoodsSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._GuildBattleStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this._OnBudoInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateFairDuelEntryState, new ClientEventSystem.UIEventHandler(this._OnUpdateFairDuelEntryState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK2V2CrossButton, new ClientEventSystem.UIEventHandler(this.Update2V2PointRaceBtn));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.Update3V3PointRaceBtn));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600FF69 RID: 65385 RVA: 0x0046C434 File Offset: 0x0046A834
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town!!!");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.RoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.RoomData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<PkWaitingRoom>(this, false);
		}

		// Token: 0x0600FF6A RID: 65386 RVA: 0x0046C4D2 File Offset: 0x0046A8D2
		[UIEventHandle("btMenu")]
		private void OnMenu()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FF6B RID: 65387 RVA: 0x0046C4E6 File Offset: 0x0046A8E6
		[UIEventHandle("btSkill")]
		private void OnSkill()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, SkillLeftType.PVP, string.Empty);
		}

		// Token: 0x0600FF6C RID: 65388 RVA: 0x0046C4FF File Offset: 0x0046A8FF
		[UIEventHandle("btPackage")]
		private void OnPackage()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FF6D RID: 65389 RVA: 0x0046C514 File Offset: 0x0046A914
		[UIEventHandle("btPkfriends")]
		private void OnPkFriends()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkFriendsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkFriendsFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkFriendsFrame>(FrameLayer.Middle, RequestType.Request_Challenge_PK, string.Empty);
		}

		// Token: 0x0600FF6E RID: 65390 RVA: 0x0046C56F File Offset: 0x0046A96F
		[UIEventHandle("btFreeTrain")]
		private void OnFreeTrain()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<InstituteFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FF6F RID: 65391 RVA: 0x0046C5A0 File Offset: 0x0046A9A0
		[UIEventHandle("ranklist")]
		private void OnRankList()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Ranklist))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足,功能尚未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RanklistFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RanklistFrame>(null, false);
			}
			this.frameMgr.OpenFrame<RanklistFrame>(FrameLayer.Middle, SortListType.SORTLIST_1V1_SEASON, string.Empty);
		}

		// Token: 0x0600FF70 RID: 65392 RVA: 0x0046C5FA File Offset: 0x0046A9FA
		[UIEventHandle("duelshop")]
		private void OnDuelShop()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(5, 0, 0, -1);
		}

		// Token: 0x0600FF71 RID: 65393 RVA: 0x0046C60A File Offset: 0x0046AA0A
		[UIEventHandle("topRight/btGotoButo")]
		private void OnGotoButo()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (!Utility.EnterBudo())
			{
				return;
			}
			this.frameMgr.CloseFrame<PkWaitingRoom>(this, false);
		}

		// Token: 0x0600FF72 RID: 65394 RVA: 0x0046C63E File Offset: 0x0046AA3E
		[UIEventHandle("topRight/btGotoMoneyRewards")]
		private void OnGotoMoneyRewards()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			MoneyRewardsEnterFrame.CommandOpen(null);
		}

		// Token: 0x0600FF73 RID: 65395 RVA: 0x0046C660 File Offset: 0x0046AA60
		[UIEventHandle("btBegin")]
		private void OnBegin()
		{
			if (!PkWaitingRoom.bBeginSeekPlayer)
			{
				this.SendMatchStartReq();
			}
			else
			{
				this.SendMatchCancelReq();
			}
			this.btBegin.interactable = false;
			Singleton<GameStatisticManager>.GetInstance().DoStatPk(StatPKType.MATCHING, string.Empty);
		}

		// Token: 0x0600FF74 RID: 65396 RVA: 0x0046C699 File Offset: 0x0046AA99
		[UIEventHandle("btPkVideo")]
		private void _OnPKVideoClicked()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkVideoFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FF75 RID: 65397 RVA: 0x0046C6C8 File Offset: 0x0046AAC8
		private void InitInterface()
		{
			if (Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Ranklist))
			{
				this.ranklist.gameObject.SetActive(true);
			}
			this._InitTalk();
			this.InitRedPoint();
			this._InitSeasonLevel();
			Singleton<GameStatisticManager>.GetInstance().DoStatPk(StatPKType.ENTER, string.Empty);
			this.UpdateHonorExpValueLabel();
		}

		// Token: 0x0600FF76 RID: 65398 RVA: 0x0046C71C File Offset: 0x0046AB1C
		private void _InitSeasonLevel()
		{
			this.m_comPKRank = ComPKRank.Create(this.m_objPKRankRoot);
			this.m_comPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonExp);
			PromotionInfo promotionInfo = DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo(DataManager<SeasonDataManager>.GetInstance().seasonLevel, PKResult.INVALID);
			if (promotionInfo.eState == EPromotionState.Promoting)
			{
				this.m_objPromotionRoot.SetActive(true);
				this._SetChildrenEnable(this.m_objRecordRoot, false);
				for (int i = 0; i < promotionInfo.nTotalCount; i++)
				{
					GameObject gameObject;
					if (i < this.m_objRecordRoot.transform.childCount)
					{
						gameObject = this.m_objRecordRoot.transform.GetChild(i).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
						gameObject.transform.SetParent(this.m_objRecordRoot.transform, false);
					}
					gameObject.SetActive(true);
					this._SetChildrenEnable(gameObject, false);
				}
				List<byte> seasonUplevelRecords = DataManager<SeasonDataManager>.GetInstance().seasonUplevelRecords;
				if (seasonUplevelRecords != null && seasonUplevelRecords.Count <= this.m_objRecordRoot.transform.childCount)
				{
					for (int j = 0; j < seasonUplevelRecords.Count; j++)
					{
						GameObject gameObject2 = this.m_objRecordRoot.transform.GetChild(j).gameObject;
						if (seasonUplevelRecords[j] == 1)
						{
							Utility.FindGameObject(gameObject2, "Win", true).SetActive(true);
						}
						else
						{
							Utility.FindGameObject(gameObject2, "Lose", true).SetActive(true);
						}
					}
				}
				this.m_labPromotionDesc.text = TR.Value("pk_rank_detail_promotion_rule", promotionInfo.nTotalCount, promotionInfo.nTargetWinCount, DataManager<SeasonDataManager>.GetInstance().GetRankName(promotionInfo.nNextSeasonLevel, true));
			}
			else
			{
				this.m_objPromotionRoot.SetActive(false);
			}
			this.m_labCoinDesc.text = TR.Value("pk_rank_detail_coin_info", DataManager<CountDataManager>.GetInstance().GetCount("day_pkcoin"), this._GetDailyMaxPKCoin(), DataManager<PlayerBaseData>.GetInstance().VipLevel);
			this.m_repeatCallAttrTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				if (this.m_labSeasonAttrTime != null)
				{
					this.m_labSeasonAttrTime.text = this._GetTimeLeft(DataManager<SeasonDataManager>.GetInstance().seasonAttrEndTime);
				}
			}, 9999999, true);
		}

		// Token: 0x0600FF77 RID: 65399 RVA: 0x0046C968 File Offset: 0x0046AD68
		private void _UpdateSeasonLevel()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonExp);
			}
			PromotionInfo promotionInfo = DataManager<SeasonDataManager>.GetInstance().GetPromotionInfo(DataManager<SeasonDataManager>.GetInstance().seasonLevel, PKResult.INVALID);
			if (promotionInfo.eState == EPromotionState.Promoting)
			{
				this.m_objPromotionRoot.SetActive(true);
				this._SetChildrenEnable(this.m_objRecordRoot, false);
				for (int i = 0; i < promotionInfo.nTotalCount; i++)
				{
					GameObject gameObject;
					if (i < this.m_objRecordRoot.transform.childCount)
					{
						gameObject = this.m_objRecordRoot.transform.GetChild(i).gameObject;
					}
					else
					{
						gameObject = Object.Instantiate<GameObject>(this.m_objRecordTemplate);
						gameObject.transform.SetParent(this.m_objRecordRoot.transform, false);
					}
					gameObject.SetActive(true);
					this._SetChildrenEnable(gameObject, false);
				}
				List<byte> seasonUplevelRecords = DataManager<SeasonDataManager>.GetInstance().seasonUplevelRecords;
				if (seasonUplevelRecords != null && seasonUplevelRecords.Count <= this.m_objRecordRoot.transform.childCount)
				{
					for (int j = 0; j < seasonUplevelRecords.Count; j++)
					{
						GameObject gameObject2 = this.m_objRecordRoot.transform.GetChild(j).gameObject;
						if (seasonUplevelRecords[j] == 1)
						{
							Utility.FindGameObject(gameObject2, "Win", true).SetActive(true);
						}
						else
						{
							Utility.FindGameObject(gameObject2, "Lose", true).SetActive(true);
						}
					}
				}
				this.m_labPromotionDesc.text = TR.Value("pk_rank_detail_promotion_rule", promotionInfo.nTotalCount, promotionInfo.nTargetWinCount, DataManager<SeasonDataManager>.GetInstance().GetRankName(promotionInfo.nNextSeasonLevel, true));
			}
			else
			{
				this.m_objPromotionRoot.SetActive(false);
			}
		}

		// Token: 0x0600FF78 RID: 65400 RVA: 0x0046CB44 File Offset: 0x0046AF44
		private string _GetTimeLeft(int a_nEndTime)
		{
			int num = a_nEndTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num <= 0)
			{
				return string.Empty;
			}
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
			if (num4 > 0)
			{
				str += string.Format("{0}天", num4);
				return str + string.Format("{0:D2}小时", num3);
			}
			if (num3 > 0)
			{
				str += string.Format("{0:D2}小时", num3);
				return str + string.Format("{0:D2}分", num2);
			}
			if (num2 > 0)
			{
				str += string.Format("{0:D2}分", num2);
				return str + string.Format("{0:D2}秒", num5);
			}
			return string.Format("{0:D2}秒", num5);
		}

		// Token: 0x0600FF79 RID: 65401 RVA: 0x0046CC78 File Offset: 0x0046B078
		private void _SetChildrenEnable(GameObject a_obj, bool a_bEnable)
		{
			for (int i = 0; i < a_obj.transform.childCount; i++)
			{
				a_obj.transform.GetChild(i).gameObject.SetActive(a_bEnable);
			}
		}

		// Token: 0x0600FF7A RID: 65402 RVA: 0x0046CCB8 File Offset: 0x0046B0B8
		private int _GetDailyMaxPKCoin()
		{
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(10, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.PK_MONEY_LIMIT);
			return num + (int)curVipLevelPrivilegeData;
		}

		// Token: 0x0600FF7B RID: 65403 RVA: 0x0046CCF8 File Offset: 0x0046B0F8
		private void _InitTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.TalkRoot);
		}

		// Token: 0x0600FF7C RID: 65404 RVA: 0x0046CD0C File Offset: 0x0046B10C
		private void InitRedPoint()
		{
			this.btPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			this.btSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
			this.DailyProveRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.DailyProve));
		}

		// Token: 0x0600FF7D RID: 65405 RVA: 0x0046CD74 File Offset: 0x0046B174
		private void OnRedPointChanged(UIEvent iEvent)
		{
			ERedPoint eredPoint = (ERedPoint)iEvent.Param1;
			if (eredPoint == ERedPoint.Skill)
			{
				this.btSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
			}
			else if (eredPoint == ERedPoint.DailyProve)
			{
				this.DailyProveRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.DailyProve));
			}
			else
			{
				this.btPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			}
		}

		// Token: 0x0600FF7E RID: 65406 RVA: 0x0046CE08 File Offset: 0x0046B208
		private void OnPkMatchStartSuccess(UIEvent iEvent)
		{
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.TraditionPk;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
			PkWaitingRoom.bBeginSeekPlayer = true;
			this.mCancelGo.CustomActive(true);
			this.btBegin.interactable = true;
		}

		// Token: 0x0600FF7F RID: 65407 RVA: 0x0046CE52 File Offset: 0x0046B252
		private void OnPkMatchCancelSuccess(UIEvent iEvent)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			PkWaitingRoom.bBeginSeekPlayer = false;
			this.mCancelGo.CustomActive(false);
			this.btBegin.interactable = true;
		}

		// Token: 0x0600FF80 RID: 65408 RVA: 0x0046CE7E File Offset: 0x0046B27E
		private void OnPkGuideStart(UIEvent iEvent)
		{
			this.ResetGuide();
		}

		// Token: 0x0600FF81 RID: 65409 RVA: 0x0046CE86 File Offset: 0x0046B286
		private void OnPkGuideEnd(UIEvent iEvent)
		{
			this.CloseGuide();
		}

		// Token: 0x0600FF82 RID: 65410 RVA: 0x0046CE8E File Offset: 0x0046B28E
		private void _OnPkRankChanged(UIEvent a_event)
		{
			this._UpdateSeasonLevel();
		}

		// Token: 0x0600FF83 RID: 65411 RVA: 0x0046CE96 File Offset: 0x0046B296
		private void _OnSeasonDataUpdate(UIEvent a_event)
		{
			this._UpdateSeasonLevel();
		}

		// Token: 0x0600FF84 RID: 65412 RVA: 0x0046CE9E File Offset: 0x0046B29E
		private void _OnMissionUpdated(UIEvent a_event)
		{
			this.DailyProveRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.DailyProve));
		}

		// Token: 0x0600FF85 RID: 65413 RVA: 0x0046CEC0 File Offset: 0x0046B2C0
		private void _OnPkCoinUpdated(UIEvent a_event)
		{
			if (this.mItemRoot == null)
			{
				return;
			}
			this.selfPkCoin = DataManager<PlayerBaseData>.GetInstance().uiPkCoin;
			if (this.mItemRoot.activeInHierarchy)
			{
				this.mCostSlider.value = this.selfPkCoin / (float)this.shopItemTable.CostNum;
				this.mCostText.text = this.selfPkCoin + "/" + this.shopItemTable.CostNum;
				GameObject gameObject = Utility.FindChild(this.mItemRoot, "EffUI_kegoumai");
				if (gameObject == null)
				{
					return;
				}
				if (this.mCostSlider.value == 1f)
				{
					gameObject.CustomActive(true);
				}
				else
				{
					gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600FF86 RID: 65414 RVA: 0x0046CF98 File Offset: 0x0046B398
		private void _RefreshWeaponShow()
		{
			this.currLevel = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			int num = 0;
			ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(5);
			if (goodsDataFromShop != null)
			{
				foreach (KeyValuePair<int, List<ShopItemTable>> keyValuePair in DataManager<ShopDataManager>.GetInstance().GetDuelWeaponsDict())
				{
					List<ShopItemTable> value = keyValuePair.Value;
					if (value != null)
					{
						int num2 = 0;
						for (int i = 0; i < value.Count; i++)
						{
							for (int j = 0; j < goodsDataFromShop.Goods.Count; j++)
							{
								if (value[i].ID == goodsDataFromShop.Goods[j].ID && goodsDataFromShop.Goods[j].LimitBuyTimes != 0)
								{
									num2++;
									break;
								}
							}
						}
						if (num2 < value.Count)
						{
							Dictionary<int, List<ShopItemTable>>.Enumerator enumerator;
							KeyValuePair<int, List<ShopItemTable>> keyValuePair2 = enumerator.Current;
							if (keyValuePair2.Key > num)
							{
								KeyValuePair<int, List<ShopItemTable>> keyValuePair3 = enumerator.Current;
								num = keyValuePair3.Key;
							}
						}
					}
				}
			}
			num += 6;
			if (num > this.duelTuiJianEquipMaxLevel)
			{
				this.mGoDuelWeapon.CustomActive(false);
				return;
			}
			if (num > this.currLevel)
			{
				this.getDuleWeaponList = DataManager<ShopDataManager>.GetInstance()._ScreenCurrJobDuelWeapons(num);
				this.CreatDuleWeaponItem(this.getDuleWeaponList, 0);
			}
			else
			{
				this.getDuleWeaponList = DataManager<ShopDataManager>.GetInstance()._ScreenCurrJobDuelWeapons(this.currLevel);
				this.CreatDuleWeaponItem(this.getDuleWeaponList, 0);
			}
		}

		// Token: 0x0600FF87 RID: 65415 RVA: 0x0046D142 File Offset: 0x0046B542
		private void _OnSelfLevelUpdated(UIEvent a_event)
		{
			this._RefreshWeaponShow();
		}

		// Token: 0x0600FF88 RID: 65416 RVA: 0x0046D14A File Offset: 0x0046B54A
		private void _OnShopBuyGoodsSuccess(UIEvent a_event)
		{
			DataManager<ShopDataManager>.GetInstance().InitBaseWeaponData(this.currJob);
			this._QueryShopData(5, delegate
			{
				this.ShowDuelWeapon();
			});
		}

		// Token: 0x0600FF89 RID: 65417 RVA: 0x0046D16F File Offset: 0x0046B56F
		private void _GuildBattleStateChanged(UIEvent a_event)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600FF8A RID: 65418 RVA: 0x0046D177 File Offset: 0x0046B577
		private void _OnMoneyRewardsStatusChanged(UIEvent a_event)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600FF8B RID: 65419 RVA: 0x0046D17F File Offset: 0x0046B57F
		private void _OnBudoInfoChanged()
		{
			this._UpdateStatus();
		}

		// Token: 0x0600FF8C RID: 65420 RVA: 0x0046D188 File Offset: 0x0046B588
		private void SendMatchStartReq()
		{
			WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
			worldMatchStartReq.type = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
		}

		// Token: 0x0600FF8D RID: 65421 RVA: 0x0046D1B4 File Offset: 0x0046B5B4
		[ProtocolHandle(typeof(WorldMatchStartRes))]
		private void _onMathcStartRes(WorldMatchStartRes msgRet)
		{
			if (msgRet == null)
			{
				return;
			}
			if (msgRet.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchStartSuccess, null, null, null, null);
		}

		// Token: 0x0600FF8E RID: 65422 RVA: 0x0046D20C File Offset: 0x0046B60C
		private void SendMatchCancelReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600FF8F RID: 65423 RVA: 0x0046D230 File Offset: 0x0046B630
		[ProtocolHandle(typeof(WorldMatchCancelRes))]
		private void _onMathcCancelRes(WorldMatchCancelRes msgRet)
		{
			if (msgRet == null)
			{
				return;
			}
			if (msgRet.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelSuccess, null, null, null, null);
		}

		// Token: 0x0600FF90 RID: 65424 RVA: 0x0046D288 File Offset: 0x0046B688
		private void AddGuideEffect()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.fingerPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			gameObject.name = "GuideEffect";
			Utility.AttachTo(gameObject, this.btBegin.gameObject, false);
		}

		// Token: 0x0600FF91 RID: 65425 RVA: 0x0046D2D4 File Offset: 0x0046B6D4
		private void RemoveGuideEffect()
		{
			GameObject gameObject = Utility.FindGameObject(this.frame, this.EffectPath, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600FF92 RID: 65426 RVA: 0x0046D308 File Offset: 0x0046B708
		private void ResetGuide()
		{
			this.fTimeIntrval = 0f;
			this.bIsAddGuide = false;
		}

		// Token: 0x0600FF93 RID: 65427 RVA: 0x0046D31C File Offset: 0x0046B71C
		private void CloseGuide()
		{
			this.bIsAddGuide = true;
		}

		// Token: 0x0600FF94 RID: 65428 RVA: 0x0046D325 File Offset: 0x0046B725
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FF95 RID: 65429 RVA: 0x0046D328 File Offset: 0x0046B728
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeIntrval += timeElapsed;
			if (this.fTimeIntrval >= 12f && !this.bIsAddGuide && this.RoomData.SceneSubType == CitySceneTable.eSceneSubType.TRADITION && !Singleton<NewbieGuideManager>.GetInstance().IsGuiding())
			{
				this.bIsAddGuide = true;
			}
			if (this.mItemRoot.activeInHierarchy)
			{
				this.fTime += timeElapsed;
				if (this.fTime >= 30f)
				{
					GameObject gameObject = Utility.FindChild(this.mGoDuelWeapon, "EffUI_DuelWeapon");
					gameObject.CustomActive(true);
					int count = this.getDuleWeaponList.Count;
					this.CreatDuleWeaponItem(this.getDuleWeaponList, count - (count - this.index));
					this.index++;
					if (this.index == count)
					{
						this.index = 0;
					}
					base.StartCoroutine(this.WaitHide(1f));
					this.fTime = 0f;
				}
			}
		}

		// Token: 0x0600FF96 RID: 65430 RVA: 0x0046D430 File Offset: 0x0046B830
		private IEnumerator WaitHide(float waitTime)
		{
			yield return Yielders.GetWaitForSeconds(waitTime);
			GameObject DuelWeapon = Utility.FindChild(this.mGoDuelWeapon, "EffUI_DuelWeapon");
			DuelWeapon.CustomActive(false);
			yield break;
		}

		// Token: 0x0600FF97 RID: 65431 RVA: 0x0046D452 File Offset: 0x0046B852
		[UIEventHandle("Detail")]
		private void _OnPKRankDetailClicked()
		{
			this.frameMgr.OpenFrame<PKSeasonDetailFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FF98 RID: 65432 RVA: 0x0046D467 File Offset: 0x0046B867
		[UIEventHandle("btSeasonAttr")]
		private void _OnPKSeasonAttrClicked()
		{
			this.frameMgr.OpenFrame<PKSeasonDetailFrame>(FrameLayer.Middle, ESeasonDetailType.Attr, string.Empty);
		}

		// Token: 0x0600FF99 RID: 65433 RVA: 0x0046D484 File Offset: 0x0046B884
		private void _QueryShopData(int iShopID, UnityAction callback)
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(iShopID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(tableItem.ID);
				if (goodsDataFromShop != null)
				{
					if (callback != null)
					{
						callback.Invoke();
					}
					return;
				}
				DataManager<ShopDataManager>.GetInstance().OpenShop(tableItem.ID, 0, -1, delegate
				{
					if (callback != null)
					{
						callback.Invoke();
					}
				}, null, ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME, 0, -1);
			}
		}

		// Token: 0x0600FF9A RID: 65434 RVA: 0x0046D50C File Offset: 0x0046B90C
		private void ShowDuelWeapon()
		{
			ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(5);
			if (goodsDataFromShop != null)
			{
				Dictionary<int, List<ShopItemTable>>.Enumerator enumerator = DataManager<ShopDataManager>.GetInstance().GetDuelWeaponsDict().GetEnumerator();
				bool flag = false;
				int num = 0;
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, List<ShopItemTable>> keyValuePair = enumerator.Current;
					List<ShopItemTable> value = keyValuePair.Value;
					if (value != null)
					{
						int num2 = 0;
						for (int i = 0; i < value.Count; i++)
						{
							for (int j = 0; j < goodsDataFromShop.Goods.Count; j++)
							{
								if (value[i].ID == goodsDataFromShop.Goods[j].ID && goodsDataFromShop.Goods[j].LimitBuyTimes != 0)
								{
									num2++;
									break;
								}
							}
						}
						if (num2 < value.Count)
						{
							flag = true;
							KeyValuePair<int, List<ShopItemTable>> keyValuePair2 = enumerator.Current;
							if (keyValuePair2.Key > num)
							{
								KeyValuePair<int, List<ShopItemTable>> keyValuePair3 = enumerator.Current;
								num = keyValuePair3.Key;
							}
						}
					}
				}
				num += 10;
				if (flag)
				{
					if (num > this.duelTuiJianEquipMaxLevel)
					{
						this.mGoDuelWeapon.CustomActive(false);
						return;
					}
					if (num > this.currLevel)
					{
						this.getDuleWeaponList = DataManager<ShopDataManager>.GetInstance()._ScreenCurrJobDuelWeapons(num);
						this.CreatDuleWeaponItem(this.getDuleWeaponList, 0);
					}
					else
					{
						this.getDuleWeaponList = DataManager<ShopDataManager>.GetInstance()._ScreenCurrJobDuelWeapons(this.currLevel);
						this.CreatDuleWeaponItem(this.getDuleWeaponList, 0);
					}
				}
				else
				{
					this.getDuleWeaponList = DataManager<ShopDataManager>.GetInstance()._ScreenCurrJobDuelWeapons(this.currLevel);
					this.CreatDuleWeaponItem(this.getDuleWeaponList, 0);
				}
			}
		}

		// Token: 0x0600FF9B RID: 65435 RVA: 0x0046D6E0 File Offset: 0x0046BAE0
		private void TryOpenSkilltreeFrame()
		{
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>((int)DataManager<PlayerBaseData>.GetInstance().Level, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			uint num = 0U;
			if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				num = DataManager<PlayerBaseData>.GetInstance().pvpSP;
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page2)
			{
				num = DataManager<PlayerBaseData>.GetInstance().pvpSP2;
			}
			if ((ulong)num >= (ulong)((long)tableItem.SpPvp))
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format(TR.Value("skill_openwaitroom_tips"), new object[0]), delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, SkillLeftType.PVP, string.Empty);
				}, delegate()
				{
				}, 0f, false);
			}
		}

		// Token: 0x0600FF9C RID: 65436 RVA: 0x0046D7B8 File Offset: 0x0046BBB8
		private void CreatDuleWeaponItem(List<ShopItemTable> itemList, int index)
		{
			if (itemList == null || index < 0 || index >= itemList.Count)
			{
				this.mGoDuelWeapon.CustomActive(false);
				return;
			}
			if (this.currLevel > DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv)
			{
				this.mGoDuelWeapon.CustomActive(false);
				return;
			}
			this.selfPkCoin = DataManager<PlayerBaseData>.GetInstance().uiPkCoin;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemList[index].ItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem.ID, 100, 0);
			ComItem comItem = this.mItemRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mItemRoot.gameObject);
				comItem.labLevel.fontSize = 30;
				comItem.transform.SetAsFirstSibling();
			}
			comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.shopItemTable = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(itemList[index].ID, string.Empty, string.Empty);
			if (this.shopItemTable == null)
			{
				return;
			}
			this.mName.text = itemData.GetColorName(string.Empty, false);
			this.mCostSlider.value = this.selfPkCoin / (float)this.shopItemTable.CostNum;
			this.mCostText.text = this.selfPkCoin + "/" + this.shopItemTable.CostNum;
			GameObject gameObject = Utility.FindChild(this.mItemRoot, "EffUI_kegoumai");
			if (this.mCostSlider.value == 1f)
			{
				gameObject.CustomActive(true);
			}
			else
			{
				gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600FF9D RID: 65437 RVA: 0x0046D98C File Offset: 0x0046BD8C
		protected override void _bindExUI()
		{
			this.mGoDuelWeapon = this.mBind.GetGameObject("GoDuelWeapon");
			this.mItemRoot = this.mBind.GetGameObject("ItemRoot");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mCostSlider = this.mBind.GetCom<Slider>("CostSlider");
			this.mCostText = this.mBind.GetCom<Text>("CostText");
			this.mDuelShopBtn = this.mBind.GetCom<Button>("DuelShopBtn");
			this.mDuelShopBtn.onClick.AddListener(new UnityAction(this._onDuelShopBtnButtonClick));
			this.mBtGuildFighter = this.mBind.GetCom<Button>("btGuildFighter");
			this.mBtGuildFighter.onClick.AddListener(new UnityAction(this._onBtGuildFighterButtonClick));
			this.mBt3v3 = this.mBind.GetCom<Button>("bt3v3");
			this.mBt3v3.onClick.AddListener(new UnityAction(this._onBt3v3ButtonClick));
			this.mFairDuel = this.mBind.GetCom<Button>("btFairDuel");
			this.mFairDuel.onClick.AddListener(new UnityAction(this._onBtFairDuelClick));
			this.mCancelGo = this.mBind.GetGameObject("Cancel");
			this.m2V2PointRaceBtn = this.mBind.GetCom<Button>("2V2PointRace");
			this.m2V2PointRaceBtn.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinPk2v2CrossFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.m3V3PointRaceBtn = this.mBind.GetCom<Button>("3V3PointRace");
			this.m3V3PointRaceBtn.SafeSetOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinPK3v3CrossFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.mHonorExpValueLabel = this.mBind.GetCom<Text>("honorExpValueLabel");
		}

		// Token: 0x0600FF9E RID: 65438 RVA: 0x0046DB78 File Offset: 0x0046BF78
		protected override void _unbindExUI()
		{
			this.mGoDuelWeapon = null;
			this.mItemRoot = null;
			this.mName = null;
			this.mCostSlider = null;
			this.mCostText = null;
			this.mDuelShopBtn.onClick.RemoveListener(new UnityAction(this._onDuelShopBtnButtonClick));
			this.mDuelShopBtn = null;
			this.mBtGuildFighter.onClick.RemoveListener(new UnityAction(this._onBtGuildFighterButtonClick));
			this.mBtGuildFighter = null;
			this.mBt3v3.onClick.RemoveListener(new UnityAction(this._onBt3v3ButtonClick));
			this.mBt3v3 = null;
			this.mFairDuel.onClick.RemoveListener(new UnityAction(this._onBtFairDuelClick));
			this.mFairDuel = null;
			this.mCancelGo = null;
			this.m2V2PointRaceBtn = null;
			this.m3V3PointRaceBtn = null;
			this.mHonorExpValueLabel = null;
		}

		// Token: 0x0600FF9F RID: 65439 RVA: 0x0046DC50 File Offset: 0x0046C050
		private void _onDuelShopBtnButtonClick()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(5, 0, 0, -1);
		}

		// Token: 0x0600FFA0 RID: 65440 RVA: 0x0046DC60 File Offset: 0x0046C060
		private void _onBtGuildFighterButtonClick()
		{
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState >= EGuildBattleState.Preparing && guildBattleState <= EGuildBattleState.Firing)
				{
					if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
					{
						GuildMyMainFrame.OpenLinkFrame("10");
					}
					else
					{
						GuildMyMainFrame.OpenLinkFrame("8");
					}
					return;
				}
			}
			else
			{
				this.frameMgr.OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600FFA1 RID: 65441 RVA: 0x0046DCD8 File Offset: 0x0046C0D8
		private void _onBt3v3ButtonClick()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3RoomListFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3RoomListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("PK3V3");
		}

		// Token: 0x0600FFA2 RID: 65442 RVA: 0x0046DD31 File Offset: 0x0046C131
		private void _onBtFairDuelClick()
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelEntranceFrame>(FrameLayer.Middle, this.RoomData, string.Empty);
		}

		// Token: 0x0600FFA3 RID: 65443 RVA: 0x0046DD64 File Offset: 0x0046C164
		private void _OnUpdateFairDuelEntryState(UIEvent uiEvent)
		{
			bool bActive = (bool)uiEvent.Param1;
			this.mFairDuel.CustomActive(bActive);
		}

		// Token: 0x0600FFA4 RID: 65444 RVA: 0x0046DD8C File Offset: 0x0046C18C
		private void Update3V3PointRaceBtn(UIEvent uiEvent)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				this.m3V3PointRaceBtn.CustomActive(false);
				return;
			}
			byte b = (byte)uiEvent.Param1;
			bool bActive = b >= 1 && b < 3;
			this.m3V3PointRaceBtn.CustomActive(bActive);
		}

		// Token: 0x0600FFA5 RID: 65445 RVA: 0x0046DE0C File Offset: 0x0046C20C
		private void Update2V2PointRaceBtn(UIEvent uiEvent)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				this.m2V2PointRaceBtn.CustomActive(false);
				return;
			}
			byte b = (byte)uiEvent.Param1;
			bool bActive = b >= 1 && b < 3;
			this.m2V2PointRaceBtn.CustomActive(bActive);
		}

		// Token: 0x0600FFA6 RID: 65446 RVA: 0x0046DE8C File Offset: 0x0046C28C
		private void OnCountValueChangeChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (string.Equals(a, DataManager<HonorSystemDataManager>.GetInstance().PkHonorExpCounterStr))
			{
				this.UpdateHonorExpValueLabel();
			}
		}

		// Token: 0x0600FFA7 RID: 65447 RVA: 0x0046DED4 File Offset: 0x0046C2D4
		private void UpdateHonorExpValueLabel()
		{
			if (this.mHonorExpValueLabel == null)
			{
				return;
			}
			string thisWeekHonorExpStrInPk = HonorSystemUtility.GetThisWeekHonorExpStrInPk();
			this.mHonorExpValueLabel.text = thisWeekHonorExpStrInPk;
		}

		// Token: 0x0400A119 RID: 41241
		[UIObject("PKRankRoot/Icon")]
		private GameObject m_objPKRankRoot;

		// Token: 0x0400A11A RID: 41242
		[UIObject("PKRankRoot/Promotion")]
		private GameObject m_objPromotionRoot;

		// Token: 0x0400A11B RID: 41243
		[UIObject("PKRankRoot/Promotion/Records/Viewport/Content")]
		private GameObject m_objRecordRoot;

		// Token: 0x0400A11C RID: 41244
		[UIObject("PKRankRoot/Promotion/Records/Viewport/Content/Template")]
		private GameObject m_objRecordTemplate;

		// Token: 0x0400A11D RID: 41245
		[UIControl("PKRankRoot/Promotion/Desc", null, 0)]
		private Text m_labPromotionDesc;

		// Token: 0x0400A11E RID: 41246
		[UIControl("PKRankRoot/CoinDesc", null, 0)]
		private Text m_labCoinDesc;

		// Token: 0x0400A11F RID: 41247
		[UIObject("btPkVideo")]
		private GameObject objPkVideo;

		// Token: 0x0400A120 RID: 41248
		[UIControl("btSeasonAttr/Time", null, 0)]
		private Text m_labSeasonAttrTime;

		// Token: 0x0400A121 RID: 41249
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x0400A122 RID: 41250
		private string fingerPath = "UIFlatten/Prefabs/Pk/DualFinger";

		// Token: 0x0400A123 RID: 41251
		private string EffectPath = "btBegin/GuideEffect";

		// Token: 0x0400A124 RID: 41252
		private PkWaitingRoomData RoomData = new PkWaitingRoomData();

		// Token: 0x0400A125 RID: 41253
		private ComTalk m_miniTalk;

		// Token: 0x0400A126 RID: 41254
		private ComPKRank m_comPKRank;

		// Token: 0x0400A127 RID: 41255
		public float fTimeIntrval;

		// Token: 0x0400A128 RID: 41256
		private bool bIsAddGuide;

		// Token: 0x0400A129 RID: 41257
		private float selfPkCoin;

		// Token: 0x0400A12A RID: 41258
		private int currLevel;

		// Token: 0x0400A12B RID: 41259
		private int currJob;

		// Token: 0x0400A12C RID: 41260
		private int duelTuiJianEquipMaxLevel;

		// Token: 0x0400A12D RID: 41261
		public float fTime;

		// Token: 0x0400A12E RID: 41262
		private ShopItemTable shopItemTable;

		// Token: 0x0400A12F RID: 41263
		public static bool bBeginSeekPlayer;

		// Token: 0x0400A130 RID: 41264
		private DelayCallUnitHandle m_repeatCallAttrTime;

		// Token: 0x0400A131 RID: 41265
		private List<ShopItemTable> getDuleWeaponList = new List<ShopItemTable>();

		// Token: 0x0400A132 RID: 41266
		private int index = 1;

		// Token: 0x0400A133 RID: 41267
		[UIControl("Detail/RedPoint", null, 0)]
		private Image DailyProveRedPoint;

		// Token: 0x0400A134 RID: 41268
		[UIControl("btBegin", null, 0)]
		private Button btBegin;

		// Token: 0x0400A135 RID: 41269
		[UIObject("talk")]
		private GameObject TalkRoot;

		// Token: 0x0400A136 RID: 41270
		[UIControl("btSkill/RedPoint", null, 0)]
		private Image btSkillRedPoint;

		// Token: 0x0400A137 RID: 41271
		[UIControl("btPackage/RedPoint", null, 0)]
		private Image btPackageRedPoint;

		// Token: 0x0400A138 RID: 41272
		[UIControl("ranklist", null, 0)]
		private Button ranklist;

		// Token: 0x0400A139 RID: 41273
		private GameObject mGoDuelWeapon;

		// Token: 0x0400A13A RID: 41274
		private GameObject mItemRoot;

		// Token: 0x0400A13B RID: 41275
		private Text mName;

		// Token: 0x0400A13C RID: 41276
		private Slider mCostSlider;

		// Token: 0x0400A13D RID: 41277
		private Text mCostText;

		// Token: 0x0400A13E RID: 41278
		private Button mDuelShopBtn;

		// Token: 0x0400A13F RID: 41279
		private Button mBtGuildFighter;

		// Token: 0x0400A140 RID: 41280
		private Button mBt3v3;

		// Token: 0x0400A141 RID: 41281
		private Button mFairDuel;

		// Token: 0x0400A142 RID: 41282
		private Button m2V2PointRaceBtn;

		// Token: 0x0400A143 RID: 41283
		private Button m3V3PointRaceBtn;

		// Token: 0x0400A144 RID: 41284
		private GameObject mCancelGo;

		// Token: 0x0400A145 RID: 41285
		private Text mHonorExpValueLabel;
	}
}
