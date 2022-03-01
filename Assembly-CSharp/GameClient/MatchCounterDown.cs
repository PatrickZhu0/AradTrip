using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000081 RID: 129
	[RequireComponent(typeof(Text))]
	internal class MatchCounterDown : MonoBehaviour
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x0001593B File Offset: 0x00013D3B
		private void Start()
		{
			this.text = base.GetComponent<Text>();
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00015949 File Offset: 0x00013D49
		private void OnEnable()
		{
			this.iTime = MatchCounterDown.iLimitTime;
			base.CancelInvoke("_OnUpdate");
			base.InvokeRepeating("_OnUpdate", 0f, 1f);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00015978 File Offset: 0x00013D78
		private void _OnUpdate()
		{
			if (this.text == null)
			{
				this.text = base.GetComponent<Text>();
			}
			if (this.text != null)
			{
				this.text.text = string.Format("匹配中...({0:D2}s)", this.iTime--);
			}
			if (this.iTime < 0)
			{
				this.iTime = MatchCounterDown.iLimitTime;
			}
		}

		// Token: 0x040002C0 RID: 704
		private Text text;

		// Token: 0x040002C1 RID: 705
		private int iTime;

		// Token: 0x040002C2 RID: 706
		private static int iLimitTime = 30;
	}
}
