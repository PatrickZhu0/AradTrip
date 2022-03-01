using System;
using System.Collections.Generic;
using GamePool;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020019E9 RID: 6633
	public class RelationDataManager : DataManager<RelationDataManager>
	{
		// Token: 0x17001D3A RID: 7482
		// (get) Token: 0x060103E0 RID: 66528 RVA: 0x0048B788 File Offset: 0x00489B88
		public List<SceneSyncRequest> FriendsPlayInviteList
		{
			get
			{
				return this.m_friendsPlayInviteList;
			}
		}

		// Token: 0x17001D3B RID: 7483
		// (get) Token: 0x060103E1 RID: 66529 RVA: 0x0048B790 File Offset: 0x00489B90
		public List<RelationData> ApplyPupils
		{
			get
			{
				return this.m_apply_pupils;
			}
		}

		// Token: 0x17001D3C RID: 7484
		// (get) Token: 0x060103E2 RID: 66530 RVA: 0x0048B798 File Offset: 0x00489B98
		public List<RelationData> ApplyTeachers
		{
			get
			{
				return this.m_apply_teachers;
			}
		}

		// Token: 0x17001D3D RID: 7485
		// (get) Token: 0x060103E3 RID: 66531 RVA: 0x0048B7A0 File Offset: 0x00489BA0
		public List<RelationData> SearchedTeacherList
		{
			get
			{
				this.m_recommand_teachres.RemoveAll(delegate(RelationData x)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(x.uid);
					return relationByRoleID != null && (relationByRoleID.type == 5 || relationByRoleID.type == 4);
				});
				return this.m_recommand_teachres;
			}
		}

		// Token: 0x060103E4 RID: 66532 RVA: 0x0048B7D1 File Offset: 0x00489BD1
		public void SetQueryedTeacherInfo(RelationData info)
		{
			this.m_recommand_teachres.Clear();
			this.m_recommand_teachres.Add(info);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSearchedTeacherListChanged, null, null, null, null);
		}

		// Token: 0x17001D3E RID: 7486
		// (get) Token: 0x060103E5 RID: 66533 RVA: 0x0048B7FD File Offset: 0x00489BFD
		public List<RelationData> SearchedPupilList
		{
			get
			{
				this.m_recommand_pupils.RemoveAll(delegate(RelationData x)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(x.uid);
					return relationByRoleID != null && (relationByRoleID.type == 5 || relationByRoleID.type == 4);
				});
				return this.m_recommand_pupils;
			}
		}

		// Token: 0x060103E6 RID: 66534 RVA: 0x0048B830 File Offset: 0x00489C30
		public string GetFriendlyDegreesIntervalName(int intimacy)
		{
			for (int i = 0; i < this.m_friendDegreesIntervalList.Count; i++)
			{
				FriendlyDegreesIntervalNameModel friendlyDegreesIntervalNameModel = this.m_friendDegreesIntervalList[i];
				if (intimacy > friendlyDegreesIntervalNameModel.minLevel && intimacy <= friendlyDegreesIntervalNameModel.maxLevel)
				{
					return friendlyDegreesIntervalNameModel.name;
				}
				if (i == this.m_friendDegreesIntervalList.Count - 1 && intimacy > friendlyDegreesIntervalNameModel.minLevel)
				{
					return friendlyDegreesIntervalNameModel.name;
				}
			}
			return string.Empty;
		}

		// Token: 0x060103E7 RID: 66535 RVA: 0x0048B8B0 File Offset: 0x00489CB0
		private void _InitFriendWelfareAddTable()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<FriendWelfareAddTable>())
			{
				FriendWelfareAddTable friendWelfareAddTable = keyValuePair.Value as FriendWelfareAddTable;
				if (friendWelfareAddTable == null)
				{
					return;
				}
				int minLevel = 0;
				int maxLevel = 0;
				string name = string.Empty;
				if (friendWelfareAddTable.IntimacySpan.Length > 0)
				{
					string[] array = friendWelfareAddTable.IntimacySpan.Split(new char[]
					{
						'|'
					});
					if (array == null)
					{
						return;
					}
					int.TryParse(array[0], out minLevel);
					int.TryParse(array[1], out maxLevel);
					name = friendWelfareAddTable.IntimacyName;
				}
				FriendlyDegreesIntervalNameModel item = new FriendlyDegreesIntervalNameModel(minLevel, maxLevel, name);
				this.m_friendDegreesIntervalList.Add(item);
			}
		}

		// Token: 0x060103E8 RID: 66536 RVA: 0x0048B970 File Offset: 0x00489D70
		private void _BindNetMessage()
		{
			NetProcess.AddMsgHandler(601708U, new Action<MsgDATA>(this._OnSyncRelationList));
			NetProcess.AddMsgHandler(601715U, new Action<MsgDATA>(this.OnRecvPlayerOnLineStatusChanged));
			NetProcess.AddMsgHandler(601707U, new Action<MsgDATA>(this._OnSyncRelationData));
			NetProcess.AddMsgHandler(601705U, new Action<MsgDATA>(this._OnNewRelation));
			NetProcess.AddMsgHandler(601706U, new Action<MsgDATA>(this._OnDelRelation));
			NetProcess.AddMsgHandler(601710U, new Action<MsgDATA>(this._OnRecommendFindRet));
			NetProcess.AddMsgHandler(601713U, new Action<MsgDATA>(this._OnSyncOffline));
			NetProcess.AddMsgHandler(500805U, new Action<MsgDATA>(this._OnSyncRequest));
			NetProcess.AddMsgHandler(601738U, new Action<MsgDATA>(this._OnSetPlayerRemarkRet));
		}

		// Token: 0x060103E9 RID: 66537 RVA: 0x0048BA44 File Offset: 0x00489E44
		private void _UnBindNetMessage()
		{
			NetProcess.RemoveMsgHandler(601708U, new Action<MsgDATA>(this._OnSyncRelationList));
			NetProcess.RemoveMsgHandler(601715U, new Action<MsgDATA>(this.OnRecvPlayerOnLineStatusChanged));
			NetProcess.RemoveMsgHandler(601707U, new Action<MsgDATA>(this._OnSyncRelationData));
			NetProcess.RemoveMsgHandler(601705U, new Action<MsgDATA>(this._OnNewRelation));
			NetProcess.RemoveMsgHandler(601706U, new Action<MsgDATA>(this._OnDelRelation));
			NetProcess.RemoveMsgHandler(601710U, new Action<MsgDATA>(this._OnRecommendFindRet));
			NetProcess.RemoveMsgHandler(601713U, new Action<MsgDATA>(this._OnSyncOffline));
			NetProcess.RemoveMsgHandler(500805U, new Action<MsgDATA>(this._OnSyncRequest));
			NetProcess.RemoveMsgHandler(601738U, new Action<MsgDATA>(this._OnSetPlayerRemarkRet));
		}

		// Token: 0x060103EA RID: 66538 RVA: 0x0048BB18 File Offset: 0x00489F18
		private void _OnSyncRelationList(MsgDATA msg)
		{
			int num = 0;
			List<Relation> list = RelationDecoder.DecodeList(msg.bytes, ref num, msg.bytes.Length);
			for (int i = 0; i < list.Count; i++)
			{
				RelationData relationData = this._CreateLocalData(list[i]);
				this._AddRelation(relationData);
				this._UpdatePriChatListRelation(relationData);
				byte type = list[i].type;
				if (!this.m_typeRelations.ContainsKey((RelationType)type))
				{
					this.m_typeRelations.Add((RelationType)type, new List<ulong>());
				}
				this.m_typeRelations[(RelationType)type].Add(relationData.uid);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRelationChanged, relationData, false, null, null);
			}
		}

		// Token: 0x060103EB RID: 66539 RVA: 0x0048BBD8 File Offset: 0x00489FD8
		protected void _OnSyncRelationData(MsgDATA msg)
		{
			int num = 0;
			Relation relation = RelationDecoder.DecodeData(msg.bytes, ref num, msg.bytes.Length);
			RelationData relationData = null;
			this.m_relationsDict.TryGetValue(relation.uid, out relationData);
			if (relationData == null)
			{
				Logger.LogErrorFormat("_OnSyncRelationData recv data is null! {0}", new object[]
				{
					relation.uid
				});
			}
			else
			{
				this._UpdateLocalData(relation, ref relationData);
				this._UpdatePriChatListRelation(relationData);
				if (relationData.type == 4 || relationData.type == 5)
				{
					DataManager<TAPDataManager>.GetInstance().RemoveQueryInfo(relationData.uid);
					DataManager<TAPDataManager>.GetInstance().RemoveApplyedPupil(relationData.uid);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRelationChanged, relationData, false, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshFriendList, null, null, null, null);
		}

		// Token: 0x060103EC RID: 66540 RVA: 0x0048BCB0 File Offset: 0x0048A0B0
		protected void _OnNewRelation(MsgDATA msg)
		{
			int num = 0;
			Relation relation = RelationDecoder.DecodeNew(msg.bytes, ref num, msg.bytes.Length);
			RelationData relationData = null;
			this.m_relationsDict.TryGetValue(relation.uid, out relationData);
			if (relationData == null)
			{
				relationData = this._CreateLocalData(relation);
				this._AddRelation(relationData);
				this.DelInviter(relationData.uid);
				if (!this.m_typeRelations.ContainsKey((RelationType)relationData.type))
				{
					this.m_typeRelations.Add((RelationType)relationData.type, new List<ulong>());
				}
				this.m_typeRelations[(RelationType)relationData.type].Add(relationData.uid);
				this._UpdatePriChatListRelation(relationData);
				if (relationData.type == 4 || relationData.type == 5)
				{
					DataManager<TAPDataManager>.GetInstance().RemoveQueryInfo(relationData.uid);
					DataManager<TAPDataManager>.GetInstance().RemoveApplyedPupil(relationData.uid);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshFriendList, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRelationChanged, relationData, false, null, null);
			}
			else
			{
				Logger.LogError("_OnNewRelation recv data is not new!");
			}
		}

		// Token: 0x060103ED RID: 66541 RVA: 0x0048BDD0 File Offset: 0x0048A1D0
		protected void _OnDelRelation(MsgDATA msg)
		{
			int num = 0;
			WorldNotifyDelRelation worldNotifyDelRelation = new WorldNotifyDelRelation();
			worldNotifyDelRelation.decode(msg.bytes, ref num);
			this._RemoveRelation(worldNotifyDelRelation.id);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshFriendList, null, null, null, null);
		}

		// Token: 0x060103EE RID: 66542 RVA: 0x0048BE14 File Offset: 0x0048A214
		protected void _OnRecommendFindRet(MsgDATA msg)
		{
			int num = 0;
			WorldRelationFindPlayersRet worldRelationFindPlayersRet = new WorldRelationFindPlayersRet();
			worldRelationFindPlayersRet.decode(msg.bytes, ref num);
			RelationFindType type = (RelationFindType)worldRelationFindPlayersRet.type;
			if (type != RelationFindType.Friend)
			{
				if (type != RelationFindType.Master)
				{
					if (type == RelationFindType.Disciple)
					{
						this.m_recommand_pupils.Clear();
						for (int i = 0; i < worldRelationFindPlayersRet.friendList.Length; i++)
						{
							RelationData relationData = this._CreateLocalData(worldRelationFindPlayersRet.friendList[i]);
							if (relationData != null)
							{
								this.m_recommand_pupils.Add(relationData);
							}
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSearchedPupilListChanged, null, null, null, null);
					}
				}
				else
				{
					this.m_recommand_teachres.Clear();
					for (int j = 0; j < worldRelationFindPlayersRet.friendList.Length; j++)
					{
						RelationData relationData2 = this._CreateLocalData(worldRelationFindPlayersRet.friendList[j]);
						if (relationData2 != null)
						{
							this.m_recommand_teachres.Add(relationData2);
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSearchedTeacherListChanged, null, null, null, null);
				}
			}
			else
			{
				RelationData[] array = new RelationData[worldRelationFindPlayersRet.friendList.Length];
				for (int k = 0; k < worldRelationFindPlayersRet.friendList.Length; k++)
				{
					array[k] = this._CreateLocalData(worldRelationFindPlayersRet.friendList[k]);
				}
				UIEventSystem.GetInstance().SendUIEvent(new UIEventRecievRecommendFriend(array));
			}
		}

		// Token: 0x060103EF RID: 66543 RVA: 0x0048BF78 File Offset: 0x0048A378
		protected void _OnSyncOffline(MsgDATA msg)
		{
			int num = 0;
			WorldSyncOnOffline worldSyncOnOffline = new WorldSyncOnOffline();
			worldSyncOnOffline.decode(msg.bytes, ref num);
			RelationData relationData;
			this.m_relationsDict.TryGetValue(worldSyncOnOffline.id, out relationData);
			if (relationData != null)
			{
				relationData.isOnline = worldSyncOnOffline.isOnline;
				this._UpdatePriChatListRelation(relationData);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRelationChanged, relationData, false, null, null);
				if (relationData.type == 4 || relationData.type == 5)
				{
					SystemNotifyManager.SystemNotify((relationData.isOnline != 0) ? 8921 : 8924, new object[]
					{
						RelationDataManager.GetRelationDesc((RelationType)relationData.type),
						relationData.name
					});
				}
			}
		}

		// Token: 0x060103F0 RID: 66544 RVA: 0x0048C03C File Offset: 0x0048A43C
		protected void _OnSetPlayerRemarkRet(MsgDATA msg)
		{
			WorldSetPlayerRemarkRes worldSetPlayerRemarkRes = new WorldSetPlayerRemarkRes();
			worldSetPlayerRemarkRes.decode(msg.bytes);
			if (worldSetPlayerRemarkRes.code != 0U)
			{
				CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)worldSetPlayerRemarkRes.code, string.Empty, string.Empty);
				if (tableItem != null)
				{
					SystemNotifyManager.SysNotifyTextAnimation(tableItem.Descs, CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SetNoteNameSuccess, null, null, null, null);
			}
		}

		// Token: 0x060103F1 RID: 66545 RVA: 0x0048C0AC File Offset: 0x0048A4AC
		protected void _OnSyncRequest(MsgDATA msg)
		{
			if (msg == null)
			{
				Logger.LogError("_OnSyncRequest ==>> msg is nil");
				return;
			}
			SceneSyncRequest sceneSyncRequest = new SceneSyncRequest();
			sceneSyncRequest.decode(msg.bytes);
			RequestType type = (RequestType)sceneSyncRequest.type;
			switch (type)
			{
			case RequestType.InviteTeam:
				SystemNotifyManager.SysNotifyFloatingEffect("邀请发送成功", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				break;
			case RequestType.JoinTeam:
				break;
			case RequestType.RequestFriend:
				this.AddInviteFriendNotify(sceneSyncRequest);
				break;
			case RequestType.RequestMaster:
				this.AddApplyPupilNotify(sceneSyncRequest);
				break;
			case RequestType.RequestDisciple:
				this.AddApplyTeacherNotify(sceneSyncRequest);
				break;
			default:
				switch (type)
				{
				case RequestType.Request_Challenge_PK:
				{
					ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
					if (clientSystemTown != null)
					{
						CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.TRADITION)
							{
								this.m_friendsPlayInviteList.Add(sceneSyncRequest);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, null, null, null, null);
							}
						}
					}
					break;
				}
				case RequestType.Request_Equal_PK:
					this.FairDueleRequest(sceneSyncRequest);
					break;
				}
				break;
			}
		}

		// Token: 0x060103F2 RID: 66546 RVA: 0x0048C1D8 File Offset: 0x0048A5D8
		private void FairDueleRequest(SceneSyncRequest req)
		{
			if (req == null)
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
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.FairDuelPrepare)
			{
				return;
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			if (BattleMain.battleType == BattleType.Training || BattleMain.battleType == BattleType.TrainingPVE)
			{
				this.ReplyRequest(req, 0);
				return;
			}
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("fairduel_pkfriend_content"), req.requesterName),
				IsShowNotify = false,
				LeftButtonText = TR.Value("fairduel_pkfriend_cancel"),
				RightButtonText = TR.Value("fairduel_pkfriend_ok"),
				OnRightButtonClickCallBack = delegate()
				{
					this.ReplyRequest(req, 1);
				},
				OnLeftButtonClickCallBack = delegate()
				{
					this.ReplyRequest(req, 0);
				}
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x060103F3 RID: 66547 RVA: 0x0048C304 File Offset: 0x0048A704
		public void ReplyRequest(SceneSyncRequest req, byte reply)
		{
			SceneReply sceneReply = new SceneReply();
			sceneReply.type = req.type;
			sceneReply.requester = req.requester;
			sceneReply.result = reply;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
		}

		// Token: 0x060103F4 RID: 66548 RVA: 0x0048C345 File Offset: 0x0048A745
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.RelationDataManager;
		}

		// Token: 0x060103F5 RID: 66549 RVA: 0x0048C349 File Offset: 0x0048A749
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMessage();
			this.m_relationsDict = new Dictionary<ulong, RelationData>();
			this.m_typeRelations = new Dictionary<RelationType, List<ulong>>();
			this.m_inviteFriends = new List<InviteFriendData>();
			this.m_priChatList = new List<PrivateChatPlayerData>();
			this._InitFriendWelfareAddTable();
		}

		// Token: 0x060103F6 RID: 66550 RVA: 0x0048C38C File Offset: 0x0048A78C
		public override void Clear()
		{
			this._UnBindNetMessage();
			this.m_relationsDict = null;
			this.m_typeRelations = null;
			this.m_inviteFriends = null;
			this.m_priChatList = null;
			this.m_akQueriedIds.Clear();
			this.m_recommand_teachres.Clear();
			this.m_recommand_pupils.Clear();
			this.m_apply_pupils.Clear();
			this.m_apply_teachers.Clear();
			this.m_bHasNewApply = false;
			this.m_friendDegreesIntervalList.Clear();
			this.m_friendsPlayInviteList.Clear();
		}

		// Token: 0x060103F7 RID: 66551 RVA: 0x0048C40F File Offset: 0x0048A80F
		public void AddQueryInfo(ulong uid)
		{
			if (!this.m_akQueriedIds.Contains(uid))
			{
				this.m_akQueriedIds.Add(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryIntervalChanged, uid, null, null, null);
		}

		// Token: 0x060103F8 RID: 66552 RVA: 0x0048C446 File Offset: 0x0048A846
		public void RemoveQueryInfo(ulong uid)
		{
			if (this.m_akQueriedIds.Contains(uid))
			{
				this.m_akQueriedIds.Remove(uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryIntervalChanged, uid, null, null, null);
		}

		// Token: 0x060103F9 RID: 66553 RVA: 0x0048C47E File Offset: 0x0048A87E
		public void ClearQueryInfo()
		{
			this.m_akQueriedIds.Clear();
		}

		// Token: 0x060103FA RID: 66554 RVA: 0x0048C48B File Offset: 0x0048A88B
		public bool CanQuery(ulong uid)
		{
			return !this.m_akQueriedIds.Contains(uid);
		}

		// Token: 0x060103FB RID: 66555 RVA: 0x0048C49C File Offset: 0x0048A89C
		private void _UpdatePriChatListRelation(RelationData rd)
		{
			PrivateChatPlayerData privateChatPlayerData = this.m_priChatList.Find((PrivateChatPlayerData x) => x.relationData.uid == rd.uid);
			if (privateChatPlayerData != null)
			{
				privateChatPlayerData.relationData = rd;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePrivate, null, null, null, null);
		}

		// Token: 0x060103FC RID: 66556 RVA: 0x0048C4F3 File Offset: 0x0048A8F3
		public void OnAddPriChatList(RelationData rd, bool recv)
		{
			this.AddPriChatList(ref rd, recv);
		}

		// Token: 0x060103FD RID: 66557 RVA: 0x0048C4FE File Offset: 0x0048A8FE
		public void SetCurPriChatUid(ulong uid)
		{
			this.m_curPriChatUid = uid;
		}

		// Token: 0x060103FE RID: 66558 RVA: 0x0048C507 File Offset: 0x0048A907
		public void MarkDirty(ulong uid, bool bDirty)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RoleChatDirtyChanged, uid, bDirty, null, null);
		}

		// Token: 0x060103FF RID: 66559 RVA: 0x0048C528 File Offset: 0x0048A928
		public bool GetPriDirty()
		{
			if (this.m_priChatList != null)
			{
				for (int i = 0; i < this.m_priChatList.Count; i++)
				{
					if (this.m_priChatList[i].chatNum > 0)
					{
						return this.FilterNoRedPoint(this.m_priChatList[i].relationData);
					}
				}
			}
			return false;
		}

		// Token: 0x06010400 RID: 66560 RVA: 0x0048C58C File Offset: 0x0048A98C
		private bool FilterNoRedPoint(RelationData relationData)
		{
			if (relationData == null)
			{
				return false;
			}
			List<ChatBlock> privateChat = DataManager<ChatManager>.GetInstance().GetPrivateChat(relationData.uid);
			if (privateChat == null)
			{
				return false;
			}
			for (int i = 0; i < privateChat.Count; i++)
			{
				if (privateChat[i] != null)
				{
					ChatData chatData = privateChat[i].chatData;
					if (chatData != null)
					{
						if (!chatData.bNotHeadPoint)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06010401 RID: 66561 RVA: 0x0048C608 File Offset: 0x0048AA08
		public void SetRecentlyHaveRead()
		{
			if (this.m_priChatList != null)
			{
				for (int i = 0; i < this.m_priChatList.Count; i++)
				{
					if (this.m_priChatList[i].chatNum > 0)
					{
						RelationData relationData = this.m_priChatList[i].relationData;
						if (relationData != null)
						{
							if (relationData.isOnline < 1 && this.OnlySystemMsg(relationData))
							{
								this.ClearPriChatDirty(relationData.uid);
							}
						}
					}
				}
			}
		}

		// Token: 0x06010402 RID: 66562 RVA: 0x0048C694 File Offset: 0x0048AA94
		private bool OnlySystemMsg(RelationData data)
		{
			if (data == null)
			{
				return true;
			}
			List<ChatBlock> privateChat = DataManager<ChatManager>.GetInstance().GetPrivateChat(data.uid);
			if (privateChat != null)
			{
				for (int i = 0; i < privateChat.Count; i++)
				{
					if (privateChat[i] != null)
					{
						ChatData chatData = privateChat[i].chatData;
						if (chatData != null && !chatData.bAddFriend && !chatData.bRedPacket && !chatData.bSystem)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06010403 RID: 66563 RVA: 0x0048C71C File Offset: 0x0048AB1C
		public bool GetFriendPriDirty()
		{
			if (this.m_priChatList != null)
			{
				for (int i = 0; i < this.m_priChatList.Count; i++)
				{
					if (this.m_priChatList[i].chatNum > 0)
					{
						RelationData relationByRoleID = this.GetRelationByRoleID(this.m_priChatList[i].relationData.uid);
						if (relationByRoleID != null && relationByRoleID.type == 1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06010404 RID: 66564 RVA: 0x0048C7A4 File Offset: 0x0048ABA4
		public bool GetPriDirtyByUid(ulong uid)
		{
			if (this.m_priChatList != null)
			{
				for (int i = 0; i < this.m_priChatList.Count; i++)
				{
					if (uid == this.m_priChatList[i].relationData.uid && this.m_priChatList[i].chatNum > 0)
					{
						return this.FilterNoRedPoint(this.m_priChatList[i].relationData);
					}
				}
			}
			return false;
		}

		// Token: 0x06010405 RID: 66565 RVA: 0x0048C824 File Offset: 0x0048AC24
		public void ClearPriChatDirty(ulong uid)
		{
			this.m_curPriChatUid = uid;
			for (int i = 0; i < this.m_priChatList.Count; i++)
			{
				if (this.m_priChatList[i].relationData.uid == uid)
				{
					this.m_priChatList[i].chatNum = 0;
					this.MarkDirty(uid, false);
					return;
				}
			}
		}

		// Token: 0x06010406 RID: 66566 RVA: 0x0048C88C File Offset: 0x0048AC8C
		public void DelPriChat(ulong uid)
		{
			PrivateChatPlayerData privateChatPlayerData = this.m_priChatList.Find((PrivateChatPlayerData x) => x.relationData.uid == uid);
			if (privateChatPlayerData != null)
			{
				DataManager<ChatRecordManager>.GetInstance().RemoveChatRecords(DataManager<PlayerBaseData>.GetInstance().RoleID, uid);
				DataManager<ChatManager>.GetInstance().RemovePrivateChatData(uid);
				UIEventSystem.GetInstance().SendUIEvent(new UIEventDelPrivate(uid));
			}
		}

		// Token: 0x06010407 RID: 66567 RVA: 0x0048C904 File Offset: 0x0048AD04
		public static string GetRelationDesc(RelationType eRelation)
		{
			switch (eRelation)
			{
			case RelationType.RELATION_FRIEND:
				return TR.Value("relation_desc_friend");
			case RelationType.RELATION_BLACKLIST:
				return TR.Value("relation_desc_black");
			case RelationType.RELATION_STRANGER:
				return TR.Value("relation_desc_stranger");
			case RelationType.RELATION_MASTER:
				return TR.Value("relation_desc_teacher");
			case RelationType.RELATION_DISCIPLE:
				return TR.Value("relation_desc_pupil");
			default:
				return TR.Value("relation_desc_none");
			}
		}

		// Token: 0x06010408 RID: 66568 RVA: 0x0048C974 File Offset: 0x0048AD74
		private void AddPriChatList(ref RelationData rd, bool recv)
		{
			if (rd == null)
			{
				return;
			}
			bool flag = false;
			int index = 0;
			for (int i = 0; i < this.m_priChatList.Count; i++)
			{
				if (this.m_priChatList[i].relationData.uid == rd.uid)
				{
					this.m_priChatList[i].relationData = rd;
					if (recv)
					{
						this.m_priChatList[i].chatNum++;
						this.MarkDirty(rd.uid, true);
					}
					flag = true;
					index = i;
					break;
				}
			}
			if (!flag)
			{
				if (this.m_priChatList.Count >= 50)
				{
					this.m_priChatList.RemoveAt(0);
				}
				PrivateChatPlayerData privateChatPlayerData = new PrivateChatPlayerData();
				privateChatPlayerData.relationData = rd;
				if (recv)
				{
					privateChatPlayerData.chatNum++;
					this.MarkDirty(rd.uid, true);
				}
				this.m_priChatList.Add(privateChatPlayerData);
				if (this.m_priChatList.Count >= 50)
				{
					privateChatPlayerData.iOrder = this.m_priChatList[this.m_priChatList.Count - 2].iOrder + 1;
				}
				else
				{
					privateChatPlayerData.iOrder = this.m_priChatList.Count;
				}
			}
			else
			{
				int iOrder = this.m_priChatList[this.m_priChatList.Count - 1].iOrder + 1;
				this.m_priChatList[index].iOrder = iOrder;
				PrivateChatPlayerData value = this.m_priChatList[index];
				this.m_priChatList[index] = this.m_priChatList[0];
				this.m_priChatList[0] = value;
			}
			if (recv && rd.uid != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(rd, true));
			}
		}

		// Token: 0x06010409 RID: 66569 RVA: 0x0048CB5C File Offset: 0x0048AF5C
		public List<PrivateChatPlayerData> GetPriChatList()
		{
			for (int i = 0; i < this.m_priChatList.Count; i++)
			{
				if (this.m_priChatList[i].relationData.type == 2)
				{
					this.m_priChatList.Remove(this.m_priChatList[i]);
				}
			}
			return this.m_priChatList;
		}

		// Token: 0x0601040A RID: 66570 RVA: 0x0048CBC0 File Offset: 0x0048AFC0
		public bool HasTeacher()
		{
			List<RelationData> relation = this.GetRelation(4);
			return relation != null && relation.Count > 0 && null != relation[0];
		}

		// Token: 0x0601040B RID: 66571 RVA: 0x0048CBF8 File Offset: 0x0048AFF8
		public RelationData GetTeacher()
		{
			List<RelationData> relation = this.GetRelation(4);
			if (relation != null && relation.Count > 0)
			{
				return relation[0];
			}
			return null;
		}

		// Token: 0x0601040C RID: 66572 RVA: 0x0048CC28 File Offset: 0x0048B028
		public void RemoveApplyPupil(ulong guid)
		{
			RelationData relationData = this.m_apply_pupils.Find((RelationData x) => x.uid == guid);
			if (relationData != null)
			{
				this.m_apply_pupils.Remove(relationData);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyPupilListChanged, null, null, null, null);
			}
		}

		// Token: 0x0601040D RID: 66573 RVA: 0x0048CC80 File Offset: 0x0048B080
		public void RemoveApplyTeacher(ulong guid)
		{
			RelationData relationData = this.m_apply_teachers.Find((RelationData x) => x.uid == guid);
			if (relationData != null)
			{
				this.m_apply_teachers.Remove(relationData);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyTeacherListChanged, null, null, null, null);
			}
		}

		// Token: 0x0601040E RID: 66574 RVA: 0x0048CCD8 File Offset: 0x0048B0D8
		public void AcceptApplyPupils(ulong uid)
		{
			SceneReply sceneReply = new SceneReply();
			sceneReply.type = 4;
			sceneReply.requester = uid;
			sceneReply.result = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
		}

		// Token: 0x0601040F RID: 66575 RVA: 0x0048CD10 File Offset: 0x0048B110
		public static void AcceptApplyTeachers(string param)
		{
			if (string.IsNullOrEmpty(param))
			{
				return;
			}
			ulong uid = 0UL;
			if (!ulong.TryParse(param, out uid))
			{
				return;
			}
			DataManager<RelationDataManager>.GetInstance()._AcceptApplyTeachers(uid);
		}

		// Token: 0x06010410 RID: 66576 RVA: 0x0048CD48 File Offset: 0x0048B148
		public void _AcceptApplyTeachers(ulong uid)
		{
			SceneReply sceneReply = new SceneReply();
			sceneReply.type = 5;
			sceneReply.requester = uid;
			sceneReply.result = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
		}

		// Token: 0x06010411 RID: 66577 RVA: 0x0048CD80 File Offset: 0x0048B180
		public void RefuseApplyPupils(ulong[] uids)
		{
			if (uids != null)
			{
				for (int i = 0; i < uids.Length; i++)
				{
					SceneReply sceneReply = new SceneReply();
					sceneReply.type = 5;
					sceneReply.requester = uids[i];
					sceneReply.result = 0;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
				}
			}
		}

		// Token: 0x06010412 RID: 66578 RVA: 0x0048CDD4 File Offset: 0x0048B1D4
		public void RefuseApplyTeachers(ulong[] uids)
		{
			if (uids != null)
			{
				for (int i = 0; i < uids.Length; i++)
				{
					SceneReply sceneReply = new SceneReply();
					sceneReply.type = 4;
					sceneReply.requester = uids[i];
					sceneReply.result = 0;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
				}
			}
		}

		// Token: 0x06010413 RID: 66579 RVA: 0x0048CE28 File Offset: 0x0048B228
		public void RefuseAllApplyPupils()
		{
			List<ulong> list = ListPool<ulong>.Get();
			for (int i = 0; i < this.m_apply_pupils.Count; i++)
			{
				RelationData relationData = this.m_apply_pupils[i];
				if (relationData != null)
				{
					list.Add(relationData.uid);
				}
			}
			this.RefuseApplyPupils(list.ToArray());
			ListPool<ulong>.Release(list);
			this.m_apply_pupils.Clear();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyPupilListChanged, null, null, null, null);
		}

		// Token: 0x06010414 RID: 66580 RVA: 0x0048CEA8 File Offset: 0x0048B2A8
		public void RefuseAllApplyTeachers()
		{
			List<ulong> list = ListPool<ulong>.Get();
			for (int i = 0; i < this.m_apply_teachers.Count; i++)
			{
				RelationData relationData = this.m_apply_teachers[i];
				if (relationData != null)
				{
					list.Add(relationData.uid);
				}
			}
			this.RefuseApplyTeachers(list.ToArray());
			ListPool<ulong>.Release(list);
			this.m_apply_teachers.Clear();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyTeacherListChanged, null, null, null, null);
		}

		// Token: 0x06010415 RID: 66581 RVA: 0x0048CF28 File Offset: 0x0048B328
		public void MakeDebugSearchTeacherListData()
		{
			this.SearchedTeacherList.Clear();
			this.SearchedTeacherList.Add(new RelationData
			{
				uid = 15888UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "make a nice life,forget passed life!"
			});
			this.SearchedTeacherList.Add(new RelationData
			{
				uid = 15889UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "how pretty the dog is !"
			});
			this.SearchedTeacherList.Add(new RelationData
			{
				uid = 15890UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "what a nice girl!"
			});
		}

		// Token: 0x06010416 RID: 66582 RVA: 0x0048D0DC File Offset: 0x0048B4DC
		public void MakeDebugApplyPupilDatas()
		{
			this.m_apply_pupils.Clear();
			this.m_apply_pupils.Add(new RelationData
			{
				uid = 15888UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "make a nice life,forget passed life!"
			});
			this.m_apply_pupils.Add(new RelationData
			{
				uid = 15889UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "how pretty the dog is !"
			});
			this.m_apply_pupils.Add(new RelationData
			{
				uid = 15890UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "what a nice girl!"
			});
		}

		// Token: 0x06010417 RID: 66583 RVA: 0x0048D290 File Offset: 0x0048B690
		public void MakeDebugSearchedPupilListData()
		{
			this.m_recommand_pupils.Clear();
			this.m_recommand_pupils.Add(new RelationData
			{
				uid = 15888UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "make a nice life,forget passed life!"
			});
			this.m_recommand_pupils.Add(new RelationData
			{
				uid = 15889UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "how pretty the dog is !"
			});
			this.m_recommand_pupils.Add(new RelationData
			{
				uid = 15890UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0,
				announcement = "what a nice girl!"
			});
		}

		// Token: 0x06010418 RID: 66584 RVA: 0x0048D444 File Offset: 0x0048B844
		public void MakeDebugPupilDatas()
		{
			this._AddRelation(new RelationData
			{
				uid = 15888UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0
			});
			this._AddRelation(new RelationData
			{
				uid = 15889UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0
			});
			this._AddRelation(new RelationData
			{
				uid = 15890UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0
			});
			this._AddRelation(new RelationData
			{
				uid = 15888UL,
				name = DataManager<PlayerBaseData>.GetInstance().Name,
				seasonLv = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel,
				level = DataManager<PlayerBaseData>.GetInstance().Level,
				occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
				vipLv = (byte)DataManager<PlayerBaseData>.GetInstance().VipLevel,
				type = 5,
				status = 0
			});
		}

		// Token: 0x06010419 RID: 66585 RVA: 0x0048D63C File Offset: 0x0048BA3C
		public List<RelationData> GetRelation(byte type)
		{
			List<RelationData> list = new List<RelationData>();
			if (this.m_relationsDict != null)
			{
				foreach (KeyValuePair<ulong, RelationData> keyValuePair in this.m_relationsDict)
				{
					RelationData value = keyValuePair.Value;
					if (value != null)
					{
						if (value.type == type)
						{
							list.Add(value);
						}
					}
				}
			}
			list.Sort(new Comparison<RelationData>(this.SortList));
			return list;
		}

		// Token: 0x0601041A RID: 66586 RVA: 0x0048D6B8 File Offset: 0x0048BAB8
		public bool FindPlayerIsRelation(ulong uid, ref RelationData relationData)
		{
			List<RelationData> relation = this.GetRelation(1);
			List<RelationData> relation2 = this.GetRelation(4);
			List<RelationData> relation3 = this.GetRelation(5);
			List<RelationData> list = new List<RelationData>();
			list.AddRange(relation2);
			list.AddRange(relation3);
			list.AddRange(relation);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].uid == uid)
				{
					relationData = list[i];
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601041B RID: 66587 RVA: 0x0048D738 File Offset: 0x0048BB38
		private int SortList(RelationData a, RelationData b)
		{
			if (a.isOnline > b.isOnline)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x0601041C RID: 66588 RVA: 0x0048D750 File Offset: 0x0048BB50
		public RelationData GetRelationByRoleID(ulong uid)
		{
			RelationData result = null;
			if (this.m_relationsDict != null && this.m_relationsDict.TryGetValue(uid, out result))
			{
				return result;
			}
			return result;
		}

		// Token: 0x0601041D RID: 66589 RVA: 0x0048D780 File Offset: 0x0048BB80
		public void AddInviteFriendNotify(SceneSyncRequest req)
		{
			InviteFriendData inviteFriendData = new InviteFriendData();
			inviteFriendData.requester = req.requester;
			inviteFriendData.requesterName = req.requesterName;
			inviteFriendData.requesterLevel = req.requesterLevel;
			inviteFriendData.requesterOccu = req.requesterOccu;
			inviteFriendData.vipLv = req.requesterVipLv;
			bool flag = false;
			for (int i = 0; i < this.m_inviteFriends.Count; i++)
			{
				if (this.m_inviteFriends[i].requester == inviteFriendData.requester)
				{
					this.m_inviteFriends[i] = inviteFriendData;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (this.m_inviteFriends.Count >= 30)
				{
					this.m_inviteFriends.RemoveAt(0);
				}
				this.m_inviteFriends.Add(inviteFriendData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FriendRequestNoticeUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshInviteList, null, null, null, null);
		}

		// Token: 0x17001D3F RID: 7487
		// (get) Token: 0x0601041E RID: 66590 RVA: 0x0048D873 File Offset: 0x0048BC73
		public bool HasNewApply
		{
			get
			{
				return this.m_bHasNewApply;
			}
		}

		// Token: 0x0601041F RID: 66591 RVA: 0x0048D87C File Offset: 0x0048BC7C
		public void AddApplyPupilNotify(SceneSyncRequest req)
		{
			RelationData relationData = new RelationData();
			relationData.uid = req.requester;
			relationData.name = req.requesterName;
			relationData.level = req.requesterLevel;
			relationData.occu = req.requesterOccu;
			relationData.vipLv = req.requesterVipLv;
			relationData.type = 3;
			relationData.avatar = req.avatar;
			relationData.activeTimeType = req.activeTimeType;
			relationData.masterType = req.masterType;
			relationData.regionId = req.regionId;
			relationData.declaration = req.declaration;
			bool flag = false;
			for (int i = 0; i < this.m_apply_pupils.Count; i++)
			{
				if (this.m_apply_pupils[i].uid == relationData.uid)
				{
					this.m_apply_pupils[i] = relationData;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (this.m_apply_pupils.Count >= 30)
				{
					this.m_apply_pupils.RemoveAt(0);
				}
				this.m_apply_pupils.Add(relationData);
				this.m_bHasNewApply = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPupilApplyRecieved, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyPupilListChanged, null, null, null, null);
		}

		// Token: 0x06010420 RID: 66592 RVA: 0x0048D9BC File Offset: 0x0048BDBC
		public void AddApplyTeacherNotify(SceneSyncRequest req)
		{
			RelationData relationData = new RelationData();
			relationData.uid = req.requester;
			relationData.name = req.requesterName;
			relationData.level = req.requesterLevel;
			relationData.occu = req.requesterOccu;
			relationData.vipLv = req.requesterVipLv;
			relationData.type = 3;
			relationData.avatar = req.avatar;
			relationData.activeTimeType = req.activeTimeType;
			relationData.masterType = req.masterType;
			relationData.regionId = req.regionId;
			relationData.declaration = req.declaration;
			DataManager<ChatManager>.GetInstance().AddAskForPupilInvite(relationData, TR.Value("tap_invite_msg", relationData.uid), true);
			bool flag = false;
			for (int i = 0; i < this.m_apply_teachers.Count; i++)
			{
				if (this.m_apply_teachers[i].uid == relationData.uid)
				{
					this.m_apply_teachers[i] = relationData;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (this.m_apply_teachers.Count >= 30)
				{
					this.m_apply_teachers.RemoveAt(0);
				}
				this.m_apply_teachers.Add(relationData);
				this.m_bHasNewApply = true;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewTeacherApplyRecieved, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyTeacherListChanged, null, null, null, null);
		}

		// Token: 0x06010421 RID: 66593 RVA: 0x0048DB1A File Offset: 0x0048BF1A
		public void RemoveApplyPupilNotify()
		{
			this.m_bHasNewApply = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPupilApplyRecieved, null, null, null, null);
		}

		// Token: 0x17001D40 RID: 7488
		// (get) Token: 0x06010422 RID: 66594 RVA: 0x0048DB38 File Offset: 0x0048BF38
		public int maxFriendCount
		{
			get
			{
				int result = 0;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(281, string.Empty, string.Empty);
				if (tableItem != null)
				{
					result = tableItem.Value;
				}
				return result;
			}
		}

		// Token: 0x06010423 RID: 66595 RVA: 0x0048DB6F File Offset: 0x0048BF6F
		public List<InviteFriendData> GetInviteFriendData()
		{
			return this.m_inviteFriends;
		}

		// Token: 0x06010424 RID: 66596 RVA: 0x0048DB78 File Offset: 0x0048BF78
		public void DelInviter(ulong uid)
		{
			for (int i = 0; i < this.m_inviteFriends.Count; i++)
			{
				if (this.m_inviteFriends[i].requester == uid)
				{
					this.m_inviteFriends.RemoveAt(i);
					break;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshInviteList, null, null, null, null);
		}

		// Token: 0x06010425 RID: 66597 RVA: 0x0048DBDC File Offset: 0x0048BFDC
		public void DelAllInviter()
		{
			this.m_inviteFriends.Clear();
		}

		// Token: 0x06010426 RID: 66598 RVA: 0x0048DBEC File Offset: 0x0048BFEC
		public void OnPrivateChat(RelationData data)
		{
			RelationData relationData = this.GetRelationByRoleID(data.uid);
			if (relationData == null)
			{
				relationData = data;
				relationData.type = 3;
			}
			this.OnAddPriChatList(relationData, false);
			DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(data);
		}

		// Token: 0x06010427 RID: 66599 RVA: 0x0048DC2C File Offset: 0x0048C02C
		public void AddRelationByID(ulong uid, RequestType eRequestType)
		{
			if (eRequestType != RequestType.RequestMaster && eRequestType != RequestType.RequestDisciple)
			{
				Logger.LogErrorFormat("this request has not been suported !! {0}", new object[]
				{
					eRequestType
				});
			}
			else
			{
				SceneRequest sceneRequest = new SceneRequest();
				sceneRequest.type = (byte)eRequestType;
				sceneRequest.targetName = string.Empty;
				sceneRequest.target = uid;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			}
		}

		// Token: 0x06010428 RID: 66600 RVA: 0x0048DCA0 File Offset: 0x0048C0A0
		public void AddFriendByName(string name)
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (name != DataManager<PlayerBaseData>.GetInstance().Name)
			{
				SceneRequest sceneRequest = new SceneRequest();
				sceneRequest.type = 29;
				sceneRequest.targetName = name;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			}
		}

		// Token: 0x06010429 RID: 66601 RVA: 0x0048DD34 File Offset: 0x0048C134
		public static void RequestAddRelation(string param)
		{
			if (string.IsNullOrEmpty(param))
			{
				return;
			}
			ulong uid = 0UL;
			if (!ulong.TryParse(param, out uid))
			{
				return;
			}
			DataManager<RelationDataManager>.GetInstance().AddFriendByID(uid);
		}

		// Token: 0x0601042A RID: 66602 RVA: 0x0048DD6C File Offset: 0x0048C16C
		public void AddFriendByID(ulong uid)
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_add_friend_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (uid != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				SceneRequest sceneRequest = new SceneRequest();
				sceneRequest.type = 3;
				sceneRequest.target = uid;
				sceneRequest.targetName = string.Empty;
				sceneRequest.param = 0U;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			}
			else
			{
				SystemNotifyManager.SystemNotify(3049, string.Empty);
			}
		}

		// Token: 0x0601042B RID: 66603 RVA: 0x0048DE20 File Offset: 0x0048C220
		public void DelFriend(ulong uid)
		{
			RelationData relationByRoleID = this.GetRelationByRoleID(uid);
			if (relationByRoleID == null)
			{
				return;
			}
			if (relationByRoleID.type != 1)
			{
				return;
			}
			WorldRemoveRelation worldRemoveRelation = new WorldRemoveRelation();
			worldRemoveRelation.type = 1;
			worldRemoveRelation.uid = uid;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRemoveRelation>(ServerType.GATE_SERVER, worldRemoveRelation);
		}

		// Token: 0x0601042C RID: 66604 RVA: 0x0048DE6C File Offset: 0x0048C26C
		public void DelRelation(ulong uid, RelationType eRelationType)
		{
			if (this.GetRelationByRoleID(uid) == null)
			{
				return;
			}
			WorldRemoveRelation worldRemoveRelation = new WorldRemoveRelation();
			worldRemoveRelation.type = (byte)eRelationType;
			worldRemoveRelation.uid = uid;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRemoveRelation>(ServerType.GATE_SERVER, worldRemoveRelation);
		}

		// Token: 0x0601042D RID: 66605 RVA: 0x0048DEAC File Offset: 0x0048C2AC
		public void DelBlack(ulong uid)
		{
			RelationData relationByRoleID = this.GetRelationByRoleID(uid);
			if (relationByRoleID == null)
			{
				return;
			}
			if (relationByRoleID.type != 2)
			{
				return;
			}
			WorldRemoveRelation worldRemoveRelation = new WorldRemoveRelation();
			worldRemoveRelation.type = 2;
			worldRemoveRelation.uid = uid;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRemoveRelation>(ServerType.GATE_SERVER, worldRemoveRelation);
		}

		// Token: 0x0601042E RID: 66606 RVA: 0x0048DEF8 File Offset: 0x0048C2F8
		public void AddBlackList(ulong uid)
		{
			RelationData relationByRoleID = this.GetRelationByRoleID(uid);
			if (relationByRoleID != null && relationByRoleID.type == 2)
			{
				SystemNotifyManager.SystemNotify(3118, string.Empty);
				return;
			}
			WorldAddToBlackList worldAddToBlackList = new WorldAddToBlackList();
			worldAddToBlackList.tarUid = uid;
			NetManager.Instance().SendCommand<WorldAddToBlackList>(ServerType.GATE_SERVER, worldAddToBlackList);
		}

		// Token: 0x0601042F RID: 66607 RVA: 0x0048DF4C File Offset: 0x0048C34C
		public void QueryPlayerOnlineStatus(ulong[] uids)
		{
			WorldUpdatePlayerOnlineReq worldUpdatePlayerOnlineReq = new WorldUpdatePlayerOnlineReq();
			worldUpdatePlayerOnlineReq.uids = uids;
			NetManager.Instance().SendCommand<WorldUpdatePlayerOnlineReq>(ServerType.GATE_SERVER, worldUpdatePlayerOnlineReq);
		}

		// Token: 0x06010430 RID: 66608 RVA: 0x0048DF74 File Offset: 0x0048C374
		public void QueryPlayerOnlineStatus()
		{
			List<ulong> list = ListPool<ulong>.Get();
			list.Clear();
			List<PrivateChatPlayerData> priChatList = this.GetPriChatList();
			for (int i = 0; i < priChatList.Count; i++)
			{
				list.Add(priChatList[i].relationData.uid);
			}
			this.QueryPlayerOnlineStatus(list.ToArray());
			ListPool<ulong>.Release(list);
		}

		// Token: 0x06010431 RID: 66609 RVA: 0x0048DFD4 File Offset: 0x0048C3D4
		private void OnRecvPlayerOnLineStatusChanged(MsgDATA msg)
		{
			WorldUpdatePlayerOnlineRes worldUpdatePlayerOnlineRes = new WorldUpdatePlayerOnlineRes();
			worldUpdatePlayerOnlineRes.decode(msg.bytes);
			for (int i = 0; i < worldUpdatePlayerOnlineRes.playerStates.Length; i++)
			{
				PlayerOnline current = worldUpdatePlayerOnlineRes.playerStates[i];
				PrivateChatPlayerData privateChatPlayerData = this.m_priChatList.Find((PrivateChatPlayerData x) => x.relationData.uid == current.uid);
				if (privateChatPlayerData != null)
				{
					privateChatPlayerData.relationData.isOnline = current.online;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPlayerOnLineStatusChanged, null, null, null, null);
		}

		// Token: 0x06010432 RID: 66610 RVA: 0x0048E067 File Offset: 0x0048C467
		protected void _AddPriChatPlayer()
		{
		}

		// Token: 0x06010433 RID: 66611 RVA: 0x0048E069 File Offset: 0x0048C469
		protected bool _AddRelation(RelationData data)
		{
			if (data != null && !this.m_relationsDict.ContainsKey(data.uid))
			{
				this.m_relationsDict.Add(data.uid, data);
				return true;
			}
			return false;
		}

		// Token: 0x06010434 RID: 66612 RVA: 0x0048E09C File Offset: 0x0048C49C
		public void SendUpdateRelation()
		{
			WorldUpdateRelation cmd = new WorldUpdateRelation();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRelation>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010435 RID: 66613 RVA: 0x0048E0C0 File Offset: 0x0048C4C0
		protected bool _RemoveRelation(ulong uid)
		{
			RelationData relationData = null;
			this.m_relationsDict.TryGetValue(uid, out relationData);
			if (relationData != null)
			{
				this.m_relationsDict.Remove(uid);
				if (this.m_typeRelations.ContainsKey((RelationType)relationData.type))
				{
					this.m_typeRelations[(RelationType)relationData.type].Remove(uid);
				}
				relationData.type = 3;
				this._UpdatePriChatListRelation(relationData);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRelationChanged, relationData, true, null, null);
				return true;
			}
			return false;
		}

		// Token: 0x06010436 RID: 66614 RVA: 0x0048E148 File Offset: 0x0048C548
		protected void _UpdateLocalData(Relation net, ref RelationData localData)
		{
			for (int i = 0; i < net.dirtyFields.Count; i++)
			{
				if (net.dirtyFields[i] == 1)
				{
					localData.name = net.name;
				}
				else if (net.dirtyFields[i] == 2)
				{
					localData.seasonLv = net.seasonLv;
				}
				else if (net.dirtyFields[i] == 3)
				{
					localData.level = net.level;
				}
				else if (net.dirtyFields[i] == 4)
				{
					localData.occu = net.occu;
				}
				else if (net.dirtyFields[i] == 6)
				{
					localData.dayGiftNum = net.dayGiftNum;
				}
				else if (net.dirtyFields[i] == 7)
				{
					if (this.m_typeRelations.ContainsKey((RelationType)localData.type))
					{
						ulong uid = localData.uid;
						this.m_typeRelations[(RelationType)localData.type].RemoveAll((ulong x) => x == uid);
					}
					if (!this.m_typeRelations.ContainsKey((RelationType)net.type))
					{
						this.m_typeRelations[(RelationType)net.type] = new List<ulong>();
					}
					this.m_typeRelations[(RelationType)net.type].Add(localData.uid);
					localData.type = net.type;
				}
				else if (net.dirtyFields[i] == 8)
				{
					localData.createTime = net.createTime;
				}
				else if (net.dirtyFields[i] == 10)
				{
					localData.status = net.status;
				}
				else if (net.dirtyFields[i] == 11)
				{
					localData.tapDayGiftTimes = net.dailyGiftTimes;
				}
				else if (net.dirtyFields[i] == 11)
				{
					localData.tapDayGiftTimes = net.dailyGiftTimes;
				}
				else if (net.dirtyFields[i] == 12)
				{
					localData.offlineTime = net.offlineTime;
				}
				else if (net.dirtyFields[i] == 14)
				{
					localData.dailyTaskState = net.dailyMasterTaskState;
				}
				else if (net.dirtyFields[i] == 15)
				{
					localData.remark = net.remark;
				}
				else if (net.dirtyFields[i] == 13)
				{
					localData.intimacy = (uint)net.intimacy;
				}
				else if (net.dirtyFields[i] == 16)
				{
					localData.isRegress = net.isRegress;
				}
				else if (net.dirtyFields[i] == 17)
				{
					localData.mark = (uint)net.mark;
				}
				else if (net.dirtyFields[i] == 18)
				{
					localData.headFrame = net.headFrame;
				}
				else if (net.dirtyFields[i] == 20)
				{
					localData.returnYearTitle = net.returnYearTitle;
				}
			}
		}

		// Token: 0x06010437 RID: 66615 RVA: 0x0048E498 File Offset: 0x0048C898
		protected RelationData _CreateLocalData(Relation net)
		{
			return new RelationData
			{
				uid = net.uid,
				type = net.type,
				name = net.name,
				seasonLv = net.seasonLv,
				level = net.level,
				occu = net.occu,
				dayGiftNum = net.dayGiftNum,
				isOnline = net.isOnline,
				createTime = net.createTime,
				vipLv = net.vipLv,
				status = net.status,
				tapDayGiftTimes = net.dailyGiftTimes,
				announcement = string.Empty,
				offlineTime = net.offlineTime,
				intimacy = (uint)net.intimacy,
				remark = net.remark,
				dailyTaskState = net.dailyMasterTaskState,
				isRegress = net.isRegress,
				mark = (uint)net.mark,
				headFrame = net.headFrame,
				returnYearTitle = net.returnYearTitle
			};
		}

		// Token: 0x06010438 RID: 66616 RVA: 0x0048E5A8 File Offset: 0x0048C9A8
		protected RelationData _CreateLocalData(QuickFriendInfo net)
		{
			return new RelationData
			{
				uid = net.playerId,
				name = net.name,
				seasonLv = net.seasonLv,
				level = net.level,
				occu = net.occu,
				vipLv = net.vipLv,
				announcement = net.masterNote,
				avatar = net.avatar,
				activeTimeType = net.activeTimeType,
				masterType = net.masterType,
				regionId = net.regionId,
				declaration = net.declaration,
				playerLabelInfo = net.playerLabelInfo
			};
		}

		// Token: 0x0400A49F RID: 42143
		protected Dictionary<ulong, RelationData> m_relationsDict;

		// Token: 0x0400A4A0 RID: 42144
		protected Dictionary<RelationType, List<ulong>> m_typeRelations;

		// Token: 0x0400A4A1 RID: 42145
		protected List<InviteFriendData> m_inviteFriends;

		// Token: 0x0400A4A2 RID: 42146
		protected List<RelationData> m_recommand_teachres = new List<RelationData>();

		// Token: 0x0400A4A3 RID: 42147
		protected List<RelationData> m_recommand_pupils = new List<RelationData>();

		// Token: 0x0400A4A4 RID: 42148
		protected List<RelationData> m_apply_pupils = new List<RelationData>();

		// Token: 0x0400A4A5 RID: 42149
		protected List<RelationData> m_apply_teachers = new List<RelationData>();

		// Token: 0x0400A4A6 RID: 42150
		protected List<FriendlyDegreesIntervalNameModel> m_friendDegreesIntervalList = new List<FriendlyDegreesIntervalNameModel>();

		// Token: 0x0400A4A7 RID: 42151
		protected List<SceneSyncRequest> m_friendsPlayInviteList = new List<SceneSyncRequest>();

		// Token: 0x0400A4A8 RID: 42152
		private const int m_inviteFriendListNum = 30;

		// Token: 0x0400A4A9 RID: 42153
		private const int m_priChatListNum = 50;

		// Token: 0x0400A4AA RID: 42154
		private ulong m_curPriChatUid;

		// Token: 0x0400A4AB RID: 42155
		protected List<PrivateChatPlayerData> m_priChatList;

		// Token: 0x0400A4AC RID: 42156
		private List<ulong> m_akQueriedIds = new List<ulong>();

		// Token: 0x0400A4AD RID: 42157
		private bool m_bHasNewApply;
	}
}
