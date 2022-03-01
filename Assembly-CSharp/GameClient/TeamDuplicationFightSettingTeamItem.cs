using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C92 RID: 7314
	public class TeamDuplicationFightSettingTeamItem : MonoBehaviour
	{
		// Token: 0x06011EF1 RID: 73457 RVA: 0x0053E9D7 File Offset: 0x0053CDD7
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011EF2 RID: 73458 RVA: 0x0053E9DF File Offset: 0x0053CDDF
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011EF3 RID: 73459 RVA: 0x0053E9ED File Offset: 0x0053CDED
		private void BindUiEvents()
		{
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
				this.teamButton.onClick.AddListener(new UnityAction(this.OnTeamButtonClick));
			}
		}

		// Token: 0x06011EF4 RID: 73460 RVA: 0x0053EA2C File Offset: 0x0053CE2C
		private void UnBindUiEvents()
		{
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011EF5 RID: 73461 RVA: 0x0053EA4F File Offset: 0x0053CE4F
		private void ClearData()
		{
			this._teamIndex = 0;
			this._isSelected = false;
			this._fightSettingTeamButtonAction = null;
		}

		// Token: 0x06011EF6 RID: 73462 RVA: 0x0053EA66 File Offset: 0x0053CE66
		public void Init(int teamIndex, bool isSelected, OnTeamDuplicationFightSettingTeamButtonAction fightSettingTeamButtonAction)
		{
			this._teamIndex = teamIndex;
			this._isSelected = isSelected;
			this._fightSettingTeamButtonAction = fightSettingTeamButtonAction;
			this.UpdateTeamItem();
		}

		// Token: 0x06011EF7 RID: 73463 RVA: 0x0053EA83 File Offset: 0x0053CE83
		private void UpdateTeamItem()
		{
			CommonUtility.UpdateGameObjectVisible(this.teamSelectedFlag, this._isSelected);
		}

		// Token: 0x06011EF8 RID: 73464 RVA: 0x0053EA98 File Offset: 0x0053CE98
		private void OnTeamButtonClick()
		{
			this._isSelected = !this._isSelected;
			this.UpdateTeamItem();
			if (this._fightSettingTeamButtonAction != null)
			{
				if (this._isSelected)
				{
					this._fightSettingTeamButtonAction(this._teamIndex);
				}
				else
				{
					this._fightSettingTeamButtonAction(0);
				}
			}
		}

		// Token: 0x06011EF9 RID: 73465 RVA: 0x0053EAF2 File Offset: 0x0053CEF2
		public void SetTeamItem(bool isSelected)
		{
			this._isSelected = isSelected;
			this.UpdateTeamItem();
		}

		// Token: 0x06011EFA RID: 73466 RVA: 0x0053EB01 File Offset: 0x0053CF01
		public int GetTeamIndex()
		{
			return this._teamIndex;
		}

		// Token: 0x0400BAE1 RID: 47841
		private int _teamIndex;

		// Token: 0x0400BAE2 RID: 47842
		private bool _isSelected;

		// Token: 0x0400BAE3 RID: 47843
		private OnTeamDuplicationFightSettingTeamButtonAction _fightSettingTeamButtonAction;

		// Token: 0x0400BAE4 RID: 47844
		[Space(10f)]
		[Header("TeamInfo")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamSelectedFlag;

		// Token: 0x0400BAE5 RID: 47845
		[SerializeField]
		private Button teamButton;
	}
}
