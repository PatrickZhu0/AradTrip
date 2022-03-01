using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D5 RID: 6613
	public class RandomTreasureMiniMap : MonoBehaviour
	{
		// Token: 0x06010338 RID: 66360 RVA: 0x00484F1E File Offset: 0x0048331E
		private void Start()
		{
			if (this.mBackBtn != null)
			{
				this.mBackBtn.onClick.AddListener(new UnityAction(this._OnBackBtnClick));
			}
		}

		// Token: 0x06010339 RID: 66361 RVA: 0x00484F4D File Offset: 0x0048334D
		private void OnDestroy()
		{
			if (this.mBackBtn != null)
			{
				this.mBackBtn.onClick.RemoveListener(new UnityAction(this._OnBackBtnClick));
			}
			this.onBackBtnClick = null;
		}

		// Token: 0x0601033A RID: 66362 RVA: 0x00484F83 File Offset: 0x00483383
		private void _OnBackBtnClick()
		{
			if (this.onBackBtnClick != null)
			{
				this.onBackBtnClick.Invoke();
			}
		}

		// Token: 0x0601033B RID: 66363 RVA: 0x00484F9C File Offset: 0x0048339C
		public void RefreshView(int mapIndex)
		{
			if (this.mMiniMapSites == null)
			{
				Logger.LogError("[RandomTreasureMiniMap] - RefreshView mMiniMapSites is null");
				return;
			}
			if (mapIndex > this.mMiniMapSites.Length + 1 && mapIndex < 1)
			{
				Logger.LogError("[RandomTreasureMiniMap] - RefreshView mapIndex >= mMiniMapSites Length");
				return;
			}
			if (this.mOverlayMask)
			{
				RectTransform component = this.mOverlayMask.GetComponent<RectTransform>();
				GameObject gameObject = this.mMiniMapSites[mapIndex - 1];
				if (gameObject)
				{
					RectTransform component2 = gameObject.GetComponent<RectTransform>();
					if (component && component2)
					{
						component.anchoredPosition = component2.anchoredPosition;
					}
				}
			}
		}

		// Token: 0x0601033C RID: 66364 RVA: 0x0048503C File Offset: 0x0048343C
		public void BindFuncBtnEvent(UnityAction onFuncBtnClick)
		{
			this.onBackBtnClick = onFuncBtnClick;
		}

		// Token: 0x0400A3D1 RID: 41937
		private UnityAction onBackBtnClick;

		// Token: 0x0400A3D2 RID: 41938
		[SerializeField]
		private GameObject[] mMiniMapSites;

		// Token: 0x0400A3D3 RID: 41939
		[SerializeField]
		private GameObject mOverlayMask;

		// Token: 0x0400A3D4 RID: 41940
		[SerializeField]
		private Button mBackBtn;
	}
}
