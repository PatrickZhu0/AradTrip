using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA1 RID: 7329
	public class TeamDuplicationTeamRoomPlayerItem : MonoBehaviour
	{
		// Token: 0x06011F9C RID: 73628 RVA: 0x005415F1 File Offset: 0x0053F9F1
		protected void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F9D RID: 73629 RVA: 0x005415F9 File Offset: 0x0053F9F9
		protected void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011F9E RID: 73630 RVA: 0x00541608 File Offset: 0x0053FA08
		private void ClearData()
		{
			this._teamRoomPlayerDataModel = null;
			this._isOtherTeam = false;
			this._playerSeatId = 0;
			this._chatViewBubbleControl = null;
			this._teamRoomPlayerView = null;
			this._teamRoomPlayerDragStillCoverImage = null;
			this._teamRoomPlayerDropCoverImage = null;
			this._isBadSeat = false;
			this._badSeatPrefab = null;
		}

		// Token: 0x06011F9F RID: 73631 RVA: 0x00541654 File Offset: 0x0053FA54
		private void BindUiEvents()
		{
			if (this.commonNewDrag != null)
			{
				this.commonNewDrag.SetIsCanBeginDragAction(new IsCanBeginDragAction(this.IsCanBeginDrag));
				this.commonNewDrag.SetDragBeginAction(new DragBeginAction(this.DragBegin));
				this.commonNewDrag.SetDragEndAction(new DragEndAction(this.DragEnd));
			}
			if (this.commonNewDrop != null)
			{
				this.commonNewDrop.SetIsPointerItemCanDropDownAction(new IsPointerItemCanDropDownAction(this.IsPointerItemCanDropDownAction));
				this.commonNewDrop.SetOnDropDownAction(new OnDropDownAction(this.OnDropDownAction));
				this.commonNewDrop.SetOnPointerEnterAction(new OnPointerEnterAction(this.OnPointerEnterAction));
				this.commonNewDrop.SetOnPointerExitAction(new OnPointerExitAction(this.OnPointerExitAction));
			}
		}

		// Token: 0x06011FA0 RID: 73632 RVA: 0x00541724 File Offset: 0x0053FB24
		private void UnBindUiEvents()
		{
			if (this.commonNewDrag != null)
			{
				this.commonNewDrag.ResetDragAction();
			}
			if (this.commonNewDrop != null)
			{
				this.commonNewDrop.ResetDropAction();
			}
		}

		// Token: 0x06011FA1 RID: 73633 RVA: 0x00541760 File Offset: 0x0053FB60
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTeamDuplicationForceQuitTeamByDragMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationForceQuitTeamByDragMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationChatContentMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationChatBubbleContentMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamStatusNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamStatusNotifyMessage));
		}

		// Token: 0x06011FA2 RID: 73634 RVA: 0x005417DC File Offset: 0x0053FBDC
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTeamDuplicationForceQuitTeamByDragMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationForceQuitTeamByDragMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationChatContentMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationChatBubbleContentMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamStatusNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamStatusNotifyMessage));
		}

		// Token: 0x06011FA3 RID: 73635 RVA: 0x00541855 File Offset: 0x0053FC55
		public void InitItem(TeamDuplicationPlayerDataModel playerDataModel, bool isOtherTeam = false, int playerSeatId = 0, bool isBadSeat = false)
		{
			this._isOtherTeam = isOtherTeam;
			this._playerSeatId = playerSeatId;
			this._teamRoomPlayerDataModel = playerDataModel;
			this._isBadSeat = isBadSeat;
			this.InitTeamRoomPlayerItem();
		}

		// Token: 0x06011FA4 RID: 73636 RVA: 0x0054187C File Offset: 0x0053FC7C
		private void InitTeamRoomPlayerItem()
		{
			if (this._teamRoomPlayerDataModel == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.noPlayerRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.teamRoomPlayerViewRoot, false);
				this.ResetTeamRoomPlayerItemDrag();
				if (this._teamRoomPlayerView != null)
				{
					this._teamRoomPlayerView.ResetPlayerGrayView();
				}
				if (this._isBadSeat)
				{
					CommonUtility.UpdateTextVisible(this.seatEmptyLabel, false);
					if (this._badSeatPrefab == null)
					{
						this._badSeatPrefab = CommonUtility.LoadGameObject(this.noPlayerRoot);
					}
					CommonUtility.UpdateGameObjectVisible(this._badSeatPrefab, true);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.noPlayerRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.teamRoomPlayerViewRoot, true);
				this.InitTeamRoomPlayerView();
			}
			this.UpdateChatBubbleViewControl();
		}

		// Token: 0x06011FA5 RID: 73637 RVA: 0x0054193C File Offset: 0x0053FD3C
		private void InitTeamRoomPlayerView()
		{
			if (this._teamRoomPlayerView != null)
			{
				this._teamRoomPlayerView.InitItem(this._teamRoomPlayerDataModel, this._isOtherTeam);
				return;
			}
			if (this.teamRoomPlayerViewPrefab == null)
			{
				return;
			}
			if (this.teamRoomPlayerViewRoot == null)
			{
				return;
			}
			if (this._teamRoomPlayerView == null)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.teamRoomPlayerViewPrefab);
				if (gameObject != null)
				{
					CommonUtility.UpdateGameObjectVisible(gameObject, true);
					gameObject.transform.SetParent(this.teamRoomPlayerViewRoot.transform, false);
					this._teamRoomPlayerView = gameObject.GetComponent<TeamDuplicationTeamRoomPlayerView>();
					if (this._teamRoomPlayerView != null)
					{
						this._teamRoomPlayerView.InitItem(this._teamRoomPlayerDataModel, this._isOtherTeam);
					}
				}
			}
		}

		// Token: 0x06011FA6 RID: 73638 RVA: 0x00541A11 File Offset: 0x0053FE11
		private bool IsCanBeginDrag(PointerEventData pointerEventData)
		{
			return !this._isOtherTeam && !this._isBadSeat && this._teamRoomPlayerDataModel != null && TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication();
		}

		// Token: 0x06011FA7 RID: 73639 RVA: 0x00541A48 File Offset: 0x0053FE48
		private void ResetTeamRoomPlayerItemDrag()
		{
			if (this.commonNewDrag == null)
			{
				return;
			}
			if (!this.commonNewDrag.GetDraggingState())
			{
				return;
			}
			this.commonNewDrag.OnForceEndDrag();
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_change_seat_termination"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTeamDuplicationForceQuitTeamByDragMessage, null, null, null, null);
		}

		// Token: 0x06011FA8 RID: 73640 RVA: 0x00541AA8 File Offset: 0x0053FEA8
		private void DragBegin(PointerEventData pointerEventData)
		{
			this.ResetChatBubbleViewControl();
			if (this.dragCanvasRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.dragCanvasRoot, true);
			this.commonNewDrag.SetDragCanvasRoot(this.dragCanvasRoot);
			if (this.teamRoomPlayerViewRoot == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.teamRoomPlayerViewRoot);
			if (gameObject == null)
			{
				return;
			}
			CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();
			if (canvasGroup != null)
			{
				canvasGroup.blocksRaycasts = false;
			}
			CommonUtility.UpdateGameObjectVisible(gameObject, true);
			this.commonNewDrag.SetDragGameObject(gameObject);
			GameObject gameObject2 = Object.Instantiate<GameObject>(this.dragMoveCoverImage);
			if (gameObject2 != null)
			{
				CommonUtility.UpdateGameObjectVisible(gameObject2, true);
				gameObject2.transform.SetParent(gameObject.transform, false);
				gameObject2.transform.SetAsFirstSibling();
			}
			CommonUtility.RemoveChildGameObject(this.dragCanvasRoot);
			gameObject.transform.SetParent(this.dragCanvasRoot.transform, false);
			this.ShowTeamRoomPlayerDragStillCoverImage();
		}

		// Token: 0x06011FA9 RID: 73641 RVA: 0x00541BA8 File Offset: 0x0053FFA8
		private void DragEnd(PointerEventData pointEventData)
		{
			this.ResetChatBubbleViewControl();
			CommonUtility.UpdateGameObjectVisible(this._teamRoomPlayerDragStillCoverImage, false);
			if (this.dragCanvasRoot != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.dragCanvasRoot, false);
			}
			this.commonNewDrag.SetDragCanvasRoot(null);
			GameObject dragGameObject = this.commonNewDrag.GetDragGameObject();
			if (dragGameObject == null)
			{
				return;
			}
			Object.Destroy(dragGameObject);
			this.commonNewDrag.SetDragGameObject(null);
		}

		// Token: 0x06011FAA RID: 73642 RVA: 0x00541C1C File Offset: 0x0054001C
		private bool IsPointerItemCanDropDownAction(PointerEventData pointerEventData)
		{
			if (this._isBadSeat)
			{
				return false;
			}
			GameObject pointerDrag = pointerEventData.pointerDrag;
			if (pointerDrag == null)
			{
				return false;
			}
			CommonNewDrag component = pointerDrag.GetComponent<CommonNewDrag>();
			if (component == null)
			{
				return false;
			}
			TeamDuplicationTeamRoomPlayerItem component2 = pointerDrag.GetComponent<TeamDuplicationTeamRoomPlayerItem>();
			return !(component2 == null) && component2.IsCanDropDown(pointerEventData);
		}

		// Token: 0x06011FAB RID: 73643 RVA: 0x00541C80 File Offset: 0x00540080
		private void OnDropDownAction(PointerEventData pointerEventData)
		{
			CommonUtility.UpdateGameObjectVisible(this._teamRoomPlayerDropCoverImage, false);
			int dragPlayerSeatId = this.GetDragPlayerSeatId(pointerEventData);
			if (dragPlayerSeatId == 0 || this._playerSeatId == 0 || this._playerSeatId == dragPlayerSeatId)
			{
				return;
			}
			if (this._isBadSeat)
			{
				return;
			}
			bool flag = TeamDuplicationUtility.IsTeamDuplicationPlayerInFightingStatus(this._teamRoomPlayerDataModel);
			if (flag)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_can_not_change_position"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TeamDuplicationPlayerDataModel dragPlayerDataModel = this.GetDragPlayerDataModel(pointerEventData);
			bool flag2 = TeamDuplicationUtility.IsTeamDuplicationPlayerInFightingStatus(dragPlayerDataModel);
			if (flag2)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_can_not_change_position"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyChangeSeatReq(dragPlayerSeatId, this._playerSeatId);
		}

		// Token: 0x06011FAC RID: 73644 RVA: 0x00541D28 File Offset: 0x00540128
		private void OnPointerEnterAction(PointerEventData pointerEventData)
		{
			int dragPlayerSeatId = this.GetDragPlayerSeatId(pointerEventData);
			if (dragPlayerSeatId != 0 && dragPlayerSeatId != this._playerSeatId)
			{
				this.ShowTeamRoomPlayerDropCoverImage();
			}
		}

		// Token: 0x06011FAD RID: 73645 RVA: 0x00541D55 File Offset: 0x00540155
		private void OnPointerExitAction(PointerEventData pointerEventData)
		{
			CommonUtility.UpdateGameObjectVisible(this._teamRoomPlayerDropCoverImage, false);
		}

		// Token: 0x06011FAE RID: 73646 RVA: 0x00541D63 File Offset: 0x00540163
		public bool IsCanDropDown(PointerEventData pointerEventData)
		{
			return !this._isOtherTeam && this._teamRoomPlayerDataModel != null && TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication();
		}

		// Token: 0x06011FAF RID: 73647 RVA: 0x00541D8C File Offset: 0x0054018C
		private void OnReceiveTeamDuplicationForceQuitTeamByDragMessage(UIEvent uiEvent)
		{
			this.OnPointerExitAction(null);
		}

		// Token: 0x06011FB0 RID: 73648 RVA: 0x00541D98 File Offset: 0x00540198
		private int GetDragPlayerSeatId(PointerEventData pointerEventData)
		{
			GameObject pointerDrag = pointerEventData.pointerDrag;
			if (pointerDrag == null)
			{
				return 0;
			}
			CommonNewDrag component = pointerDrag.GetComponent<CommonNewDrag>();
			if (component == null)
			{
				return 0;
			}
			TeamDuplicationTeamRoomPlayerItem component2 = pointerDrag.GetComponent<TeamDuplicationTeamRoomPlayerItem>();
			if (component2 == null)
			{
				return 0;
			}
			if (component2.GetPlayerDataModel() == null)
			{
				return 0;
			}
			return component2.GetPlayerSeatId();
		}

		// Token: 0x06011FB1 RID: 73649 RVA: 0x00541DFC File Offset: 0x005401FC
		private TeamDuplicationPlayerDataModel GetDragPlayerDataModel(PointerEventData pointerEventData)
		{
			GameObject pointerDrag = pointerEventData.pointerDrag;
			if (pointerDrag == null)
			{
				return null;
			}
			CommonNewDrag component = pointerDrag.GetComponent<CommonNewDrag>();
			if (component == null)
			{
				return null;
			}
			TeamDuplicationTeamRoomPlayerItem component2 = pointerDrag.GetComponent<TeamDuplicationTeamRoomPlayerItem>();
			if (component2 == null)
			{
				return null;
			}
			return component2.GetPlayerDataModel();
		}

		// Token: 0x06011FB2 RID: 73650 RVA: 0x00541E50 File Offset: 0x00540250
		private void ShowTeamRoomPlayerDragStillCoverImage()
		{
			if (this._teamRoomPlayerDragStillCoverImage == null)
			{
				this._teamRoomPlayerDragStillCoverImage = Object.Instantiate<GameObject>(this.dragStillCoverImage);
				if (this._teamRoomPlayerDragStillCoverImage != null && this.dragAndDropRoot != null)
				{
					this._teamRoomPlayerDragStillCoverImage.transform.SetParent(this.dragAndDropRoot.transform, false);
				}
			}
			CommonUtility.UpdateGameObjectVisible(this._teamRoomPlayerDragStillCoverImage, true);
		}

		// Token: 0x06011FB3 RID: 73651 RVA: 0x00541ECC File Offset: 0x005402CC
		private void ShowTeamRoomPlayerDropCoverImage()
		{
			if (this._teamRoomPlayerDropCoverImage == null)
			{
				this._teamRoomPlayerDropCoverImage = Object.Instantiate<GameObject>(this.dropCoverImage);
				if (this._teamRoomPlayerDropCoverImage != null && this.dragAndDropRoot != null)
				{
					this._teamRoomPlayerDropCoverImage.transform.SetParent(this.dragAndDropRoot.transform, false);
				}
			}
			CommonUtility.UpdateGameObjectVisible(this._teamRoomPlayerDropCoverImage, true);
		}

		// Token: 0x06011FB4 RID: 73652 RVA: 0x00541F48 File Offset: 0x00540348
		private void OnReceiveTeamDuplicationChatBubbleContentMessage(UIEvent uiEvent)
		{
			if (this._isOtherTeam)
			{
				return;
			}
			if (this._teamRoomPlayerDataModel == null)
			{
				return;
			}
			if (this._teamRoomPlayerDragStillCoverImage != null && this._teamRoomPlayerDragStillCoverImage.activeSelf)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this._teamRoomPlayerDataModel.Guid)
			{
				return;
			}
			string chatContent = (string)uiEvent.Param2;
			this.ShowTeamDuplicationChatBubbleContent(num, chatContent);
		}

		// Token: 0x06011FB5 RID: 73653 RVA: 0x00541FE0 File Offset: 0x005403E0
		private void ShowTeamDuplicationChatBubbleContent(ulong guid, string chatContent)
		{
			if (this._chatViewBubbleControl == null)
			{
				this._chatViewBubbleControl = TeamDuplicationUtility.LoadTeamDuplicationChatBubbleViewControl(this.chatRoot);
			}
			if (this._chatViewBubbleControl == null)
			{
				return;
			}
			this._chatViewBubbleControl.SetChatPlayerGuid(guid);
			this._chatViewBubbleControl.SetMessage(chatContent);
		}

		// Token: 0x06011FB6 RID: 73654 RVA: 0x0054203C File Offset: 0x0054043C
		private void UpdateChatBubbleViewControl()
		{
			if (this._chatViewBubbleControl == null)
			{
				return;
			}
			if (this._teamRoomPlayerDataModel == null)
			{
				this.ResetChatBubbleViewControl();
				return;
			}
			if (this._teamRoomPlayerDataModel.Guid != this._chatViewBubbleControl.GetChatPlayerGuid())
			{
				this.ResetChatBubbleViewControl();
			}
		}

		// Token: 0x06011FB7 RID: 73655 RVA: 0x0054208E File Offset: 0x0054048E
		private void ResetChatBubbleViewControl()
		{
			if (this._chatViewBubbleControl == null)
			{
				return;
			}
			this._chatViewBubbleControl.ShowRoot(false);
		}

		// Token: 0x06011FB8 RID: 73656 RVA: 0x005420AE File Offset: 0x005404AE
		private void OnReceiveTeamDuplicationTeamStatusNotifyMessage(UIEvent uiEvent)
		{
			if (this._isOtherTeam)
			{
				return;
			}
			if (this._teamRoomPlayerDataModel == null)
			{
				return;
			}
			if (this._teamRoomPlayerView == null)
			{
				return;
			}
			this._teamRoomPlayerView.UpdatePlayerTicketInfo();
		}

		// Token: 0x06011FB9 RID: 73657 RVA: 0x005420E8 File Offset: 0x005404E8
		private void OnReceiveTeamDuplicationPlayerExpireTimeMessage(UIEvent uiEvent)
		{
			if (this._isOtherTeam)
			{
				return;
			}
			if (this._teamRoomPlayerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			ulong expireTime = (ulong)uiEvent.Param2;
			if (this._teamRoomPlayerDataModel.Guid != num)
			{
				return;
			}
			if (this._teamRoomPlayerView != null)
			{
				this._teamRoomPlayerView.UpdatePlayerGrayView(expireTime);
			}
		}

		// Token: 0x06011FBA RID: 73658 RVA: 0x00542171 File Offset: 0x00540571
		public int GetPlayerSeatId()
		{
			return this._playerSeatId;
		}

		// Token: 0x06011FBB RID: 73659 RVA: 0x00542179 File Offset: 0x00540579
		public TeamDuplicationPlayerDataModel GetPlayerDataModel()
		{
			return this._teamRoomPlayerDataModel;
		}

		// Token: 0x0400BB66 RID: 47974
		private bool _isOtherTeam;

		// Token: 0x0400BB67 RID: 47975
		private int _playerSeatId;

		// Token: 0x0400BB68 RID: 47976
		private TeamDuplicationPlayerDataModel _teamRoomPlayerDataModel;

		// Token: 0x0400BB69 RID: 47977
		private bool _isBadSeat;

		// Token: 0x0400BB6A RID: 47978
		private TeamDuplicationChatBubbleViewControl _chatViewBubbleControl;

		// Token: 0x0400BB6B RID: 47979
		private TeamDuplicationTeamRoomPlayerView _teamRoomPlayerView;

		// Token: 0x0400BB6C RID: 47980
		private GameObject _teamRoomPlayerDragStillCoverImage;

		// Token: 0x0400BB6D RID: 47981
		private GameObject _teamRoomPlayerDropCoverImage;

		// Token: 0x0400BB6E RID: 47982
		private GameObject _badSeatPrefab;

		// Token: 0x0400BB6F RID: 47983
		[Space(15f)]
		[Header("NoPlayer")]
		[Space(5f)]
		[SerializeField]
		private GameObject noPlayerRoot;

		// Token: 0x0400BB70 RID: 47984
		[SerializeField]
		private Text seatEmptyLabel;

		// Token: 0x0400BB71 RID: 47985
		[Space(15f)]
		[Header("PlayerViewRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamRoomPlayerViewRoot;

		// Token: 0x0400BB72 RID: 47986
		[Space(15f)]
		[Header("CommonNewDragAndDrop")]
		[Space(15f)]
		[SerializeField]
		private CommonNewDrag commonNewDrag;

		// Token: 0x0400BB73 RID: 47987
		[SerializeField]
		private CommonNewDrop commonNewDrop;

		// Token: 0x0400BB74 RID: 47988
		[SerializeField]
		private GameObject dragCanvasRoot;

		// Token: 0x0400BB75 RID: 47989
		[Space(25f)]
		[Header("ChatContent")]
		[Space(10f)]
		[SerializeField]
		private GameObject chatRoot;

		// Token: 0x0400BB76 RID: 47990
		[Space(15f)]
		[Header("AddInActionGameObject")]
		[Space(10f)]
		[SerializeField]
		private GameObject teamRoomPlayerViewPrefab;

		// Token: 0x0400BB77 RID: 47991
		[SerializeField]
		private GameObject dropCoverImage;

		// Token: 0x0400BB78 RID: 47992
		[SerializeField]
		private GameObject dragStillCoverImage;

		// Token: 0x0400BB79 RID: 47993
		[SerializeField]
		private GameObject dragMoveCoverImage;

		// Token: 0x0400BB7A RID: 47994
		[SerializeField]
		private GameObject dragAndDropRoot;
	}
}
