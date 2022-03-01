using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF0 RID: 4080
public class ComNewbieGuideETCButton : ComNewbieGuideBase
{
	// Token: 0x06009B97 RID: 39831 RVA: 0x001E506C File Offset: 0x001E346C
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		this.mButtonName = string.Empty;
		this.mContent = string.Empty;
		if (args != null)
		{
			if (args.Length >= 2)
			{
				this.mButtonName = (args[0] as string);
				this.mAnchor = (ComNewbieGuideBase.eNewbieGuideAnchor)args[1];
			}
			if (args.Length >= 3)
			{
				this.mContent = (args[2] as string);
			}
		}
	}

	// Token: 0x06009B98 RID: 39832 RVA: 0x001E50D8 File Offset: 0x001E34D8
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
		GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.MiddleLayer, InputManager.GetEtcSkillRoot(), true);
		if (gameObject == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject gameObject2 = Utility.FindGameObject(gameObject, this.mButtonName, true);
		if (gameObject2 == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		ETCButton etcButtonCom = gameObject2.GetComponent<ETCButton>();
		if (etcButtonCom == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		if (!etcButtonCom.isActiveAndEnabled)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject root = base.AddTouchedTips(gameObject2, delegate
		{
			etcButtonCom.onDown.Invoke();
		}, delegate
		{
			etcButtonCom.onUp.Invoke();
		});
		if (this.mContent.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mContent, TextTipType.TextTipType_One, default(Vector3));
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x04005514 RID: 21780
	public string mButtonName;

	// Token: 0x04005515 RID: 21781
	public string mContent = string.Empty;
}
