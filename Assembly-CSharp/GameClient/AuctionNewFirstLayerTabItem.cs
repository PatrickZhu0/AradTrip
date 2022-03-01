using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001479 RID: 5241
	public class AuctionNewFirstLayerTabItem : MonoBehaviour
	{
		// Token: 0x0600CB47 RID: 52039 RVA: 0x0031CC2E File Offset: 0x0031B02E
		private void Awake()
		{
			if (this.tabToggle != null)
			{
				this.tabToggle.onValueChanged.RemoveAllListeners();
				this.tabToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600CB48 RID: 52040 RVA: 0x0031CC6D File Offset: 0x0031B06D
		private void OnDestroy()
		{
			if (this.tabToggle != null)
			{
				this.tabToggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600CB49 RID: 52041 RVA: 0x0031CC98 File Offset: 0x0031B098
		private void ResetData()
		{
			this._isSelected = false;
			this._isOwnerChildren = false;
			this._isInitChildrenLayer = false;
			this._firstLayerMenuTabDataModel = null;
			this._onFirstLayerTabToggleClick = null;
			this._onSecondLayerTabToggleClick = null;
			this._secondLayerTabItemList.Clear();
			this._defaultSecondLayerTabId = 0;
			this._secondLayerTabDataModelList = null;
		}

		// Token: 0x0600CB4A RID: 52042 RVA: 0x0031CCE8 File Offset: 0x0031B0E8
		public void InitTabItem(AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, List<AuctionNewMenuTabDataModel> secondLayerTabDataModelList, bool isSelected = false, int defaultSecondLayerTabId = 0, OnFirstLayerTabToggleClick onFirstLayerTabToggleClick = null, OnSecondLayerTabToggleClick onSecondLayerTabToggleClick = null)
		{
			this.ResetData();
			this._firstLayerMenuTabDataModel = firstLayerMenuTabDataModel;
			this._secondLayerTabDataModelList = secondLayerTabDataModelList;
			this._defaultSecondLayerTabId = defaultSecondLayerTabId;
			this._onFirstLayerTabToggleClick = onFirstLayerTabToggleClick;
			this._onSecondLayerTabToggleClick = onSecondLayerTabToggleClick;
			if (this._firstLayerMenuTabDataModel == null)
			{
				return;
			}
			if (this._firstLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				return;
			}
			this._isOwnerChildren = false;
			if (this._secondLayerTabDataModelList != null && this._secondLayerTabDataModelList.Count > 0)
			{
				this._isOwnerChildren = true;
			}
			if (this.tabName != null)
			{
				this.tabName.text = this._firstLayerMenuTabDataModel.AuctionNewFrameTable.Name;
			}
			if (this.selectedTabName != null)
			{
				this.selectedTabName.text = this._firstLayerMenuTabDataModel.AuctionNewFrameTable.Name;
			}
			this.InitArrowUp();
			if (isSelected && this.tabToggle != null)
			{
				this.tabToggle.isOn = true;
			}
		}

		// Token: 0x0600CB4B RID: 52043 RVA: 0x0031CDEC File Offset: 0x0031B1EC
		private void OnTabClicked(bool value)
		{
			if (this._firstLayerMenuTabDataModel == null)
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
				if (this._onFirstLayerTabToggleClick != null)
				{
					this._onFirstLayerTabToggleClick(this._firstLayerMenuTabDataModel);
				}
				if (this._isOwnerChildren)
				{
					this.SetArrowUp(false);
					this.SetArrowDown(true);
					if (this.secondMenuRoot != null && !this.secondMenuRoot.activeSelf)
					{
						this.secondMenuRoot.CustomActive(true);
					}
					if (!this._isInitChildrenLayer)
					{
						this.InitChildrenLayer();
						this._isInitChildrenLayer = true;
					}
					else if (this._secondLayerTabItemList != null && this._secondLayerTabItemList.Count > 0)
					{
						for (int i = 0; i < this._secondLayerTabItemList.Count; i++)
						{
							AuctionNewSecondLayerTabItem auctionNewSecondLayerTabItem = this._secondLayerTabItemList[i];
							if (auctionNewSecondLayerTabItem != null)
							{
								auctionNewSecondLayerTabItem.OnEnabelTabItem();
							}
						}
					}
				}
			}
			else if (this._isOwnerChildren)
			{
				this.SetArrowUp(true);
				this.SetArrowDown(false);
				if (this.secondMenuRoot != null)
				{
					this.secondMenuRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x0600CB4C RID: 52044 RVA: 0x0031CF30 File Offset: 0x0031B330
		private void InitArrowUp()
		{
			if (this.arrowRoot != null)
			{
				if (!this._isOwnerChildren)
				{
					this.arrowRoot.CustomActive(false);
				}
				else
				{
					this.arrowRoot.CustomActive(true);
				}
			}
			if (this._isOwnerChildren)
			{
				this.SetArrowUp(true);
				this.SetArrowDown(false);
			}
		}

		// Token: 0x0600CB4D RID: 52045 RVA: 0x0031CF8F File Offset: 0x0031B38F
		private void SetArrowUp(bool flag)
		{
			if (this.arrowUp != null)
			{
				this.arrowUp.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CB4E RID: 52046 RVA: 0x0031CFB3 File Offset: 0x0031B3B3
		private void SetArrowDown(bool flag)
		{
			if (this.arrowDown != null)
			{
				this.arrowDown.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CB4F RID: 52047 RVA: 0x0031CFD8 File Offset: 0x0031B3D8
		private void InitChildrenLayer()
		{
			this._secondLayerTabItemList.Clear();
			if (this._secondLayerTabDataModelList == null || this._secondLayerTabDataModelList.Count <= 0)
			{
				Logger.LogErrorFormat("SecondLayerTabDataModelList is null and Init is Error", new object[0]);
				return;
			}
			if (this.secondMenuRoot == null || this.secondLayerTabItemGo == null)
			{
				Logger.LogErrorFormat("SecondMenuRoot is null or secondLayerTabItem is null", new object[0]);
				return;
			}
			int secondDefaultIndex = this.GetSecondDefaultIndex(this._secondLayerTabDataModelList);
			for (int i = 0; i < this._secondLayerTabDataModelList.Count; i++)
			{
				AuctionNewMenuTabDataModel auctionNewMenuTabDataModel = this._secondLayerTabDataModelList[i];
				if (auctionNewMenuTabDataModel != null)
				{
					bool isSelected = i == secondDefaultIndex;
					GameObject gameObject = Object.Instantiate<GameObject>(this.secondLayerTabItemGo);
					if (gameObject != null)
					{
						gameObject.CustomActive(true);
						Utility.AttachTo(gameObject, this.secondMenuRoot, false);
						AuctionNewSecondLayerTabItem component = gameObject.GetComponent<AuctionNewSecondLayerTabItem>();
						if (component != null)
						{
							component.InitTabItem(this._firstLayerMenuTabDataModel, auctionNewMenuTabDataModel, isSelected, this._onSecondLayerTabToggleClick);
							this._secondLayerTabItemList.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x0600CB50 RID: 52048 RVA: 0x0031D100 File Offset: 0x0031B500
		private int GetSecondDefaultIndex(List<AuctionNewMenuTabDataModel> childrenTabDataModelList)
		{
			if (this._defaultSecondLayerTabId > 0)
			{
				for (int i = 0; i < childrenTabDataModelList.Count; i++)
				{
					AuctionNewMenuTabDataModel auctionNewMenuTabDataModel = childrenTabDataModelList[i];
					if (auctionNewMenuTabDataModel != null && auctionNewMenuTabDataModel.AuctionNewFrameTable != null)
					{
						if (auctionNewMenuTabDataModel.Id == this._defaultSecondLayerTabId)
						{
							this._defaultSecondLayerTabId = 0;
							return i;
						}
					}
				}
			}
			this._defaultSecondLayerTabId = 0;
			int result = 0;
			if (this._firstLayerMenuTabDataModel.AuctionNewFrameTable.ChooseLogic == 2)
			{
				int baseJobID = Utility.GetBaseJobID(DataManager<PlayerBaseData>.GetInstance().JobTableID);
				for (int j = 0; j < childrenTabDataModelList.Count; j++)
				{
					AuctionNewMenuTabDataModel auctionNewMenuTabDataModel2 = childrenTabDataModelList[j];
					if (auctionNewMenuTabDataModel2 != null && auctionNewMenuTabDataModel2.AuctionNewFrameTable != null)
					{
						if (auctionNewMenuTabDataModel2.AuctionNewFrameTable.JobBaseId == baseJobID)
						{
							result = j;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04007610 RID: 30224
		private bool _isSelected;

		// Token: 0x04007611 RID: 30225
		private AuctionNewMenuTabDataModel _firstLayerMenuTabDataModel;

		// Token: 0x04007612 RID: 30226
		private bool _isOwnerChildren;

		// Token: 0x04007613 RID: 30227
		private bool _isInitChildrenLayer;

		// Token: 0x04007614 RID: 30228
		private OnFirstLayerTabToggleClick _onFirstLayerTabToggleClick;

		// Token: 0x04007615 RID: 30229
		private OnSecondLayerTabToggleClick _onSecondLayerTabToggleClick;

		// Token: 0x04007616 RID: 30230
		private int _defaultSecondLayerTabId;

		// Token: 0x04007617 RID: 30231
		private List<AuctionNewMenuTabDataModel> _secondLayerTabDataModelList;

		// Token: 0x04007618 RID: 30232
		private List<AuctionNewSecondLayerTabItem> _secondLayerTabItemList = new List<AuctionNewSecondLayerTabItem>();

		// Token: 0x04007619 RID: 30233
		[Space(10f)]
		[Header("FirstLayerTab")]
		[Space(5f)]
		[SerializeField]
		private Text tabName;

		// Token: 0x0400761A RID: 30234
		[SerializeField]
		private Text selectedTabName;

		// Token: 0x0400761B RID: 30235
		[SerializeField]
		private Toggle tabToggle;

		// Token: 0x0400761C RID: 30236
		[SerializeField]
		private GameObject arrowRoot;

		// Token: 0x0400761D RID: 30237
		[SerializeField]
		private Image arrowUp;

		// Token: 0x0400761E RID: 30238
		[SerializeField]
		private Image arrowDown;

		// Token: 0x0400761F RID: 30239
		[Space(10f)]
		[Header("SecondLayerInfo")]
		[Space(5f)]
		[SerializeField]
		private GameObject secondMenuRoot;

		// Token: 0x04007620 RID: 30240
		[SerializeField]
		private GameObject secondLayerTabItemGo;
	}
}
