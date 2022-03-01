using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C3F RID: 7231
	public class TeamDuplicationFightPanelControl : MonoBehaviour
	{
		// Token: 0x06011C38 RID: 72760 RVA: 0x00534089 File Offset: 0x00532489
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06011C39 RID: 72761 RVA: 0x00534091 File Offset: 0x00532491
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06011C3A RID: 72762 RVA: 0x0053409F File Offset: 0x0053249F
		private void BindEvents()
		{
			if (this.fightPanelShowButton != null)
			{
				this.fightPanelShowButton.onClick.RemoveAllListeners();
				this.fightPanelShowButton.onClick.AddListener(new UnityAction(this.OnFightPanelShowButtonClick));
			}
		}

		// Token: 0x06011C3B RID: 72763 RVA: 0x005340DE File Offset: 0x005324DE
		private void UnBindEvents()
		{
			if (this.fightPanelShowButton != null)
			{
				this.fightPanelShowButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011C3C RID: 72764 RVA: 0x00534101 File Offset: 0x00532501
		private void ClearData()
		{
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011C3D RID: 72765 RVA: 0x0053410A File Offset: 0x0053250A
		public void InitFightPanelControl(bool isIn65LevelTeamDuplication = false)
		{
			this._isIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
		}

		// Token: 0x06011C3E RID: 72766 RVA: 0x00534113 File Offset: 0x00532513
		private void OnFightPanelShowButtonClick()
		{
			this.OnFightPanelShow();
		}

		// Token: 0x06011C3F RID: 72767 RVA: 0x0053411B File Offset: 0x0053251B
		public void OnFightPanelShow()
		{
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationGridMapFrame();
			}
			else
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationFightStagePanelFrame(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageId);
			}
		}

		// Token: 0x06011C40 RID: 72768 RVA: 0x00534141 File Offset: 0x00532541
		public void UpdateFightPanelShowButton(bool flag)
		{
			CommonUtility.UpdateButtonVisible(this.fightPanelShowButton, flag);
		}

		// Token: 0x0400B910 RID: 47376
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B911 RID: 47377
		[Space(15f)]
		[Header("FightPanel")]
		[Space(5f)]
		[SerializeField]
		private Button fightPanelShowButton;
	}
}
