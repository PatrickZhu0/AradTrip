using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FF7 RID: 4087
public class ComNewbieGuidePassThrough : ComNewbieGuideBase
{
	// Token: 0x06009BB1 RID: 39857 RVA: 0x001E5AF4 File Offset: 0x001E3EF4
	public override void StartInit(params object[] args)
	{
		this.mWaitTime = 0f;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mFrameType = (args[0] as string);
			}
			if (args.Length >= 2)
			{
				this.mComRoot = (args[1] as string);
			}
			if (args.Length >= 3 && (eNewbieGuideAgrsName)args[2] == eNewbieGuideAgrsName.AutoClose)
			{
				this.mOpenAutoClose = true;
			}
			if (args.Length >= 4)
			{
				this.mWaitTime = (float)args[3];
			}
			if (args.Length >= 5)
			{
				this.mShowBindObjName = (args[4] as string);
			}
			if (args.Length >= 6)
			{
				this.mTextTips = (args[5] as string);
			}
			if (args.Length >= 7)
			{
				this.mAnchor = (ComNewbieGuideBase.eNewbieGuideAnchor)args[6];
			}
			if (args.Length >= 8)
			{
				this.mTextTipType = (TextTipType)args[7];
			}
			if (args.Length >= 9 && (eNewbieGuideAgrsName)args[8] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
		}
	}

	// Token: 0x06009BB2 RID: 39858 RVA: 0x001E5BF8 File Offset: 0x001E3FF8
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
		if (!instance.IsFrameOpen(this.mFrameType))
		{
			return ComNewbieGuideBase.GuideState.Wait;
		}
		IGameBind gameBind = instance.GetFrame(this.mFrameType) as IGameBind;
		if (gameBind == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		Button ClickRect = gameBind.GetComponent<Button>(this.mComRoot);
		if (ClickRect == null)
		{
			Logger.LogErrorFormat("ClickRect is nil with path : {0}", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject showAreaRoot = null;
		if (this.mShowBindObjName != string.Empty)
		{
			showAreaRoot = gameBind.GetComponent<RectTransform>(this.mShowBindObjName).gameObject;
		}
		GameObject root = base.AddPassThroughTips(ClickRect.gameObject, showAreaRoot, delegate
		{
			ClickRect.onClick.Invoke();
		});
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BB3 RID: 39859 RVA: 0x001E5CF8 File Offset: 0x001E40F8
	protected override void _update()
	{
		if (this.mOpenAutoClose)
		{
			if (this.mWaitTime > 0f)
			{
				this.mWaitTime -= Time.deltaTime;
			}
			else if (this.mGuideControl != null)
			{
				this.mGuideControl.ControlComplete();
			}
		}
	}

	// Token: 0x04005521 RID: 21793
	public string mShowBindObjName = string.Empty;

	// Token: 0x04005522 RID: 21794
	public bool mOpenAutoClose;

	// Token: 0x04005523 RID: 21795
	public float mWaitTime;
}
