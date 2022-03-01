using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001707 RID: 5895
	internal class StorageFrame : ClientFrame
	{
		// Token: 0x17001CB9 RID: 7353
		// (get) Token: 0x0600E79A RID: 59290 RVA: 0x003D13D7 File Offset: 0x003CF7D7
		// (set) Token: 0x0600E79B RID: 59291 RVA: 0x003D13DF File Offset: 0x003CF7DF
		public StorageType CurrentStorageType
		{
			get
			{
				return this._currentStorageType;
			}
			set
			{
				this._currentStorageType = value;
				DataManager<StorageDataManager>.GetInstance().CurrentStorageType = this._currentStorageType;
			}
		}

		// Token: 0x0600E79C RID: 59292 RVA: 0x003D13F8 File Offset: 0x003CF7F8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/Storage";
		}

		// Token: 0x0600E79D RID: 59293 RVA: 0x003D13FF File Offset: 0x003CF7FF
		protected override void _OnOpenFrame()
		{
			this.CurrentStorageType = StorageType.RoleStorage;
			this.InitStorageView();
		}

		// Token: 0x0600E79E RID: 59294 RVA: 0x003D140E File Offset: 0x003CF80E
		protected override void _OnCloseFrame()
		{
			this._roleStorageController = null;
			this._accountStorageController = null;
		}

		// Token: 0x0600E79F RID: 59295 RVA: 0x003D1420 File Offset: 0x003CF820
		protected override void _bindExUI()
		{
			this.roleStorageToggle = this.mBind.GetCom<Toggle>("roleStorageToggle");
			if (this.roleStorageToggle != null)
			{
				this.roleStorageToggle.onValueChanged.RemoveAllListeners();
				this.roleStorageToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnRoleStorageToggleClick));
			}
			this.accountStorageToggle = this.mBind.GetCom<Toggle>("accountStorageToggle");
			if (this.accountStorageToggle != null)
			{
				this.accountStorageToggle.onValueChanged.RemoveAllListeners();
				this.accountStorageToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnAccountStorageToggleClick));
			}
			this.roleStorageViewRoot = this.mBind.GetGameObject("roleStorageRoot");
			this.accountStorageViewRoot = this.mBind.GetGameObject("accountStorageRoot");
		}

		// Token: 0x0600E7A0 RID: 59296 RVA: 0x003D1500 File Offset: 0x003CF900
		protected override void _unbindExUI()
		{
			if (this.roleStorageToggle != null)
			{
				this.roleStorageToggle.onValueChanged.RemoveAllListeners();
				this.roleStorageToggle = null;
			}
			if (this.accountStorageToggle != null)
			{
				this.accountStorageToggle.onValueChanged.RemoveAllListeners();
				this.accountStorageToggle = null;
			}
			this.accountStorageViewRoot = null;
			this.roleStorageViewRoot = null;
		}

		// Token: 0x0600E7A1 RID: 59297 RVA: 0x003D156B File Offset: 0x003CF96B
		private void InitStorageView()
		{
			this.InitStorageToggle();
			this.OnUpdateStorageView();
		}

		// Token: 0x0600E7A2 RID: 59298 RVA: 0x003D157C File Offset: 0x003CF97C
		private void InitStorageToggle()
		{
			if (this.CurrentStorageType == StorageType.RoleStorage)
			{
				if (this.roleStorageToggle != null)
				{
					this.roleStorageToggle.isOn = false;
					this.roleStorageToggle.isOn = true;
				}
			}
			else if (this.accountStorageToggle != null)
			{
				this.accountStorageToggle.isOn = false;
				this.accountStorageToggle.isOn = true;
			}
		}

		// Token: 0x0600E7A3 RID: 59299 RVA: 0x003D15EC File Offset: 0x003CF9EC
		private void OnUpdateStorageView()
		{
			if (this.CurrentStorageType == StorageType.AccountStorage)
			{
				CommonUtility.UpdateGameObjectVisible(this.roleStorageViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.accountStorageViewRoot, true);
				if (this._accountStorageController == null)
				{
					if (this.accountStorageViewRoot != null)
					{
						GameObject gameObject = CommonUtility.LoadGameObject(this.accountStorageViewRoot);
						if (gameObject != null)
						{
							this._accountStorageController = gameObject.GetComponent<AccountStorageController>();
						}
						if (this._accountStorageController != null)
						{
							this._accountStorageController.InitView(this.CurrentStorageType);
						}
					}
				}
				else
				{
					this._accountStorageController.OnEnableView();
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.roleStorageViewRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.accountStorageViewRoot, false);
				if (this._roleStorageController == null)
				{
					if (this.roleStorageViewRoot != null)
					{
						GameObject gameObject2 = CommonUtility.LoadGameObject(this.roleStorageViewRoot);
						if (gameObject2 != null)
						{
							this._roleStorageController = gameObject2.GetComponent<RoleStorageController>();
						}
						if (this._roleStorageController != null)
						{
							this._roleStorageController.InitView(this.CurrentStorageType);
						}
					}
				}
				else
				{
					this._roleStorageController.OnEnableView();
				}
			}
		}

		// Token: 0x0600E7A4 RID: 59300 RVA: 0x003D172A File Offset: 0x003CFB2A
		private void OnRoleStorageToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this.CurrentStorageType == StorageType.RoleStorage)
			{
				return;
			}
			this.CurrentStorageType = StorageType.RoleStorage;
			this.OnUpdateStorageView();
		}

		// Token: 0x0600E7A5 RID: 59301 RVA: 0x003D174C File Offset: 0x003CFB4C
		private void OnAccountStorageToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this.CurrentStorageType == StorageType.AccountStorage)
			{
				return;
			}
			this.CurrentStorageType = StorageType.AccountStorage;
			this.OnUpdateStorageView();
		}

		// Token: 0x04008C78 RID: 35960
		private RoleStorageController _roleStorageController;

		// Token: 0x04008C79 RID: 35961
		private AccountStorageController _accountStorageController;

		// Token: 0x04008C7A RID: 35962
		private StorageType _currentStorageType;

		// Token: 0x04008C7B RID: 35963
		private Toggle roleStorageToggle;

		// Token: 0x04008C7C RID: 35964
		private Toggle accountStorageToggle;

		// Token: 0x04008C7D RID: 35965
		private GameObject roleStorageViewRoot;

		// Token: 0x04008C7E RID: 35966
		private GameObject accountStorageViewRoot;
	}
}
