using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019AD RID: 6573
	internal class Pk3v3VoteEnterPkFrame : ClientFrame
	{
		// Token: 0x06010097 RID: 65687 RVA: 0x00473101 File Offset: 0x00471501
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3VoteEnterPkFrame";
		}

		// Token: 0x06010098 RID: 65688 RVA: 0x00473108 File Offset: 0x00471508
		protected override void _OnOpenFrame()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(316, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("can not find SVT_ROOM_REJECT_ENTER_TIME in SystemValueTable");
				return;
			}
			this.VoteLastTime = (float)tableItem.Value;
			this.mTips.text = TR.Value("Pk3v3EnterBattleTips");
			this.mMatchtips.text = TR.Value("Pk3v3EnterBattleTips");
			this.InitInterface();
			this.BindUIEvent();
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				this.txtBattle.text = "队长发起决斗";
				this.txtMatch.text = "队长发起匹配";
			}
		}

		// Token: 0x06010099 RID: 65689 RVA: 0x004731B4 File Offset: 0x004715B4
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0601009A RID: 65690 RVA: 0x004731C2 File Offset: 0x004715C2
		private void ClearData()
		{
			this.VoteLastTime = 0f;
			this.addTime = 0f;
			this.LeftDict.Clear();
			this.RightDict.Clear();
		}

		// Token: 0x0601009B RID: 65691 RVA: 0x004731F0 File Offset: 0x004715F0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RefuseBeginMatch, new ClientEventSystem.UIEventHandler(this.OnPk3v3RefuseBeginMatch));
		}

		// Token: 0x0601009C RID: 65692 RVA: 0x00473228 File Offset: 0x00471628
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RefuseBeginMatch, new ClientEventSystem.UIEventHandler(this.OnPk3v3RefuseBeginMatch));
		}

		// Token: 0x0601009D RID: 65693 RVA: 0x00473260 File Offset: 0x00471660
		private void OnPk3v3RoomSlotInfoUpdate(UIEvent iEvent)
		{
			this.UpdatePlayerInfo();
		}

		// Token: 0x0601009E RID: 65694 RVA: 0x00473268 File Offset: 0x00471668
		private void OnPk3v3RefuseBeginMatch(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<Pk3v3VoteEnterPkFrame>(this, false);
		}

		// Token: 0x0601009F RID: 65695 RVA: 0x00473278 File Offset: 0x00471678
		private void Swap<T>(ref T x, ref T y)
		{
			T t = x;
			x = y;
			y = t;
		}

		// Token: 0x060100A0 RID: 65696 RVA: 0x004732A0 File Offset: 0x004716A0
		private void ReSortRoomSlotInfo(ref RoomInfo roomInfo)
		{
			if (roomInfo == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				RoomSlotInfo roomSlotInfo = roomInfo.roomSlotInfos[i];
				if (roomSlotInfo.playerId == roomInfo.roomSimpleInfo.ownerId)
				{
					num = i;
					break;
				}
			}
			if (num != -1 && num != 0)
			{
				this.Swap<RoomSlotInfo>(ref roomInfo.roomSlotInfos[0], ref roomInfo.roomSlotInfos[num]);
			}
			if (roomInfo.roomSlotInfos.Length > 2 && roomInfo.roomSlotInfos[1].playerId == 0UL && roomInfo.roomSlotInfos[2].playerId != 0UL)
			{
				this.Swap<RoomSlotInfo>(ref roomInfo.roomSlotInfos[1], ref roomInfo.roomSlotInfos[2]);
			}
		}

		// Token: 0x060100A1 RID: 65697 RVA: 0x00473380 File Offset: 0x00471780
		private void InitInterface()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
				this.ReSortRoomSlotInfo(ref roomInfo);
			}
			if (roomInfo == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4)
			{
				this.mGoEntertainment.CustomActive(true);
				this.mGoMatching.CustomActive(false);
				this.mBottomroot.CustomActive(DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId);
			}
			else if (roomInfo.roomSimpleInfo.roomType == 2 || roomInfo.roomSimpleInfo.roomType == 3)
			{
				this.mGoEntertainment.CustomActive(false);
				this.mGoMatching.CustomActive(true);
				this.mMatchbottomroot.CustomActive(DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId);
			}
			int i = 0;
			while (i < roomInfo.roomSlotInfos.Length)
			{
				RoomSlotInfo roomSlotInfo = roomInfo.roomSlotInfos[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.VotePlayerElePath, true, 0U);
				if (gameObject == null)
				{
					Logger.LogError("can't create obj in Pk3v3VoteEnterPkFrame");
					return;
				}
				if (roomSlotInfo.group == 1)
				{
					if (roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4)
					{
						gameObject.transform.SetParent(this.mLeftroot.transform, false);
					}
					else if (roomInfo.roomSimpleInfo.roomType == 2 || roomInfo.roomSimpleInfo.roomType == 3)
					{
						gameObject.transform.SetParent(this.mContentroot.transform, false);
					}
					if (roomSlotInfo.playerId > 0UL)
					{
						if (this.LeftDict.ContainsKey(roomSlotInfo.playerId))
						{
							this.LeftDict[roomSlotInfo.playerId] = gameObject;
						}
						else
						{
							this.LeftDict.Add(roomSlotInfo.playerId, gameObject);
						}
					}
					else if (this.LeftDict.ContainsKey((ulong)((long)i)))
					{
						this.LeftDict[(ulong)((long)i)] = gameObject;
					}
					else
					{
						this.LeftDict.Add((ulong)((long)i), gameObject);
					}
					goto IL_2F0;
				}
				if (roomSlotInfo.group == 2)
				{
					gameObject.transform.SetParent(this.mRightroot.transform, false);
					if (roomSlotInfo.playerId > 0UL)
					{
						if (this.RightDict.ContainsKey(roomSlotInfo.playerId))
						{
							this.RightDict[roomSlotInfo.playerId] = gameObject;
						}
						else
						{
							this.RightDict.Add(roomSlotInfo.playerId, gameObject);
						}
					}
					else if (this.RightDict.ContainsKey((ulong)((long)i)))
					{
						this.RightDict[(ulong)((long)i)] = gameObject;
					}
					else
					{
						this.RightDict.Add((ulong)((long)i), gameObject);
					}
					goto IL_2F0;
				}
				IL_319:
				i++;
				continue;
				IL_2F0:
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in VotePlayerElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomSlotInfo);
				goto IL_319;
			}
		}

		// Token: 0x060100A2 RID: 65698 RVA: 0x004736B8 File Offset: 0x00471AB8
		private void UpdatePlayerInfo()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
				this.ReSortRoomSlotInfo(ref roomInfo);
			}
			if (roomInfo == null)
			{
				return;
			}
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				RoomSlotInfo roomSlotInfo = roomInfo.roomSlotInfos[i];
				if (roomSlotInfo.playerId != 0UL)
				{
					bool flag = false;
					GameObject gameObject = null;
					if (roomInfo.roomSlotInfos[i].group == 1)
					{
						if (this.LeftDict.TryGetValue(roomSlotInfo.playerId, out gameObject))
						{
							flag = true;
						}
						else
						{
							Logger.LogErrorFormat("LeftDict don`t find init PlayerId = {0} when UpdatePlayerInfo", new object[]
							{
								roomSlotInfo.playerId
							});
						}
					}
					else if (roomInfo.roomSlotInfos[i].group == 2)
					{
						if (this.RightDict.TryGetValue(roomSlotInfo.playerId, out gameObject))
						{
							flag = true;
						}
						else
						{
							Logger.LogErrorFormat("RightDict don`t find init PlayerId = {0} when UpdatePlayerInfo", new object[]
							{
								roomSlotInfo.playerId
							});
						}
					}
					if (flag)
					{
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component == null)
						{
							Logger.LogError("can't find ComCommonBind in UpdatePlayerInfo");
							return;
						}
						this.UpdatePlayerBaseInfo(component, roomSlotInfo);
					}
				}
			}
		}

		// Token: 0x060100A3 RID: 65699 RVA: 0x0047380C File Offset: 0x00471C0C
		private void UpdatePlayerBaseInfo(ComCommonBind combind, RoomSlotInfo slotInfo)
		{
			Image com = combind.GetCom<Image>("Icon");
			Text com2 = combind.GetCom<Text>("Name");
			Image com3 = combind.GetCom<Image>("Sel");
			UIGray com4 = combind.GetCom<UIGray>("IconGray");
			if (slotInfo.playerId > 0UL)
			{
				string text = string.Empty;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)slotInfo.playerOccu, string.Empty, string.Empty);
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
					ETCImageLoader.LoadSprite(ref com, text, true);
				}
				com2.text = slotInfo.playerName;
				com4.SetEnable(slotInfo.readyStatus != 1);
				com3.gameObject.CustomActive(slotInfo.readyStatus == 1);
				if (slotInfo.playerId == DataManager<PlayerBaseData>.GetInstance().RoleID && slotInfo.readyStatus == 1)
				{
					this.mBottomroot.CustomActive(false);
					this.mTips.gameObject.CustomActive(true);
					this.mMatchbottomroot.CustomActive(false);
					this.mMatchtips.gameObject.CustomActive(true);
				}
			}
			else
			{
				com4.SetEnable(true);
			}
		}

		// Token: 0x060100A4 RID: 65700 RVA: 0x00473964 File Offset: 0x00471D64
		private void SendBattleReadyReq(bool agree)
		{
			WorldRoomBattleReadyReq worldRoomBattleReadyReq = new WorldRoomBattleReadyReq();
			if (agree)
			{
				worldRoomBattleReadyReq.slotStatus = 1;
			}
			else
			{
				worldRoomBattleReadyReq.slotStatus = 2;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleReadyReq>(ServerType.GATE_SERVER, worldRoomBattleReadyReq);
		}

		// Token: 0x060100A5 RID: 65701 RVA: 0x0047399F File Offset: 0x00471D9F
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060100A6 RID: 65702 RVA: 0x004739A4 File Offset: 0x00471DA4
		protected override void _OnUpdate(float timeElapsed)
		{
			this.mEnterSlider.value += this.fSpeed;
			this.mMatchSlider.value += this.fSpeed;
			this.addTime += timeElapsed;
			if (this.addTime > 1f)
			{
				this.VoteLastTime -= 1f;
				this.addTime = 0f;
				int num = (int)this.VoteLastTime;
				this.mRegectText.text = string.Format("拒绝({0}s)", num);
				this.mMatchRegectText.text = string.Format("拒绝({0}s)", num);
			}
			if (this.VoteLastTime < 0.2f)
			{
				this.frameMgr.CloseFrame<Pk3v3VoteEnterPkFrame>(this, false);
			}
		}

		// Token: 0x060100A7 RID: 65703 RVA: 0x00473A78 File Offset: 0x00471E78
		protected override void _bindExUI()
		{
			this.mLeftroot = this.mBind.GetGameObject("leftroot");
			this.mRightroot = this.mBind.GetGameObject("rightroot");
			this.mBottomroot = this.mBind.GetGameObject("bottomroot");
			this.mBtReject = this.mBind.GetCom<Button>("btReject");
			this.mBtReject.onClick.AddListener(new UnityAction(this._onBtRejectButtonClick));
			this.mBtAgree = this.mBind.GetCom<Button>("btAgree");
			this.mBtAgree.onClick.AddListener(new UnityAction(this._onBtAgreeButtonClick));
			this.mPkbg = this.mBind.GetGameObject("pkbg");
			this.mRegectText = this.mBind.GetCom<Text>("RegectText");
			this.mRejectGray = this.mBind.GetCom<UIGray>("RejectGray");
			this.mAgreeGray = this.mBind.GetCom<UIGray>("AgreeGray");
			this.mMatchtips = this.mBind.GetCom<Text>("matchtips");
			this.mMatchbottomroot = this.mBind.GetGameObject("matchbottomroot");
			this.mGoMatching = this.mBind.GetGameObject("goMatching");
			this.mGoEntertainment = this.mBind.GetGameObject("goEntertainment");
			this.mContentroot = this.mBind.GetGameObject("contentroot");
			this.mMatchAgreeGray = this.mBind.GetCom<UIGray>("matchAgreeGray");
			this.mMatchRejectGray = this.mBind.GetCom<UIGray>("matchRejectGray");
			this.mBtmatchAgree = this.mBind.GetCom<Button>("btmatchAgree");
			this.mBtmatchAgree.onClick.AddListener(new UnityAction(this._onBtmatchAgreeButtonClick));
			this.mBtmatchReject = this.mBind.GetCom<Button>("btmatchReject");
			this.mBtmatchReject.onClick.AddListener(new UnityAction(this._onBtmatchRejectButtonClick));
			this.mMatchRegectText = this.mBind.GetCom<Text>("matchRegectText");
			this.mMatchSlider = this.mBind.GetCom<Slider>("matchSlider");
			this.mEnterSlider = this.mBind.GetCom<Slider>("enterSlider");
			this.mTips = this.mBind.GetCom<Text>("tips");
			this.txtBattle = this.mBind.GetCom<Text>("txtBattle");
			this.txtMatch = this.mBind.GetCom<Text>("txtMatch");
		}

		// Token: 0x060100A8 RID: 65704 RVA: 0x00473D08 File Offset: 0x00472108
		protected override void _unbindExUI()
		{
			this.mLeftroot = null;
			this.mRightroot = null;
			this.mBottomroot = null;
			this.mBtReject.onClick.RemoveListener(new UnityAction(this._onBtRejectButtonClick));
			this.mBtReject = null;
			this.mBtAgree.onClick.RemoveListener(new UnityAction(this._onBtAgreeButtonClick));
			this.mBtAgree = null;
			this.mPkbg = null;
			this.mRegectText = null;
			this.mRejectGray = null;
			this.mAgreeGray = null;
			this.mMatchtips = null;
			this.mMatchbottomroot = null;
			this.mGoMatching = null;
			this.mGoEntertainment = null;
			this.mContentroot = null;
			this.mMatchAgreeGray = null;
			this.mMatchRejectGray = null;
			this.mBtmatchAgree.onClick.RemoveListener(new UnityAction(this._onBtmatchAgreeButtonClick));
			this.mBtmatchAgree = null;
			this.mBtmatchReject.onClick.RemoveListener(new UnityAction(this._onBtmatchRejectButtonClick));
			this.mBtmatchReject = null;
			this.mMatchRegectText = null;
			this.mTips = null;
			this.mMatchSlider = null;
			this.mEnterSlider = null;
			this.txtBattle = null;
			this.txtMatch = null;
		}

		// Token: 0x060100A9 RID: 65705 RVA: 0x00473E2D File Offset: 0x0047222D
		private void _onBtRejectButtonClick()
		{
			this.OnRejectButtonClick();
		}

		// Token: 0x060100AA RID: 65706 RVA: 0x00473E35 File Offset: 0x00472235
		private void _onBtAgreeButtonClick()
		{
			this.SendBattleReadyReq(true);
			this.mRejectGray.enabled = true;
			this.mBtAgree.interactable = false;
			this.mAgreeGray.enabled = true;
			this.mBtAgree.interactable = false;
		}

		// Token: 0x060100AB RID: 65707 RVA: 0x00473E6E File Offset: 0x0047226E
		private void _onBtmatchAgreeButtonClick()
		{
			this.SendBattleReadyReq(true);
			this.mMatchRejectGray.enabled = true;
			this.mBtmatchAgree.interactable = false;
			this.mMatchAgreeGray.enabled = true;
			this.mBtmatchAgree.interactable = false;
		}

		// Token: 0x060100AC RID: 65708 RVA: 0x00473EA7 File Offset: 0x004722A7
		private void _onBtmatchRejectButtonClick()
		{
			this.OnRejectButtonClick();
		}

		// Token: 0x060100AD RID: 65709 RVA: 0x00473EB0 File Offset: 0x004722B0
		private void OnRejectButtonClick()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
				this.ReSortRoomSlotInfo(ref roomInfo);
			}
			if (roomInfo == null)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID == roomInfo.roomSimpleInfo.ownerId)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("房主默认同意进入战斗", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.SendBattleReadyReq(false);
			this.frameMgr.CloseFrame<Pk3v3VoteEnterPkFrame>(this, false);
		}

		// Token: 0x0400A1DE RID: 41438
		private string VotePlayerElePath = "UIFlatten/Prefabs/Pk3v3/Pk3v3VotePlayerEle";

		// Token: 0x0400A1DF RID: 41439
		private float VoteLastTime;

		// Token: 0x0400A1E0 RID: 41440
		private float addTime;

		// Token: 0x0400A1E1 RID: 41441
		private float fSpeed = 0.00225f;

		// Token: 0x0400A1E2 RID: 41442
		private Dictionary<ulong, GameObject> LeftDict = new Dictionary<ulong, GameObject>();

		// Token: 0x0400A1E3 RID: 41443
		private Dictionary<ulong, GameObject> RightDict = new Dictionary<ulong, GameObject>();

		// Token: 0x0400A1E4 RID: 41444
		private GameObject mLeftroot;

		// Token: 0x0400A1E5 RID: 41445
		private GameObject mRightroot;

		// Token: 0x0400A1E6 RID: 41446
		private GameObject mBottomroot;

		// Token: 0x0400A1E7 RID: 41447
		private Button mBtReject;

		// Token: 0x0400A1E8 RID: 41448
		private Button mBtAgree;

		// Token: 0x0400A1E9 RID: 41449
		private GameObject mPkbg;

		// Token: 0x0400A1EA RID: 41450
		private Text mRegectText;

		// Token: 0x0400A1EB RID: 41451
		private UIGray mRejectGray;

		// Token: 0x0400A1EC RID: 41452
		private UIGray mAgreeGray;

		// Token: 0x0400A1ED RID: 41453
		private Text mMatchtips;

		// Token: 0x0400A1EE RID: 41454
		private GameObject mMatchbottomroot;

		// Token: 0x0400A1EF RID: 41455
		private GameObject mGoMatching;

		// Token: 0x0400A1F0 RID: 41456
		private GameObject mGoEntertainment;

		// Token: 0x0400A1F1 RID: 41457
		private GameObject mContentroot;

		// Token: 0x0400A1F2 RID: 41458
		private UIGray mMatchAgreeGray;

		// Token: 0x0400A1F3 RID: 41459
		private UIGray mMatchRejectGray;

		// Token: 0x0400A1F4 RID: 41460
		private Button mBtmatchAgree;

		// Token: 0x0400A1F5 RID: 41461
		private Button mBtmatchReject;

		// Token: 0x0400A1F6 RID: 41462
		private Text mMatchRegectText;

		// Token: 0x0400A1F7 RID: 41463
		private Slider mMatchSlider;

		// Token: 0x0400A1F8 RID: 41464
		private Slider mEnterSlider;

		// Token: 0x0400A1F9 RID: 41465
		private Text mTips;

		// Token: 0x0400A1FA RID: 41466
		private Text txtBattle;

		// Token: 0x0400A1FB RID: 41467
		private Text txtMatch;
	}
}
