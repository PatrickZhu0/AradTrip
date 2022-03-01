using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F2C RID: 3884
	public class ComToggleChangeVisible : MonoBehaviour
	{
		// Token: 0x06009778 RID: 38776 RVA: 0x001D0388 File Offset: 0x001CE788
		public void SetToggleIsOn(bool isOn)
		{
			CommonUtility.UpdateGameObjectVisible(this.toggleNormalTabGo, !isOn);
			CommonUtility.UpdateGameObjectVisible(this.toggleSelectedTabGo, isOn);
		}

		// Token: 0x04004E21 RID: 20001
		[SerializeField]
		private GameObject toggleNormalTabGo;

		// Token: 0x04004E22 RID: 20002
		[SerializeField]
		private GameObject toggleSelectedTabGo;
	}
}
