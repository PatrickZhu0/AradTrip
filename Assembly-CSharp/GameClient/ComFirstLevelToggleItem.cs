using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F99 RID: 3993
	public class ComFirstLevelToggleItem : MonoBehaviour
	{
		// Token: 0x06009A56 RID: 39510 RVA: 0x001DCFBE File Offset: 0x001DB3BE
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleClick));
			}
		}

		// Token: 0x06009A57 RID: 39511 RVA: 0x001DCFFD File Offset: 0x001DB3FD
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x06009A58 RID: 39512 RVA: 0x001DD026 File Offset: 0x001DB426
		private void ResetData()
		{
			this._comFirstLevelToggleData = null;
			this._isOwnerSecondLevel = false;
			this._isInitSecondLevel = false;
			this._onFirstLevelToggleClick = null;
			this._onSecondLevelToggleClick = null;
			this._isSelected = false;
			this._secondLevelToggleItemList.Clear();
		}

		// Token: 0x06009A59 RID: 39513 RVA: 0x001DD060 File Offset: 0x001DB460
		public void InitItem(ComFirstLevelToggleData comFirstLevelToggleData, OnComToggleClick onFirstLevelToggleClick = null, OnComToggleClick onSecondLevelToggleClick = null)
		{
			this.ResetData();
			this._comFirstLevelToggleData = comFirstLevelToggleData;
			this._onFirstLevelToggleClick = onFirstLevelToggleClick;
			this._onSecondLevelToggleClick = onSecondLevelToggleClick;
			if (this._comFirstLevelToggleData == null || this._comFirstLevelToggleData.FirstLevelToggleData == null)
			{
				Logger.LogErrorFormat("ComFirstLevelToggleItem InitItem comFirstLevelToggleData is null", new object[0]);
				return;
			}
			this._isOwnerSecondLevel = true;
			if (this._comFirstLevelToggleData.SecondLevelToggleDataList == null || this._comFirstLevelToggleData.SecondLevelToggleDataList.Count <= 0)
			{
				this._isOwnerSecondLevel = false;
			}
			this.InitItemView();
		}

		// Token: 0x06009A5A RID: 39514 RVA: 0x001DD0F0 File Offset: 0x001DB4F0
		private void InitItemView()
		{
			if (this.normalName != null)
			{
				this.normalName.text = this._comFirstLevelToggleData.FirstLevelToggleData.Name;
			}
			if (this.selectedTabName != null)
			{
				this.selectedTabName.text = this._comFirstLevelToggleData.FirstLevelToggleData.Name;
			}
			this.InitArrowUp();
			if (this._comFirstLevelToggleData.FirstLevelToggleData.IsSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x06009A5B RID: 39515 RVA: 0x001DD190 File Offset: 0x001DB590
		private void OnToggleClick(bool value)
		{
			if (this._comFirstLevelToggleData == null || this._comFirstLevelToggleData.FirstLevelToggleData == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value)
			{
				if (this._onFirstLevelToggleClick != null)
				{
					this._onFirstLevelToggleClick(this._comFirstLevelToggleData.FirstLevelToggleData);
				}
				if (this._isOwnerSecondLevel)
				{
					this.SetArrowUp(false);
					this.SetArrowDown(true);
					if (this.secondLevelToggleRoot != null && !this.secondLevelToggleRoot.activeSelf)
					{
						this.secondLevelToggleRoot.CustomActive(true);
					}
					if (!this._isInitSecondLevel)
					{
						this.InitSecondLevel();
						this._isInitSecondLevel = true;
					}
					else if (this._secondLevelToggleItemList != null && this._secondLevelToggleItemList.Count > 0)
					{
						for (int i = 0; i < this._secondLevelToggleItemList.Count; i++)
						{
							ComToggleItem comToggleItem = this._secondLevelToggleItemList[i];
							if (comToggleItem != null)
							{
								comToggleItem.OnEnableComToggleItem();
							}
						}
					}
				}
			}
			else if (this._isOwnerSecondLevel)
			{
				this.SetArrowUp(true);
				this.SetArrowDown(false);
				if (this.secondLevelToggleRoot != null)
				{
					this.secondLevelToggleRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x06009A5C RID: 39516 RVA: 0x001DD2EC File Offset: 0x001DB6EC
		private void InitSecondLevel()
		{
			this._secondLevelToggleItemList.Clear();
			if (this._comFirstLevelToggleData.SecondLevelToggleDataList == null || this._comFirstLevelToggleData.SecondLevelToggleDataList.Count <= 0)
			{
				Logger.LogErrorFormat("ComFirstLevelToggleItem InitSecondLevel secondLevelToggleDataList is null", new object[0]);
				return;
			}
			if (this.secondLevelToggleRoot == null || this.secondLevelToggleItemPrefab == null)
			{
				Logger.LogErrorFormat("ComFirstLevelToggleItem InitSecondLevel secondLevelToggleRoot is null or secondLevelToggleItem is null", new object[0]);
				return;
			}
			for (int i = 0; i < this._comFirstLevelToggleData.SecondLevelToggleDataList.Count; i++)
			{
				ComControlData comControlData = this._comFirstLevelToggleData.SecondLevelToggleDataList[i];
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
						ComToggleItem component = gameObject.GetComponent<ComToggleItem>();
						if (component != null)
						{
							component.InitItem(comControlData, this._onSecondLevelToggleClick);
							this._secondLevelToggleItemList.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x06009A5D RID: 39517 RVA: 0x001DD420 File Offset: 0x001DB820
		private void InitArrowUp()
		{
			if (this.arrowRoot != null)
			{
				if (!this._isOwnerSecondLevel)
				{
					this.arrowRoot.CustomActive(false);
				}
				else
				{
					this.arrowRoot.CustomActive(true);
				}
			}
			if (this._isOwnerSecondLevel)
			{
				this.SetArrowUp(true);
				this.SetArrowDown(false);
			}
		}

		// Token: 0x06009A5E RID: 39518 RVA: 0x001DD47F File Offset: 0x001DB87F
		private void SetArrowUp(bool flag)
		{
			if (this.arrowUp != null)
			{
				this.arrowUp.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06009A5F RID: 39519 RVA: 0x001DD4A3 File Offset: 0x001DB8A3
		private void SetArrowDown(bool flag)
		{
			if (this.arrowDown != null)
			{
				this.arrowDown.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x04004FDE RID: 20446
		private ComFirstLevelToggleData _comFirstLevelToggleData;

		// Token: 0x04004FDF RID: 20447
		private bool _isOwnerSecondLevel;

		// Token: 0x04004FE0 RID: 20448
		private bool _isInitSecondLevel;

		// Token: 0x04004FE1 RID: 20449
		private OnComToggleClick _onFirstLevelToggleClick;

		// Token: 0x04004FE2 RID: 20450
		private OnComToggleClick _onSecondLevelToggleClick;

		// Token: 0x04004FE3 RID: 20451
		private bool _isSelected;

		// Token: 0x04004FE4 RID: 20452
		private List<ComToggleItem> _secondLevelToggleItemList = new List<ComToggleItem>();

		// Token: 0x04004FE5 RID: 20453
		[Space(10f)]
		[Header("FirstLevelToggle")]
		[Space(5f)]
		[SerializeField]
		private Text normalName;

		// Token: 0x04004FE6 RID: 20454
		[SerializeField]
		private Text selectedTabName;

		// Token: 0x04004FE7 RID: 20455
		[SerializeField]
		private Toggle toggle;

		// Token: 0x04004FE8 RID: 20456
		[Space(10f)]
		[Header("Arrow")]
		[Space(5f)]
		[SerializeField]
		private GameObject arrowRoot;

		// Token: 0x04004FE9 RID: 20457
		[SerializeField]
		private Image arrowUp;

		// Token: 0x04004FEA RID: 20458
		[SerializeField]
		private Image arrowDown;

		// Token: 0x04004FEB RID: 20459
		[Space(10f)]
		[Header("SecondLevelToggle")]
		[Space(5f)]
		[SerializeField]
		private GameObject secondLevelToggleRoot;

		// Token: 0x04004FEC RID: 20460
		[SerializeField]
		private GameObject secondLevelToggleItemPrefab;
	}
}
