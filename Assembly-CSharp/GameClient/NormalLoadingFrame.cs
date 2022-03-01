using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E4C RID: 3660
	internal class NormalLoadingFrame : ClientFrame
	{
		// Token: 0x060091AE RID: 37294 RVA: 0x001AFB00 File Offset: 0x001ADF00
		private void SetProcess(int iProcess)
		{
			this.loadProcess.value = (float)iProcess / 100f;
			MyExtensionMethods.Clear(this.strBuilder);
			this.strBuilder.AppendFormat("读取中...{0}%", iProcess);
			this.loadText.text = this.strBuilder.ToString();
		}

		// Token: 0x060091AF RID: 37295 RVA: 0x001AFB58 File Offset: 0x001ADF58
		protected sealed override void _OnOpenFrame()
		{
			this.strBuilder = StringBuilderCache.Acquire(256);
			base.StartCoroutine(this.LoadStartLoading());
		}

		// Token: 0x060091B0 RID: 37296 RVA: 0x001AFB77 File Offset: 0x001ADF77
		protected sealed override void _OnCloseFrame()
		{
			StringBuilderCache.Release(this.strBuilder);
		}

		// Token: 0x060091B1 RID: 37297 RVA: 0x001AFB84 File Offset: 0x001ADF84
		public IEnumerator LoadStartLoading()
		{
			AsyncOperation op = ClientApplication.LoadLevelAsync(NormalLoadingFrame.iSceneIndex);
			int curProcess = 0;
			int displayProcess = 0;
			op.allowSceneActivation = false;
			NormalLoadingFrame.next next_func = delegate()
			{
				if (displayProcess >= curProcess && curProcess != 0)
				{
					return true;
				}
				displayProcess += NormalLoadingFrame.iLoadSpeed;
				displayProcess = Mathf.Min(displayProcess, curProcess);
				this.SetProcess(displayProcess);
				return false;
			};
			while (op.progress < 0.9f)
			{
				curProcess = (int)(op.progress * 100f);
				if (next_func())
				{
					break;
				}
				yield return Yielders.EndOfFrame;
			}
			curProcess = 100;
			while (!next_func())
			{
				yield return Yielders.EndOfFrame;
			}
			op.allowSceneActivation = true;
			ClientApplication.ops = null;
			yield break;
		}

		// Token: 0x060091B2 RID: 37298 RVA: 0x001AFB9F File Offset: 0x001ADF9F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Loading/LoadingFrame";
		}

		// Token: 0x040048D5 RID: 18645
		public static int iSceneIndex;

		// Token: 0x040048D6 RID: 18646
		public static int iLoadSpeed = 10;

		// Token: 0x040048D7 RID: 18647
		[UIControl("loading", null, 0)]
		private Slider loadProcess;

		// Token: 0x040048D8 RID: 18648
		[UIControl("loading/loadingText", null, 0)]
		private Text loadText;

		// Token: 0x040048D9 RID: 18649
		private StringBuilder strBuilder;

		// Token: 0x02000E4D RID: 3661
		// (Invoke) Token: 0x060091B5 RID: 37301
		private delegate bool next();
	}
}
