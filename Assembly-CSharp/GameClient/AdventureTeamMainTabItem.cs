using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001406 RID: 5126
	public class AdventureTeamMainTabItem : MonoBehaviour
	{
		// Token: 0x0600C678 RID: 50808 RVA: 0x002FE64B File Offset: 0x002FCA4B
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600C679 RID: 50809 RVA: 0x002FE68A File Offset: 0x002FCA8A
		private void ResetData()
		{
			this._isSelected = false;
			this._mainTabDataModel = null;
			this._mainTabContentView = null;
		}

		// Token: 0x0600C67A RID: 50810 RVA: 0x002FE6A1 File Offset: 0x002FCAA1
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600C67B RID: 50811 RVA: 0x002FE6CC File Offset: 0x002FCACC
		private void OnTabClicked(bool value)
		{
			if (this._mainTabDataModel == null)
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
				if (this._mainTabDataModel.contentRoot != null)
				{
					this._mainTabDataModel.contentRoot.CustomActive(true);
					if (this._mainTabContentView == null)
					{
						this.LoadContentView();
					}
					else
					{
						AdventureTeamContentBaseView component = this._mainTabContentView.GetComponent<AdventureTeamContentBaseView>();
						if (component != null)
						{
							component.OnEnableView();
						}
					}
				}
			}
			else if (this._mainTabDataModel.contentRoot != null)
			{
				this._mainTabDataModel.contentRoot.CustomActive(false);
				if (this._mainTabContentView != null)
				{
					AdventureTeamContentBaseView component2 = this._mainTabContentView.GetComponent<AdventureTeamContentBaseView>();
					if (component2 != null)
					{
						component2.OnDisableView();
					}
				}
			}
		}

		// Token: 0x0600C67C RID: 50812 RVA: 0x002FE7BC File Offset: 0x002FCBBC
		private void LoadContentView()
		{
			UIPrefabWrapper component = this._mainTabDataModel.contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					Utility.AttachTo(gameObject, this._mainTabDataModel.contentRoot, false);
					this._mainTabContentView = gameObject;
				}
			}
			if (this._mainTabContentView != null)
			{
				AdventureTeamContentBaseView component2 = this._mainTabContentView.GetComponent<AdventureTeamContentBaseView>();
				if (component2 != null)
				{
					component2.InitData();
				}
			}
		}

		// Token: 0x0600C67D RID: 50813 RVA: 0x002FE844 File Offset: 0x002FCC44
		public void Init(AdventureTeamMainTabDataModel mainTabDataModel, bool isSelected = false)
		{
			this.ResetData();
			this._mainTabDataModel = mainTabDataModel;
			if (this._mainTabDataModel == null)
			{
				return;
			}
			if (this.mainTabName != null)
			{
				this.mainTabName.text = this._mainTabDataModel.mainTabName;
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600C67E RID: 50814 RVA: 0x002FE8B4 File Offset: 0x002FCCB4
		public void SetRedPointEnable(bool bEnable)
		{
			this.redPoint.CustomActive(bEnable);
		}

		// Token: 0x0600C67F RID: 50815 RVA: 0x002FE8C2 File Offset: 0x002FCCC2
		public AdventureTeamMainTabType GetTabType()
		{
			if (this._mainTabDataModel != null)
			{
				return this._mainTabDataModel.mainTabType;
			}
			return AdventureTeamMainTabType.None;
		}

		// Token: 0x0600C680 RID: 50816 RVA: 0x002FE8DC File Offset: 0x002FCCDC
		public bool IsTabSelected()
		{
			return this._isSelected;
		}

		// Token: 0x0600C681 RID: 50817 RVA: 0x002FE8E4 File Offset: 0x002FCCE4
		public void SetTabSelect()
		{
			if (this.toggle && !this.toggle.isOn)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x040071DF RID: 29151
		private bool _isSelected;

		// Token: 0x040071E0 RID: 29152
		private AdventureTeamMainTabDataModel _mainTabDataModel;

		// Token: 0x040071E1 RID: 29153
		private GameObject _mainTabContentView;

		// Token: 0x040071E2 RID: 29154
		[SerializeField]
		private Text mainTabName;

		// Token: 0x040071E3 RID: 29155
		[SerializeField]
		private Toggle toggle;

		// Token: 0x040071E4 RID: 29156
		[SerializeField]
		private GameObject redPoint;
	}
}
