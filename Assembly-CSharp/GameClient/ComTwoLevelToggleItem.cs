using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F9D RID: 3997
	public class ComTwoLevelToggleItem : MonoBehaviour
	{
		// Token: 0x06009A6C RID: 39532 RVA: 0x001DD834 File Offset: 0x001DBC34
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnFirstLevelToggleClick));
			}
		}

		// Token: 0x06009A6D RID: 39533 RVA: 0x001DD873 File Offset: 0x001DBC73
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x06009A6E RID: 39534 RVA: 0x001DD89C File Offset: 0x001DBC9C
		private void ResetData()
		{
			this._comTwoLevelToggleData = null;
			this._comFirstLevelToggleData = null;
			this._isOwnerSecondLevel = false;
			this._onFirstLevelToggleClick = null;
			this._onSecondLevelToggleClick = null;
		}

		// Token: 0x06009A6F RID: 39535 RVA: 0x001DD8C4 File Offset: 0x001DBCC4
		public void InitItem(ComTwoLevelToggleData comTwoLevelToggleData, OnComToggleClick onFirstLevelToggleClick = null, OnComToggleClick onSecondLevelToggleClick = null)
		{
			this.ResetData();
			this._comTwoLevelToggleData = comTwoLevelToggleData;
			if (this._comTwoLevelToggleData == null || this._comTwoLevelToggleData.FirstLevelToggleData == null)
			{
				Logger.LogErrorFormat("ComFirstLevelToggleItem InitItem comFirstLevelToggleData is null", new object[0]);
				return;
			}
			this._comFirstLevelToggleData = this._comTwoLevelToggleData.FirstLevelToggleData;
			this._onFirstLevelToggleClick = onFirstLevelToggleClick;
			this._onSecondLevelToggleClick = onSecondLevelToggleClick;
			this.InitSecondLevelToggleData();
			this.InitItemView();
		}

		// Token: 0x06009A70 RID: 39536 RVA: 0x001DD938 File Offset: 0x001DBD38
		private void InitSecondLevelToggleData()
		{
			this._isOwnerSecondLevel = true;
			if (this._comTwoLevelToggleData.SecondLevelToggleDataList == null || this._comTwoLevelToggleData.SecondLevelToggleDataList.Count <= 0)
			{
				this._isOwnerSecondLevel = false;
			}
			if (this._isOwnerSecondLevel && this.secondLevelToggleView != null)
			{
				this.secondLevelToggleView.InitSecondLevelToggleViewData(this._comTwoLevelToggleData, this._onSecondLevelToggleClick);
			}
		}

		// Token: 0x06009A71 RID: 39537 RVA: 0x001DD9AC File Offset: 0x001DBDAC
		protected virtual void InitItemView()
		{
			this.InitItemName();
			this.InitArrowRoot();
			this.InitItemToggle();
		}

		// Token: 0x06009A72 RID: 39538 RVA: 0x001DD9C0 File Offset: 0x001DBDC0
		private void InitItemName()
		{
			if (this.normalName != null)
			{
				this.normalName.text = this._comFirstLevelToggleData.Name;
			}
			if (this.selectedName != null)
			{
				this.selectedName.text = this._comFirstLevelToggleData.Name;
			}
		}

		// Token: 0x06009A73 RID: 39539 RVA: 0x001DDA1B File Offset: 0x001DBE1B
		private void InitItemToggle()
		{
			if (this.toggle != null)
			{
				if (this._comFirstLevelToggleData.IsSelected)
				{
					this.toggle.isOn = true;
				}
				else
				{
					this.toggle.isOn = false;
				}
			}
		}

		// Token: 0x06009A74 RID: 39540 RVA: 0x001DDA5C File Offset: 0x001DBE5C
		private void OnFirstLevelToggleClick(bool value)
		{
			if (this._comFirstLevelToggleData == null)
			{
				return;
			}
			this._comFirstLevelToggleData.IsSelected = value;
			if (value)
			{
				if (this._onFirstLevelToggleClick != null)
				{
					this._onFirstLevelToggleClick(this._comFirstLevelToggleData);
				}
				if (this._isOwnerSecondLevel)
				{
					this.UpdateNormalArrow(false);
					this.UpdateSecondLevelToggleViewVisible(true);
					if (this.secondLevelToggleView != null)
					{
						this.secondLevelToggleView.ShowSecondLevelToggleView();
					}
				}
			}
			else if (this._isOwnerSecondLevel)
			{
				this.UpdateNormalArrow(true);
				this.UpdateSecondLevelToggleViewVisible(false);
			}
		}

		// Token: 0x06009A75 RID: 39541 RVA: 0x001DDAF6 File Offset: 0x001DBEF6
		private void InitArrowRoot()
		{
			CommonUtility.UpdateGameObjectVisible(this.arrowRoot, this._isOwnerSecondLevel);
			this.UpdateNormalArrow(this._isOwnerSecondLevel);
		}

		// Token: 0x06009A76 RID: 39542 RVA: 0x001DDB15 File Offset: 0x001DBF15
		private void UpdateNormalArrow(bool flag)
		{
			CommonUtility.UpdateImageVisible(this.normalArrow, flag);
			CommonUtility.UpdateImageVisible(this.selectedArrow, !flag);
		}

		// Token: 0x06009A77 RID: 39543 RVA: 0x001DDB32 File Offset: 0x001DBF32
		private void UpdateSecondLevelToggleViewVisible(bool flag)
		{
			if (this.secondLevelToggleView != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.secondLevelToggleView.gameObject, flag);
			}
		}

		// Token: 0x04004FF7 RID: 20471
		private ComTwoLevelToggleData _comTwoLevelToggleData;

		// Token: 0x04004FF8 RID: 20472
		protected ComControlData _comFirstLevelToggleData;

		// Token: 0x04004FF9 RID: 20473
		private bool _isOwnerSecondLevel;

		// Token: 0x04004FFA RID: 20474
		private OnComToggleClick _onFirstLevelToggleClick;

		// Token: 0x04004FFB RID: 20475
		private OnComToggleClick _onSecondLevelToggleClick;

		// Token: 0x04004FFC RID: 20476
		[Space(10f)]
		[Header("FirstLevelToggle")]
		[Space(5f)]
		[SerializeField]
		private Toggle toggle;

		// Token: 0x04004FFD RID: 20477
		[SerializeField]
		private Text normalName;

		// Token: 0x04004FFE RID: 20478
		[SerializeField]
		private Text selectedName;

		// Token: 0x04004FFF RID: 20479
		[Space(10f)]
		[Header("Arrow")]
		[Space(5f)]
		[SerializeField]
		private GameObject arrowRoot;

		// Token: 0x04005000 RID: 20480
		[SerializeField]
		private Image normalArrow;

		// Token: 0x04005001 RID: 20481
		[SerializeField]
		private Image selectedArrow;

		// Token: 0x04005002 RID: 20482
		[Space(10f)]
		[Header("SecondLevelToggleView")]
		[Space(5f)]
		[SerializeField]
		private ComSecondLevelToggleView secondLevelToggleView;
	}
}
