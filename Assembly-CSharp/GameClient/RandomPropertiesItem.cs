using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B73 RID: 7027
	public class RandomPropertiesItem : MonoBehaviour
	{
		// Token: 0x0601137F RID: 70527 RVA: 0x004F44E5 File Offset: 0x004F28E5
		public void OnItemVisible(int iBuffId)
		{
			this.mArrtDes.text = DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(iBuffId);
		}

		// Token: 0x0400B1CC RID: 45516
		[SerializeField]
		private Text mArrtDes;
	}
}
