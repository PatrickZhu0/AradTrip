using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017E8 RID: 6120
	internal class ComSetMaterial : MonoBehaviour
	{
		// Token: 0x0600F0F8 RID: 61688 RVA: 0x0040E348 File Offset: 0x0040C748
		private void Awake()
		{
			this._enableMaterial = ETCImageLoader.LoadMaterialFromSpritePath(this.enableMaterial, true);
			this._disableMaterial = Singleton<GeMaterialPool>.instance.CreateMaterialInstance(this.disableMaterial);
		}

		// Token: 0x0600F0F9 RID: 61689 RVA: 0x0040E374 File Offset: 0x0040C774
		public void SetMaterialEnable(bool bEnable)
		{
			for (int i = 0; i < this.imgs.Length; i++)
			{
				if (null != this.imgs[i])
				{
					this.imgs[i].material = ((!bEnable) ? this._disableMaterial : this._enableMaterial);
				}
			}
		}

		// Token: 0x0600F0FA RID: 61690 RVA: 0x0040E3D1 File Offset: 0x0040C7D1
		private void OnDestroy()
		{
			this._enableMaterial = null;
			if (null != this._disableMaterial)
			{
				Singleton<GeMaterialPool>.instance.RecycleMaterialInstance(this.disableMaterial, this._disableMaterial);
				this._disableMaterial = null;
			}
		}

		// Token: 0x0400940E RID: 37902
		public string enableMaterial;

		// Token: 0x0400940F RID: 37903
		public string disableMaterial;

		// Token: 0x04009410 RID: 37904
		public Image[] imgs = new Image[0];

		// Token: 0x04009411 RID: 37905
		private Material _enableMaterial;

		// Token: 0x04009412 RID: 37906
		private Material _disableMaterial;
	}
}
