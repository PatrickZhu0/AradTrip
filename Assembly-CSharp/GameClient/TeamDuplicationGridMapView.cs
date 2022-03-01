using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C81 RID: 7297
	public class TeamDuplicationGridMapView : MonoBehaviour
	{
		// Token: 0x06011E77 RID: 73335 RVA: 0x0053CB0A File Offset: 0x0053AF0A
		public void Init()
		{
			this.InitContentControl();
			this.InitCommonControl();
		}

		// Token: 0x06011E78 RID: 73336 RVA: 0x0053CB18 File Offset: 0x0053AF18
		private void InitContentControl()
		{
			if (this.contentView == null)
			{
				return;
			}
			this.contentView.InitContentView();
		}

		// Token: 0x06011E79 RID: 73337 RVA: 0x0053CB37 File Offset: 0x0053AF37
		private void InitCommonControl()
		{
			if (this.commonView == null)
			{
				return;
			}
			this.commonView.InitCommonView();
		}

		// Token: 0x0400BA91 RID: 47761
		[Space(10f)]
		[Header("ContentView")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapContentView contentView;

		// Token: 0x0400BA92 RID: 47762
		[Space(10f)]
		[Header("CountDownTimeView")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationGridMapCommonView commonView;
	}
}
