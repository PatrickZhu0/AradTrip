using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F7F RID: 3967
	public class CommonNewDropDownControl : MonoBehaviour
	{
		// Token: 0x06009951 RID: 39249 RVA: 0x001D801C File Offset: 0x001D641C
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06009952 RID: 39250 RVA: 0x001D8024 File Offset: 0x001D6424
		private void BindUiEventSystem()
		{
			if (this.dropDownButton != null)
			{
				this.dropDownButton.onClick.RemoveAllListeners();
				this.dropDownButton.onClick.AddListener(new UnityAction(this.OnDropDownButtonClick));
			}
			if (this.dropDownListCloseButton != null)
			{
				this.dropDownListCloseButton.onClick.RemoveAllListeners();
				this.dropDownListCloseButton.onClick.AddListener(new UnityAction(this.OnDropDownListCloseButton));
			}
		}

		// Token: 0x06009953 RID: 39251 RVA: 0x001D80AB File Offset: 0x001D64AB
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06009954 RID: 39252 RVA: 0x001D80BC File Offset: 0x001D64BC
		private void UnBindUiEventSystem()
		{
			if (this.dropDownButton != null)
			{
				this.dropDownButton.onClick.RemoveAllListeners();
			}
			if (this.dropDownListCloseButton != null)
			{
				this.dropDownListCloseButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009955 RID: 39253 RVA: 0x001D810B File Offset: 0x001D650B
		private void ClearData()
		{
			this._commonNewControlData = null;
			this._commonNewDropDownDataList = null;
			this._onCommonNewDropDownItemButtonClick = null;
			this._onResetDropDownListAction = null;
			this._commonNewDropDownListView = null;
		}

		// Token: 0x06009956 RID: 39254 RVA: 0x001D8130 File Offset: 0x001D6530
		public void InitComDropDownControl(ComControlData comControlData, List<ComControlData> comDropDownDataList, OnCommonNewDropDownItemButtonClick onCommonNewDropDownItemButtonClick, Action onResetDropDownAction = null)
		{
			this.ClearData();
			this._commonNewControlData = comControlData;
			if (this._commonNewControlData == null)
			{
				Logger.LogError("CommonNewControlData is null");
				return;
			}
			this._commonNewDropDownDataList = comDropDownDataList;
			if (this._commonNewDropDownDataList == null || this._commonNewDropDownDataList.Count <= 0)
			{
				Logger.LogError("ComDropDownDataList is null");
				return;
			}
			this._onCommonNewDropDownItemButtonClick = onCommonNewDropDownItemButtonClick;
			this._onResetDropDownListAction = onResetDropDownAction;
			this.InitCommonNewDropDownControl();
		}

		// Token: 0x06009957 RID: 39255 RVA: 0x001D81A3 File Offset: 0x001D65A3
		private void InitCommonNewDropDownControl()
		{
			this.UpdateDropDownLabelName();
			this.UpdateDropDownList(false);
		}

		// Token: 0x06009958 RID: 39256 RVA: 0x001D81B4 File Offset: 0x001D65B4
		private void OnDropDownButtonClick()
		{
			if (this._onResetDropDownListAction != null)
			{
				this._onResetDropDownListAction();
			}
			if (this._commonNewDropDownDataList == null || this._commonNewDropDownDataList.Count <= 0)
			{
				return;
			}
			if (this._commonNewDropDownListView == null)
			{
				this.UpdateDropDownList(true);
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.dropDownListPath, true, 0U);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.dropDownListRoot.transform, false);
					this.UpdateDropDownListPrefabPosition(gameObject);
					this._commonNewDropDownListView = gameObject.GetComponent<CommonNewDropDownListView>();
					this._commonNewDropDownListView.InitCommonNewDropDownListView(this._commonNewControlData, this._commonNewDropDownDataList, new OnCommonNewDropDownItemButtonClick(this.OnCommonNewDropDownItemButtonClick));
				}
			}
			else if (this.dropDownListRoot.gameObject.activeInHierarchy)
			{
				this.UpdateDropDownList(false);
			}
			else
			{
				this.UpdateDropDownList(true);
				this._commonNewDropDownListView.UpdateSelectedItemPosition();
			}
		}

		// Token: 0x06009959 RID: 39257 RVA: 0x001D82B0 File Offset: 0x001D66B0
		private void OnCommonNewDropDownItemButtonClick(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			this.UpdateDropDownList(false);
			this._commonNewControlData = comControlData;
			this.UpdateDropDownLabelName();
			if (this._onCommonNewDropDownItemButtonClick != null)
			{
				this._onCommonNewDropDownItemButtonClick(this._commonNewControlData);
			}
		}

		// Token: 0x0600995A RID: 39258 RVA: 0x001D82EC File Offset: 0x001D66EC
		public void UpdateCommonNewDropDownSelectedItem(ComControlData selectedControlData)
		{
			if (selectedControlData == null)
			{
				return;
			}
			this._commonNewControlData = selectedControlData;
			this.UpdateDropDownLabelName();
			if (this._commonNewDropDownListView != null)
			{
				this._commonNewDropDownListView.UpdateCommonNewDropDownDataList(this._commonNewControlData);
				this._commonNewDropDownListView.UpdateCommonNewDropDownItemList();
			}
		}

		// Token: 0x0600995B RID: 39259 RVA: 0x001D833C File Offset: 0x001D673C
		private void UpdateDropDownListPrefabPosition(GameObject dropDownListPrefab)
		{
			if (dropDownListPrefab == null)
			{
				return;
			}
			RectTransform rectTransform = dropDownListPrefab.transform as RectTransform;
			RectTransform rectTransform2 = this.dropDownListRoot.transform as RectTransform;
			if (rectTransform == null || rectTransform2 == null)
			{
				return;
			}
			if (this.dropDownListType == CommonNewDropDownListType.DownType)
			{
				dropDownListPrefab.transform.localPosition = new Vector3(dropDownListPrefab.transform.localPosition.x, dropDownListPrefab.transform.localPosition.y - (rectTransform.sizeDelta.y + rectTransform2.sizeDelta.y) / 2f, dropDownListPrefab.transform.localPosition.z);
			}
			else if (this.dropDownListType == CommonNewDropDownListType.UpType)
			{
				dropDownListPrefab.transform.localPosition = new Vector3(dropDownListPrefab.transform.localPosition.x, dropDownListPrefab.transform.localPosition.y + (rectTransform.sizeDelta.y + rectTransform2.sizeDelta.y) / 2f, dropDownListPrefab.transform.localPosition.z);
			}
		}

		// Token: 0x0600995C RID: 39260 RVA: 0x001D848B File Offset: 0x001D688B
		private void OnDropDownListCloseButton()
		{
			this.UpdateDropDownList(false);
		}

		// Token: 0x0600995D RID: 39261 RVA: 0x001D8494 File Offset: 0x001D6894
		private void UpdateDropDownLabelName()
		{
			if (this.dropDownLabelName != null)
			{
				this.dropDownLabelName.text = this._commonNewControlData.Name;
			}
		}

		// Token: 0x0600995E RID: 39262 RVA: 0x001D84BD File Offset: 0x001D68BD
		public void UpdateDropDownList(bool flag)
		{
			CommonUtility.UpdateButtonVisible(this.dropDownListCloseButton, flag);
			CommonUtility.UpdateGameObjectVisible(this.dropDownListRoot, flag);
			CommonUtility.UpdateImageVisible(this.selectedArrow, flag);
			CommonUtility.UpdateImageVisible(this.defaultArrow, !flag);
		}

		// Token: 0x04004EF2 RID: 20210
		private ComControlData _commonNewControlData;

		// Token: 0x04004EF3 RID: 20211
		private List<ComControlData> _commonNewDropDownDataList;

		// Token: 0x04004EF4 RID: 20212
		private OnCommonNewDropDownItemButtonClick _onCommonNewDropDownItemButtonClick;

		// Token: 0x04004EF5 RID: 20213
		private Action _onResetDropDownListAction;

		// Token: 0x04004EF6 RID: 20214
		private CommonNewDropDownListView _commonNewDropDownListView;

		// Token: 0x04004EF7 RID: 20215
		[Space(20f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text dropDownLabelName;

		// Token: 0x04004EF8 RID: 20216
		[SerializeField]
		private Button dropDownButton;

		// Token: 0x04004EF9 RID: 20217
		[SerializeField]
		private Image defaultArrow;

		// Token: 0x04004EFA RID: 20218
		[SerializeField]
		private Image selectedArrow;

		// Token: 0x04004EFB RID: 20219
		[Space(20f)]
		[Header("DropDownListType")]
		[Space(10f)]
		[SerializeField]
		private CommonNewDropDownListType dropDownListType = CommonNewDropDownListType.DownType;

		// Token: 0x04004EFC RID: 20220
		[Space(20f)]
		[Header("DropDownListRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject dropDownListRoot;

		// Token: 0x04004EFD RID: 20221
		[SerializeField]
		private string dropDownListPath;

		// Token: 0x04004EFE RID: 20222
		[Space(20f)]
		[Header("dropDownListClose")]
		[Space(10f)]
		[SerializeField]
		private Button dropDownListCloseButton;
	}
}
