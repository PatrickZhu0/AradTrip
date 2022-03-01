using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200150E RID: 5390
	public class ChampionshipMainScheduleSeaView : MonoBehaviour
	{
		// Token: 0x0600D15D RID: 53597 RVA: 0x0033A90D File Offset: 0x00338D0D
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D15E RID: 53598 RVA: 0x0033A915 File Offset: 0x00338D15
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
		}

		// Token: 0x0600D15F RID: 53599 RVA: 0x0033A932 File Offset: 0x00338D32
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
		}

		// Token: 0x0600D160 RID: 53600 RVA: 0x0033A94F File Offset: 0x00338D4F
		private void ClearData()
		{
			this._scheduleTable = null;
		}

		// Token: 0x0600D161 RID: 53601 RVA: 0x0033A958 File Offset: 0x00338D58
		public void InitView(ChampionshipScheduleTable scheduleTable)
		{
			this._scheduleTable = scheduleTable;
			if (this._scheduleTable == null)
			{
				return;
			}
			this.InitBaseContent();
			this.UpdateContent();
		}

		// Token: 0x0600D162 RID: 53602 RVA: 0x0033A97C File Offset: 0x00338D7C
		private void InitBaseContent()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = this._scheduleTable.ScheduleName;
			}
			if (this.helpNewAssistant != null)
			{
				this.helpNewAssistant.HelpId = this._scheduleTable.CommonHelpId;
			}
		}

		// Token: 0x0600D163 RID: 53603 RVA: 0x0033A9D8 File Offset: 0x00338DD8
		private void UpdateContent()
		{
			ChampionshipSelfSeaFightResultDataModel selfSeaFightResultDataModel = DataManager<ChampionshipDataManager>.GetInstance().SelfSeaFightResultDataModel;
			int num = 0;
			int num2 = 0;
			if (selfSeaFightResultDataModel != null)
			{
				num = selfSeaFightResultDataModel.WinNumber;
				num2 = selfSeaFightResultDataModel.LoseNumber;
			}
			string text = TR.Value("Championship_Race_Win_Format", num);
			string text2 = TR.Value("Championship_Race_Lost_Format", num2);
			if (this.winLabel != null)
			{
				this.winLabel.text = text;
			}
			if (this.loseLabel != null)
			{
				this.loseLabel.text = text2;
			}
		}

		// Token: 0x0600D164 RID: 53604 RVA: 0x0033AA66 File Offset: 0x00338E66
		private void OnReceiveChampionshipSelfSeaFightResultMessage(UIEvent uiEvent)
		{
			this.UpdateContent();
		}

		// Token: 0x04007A8E RID: 31374
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A8F RID: 31375
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007A90 RID: 31376
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x04007A91 RID: 31377
		[SerializeField]
		private Text winLabel;

		// Token: 0x04007A92 RID: 31378
		[SerializeField]
		private Text loseLabel;
	}
}
