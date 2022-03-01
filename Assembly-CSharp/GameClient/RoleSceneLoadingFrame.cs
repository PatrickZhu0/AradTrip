using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001170 RID: 4464
	public class RoleSceneLoadingFrame : ClientFrame
	{
		// Token: 0x0600AAAC RID: 43692 RVA: 0x002476A2 File Offset: 0x00245AA2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelectRole/SelectRoleLoadingFrame";
		}

		// Token: 0x0600AAAD RID: 43693 RVA: 0x002476A9 File Offset: 0x00245AA9
		protected override void _OnOpenFrame()
		{
			Object.DontDestroyOnLoad(this.frame);
			this.m_StringBuilder = StringBuilderCache.Acquire(256);
			this.Reset();
			this.SetBackgrounImage();
			base.StartCoroutine(this._Update());
		}

		// Token: 0x0600AAAE RID: 43694 RVA: 0x002476DF File Offset: 0x00245ADF
		protected override void _OnCloseFrame()
		{
			if (this.m_StringBuilder != null)
			{
				StringBuilderCache.Release(this.m_StringBuilder);
			}
		}

		// Token: 0x0600AAAF RID: 43695 RVA: 0x002476F8 File Offset: 0x00245AF8
		public void Reset()
		{
			this.m_TargetProgress = 0;
			this.m_CurrentProgress = 0;
			this.m_DisplayInfo = string.Empty;
			this.m_DisplayState = string.Empty;
			this.m_LoadProcess.value = (float)this.m_TargetProgress * 0.01f;
			this.m_LoadingProgressInfoText.text = this.m_DisplayInfo;
			this.m_LoadingProgressStateText.text = this.m_DisplayState;
		}

		// Token: 0x0600AAB0 RID: 43696 RVA: 0x00247763 File Offset: 0x00245B63
		public void AddLoadingTask(string res)
		{
			if (!string.IsNullOrEmpty(res))
			{
				this.m_LoadingResList.Add(res);
			}
		}

		// Token: 0x0600AAB1 RID: 43697 RVA: 0x0024777C File Offset: 0x00245B7C
		public void ProcessLoading()
		{
			base.StartCoroutine(this._StepLoading());
		}

		// Token: 0x0600AAB2 RID: 43698 RVA: 0x0024778C File Offset: 0x00245B8C
		protected IEnumerator _StepLoading()
		{
			int i = 0;
			int icnt = this.m_LoadingResList.Count;
			while (i < icnt)
			{
				this._SetLoadingInfo((int)((float)i * 100f / (float)icnt), null, "正在加载角色资源...");
				yield return Yielders.EndOfFrame;
				i++;
			}
			this.m_LoadingResList.Clear();
			Singleton<ClientSystemManager>.instance.CloseFrame<RoleSceneLoadingFrame>(this, false);
			yield break;
		}

		// Token: 0x0600AAB3 RID: 43699 RVA: 0x002477A7 File Offset: 0x00245BA7
		protected void _SetLoadingInfo(int progress, string info = null, string state = null)
		{
			if (progress > this.m_TargetProgress)
			{
				this.m_TargetProgress = progress;
			}
			if (!string.IsNullOrEmpty(info))
			{
				this.m_DisplayInfo = info;
			}
			if (!string.IsNullOrEmpty(state))
			{
				this.m_DisplayState = state;
			}
		}

		// Token: 0x0600AAB4 RID: 43700 RVA: 0x002477E0 File Offset: 0x00245BE0
		protected IEnumerator _Update()
		{
			while (this.m_TargetProgress <= 100)
			{
				while (this.m_CurrentProgress < this.m_TargetProgress)
				{
					this.m_CurrentProgress += 100;
					if (this.m_CurrentProgress > this.m_TargetProgress)
					{
						this.m_CurrentProgress = this.m_TargetProgress;
					}
					this._DisplayPrgress(this.m_CurrentProgress);
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

		// Token: 0x0600AAB5 RID: 43701 RVA: 0x002477FC File Offset: 0x00245BFC
		protected void _DisplayPrgress(int curPrgress)
		{
			if (curPrgress < 0)
			{
				curPrgress = 0;
			}
			if (curPrgress > 100)
			{
				curPrgress = 100;
			}
			this.m_LoadProcess.value = (float)curPrgress * 0.01f;
			MyExtensionMethods.Clear(this.m_StringBuilder);
			this.m_StringBuilder.AppendFormat("{0} %", curPrgress);
			this.m_LoadingProgressInfoText.text = this.m_DisplayInfo + this.m_StringBuilder.ToString();
			this.m_LoadingProgressStateText.text = this.m_DisplayState;
		}

		// Token: 0x0600AAB6 RID: 43702 RVA: 0x00247888 File Offset: 0x00245C88
		private void SetBackgrounImage()
		{
			if (this.mBgImg != null)
			{
				string sdklogoPath = PluginManager.GetSDKLogoPath(SDKInterface.SDKLogoType.SelectRole);
				if (string.IsNullOrEmpty(sdklogoPath))
				{
					return;
				}
				ETCImageLoader.LoadSprite(ref this.mBgImg, sdklogoPath, true);
			}
		}

		// Token: 0x04005FA8 RID: 24488
		[UIControl("Loading_progress", null, 0)]
		private Slider m_LoadProcess;

		// Token: 0x04005FA9 RID: 24489
		[UIControl("Loading_progress/loading_progress_info", null, 0)]
		private Text m_LoadingProgressInfoText;

		// Token: 0x04005FAA RID: 24490
		[UIControl("Loading_progress/loading_progress_state", null, 0)]
		private Text m_LoadingProgressStateText;

		// Token: 0x04005FAB RID: 24491
		[UIControl("Loading_background", null, 0)]
		private Image mBgImg;

		// Token: 0x04005FAC RID: 24492
		protected StringBuilder m_StringBuilder;

		// Token: 0x04005FAD RID: 24493
		protected string m_DisplayInfo;

		// Token: 0x04005FAE RID: 24494
		protected string m_DisplayState;

		// Token: 0x04005FAF RID: 24495
		protected int m_CurrentProgress;

		// Token: 0x04005FB0 RID: 24496
		protected int m_TargetProgress;

		// Token: 0x04005FB1 RID: 24497
		protected List<string> m_LoadingResList = new List<string>();
	}
}
