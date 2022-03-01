using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200193F RID: 6463
	public class PackageExtraController : MonoBehaviour
	{
		// Token: 0x0600FB44 RID: 64324 RVA: 0x0044DAD7 File Offset: 0x0044BED7
		private void Awake()
		{
		}

		// Token: 0x0600FB45 RID: 64325 RVA: 0x0044DAD9 File Offset: 0x0044BED9
		private void OnDestroy()
		{
			this._packageEquipPlanSwitchView = null;
		}

		// Token: 0x0600FB46 RID: 64326 RVA: 0x0044DAE2 File Offset: 0x0044BEE2
		private void OnEnable()
		{
			this.OnEnableEquipPlanController();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
		}

		// Token: 0x0600FB47 RID: 64327 RVA: 0x0044DB02 File Offset: 0x0044BF02
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
		}

		// Token: 0x0600FB48 RID: 64328 RVA: 0x0044DB1C File Offset: 0x0044BF1C
		private void OnPlayerLevelChangeMessage(UIEvent uiEvent)
		{
			this.UpdateEquipPlanController();
		}

		// Token: 0x0600FB49 RID: 64329 RVA: 0x0044DB24 File Offset: 0x0044BF24
		private void OnEnableEquipPlanController()
		{
			this.UpdateEquipPlanController();
		}

		// Token: 0x0600FB4A RID: 64330 RVA: 0x0044DB2C File Offset: 0x0044BF2C
		private void UpdateEquipPlanController()
		{
			if (!EquipPlanUtility.IsEquipPlanOpenedByServer())
			{
				CommonUtility.UpdateGameObjectVisible(this.packageEquipPlanRoot, false);
				return;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.packageEquipPlanRoot, false);
				return;
			}
			if (!EquipPlanUtility.IsShowEquipPlanFunction())
			{
				CommonUtility.UpdateGameObjectVisible(this.packageEquipPlanRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.packageEquipPlanRoot, true);
				if (this._packageEquipPlanSwitchView == null && this.packageEquipPlanRoot != null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.packageEquipPlanRoot);
					if (gameObject != null)
					{
						this._packageEquipPlanSwitchView = gameObject.GetComponent<PackageEquipPlanSwitchView>();
					}
				}
			}
		}

		// Token: 0x04009D04 RID: 40196
		[SerializeField]
		private GameObject packageEquipPlanRoot;

		// Token: 0x04009D05 RID: 40197
		private PackageEquipPlanSwitchView _packageEquipPlanSwitchView;
	}
}
