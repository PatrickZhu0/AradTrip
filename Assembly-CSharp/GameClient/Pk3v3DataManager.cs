using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020012C8 RID: 4808
	public class Pk3v3DataManager : DataManager<Pk3v3DataManager>
	{
		// Token: 0x17001B61 RID: 7009
		// (get) Token: 0x0600BA11 RID: 47633 RVA: 0x002ADDF7 File Offset: 0x002AC1F7
		// (set) Token: 0x0600BA12 RID: 47634 RVA: 0x002ADDFF File Offset: 0x002AC1FF
		public bool isNotify
		{
			get
			{
				return this.m_bNotify;
			}
			set
			{
				this.m_bNotify = value;
			}
		}

		// Token: 0x17001B62 RID: 7010
		// (get) Token: 0x0600BA14 RID: 47636 RVA: 0x002ADE11 File Offset: 0x002AC211
		// (set) Token: 0x0600BA13 RID: 47635 RVA: 0x002ADE08 File Offset: 0x002AC208
		public int SimpleInviteLastTime
		{
			get
			{
				return this.simpleInviteLastTime;
			}
			set
			{
				this.simpleInviteLastTime = value;
			}
		}

		// Token: 0x17001B63 RID: 7011
		// (get) Token: 0x0600BA15 RID: 47637 RVA: 0x002ADE19 File Offset: 0x002AC219
		// (set) Token: 0x0600BA16 RID: 47638 RVA: 0x002ADE21 File Offset: 0x002AC221
		public Dictionary<RoomType, Pk3v3RoomSettingData> RoomSettingData
		{
			get
			{
				return this.roomSettingData;
			}
			set
			{
				if (this.roomSettingData != value)
				{
					this.roomSettingData = value;
				}
			}
		}

		// Token: 0x0600BA17 RID: 47639 RVA: 0x002ADE36 File Offset: 0x002AC236
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BA18 RID: 47640 RVA: 0x002ADE3C File Offset: 0x002AC23C
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(314, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.fChangePosLastTime = (float)tableItem.Value;
			}
			this.InitRoomSettingData();
		}

		// Token: 0x0600BA19 RID: 47641 RVA: 0x002ADE88 File Offset: 0x002AC288
		public override void Clear()
		{
			this.ClearRoomInfo();
			if (this.roomSettingData != null)
			{
				foreach (KeyValuePair<RoomType, Pk3v3RoomSettingData> keyValuePair in this.roomSettingData)
				{
					Pk3v3RoomSettingData value = keyValuePair.Value;
					if (value != null)
					{
						value.DefaultInit();
					}
				}
			}
			this.fChangePosLastTime = 0f;
			this.fAddUpTime = 0f;
			this.fChangePosLocationTime = 0f;
			this._UnBindNetMsg();
			this.iInt = 0;
			this.m_bNotify = false;
			this.SimpleInviteLastTime = -1;
		}

		// Token: 0x0600BA1A RID: 47642 RVA: 0x002ADF1B File Offset: 0x002AC31B
		public void BindNetMsg()
		{
			this._BindNetMsg();
		}

		// Token: 0x0600BA1B RID: 47643 RVA: 0x002ADF23 File Offset: 0x002AC323
		public void UnBindNetMsg()
		{
			this._UnBindNetMsg();
		}

		// Token: 0x0600BA1C RID: 47644 RVA: 0x002ADF2C File Offset: 0x002AC32C
		private void InitRoomSettingData()
		{
			if (this.roomSettingData == null)
			{
				this.roomSettingData = new Dictionary<RoomType, Pk3v3RoomSettingData>();
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_FREE, out pk3v3RoomSettingData))
			{
				pk3v3RoomSettingData = new Pk3v3RoomSettingData();
				pk3v3RoomSettingData.DefaultInit();
				this.roomSettingData.Add(RoomType.ROOM_TYPE_THREE_FREE, pk3v3RoomSettingData);
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData2 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_MELEE, out pk3v3RoomSettingData2))
			{
				pk3v3RoomSettingData2 = new Pk3v3RoomSettingData();
				pk3v3RoomSettingData2.DefaultInit();
				this.roomSettingData.Add(RoomType.ROOM_TYPE_MELEE, pk3v3RoomSettingData2);
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData3 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_MATCH, out pk3v3RoomSettingData3))
			{
				pk3v3RoomSettingData3 = new Pk3v3RoomSettingData();
				pk3v3RoomSettingData3.DefaultInit();
				this.roomSettingData.Add(RoomType.ROOM_TYPE_THREE_MATCH, pk3v3RoomSettingData3);
			}
			this.SetLocalSave();
		}

		// Token: 0x0600BA1D RID: 47645 RVA: 0x002ADFE0 File Offset: 0x002AC3E0
		private void SetLocalSave()
		{
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_FREE, out pk3v3RoomSettingData))
			{
				return;
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData2 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_MATCH, out pk3v3RoomSettingData2))
			{
				return;
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData3 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_SCORE_WAR, out pk3v3RoomSettingData3))
			{
				return;
			}
			string pk3v3LocalDataKey = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "bSetMinLv");
			string pk3v3LocalDataKey2 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "bSetMinRankLv");
			string pk3v3LocalDataKey3 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "MinLv");
			string pk3v3LocalDataKey4 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "MinRankLv");
			string pk3v3LocalDataKey5 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "bSetMinLv");
			string pk3v3LocalDataKey6 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "bSetMinRankLv");
			string pk3v3LocalDataKey7 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "MinLv");
			string pk3v3LocalDataKey8 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "MinRankLv");
			string text = PlayerLocalSetting.GetValue(pk3v3LocalDataKey) as string;
			string text2 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey2) as string;
			string text3 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey3) as string;
			string text4 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey4) as string;
			string text5 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey5) as string;
			string text6 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey6) as string;
			string text7 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey7) as string;
			string text8 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey8) as string;
			if (text == null || text == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey, pk3v3RoomSettingData.bSetMinLv.ToString());
			}
			else if (text == "True")
			{
				pk3v3RoomSettingData.bSetMinLv = true;
			}
			else
			{
				pk3v3RoomSettingData.bSetMinLv = false;
			}
			if (text2 == null || text2 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey2, pk3v3RoomSettingData.bSetMinRankLv.ToString());
			}
			else if (text2 == "True")
			{
				pk3v3RoomSettingData.bSetMinRankLv = true;
			}
			else
			{
				pk3v3RoomSettingData.bSetMinRankLv = false;
			}
			if (text3 == null || text3 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey3, pk3v3RoomSettingData.MinLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
				int minLv = 0;
				if (int.TryParse(text3, out minLv))
				{
					pk3v3RoomSettingData.MinLv = minLv;
				}
			}
			if (text4 == null || text4 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey4, pk3v3RoomSettingData.MinRankLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
				int minRankLv = 0;
				if (int.TryParse(text4, out minRankLv))
				{
					pk3v3RoomSettingData.MinRankLv = minRankLv;
				}
			}
			if (text5 == null || text5 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey5, pk3v3RoomSettingData2.bSetMinLv.ToString());
			}
			else if (text5 == "True")
			{
				pk3v3RoomSettingData2.bSetMinLv = true;
			}
			else
			{
				pk3v3RoomSettingData2.bSetMinLv = false;
			}
			if (text6 == null || text6 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey6, pk3v3RoomSettingData2.bSetMinRankLv.ToString());
			}
			else if (text6 == "True")
			{
				pk3v3RoomSettingData2.bSetMinRankLv = true;
			}
			else
			{
				pk3v3RoomSettingData2.bSetMinRankLv = false;
			}
			if (text7 == null || text7 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey7, pk3v3RoomSettingData2.MinLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData2.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
				int minLv2 = 0;
				if (int.TryParse(text7, out minLv2))
				{
					pk3v3RoomSettingData2.MinLv = minLv2;
				}
			}
			if (text8 == null || text8 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey8, pk3v3RoomSettingData2.MinRankLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData2.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
				int minRankLv2 = 0;
				if (int.TryParse(text8, out minRankLv2))
				{
					pk3v3RoomSettingData2.MinRankLv = minRankLv2;
				}
			}
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x0600BA1E RID: 47646 RVA: 0x002AE3E8 File Offset: 0x002AC7E8
		public override void Update(float a_fTime)
		{
			if (this.isNotify || this.SimpleInviteLastTime > 0)
			{
				this.fAddUpTime += a_fTime;
				if (this.fAddUpTime > 1f)
				{
					if (this.SimpleInviteLastTime > 0)
					{
						this.SimpleInviteLastTime--;
					}
					if (this.isNotify)
					{
						this.fChangePosLocationTime -= 1f;
						this.iInt = (int)this.fChangePosLocationTime;
					}
					this.fAddUpTime = 0f;
				}
			}
		}

		// Token: 0x0600BA1F RID: 47647 RVA: 0x002AE479 File Offset: 0x002AC879
		public void SetCountDownTime(float fTime)
		{
			if (fTime > 0f)
			{
				this.fChangePosLocationTime = fTime;
				this.iInt = (int)fTime;
				this.m_bNotify = true;
			}
		}

		// Token: 0x0600BA20 RID: 47648 RVA: 0x002AE49C File Offset: 0x002AC89C
		public void ClearRoomInfo()
		{
			if (Pk3v3DataManager.roomInfo != null)
			{
				Pk3v3DataManager.roomInfo.roomSimpleInfo.id = 0U;
				Pk3v3DataManager.roomInfo.roomSimpleInfo.isPassword = 0;
				Pk3v3DataManager.roomInfo.roomSimpleInfo.ownerId = 0UL;
				Pk3v3DataManager.roomInfo.roomSimpleInfo.roomStatus = 0;
				Pk3v3DataManager.roomInfo.roomSimpleInfo.roomType = 0;
				for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
				{
					Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId = 0UL;
					Pk3v3DataManager.roomInfo.roomSlotInfos[i].group = 0;
					Pk3v3DataManager.roomInfo.roomSlotInfos[i].index = 0;
					Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerOccu = 0;
				}
			}
			this.InviteRoomList.Clear();
			this.bHasPassword = false;
			this.PassWord = string.Empty;
		}

		// Token: 0x0600BA21 RID: 47649 RVA: 0x002AE588 File Offset: 0x002AC988
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(607801U, new Action<MsgDATA>(this._OnWorldSyncReLoginRoomInfo));
				NetProcess.AddMsgHandler(607814U, new Action<MsgDATA>(this._OnWorldUpdateRoomRes));
				NetProcess.AddMsgHandler(607802U, new Action<MsgDATA>(this._OnSyncRoomSimpleInfo));
				NetProcess.AddMsgHandler(607809U, new Action<MsgDATA>(this._OnSyncRoomPasswordInfo));
				NetProcess.AddMsgHandler(607803U, new Action<MsgDATA>(this._OnSyncRoomSlotInfo));
				NetProcess.AddMsgHandler(607816U, new Action<MsgDATA>(this._OnJoinRoomRes));
				NetProcess.AddMsgHandler(607824U, new Action<MsgDATA>(this._OnInviteJoinRoomRes));
				NetProcess.AddMsgHandler(607804U, new Action<MsgDATA>(this._OnSyncInviteInfo));
				NetProcess.AddMsgHandler(607828U, new Action<MsgDATA>(this._OnRoomInviteReply));
				NetProcess.AddMsgHandler(607805U, new Action<MsgDATA>(this._OnSyncKickOutInfo));
				NetProcess.AddMsgHandler(607820U, new Action<MsgDATA>(this._OnKickOutRoomRes));
				NetProcess.AddMsgHandler(607826U, new Action<MsgDATA>(this._OnChangeRoomOwnerRes));
				NetProcess.AddMsgHandler(607830U, new Action<MsgDATA>(this._OnRoomCloseSlotRes));
				NetProcess.AddMsgHandler(607836U, new Action<MsgDATA>(this._OnRoomBeginGameRes));
				NetProcess.AddMsgHandler(607838U, new Action<MsgDATA>(this._OnRoomBattleCancelRes));
				NetProcess.AddMsgHandler(607840U, new Action<MsgDATA>(this._OnVoteReadyRes));
				NetProcess.AddMsgHandler(607842U, new Action<MsgDATA>(this._OnRoomSendInviteLinkRes));
				NetProcess.AddMsgHandler(607832U, new Action<MsgDATA>(this._OnRoomSwapSlotRes));
				NetProcess.AddMsgHandler(607807U, new Action<MsgDATA>(this._OnSyncRoomSwapSlotInfo));
				NetProcess.AddMsgHandler(607834U, new Action<MsgDATA>(this._OnRoomResponseSwapSlotRes));
				NetProcess.AddMsgHandler(607808U, new Action<MsgDATA>(this._OnSyncRoomSwapResultInfo));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600BA22 RID: 47650 RVA: 0x002AE778 File Offset: 0x002ACB78
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(607801U, new Action<MsgDATA>(this._OnWorldSyncReLoginRoomInfo));
			NetProcess.RemoveMsgHandler(607814U, new Action<MsgDATA>(this._OnWorldUpdateRoomRes));
			NetProcess.RemoveMsgHandler(607802U, new Action<MsgDATA>(this._OnSyncRoomSimpleInfo));
			NetProcess.RemoveMsgHandler(607809U, new Action<MsgDATA>(this._OnSyncRoomPasswordInfo));
			NetProcess.RemoveMsgHandler(607803U, new Action<MsgDATA>(this._OnSyncRoomSlotInfo));
			NetProcess.RemoveMsgHandler(607816U, new Action<MsgDATA>(this._OnJoinRoomRes));
			NetProcess.RemoveMsgHandler(607824U, new Action<MsgDATA>(this._OnInviteJoinRoomRes));
			NetProcess.RemoveMsgHandler(607804U, new Action<MsgDATA>(this._OnSyncInviteInfo));
			NetProcess.RemoveMsgHandler(607828U, new Action<MsgDATA>(this._OnRoomInviteReply));
			NetProcess.RemoveMsgHandler(607805U, new Action<MsgDATA>(this._OnSyncKickOutInfo));
			NetProcess.RemoveMsgHandler(607820U, new Action<MsgDATA>(this._OnKickOutRoomRes));
			NetProcess.RemoveMsgHandler(607826U, new Action<MsgDATA>(this._OnChangeRoomOwnerRes));
			NetProcess.RemoveMsgHandler(607830U, new Action<MsgDATA>(this._OnRoomCloseSlotRes));
			NetProcess.RemoveMsgHandler(607836U, new Action<MsgDATA>(this._OnRoomBeginGameRes));
			NetProcess.RemoveMsgHandler(607838U, new Action<MsgDATA>(this._OnRoomBattleCancelRes));
			NetProcess.RemoveMsgHandler(607840U, new Action<MsgDATA>(this._OnVoteReadyRes));
			NetProcess.RemoveMsgHandler(607842U, new Action<MsgDATA>(this._OnRoomSendInviteLinkRes));
			NetProcess.RemoveMsgHandler(607832U, new Action<MsgDATA>(this._OnRoomSwapSlotRes));
			NetProcess.RemoveMsgHandler(607807U, new Action<MsgDATA>(this._OnSyncRoomSwapSlotInfo));
			NetProcess.RemoveMsgHandler(607834U, new Action<MsgDATA>(this._OnRoomResponseSwapSlotRes));
			NetProcess.RemoveMsgHandler(607808U, new Action<MsgDATA>(this._OnSyncRoomSwapResultInfo));
			this.m_bNetBind = false;
		}

		// Token: 0x0600BA23 RID: 47651 RVA: 0x002AE95C File Offset: 0x002ACD5C
		private void _OnWorldSyncReLoginRoomInfo(MsgDATA msg)
		{
			WorldSyncRoomInfo worldSyncRoomInfo = new WorldSyncRoomInfo();
			worldSyncRoomInfo.decode(msg.bytes);
			Pk3v3DataManager.roomInfo = worldSyncRoomInfo.info;
			if (Pk3v3DataManager.roomInfo.roomSimpleInfo.id <= 0U)
			{
				Logger.LogError("3v3房间掉线重连后,玩家初始化数据时,服务器同步的房间id有问题");
			}
			bool flag = true;
			for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId != 0UL)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Logger.LogError("3v3房间掉线重连后,玩家初始化数据时,服务器同步的玩家列表有问题，全是空数据");
			}
		}

		// Token: 0x0600BA24 RID: 47652 RVA: 0x002AE9F0 File Offset: 0x002ACDF0
		private void _OnWorldUpdateRoomRes(MsgDATA msg)
		{
			WorldUpdateRoomRes worldUpdateRoomRes = new WorldUpdateRoomRes();
			worldUpdateRoomRes.decode(msg.bytes);
			if (worldUpdateRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldUpdateRoomRes.result, string.Empty);
				return;
			}
			Pk3v3DataManager.roomInfo = worldUpdateRoomRes.info;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomInfoUpdate, null, null, null, null);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
				{
					this.SwitchToPk3v3Scene();
				}
			}
		}

		// Token: 0x0600BA25 RID: 47653 RVA: 0x002AEA94 File Offset: 0x002ACE94
		private void _OnSyncRoomSimpleInfo(MsgDATA msg)
		{
			WorldSyncRoomSimpleInfo worldSyncRoomSimpleInfo = new WorldSyncRoomSimpleInfo();
			worldSyncRoomSimpleInfo.decode(msg.bytes);
			if (Pk3v3DataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnSyncRoomSimpleInfo]");
			}
			if (worldSyncRoomSimpleInfo.info.roomType != 1 && worldSyncRoomSimpleInfo.info.roomType != 4)
			{
				return;
			}
			if (Pk3v3DataManager.roomInfo != null && Pk3v3DataManager.roomInfo.roomSimpleInfo.ownerId != worldSyncRoomSimpleInfo.info.ownerId)
			{
				string text = string.Empty;
				for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
				{
					if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId == worldSyncRoomSimpleInfo.info.ownerId)
					{
						text = Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerName;
						break;
					}
				}
				SystemNotifyManager.SystemNotify(9214, new object[]
				{
					text
				});
			}
			Pk3v3DataManager.roomInfo.roomSimpleInfo = worldSyncRoomSimpleInfo.info;
			if (worldSyncRoomSimpleInfo.info.roomStatus == 1)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatch, null, null, null, null);
			}
			else if (worldSyncRoomSimpleInfo.info.roomStatus == 2)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3VoteEnterPkFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3VoteEnterPkFrame>(null, false);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3VoteEnterBattle, null, null, null, null);
				bool flag = true;
				int num = 0;
				ulong num2 = 0UL;
				for (int j = 0; j < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; j++)
				{
					if (Pk3v3DataManager.roomInfo.roomSlotInfos[j].playerId > 0UL)
					{
						num++;
						num2 = Pk3v3DataManager.roomInfo.roomSlotInfos[j].playerId;
					}
				}
				if (num == 1 && num2 == Pk3v3DataManager.roomInfo.roomSimpleInfo.ownerId)
				{
					flag = false;
				}
				if (flag)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3VoteEnterPkFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			else if (worldSyncRoomSimpleInfo.info.roomStatus == 3)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3VoteEnterPkFrame>(null, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatch, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSimpleInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600BA26 RID: 47654 RVA: 0x002AECE0 File Offset: 0x002AD0E0
		private void _OnSyncRoomPasswordInfo(MsgDATA msg)
		{
			WorldSyncRoomPasswordInfo worldSyncRoomPasswordInfo = new WorldSyncRoomPasswordInfo();
			worldSyncRoomPasswordInfo.decode(msg.bytes);
			this.bHasPassword = (worldSyncRoomPasswordInfo.password != string.Empty);
			this.PassWord = worldSyncRoomPasswordInfo.password;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Set3v3RoomPassword, null, null, null, null);
		}

		// Token: 0x0600BA27 RID: 47655 RVA: 0x002AED34 File Offset: 0x002AD134
		private void _OnSyncRoomSlotInfo(MsgDATA msg)
		{
			WorldSyncRoomSlotInfo worldSyncRoomSlotInfo = new WorldSyncRoomSlotInfo();
			worldSyncRoomSlotInfo.decode(msg.bytes);
			if (Pk3v3DataManager.roomInfo != null)
			{
				if (Pk3v3DataManager.roomInfo.roomSlotInfos != null)
				{
					for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
					{
						if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].group == worldSyncRoomSlotInfo.slotInfo.group)
						{
							if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].index == worldSyncRoomSlotInfo.slotInfo.index)
							{
								if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId > 0UL && worldSyncRoomSlotInfo.slotInfo.playerId <= 0UL)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3PlayerLeave, worldSyncRoomSlotInfo.slotInfo.group, worldSyncRoomSlotInfo.slotInfo.index, null, null);
								}
								if (worldSyncRoomSlotInfo.slotInfo.playerId > 0UL && worldSyncRoomSlotInfo.slotInfo.playerId != Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3ChangePosition, worldSyncRoomSlotInfo.slotInfo.playerId, worldSyncRoomSlotInfo.slotInfo.group, null, null);
								}
								Pk3v3DataManager.roomInfo.roomSlotInfos[i] = worldSyncRoomSlotInfo.slotInfo;
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
								if (worldSyncRoomSlotInfo.slotInfo.status == 4)
								{
									SystemNotifyManager.SysNotifyFloatingEffect(string.Format("玩家{0}已断开连接", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
								}
								if (worldSyncRoomSlotInfo.slotInfo.readyStatus == 2 || worldSyncRoomSlotInfo.slotInfo.readyStatus == 3)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RefuseBeginMatch, null, null, null, null);
									if (worldSyncRoomSlotInfo.slotInfo.readyStatus == 2)
									{
										SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_room_beginfight_refuse", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
									}
									else
									{
										SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_room_beginfight_timeout", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
									}
								}
								break;
							}
						}
					}
				}
				else
				{
					Logger.LogError("roomInfo.roomSlotInfos is null in [_OnSyncRoomSlotInfo]");
				}
			}
			else
			{
				Logger.LogError("roomInfo is null in [_OnSyncRoomSlotInfo]");
			}
		}

		// Token: 0x0600BA28 RID: 47656 RVA: 0x002AEF8C File Offset: 0x002AD38C
		private void _OnJoinRoomRes(MsgDATA msg)
		{
			WorldJoinRoomRes worldJoinRoomRes = new WorldJoinRoomRes();
			worldJoinRoomRes.decode(msg.bytes);
			if (worldJoinRoomRes.result != 0U)
			{
				if (worldJoinRoomRes.result == 3401020U)
				{
					SystemNotifyManager.SystemNotify(9217, new UnityAction(this.AcceptCreateAmuseRoom));
				}
				else if (worldJoinRoomRes.result == 3401026U)
				{
					SystemNotifyManager.SystemNotify(9217, new UnityAction(this.AcceptCreateMatchRoom));
				}
				else if (worldJoinRoomRes.result == 3401025U)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RefreshRoomList, null, null, null, null);
					SystemNotifyManager.SysNotifyFloatingEffect("该房间已设置密码", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (worldJoinRoomRes.info != null && worldJoinRoomRes.info.roomSimpleInfo != null && (worldJoinRoomRes.info.roomSimpleInfo.roomType == 1 || worldJoinRoomRes.info.roomSimpleInfo.roomType == 4))
				{
					SystemNotifyManager.SystemNotify((int)worldJoinRoomRes.result, string.Empty);
				}
				return;
			}
			if (worldJoinRoomRes.info.roomSimpleInfo.roomType != 1 && worldJoinRoomRes.info.roomSimpleInfo.roomType != 4)
			{
				return;
			}
			Pk3v3DataManager.roomInfo = worldJoinRoomRes.info;
			if (Pk3v3DataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnJoinRoomRes]");
				return;
			}
			this.SwitchToPk3v3Scene();
		}

		// Token: 0x0600BA29 RID: 47657 RVA: 0x002AF0EC File Offset: 0x002AD4EC
		private void _OnInviteJoinRoomRes(MsgDATA msg)
		{
			WorldInviteJoinRoomRes worldInviteJoinRoomRes = new WorldInviteJoinRoomRes();
			worldInviteJoinRoomRes.decode(msg.bytes);
			if (worldInviteJoinRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldInviteJoinRoomRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600BA2A RID: 47658 RVA: 0x002AF128 File Offset: 0x002AD528
		private void _OnSyncInviteInfo(MsgDATA msg)
		{
			WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = new WorldSyncRoomInviteInfo();
			worldSyncRoomInviteInfo.decode(msg.bytes);
			if (worldSyncRoomInviteInfo.roomType != 1 && worldSyncRoomInviteInfo.roomType != 4)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.InviteRoomList.Count; i++)
			{
				if (this.InviteRoomList[i].inviterId == worldSyncRoomInviteInfo.inviterId)
				{
					this.InviteRoomList[i] = worldSyncRoomInviteInfo;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.InviteRoomList.Insert(0, worldSyncRoomInviteInfo);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
		}

		// Token: 0x0600BA2B RID: 47659 RVA: 0x002AF1E0 File Offset: 0x002AD5E0
		private void _OnRoomInviteReply(MsgDATA msg)
		{
			WorldBeInviteRoomRes worldBeInviteRoomRes = new WorldBeInviteRoomRes();
			worldBeInviteRoomRes.decode(msg.bytes);
			if (worldBeInviteRoomRes.roomInfo.roomSimpleInfo.roomType != 1 && worldBeInviteRoomRes.roomInfo.roomSimpleInfo.roomType != 4)
			{
				return;
			}
			if (worldBeInviteRoomRes.result != 0U && worldBeInviteRoomRes.result != 3403007U)
			{
				SystemNotifyManager.SystemNotify((int)worldBeInviteRoomRes.result, string.Empty);
				return;
			}
			Pk3v3DataManager.roomInfo = worldBeInviteRoomRes.roomInfo;
			if (Pk3v3DataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnJoinRoomRes]");
				return;
			}
			if (worldBeInviteRoomRes.result != 3403007U)
			{
				this.SwitchToPk3v3Scene();
			}
		}

		// Token: 0x0600BA2C RID: 47660 RVA: 0x002AF290 File Offset: 0x002AD690
		private void _OnSyncKickOutInfo(MsgDATA msg)
		{
			WorldSyncRoomKickOutInfo worldSyncRoomKickOutInfo = new WorldSyncRoomKickOutInfo();
			worldSyncRoomKickOutInfo.decode(msg.bytes);
			this.ClearRoomInfo();
			SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("你被玩家{0}踢出了{1}号房间(10秒内无法再次进入)", worldSyncRoomKickOutInfo.kickPlayerName, worldSyncRoomKickOutInfo.roomId), new UnityAction(this.OnClickOkAcceptBeKickedOut), string.Empty, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3KickOut, null, null, null, null);
		}

		// Token: 0x0600BA2D RID: 47661 RVA: 0x002AF2FC File Offset: 0x002AD6FC
		private void _OnKickOutRoomRes(MsgDATA msg)
		{
			WorldKickOutRoomRes worldKickOutRoomRes = new WorldKickOutRoomRes();
			worldKickOutRoomRes.decode(msg.bytes);
			if (worldKickOutRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldKickOutRoomRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600BA2E RID: 47662 RVA: 0x002AF338 File Offset: 0x002AD738
		private void _OnChangeRoomOwnerRes(MsgDATA msg)
		{
			WorldChangeRoomOwnerRes worldChangeRoomOwnerRes = new WorldChangeRoomOwnerRes();
			worldChangeRoomOwnerRes.decode(msg.bytes);
			if (worldChangeRoomOwnerRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldChangeRoomOwnerRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600BA2F RID: 47663 RVA: 0x002AF374 File Offset: 0x002AD774
		private void _OnRoomCloseSlotRes(MsgDATA msg)
		{
			WorldRoomCloseSlotRes worldRoomCloseSlotRes = new WorldRoomCloseSlotRes();
			worldRoomCloseSlotRes.decode(msg.bytes);
			if (worldRoomCloseSlotRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomCloseSlotRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600BA30 RID: 47664 RVA: 0x002AF3B0 File Offset: 0x002AD7B0
		private void _OnRoomBeginGameRes(MsgDATA msg)
		{
			WorldRoomBattleStartRes worldRoomBattleStartRes = new WorldRoomBattleStartRes();
			worldRoomBattleStartRes.decode(msg.bytes);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
				{
					return;
				}
			}
			if (worldRoomBattleStartRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleStartRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatchRes, null, null, null, null);
		}

		// Token: 0x0600BA31 RID: 47665 RVA: 0x002AF444 File Offset: 0x002AD844
		private void _OnRoomBattleCancelRes(MsgDATA msg)
		{
			WorldRoomBattleCancelRes worldRoomBattleCancelRes = new WorldRoomBattleCancelRes();
			worldRoomBattleCancelRes.decode(msg.bytes);
			if (worldRoomBattleCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleCancelRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatchRes, null, null, null, null);
		}

		// Token: 0x0600BA32 RID: 47666 RVA: 0x002AF494 File Offset: 0x002AD894
		private void _OnVoteReadyRes(MsgDATA msg)
		{
			WorldRoomBattleReadyRes worldRoomBattleReadyRes = new WorldRoomBattleReadyRes();
			worldRoomBattleReadyRes.decode(msg.bytes);
			if (worldRoomBattleReadyRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleReadyRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600BA33 RID: 47667 RVA: 0x002AF4D0 File Offset: 0x002AD8D0
		private void _OnRoomSendInviteLinkRes(MsgDATA msg)
		{
			WorldRoomSendInviteLinkRes worldRoomSendInviteLinkRes = new WorldRoomSendInviteLinkRes();
			worldRoomSendInviteLinkRes.decode(msg.bytes);
			if (worldRoomSendInviteLinkRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomSendInviteLinkRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("消息已发送...", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BA34 RID: 47668 RVA: 0x002AF518 File Offset: 0x002AD918
		private void _OnRoomSwapSlotRes(MsgDATA msg)
		{
			WorldRoomSwapSlotRes worldRoomSwapSlotRes = new WorldRoomSwapSlotRes();
			worldRoomSwapSlotRes.decode(msg.bytes);
			if (worldRoomSwapSlotRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomSwapSlotRes.result, string.Empty);
				return;
			}
			if (worldRoomSwapSlotRes.playerId > 0UL)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("交换位置请求已发送,请等待...", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600BA35 RID: 47669 RVA: 0x002AF56C File Offset: 0x002AD96C
		private void _OnSyncRoomSwapSlotInfo(MsgDATA msg)
		{
			WorldSyncRoomSwapSlotInfo worldSyncRoomSwapSlotInfo = new WorldSyncRoomSwapSlotInfo();
			worldSyncRoomSwapSlotInfo.decode(msg.bytes);
			this.SwapSlotInfo = worldSyncRoomSwapSlotInfo;
			object[] args = new object[]
			{
				worldSyncRoomSwapSlotInfo.playerName
			};
			SystemNotifyManager.SystemNotify(9215, new UnityAction(this.SwapPosOK), new UnityAction(this.SwapPosCancel), this.fChangePosLastTime, args);
		}

		// Token: 0x0600BA36 RID: 47670 RVA: 0x002AF5CC File Offset: 0x002AD9CC
		private void _OnRoomResponseSwapSlotRes(MsgDATA msg)
		{
			WorldRoomResponseSwapSlotRes stream = new WorldRoomResponseSwapSlotRes();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600BA37 RID: 47671 RVA: 0x002AF5EC File Offset: 0x002AD9EC
		private void _OnSyncRoomSwapResultInfo(MsgDATA msg)
		{
			WorldSyncRoomSwapResultInfo worldSyncRoomSwapResultInfo = new WorldSyncRoomSwapResultInfo();
			worldSyncRoomSwapResultInfo.decode(msg.bytes);
			if (worldSyncRoomSwapResultInfo.result == 2)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}拒绝了你交换位置的请求", worldSyncRoomSwapResultInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (worldSyncRoomSwapResultInfo.result == 4)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("交换位置请求取消", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOKCancel>(null, false);
			}
		}

		// Token: 0x0600BA38 RID: 47672 RVA: 0x002AF658 File Offset: 0x002ADA58
		private void OnClickOkAcceptBeKickedOut()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3KickOut, null, null, null, null);
		}

		// Token: 0x0600BA39 RID: 47673 RVA: 0x002AF6BE File Offset: 0x002ADABE
		private void SwapPosOK()
		{
			this.SendAgreeChangePosReq(true);
		}

		// Token: 0x0600BA3A RID: 47674 RVA: 0x002AF6C7 File Offset: 0x002ADAC7
		private void SwapPosCancel()
		{
			this.SendAgreeChangePosReq(false);
		}

		// Token: 0x0600BA3B RID: 47675 RVA: 0x002AF6D0 File Offset: 0x002ADAD0
		private void AcceptCreateAmuseRoom()
		{
			this.SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_FREE);
		}

		// Token: 0x0600BA3C RID: 47676 RVA: 0x002AF6D9 File Offset: 0x002ADAD9
		private void AcceptCreateMatchRoom()
		{
			this.SendCreateRoomReq(RoomType.ROOM_TYPE_MELEE);
		}

		// Token: 0x0600BA3D RID: 47677 RVA: 0x002AF6E4 File Offset: 0x002ADAE4
		public void SendCreateRoomReq(RoomType roomtype)
		{
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!this.roomSettingData.TryGetValue(roomtype, out pk3v3RoomSettingData))
			{
				this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_FREE, out pk3v3RoomSettingData);
			}
			if (pk3v3RoomSettingData == null)
			{
				return;
			}
			WorldUpdateRoomReq worldUpdateRoomReq = new WorldUpdateRoomReq();
			worldUpdateRoomReq.roomId = 0U;
			worldUpdateRoomReq.roomType = (byte)roomtype;
			worldUpdateRoomReq.name = TR.Value("pk_create_room_name", DataManager<PlayerBaseData>.GetInstance().Name);
			worldUpdateRoomReq.password = this.PassWord;
			worldUpdateRoomReq.limitPlayerLevel = (ushort)pk3v3RoomSettingData.MinLv;
			worldUpdateRoomReq.limitPlayerSeasonLevel = (uint)pk3v3RoomSettingData.MinRankLv;
			if (pk3v3RoomSettingData.bSetMinLv)
			{
				worldUpdateRoomReq.isLimitPlayerLevel = 1;
			}
			else
			{
				worldUpdateRoomReq.isLimitPlayerLevel = 0;
			}
			if (pk3v3RoomSettingData.bSetMinRankLv)
			{
				worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
			}
			else
			{
				worldUpdateRoomReq.isLimitPlayerSeasonLevel = 0;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRoomReq>(ServerType.GATE_SERVER, worldUpdateRoomReq);
		}

		// Token: 0x0600BA3E RID: 47678 RVA: 0x002AF7BC File Offset: 0x002ADBBC
		public static void SendJoinRoomReq(uint roomid, RoomType roomtype = RoomType.ROOM_TYPE_INVALID, string password = "", uint createTime = 0U)
		{
			WorldJoinRoomReq worldJoinRoomReq = new WorldJoinRoomReq();
			worldJoinRoomReq.roomId = roomid;
			if (roomtype != RoomType.ROOM_TYPE_INVALID)
			{
				worldJoinRoomReq.roomType = (byte)roomtype;
			}
			worldJoinRoomReq.password = password;
			worldJoinRoomReq.createTime = createTime;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldJoinRoomReq>(ServerType.GATE_SERVER, worldJoinRoomReq);
		}

		// Token: 0x0600BA3F RID: 47679 RVA: 0x002AF804 File Offset: 0x002ADC04
		public void Pk3v3RoomInviteOtherPlayer(ulong RoleId)
		{
			WorldInviteJoinRoomReq worldInviteJoinRoomReq = new WorldInviteJoinRoomReq();
			worldInviteJoinRoomReq.playerId = RoleId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldInviteJoinRoomReq>(ServerType.GATE_SERVER, worldInviteJoinRoomReq);
		}

		// Token: 0x0600BA40 RID: 47680 RVA: 0x002AF830 File Offset: 0x002ADC30
		public void SendPk3v3ChangePosReq(uint roomId, RoomSlotInfo TargetSlotInfo)
		{
			WorldRoomSwapSlotReq worldRoomSwapSlotReq = new WorldRoomSwapSlotReq();
			worldRoomSwapSlotReq.roomId = roomId;
			worldRoomSwapSlotReq.slotGroup = TargetSlotInfo.group;
			worldRoomSwapSlotReq.index = TargetSlotInfo.index;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomSwapSlotReq>(ServerType.GATE_SERVER, worldRoomSwapSlotReq);
		}

		// Token: 0x0600BA41 RID: 47681 RVA: 0x002AF874 File Offset: 0x002ADC74
		public void SendClosePosReq(byte group, byte index)
		{
			WorldRoomCloseSlotReq worldRoomCloseSlotReq = new WorldRoomCloseSlotReq();
			worldRoomCloseSlotReq.slotGroup = group;
			worldRoomCloseSlotReq.index = index;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomCloseSlotReq>(ServerType.GATE_SERVER, worldRoomCloseSlotReq);
		}

		// Token: 0x0600BA42 RID: 47682 RVA: 0x002AF8A4 File Offset: 0x002ADCA4
		private void SendAgreeChangePosReq(bool bAgree)
		{
			WorldRoomResponseSwapSlotReq worldRoomResponseSwapSlotReq = new WorldRoomResponseSwapSlotReq();
			if (bAgree)
			{
				worldRoomResponseSwapSlotReq.isAccept = 1;
			}
			else
			{
				worldRoomResponseSwapSlotReq.isAccept = 0;
			}
			worldRoomResponseSwapSlotReq.slotGroup = this.SwapSlotInfo.slotGroup;
			worldRoomResponseSwapSlotReq.slotIndex = this.SwapSlotInfo.slotIndex;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomResponseSwapSlotReq>(ServerType.GATE_SERVER, worldRoomResponseSwapSlotReq);
		}

		// Token: 0x0600BA43 RID: 47683 RVA: 0x002AF904 File Offset: 0x002ADD04
		public void SwitchToPk3v3Scene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(true);
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 5006,
				targetDoorID = 0
			}, false));
		}

		// Token: 0x0600BA44 RID: 47684 RVA: 0x002AF9F9 File Offset: 0x002ADDF9
		public RoomInfo GetRoomInfo()
		{
			return Pk3v3DataManager.roomInfo;
		}

		// Token: 0x0600BA45 RID: 47685 RVA: 0x002AFA00 File Offset: 0x002ADE00
		public List<WorldSyncRoomInviteInfo> GetInviteRoomList()
		{
			List<WorldSyncRoomInviteInfo> list = new List<WorldSyncRoomInviteInfo>();
			if (list == null)
			{
				return null;
			}
			if (this.InviteRoomList == null)
			{
				return list;
			}
			list.AddRange(this.InviteRoomList);
			return list;
		}

		// Token: 0x0600BA46 RID: 47686 RVA: 0x002AFA38 File Offset: 0x002ADE38
		public void RemoveInviteInfo(int index)
		{
			if (this.InviteRoomList == null)
			{
				return;
			}
			if (index < 0 || index >= this.InviteRoomList.Count)
			{
				return;
			}
			WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = this.InviteRoomList[index];
			this.InviteRoomList.RemoveAt(index);
			if (worldSyncRoomInviteInfo != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
			}
		}

		// Token: 0x0600BA47 RID: 47687 RVA: 0x002AFAA8 File Offset: 0x002ADEA8
		public void RemoveInviteInfo(WorldSyncRoomInviteInfo info)
		{
			if (this.InviteRoomList == null || info == null)
			{
				return;
			}
			this.RemoveInviteInfo(this.InviteRoomList.FindIndex((WorldSyncRoomInviteInfo temp) => temp.inviterId == info.inviterId));
		}

		// Token: 0x0600BA48 RID: 47688 RVA: 0x002AFAF8 File Offset: 0x002ADEF8
		public void ClearAllInviteInfo()
		{
			if (this.InviteRoomList == null)
			{
				return;
			}
			if (this.InviteRoomList.Count > 0)
			{
				WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = this.InviteRoomList[0];
				this.InviteRoomList.Clear();
				if (worldSyncRoomInviteInfo != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
				}
			}
		}

		// Token: 0x0600BA49 RID: 47689 RVA: 0x002AFB60 File Offset: 0x002ADF60
		public static bool HasInPk3v3Room()
		{
			if (Pk3v3DataManager.roomInfo == null)
			{
				return false;
			}
			if (Pk3v3DataManager.roomInfo.roomSlotInfos == null)
			{
				return false;
			}
			for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BA4A RID: 47690 RVA: 0x002AFBCC File Offset: 0x002ADFCC
		public bool CheckIsInMyRoom(ulong uId)
		{
			if (Pk3v3DataManager.roomInfo == null || Pk3v3DataManager.roomInfo.roomSlotInfos == null)
			{
				return false;
			}
			for (int i = 0; i < Pk3v3DataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3DataManager.roomInfo.roomSlotInfos[i].playerId == uId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BA4B RID: 47691 RVA: 0x002AFC2B File Offset: 0x002AE02B
		public bool CheckRoomIsMatching()
		{
			if (Pk3v3DataManager.roomInfo == null)
			{
				return false;
			}
			if (Pk3v3DataManager.roomInfo.roomSimpleInfo.roomStatus == 3)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("房间正在匹配中,无法进行操作", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return true;
			}
			return false;
		}

		// Token: 0x0600BA4C RID: 47692 RVA: 0x002AFC5D File Offset: 0x002AE05D
		public static bool checkCanJump()
		{
			Logger.LogErrorFormat("checkCanJump", new object[0]);
			return true;
		}

		// Token: 0x0600BA4D RID: 47693 RVA: 0x002AFC70 File Offset: 0x002AE070
		public static void AcceptJoinPk3v3RoomLink(string param)
		{
			string[] array = param.Split(new char[]
			{
				'|'
			});
			if (array == null || array.Length != 2)
			{
				return;
			}
			int num = 0;
			long num2 = 0L;
			if (!int.TryParse(array[0], out num) || !long.TryParse(array[1], out num2))
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("你已经在房间里了", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE && PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
			{
				SystemNotifyManager.SystemNotify(9307, string.Empty);
				return;
			}
			if (num <= 0)
			{
				return;
			}
			Pk3v3DataManager.SendJoinRoomReq((uint)num, RoomType.ROOM_TYPE_THREE_FREE, string.Empty, (uint)num2);
		}

		// Token: 0x0600BA4E RID: 47694 RVA: 0x002AFD80 File Offset: 0x002AE180
		public static void AcceptJoinPk3v3MeleeRoomLink(string param)
		{
			string[] array = param.Split(new char[]
			{
				'|'
			});
			if (array == null || array.Length != 2)
			{
				return;
			}
			int num = 0;
			long num2 = 0L;
			if (!int.TryParse(array[0], out num) || !long.TryParse(array[1], out num2))
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("你已经在房间里了", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE && PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
			{
				SystemNotifyManager.SystemNotify(9307, string.Empty);
				return;
			}
			if (num <= 0)
			{
				return;
			}
			Pk3v3DataManager.SendJoinRoomReq((uint)num, RoomType.ROOM_TYPE_MELEE, string.Empty, (uint)num2);
		}

		// Token: 0x0600BA4F RID: 47695 RVA: 0x002AFE80 File Offset: 0x002AE280
		public string GetRoomState(RoomStatus roomstatus)
		{
			if (roomstatus == RoomStatus.ROOM_STATUS_BATTLE || roomstatus == RoomStatus.ROOM_STATUS_MATCH || roomstatus == RoomStatus.ROOM_STATUS_READY)
			{
				return "<color=#f0cd0dff>决斗中</color>";
			}
			if (roomstatus == RoomStatus.ROOM_STATUS_OPEN)
			{
				return "<color=#ffffffff>未开始</color>";
			}
			return "异常";
		}

		// Token: 0x0600BA50 RID: 47696 RVA: 0x002AFEAF File Offset: 0x002AE2AF
		public string GetRoomType(RoomType roomtype)
		{
			if (roomtype == RoomType.ROOM_TYPE_THREE_FREE)
			{
				return "娱乐";
			}
			if (roomtype == RoomType.ROOM_TYPE_THREE_MATCH)
			{
				return "段位";
			}
			if (roomtype == RoomType.ROOM_TYPE_MELEE)
			{
				return "乱斗";
			}
			return "异常";
		}

		// Token: 0x0600BA51 RID: 47697 RVA: 0x002AFEE0 File Offset: 0x002AE2E0
		public int GetRankLvByIndex(int iIndex)
		{
			if (iIndex == 0)
			{
				return DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
			}
			if (iIndex == 1)
			{
				return 24501;
			}
			if (iIndex == 2)
			{
				return 34501;
			}
			if (iIndex == 3)
			{
				return 44501;
			}
			if (iIndex == 4)
			{
				return 54501;
			}
			return DataManager<SeasonDataManager>.GetInstance().GetMaxRankID();
		}

		// Token: 0x0600BA52 RID: 47698 RVA: 0x002AFF3C File Offset: 0x002AE33C
		public int RandPassWord()
		{
			return Random.Range(1000, 9999);
		}

		// Token: 0x0600BA53 RID: 47699 RVA: 0x002AFF4D File Offset: 0x002AE34D
		public string GetPk3v3LocalDataKey(RoomType roomType, string key)
		{
			return string.Format("{0}_3v3_{1}_{2}", DataManager<PlayerBaseData>.GetInstance().RoleID, roomType, key);
		}

		// Token: 0x040068A7 RID: 26791
		private bool m_bNetBind;

		// Token: 0x040068A8 RID: 26792
		private Dictionary<RoomType, Pk3v3RoomSettingData> roomSettingData = new Dictionary<RoomType, Pk3v3RoomSettingData>();

		// Token: 0x040068A9 RID: 26793
		public bool bHasPassword;

		// Token: 0x040068AA RID: 26794
		public string PassWord = string.Empty;

		// Token: 0x040068AB RID: 26795
		private WorldSyncRoomSwapSlotInfo SwapSlotInfo = new WorldSyncRoomSwapSlotInfo();

		// Token: 0x040068AC RID: 26796
		private float fChangePosLastTime;

		// Token: 0x040068AD RID: 26797
		private float fAddUpTime;

		// Token: 0x040068AE RID: 26798
		private float fChangePosLocationTime;

		// Token: 0x040068AF RID: 26799
		public int iInt;

		// Token: 0x040068B0 RID: 26800
		private bool m_bNotify;

		// Token: 0x040068B1 RID: 26801
		private int simpleInviteLastTime = -1;

		// Token: 0x040068B2 RID: 26802
		private static RoomInfo roomInfo = new RoomInfo();

		// Token: 0x040068B3 RID: 26803
		private List<WorldSyncRoomInviteInfo> InviteRoomList = new List<WorldSyncRoomInviteInfo>();
	}
}
