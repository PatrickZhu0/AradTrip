using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F5 RID: 6645
	internal class RelationPopupFram : ClientFrame
	{
		// Token: 0x060104C9 RID: 66761 RVA: 0x00491A0D File Offset: 0x0048FE0D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Friends/PopupDialog";
		}

		// Token: 0x060104CA RID: 66762 RVA: 0x00491A14 File Offset: 0x0048FE14
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._RegUIEvent();
			this._ChangeRefreshState(true);
			this.m_players = new List<CommonPlayerInfo>();
		}

		// Token: 0x060104CB RID: 66763 RVA: 0x00491A34 File Offset: 0x0048FE34
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060104CC RID: 66764 RVA: 0x00491A38 File Offset: 0x0048FE38
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.m_refreshCd == 0)
			{
				return;
			}
			this.m_timer += timeElapsed;
			if ((double)this.m_timer > 1.0)
			{
				this.m_refreshCd--;
				this._UpdateRefreshTime();
				if (this.m_refreshCd == 0)
				{
					this._ChangeRefreshState(true);
				}
				this.m_timer = 0f;
			}
		}

		// Token: 0x060104CD RID: 66765 RVA: 0x00491AA5 File Offset: 0x0048FEA5
		public void SetData(RelationData[] list)
		{
			this.m_list = list;
			this._InitElement();
		}

		// Token: 0x060104CE RID: 66766 RVA: 0x00491AB4 File Offset: 0x0048FEB4
		protected override void _OnCloseFrame()
		{
			this._ClearPlayerList();
			this._UnRegUIEvent();
		}

		// Token: 0x060104CF RID: 66767 RVA: 0x00491AC2 File Offset: 0x0048FEC2
		protected void _RegUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecvQueryPlayer, new ClientEventSystem.UIEventHandler(this._OnRecvQueryPlayer));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecievRecommendFriend));
		}

		// Token: 0x060104D0 RID: 66768 RVA: 0x00491AFA File Offset: 0x0048FEFA
		protected void _UnRegUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecvQueryPlayer, new ClientEventSystem.UIEventHandler(this._OnRecvQueryPlayer));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecievRecommendFriend));
		}

		// Token: 0x060104D1 RID: 66769 RVA: 0x00491B32 File Offset: 0x0048FF32
		protected void _InitData()
		{
			this.m_list = (this.userData as RelationData[]);
		}

		// Token: 0x060104D2 RID: 66770 RVA: 0x00491B48 File Offset: 0x0048FF48
		protected void _InitElement()
		{
			if (this.m_list == null)
			{
				return;
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, "Dlg/Scroll View/Viewport/Content", true);
			for (int i = 0; i < this.m_list.Length; i++)
			{
				CommonPlayerInfo commonPlayerInfo = new CommonPlayerInfo(this.m_list[i].uid, this.m_list[i].name, this.m_list[i].level, this.m_list[i].occu, CommonPlayerInfo.CommonPlayerType.CPT_RECOMEND, false, 1, this.m_list[i].type, this.m_list[i].vipLv);
				this.m_players.Add(commonPlayerInfo);
				commonPlayerInfo.m_friendPrefab.transform.SetParent(gameObject.transform, false);
			}
		}

		// Token: 0x060104D3 RID: 66771 RVA: 0x00491C08 File Offset: 0x00490008
		protected void _ClearPlayerList()
		{
			if (this.m_players == null)
			{
				return;
			}
			for (int i = 0; i < this.m_players.Count; i++)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_players[i].m_friendPrefab);
				this.m_players[i].Finatial();
			}
			this.m_players.Clear();
		}

		// Token: 0x060104D4 RID: 66772 RVA: 0x00491C74 File Offset: 0x00490074
		[UIEventHandle("Dlg/Title/Button")]
		private void OnClickClose()
		{
			this._OnClickClose();
		}

		// Token: 0x060104D5 RID: 66773 RVA: 0x00491C7C File Offset: 0x0049007C
		[UIEventHandle("Dlg/AddAllBtn")]
		private void OnClickAddAllBtn()
		{
			if (this.m_ct != null)
			{
				return;
			}
			this.m_ct = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AddBatchFriend());
		}

		// Token: 0x060104D6 RID: 66774 RVA: 0x00491CA0 File Offset: 0x004900A0
		public IEnumerator _AddBatchFriend()
		{
			for (int i = 0; i < this.m_players.Count; i++)
			{
				this.m_players[i].OnClickAddFriendBtn();
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			yield break;
		}

		// Token: 0x060104D7 RID: 66775 RVA: 0x00491CBB File Offset: 0x004900BB
		[UIEventHandle("Button")]
		private void OnClickOutSide()
		{
			this._OnClickClose();
		}

		// Token: 0x060104D8 RID: 66776 RVA: 0x00491CC4 File Offset: 0x004900C4
		[UIEventHandle("Dlg/Button")]
		private void OnRefreshBtn()
		{
			if (this.m_refreshCd > 0)
			{
				return;
			}
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 1;
			worldRelationFindPlayersReq.name = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x060104D9 RID: 66777 RVA: 0x00491D05 File Offset: 0x00490105
		protected void _OnClickClose()
		{
			if (this.m_ct != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_ct);
				this.m_ct = null;
			}
			this.frameMgr.CloseFrame<RelationPopupFram>(this, false);
		}

		// Token: 0x060104DA RID: 66778 RVA: 0x00491D38 File Offset: 0x00490138
		protected void _OnRecvQueryPlayer(UIEvent uiEvent)
		{
			UIEventRecvQueryPlayer uieventRecvQueryPlayer = uiEvent as UIEventRecvQueryPlayer;
			GameObject gameObject = Utility.FindGameObject(this.frame, "Dlg/Scroll View/Viewport/Content", true);
			CommonPlayerInfo commonPlayerInfo = new CommonPlayerInfo(uieventRecvQueryPlayer._info.id, uieventRecvQueryPlayer._info.name, uieventRecvQueryPlayer._info.level, uieventRecvQueryPlayer._info.occu, CommonPlayerInfo.CommonPlayerType.CPT_RECOMEND, false, 1, 0, uieventRecvQueryPlayer._info.vipLevel);
			this.m_players.Add(commonPlayerInfo);
			commonPlayerInfo.m_friendPrefab.transform.SetParent(gameObject.transform, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnQueryEnd, null, null, null, null);
		}

		// Token: 0x060104DB RID: 66779 RVA: 0x00491DD8 File Offset: 0x004901D8
		protected void _OnRecievRecommendFriend(UIEvent uiEvent)
		{
			UIEventRecievRecommendFriend uieventRecievRecommendFriend = uiEvent as UIEventRecievRecommendFriend;
			this._ClearPlayerList();
			this.SetData(uieventRecievRecommendFriend.m_friendList);
			this._ChangeRefreshState(false);
		}

		// Token: 0x060104DC RID: 66780 RVA: 0x00491E08 File Offset: 0x00490208
		protected void _ChangeRefreshState(bool validate)
		{
			UIGray component = this.m_refreshBtn.GetComponent<UIGray>();
			if (null == component)
			{
				return;
			}
			if (validate)
			{
				this.m_refreshBtn.enabled = true;
				component.enabled = false;
				this.m_refreshText.text = "换一批";
				this.m_refreshCd = 0;
			}
			else
			{
				this.m_refreshBtn.enabled = false;
				component.enabled = true;
				this.m_refreshText.text = string.Format("换一批5s", new object[0]);
				this.m_refreshCd = 5;
				if (this.m_ct != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_ct);
					this.m_ct = null;
				}
			}
		}

		// Token: 0x060104DD RID: 66781 RVA: 0x00491EBA File Offset: 0x004902BA
		protected void _UpdateRefreshTime()
		{
			this.m_refreshText.text = string.Format("换一批{0}s", this.m_refreshCd);
		}

		// Token: 0x0400A508 RID: 42248
		private GameObject m_element;

		// Token: 0x0400A509 RID: 42249
		private RelationData[] m_list;

		// Token: 0x0400A50A RID: 42250
		private List<CommonPlayerInfo> m_players;

		// Token: 0x0400A50B RID: 42251
		private float m_timer;

		// Token: 0x0400A50C RID: 42252
		private int m_refreshCd;

		// Token: 0x0400A50D RID: 42253
		[UIControl("Dlg/Button", null, 0)]
		private Button m_refreshBtn;

		// Token: 0x0400A50E RID: 42254
		[UIControl("Dlg/Button/Text", null, 0)]
		private Text m_refreshText;

		// Token: 0x0400A50F RID: 42255
		protected Coroutine m_ct;
	}
}
