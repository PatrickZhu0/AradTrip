using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001637 RID: 5687
	public class GuildMergeAskItem : MonoBehaviour
	{
		// Token: 0x0600DF6D RID: 57197 RVA: 0x003903B3 File Offset: 0x0038E7B3
		private void Awake()
		{
			this.mViewBtn.SafeAddOnClickListener(new UnityAction(this.OnViewBtnClick));
		}

		// Token: 0x0600DF6E RID: 57198 RVA: 0x003903CC File Offset: 0x0038E7CC
		private void OnDestroy()
		{
			this.mViewBtn.SafeRemoveOnClickListener(new UnityAction(this.OnViewBtnClick));
		}

		// Token: 0x0600DF6F RID: 57199 RVA: 0x003903E5 File Offset: 0x0038E7E5
		private void OnViewBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMergeAskInfoFrame>(FrameLayer.Middle, this.mGuildEntry, string.Empty);
		}

		// Token: 0x0600DF70 RID: 57200 RVA: 0x00390400 File Offset: 0x0038E800
		public void SetData(GuildEntry guildEntry)
		{
			if (guildEntry != null)
			{
				this.mGuildEntry = guildEntry;
				string str = string.Format(TR.Value("guildmerge_askinfo"), guildEntry.name);
				this.mDesTxt.SafeSetText(str);
				this.mArgeeImg.CustomActive(guildEntry.isRequested != 0);
			}
		}

		// Token: 0x040084AD RID: 33965
		[SerializeField]
		private Text mDesTxt;

		// Token: 0x040084AE RID: 33966
		[SerializeField]
		private Image mArgeeImg;

		// Token: 0x040084AF RID: 33967
		[SerializeField]
		private Button mViewBtn;

		// Token: 0x040084B0 RID: 33968
		private GuildEntry mGuildEntry;
	}
}
