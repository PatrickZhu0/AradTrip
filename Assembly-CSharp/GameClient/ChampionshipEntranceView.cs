using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014DE RID: 5342
	public class ChampionshipEntranceView : MonoBehaviour
	{
		// Token: 0x0600CF3A RID: 53050 RVA: 0x00332414 File Offset: 0x00330814
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CF3B RID: 53051 RVA: 0x0033241C File Offset: 0x0033081C
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CF3C RID: 53052 RVA: 0x0033242A File Offset: 0x0033082A
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x0600CF3D RID: 53053 RVA: 0x00332469 File Offset: 0x00330869
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CF3E RID: 53054 RVA: 0x0033248C File Offset: 0x0033088C
		private void ClearData()
		{
			this._championshipScheduleTable = null;
			this._championshipScheduleId = 0;
			this._finalWinnerView = null;
		}

		// Token: 0x0600CF3F RID: 53055 RVA: 0x003324A3 File Offset: 0x003308A3
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600CF40 RID: 53056 RVA: 0x003324AB File Offset: 0x003308AB
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600CF41 RID: 53057 RVA: 0x003324B3 File Offset: 0x003308B3
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfStatusMessage));
		}

		// Token: 0x0600CF42 RID: 53058 RVA: 0x003324EB File Offset: 0x003308EB
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfStatusMessage));
		}

		// Token: 0x0600CF43 RID: 53059 RVA: 0x00332523 File Offset: 0x00330923
		public void InitView()
		{
			DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionTotalStatusReq();
			if (this.commonController != null)
			{
				this.commonController.InitBigRewardControl();
			}
		}

		// Token: 0x0600CF44 RID: 53060 RVA: 0x0033254C File Offset: 0x0033094C
		public void UpdateEntranceView()
		{
			this._championshipScheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			this._championshipScheduleTable = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(this._championshipScheduleId, string.Empty, string.Empty);
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			if (this.commonController != null)
			{
				this.commonController.Init(this._championshipScheduleTable);
			}
			if (this.buttonController != null)
			{
				this.buttonController.Init(this._championshipScheduleTable);
			}
		}

		// Token: 0x0600CF45 RID: 53061 RVA: 0x003325DC File Offset: 0x003309DC
		private void OnReceiveChampionshipStatusMessage(UIEvent uiEvent)
		{
			if (ChampionshipUtility.IsInChampionshipEndShow())
			{
				CommonUtility.UpdateGameObjectVisible(this.scheduleRoot, false);
				if (this.commonController != null)
				{
					this.commonController.ResetChampionshipAvatarView();
				}
				CommonUtility.UpdateGameObjectVisible(this.finalWinnerRoot, true);
				this.UpdateFinalWinnerView();
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.scheduleRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.finalWinnerRoot, false);
				this.UpdateEntranceView();
			}
		}

		// Token: 0x0600CF46 RID: 53062 RVA: 0x00332650 File Offset: 0x00330A50
		private void OnReceiveChampionshipSelfStatusMessage(UIEvent uiEvent)
		{
			if (this._championshipScheduleTable == null)
			{
				return;
			}
			if (ChampionshipUtility.IsInChampionshipEndShow())
			{
				return;
			}
			if (this.buttonController != null)
			{
				this.buttonController.Init(this._championshipScheduleTable);
			}
		}

		// Token: 0x0600CF47 RID: 53063 RVA: 0x0033268C File Offset: 0x00330A8C
		private void UpdateFinalWinnerView()
		{
			if (this.finalWinnerRoot == null)
			{
				return;
			}
			if (this._finalWinnerView == null)
			{
				GameObject gameObject = CommonUtility.LoadGameObject(this.finalWinnerRoot);
				if (gameObject != null)
				{
					this._finalWinnerView = gameObject.GetComponent<ChampionshipFinalWinnerView>();
				}
			}
			if (this._finalWinnerView != null)
			{
				this._finalWinnerView.InitFinalWinnerView();
			}
		}

		// Token: 0x0600CF48 RID: 53064 RVA: 0x003326FC File Offset: 0x00330AFC
		private void OnCloseButtonClick()
		{
			ChampionshipUtility.OnCloseChampionshipEntranceFrame();
		}

		// Token: 0x04007923 RID: 31011
		private int _championshipScheduleId;

		// Token: 0x04007924 RID: 31012
		private ChampionshipScheduleTable _championshipScheduleTable;

		// Token: 0x04007925 RID: 31013
		private ChampionshipFinalWinnerView _finalWinnerView;

		// Token: 0x04007926 RID: 31014
		[Space(10f)]
		[Header("ScheduleRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject scheduleRoot;

		// Token: 0x04007927 RID: 31015
		[SerializeField]
		private GameObject finalWinnerRoot;

		// Token: 0x04007928 RID: 31016
		[Space(20f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipEntranceCommonController commonController;

		// Token: 0x04007929 RID: 31017
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipEntranceButtonController buttonController;

		// Token: 0x0400792A RID: 31018
		[Space(10f)]
		[Header("Close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
