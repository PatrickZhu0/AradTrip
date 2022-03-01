using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014FF RID: 5375
	public class ChampionshipFirstWinnerGuessControl : MonoBehaviour
	{
		// Token: 0x0600D0A2 RID: 53410 RVA: 0x00337E81 File Offset: 0x00336281
		private void Awake()
		{
		}

		// Token: 0x0600D0A3 RID: 53411 RVA: 0x00337E83 File Offset: 0x00336283
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D0A4 RID: 53412 RVA: 0x00337E8B File Offset: 0x0033628B
		private void ClearData()
		{
			this._guessProjectDataModel = null;
			this._guessOptionDataModel = null;
			this._guessProjectId = 0U;
			this._guessOptionId = 0UL;
			this._playerDataModel = null;
		}

		// Token: 0x0600D0A5 RID: 53413 RVA: 0x00337EB1 File Offset: 0x003362B1
		private void OnEnable()
		{
		}

		// Token: 0x0600D0A6 RID: 53414 RVA: 0x00337EB3 File Offset: 0x003362B3
		private void OnDisable()
		{
		}

		// Token: 0x0600D0A7 RID: 53415 RVA: 0x00337EB8 File Offset: 0x003362B8
		public void InitControl(ChampionshipGuessProjectDataModel guessProjectDataModel, ChampionshipGuessOptionDataModel guessOptionDataModel)
		{
			this._guessProjectDataModel = guessProjectDataModel;
			this._guessOptionDataModel = guessOptionDataModel;
			if (this._guessProjectDataModel == null)
			{
				return;
			}
			if (this._guessOptionDataModel == null)
			{
				return;
			}
			this._guessProjectId = this._guessProjectDataModel.ProjectId;
			this._guessOptionId = this._guessOptionDataModel.OptionId;
			this._playerDataModel = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._guessOptionId);
			if (this._playerDataModel == null)
			{
				return;
			}
			this.InitBaseContent();
			this.UpdateBetContent();
		}

		// Token: 0x0600D0A8 RID: 53416 RVA: 0x00337F36 File Offset: 0x00336336
		private void InitBaseContent()
		{
			if (this.playerItem != null)
			{
				this.playerItem.Init(this._playerDataModel);
			}
		}

		// Token: 0x0600D0A9 RID: 53417 RVA: 0x00337F5A File Offset: 0x0033635A
		private void UpdateBetContent()
		{
			if (this.guessOptionItem != null)
			{
				this.guessOptionItem.InitItem(this._guessProjectDataModel, this._guessOptionDataModel);
			}
		}

		// Token: 0x0600D0AA RID: 53418 RVA: 0x00337F84 File Offset: 0x00336384
		public void UpdatePlayerAvatar()
		{
			if (this.playerItem != null)
			{
				this.playerItem.UpdatePlayerRenderEx();
			}
		}

		// Token: 0x0600D0AB RID: 53419 RVA: 0x00337FA2 File Offset: 0x003363A2
		public void UpdateControlByUpdateData()
		{
			if (this._guessProjectDataModel == null || this._guessOptionDataModel == null)
			{
				return;
			}
			this.UpdateBetContent();
		}

		// Token: 0x0600D0AC RID: 53420 RVA: 0x00337FC1 File Offset: 0x003363C1
		public void UpdateControlByOnEnable()
		{
			if (this._guessProjectDataModel == null || this._guessOptionDataModel == null)
			{
				return;
			}
			this.UpdateBetContent();
			this.UpdatePlayerAvatar();
		}

		// Token: 0x04007A26 RID: 31270
		private ChampionshipGuessProjectDataModel _guessProjectDataModel;

		// Token: 0x04007A27 RID: 31271
		private ChampionshipGuessOptionDataModel _guessOptionDataModel;

		// Token: 0x04007A28 RID: 31272
		private uint _guessProjectId;

		// Token: 0x04007A29 RID: 31273
		private ulong _guessOptionId;

		// Token: 0x04007A2A RID: 31274
		private ChampionshipTopPlayerDataModel _playerDataModel;

		// Token: 0x04007A2B RID: 31275
		[Space(10f)]
		[Header("player")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem playerItem;

		// Token: 0x04007A2C RID: 31276
		[SerializeField]
		private ChampionshipGuessOptionItem guessOptionItem;
	}
}
