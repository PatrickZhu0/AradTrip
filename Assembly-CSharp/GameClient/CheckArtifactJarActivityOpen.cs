using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200143F RID: 5183
	[RequireComponent(typeof(RectTransform))]
	public class CheckArtifactJarActivityOpen : MonoBehaviour
	{
		// Token: 0x0600C924 RID: 51492 RVA: 0x0030EBCC File Offset: 0x0030CFCC
		private void Start()
		{
			this.goShow = base.transform.gameObject;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600C925 RID: 51493 RVA: 0x0030EC01 File Offset: 0x0030D001
		private void OnDestroy()
		{
			this.goShow = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
		}

		// Token: 0x0600C926 RID: 51494 RVA: 0x0030EC25 File Offset: 0x0030D025
		private void Update()
		{
		}

		// Token: 0x0600C927 RID: 51495 RVA: 0x0030EC27 File Offset: 0x0030D027
		private bool IsActivityOpen()
		{
			return ArtifactFrame.IsArtifactJarDiscountActivityOpen() || ArtifactFrame.IsArtifactJarShowActivityOpen() || ArtifactFrame.IsArtifactJarRewardActivityOpen();
		}

		// Token: 0x0600C928 RID: 51496 RVA: 0x0030EC45 File Offset: 0x0030D045
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			this.goShow.CustomActive(this.IsActivityOpen());
		}

		// Token: 0x04007417 RID: 29719
		private GameObject goShow;
	}
}
