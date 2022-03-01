using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C42 RID: 7234
	public class TeamDuplicationTalkViewControl : MonoBehaviour
	{
		// Token: 0x06011C4C RID: 72780 RVA: 0x005342D3 File Offset: 0x005326D3
		private void Awake()
		{
			this.BindUiEvents();
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddGlobalChatData = (ChatManager.OnAddGlobalChatData)Delegate.Combine(instance.onAddGlobalChatData, new ChatManager.OnAddGlobalChatData(this.OnAddChat));
		}

		// Token: 0x06011C4D RID: 72781 RVA: 0x00534301 File Offset: 0x00532701
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddGlobalChatData = (ChatManager.OnAddGlobalChatData)Delegate.Remove(instance.onAddGlobalChatData, new ChatManager.OnAddGlobalChatData(this.OnAddChat));
		}

		// Token: 0x06011C4E RID: 72782 RVA: 0x00534330 File Offset: 0x00532730
		private void BindUiEvents()
		{
			if (this.upButton != null)
			{
				this.upButton.onClick.RemoveAllListeners();
				this.upButton.onClick.AddListener(new UnityAction(this.OnUpButtonClick));
			}
			if (this.downButton != null)
			{
				this.downButton.onClick.RemoveAllListeners();
				this.downButton.onClick.AddListener(new UnityAction(this.OnDownButtonClick));
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
				this.chatButton.onClick.AddListener(new UnityAction(this.OnChatButtonClick));
			}
		}

		// Token: 0x06011C4F RID: 72783 RVA: 0x005343F4 File Offset: 0x005327F4
		private void UnBindUiEvents()
		{
			if (this.upButton != null)
			{
				this.upButton.onClick.RemoveAllListeners();
			}
			if (this.downButton != null)
			{
				this.downButton.onClick.RemoveAllListeners();
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011C50 RID: 72784 RVA: 0x00534464 File Offset: 0x00532864
		public void Init()
		{
			this.InitData();
		}

		// Token: 0x06011C51 RID: 72785 RVA: 0x0053446C File Offset: 0x0053286C
		private void InitData()
		{
			if (this.talkExtraParam != null)
			{
				this._upOffset = this.talkExtraParam.upOffsetHeight;
				this._normalOffset = this.talkExtraParam.normalHeight;
			}
		}

		// Token: 0x06011C52 RID: 72786 RVA: 0x005344A4 File Offset: 0x005328A4
		private void OnAddChat(ChatBlock chatBlock)
		{
			if (this.chatItemParent == null || this.chatItemPrefab == null)
			{
				return;
			}
			if (chatBlock == null)
			{
				return;
			}
			if (chatBlock.chatData == null)
			{
				return;
			}
			ChatData chatData = chatBlock.chatData;
			if (chatData.eChatType != ChatType.CT_TEAM_COPY_PREPARE && chatData.eChatType != ChatType.CT_TEAM_COPY_TEAM && chatData.eChatType != ChatType.CT_TEAM_COPY_SQUAD)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.chatItemPrefab);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.chatItemParent, false);
			gameObject.CustomActive(true);
			TeamDuplicationTalkItem component = gameObject.GetComponent<TeamDuplicationTalkItem>();
			if (component != null)
			{
				component.Init(chatBlock);
			}
			if (this.chatFastVerticalLayout != null)
			{
				this.chatFastVerticalLayout.MarkDirty();
			}
		}

		// Token: 0x06011C53 RID: 72787 RVA: 0x0053457C File Offset: 0x0053297C
		private void OnUpButtonClick()
		{
			CommonUtility.UpdateGameObjectVisible(this.upButtonRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.downButtonRoot, true);
			if (this.talkViewRootRtf == null)
			{
				return;
			}
			this.talkViewRootRtf.offsetMax = new Vector2(this.talkViewRootRtf.offsetMax.x, this._upOffset);
			this.talkViewRootRtf.offsetMin = new Vector2(this.talkViewRootRtf.offsetMin.x, 0f);
			this.talkViewRootRtf.anchoredPosition = new Vector2(this.talkViewRootRtf.anchoredPosition.x, 0f);
			this.talkViewRootRtf.anchoredPosition3D = new Vector3(this.talkViewRootRtf.anchoredPosition3D.x, 0f, this.talkViewRootRtf.anchoredPosition3D.z);
		}

		// Token: 0x06011C54 RID: 72788 RVA: 0x00534668 File Offset: 0x00532A68
		private void OnDownButtonClick()
		{
			CommonUtility.UpdateGameObjectVisible(this.upButtonRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.downButtonRoot, false);
			if (this.talkViewRootRtf == null)
			{
				return;
			}
			this.talkViewRootRtf.offsetMax = new Vector2(this.talkViewRootRtf.offsetMax.x, this._normalOffset);
			this.talkViewRootRtf.offsetMin = new Vector2(this.talkViewRootRtf.offsetMin.x, 0f);
			this.talkViewRootRtf.anchoredPosition = new Vector2(this.talkViewRootRtf.anchoredPosition.x, 0f);
			this.talkViewRootRtf.anchoredPosition3D = new Vector3(this.talkViewRootRtf.anchoredPosition3D.x, 0f, this.talkViewRootRtf.anchoredPosition3D.z);
		}

		// Token: 0x06011C55 RID: 72789 RVA: 0x00534754 File Offset: 0x00532B54
		private void OnChatButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationChatFrame();
		}

		// Token: 0x0400B916 RID: 47382
		private float _upOffset = 150f;

		// Token: 0x0400B917 RID: 47383
		private float _normalOffset = 89f;

		// Token: 0x0400B918 RID: 47384
		[Space(10f)]
		[Header("View")]
		[Space(10f)]
		[SerializeField]
		private GameObject talkViewRoot;

		// Token: 0x0400B919 RID: 47385
		[SerializeField]
		private RectTransform talkViewRootRtf;

		// Token: 0x0400B91A RID: 47386
		[SerializeField]
		private ComTalkExtraParam talkExtraParam;

		// Token: 0x0400B91B RID: 47387
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button upButton;

		// Token: 0x0400B91C RID: 47388
		[SerializeField]
		private GameObject upButtonRoot;

		// Token: 0x0400B91D RID: 47389
		[SerializeField]
		private Button downButton;

		// Token: 0x0400B91E RID: 47390
		[SerializeField]
		private GameObject downButtonRoot;

		// Token: 0x0400B91F RID: 47391
		[SerializeField]
		private Button chatButton;

		// Token: 0x0400B920 RID: 47392
		[Space(10f)]
		[Header("ScrollView")]
		[Space(10f)]
		[SerializeField]
		private GameObject chatItemParent;

		// Token: 0x0400B921 RID: 47393
		[SerializeField]
		private GameObject chatItemPrefab;

		// Token: 0x0400B922 RID: 47394
		[SerializeField]
		private FastVerticalLayout chatFastVerticalLayout;
	}
}
