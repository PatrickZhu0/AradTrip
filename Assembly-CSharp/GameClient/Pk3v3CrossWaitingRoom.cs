using System;
using System.Collections.Generic;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x020019C0 RID: 6592
	public class Pk3v3CrossWaitingRoom : ClientFrame
	{
		// Token: 0x060101F8 RID: 66040 RVA: 0x0047CA9E File Offset: 0x0047AE9E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossWaitingRoom";
		}

		// Token: 0x060101F9 RID: 66041 RVA: 0x0047CAA8 File Offset: 0x0047AEA8
		private void SetAwardItem(GameObject goItem, ItemData itemData)
		{
			if (goItem == null)
			{
				return;
			}
			ComItem component = goItem.GetComponent<ComItem>();
			if (component == null)
			{
				return;
			}
			component.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
		}

		// Token: 0x060101FA RID: 66042 RVA: 0x0047CAFC File Offset: 0x0047AEFC
		protected override void _OnOpenFrame()
		{
			this.fTimeAcc = 0f;
			if (this.userData != null)
			{
				this.RoomData = (this.userData as PkWaitingRoomData);
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWarRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ScoreWarRewardTable scoreWarRewardTable = keyValuePair.Value as ScoreWarRewardTable;
					if (scoreWarRewardTable != null)
					{
						if (scoreWarRewardTable.BattleCount == 1 && this.iFirstBattleAwardID == 0)
						{
							this.iFirstBattleAwardID = scoreWarRewardTable.RewardId;
						}
						if (scoreWarRewardTable.BattleCount == 5 && this.iFiveBattleAwardID == 0)
						{
							this.iFiveBattleAwardID = scoreWarRewardTable.RewardId;
						}
						if (scoreWarRewardTable.WinCount == 1 && this.iFirstWinBattleID == 0)
						{
							this.iFirstWinBattleID = scoreWarRewardTable.RewardId;
						}
						if (this.iFirstBattleAwardID > 0 && this.iFirstWinBattleID > 0 && this.iFiveBattleAwardID > 0)
						{
							break;
						}
					}
				}
			}
			this.InitInterface();
			this.BindUIEvent();
			this.OnPk3v3CrossRewardInfoUpdate(null);
			if (this.goMatchOK != null)
			{
				this.goMatchOK.CustomActive(false);
			}
			this.UpdateBeginButton();
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && pkInfo.nCurPkCount >= 5)
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
		}

		// Token: 0x060101FB RID: 66043 RVA: 0x0047CC7C File Offset: 0x0047B07C
		protected override void _OnCloseFrame()
		{
			this.iFirstBattleAwardID = 0;
			this.iFiveBattleAwardID = 0;
			this.iFirstWinBattleID = 0;
			this.fTimeAcc = 0f;
			this.ClearData();
			this.UnBindUIEvent();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3PlayerMenuFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamMainFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamMainMenuFrame>(null, false);
			this.UnInitVoiceChatModule();
		}

		// Token: 0x060101FC RID: 66044 RVA: 0x0047CD10 File Offset: 0x0047B110
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060101FD RID: 66045 RVA: 0x0047CD14 File Offset: 0x0047B114
		private void GetLeftTime(uint nEndTime, uint nNowTime, ref int nLeftDay, ref int nLeftHour, ref int nLeftMin, ref int nLeftSec)
		{
			nLeftDay = 0;
			nLeftHour = 0;
			nLeftMin = 0;
			nLeftSec = 0;
			if (nEndTime <= nNowTime)
			{
				return;
			}
			uint num = nEndTime - nNowTime;
			uint num2 = num / 86400U;
			num -= num2 * 24U * 60U * 60U;
			uint num3 = num / 3600U;
			num -= num3 * 60U * 60U;
			uint num4 = num / 60U;
			num -= num4 * 60U;
			uint num5 = num;
			nLeftDay = (int)num2;
			nLeftHour = (int)num3;
			nLeftMin = (int)num4;
			nLeftSec = (int)num5;
		}

		// Token: 0x060101FE RID: 66046 RVA: 0x0047CD82 File Offset: 0x0047B182
		private void UpdateWarStateTimeLeft()
		{
		}

		// Token: 0x060101FF RID: 66047 RVA: 0x0047CD84 File Offset: 0x0047B184
		protected override void _OnUpdate(float timeElapsed)
		{
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE || scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
			{
				if (this.goScoreWarStateTimeInfo != null)
				{
					this.goScoreWarStateTimeInfo.CustomActive(true);
				}
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				this.GetLeftTime(DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatusEndTime(), DataManager<TimeManager>.GetInstance().GetServerTime(), ref num, ref num2, ref num3, ref num4);
				if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE)
				{
					this.txtTimeInfo.text = string.Format("备战时间 {0}:{1}:{2}", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
				}
				else if (scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
				{
					this.txtTimeInfo.text = string.Format("活动时间 {0}:{1}:{2}", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
				}
			}
			else if (this.goScoreWarStateTimeInfo != null)
			{
				this.goScoreWarStateTimeInfo.CustomActive(false);
			}
		}

		// Token: 0x06010200 RID: 66048 RVA: 0x0047CEB4 File Offset: 0x0047B2B4
		private bool IsGetFirstBattleAward()
		{
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFirstBattleAwardID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010201 RID: 66049 RVA: 0x0047CF04 File Offset: 0x0047B304
		private bool IsGetFiveBattleAward()
		{
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFiveBattleAwardID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010202 RID: 66050 RVA: 0x0047CF54 File Offset: 0x0047B354
		private bool IsGetFirstWinAward()
		{
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			for (int i = 0; i < pkInfo.arrAwardIDs.Count; i++)
			{
				if ((long)this.iFirstWinBattleID == (long)((ulong)pkInfo.arrAwardIDs[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010203 RID: 66051 RVA: 0x0047CFA4 File Offset: 0x0047B3A4
		private void UpdateAwardInfo(int iAwardID, Func<bool> isGet, Func<bool> canGet, Button btnChest, Image goImageGet, GameObject goAni)
		{
			goAni.CustomActive(false);
			if (isGet())
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.interactable = false;
				goImageGet.CustomActive(true);
				btnChest.GetComponent<Image>().raycastTarget = false;
				UIGray component = btnChest.gameObject.GetComponent<UIGray>();
				if (component != null)
				{
					component.SetEnable(true);
				}
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DOPause();
			}
			else if (canGet())
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.onClick.AddListener(delegate()
				{
					SceneScoreWarRewardReq sceneScoreWarRewardReq = new SceneScoreWarRewardReq();
					sceneScoreWarRewardReq.rewardId = (byte)iAwardID;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneScoreWarRewardReq>(ServerType.GATE_SERVER, sceneScoreWarRewardReq);
				});
				btnChest.interactable = true;
				goImageGet.CustomActive(false);
				btnChest.GetComponent<Image>().raycastTarget = true;
				UIGray component2 = btnChest.gameObject.GetComponent<UIGray>();
				if (component2 != null)
				{
					component2.SetEnable(false);
				}
				goAni.CustomActive(true);
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DORestart(false);
			}
			else
			{
				btnChest.onClick.RemoveAllListeners();
				btnChest.onClick.AddListener(delegate()
				{
					AwardRankItem awardRankItem = new AwardRankItem();
					ScoreWarRewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScoreWarRewardTable>(iAwardID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						for (int i = 0; i < tableItem.ItemReward.Count; i++)
						{
							string text = tableItem.ItemRewardArray(i);
							string[] array = text.Split(new char[]
							{
								'_'
							});
							if (array.Length >= 2)
							{
								int tableId = int.Parse(array[0]);
								int count = int.Parse(array[1]);
								ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
								itemData.Count = count;
								if (itemData != null)
								{
									DataManager<ItemTipManager>.GetInstance().CloseAll();
									DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
								}
							}
						}
					}
				});
				btnChest.interactable = true;
				goImageGet.CustomActive(false);
				btnChest.GetComponent<Image>().raycastTarget = true;
				UIGray component3 = btnChest.gameObject.GetComponent<UIGray>();
				if (component3 != null)
				{
					component3.SetEnable(false);
				}
				btnChest.gameObject.GetComponent<DOTweenAnimation>().DOPause();
			}
		}

		// Token: 0x06010204 RID: 66052 RVA: 0x0047D130 File Offset: 0x0047B530
		private void UpdateFirstBattleAwardChest(UIEvent uiEvent)
		{
			if (this.IsGetFirstBattleAward())
			{
				this.gofirstBattleAward.CustomActive(false);
			}
			else
			{
				this.gofirstBattleAward.CustomActive(true);
			}
			this.UpdateAwardInfo(this.iFirstBattleAwardID, new Func<bool>(this.IsGetFirstBattleAward), delegate
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nCurPkCount >= 1;
			}, this.btnFirstBattleChest, this.goFirstBattleGet, this.mBind.GetGameObject("goFirstBattleAni"));
		}

		// Token: 0x06010205 RID: 66053 RVA: 0x0047D1B8 File Offset: 0x0047B5B8
		private void UpdateFiveBattleAwardChest(UIEvent uiEvent)
		{
			if (!this.IsGetFirstBattleAward())
			{
				this.gofiveBattleAward.CustomActive(false);
				return;
			}
			this.gofiveBattleAward.CustomActive(true);
			this.UpdateAwardInfo(this.iFiveBattleAwardID, new Func<bool>(this.IsGetFiveBattleAward), delegate
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nCurPkCount == 5;
			}, this.btnFiveBattleChest, this.goFiveBattleGet, this.mBind.GetGameObject("goFiveBattleAni"));
		}

		// Token: 0x06010206 RID: 66054 RVA: 0x0047D240 File Offset: 0x0047B640
		private void UpdateFirstWinAwardChest(UIEvent uiEvent)
		{
			this.UpdateAwardInfo(this.iFirstWinBattleID, new Func<bool>(this.IsGetFirstWinAward), delegate
			{
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				return pkInfo.nWinCount >= 1;
			}, this.btnFirstWinChest, this.goFirstWinGet, this.mBind.GetGameObject("goFirstWinAni"));
		}

		// Token: 0x06010207 RID: 66055 RVA: 0x0047D2A0 File Offset: 0x0047B6A0
		private void ClearData()
		{
			this.RoomData.Clear();
			this.SelfGroup = RoomSlotGroup.ROOM_SLOT_GROUP_INVALID;
			this.bSelfIsRoomOwner = false;
			this.bMatchLock = false;
			this.bIsMatching = false;
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				this.LeftList[i] = null;
			}
			for (int j = 0; j < this.RightList.Length; j++)
			{
				this.RightList[j] = null;
			}
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			this.m_iCurAwardID = 0;
			this.bHasTeam = false;
			this.UnInitVoiceChat();
		}

		// Token: 0x06010208 RID: 66056 RVA: 0x0047D34C File Offset: 0x0047B74C
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3KickOut, new ClientEventSystem.UIEventHandler(this.OnPk3v3KickOut));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Set3v3RoomName, new ClientEventSystem.UIEventHandler(this.OnSetName));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Set3v3RoomPassword, new ClientEventSystem.UIEventHandler(this.onSetPassword));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CrossPkAwardInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3CrossRewardInfoUpdate));
		}

		// Token: 0x06010209 RID: 66057 RVA: 0x0047D484 File Offset: 0x0047B884
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3KickOut, new ClientEventSystem.UIEventHandler(this.OnPk3v3KickOut));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Set3v3RoomName, new ClientEventSystem.UIEventHandler(this.OnSetName));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Set3v3RoomPassword, new ClientEventSystem.UIEventHandler(this.onSetPassword));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CrossPkAwardInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3CrossRewardInfoUpdate));
		}

		// Token: 0x0601020A RID: 66058 RVA: 0x0047D5BC File Offset: 0x0047B9BC
		private void OnPk3v3CrossRewardInfoUpdate(UIEvent iEvent)
		{
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo == null)
			{
				return;
			}
			this.txtPkCountInfo.text = string.Format("剩余比赛次数: {0}/{1}", (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT - (ulong)((long)pkInfo.nCurPkCount)), 5);
			this.UpdateFirstBattleAwardChest(null);
			this.UpdateFiveBattleAwardChest(null);
			this.UpdateFirstWinAwardChest(null);
			this.m_iCurAwardID = 0;
			if (pkInfo.nCurPkCount >= 5)
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
		}

		// Token: 0x0601020B RID: 66059 RVA: 0x0047D649 File Offset: 0x0047BA49
		private void OnPk3v3RoomInfoUpdate(UIEvent iEvent)
		{
			this.UpdateTeamMainMenuFrame();
		}

		// Token: 0x0601020C RID: 66060 RVA: 0x0047D651 File Offset: 0x0047BA51
		private void OnPk3v3RoomSimpleInfoUpdate(UIEvent iEvent)
		{
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
		}

		// Token: 0x0601020D RID: 66061 RVA: 0x0047D65F File Offset: 0x0047BA5F
		private void OnPk3v3RoomSlotInfoUpdate(UIEvent iEvent)
		{
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
		}

		// Token: 0x0601020E RID: 66062 RVA: 0x0047D66D File Offset: 0x0047BA6D
		private void OnPk3v3KickOut(UIEvent iEvent)
		{
			DataManager<Pk3v3CrossDataManager>.GetInstance().ClearRoomInfo();
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
			this.frameMgr.CloseFrame<Pk3v3CrossMyTeamFrame>(null, false);
		}

		// Token: 0x0601020F RID: 66063 RVA: 0x0047D694 File Offset: 0x0047BA94
		private void OnBeginMatch(UIEvent iEvent)
		{
			this.bIsMatching = true;
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
			if (roomInfo == null)
			{
				return;
			}
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.Pk3v3Cross;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
			if (roomInfo.roomSimpleInfo != null && roomInfo.roomSimpleInfo.id > 0U)
			{
				if (roomInfo.roomSimpleInfo.roomType == 3)
				{
					this.ShowCancelText(roomInfo);
					this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomStatus == 3);
				}
				if (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					bool flag = roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3;
				}
				this.mBtBegin.gameObject.CustomActive(true);
			}
			else
			{
				this.mBtMatchText.text = "取消匹配";
			}
		}

		// Token: 0x06010210 RID: 66064 RVA: 0x0047D7A1 File Offset: 0x0047BBA1
		private void OnBeginMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x06010211 RID: 66065 RVA: 0x0047D7AC File Offset: 0x0047BBAC
		private void OnCancelMatch(UIEvent iEvent)
		{
			this.bIsMatching = false;
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
			if (roomInfo == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			if (roomInfo.roomSimpleInfo != null && roomInfo.roomSimpleInfo.id > 0U)
			{
				if (roomInfo.roomSimpleInfo.roomType == 3)
				{
					this.ShowBeginText(roomInfo);
					this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomStatus == 3);
				}
				if (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					bool flag = roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3;
				}
				this.mBtBegin.gameObject.CustomActive(true);
			}
			else
			{
				this.mBtMatchText.text = "开始匹配";
			}
		}

		// Token: 0x06010212 RID: 66066 RVA: 0x0047D8A6 File Offset: 0x0047BCA6
		private void OnCancelMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x06010213 RID: 66067 RVA: 0x0047D8B0 File Offset: 0x0047BCB0
		private void OnSetName(UIEvent iEvent)
		{
			string text = (string)iEvent.Param1;
			if (text != null && text != string.Empty)
			{
				this.mRoomName.text = text;
			}
			this.mRoomName.text = "3v3积分争霸赛";
		}

		// Token: 0x06010214 RID: 66068 RVA: 0x0047D8FB File Offset: 0x0047BCFB
		private void onSetPassword(UIEvent iEvent)
		{
			this.SetRoomPassword();
		}

		// Token: 0x06010215 RID: 66069 RVA: 0x0047D903 File Offset: 0x0047BD03
		private void OnClickLeftIcon(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryOpenPlayerMenuFrame(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x06010216 RID: 66070 RVA: 0x0047D91D File Offset: 0x0047BD1D
		private void OnClickLeftChangePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryChangePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x06010217 RID: 66071 RVA: 0x0047D937 File Offset: 0x0047BD37
		private void OnClickLeftClosePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryClosePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x06010218 RID: 66072 RVA: 0x0047D951 File Offset: 0x0047BD51
		private void OnClickRightIcon(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryOpenPlayerMenuFrame(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x06010219 RID: 66073 RVA: 0x0047D96B File Offset: 0x0047BD6B
		private void OnClickRightChangePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryChangePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x0601021A RID: 66074 RVA: 0x0047D985 File Offset: 0x0047BD85
		private void OnClickRightClosePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryClosePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x0601021B RID: 66075 RVA: 0x0047D99F File Offset: 0x0047BD9F
		private void InitInterface()
		{
			this.InitPlayerList();
			this._InitTalk();
			this.InitVoiceChat();
			this.InitVoiceChatModule();
		}

		// Token: 0x0601021C RID: 66076 RVA: 0x0047D9BC File Offset: 0x0047BDBC
		private void InitPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitPlayerList]");
				return;
			}
			this.ShowBeginText(roomInfo);
			this.CheckSelfInfo();
			this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomType == 1);
			this.mRankBg.CustomActive(roomInfo.roomSimpleInfo.roomType == 2);
			this.mAmuseBg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 1);
			this.mMatchTypeImg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 2);
			this.mAmuseTypeImg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 1);
			this.InitLeftPlayerList();
			this.InitRightPlayerList();
			this.mRoomName.text = roomInfo.roomSimpleInfo.name;
			this.mRoomId.text = roomInfo.roomSimpleInfo.id.ToString();
			this.SetRoomPassword();
			this.mRoomName.text = "3v3积分争霸赛";
		}

		// Token: 0x0601021D RID: 66077 RVA: 0x0047DAD7 File Offset: 0x0047BED7
		private void _InitTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkRoot);
		}

		// Token: 0x0601021E RID: 66078 RVA: 0x0047DAEC File Offset: 0x0047BEEC
		private void InitLeftPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitLeftPlayerList]");
				return;
			}
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.PlayerInfoElePath, true, 0U);
				if (gameObject == null)
				{
					Logger.LogError("can't create left obj in pk3v3WaitinRoom");
					return;
				}
				gameObject.transform.SetParent(this.mLeft.transform, false);
				this.LeftList[i] = gameObject;
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
			}
		}

		// Token: 0x0601021F RID: 66079 RVA: 0x0047DBA0 File Offset: 0x0047BFA0
		private void InitRightPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitRightPlayerList]");
				return;
			}
			if (roomInfo.roomSimpleInfo.roomType == 2)
			{
				return;
			}
			for (int i = 0; i < this.RightList.Length; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.PlayerInfoElePath, true, 0U);
				if (gameObject == null)
				{
					Logger.LogError("can't create right obj in pk3v3WaitinRoom");
					return;
				}
				gameObject.transform.SetParent(this.mRight.transform, false);
				this.RightList[i] = gameObject;
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
			}
		}

		// Token: 0x06010220 RID: 66080 RVA: 0x0047DC68 File Offset: 0x0047C068
		private void UpdateTeamMainMenuFrame()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamMainMenuFrame>(null, false);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamMainMenuFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(Pk3v3CrossTeamMainMenuFrame)).GetFrame().CustomActive(true);
			}
		}

		// Token: 0x06010221 RID: 66081 RVA: 0x0047DCC8 File Offset: 0x0047C0C8
		private void UpdateBeginButton()
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			this.mBeginGray.SetEnable(false);
			this.mBtBegin.interactable = true;
			if (scoreWarStatus != ScoreWarStatus.SWS_BATTLE || (roomInfo != null && roomInfo.roomSimpleInfo.id > 0U && roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID))
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
			this.mBtBegin.CustomActive(true);
			if (!this.bHasTeam && DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				this.bHasTeam = true;
				this.InitVoiceChat();
			}
			else if (this.bHasTeam && !DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				this.bHasTeam = false;
				this.UnInitVoiceChat();
			}
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && pkInfo.nCurPkCount >= 5)
			{
				this.mBeginGray.SetEnable(true);
				this.mBtBegin.interactable = false;
			}
		}

		// Token: 0x06010222 RID: 66082 RVA: 0x0047DDE8 File Offset: 0x0047C1E8
		private void UpdatePlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [UpdatePlayerList]");
				return;
			}
			this.CheckSelfInfo();
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				ComCommonBind component = this.LeftList[i].GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
			}
			if (roomInfo.roomSimpleInfo.roomType == 1)
			{
				for (int j = 0; j < this.RightList.Length; j++)
				{
					ComCommonBind component2 = this.RightList[j].GetComponent<ComCommonBind>();
					if (component2 == null)
					{
						Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
						return;
					}
					this.UpdatePlayerBaseInfo(component2, roomInfo, j, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
				}
			}
			if (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				bool flag = roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3;
			}
			this.mBtBegin.gameObject.CustomActive(true);
			this.mRoomName.text = roomInfo.roomSimpleInfo.name;
			this.mRoomName.text = "3v3积分争霸赛";
		}

		// Token: 0x06010223 RID: 66083 RVA: 0x0047DF3C File Offset: 0x0047C33C
		private void UpdatePlayerBaseInfo(ComCommonBind combind, RoomInfo roomInfo, int iIndex, RoomSlotGroup group)
		{
			Image com = combind.GetCom<Image>("Icon");
			Text com2 = combind.GetCom<Text>("Name");
			Text com3 = combind.GetCom<Text>("Lv");
			Image com4 = combind.GetCom<Image>("LvBack");
			Image com5 = combind.GetCom<Image>("RoomOwner");
			Image com6 = combind.GetCom<Image>("Lock");
			GameObject gameObject = combind.GetGameObject("What");
			UIGray com7 = combind.GetCom<UIGray>("IconGray");
			UIGray com8 = combind.GetCom<UIGray>("btIconGray");
			Button com9 = combind.GetCom<Button>("btIcon");
			Button com10 = combind.GetCom<Button>("ChangePos");
			Button com11 = combind.GetCom<Button>("ClosePos");
			bool flag = false;
			bool bActive = false;
			bool flag2 = false;
			bool enable = false;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)group)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIndex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == roomInfo.roomSimpleInfo.ownerId)
						{
							bActive = true;
						}
						if (roomInfo.roomSlotInfos[i].status == 2)
						{
							flag2 = true;
						}
						else if (roomInfo.roomSlotInfos[i].status == 4)
						{
							enable = true;
						}
						if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
						{
						}
						if (roomInfo.roomSlotInfos[i].playerId != 0UL)
						{
							flag = true;
							this.LoadSprite(ref com, (int)roomInfo.roomSlotInfos[i].playerOccu);
							com3.text = roomInfo.roomSlotInfos[i].playerLevel.ToString();
							com2.text = roomInfo.roomSlotInfos[i].playerName;
						}
						break;
					}
				}
			}
			com.gameObject.CustomActive(flag);
			com2.gameObject.CustomActive(flag);
			com4.gameObject.CustomActive(flag);
			com5.gameObject.CustomActive(bActive);
			com6.gameObject.CustomActive(flag2);
			com7.SetEnable(enable);
			com8.SetEnable(enable);
			gameObject.gameObject.CustomActive(group == RoomSlotGroup.ROOM_SLOT_GROUP_BLUE && roomInfo.roomSimpleInfo.roomType == 2);
			com10.gameObject.CustomActive(!flag && !flag2 && !this.bSelfIsRoomOwner);
			com11.gameObject.CustomActive(false);
			com9.onClick.RemoveAllListeners();
			int iIdex = iIndex;
			com10.onClick.RemoveAllListeners();
			int iIdx = iIndex;
			com11.onClick.RemoveAllListeners();
			int idx = iIndex;
			if (group == RoomSlotGroup.ROOM_SLOT_GROUP_RED)
			{
				com9.onClick.AddListener(delegate()
				{
					this.OnClickLeftIcon(iIdex);
				});
				com10.onClick.AddListener(delegate()
				{
					this.OnClickLeftChangePos(iIdx);
				});
				com11.onClick.AddListener(delegate()
				{
					this.OnClickLeftClosePos(idx);
				});
			}
			else if (group == RoomSlotGroup.ROOM_SLOT_GROUP_BLUE)
			{
				com9.onClick.AddListener(delegate()
				{
					this.OnClickRightIcon(iIdex);
				});
				com10.onClick.AddListener(delegate()
				{
					this.OnClickRightChangePos(iIdx);
				});
				com11.onClick.AddListener(delegate()
				{
					this.OnClickRightClosePos(idx);
				});
			}
		}

		// Token: 0x06010224 RID: 66084 RVA: 0x0047E2B4 File Offset: 0x0047C6B4
		private void CheckSelfInfo()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			this.bSelfIsRoomOwner = (roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.SelfGroup = (RoomSlotGroup)roomInfo.roomSlotInfos[i].group;
					break;
				}
			}
		}

		// Token: 0x06010225 RID: 66085 RVA: 0x0047E340 File Offset: 0x0047C740
		private void TryOpenPlayerMenuFrame(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			RoomSlotInfo roomSlotInfo = null;
			bool flag = false;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							flag = true;
							break;
						}
						roomSlotInfo = roomInfo.roomSlotInfos[i];
						break;
					}
				}
			}
			if (roomSlotInfo == null)
			{
				return;
			}
			bool flag2 = false;
			if (roomSlotInfo.status == 2)
			{
				if (this.bSelfIsRoomOwner)
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag2)
			{
				return;
			}
			if (flag)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId && roomSlotInfo.playerId == 0UL)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3PlayerMenuFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3PlayerMenuFrame>(null, false);
			}
			else if (this.bSelfIsRoomOwner && roomSlotInfo.status == 2)
			{
				DataManager<Pk3v3DataManager>.GetInstance().SendClosePosReq(roomSlotInfo.group, roomSlotInfo.index);
			}
			else
			{
				Pk3v3PlayerMenuFrame pk3v3PlayerMenuFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3PlayerMenuFrame>(FrameLayer.Middle, roomSlotInfo, string.Empty) as Pk3v3PlayerMenuFrame;
				if (slotGroup == RoomSlotGroup.ROOM_SLOT_GROUP_RED)
				{
					pk3v3PlayerMenuFrame.SetPosition(this.LeftList[iIdex].GetComponent<RectTransform>().position);
				}
				else
				{
					pk3v3PlayerMenuFrame.SetPosition(this.RightList[iIdex].GetComponent<RectTransform>().position);
				}
			}
		}

		// Token: 0x06010226 RID: 66086 RVA: 0x0047E4E4 File Offset: 0x0047C8E4
		private void TryChangePos(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == 0UL)
						{
							if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
							{
							}
							DataManager<Pk3v3DataManager>.GetInstance().SendPk3v3ChangePosReq(roomInfo.roomSimpleInfo.id, roomInfo.roomSlotInfos[i]);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06010227 RID: 66087 RVA: 0x0047E5A4 File Offset: 0x0047C9A4
		private void TryClosePos(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == 0UL)
						{
							if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
							{
								DataManager<Pk3v3DataManager>.GetInstance().SendClosePosReq(roomInfo.roomSlotInfos[i].group, roomInfo.roomSlotInfos[i].index);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06010228 RID: 66088 RVA: 0x0047E688 File Offset: 0x0047CA88
		private void LoadSprite(ref Image Icon, int Occu)
		{
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(Occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					text = tableItem2.IconPath;
				}
			}
			if (text != string.Empty)
			{
				ETCImageLoader.LoadSprite(ref Icon, text, true);
			}
		}

		// Token: 0x06010229 RID: 66089 RVA: 0x0047E6F8 File Offset: 0x0047CAF8
		private void SwitchSceneToTown()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town from Pk3v3WaitingRoom");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.RoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.RoomData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<Pk3v3CrossWaitingRoom>(this, false);
		}

		// Token: 0x0601022A RID: 66090 RVA: 0x0047E77C File Offset: 0x0047CB7C
		private void SetRoomPassword()
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitPlayerList]");
				return;
			}
			if (roomInfo.roomSimpleInfo.isPassword > 0 && roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.SetActiveRoomPassword(true);
			}
			else
			{
				this.SetActiveRoomPassword(false);
			}
		}

		// Token: 0x0601022B RID: 66091 RVA: 0x0047E7E3 File Offset: 0x0047CBE3
		private void SetActiveRoomPassword(bool isOpen)
		{
			if (isOpen)
			{
				this.mRoomPasswordGO.CustomActive(true);
				this.mRoomPasswordText.text = DataManager<Pk3v3CrossDataManager>.GetInstance().PassWord;
			}
			else
			{
				this.mRoomPasswordGO.CustomActive(false);
			}
		}

		// Token: 0x0601022C RID: 66092 RVA: 0x0047E81D File Offset: 0x0047CC1D
		[MessageHandle(508101U, false, 0)]
		private void OnWorldSyncScoreWarInfo(MsgDATA msg)
		{
		}

		// Token: 0x0601022D RID: 66093 RVA: 0x0047E820 File Offset: 0x0047CC20
		[MessageHandle(607818U, false, 0)]
		private void OnQuitRoomRes(MsgDATA msg)
		{
			WorldQuitRoomRes worldQuitRoomRes = new WorldQuitRoomRes();
			worldQuitRoomRes.decode(msg.bytes);
			if (worldQuitRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldQuitRoomRes.result, string.Empty);
			}
			DataManager<Pk3v3CrossDataManager>.GetInstance().ClearRoomInfo();
			this.UpdateTeamMainMenuFrame();
			this.UpdateBeginButton();
			this.frameMgr.CloseFrame<Pk3v3CrossMyTeamFrame>(null, false);
		}

		// Token: 0x0601022E RID: 66094 RVA: 0x0047E880 File Offset: 0x0047CC80
		private void SendQuitRoomReq()
		{
			WorldQuitRoomReq cmd = new WorldQuitRoomReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQuitRoomReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0601022F RID: 66095 RVA: 0x0047E8A4 File Offset: 0x0047CCA4
		private void SendBeginGameReq()
		{
			WorldRoomBattleStartReq cmd = new WorldRoomBattleStartReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleStartReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010230 RID: 66096 RVA: 0x0047E8C8 File Offset: 0x0047CCC8
		private void SendCancelGameReq()
		{
			WorldRoomBattleCancelReq cmd = new WorldRoomBattleCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010231 RID: 66097 RVA: 0x0047E8EC File Offset: 0x0047CCEC
		private void SendBeginOnePersonMatchGameReq()
		{
			WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
			worldMatchStartReq.type = 9;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
		}

		// Token: 0x06010232 RID: 66098 RVA: 0x0047E918 File Offset: 0x0047CD18
		private void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010233 RID: 66099 RVA: 0x0047E93A File Offset: 0x0047CD3A
		private void ShowBeginText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1)
			{
				this.mBtMatchText.text = "开始决斗";
			}
			else
			{
				this.mBtMatchText.text = "开始匹配";
			}
		}

		// Token: 0x06010234 RID: 66100 RVA: 0x0047E972 File Offset: 0x0047CD72
		private void ShowCancelText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1)
			{
				this.mBtMatchText.text = "取消决斗";
			}
			else
			{
				this.mBtMatchText.text = "取消匹配";
			}
		}

		// Token: 0x06010235 RID: 66101 RVA: 0x0047E9AC File Offset: 0x0047CDAC
		private void InitVoiceChat()
		{
			bool flag = Singleton<PluginManager>.instance.OpenTalkRealIn3v3Room;
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				flag = false;
			}
			if (this.mPvp3v3MicRoomBtn != null)
			{
				this.mPvp3v3MicRoomBtn.gameObject.CustomActive(flag);
				this.ChangeMicBtnStatus(false);
			}
			if (this.mPvp3v3PlayerBtn != null)
			{
				this.mPvp3v3PlayerBtn.gameObject.CustomActive(flag);
				this.ChangePlayerBtnStatus(false);
			}
			if (!flag)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().AddRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
			string text = this.TryGetVoiceSDKChannalId();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().JoinChannel(text, DataManager<PlayerBaseData>.GetInstance().RoleID + string.Empty, ClientApplication.playerinfo.openuid + string.Empty, ClientApplication.playerinfo.token + string.Empty);
		}

		// Token: 0x06010236 RID: 66102 RVA: 0x0047EAC8 File Offset: 0x0047CEC8
		private void UnInitVoiceChat()
		{
			if (!Singleton<PluginManager>.instance.OpenTalkRealIn3v3Room)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
			Singleton<SDKVoiceManager>.GetInstance().RecoverGameVolumnInTalkVoice();
			Singleton<SDKVoiceManager>.GetInstance().LeaveAllChannel();
			Singleton<SDKVoiceManager>.GetInstance().RemoveRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
			this.mPvp3v3MicRoomBtn.CustomActive(false);
			this.mPvp3v3PlayerBtn.CustomActive(false);
		}

		// Token: 0x06010237 RID: 66103 RVA: 0x0047EB60 File Offset: 0x0047CF60
		private string TryGetVoiceSDKChannalId()
		{
			string empty = string.Empty;
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return empty;
			}
			uint id = ClientApplication.adminServer.id;
			int length = roomInfo.roomSimpleInfo.id.ToString().Length;
			if (length <= 0)
			{
				return empty;
			}
			return (id * Math.Pow(10.0, (double)length) + roomInfo.roomSimpleInfo.id).ToString();
		}

		// Token: 0x06010238 RID: 66104 RVA: 0x0047EBE9 File Offset: 0x0047CFE9
		private void OnJoinChannelSucc()
		{
			Singleton<SDKVoiceManager>.GetInstance().ResetRealTalkVoiceParams();
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().OpenRealPlayer();
		}

		// Token: 0x06010239 RID: 66105 RVA: 0x0047EC09 File Offset: 0x0047D009
		private void OnVoiceSDKMicOn(bool isOn)
		{
			this.ChangeMicBtnStatus(isOn);
			if (isOn)
			{
				Singleton<SDKVoiceManager>.GetInstance().CutGameVolumnInTalkVoice();
			}
		}

		// Token: 0x0601023A RID: 66106 RVA: 0x0047EC22 File Offset: 0x0047D022
		private void OnVoiceSDKPlayerOn(bool isOn)
		{
			this.ChangePlayerBtnStatus(isOn);
		}

		// Token: 0x0601023B RID: 66107 RVA: 0x0047EC2C File Offset: 0x0047D02C
		private bool GetVoiceDeviceIsOn()
		{
			bool flag = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn();
			bool flag2 = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealPlayerOn();
			return flag || flag2;
		}

		// Token: 0x0601023C RID: 66108 RVA: 0x0047EC5C File Offset: 0x0047D05C
		private void ChangeMicBtnStatus(bool isMicOn)
		{
			if (this.mPvp3v3MicRoomBtnClose != null)
			{
				this.mPvp3v3MicRoomBtnClose.gameObject.CustomActive(!isMicOn);
			}
			if (this.mPvp3v3MicRoomBtnBg != null)
			{
				this.mPvp3v3MicRoomBtnBg.enabled = isMicOn;
			}
		}

		// Token: 0x0601023D RID: 66109 RVA: 0x0047ECAC File Offset: 0x0047D0AC
		private void ChangePlayerBtnStatus(bool isPlayerOpen)
		{
			if (this.mPvp3v3PlayerBtnClose != null)
			{
				this.mPvp3v3PlayerBtnClose.gameObject.CustomActive(!isPlayerOpen);
			}
			if (this.mPvp3v3PlayerBtnBg != null)
			{
				this.mPvp3v3PlayerBtnBg.enabled = isPlayerOpen;
			}
		}

		// Token: 0x0601023E RID: 66110 RVA: 0x0047ECFC File Offset: 0x0047D0FC
		[UIEventHandle("btnBag")]
		private void _OnClickOpenBagFrame()
		{
			if (this.bIsMatching || this.frameMgr.IsFrameOpen<PkSeekWaiting>(null) || DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("正在匹配，无法进行该操作", null, string.Empty, false);
				return;
			}
			this.frameMgr.OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601023F RID: 66111 RVA: 0x0047ED5C File Offset: 0x0047D15C
		[UIEventHandle("btnSkill")]
		private void _OnClickOpenSkillFrame()
		{
			if (this.bIsMatching || this.frameMgr.IsFrameOpen<PkSeekWaiting>(null) || DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("正在匹配，无法进行该操作", null, string.Empty, false);
				return;
			}
			this.frameMgr.OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010240 RID: 66112 RVA: 0x0047EDB9 File Offset: 0x0047D1B9
		[UIEventHandle("btnTeamList")]
		private void _OnClickOpenTeamListFrame()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				this.frameMgr.OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				this.frameMgr.OpenFrame<Pk3v3CrossTeamListFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x06010241 RID: 66113 RVA: 0x0047EDF5 File Offset: 0x0047D1F5
		[UIEventHandle("btnRank")]
		private void _OnClickOpenRankFrame()
		{
			this.frameMgr.OpenFrame<Pk3v3CrossRankListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010242 RID: 66114 RVA: 0x0047EE0A File Offset: 0x0047D20A
		[UIEventHandle("GetAward/btnGetAward")]
		private void _OnClickGetPkAward()
		{
			this.SendGetPkAward();
		}

		// Token: 0x06010243 RID: 66115 RVA: 0x0047EE14 File Offset: 0x0047D214
		private void SendGetPkAward()
		{
			SceneScoreWarRewardReq sceneScoreWarRewardReq = new SceneScoreWarRewardReq();
			sceneScoreWarRewardReq.rewardId = (byte)this.m_iCurAwardID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneScoreWarRewardReq>(ServerType.GATE_SERVER, sceneScoreWarRewardReq);
		}

		// Token: 0x06010244 RID: 66116 RVA: 0x0047EE44 File Offset: 0x0047D244
		[MessageHandle(508104U, false, 0)]
		private void OnGetPkAwardRes(MsgDATA msg)
		{
			SceneScoreWarRewardRes sceneScoreWarRewardRes = new SceneScoreWarRewardRes();
			sceneScoreWarRewardRes.decode(msg.bytes);
			if (sceneScoreWarRewardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneScoreWarRewardRes.result, string.Empty);
			}
		}

		// Token: 0x06010245 RID: 66117 RVA: 0x0047EE80 File Offset: 0x0047D280
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtMenu = this.mBind.GetCom<Button>("btMenu");
			this.mBtMenu.onClick.AddListener(new UnityAction(this._onBtMenuButtonClick));
			this.mBtInviteFriends = this.mBind.GetCom<Button>("btInviteFriends");
			this.mBtInviteFriends.onClick.AddListener(new UnityAction(this._onBtInviteFriendsButtonClick));
			this.mBtBegin = this.mBind.GetCom<Button>("btBegin");
			this.mBtBegin.onClick.AddListener(new UnityAction(this._onBtBeginButtonClick));
			this.mTalkRoot = this.mBind.GetGameObject("TalkRoot");
			this.mBtSetting = this.mBind.GetCom<Button>("btSetting");
			this.mBtSetting.onClick.AddListener(new UnityAction(this._onBtSettingButtonClick));
			this.mLeft = this.mBind.GetGameObject("left");
			this.mRight = this.mBind.GetGameObject("right");
			this.mRoomName = this.mBind.GetCom<Text>("RoomName");
			this.mRoomId = this.mBind.GetCom<Text>("RoomId");
			this.mMatchTypeImg = this.mBind.GetCom<Image>("MatchTypeImg");
			this.mAmuseTypeImg = this.mBind.GetCom<Image>("AmuseTypeImg");
			this.mBtMatchText = this.mBind.GetCom<Text>("btMatchText");
			this.mRankBg = this.mBind.GetGameObject("RankBg");
			this.mBtStartImage = this.mBind.GetCom<Image>("btStartImage");
			this.mAmuseBg = this.mBind.GetGameObject("AmuseBg");
			this.mRoomPasswordText = this.mBind.GetCom<Text>("RoomPasswordText");
			this.mRoomPasswordGO = this.mBind.GetGameObject("RoomPasswordGO");
			this.mPvp3v3PlayerBtn = this.mBind.GetCom<Button>("pvp3v3PlayerBtn");
			this.mPvp3v3PlayerBtn.onClick.AddListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtnBg = this.mBind.GetCom<Image>("pvp3v3PlayerBtnBg");
			this.mPvp3v3PlayerBtnClose = this.mBind.GetCom<Image>("pvp3v3PlayerBtnClose");
			this.mPvp3v3MicRoomBtn = this.mBind.GetCom<Button>("pvp3v3MicRoomBtn");
			this.mPvp3v3MicRoomBtn.onClick.AddListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtnBg = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnBg");
			this.mPvp3v3MicRoomBtnClose = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnClose");
			this.txtPkCountInfo = this.mBind.GetCom<Text>("PkCountInfo");
			this.goBattleTimeState = this.mBind.GetGameObject("goBattleTimeState");
			this.goScoreWarStateTimeInfo = this.mBind.GetGameObject("goScoreWarStateTimeInfo");
			this.txtTimeInfo = this.mBind.GetCom<Text>("txtTimeInfo");
			for (int i = 0; i < 6; i++)
			{
				Text com = this.mBind.GetCom<Text>(string.Format("txtTime{0}", i));
				if (com != null)
				{
					this.arrNumbers.Add(com);
				}
			}
			this.btnFirstBattleChest = this.mBind.GetCom<Button>("btnFirstBattleChest");
			this.btnFirstWinChest = this.mBind.GetCom<Button>("btnFirstWinChest");
			this.btnFiveBattleChest = this.mBind.GetCom<Button>("btnFiveBattleChest");
			this.goFirstBattleGet = this.mBind.GetCom<Image>("goFirstBattleGet");
			this.goFiveBattleGet = this.mBind.GetCom<Image>("goFiveBattleGet");
			this.goFirstWinGet = this.mBind.GetCom<Image>("goFirstWinGet");
			this.gofiveBattleAward = this.mBind.GetGameObject("gofiveBattleAward");
			this.gofirstBattleAward = this.mBind.GetGameObject("gofirstBattleAward");
			this.goMatchOK = this.mBind.GetGameObject("goMatchOK");
			this.mBeginGray = this.mBind.GetCom<UIGray>("btnBeginGray");
			DOTweenAnimation com2 = this.mBind.GetCom<DOTweenAnimation>("firstWinDotween");
			this.mTeamVoiceBtn = this.mBind.GetCom<VoiceInputBtn>("teamVoiceBtn");
			this.mTeamVoiceBtnGo = this.mBind.GetGameObject("teamVoiceBtnGo");
		}

		// Token: 0x06010246 RID: 66118 RVA: 0x0047F318 File Offset: 0x0047D718
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtMenu.onClick.RemoveListener(new UnityAction(this._onBtMenuButtonClick));
			this.mBtMenu = null;
			this.mBtInviteFriends.onClick.RemoveListener(new UnityAction(this._onBtInviteFriendsButtonClick));
			this.mBtInviteFriends = null;
			this.mBtBegin.onClick.RemoveListener(new UnityAction(this._onBtBeginButtonClick));
			this.mBtBegin = null;
			this.mTalkRoot = null;
			this.mBtSetting.onClick.RemoveListener(new UnityAction(this._onBtSettingButtonClick));
			this.mBtSetting = null;
			this.mLeft = null;
			this.mRight = null;
			this.mRoomName = null;
			this.mRoomId = null;
			this.mMatchTypeImg = null;
			this.mAmuseTypeImg = null;
			this.mBtMatchText = null;
			this.mRankBg = null;
			this.mBtStartImage = null;
			this.mAmuseBg = null;
			this.mRoomPasswordText = null;
			this.mRoomPasswordGO = null;
			this.mPvp3v3PlayerBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtn = null;
			this.mPvp3v3PlayerBtnBg = null;
			this.mPvp3v3PlayerBtnClose = null;
			this.mPvp3v3MicRoomBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtn = null;
			this.mPvp3v3MicRoomBtnBg = null;
			this.mPvp3v3MicRoomBtnClose = null;
			this.txtPkCountInfo = null;
			this.goBattleTimeState = null;
			this.arrNumbers.Clear();
			this.btnFirstBattleChest = null;
			this.btnFirstWinChest = null;
			this.btnFiveBattleChest = null;
			this.goFirstBattleGet = null;
			this.goFiveBattleGet = null;
			this.goFirstWinGet = null;
			this.gofiveBattleAward = null;
			this.gofirstBattleAward = null;
			this.goMatchOK = null;
			this.mBeginGray = null;
			this.mTeamVoiceBtn = null;
			this.mTeamVoiceBtnGo = null;
			this.goScoreWarStateTimeInfo = null;
			this.txtTimeInfo = null;
		}

		// Token: 0x06010247 RID: 66119 RVA: 0x0047F50C File Offset: 0x0047D90C
		private void InitVoiceChatModule()
		{
		}

		// Token: 0x06010248 RID: 66120 RVA: 0x0047F50E File Offset: 0x0047D90E
		private void UnInitVoiceChatModule()
		{
		}

		// Token: 0x06010249 RID: 66121 RVA: 0x0047F510 File Offset: 0x0047D910
		private void SetVoiceInputBtnShow(bool isShow)
		{
			if (this.mTeamVoiceBtnGo)
			{
				this.mTeamVoiceBtnGo.CustomActive(isShow);
			}
			if (this.mTeamVoiceBtn)
			{
				this.mTeamVoiceBtn.gameObject.CustomActive(isShow);
			}
		}

		// Token: 0x0601024A RID: 66122 RVA: 0x0047F550 File Offset: 0x0047D950
		private void _onBtCloseButtonClick()
		{
			if (this.bIsMatching || this.frameMgr.IsFrameOpen<PkSeekWaiting>(null) || DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo != null && roomInfo.roomSimpleInfo.id > 0U)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel("退出活动场景会自动离开积分赛队伍，是否确认退出？", delegate()
				{
					RoomInfo roomInfo2 = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
					if (roomInfo2 != null && roomInfo2.roomSimpleInfo.id > 0U)
					{
						this.SendQuitRoomReq();
					}
					this.SwitchSceneToTown();
				}, null, 0f, false);
			}
			else
			{
				this.SwitchSceneToTown();
			}
		}

		// Token: 0x0601024B RID: 66123 RVA: 0x0047F5DF File Offset: 0x0047D9DF
		private void _onBtMenuButtonClick()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601024C RID: 66124 RVA: 0x0047F603 File Offset: 0x0047DA03
		private void _onBtInviteFriendsButtonClick()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamInvitePlayerListFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamInvitePlayerListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
		}

		// Token: 0x0601024D RID: 66125 RVA: 0x0047F640 File Offset: 0x0047DA40
		private void _onBtBeginButtonClick()
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null || roomInfo.roomSlotInfos == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo != null && roomInfo.roomSimpleInfo.id > 0U)
			{
				if (roomInfo.roomSimpleInfo.roomStatus == 1)
				{
					if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("你不是队长,无法开始游戏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
					{
						if (roomInfo.roomSlotInfos[i].playerId > 0UL && roomInfo.roomSlotInfos[i].status == 4)
						{
							SystemNotifyManager.SystemNotify(9216, string.Empty);
							return;
						}
					}
				}
				if (roomInfo.roomSimpleInfo.roomStatus == 2)
				{
					return;
				}
				if (this.bMatchLock)
				{
					return;
				}
				this.bMatchLock = true;
				if (roomInfo.roomSimpleInfo.roomStatus == 1)
				{
					this.SendBeginGameReq();
				}
				else if (roomInfo.roomSimpleInfo.roomStatus == 3)
				{
					this.SendCancelGameReq();
				}
				else
				{
					Logger.LogErrorFormat("Pk3v3 begin state is error, roomstate = {0}", new object[]
					{
						roomInfo.roomSimpleInfo.roomStatus
					});
				}
			}
			else
			{
				if (this.bMatchLock)
				{
					return;
				}
				this.bMatchLock = true;
				if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsMathcing())
				{
					this.SendBeginOnePersonMatchGameReq();
				}
				else
				{
					this.SendCancelOnePersonMatchGameReq();
				}
			}
		}

		// Token: 0x0601024E RID: 66126 RVA: 0x0047F7C6 File Offset: 0x0047DBC6
		private void _onBtSettingButtonClick()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3RoomSettingFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3RoomSettingFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601024F RID: 66127 RVA: 0x0047F7FB File Offset: 0x0047DBFB
		private void _onPvp3v3PlayerBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVociePlayer();
		}

		// Token: 0x06010250 RID: 66128 RVA: 0x0047F827 File Offset: 0x0047DC27
		private void _onPvp3v3MicRoomBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVoiceMic();
		}

		// Token: 0x0400A2BC RID: 41660
		private string PlayerInfoElePath = "UIFlatten/Prefabs/Pk3v3/Pk3v3PlayerInfo";

		// Token: 0x0400A2BD RID: 41661
		private string StartBtnRedPath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_06";

		// Token: 0x0400A2BE RID: 41662
		private string StartBtnBluePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Lanse_01";

		// Token: 0x0400A2BF RID: 41663
		private const int MaxPlayerNum = 3;

		// Token: 0x0400A2C0 RID: 41664
		private PkWaitingRoomData RoomData = new PkWaitingRoomData();

		// Token: 0x0400A2C1 RID: 41665
		private RoomSlotGroup SelfGroup;

		// Token: 0x0400A2C2 RID: 41666
		private bool bSelfIsRoomOwner;

		// Token: 0x0400A2C3 RID: 41667
		private bool bMatchLock;

		// Token: 0x0400A2C4 RID: 41668
		private bool bIsMatching;

		// Token: 0x0400A2C5 RID: 41669
		private GameObject[] LeftList = new GameObject[3];

		// Token: 0x0400A2C6 RID: 41670
		private GameObject[] RightList = new GameObject[3];

		// Token: 0x0400A2C7 RID: 41671
		private ComTalk m_miniTalk;

		// Token: 0x0400A2C8 RID: 41672
		[UIObject("GetAward/Item0")]
		private GameObject goAwardItem0;

		// Token: 0x0400A2C9 RID: 41673
		[UIObject("GetAward/Item1")]
		private GameObject goAwardItem1;

		// Token: 0x0400A2CA RID: 41674
		[UIObject("GetAward/Item2")]
		private GameObject goAwardItem2;

		// Token: 0x0400A2CB RID: 41675
		[UIControl("GetAward/Condition", null, 0)]
		private Text txtCondition;

		// Token: 0x0400A2CC RID: 41676
		[UIControl("GetAward/btnGetAward", null, 0)]
		private ComButtonEnbale btnGetAward;

		// Token: 0x0400A2CD RID: 41677
		private VoiceInputBtn mTeamVoiceBtn;

		// Token: 0x0400A2CE RID: 41678
		private GameObject mTeamVoiceBtnGo;

		// Token: 0x0400A2CF RID: 41679
		private int m_iCurAwardID;

		// Token: 0x0400A2D0 RID: 41680
		private float fTimeAcc;

		// Token: 0x0400A2D1 RID: 41681
		private int iFirstBattleAwardID;

		// Token: 0x0400A2D2 RID: 41682
		private int iFiveBattleAwardID;

		// Token: 0x0400A2D3 RID: 41683
		private int iFirstWinBattleID;

		// Token: 0x0400A2D4 RID: 41684
		private bool bHasTeam;

		// Token: 0x0400A2D5 RID: 41685
		private Button mBtClose;

		// Token: 0x0400A2D6 RID: 41686
		private Button mBtMenu;

		// Token: 0x0400A2D7 RID: 41687
		private Button mBtInviteFriends;

		// Token: 0x0400A2D8 RID: 41688
		private Button mBtBegin;

		// Token: 0x0400A2D9 RID: 41689
		private GameObject mTalkRoot;

		// Token: 0x0400A2DA RID: 41690
		private Button mBtSetting;

		// Token: 0x0400A2DB RID: 41691
		private GameObject mLeft;

		// Token: 0x0400A2DC RID: 41692
		private GameObject mRight;

		// Token: 0x0400A2DD RID: 41693
		private Text mRoomName;

		// Token: 0x0400A2DE RID: 41694
		private Text mRoomId;

		// Token: 0x0400A2DF RID: 41695
		private Image mMatchTypeImg;

		// Token: 0x0400A2E0 RID: 41696
		private Image mAmuseTypeImg;

		// Token: 0x0400A2E1 RID: 41697
		private Text mBtMatchText;

		// Token: 0x0400A2E2 RID: 41698
		private GameObject mRankBg;

		// Token: 0x0400A2E3 RID: 41699
		private Image mBtStartImage;

		// Token: 0x0400A2E4 RID: 41700
		private GameObject mAmuseBg;

		// Token: 0x0400A2E5 RID: 41701
		private Text mRoomPasswordText;

		// Token: 0x0400A2E6 RID: 41702
		private GameObject mRoomPasswordGO;

		// Token: 0x0400A2E7 RID: 41703
		private Button mPvp3v3PlayerBtn;

		// Token: 0x0400A2E8 RID: 41704
		private Image mPvp3v3PlayerBtnBg;

		// Token: 0x0400A2E9 RID: 41705
		private Image mPvp3v3PlayerBtnClose;

		// Token: 0x0400A2EA RID: 41706
		private Button mPvp3v3MicRoomBtn;

		// Token: 0x0400A2EB RID: 41707
		private Image mPvp3v3MicRoomBtnBg;

		// Token: 0x0400A2EC RID: 41708
		private Image mPvp3v3MicRoomBtnClose;

		// Token: 0x0400A2ED RID: 41709
		private Text txtPkCountInfo;

		// Token: 0x0400A2EE RID: 41710
		private GameObject goBattleTimeState;

		// Token: 0x0400A2EF RID: 41711
		private List<Text> arrNumbers = new List<Text>();

		// Token: 0x0400A2F0 RID: 41712
		private Button btnFirstBattleChest;

		// Token: 0x0400A2F1 RID: 41713
		private Image goFirstBattleGet;

		// Token: 0x0400A2F2 RID: 41714
		private Button btnFiveBattleChest;

		// Token: 0x0400A2F3 RID: 41715
		private Image goFiveBattleGet;

		// Token: 0x0400A2F4 RID: 41716
		private Button btnFirstWinChest;

		// Token: 0x0400A2F5 RID: 41717
		private Image goFirstWinGet;

		// Token: 0x0400A2F6 RID: 41718
		private GameObject gofiveBattleAward;

		// Token: 0x0400A2F7 RID: 41719
		private GameObject gofirstBattleAward;

		// Token: 0x0400A2F8 RID: 41720
		private GameObject goMatchOK;

		// Token: 0x0400A2F9 RID: 41721
		private GameObject goScoreWarStateTimeInfo;

		// Token: 0x0400A2FA RID: 41722
		private Text txtTimeInfo;

		// Token: 0x0400A2FB RID: 41723
		private UIGray mBeginGray;

		// Token: 0x0400A2FC RID: 41724
		private VoiceChatModule voiceChatModule;
	}
}
