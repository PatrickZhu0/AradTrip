using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001103 RID: 4355
	public class ChijiBackPackDisplayNode : MonoBehaviour
	{
		// Token: 0x0600A518 RID: 42264 RVA: 0x00220E48 File Offset: 0x0021F248
		private void Awake()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				if (this.mStateControl != null)
				{
					this.mStateControl.Key = this.chiji;
				}
			}
			else if (this.mStateControl != null)
			{
				this.mStateControl.Key = this.normal;
			}
		}

		// Token: 0x0600A519 RID: 42265 RVA: 0x00220EB4 File Offset: 0x0021F2B4
		private void OnDestroy()
		{
			this.mStateControl = null;
		}

		// Token: 0x04005C21 RID: 23585
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x04005C22 RID: 23586
		private string normal = "normal";

		// Token: 0x04005C23 RID: 23587
		private string chiji = "chiji";
	}
}
