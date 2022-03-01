using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FFD RID: 4093
[LoggerModel("NewbieGuide")]
public class ComNewbieGuideSystemButton : ComNewbieGuideButton
{
	// Token: 0x06009BC4 RID: 39876 RVA: 0x001E61A4 File Offset: 0x001E45A4
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IGameBind gameBind = Singleton<ClientSystemManager>.instance.CurrentSystem as IGameBind;
		if (gameBind == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		Button button = gameBind.GetComponent<Button>(this.mComRoot);
		if (button == null)
		{
			Logger.LogErrorFormat("button is nil with path", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject root = base.AddButtonTips(button.gameObject, delegate
		{
			button.onClick.Invoke();
		}, null, 1f);
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, TextTipType.TextTipType_One, default(Vector3));
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
