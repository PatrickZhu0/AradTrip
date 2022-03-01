using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001501 RID: 5377
	public class ChampionshipFirstWinnerGuessPlayerItem : MonoBehaviour
	{
		// Token: 0x0600D0B2 RID: 53426 RVA: 0x00337FEE File Offset: 0x003363EE
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D0B3 RID: 53427 RVA: 0x00337FF6 File Offset: 0x003363F6
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D0B4 RID: 53428 RVA: 0x00338004 File Offset: 0x00336404
		private void BindUiEvents()
		{
			if (this.playerItemSelectButton != null)
			{
				this.playerItemSelectButton.onClick.RemoveAllListeners();
				this.playerItemSelectButton.onClick.AddListener(new UnityAction(this.OnPlayerItemSelectButtonClicked));
			}
		}

		// Token: 0x0600D0B5 RID: 53429 RVA: 0x00338043 File Offset: 0x00336443
		private void UnBindUiEvents()
		{
			if (this.playerItemSelectButton != null)
			{
				this.playerItemSelectButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600D0B6 RID: 53430 RVA: 0x00338066 File Offset: 0x00336466
		private void ClearData()
		{
			this._guessPlayerDataModel = null;
			this._guessPlayerItemClickAction = null;
		}

		// Token: 0x0600D0B7 RID: 53431 RVA: 0x00338076 File Offset: 0x00336476
		public void InitItem(ChampionshipFirstWinnerGuessPlayerDataModel guessPlayerDataModel, OnFirstWinnerGuessPlayerItemClickAction guessPlayerItemClickAction)
		{
			this._guessPlayerDataModel = guessPlayerDataModel;
			this._guessPlayerItemClickAction = guessPlayerItemClickAction;
			if (this._guessPlayerDataModel == null)
			{
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600D0B8 RID: 53432 RVA: 0x00338098 File Offset: 0x00336498
		private void InitItemView()
		{
			if (this.championshipPlayerItem != null)
			{
				ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(this._guessPlayerDataModel.OptionId);
				this.championshipPlayerItem.Init(topPlayerDataModelByPlayerGuid);
			}
			this.UpdatePlayerItemSelectedFlag();
		}

		// Token: 0x0600D0B9 RID: 53433 RVA: 0x003380D9 File Offset: 0x003364D9
		public void UpdateItem()
		{
			this.UpdatePlayerItemSelectedFlag();
		}

		// Token: 0x0600D0BA RID: 53434 RVA: 0x003380E1 File Offset: 0x003364E1
		public void RecycleItem()
		{
			this._guessPlayerDataModel = null;
		}

		// Token: 0x0600D0BB RID: 53435 RVA: 0x003380EC File Offset: 0x003364EC
		private void OnPlayerItemSelectButtonClicked()
		{
			if (this._guessPlayerDataModel == null)
			{
				return;
			}
			if (this._guessPlayerItemClickAction == null)
			{
				return;
			}
			if (this._guessPlayerDataModel.IsSelected)
			{
				return;
			}
			this._guessPlayerDataModel.IsSelected = true;
			this.UpdatePlayerItemSelectedFlag();
			if (this._guessPlayerItemClickAction != null)
			{
				this._guessPlayerItemClickAction(this._guessPlayerDataModel.OptionId);
			}
		}

		// Token: 0x0600D0BC RID: 53436 RVA: 0x00338155 File Offset: 0x00336555
		private void UpdatePlayerItemSelectedFlag()
		{
			if (this._guessPlayerDataModel == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.playerItemSelectFlag, this._guessPlayerDataModel.IsSelected);
		}

		// Token: 0x04007A2D RID: 31277
		private ChampionshipFirstWinnerGuessPlayerDataModel _guessPlayerDataModel;

		// Token: 0x04007A2E RID: 31278
		private OnFirstWinnerGuessPlayerItemClickAction _guessPlayerItemClickAction;

		// Token: 0x04007A2F RID: 31279
		[Space(10f)]
		[Header("player")]
		[Space(10f)]
		[SerializeField]
		private Image playerItemBg;

		// Token: 0x04007A30 RID: 31280
		[SerializeField]
		private ChampionshipPlayerItem championshipPlayerItem;

		// Token: 0x04007A31 RID: 31281
		[Space(10f)]
		[Header("ItemSelected")]
		[Space(10f)]
		[SerializeField]
		private GameObject playerItemSelectFlag;

		// Token: 0x04007A32 RID: 31282
		[SerializeField]
		private Button playerItemSelectButton;
	}
}
