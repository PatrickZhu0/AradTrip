using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017F5 RID: 6133
	[RequireComponent(typeof(Text))]
	public class ComBaseWebViewTitle : MonoBehaviour
	{
		// Token: 0x0600F1B8 RID: 61880 RVA: 0x00412D0A File Offset: 0x0041110A
		private void Awake()
		{
			this.titleText = base.GetComponent<Text>();
		}

		// Token: 0x0600F1B9 RID: 61881 RVA: 0x00412D18 File Offset: 0x00411118
		private void OnDestroy()
		{
			this.kindTitleInfos = null;
		}

		// Token: 0x0600F1BA RID: 61882 RVA: 0x00412D24 File Offset: 0x00411124
		public void SetTitleByType(BaseWebViewType type)
		{
			if (this.titleText == null)
			{
				return;
			}
			if (type == BaseWebViewType.None || type == BaseWebViewType.Count)
			{
				return;
			}
			if (this.kindTitleInfos == null || this.kindTitleInfos.Length <= 0)
			{
				return;
			}
			for (int i = 0; i < this.kindTitleInfos.Length; i++)
			{
				BaseWebViewTitleInfo baseWebViewTitleInfo = this.kindTitleInfos[i];
				if (baseWebViewTitleInfo != null)
				{
					if (baseWebViewTitleInfo.type == type)
					{
						this.titleText.text = baseWebViewTitleInfo.titleName;
						return;
					}
				}
			}
		}

		// Token: 0x04009485 RID: 38021
		[SerializeField]
		private BaseWebViewTitleInfo[] kindTitleInfos;

		// Token: 0x04009486 RID: 38022
		private Text titleText;
	}
}
