using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200003C RID: 60
	internal class ComJarPrefabSet : MonoBehaviour
	{
		// Token: 0x0600017F RID: 383 RVA: 0x0000E0B8 File Offset: 0x0000C4B8
		private void Start()
		{
			if (this.goJar == null)
			{
				BudoAwardTable budoAwardTable = (!this.bUsePre) ? DataManager<BudoManager>.GetInstance().GetJarItemByTimes() : DataManager<BudoManager>.GetInstance().GetPreJarItemByTimes();
				if (budoAwardTable != null)
				{
					if (this.eJarPrefabType == JarPrefabType.JPT_IDLE)
					{
						this.goJar = (Singleton<AssetLoader>.instance.LoadRes(budoAwardTable.idles, true, 0U).obj as GameObject);
					}
					else if (this.eJarPrefabType == JarPrefabType.JPT_WIN)
					{
						this.goJar = (Singleton<AssetLoader>.instance.LoadRes(budoAwardTable.wins, true, 0U).obj as GameObject);
					}
					else if (this.eJarPrefabType == JarPrefabType.JPT_NEW)
					{
						this.goJar = (Singleton<AssetLoader>.instance.LoadRes(budoAwardTable.news, true, 0U).obj as GameObject);
					}
					if (this.goJar != null)
					{
						Utility.AttachTo(this.goJar, base.gameObject, false);
						this.goJar.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000E1C3 File Offset: 0x0000C5C3
		private void OnDestroy()
		{
			if (this.goJar != null)
			{
				this.goJar.transform.SetParent(null);
				Object.Destroy(this.goJar);
				this.goJar = null;
			}
		}

		// Token: 0x0400015E RID: 350
		public JarPrefabType eJarPrefabType;

		// Token: 0x0400015F RID: 351
		private GameObject goJar;

		// Token: 0x04000160 RID: 352
		public bool bUsePre;
	}
}
