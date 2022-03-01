using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A95 RID: 6805
	public class WeekSignInCommonControl : MonoBehaviour
	{
		// Token: 0x06010B4D RID: 68429 RVA: 0x004BD05C File Offset: 0x004BB45C
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06010B4E RID: 68430 RVA: 0x004BD064 File Offset: 0x004BB464
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06010B4F RID: 68431 RVA: 0x004BD072 File Offset: 0x004BB472
		private void ClearData()
		{
			this._weekSignInType = WeekSignInType.None;
			this._previewAwardItemDataModelList = null;
		}

		// Token: 0x06010B50 RID: 68432 RVA: 0x004BD084 File Offset: 0x004BB484
		private void BindEvents()
		{
			if (this.weekSignInAwardRecordButton != null)
			{
				this.weekSignInAwardRecordButton.onClick.RemoveAllListeners();
				this.weekSignInAwardRecordButton.onClick.AddListener(new UnityAction(this.OnAwardRecordButtonClick));
			}
			if (this.weekSignInDetailItemList != null)
			{
				ComUIListScript comUIListScript = this.weekSignInDetailItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06010B51 RID: 68433 RVA: 0x004BD108 File Offset: 0x004BB508
		private void UnBindEvents()
		{
			if (this.weekSignInAwardRecordButton != null)
			{
				this.weekSignInAwardRecordButton.onClick.RemoveAllListeners();
			}
			if (this.weekSignInDetailItemList != null)
			{
				ComUIListScript comUIListScript = this.weekSignInDetailItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06010B52 RID: 68434 RVA: 0x004BD16E File Offset: 0x004BB56E
		public void InitCommonControl(WeekSignInType weekSignInType)
		{
			this._weekSignInType = weekSignInType;
			this._previewAwardItemDataModelList = DataManager<WeekSignInDataManager>.GetInstance().GetPreviewAwardItemDataModelListByWeekSignInType(this._weekSignInType);
			this.InitCommonView();
		}

		// Token: 0x06010B53 RID: 68435 RVA: 0x004BD194 File Offset: 0x004BB594
		private void InitCommonView()
		{
			if (this.weekSignInTimeText != null)
			{
				this.weekSignInTimeText.text = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInTimeLabelByWeekSignInType(this._weekSignInType);
			}
			if (this._weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				if (this.weekSignInHelpButton != null)
				{
					this.weekSignInHelpButton.HelpId = 5400;
				}
			}
			else if (this.weekSignInHelpButton != null)
			{
				this.weekSignInHelpButton.HelpId = 5500;
			}
			int elementAmount = 0;
			if (this._previewAwardItemDataModelList != null && this._previewAwardItemDataModelList.Count > 0)
			{
				elementAmount = this._previewAwardItemDataModelList.Count;
			}
			if (this.weekSignInDetailItemList != null)
			{
				this.weekSignInDetailItemList.Initialize();
				this.weekSignInDetailItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x06010B54 RID: 68436 RVA: 0x004BD272 File Offset: 0x004BB672
		public void OnEnableCommonControl()
		{
		}

		// Token: 0x06010B55 RID: 68437 RVA: 0x004BD274 File Offset: 0x004BB674
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._previewAwardItemDataModelList == null || this._previewAwardItemDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._previewAwardItemDataModelList.Count)
			{
				return;
			}
			WeekSignInPreviewAwardDataModel weekSignInPreviewAwardDataModel = this._previewAwardItemDataModelList[item.m_index];
			WeekSignInPreviewAwardItem component = item.GetComponent<WeekSignInPreviewAwardItem>();
			if (weekSignInPreviewAwardDataModel != null && component != null)
			{
				component.InitItem(weekSignInPreviewAwardDataModel);
			}
		}

		// Token: 0x06010B56 RID: 68438 RVA: 0x004BD300 File Offset: 0x004BB700
		private void OnAwardRecordButtonClick()
		{
			if (this._weekSignInType == WeekSignInType.None)
			{
				Logger.LogErrorFormat("WeekSingInType is None", new object[0]);
				return;
			}
			WeekSignInUtility.OnOpenWeekSignInAwardRecordFrame((int)this._weekSignInType);
		}

		// Token: 0x0400AAD5 RID: 43733
		private WeekSignInType _weekSignInType;

		// Token: 0x0400AAD6 RID: 43734
		private List<WeekSignInPreviewAwardDataModel> _previewAwardItemDataModelList;

		// Token: 0x0400AAD7 RID: 43735
		[Space(15f)]
		[Header("CommonControl")]
		[Space(10f)]
		[SerializeField]
		private Text weekSignInTimeText;

		// Token: 0x0400AAD8 RID: 43736
		[SerializeField]
		private Button weekSignInAwardRecordButton;

		// Token: 0x0400AAD9 RID: 43737
		[SerializeField]
		private CommonHelpNewAssistant weekSignInHelpButton;

		// Token: 0x0400AADA RID: 43738
		[SerializeField]
		private ComUIListScript weekSignInDetailItemList;
	}
}
