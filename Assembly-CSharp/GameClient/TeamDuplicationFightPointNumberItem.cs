using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C86 RID: 7302
	public class TeamDuplicationFightPointNumberItem : MonoBehaviour
	{
		// Token: 0x06011E94 RID: 73364 RVA: 0x0053D454 File Offset: 0x0053B854
		public void Init(bool isFinished)
		{
			CommonUtility.UpdateImageVisible(this.fightNumberCover, !isFinished);
		}

		// Token: 0x0400BAAD RID: 47789
		[Space(10f)]
		[Header("Cover")]
		[Space(5f)]
		[SerializeField]
		private Image fightNumberCover;
	}
}
