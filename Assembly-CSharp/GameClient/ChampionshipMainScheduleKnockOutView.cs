using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200150C RID: 5388
	public class ChampionshipMainScheduleKnockOutView : MonoBehaviour
	{
		// Token: 0x0600D141 RID: 53569 RVA: 0x0033A2D6 File Offset: 0x003386D6
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D142 RID: 53570 RVA: 0x0033A2DE File Offset: 0x003386DE
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipKnockoutScoreMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipKnockoutScoreMessage));
		}

		// Token: 0x0600D143 RID: 53571 RVA: 0x0033A2FB File Offset: 0x003386FB
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipKnockoutScoreMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipKnockoutScoreMessage));
		}

		// Token: 0x0600D144 RID: 53572 RVA: 0x0033A318 File Offset: 0x00338718
		private void ClearData()
		{
			this._scheduleTable = null;
		}

		// Token: 0x0600D145 RID: 53573 RVA: 0x0033A321 File Offset: 0x00338721
		public void InitView(ChampionshipScheduleTable scheduleTable)
		{
			this._scheduleTable = scheduleTable;
			this.InitBaseContent();
			this.UpdateContent();
		}

		// Token: 0x0600D146 RID: 53574 RVA: 0x0033A338 File Offset: 0x00338738
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

		// Token: 0x0600D147 RID: 53575 RVA: 0x0033A394 File Offset: 0x00338794
		private void UpdateContent()
		{
			List<ChampionshipKnockoutPlayerDataModel> knockoutPlayerDataModelList = DataManager<ChampionshipDataManager>.GetInstance().KnockoutPlayerDataModelList;
			if (knockoutPlayerDataModelList == null || knockoutPlayerDataModelList.Count < 2)
			{
				return;
			}
			ChampionshipKnockoutPlayerDataModel championshipKnockoutPlayerDataModel = knockoutPlayerDataModelList[0];
			ChampionshipKnockoutPlayerDataModel championshipKnockoutPlayerDataModel2 = knockoutPlayerDataModelList[1];
			if (championshipKnockoutPlayerDataModel == null || championshipKnockoutPlayerDataModel2 == null)
			{
				return;
			}
			string text = TR.Value("Championship_Race_Knock_Out_Score_Format", championshipKnockoutPlayerDataModel.Score, championshipKnockoutPlayerDataModel2.Score);
			if (this.playerScoreResultLabel != null)
			{
				this.playerScoreResultLabel.text = text;
			}
			if (this.firstPlayerItem != null)
			{
				ChampionshipTopPlayerDataModel playerDataModel = this.CreateTopPlayerDataModel(championshipKnockoutPlayerDataModel);
				this.firstPlayerItem.Init(playerDataModel);
			}
			if (this.secondPlayerItem != null)
			{
				ChampionshipTopPlayerDataModel playerDataModel2 = this.CreateTopPlayerDataModel(championshipKnockoutPlayerDataModel2);
				this.secondPlayerItem.Init(playerDataModel2);
			}
		}

		// Token: 0x0600D148 RID: 53576 RVA: 0x0033A468 File Offset: 0x00338868
		private ChampionshipTopPlayerDataModel CreateTopPlayerDataModel(ChampionshipKnockoutPlayerDataModel playerDataModel)
		{
			if (playerDataModel == null)
			{
				return null;
			}
			return new ChampionshipTopPlayerDataModel
			{
				Name = playerDataModel.Name,
				ServerName = playerDataModel.Server,
				ProfessionId = playerDataModel.ProfessionId
			};
		}

		// Token: 0x0600D149 RID: 53577 RVA: 0x0033A4A8 File Offset: 0x003388A8
		private void OnReceiveChampionshipKnockoutScoreMessage(UIEvent uiEvent)
		{
			this.UpdateContent();
		}

		// Token: 0x04007A81 RID: 31361
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A82 RID: 31362
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007A83 RID: 31363
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x04007A84 RID: 31364
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem firstPlayerItem;

		// Token: 0x04007A85 RID: 31365
		[SerializeField]
		private ChampionshipPlayerItem secondPlayerItem;

		// Token: 0x04007A86 RID: 31366
		[SerializeField]
		private Text playerScoreResultLabel;
	}
}
