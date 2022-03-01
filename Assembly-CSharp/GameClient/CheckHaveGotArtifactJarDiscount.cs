using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001440 RID: 5184
	[RequireComponent(typeof(RectTransform))]
	public class CheckHaveGotArtifactJarDiscount : MonoBehaviour
	{
		// Token: 0x0600C92A RID: 51498 RVA: 0x0030EC60 File Offset: 0x0030D060
		private void Start()
		{
			this.goShow = base.transform.gameObject;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ArtifactJarDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600C92B RID: 51499 RVA: 0x0030EC95 File Offset: 0x0030D095
		private void OnDestroy()
		{
			this.goShow = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ArtifactJarDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
		}

		// Token: 0x0600C92C RID: 51500 RVA: 0x0030ECB9 File Offset: 0x0030D0B9
		private void Update()
		{
		}

		// Token: 0x0600C92D RID: 51501 RVA: 0x0030ECBB File Offset: 0x0030D0BB
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			this.goShow.CustomActive(!ActivityJarFrame.IsHaveGotArtifactJarDiscount());
			if (ArtifactFrame.IsArtifactJarShowActivityOpen())
			{
				this.goShow.CustomActive(false);
			}
		}

		// Token: 0x04007418 RID: 29720
		private GameObject goShow;
	}
}
