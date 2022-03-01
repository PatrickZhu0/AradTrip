using System;

namespace GameClient
{
	// Token: 0x020001FC RID: 508
	internal class ScriptBinderTestFrame : ClientFrame
	{
		// Token: 0x06001037 RID: 4151 RVA: 0x00054B26 File Offset: 0x00052F26
		protected override void _OnOpenFrame()
		{
			this._InitScriptBinder();
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x00054B2E File Offset: 0x00052F2E
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x00054B30 File Offset: 0x00052F30
		public static void CommandOpen(object argv = null)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ScriptBinderTestFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ScriptBinderTestFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x00054B50 File Offset: 0x00052F50
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FunctionFrame/FunctionFrame";
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x00054B58 File Offset: 0x00052F58
		private void _InitScriptBinder()
		{
			if (null != this.mScriptBinder)
			{
				LinkParse script = this.mScriptBinder.GetScript<LinkParse>(1);
				if (null != script)
				{
					script.SetText("I am a cao ni ma !!!", true);
				}
				this.mScriptBinder.SetText(0, "what a fucking day !!!");
				this.mScriptBinder.SetImage(2, 0);
			}
		}

		// Token: 0x04000B18 RID: 2840
		[UIControl("", typeof(ComScriptBinder), 0)]
		private ComScriptBinder mScriptBinder;
	}
}
