using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A00 RID: 6656
	internal class FriendRecommendedFrame : ClientFrame
	{
		// Token: 0x06010553 RID: 66899 RVA: 0x0049513C File Offset: 0x0049353C
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mBtnChangeAll = this.mBind.GetCom<Button>("BtnChangeAll");
			if (null != this.mBtnChangeAll)
			{
				this.mBtnChangeAll.onClick.AddListener(new UnityAction(this._onBtnChangeAllButtonClick));
			}
			this.comFriendRecommendList = this.mBind.GetCom<ComUIListScript>("Friends");
			this.mBtnSearch = this.mBind.GetCom<Button>("BtnSearch");
			if (null != this.mBtnSearch)
			{
				this.mBtnSearch.onClick.AddListener(new UnityAction(this._onBtnSearchButtonClick));
			}
			this.mGrayChangeAll = this.mBind.GetCom<UIGray>("GrayChangeAll");
			this.mLabelChangeAll = this.mBind.GetCom<Text>("LabelChangeAll");
			this.mInputField = this.mBind.GetCom<InputField>("InputField");
			this.mBtnAddAll = this.mBind.GetCom<Button>("BtnAddAll");
			if (this.mBtnAddAll != null)
			{
				this.mBtnAddAll.onClick.AddListener(new UnityAction(this._OnBtnAddAllButtonClick));
			}
			this.mGrayAddAll = this.mBind.GetCom<UIGray>("GrayAddAll");
		}

		// Token: 0x06010554 RID: 66900 RVA: 0x004952C4 File Offset: 0x004936C4
		protected override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			if (null != this.mBtnChangeAll)
			{
				this.mBtnChangeAll.onClick.RemoveListener(new UnityAction(this._onBtnChangeAllButtonClick));
			}
			this.mBtnChangeAll = null;
			this.comFriendRecommendList = null;
			if (null != this.mBtnSearch)
			{
				this.mBtnSearch.onClick.RemoveListener(new UnityAction(this._onBtnSearchButtonClick));
			}
			this.mBtnSearch = null;
			this.mGrayChangeAll = null;
			this.mLabelChangeAll = null;
			this.mInputField = null;
			if (this.mBtnAddAll != null)
			{
				this.mBtnAddAll.onClick.RemoveListener(new UnityAction(this._OnBtnAddAllButtonClick));
			}
			this.mBtnAddAll = null;
			this.mGrayAddAll = null;
		}

		// Token: 0x06010555 RID: 66901 RVA: 0x004953C4 File Offset: 0x004937C4
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<FriendRecommendedFrame>(this, false);
		}

		// Token: 0x06010556 RID: 66902 RVA: 0x004953D4 File Offset: 0x004937D4
		private void _onBtnChangeAllButtonClick()
		{
			if (this.iChangeCoolDown != 5)
			{
				return;
			}
			this.mBtnChangeAll.enabled = false;
			this.mGrayChangeAll.enabled = true;
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 1;
			worldRelationFindPlayersReq.name = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
			if (this.mLabelChangeAll != null)
			{
				this.mLabelChangeAll.text = TR.Value("relation_change_all_desc_param", this.iChangeCoolDown);
				this.iChangeCoolDown--;
			}
			InvokeMethod.Invoke(this, 1f, new UnityAction(this._ChangeAllCoolDown));
		}

		// Token: 0x06010557 RID: 66903 RVA: 0x00495484 File Offset: 0x00493884
		private void _onBtnSearchButtonClick()
		{
			if (string.IsNullOrEmpty(this.mInputField.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_search_name_empty"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_bWaitSearchRet)
			{
				return;
			}
			this.m_bWaitSearchRet = true;
			this.m_bIsQuery = true;
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				this.m_bWaitSearchRet = false;
			});
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.roleId = 0UL;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_FRIEND;
			worldQueryPlayerReq.name = this.mInputField.text;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x06010558 RID: 66904 RVA: 0x0049551F File Offset: 0x0049391F
		private void _OnBtnAddAllButtonClick()
		{
			this._OnAddAll();
		}

		// Token: 0x06010559 RID: 66905 RVA: 0x00495527 File Offset: 0x00493927
		protected sealed override void _OnOpenFrame()
		{
			DataManager<RelationDataManager>.GetInstance().ClearQueryInfo();
			this.InitFriendRecommendUIList();
			this._RegisterUIEvent();
			this.SendReconmendInfo();
			this.iChangeCoolDown = 5;
		}

		// Token: 0x0601055A RID: 66906 RVA: 0x0049554C File Offset: 0x0049394C
		protected sealed override void _OnCloseFrame()
		{
			InvokeMethod.RemoveInvokeCall(this);
			DataManager<RelationDataManager>.GetInstance().ClearQueryInfo();
			this.data = null;
			this._UnRegisterUIEvent();
			this.iChangeCoolDown = 5;
		}

		// Token: 0x0601055B RID: 66907 RVA: 0x00495572 File Offset: 0x00493972
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/FriendRecommendedFrame";
		}

		// Token: 0x0601055C RID: 66908 RVA: 0x0049557C File Offset: 0x0049397C
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecommendFriend));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecvQueryPlayer, new ClientEventSystem.UIEventHandler(this._OnRecvQueryPlayer));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x0601055D RID: 66909 RVA: 0x004955DC File Offset: 0x004939DC
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecommendFriend));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecvQueryPlayer, new ClientEventSystem.UIEventHandler(this._OnRecvQueryPlayer));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x0601055E RID: 66910 RVA: 0x0049563C File Offset: 0x00493A3C
		private void _OnRecommendFriend(UIEvent uiEvent)
		{
			UIEventRecievRecommendFriend uieventRecievRecommendFriend = uiEvent as UIEventRecievRecommendFriend;
			this.data = new FriendRecommentData();
			this.data.relationlist = new List<RelationData>();
			this.data.relationlist.AddRange(uieventRecievRecommendFriend.m_friendList);
			this.comFriendRecommendList.SetElementAmount(this.data.relationlist.Count);
			this.mGrayAddAll.enabled = false;
			this.mBtnAddAll.enabled = true;
		}

		// Token: 0x0601055F RID: 66911 RVA: 0x004956B4 File Offset: 0x00493AB4
		private void _OnRecvQueryPlayer(UIEvent uiEvent)
		{
			this.m_bWaitSearchRet = false;
			this.m_bIsQuery = false;
			UIEventRecvQueryPlayer uieventRecvQueryPlayer = uiEvent as UIEventRecvQueryPlayer;
			if (uieventRecvQueryPlayer != null)
			{
				this.data.relationlist = new List<RelationData>();
				this.data.relationlist.Add(new RelationData
				{
					uid = uieventRecvQueryPlayer._info.id,
					name = uieventRecvQueryPlayer._info.name,
					level = uieventRecvQueryPlayer._info.level,
					occu = uieventRecvQueryPlayer._info.occu,
					isOnline = 1,
					type = 0,
					vipLv = uieventRecvQueryPlayer._info.vipLevel,
					status = 0,
					seasonLv = uieventRecvQueryPlayer._info.seasonLevel
				});
				this.comFriendRecommendList.SetElementAmount(this.data.relationlist.Count);
				this.mGrayAddAll.enabled = false;
				this.mBtnAddAll.enabled = true;
			}
		}

		// Token: 0x06010560 RID: 66912 RVA: 0x004957B4 File Offset: 0x00493BB4
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			RelationData relationData = uiEvent.Param1 as RelationData;
			if (relationData != null && relationData.type == 1 && this.data != null && this.data.relationlist != null)
			{
				for (int i = 0; i < this.data.relationlist.Count; i++)
				{
					RelationData relationData2 = this.data.relationlist[i];
					if (relationData2.uid == relationData.uid)
					{
						this.data.relationlist.Remove(relationData2);
						break;
					}
				}
				if (this.comFriendRecommendList != null)
				{
					this.comFriendRecommendList.SetElementAmount(this.data.relationlist.Count);
				}
			}
		}

		// Token: 0x06010561 RID: 66913 RVA: 0x00495888 File Offset: 0x00493C88
		public void SendReconmendInfo()
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 1;
			worldRelationFindPlayersReq.name = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x06010562 RID: 66914 RVA: 0x004958BC File Offset: 0x00493CBC
		public bool IsQuerying()
		{
			return this.m_bIsQuery;
		}

		// Token: 0x06010563 RID: 66915 RVA: 0x004958C4 File Offset: 0x00493CC4
		private void InitFriendRecommendUIList()
		{
			this.comFriendRecommendList.Initialize();
			this.comFriendRecommendList.onBindItem = ((GameObject gameObject) => gameObject.GetComponent<ComRecommendFriendInfo>());
			this.comFriendRecommendList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null)
				{
					ComRecommendFriendInfo comRecommendFriendInfo = item.gameObjectBindScript as ComRecommendFriendInfo;
					if (comRecommendFriendInfo != null && item.m_index >= 0 && item.m_index < this.data.relationlist.Count)
					{
						comRecommendFriendInfo.OnItemVisible(this.data.relationlist[item.m_index]);
					}
				}
			};
		}

		// Token: 0x06010564 RID: 66916 RVA: 0x0049591B File Offset: 0x00493D1B
		private void SetFriendRecommendElementAmount()
		{
			if (this.data != null)
			{
				this.comFriendRecommendList.SetElementAmount(this.data.relationlist.Count);
			}
		}

		// Token: 0x06010565 RID: 66917 RVA: 0x00495944 File Offset: 0x00493D44
		private void _OnAddAll()
		{
			if (this.data != null && this.data.relationlist != null && this.data.relationlist.Count > 0)
			{
				this.mGrayAddAll.enabled = true;
				this.mBtnAddAll.enabled = false;
				for (int i = 0; i < this.data.relationlist.Count; i++)
				{
					string name = this.data.relationlist[i].name;
					ulong uid = this.data.relationlist[i].uid;
					if (this != null)
					{
						InvokeMethod.Invoke(this, (float)i * 0.2f, delegate()
						{
							DataManager<RelationDataManager>.GetInstance().AddQueryInfo(uid);
							SceneRequest sceneRequest = new SceneRequest();
							sceneRequest.type = 29;
							sceneRequest.targetName = name;
							NetManager netManager = NetManager.Instance();
							netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RelationAddRecommendFriendMsgSended, uid, null, null, null);
						});
					}
				}
			}
		}

		// Token: 0x06010566 RID: 66918 RVA: 0x00495A1C File Offset: 0x00493E1C
		private void _ChangeAllCoolDown()
		{
			if (this.mLabelChangeAll != null)
			{
				this.mLabelChangeAll.text = TR.Value("relation_change_all_desc_param", this.iChangeCoolDown);
			}
			this.iChangeCoolDown--;
			if (this.iChangeCoolDown == -1)
			{
				if (this.mLabelChangeAll != null)
				{
					this.mLabelChangeAll.text = TR.Value("relation_change_all_desc", string.Empty);
				}
				this.iChangeCoolDown = 5;
				this.mBtnChangeAll.enabled = true;
				this.mGrayChangeAll.enabled = false;
			}
			else
			{
				InvokeMethod.Invoke(this, 1f, new UnityAction(this._ChangeAllCoolDown));
			}
		}

		// Token: 0x0400A55D RID: 42333
		private FriendRecommentData data;

		// Token: 0x0400A55E RID: 42334
		private bool m_bWaitSearchRet;

		// Token: 0x0400A55F RID: 42335
		private bool m_bIsQuery;

		// Token: 0x0400A560 RID: 42336
		private Button mClose;

		// Token: 0x0400A561 RID: 42337
		private Button mBtnChangeAll;

		// Token: 0x0400A562 RID: 42338
		private ComUIListScript comFriendRecommendList;

		// Token: 0x0400A563 RID: 42339
		private Button mBtnSearch;

		// Token: 0x0400A564 RID: 42340
		private UIGray mGrayChangeAll;

		// Token: 0x0400A565 RID: 42341
		private Text mLabelChangeAll;

		// Token: 0x0400A566 RID: 42342
		private InputField mInputField;

		// Token: 0x0400A567 RID: 42343
		private Button mBtnAddAll;

		// Token: 0x0400A568 RID: 42344
		private UIGray mGrayAddAll;

		// Token: 0x0400A569 RID: 42345
		private int iChangeCoolDown = 5;
	}
}
