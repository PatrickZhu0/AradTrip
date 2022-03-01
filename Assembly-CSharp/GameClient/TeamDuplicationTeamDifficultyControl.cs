using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C44 RID: 7236
	public class TeamDuplicationTeamDifficultyControl : MonoBehaviour
	{
		// Token: 0x06011C5B RID: 72795 RVA: 0x00534764 File Offset: 0x00532B64
		private void Awake()
		{
			if (this.normalLevelButton != null)
			{
				this.normalLevelButton.onClick.RemoveAllListeners();
				this.normalLevelButton.onClick.AddListener(new UnityAction(this.OnNormalLevelButtonClicked));
				this.AddPointerDownTriggerListener(this.normalLevelButton.gameObject, new TeamDuplicationTeamDifficultyControl.PointerDownMethod(this.OnNormalLevelButtonPointerDownClicked));
			}
			if (this.hardLevelButton != null)
			{
				this.hardLevelButton.onClick.RemoveAllListeners();
				this.hardLevelButton.onClick.AddListener(new UnityAction(this.OnHardLevelButtonClicked));
				this.AddPointerDownTriggerListener(this.hardLevelButton.gameObject, new TeamDuplicationTeamDifficultyControl.PointerDownMethod(this.OnHardLevelButtonPointerDownClicked));
			}
		}

		// Token: 0x06011C5C RID: 72796 RVA: 0x00534828 File Offset: 0x00532C28
		private void OnDestroy()
		{
			if (this.normalLevelButton != null)
			{
				this.normalLevelButton.onClick.RemoveAllListeners();
			}
			if (this.hardLevelButton != null)
			{
				this.hardLevelButton.onClick.RemoveAllListeners();
			}
			this._onTeamDifficultyClickedAction = null;
			this._playerInformationDataModel = null;
			this._isHardLevelUnlock = false;
			this._normalSelectedEffectPrefab = null;
			this._hardSelectedEffectPrefab = null;
			this._pointerDownEffectPrefab = null;
			this._selectedButtonType = TeamDuplicationTeamDifficultyControl.SelectedButtonType.Invalid;
		}

		// Token: 0x06011C5D RID: 72797 RVA: 0x005348A8 File Offset: 0x00532CA8
		public void Init(OnTeamDifficultyClickedAction onTeamDifficultyClickedAction)
		{
			this._onTeamDifficultyClickedAction = onTeamDifficultyClickedAction;
			this._playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			if (this._playerInformationDataModel == null)
			{
				return;
			}
			this.InitControlView();
		}

		// Token: 0x06011C5E RID: 72798 RVA: 0x005348D3 File Offset: 0x00532CD3
		private void InitControlView()
		{
			CommonUtility.UpdateGameObjectVisible(this.normalSelectedEffectRoot, true);
			this.UpdateNormalSelectedEffect(this.normalSelectedEffectRoot);
			this._selectedButtonType = TeamDuplicationTeamDifficultyControl.SelectedButtonType.NormalButtonType;
			this.InitHardLevelContent();
		}

		// Token: 0x06011C5F RID: 72799 RVA: 0x005348FC File Offset: 0x00532CFC
		private void InitHardLevelContent()
		{
			CommonUtility.UpdateGameObjectVisible(this.hardSelectedEffectRoot, false);
			this._isHardLevelUnlock = this.IsHardLevelUnLock();
			if (this._isHardLevelUnlock)
			{
				CommonUtility.UpdateGameObjectVisible(this.hardLevelDescriptionRoot, false);
				CommonUtility.UpdateButtonState(this.hardLevelButton, this.hardLevelButtonUIGray, true);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.hardLevelButton, this.hardLevelButtonUIGray, false);
				CommonUtility.UpdateGameObjectVisible(this.hardLevelDescriptionRoot, true);
				if (this.hardLevelDescriptionLabel != null)
				{
					this.hardLevelDescriptionLabel.text = string.Format(TR.Value("team_duplication_team_difficulty_unlock_hard_require"), this._playerInformationDataModel.CommonLevelPassNumber, this._playerInformationDataModel.UnLockCommonLevelTotalNumber);
				}
			}
		}

		// Token: 0x06011C60 RID: 72800 RVA: 0x005349B8 File Offset: 0x00532DB8
		private void OnNormalLevelButtonClicked()
		{
			this._selectedButtonType = TeamDuplicationTeamDifficultyControl.SelectedButtonType.NormalButtonType;
			CommonUtility.UpdateGameObjectVisible(this.normalSelectedEffectRoot, true);
			this.UpdateNormalSelectedEffect(this.normalSelectedEffectRoot);
			if (this._isHardLevelUnlock)
			{
				CommonUtility.UpdateGameObjectVisible(this.hardSelectedEffectRoot, false);
			}
			if (this._onTeamDifficultyClickedAction != null)
			{
				this._onTeamDifficultyClickedAction(1U);
			}
		}

		// Token: 0x06011C61 RID: 72801 RVA: 0x00534A14 File Offset: 0x00532E14
		private void OnHardLevelButtonClicked()
		{
			if (!this._isHardLevelUnlock)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.normalSelectedEffectRoot, false);
			this._selectedButtonType = TeamDuplicationTeamDifficultyControl.SelectedButtonType.HardButtonType;
			CommonUtility.UpdateGameObjectVisible(this.hardSelectedEffectRoot, true);
			this.UpdateHardSelectedEffect(this.hardSelectedEffectRoot);
			if (this._onTeamDifficultyClickedAction != null)
			{
				this._onTeamDifficultyClickedAction(2U);
			}
		}

		// Token: 0x06011C62 RID: 72802 RVA: 0x00534A70 File Offset: 0x00532E70
		private bool IsHardLevelUnLock()
		{
			if (this._playerInformationDataModel == null)
			{
				return false;
			}
			if (this._playerInformationDataModel.AlreadyOpenDifficultyList == null || this._playerInformationDataModel.AlreadyOpenDifficultyList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._playerInformationDataModel.AlreadyOpenDifficultyList.Count; i++)
			{
				uint num = this._playerInformationDataModel.AlreadyOpenDifficultyList[i];
				if (num == 2U)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06011C63 RID: 72803 RVA: 0x00534AEF File Offset: 0x00532EEF
		private void UpdateNormalSelectedEffect(GameObject effectRoot)
		{
			if (effectRoot == null)
			{
				return;
			}
			if (this._normalSelectedEffectPrefab != null)
			{
				return;
			}
			this._normalSelectedEffectPrefab = CommonUtility.LoadGameObject(effectRoot);
		}

		// Token: 0x06011C64 RID: 72804 RVA: 0x00534B1C File Offset: 0x00532F1C
		private void UpdateHardSelectedEffect(GameObject effectRoot)
		{
			if (effectRoot == null)
			{
				return;
			}
			if (this._hardSelectedEffectPrefab != null)
			{
				return;
			}
			this._hardSelectedEffectPrefab = CommonUtility.LoadGameObject(effectRoot);
		}

		// Token: 0x06011C65 RID: 72805 RVA: 0x00534B49 File Offset: 0x00532F49
		private void OnHardLevelButtonPointerDownClicked(BaseEventData baseEventData)
		{
			if (!this._isHardLevelUnlock)
			{
				return;
			}
			if (this._selectedButtonType == TeamDuplicationTeamDifficultyControl.SelectedButtonType.HardButtonType)
			{
				return;
			}
			this.SetPointerDownEffectPrefab(this.hardPointerDownEffectRoot);
		}

		// Token: 0x06011C66 RID: 72806 RVA: 0x00534B70 File Offset: 0x00532F70
		private void OnNormalLevelButtonPointerDownClicked(BaseEventData baseEventData)
		{
			if (this._selectedButtonType == TeamDuplicationTeamDifficultyControl.SelectedButtonType.NormalButtonType)
			{
				return;
			}
			this.SetPointerDownEffectPrefab(this.normalPointerDownEffectRoot);
		}

		// Token: 0x06011C67 RID: 72807 RVA: 0x00534B8C File Offset: 0x00532F8C
		private void SetPointerDownEffectPrefab(GameObject buttonEffectRoot)
		{
			if (buttonEffectRoot == null)
			{
				return;
			}
			if (this.pointerDownEffectRoot == null)
			{
				return;
			}
			if (this._pointerDownEffectPrefab == null)
			{
				this._pointerDownEffectPrefab = CommonUtility.LoadGameObject(this.pointerDownEffectRoot);
			}
			if (this._pointerDownEffectPrefab != null)
			{
				this._pointerDownEffectPrefab.CustomActive(false);
				this._pointerDownEffectPrefab.CustomActive(true);
			}
			this.pointerDownEffectRoot.transform.SetParent(buttonEffectRoot.transform, false);
			this.pointerDownEffectRoot.transform.localPosition = Vector3.zero;
		}

		// Token: 0x06011C68 RID: 72808 RVA: 0x00534C30 File Offset: 0x00533030
		private void AddPointerDownTriggerListener(GameObject clickObject, TeamDuplicationTeamDifficultyControl.PointerDownMethod pointerDownMethod)
		{
			EventTrigger eventTrigger = clickObject.GetComponent<EventTrigger>();
			if (eventTrigger == null)
			{
				eventTrigger = clickObject.AddComponent<EventTrigger>();
			}
			eventTrigger.triggers = new List<EventTrigger.Entry>();
			UnityAction<BaseEventData> unityAction = new UnityAction<BaseEventData>(pointerDownMethod.Invoke);
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = 2;
			entry.callback.AddListener(unityAction);
			eventTrigger.triggers.Add(entry);
		}

		// Token: 0x0400B923 RID: 47395
		private TeamDuplicationTeamDifficultyControl.SelectedButtonType _selectedButtonType;

		// Token: 0x0400B924 RID: 47396
		private OnTeamDifficultyClickedAction _onTeamDifficultyClickedAction;

		// Token: 0x0400B925 RID: 47397
		private TeamDuplicationPlayerInformationDataModel _playerInformationDataModel;

		// Token: 0x0400B926 RID: 47398
		private bool _isHardLevelUnlock;

		// Token: 0x0400B927 RID: 47399
		private GameObject _normalSelectedEffectPrefab;

		// Token: 0x0400B928 RID: 47400
		private GameObject _hardSelectedEffectPrefab;

		// Token: 0x0400B929 RID: 47401
		private GameObject _pointerDownEffectPrefab;

		// Token: 0x0400B92A RID: 47402
		[Space(15f)]
		[Header("NormalRoot")]
		[Space(5f)]
		[SerializeField]
		private Button normalLevelButton;

		// Token: 0x0400B92B RID: 47403
		[SerializeField]
		private GameObject normalSelectedEffectRoot;

		// Token: 0x0400B92C RID: 47404
		[SerializeField]
		private GameObject normalPointerDownEffectRoot;

		// Token: 0x0400B92D RID: 47405
		[Space(15f)]
		[Header("HardRoot")]
		[Space(5f)]
		[SerializeField]
		private Button hardLevelButton;

		// Token: 0x0400B92E RID: 47406
		[SerializeField]
		private UIGray hardLevelButtonUIGray;

		// Token: 0x0400B92F RID: 47407
		[SerializeField]
		private GameObject hardSelectedEffectRoot;

		// Token: 0x0400B930 RID: 47408
		[SerializeField]
		private GameObject hardPointerDownEffectRoot;

		// Token: 0x0400B931 RID: 47409
		[Space(15f)]
		[Header("HardLevelDescription")]
		[Space(5f)]
		[SerializeField]
		private GameObject hardLevelDescriptionRoot;

		// Token: 0x0400B932 RID: 47410
		[SerializeField]
		private Text hardLevelDescriptionLabel;

		// Token: 0x0400B933 RID: 47411
		[Space(15f)]
		[Header("pointerDownRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject pointerDownEffectRoot;

		// Token: 0x02001C45 RID: 7237
		private enum SelectedButtonType
		{
			// Token: 0x0400B935 RID: 47413
			Invalid = -1,
			// Token: 0x0400B936 RID: 47414
			NormalButtonType,
			// Token: 0x0400B937 RID: 47415
			HardButtonType
		}

		// Token: 0x02001C46 RID: 7238
		// (Invoke) Token: 0x06011C6A RID: 72810
		private delegate void PointerDownMethod(BaseEventData baseEventData);
	}
}
