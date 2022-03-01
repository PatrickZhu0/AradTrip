using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001987 RID: 6535
	public class ComSeasonReward : MonoBehaviour
	{
		// Token: 0x0400A021 RID: 40993
		public Image imgSeasonIcon;

		// Token: 0x0400A022 RID: 40994
		public Text labSeasonName;

		// Token: 0x0400A023 RID: 40995
		public GameObject objReward0;

		// Token: 0x0400A024 RID: 40996
		public GameObject objReward1;

		// Token: 0x0400A025 RID: 40997
		public GameObject objReward2;

		// Token: 0x0400A026 RID: 40998
		public GameObject objReward3;

		// Token: 0x0400A027 RID: 40999
		public GameObject objReward4;

		// Token: 0x0400A028 RID: 41000
		public GameObject objReward5;

		// Token: 0x0400A029 RID: 41001
		public GameObject objMySeasonLevel;

		// Token: 0x0400A02A RID: 41002
		[HideInInspector]
		public List<ComItem> arrComItems = new List<ComItem>();
	}
}
