using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BAB RID: 7083
	public class SetTimeShowCloseBtn : MonoBehaviour
	{
		// Token: 0x06011593 RID: 71059 RVA: 0x00504784 File Offset: 0x00502B84
		private void Update()
		{
			if (!this.isUpdate)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= this.mTime)
				{
					for (int i = 0; i < this.mCloseRoots.Count; i++)
					{
						this.mCloseRoots[i].CustomActive(true);
					}
					this.isUpdate = true;
				}
			}
		}

		// Token: 0x06011594 RID: 71060 RVA: 0x005047F4 File Offset: 0x00502BF4
		private void OnDestroy()
		{
			this.isUpdate = false;
			this.timer = 0f;
		}

		// Token: 0x0400B3D4 RID: 46036
		[SerializeField]
		private List<GameObject> mCloseRoots;

		// Token: 0x0400B3D5 RID: 46037
		[SerializeField]
		private float mTime;

		// Token: 0x0400B3D6 RID: 46038
		private bool isUpdate;

		// Token: 0x0400B3D7 RID: 46039
		private float timer;
	}
}
