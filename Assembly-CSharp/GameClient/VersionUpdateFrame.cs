using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000222 RID: 546
	public class VersionUpdateFrame : ClientFrame
	{
		// Token: 0x06001223 RID: 4643 RVA: 0x00062C24 File Offset: 0x00061024
		public void UpdateProgressState(string state)
		{
			if (null != this.m_LoadingProgressText)
			{
				this.m_LoadingProgressText.text = state;
			}
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x00062C43 File Offset: 0x00061043
		public void ResetProgress(string info)
		{
			this.m_TargetProgress = 0;
			this.m_CurrentProgress = -1;
			this.m_UpdateInfo = info;
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x00062C5A File Offset: 0x0006105A
		public void UpdateProgress(int targetProgress, string info)
		{
			if (targetProgress > this.m_TargetProgress)
			{
				this.m_TargetProgress = targetProgress;
			}
			if (info != null)
			{
				this.m_UpdateInfo = info;
			}
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x00062C7C File Offset: 0x0006107C
		public override string GetPrefabPath()
		{
			return "Base/Version/VersionFrame/VersionUpdateFrame";
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x00062C84 File Offset: 0x00061084
		protected override void _OnOpenFrame()
		{
			this.SetBackgroundImage();
			this.m_UpdateSpeed = Global.Settings.loadingProgressStep;
			Object.DontDestroyOnLoad(this.frame);
			this.m_StringBuilder = StringBuilderCache.Acquire(256);
			this.m_TargetProgress = 0;
			this.m_CurrentProgress = -1;
			base.StartCoroutine(this._UpdateProgress());
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x00062CDD File Offset: 0x000610DD
		protected override void _OnCloseFrame()
		{
			StringBuilderCache.Release(this.m_StringBuilder);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x00062CEA File Offset: 0x000610EA
		protected override bool _IsLoadingFrame()
		{
			return false;
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00062CF0 File Offset: 0x000610F0
		protected void _SetProgress(int progress)
		{
			if (progress < 0)
			{
				progress = 0;
			}
			if (progress > 100)
			{
				progress = 100;
			}
			this.m_LoadProcess.value = (float)progress / 100f;
			MyExtensionMethods.Clear(this.m_StringBuilder);
			this.m_StringBuilder.AppendFormat("{0}%", progress);
			this.m_LoadingProgressInfoText.text = this.m_UpdateInfo + this.m_StringBuilder.ToString();
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00062D6C File Offset: 0x0006116C
		public IEnumerator _UpdateProgress()
		{
			while (this.m_TargetProgress <= 100)
			{
				while (this.m_CurrentProgress < this.m_TargetProgress)
				{
					this.m_CurrentProgress += this.m_UpdateSpeed;
					if (this.m_CurrentProgress > this.m_TargetProgress)
					{
						this.m_CurrentProgress = this.m_TargetProgress;
					}
					this._SetProgress(this.m_CurrentProgress);
					yield return Yielders.EndOfFrame;
				}
				if (this.m_TargetProgress == 100)
				{
					break;
				}
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00062D87 File Offset: 0x00061187
		public void SetVersionInfoBgActive(bool isShow)
		{
			if (this.versionInfoBg)
			{
				this.versionInfoBg.CustomActive(isShow);
			}
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x00062DA8 File Offset: 0x000611A8
		private void SetBackgroundImage()
		{
			if (this.mBackground != null)
			{
				string sdklogoPath = PluginManager.GetSDKLogoPath(SDKInterface.SDKLogoType.VersionUpdate);
				if (string.IsNullOrEmpty(sdklogoPath))
				{
					return;
				}
				Sprite sprite = Resources.Load<Sprite>(sdklogoPath);
				if (sprite != null)
				{
					this.mBackground.sprite = sprite;
				}
			}
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x00062DF8 File Offset: 0x000611F8
		public void SetSliderColorAlpha(float colorAlpha)
		{
			if (this.m_LoadProcessBgImg)
			{
				Color color = this.m_LoadProcessBgImg.color;
				this.m_LoadProcessBgImg.color = new Color(color.r, color.g, color.b, colorAlpha);
			}
			if (this.m_LoadProcessCoverImg)
			{
				Color color2 = this.m_LoadProcessCoverImg.color;
				this.m_LoadProcessCoverImg.color = new Color(color2.r, color2.g, color2.b, colorAlpha);
			}
			if (this.m_LoadingProgressInfoText)
			{
				Color color3 = this.m_LoadingProgressInfoText.color;
				this.m_LoadingProgressInfoText.color = new Color(color3.r, color3.g, color3.b, colorAlpha);
			}
			if (this.m_LoadingProgressText)
			{
				Color color4 = this.m_LoadingProgressText.color;
				this.m_LoadingProgressText.color = new Color(color4.r, color4.g, color4.b, colorAlpha);
			}
		}

		// Token: 0x04000C16 RID: 3094
		[UIControl("hot_update_progress", null, 0)]
		private Slider m_LoadProcess;

		// Token: 0x04000C17 RID: 3095
		[UIControl("hot_update_progress/hot_update_progress_info", null, 0)]
		private Text m_LoadingProgressInfoText;

		// Token: 0x04000C18 RID: 3096
		[UIControl("hot_update_progress/hot_update_progress_cur", null, 0)]
		private Text m_LoadingProgressText;

		// Token: 0x04000C19 RID: 3097
		[UIControl("hot_update_progress", null, 0)]
		private Image m_LoadProcessBgImg;

		// Token: 0x04000C1A RID: 3098
		[UIControl("hot_update_progress/hot_update_progress_bar", null, 0)]
		private Image m_LoadProcessCoverImg;

		// Token: 0x04000C1B RID: 3099
		[UIObject("version_info_background")]
		private GameObject versionInfoBg;

		// Token: 0x04000C1C RID: 3100
		[UIControl("hot_update_background", null, 0)]
		private Image mBackground;

		// Token: 0x04000C1D RID: 3101
		protected StringBuilder m_StringBuilder;

		// Token: 0x04000C1E RID: 3102
		protected string m_UpdateInfo;

		// Token: 0x04000C1F RID: 3103
		protected int m_UpdateSpeed = 10;

		// Token: 0x04000C20 RID: 3104
		protected int m_TargetProgress;

		// Token: 0x04000C21 RID: 3105
		protected int m_CurrentProgress = -1;
	}
}
