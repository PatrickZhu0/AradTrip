using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C60 RID: 7264
	public class TeamDuplicationGridMapCommonView : MonoBehaviour
	{
		// Token: 0x06011D78 RID: 73080 RVA: 0x00538626 File Offset: 0x00536A26
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011D79 RID: 73081 RVA: 0x0053862E File Offset: 0x00536A2E
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06011D7A RID: 73082 RVA: 0x00538638 File Offset: 0x00536A38
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.teamRoomButton != null)
			{
				this.teamRoomButton.onClick.RemoveAllListeners();
				this.teamRoomButton.onClick.AddListener(new UnityAction(this.OnTeamRoomButtonClick));
			}
		}

		// Token: 0x06011D7B RID: 73083 RVA: 0x005386C0 File Offset: 0x00536AC0
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.teamRoomButton != null)
			{
				this.teamRoomButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011D7C RID: 73084 RVA: 0x0053870F File Offset: 0x00536B0F
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridCountDownTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridCountDownMessage));
		}

		// Token: 0x06011D7D RID: 73085 RVA: 0x0053872C File Offset: 0x00536B2C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridCountDownTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridCountDownMessage));
		}

		// Token: 0x06011D7E RID: 73086 RVA: 0x00538749 File Offset: 0x00536B49
		public void InitCommonView()
		{
			this.UpdateCountDownTimeControl();
		}

		// Token: 0x06011D7F RID: 73087 RVA: 0x00538751 File Offset: 0x00536B51
		private void OnReceiveTeamDuplicationGridCountDownMessage(UIEvent uiEvent)
		{
			this.UpdateCountDownTimeControl();
		}

		// Token: 0x06011D80 RID: 73088 RVA: 0x00538759 File Offset: 0x00536B59
		private void UpdateCountDownTimeControl()
		{
			if (this.countDownTimeController == null)
			{
				return;
			}
			this.countDownTimeController.EndTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightFinishTime;
			this.countDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06011D81 RID: 73089 RVA: 0x0053878D File Offset: 0x00536B8D
		private void OnTeamRoomButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamRoomFrame(0);
		}

		// Token: 0x06011D82 RID: 73090 RVA: 0x00538795 File Offset: 0x00536B95
		private void OnCloseButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFrame();
		}

		// Token: 0x0400B9D3 RID: 47571
		[Space(10f)]
		[Header("CountDownTimeControl")]
		[Space(10f)]
		[SerializeField]
		private CountDownTimeController countDownTimeController;

		// Token: 0x0400B9D4 RID: 47572
		[Space(10f)]
		[Header("TeamRoomButton")]
		[Space(10f)]
		[SerializeField]
		private Button teamRoomButton;

		// Token: 0x0400B9D5 RID: 47573
		[Space(10f)]
		[Header("CloseButton")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
