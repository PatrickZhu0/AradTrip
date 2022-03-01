using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001936 RID: 6454
	public class ZillionaireGameGridItem : MonoBehaviour
	{
		// Token: 0x17001D0A RID: 7434
		// (get) Token: 0x0600FAF6 RID: 64246 RVA: 0x0044C13A File Offset: 0x0044A53A
		public MapGridItemData MapGridItemData
		{
			get
			{
				return this.mapGridItemData;
			}
		}

		// Token: 0x0600FAF7 RID: 64247 RVA: 0x0044C142 File Offset: 0x0044A542
		private void Awake()
		{
			if (this.itemBtn != null)
			{
				this.itemBtn.onClick.RemoveAllListeners();
				this.itemBtn.onClick.AddListener(new UnityAction(this.OnItemBtnClick));
			}
		}

		// Token: 0x0600FAF8 RID: 64248 RVA: 0x0044C181 File Offset: 0x0044A581
		private void OnDestroy()
		{
			if (this.itemBtn != null)
			{
				this.itemBtn.onClick.RemoveListener(new UnityAction(this.OnItemBtnClick));
			}
			this.mapGridItemData = null;
		}

		// Token: 0x0600FAF9 RID: 64249 RVA: 0x0044C1B7 File Offset: 0x0044A5B7
		private void OnItemBtnClick()
		{
			if (this.mapGridItemData == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ZillionaireGameGridItemTipsFrame>(FrameLayer.Middle, this.mapGridItemData, string.Empty);
		}

		// Token: 0x0600FAFA RID: 64250 RVA: 0x0044C1DC File Offset: 0x0044A5DC
		public void OnItemVisiable(MapGridItemData mapGridItemData)
		{
			if (mapGridItemData == null)
			{
				return;
			}
			this.mapGridItemData = mapGridItemData;
			if (this.itemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemIcon, mapGridItemData.gridIconPath, true);
			}
			if (this.itemCount != null)
			{
				if (mapGridItemData.gridType == 6 || mapGridItemData.gridType == 7 || mapGridItemData.gridType == 8 || mapGridItemData.gridType == 9)
				{
					this.itemCount.text = string.Format("x{0}", mapGridItemData.itemCount);
				}
				else
				{
					this.itemCount.text = string.Empty;
				}
			}
		}

		// Token: 0x04009CCF RID: 40143
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04009CD0 RID: 40144
		[SerializeField]
		private Button itemBtn;

		// Token: 0x04009CD1 RID: 40145
		[SerializeField]
		private Text itemCount;

		// Token: 0x04009CD2 RID: 40146
		private MapGridItemData mapGridItemData;
	}
}
