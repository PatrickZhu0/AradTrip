using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001940 RID: 6464
	public class PackageHonorSystemEntryController : MonoBehaviour
	{
		// Token: 0x0600FB4C RID: 64332 RVA: 0x0044DBE8 File Offset: 0x0044BFE8
		private void OnDestroy()
		{
			this._packageHonorSystemEntryView = null;
		}

		// Token: 0x0600FB4D RID: 64333 RVA: 0x0044DBF1 File Offset: 0x0044BFF1
		private void OnEnable()
		{
			this.OnEnableController();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
		}

		// Token: 0x0600FB4E RID: 64334 RVA: 0x0044DC11 File Offset: 0x0044C011
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnPlayerLevelChangeMessage));
		}

		// Token: 0x0600FB4F RID: 64335 RVA: 0x0044DC2B File Offset: 0x0044C02B
		private void OnPlayerLevelChangeMessage(UIEvent uiEvent)
		{
			this.UpdateController();
		}

		// Token: 0x0600FB50 RID: 64336 RVA: 0x0044DC33 File Offset: 0x0044C033
		private void OnEnableController()
		{
			this.UpdateController();
		}

		// Token: 0x0600FB51 RID: 64337 RVA: 0x0044DC3C File Offset: 0x0044C03C
		private void UpdateController()
		{
			if (this._packageHonorSystemEntryView != null)
			{
				return;
			}
			if (!HonorSystemUtility.IsShowHonorSystem())
			{
				return;
			}
			GameObject gameObject = CommonUtility.LoadGameObject(this.packageHonorSystemEntryRoot);
			if (gameObject != null)
			{
				this._packageHonorSystemEntryView = gameObject.GetComponent<PackageHonorSystemEntryView>();
			}
		}

		// Token: 0x04009D06 RID: 40198
		[SerializeField]
		private GameObject packageHonorSystemEntryRoot;

		// Token: 0x04009D07 RID: 40199
		private PackageHonorSystemEntryView _packageHonorSystemEntryView;
	}
}
