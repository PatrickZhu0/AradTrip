using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C9A RID: 7322
	public class TeamDuplicationCaptainPlayerItem : MonoBehaviour
	{
		// Token: 0x06011F42 RID: 73538 RVA: 0x0053FB8F File Offset: 0x0053DF8F
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationChatContentMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationChatBubbleContentMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
		}

		// Token: 0x06011F43 RID: 73539 RVA: 0x0053FBC7 File Offset: 0x0053DFC7
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationChatContentMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationChatBubbleContentMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationPlayerExpireTimeMessage));
			this.ResetChatBubbleViewControl();
		}

		// Token: 0x06011F44 RID: 73540 RVA: 0x0053FC05 File Offset: 0x0053E005
		private void OnDestroy()
		{
			this._playerDataModel = null;
			this._chatBubbleViewControl = null;
		}

		// Token: 0x06011F45 RID: 73541 RVA: 0x0053FC15 File Offset: 0x0053E015
		public void Init(TeamDuplicationPlayerDataModel playerDataModel)
		{
			this._playerDataModel = playerDataModel;
			this.InitItem();
		}

		// Token: 0x06011F46 RID: 73542 RVA: 0x0053FC24 File Offset: 0x0053E024
		private void InitItem()
		{
			if (this.basePlayerItem != null)
			{
				this.basePlayerItem.Init(this._playerDataModel);
			}
			this.UpdatePlayerNameAndProfession();
			this.InitPlayerGrayCover();
			this.UpdateChatBubbleViewControl();
		}

		// Token: 0x06011F47 RID: 73543 RVA: 0x0053FC5C File Offset: 0x0053E05C
		private void InitPlayerGrayCover()
		{
			if (this._playerDataModel == null)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGrayRoot, false);
				return;
			}
			ulong expireTime = this._playerDataModel.ExpireTime;
			this.UpdatePlayerGrayCover(expireTime);
		}

		// Token: 0x06011F48 RID: 73544 RVA: 0x0053FC94 File Offset: 0x0053E094
		private void UpdatePlayerNameAndProfession()
		{
			if (this._playerDataModel == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.noPlayerInfoRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.playerInfoRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.noPlayerInfoRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.playerInfoRoot, true);
				if (this._playerDataModel != null)
				{
					if (this.playerNameText != null)
					{
						this.playerNameText.text = this._playerDataModel.Name;
					}
					if (this.playerProfessionText != null)
					{
						this.playerProfessionText.text = TeamDuplicationUtility.GetJobName(this._playerDataModel.ProfessionId, 0);
					}
				}
			}
		}

		// Token: 0x06011F49 RID: 73545 RVA: 0x0053FD40 File Offset: 0x0053E140
		private void OnReceiveTeamDuplicationChatBubbleContentMessage(UIEvent uiEvent)
		{
			if (this._playerDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != this._playerDataModel.Guid)
			{
				return;
			}
			string chatContent = (string)uiEvent.Param2;
			this.ShowTeamDuplicationChatBubbleContent(num, chatContent);
		}

		// Token: 0x06011F4A RID: 73546 RVA: 0x0053FDA8 File Offset: 0x0053E1A8
		private void ShowTeamDuplicationChatBubbleContent(ulong guid, string chatContent)
		{
			if (this._chatBubbleViewControl == null)
			{
				this._chatBubbleViewControl = TeamDuplicationUtility.LoadTeamDuplicationChatBubbleViewControl(this.chatRoot);
				if (this._chatBubbleViewControl != null)
				{
					this._chatBubbleViewControl.SetChatBgRotate();
				}
			}
			if (this._chatBubbleViewControl == null)
			{
				return;
			}
			this._chatBubbleViewControl.SetChatPlayerGuid(guid);
			this._chatBubbleViewControl.SetMessage(chatContent);
		}

		// Token: 0x06011F4B RID: 73547 RVA: 0x0053FE20 File Offset: 0x0053E220
		private void UpdateChatBubbleViewControl()
		{
			if (this._chatBubbleViewControl == null)
			{
				return;
			}
			if (this._playerDataModel == null)
			{
				this.ResetChatBubbleViewControl();
				return;
			}
			if (this._playerDataModel.Guid != this._chatBubbleViewControl.GetChatPlayerGuid())
			{
				this.ResetChatBubbleViewControl();
			}
		}

		// Token: 0x06011F4C RID: 73548 RVA: 0x0053FE72 File Offset: 0x0053E272
		private void ResetChatBubbleViewControl()
		{
			if (this._chatBubbleViewControl == null)
			{
				return;
			}
			this._chatBubbleViewControl.ShowRoot(false);
		}

		// Token: 0x06011F4D RID: 73549 RVA: 0x0053FE94 File Offset: 0x0053E294
		private void OnReceiveTeamDuplicationPlayerExpireTimeMessage(UIEvent uiEvent)
		{
			if (this._playerDataModel == null)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGrayRoot, false);
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			ulong expireTime = (ulong)uiEvent.Param2;
			if (this._playerDataModel.Guid != num)
			{
				return;
			}
			this.UpdatePlayerGrayCover(expireTime);
		}

		// Token: 0x06011F4E RID: 73550 RVA: 0x0053FF07 File Offset: 0x0053E307
		private void UpdatePlayerGrayCover(ulong expireTime)
		{
			if (expireTime == 0UL)
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGrayRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGrayRoot, true);
			}
		}

		// Token: 0x0400BB23 RID: 47907
		private TeamDuplicationPlayerDataModel _playerDataModel;

		// Token: 0x0400BB24 RID: 47908
		private TeamDuplicationChatBubbleViewControl _chatBubbleViewControl;

		// Token: 0x0400BB25 RID: 47909
		[Space(10f)]
		[Header("TroopTotalItem")]
		[Space(5f)]
		[SerializeField]
		private GameObject playerInfoRoot;

		// Token: 0x0400BB26 RID: 47910
		[SerializeField]
		private Text playerNameText;

		// Token: 0x0400BB27 RID: 47911
		[SerializeField]
		private Text playerProfessionText;

		// Token: 0x0400BB28 RID: 47912
		[SerializeField]
		private GameObject noPlayerInfoRoot;

		// Token: 0x0400BB29 RID: 47913
		[SerializeField]
		private TeamDuplicationBasePlayerItem basePlayerItem;

		// Token: 0x0400BB2A RID: 47914
		[Space(25f)]
		[Header("ChatContent")]
		[Space(10f)]
		[SerializeField]
		private GameObject chatRoot;

		// Token: 0x0400BB2B RID: 47915
		[Space(25f)]
		[Header("GrayPlayer")]
		[Space(10f)]
		[SerializeField]
		private UIGray playerUIGrayRoot;
	}
}
