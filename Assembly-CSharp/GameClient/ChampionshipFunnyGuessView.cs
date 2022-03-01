using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014FC RID: 5372
	public class ChampionshipFunnyGuessView : MonoBehaviour
	{
		// Token: 0x0600D088 RID: 53384 RVA: 0x00337861 File Offset: 0x00335C61
		private void Awake()
		{
		}

		// Token: 0x0600D089 RID: 53385 RVA: 0x00337863 File Offset: 0x00335C63
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D08A RID: 53386 RVA: 0x0033786B File Offset: 0x00335C6B
		private void ClearData()
		{
			this._isFightRaceNumberProjectBuild = false;
			this._isFinalScoreProjectBuild = false;
		}

		// Token: 0x0600D08B RID: 53387 RVA: 0x0033787B File Offset: 0x00335C7B
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D08C RID: 53388 RVA: 0x00337898 File Offset: 0x00335C98
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGuessProjectResMessage));
		}

		// Token: 0x0600D08D RID: 53389 RVA: 0x003378B5 File Offset: 0x00335CB5
		public void InitView()
		{
			if (this.funnyGuessTitleLabel != null)
			{
				this.funnyGuessTitleLabel.text = TR.Value("Championship_Guess_Funny_Guess_Description");
			}
			this.UpdateContent();
		}

		// Token: 0x0600D08E RID: 53390 RVA: 0x003378E3 File Offset: 0x00335CE3
		public void OnEnableView()
		{
			this.UpdateContent();
		}

		// Token: 0x0600D08F RID: 53391 RVA: 0x003378EC File Offset: 0x00335CEC
		private void UpdateContent()
		{
			if (this._isFightRaceNumberProjectBuild)
			{
				if (this.fightRaceNumberControl != null)
				{
					this.fightRaceNumberControl.UpdateControl();
				}
			}
			else
			{
				ChampionshipGuessProjectDataModel championshipGuessProjectDataModelByProjectType = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectType(GambleType.GT_BATTLE_COUNT, 0);
				if (championshipGuessProjectDataModelByProjectType != null)
				{
					if (this.fightRaceNumberControl != null)
					{
						this.fightRaceNumberControl.InitControl(championshipGuessProjectDataModelByProjectType);
					}
					this._isFightRaceNumberProjectBuild = true;
				}
			}
			if (this._isFinalScoreProjectBuild)
			{
				if (this.finalScoreControl != null)
				{
					this.finalScoreControl.UpdateControl();
				}
			}
			else
			{
				ChampionshipGuessProjectDataModel championshipGuessProjectDataModelByProjectType2 = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectType(GambleType.GT_CHAMPION_BATTLE_SCORE, 0);
				if (championshipGuessProjectDataModelByProjectType2 != null)
				{
					if (this.finalScoreControl != null)
					{
						this.finalScoreControl.InitControl(championshipGuessProjectDataModelByProjectType2);
					}
					this._isFinalScoreProjectBuild = true;
				}
			}
		}

		// Token: 0x0600D090 RID: 53392 RVA: 0x003379B5 File Offset: 0x00335DB5
		private void OnReceiveChampionshipGuessProjectResMessage(UIEvent uiEvent)
		{
			this.UpdateContent();
		}

		// Token: 0x04007A0E RID: 31246
		private bool _isFightRaceNumberProjectBuild;

		// Token: 0x04007A0F RID: 31247
		private bool _isFinalScoreProjectBuild;

		// Token: 0x04007A10 RID: 31248
		[Space(10f)]
		[Header("title")]
		[Space(10f)]
		[SerializeField]
		private Text funnyGuessTitleLabel;

		// Token: 0x04007A11 RID: 31249
		[Space(10f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipFunnyGuessControl fightRaceNumberControl;

		// Token: 0x04007A12 RID: 31250
		[SerializeField]
		private ChampionshipFunnyGuessControl finalScoreControl;
	}
}
