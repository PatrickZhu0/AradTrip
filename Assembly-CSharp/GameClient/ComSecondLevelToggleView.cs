using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F9A RID: 3994
	public class ComSecondLevelToggleView : MonoBehaviour
	{
		// Token: 0x06009A61 RID: 39521 RVA: 0x001DD4DA File Offset: 0x001DB8DA
		private void Awake()
		{
		}

		// Token: 0x06009A62 RID: 39522 RVA: 0x001DD4DC File Offset: 0x001DB8DC
		private void OnDestroy()
		{
			this.ResetData();
		}

		// Token: 0x06009A63 RID: 39523 RVA: 0x001DD4E4 File Offset: 0x001DB8E4
		private void ResetData()
		{
			this._comSecondLevelToggleDataModelList = null;
			this._comSecondLevelToggleItemList.Clear();
			this._isInitSecondLevelToggleView = false;
			this._onSecondLevelToggleClick = null;
		}

		// Token: 0x06009A64 RID: 39524 RVA: 0x001DD506 File Offset: 0x001DB906
		public void InitSecondLevelToggleViewData(ComTwoLevelToggleData comTwoLevelToggleData, OnComToggleClick onSecondLevelToggleClick = null)
		{
			this.ResetData();
			if (comTwoLevelToggleData == null)
			{
				return;
			}
			this._comSecondLevelToggleDataModelList = comTwoLevelToggleData.SecondLevelToggleDataList;
			this._onSecondLevelToggleClick = onSecondLevelToggleClick;
		}

		// Token: 0x06009A65 RID: 39525 RVA: 0x001DD528 File Offset: 0x001DB928
		public void ShowSecondLevelToggleView()
		{
			if (this._comSecondLevelToggleDataModelList == null || this._comSecondLevelToggleDataModelList.Count <= 0)
			{
				return;
			}
			if (!this._isInitSecondLevelToggleView)
			{
				this.InitSecondLevelToggleView();
				this._isInitSecondLevelToggleView = true;
			}
			else
			{
				this.EnableSecondLevelToggleView();
			}
		}

		// Token: 0x06009A66 RID: 39526 RVA: 0x001DD578 File Offset: 0x001DB978
		private void InitSecondLevelToggleView()
		{
			this._comSecondLevelToggleItemList.Clear();
			if (this._comSecondLevelToggleDataModelList == null || this._comSecondLevelToggleDataModelList.Count <= 0)
			{
				return;
			}
			if (this.secondLevelToggleRoot == null || this.secondLevelToggleItemPrefab == null)
			{
				Logger.LogErrorFormat("ComFirstLevelToggleItem InitSecondLevel secondLevelToggleRoot is null or secondLevelToggleItem is null", new object[0]);
				return;
			}
			for (int i = 0; i < this._comSecondLevelToggleDataModelList.Count; i++)
			{
				ComControlData comControlData = this._comSecondLevelToggleDataModelList[i];
				if (comControlData == null)
				{
					Logger.LogErrorFormat("InitSecondLevel index is {0}, secondLevelToggleData is null", new object[]
					{
						i
					});
				}
				else
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.secondLevelToggleItemPrefab);
					if (gameObject != null)
					{
						gameObject.CustomActive(true);
						Utility.AttachTo(gameObject, this.secondLevelToggleRoot, false);
						gameObject.transform.name = gameObject.transform.name + "_" + (i + 1);
						ComToggleItem component = gameObject.GetComponent<ComToggleItem>();
						if (component != null)
						{
							component.InitItem(comControlData, this._onSecondLevelToggleClick);
							this._comSecondLevelToggleItemList.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x06009A67 RID: 39527 RVA: 0x001DD6B0 File Offset: 0x001DBAB0
		private void EnableSecondLevelToggleView()
		{
			if (this._comSecondLevelToggleItemList != null && this._comSecondLevelToggleItemList.Count > 0)
			{
				for (int i = 0; i < this._comSecondLevelToggleItemList.Count; i++)
				{
					ComToggleItem comToggleItem = this._comSecondLevelToggleItemList[i];
					if (comToggleItem != null)
					{
						comToggleItem.OnEnableComToggleItem();
					}
				}
			}
		}

		// Token: 0x04004FED RID: 20461
		private List<ComControlData> _comSecondLevelToggleDataModelList;

		// Token: 0x04004FEE RID: 20462
		private List<ComToggleItem> _comSecondLevelToggleItemList = new List<ComToggleItem>();

		// Token: 0x04004FEF RID: 20463
		private bool _isInitSecondLevelToggleView;

		// Token: 0x04004FF0 RID: 20464
		private OnComToggleClick _onSecondLevelToggleClick;

		// Token: 0x04004FF1 RID: 20465
		[Space(10f)]
		[Header("SecondLevelToggle")]
		[Space(5f)]
		[SerializeField]
		private GameObject secondLevelToggleRoot;

		// Token: 0x04004FF2 RID: 20466
		[SerializeField]
		private GameObject secondLevelToggleItemPrefab;
	}
}
