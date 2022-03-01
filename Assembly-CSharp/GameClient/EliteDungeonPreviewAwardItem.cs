using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200153F RID: 5439
	public class EliteDungeonPreviewAwardItem : MonoBehaviour
	{
		// Token: 0x0600D472 RID: 54386 RVA: 0x0035052E File Offset: 0x0034E92E
		private void Start()
		{
		}

		// Token: 0x0600D473 RID: 54387 RVA: 0x00350530 File Offset: 0x0034E930
		private void Update()
		{
		}

		// Token: 0x0600D474 RID: 54388 RVA: 0x00350534 File Offset: 0x0034E934
		private void OnDestroy()
		{
			ComChapterInfoDropUnit comChapterInfoDropUnit = this.comChapterInfoDropUnit;
			if (null != comChapterInfoDropUnit)
			{
				comChapterInfoDropUnit.Unload();
			}
		}

		// Token: 0x0600D475 RID: 54389 RVA: 0x0035055C File Offset: 0x0034E95C
		public void SetUp(object data)
		{
			if (!(data is int))
			{
				return;
			}
			int id = (int)data;
			ComChapterInfoDropUnit comChapterInfoDropUnit = this.comChapterInfoDropUnit;
			if (null != comChapterInfoDropUnit)
			{
				comChapterInfoDropUnit.Load(id);
				comChapterInfoDropUnit.ShowName(true);
				comChapterInfoDropUnit.ShowLevel(true);
			}
		}

		// Token: 0x04007C9B RID: 31899
		[SerializeField]
		private ComChapterInfoDropUnit comChapterInfoDropUnit;
	}
}
