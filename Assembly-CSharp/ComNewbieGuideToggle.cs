using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FFF RID: 4095
public class ComNewbieGuideToggle : ComNewbieGuideButton
{
	// Token: 0x06009BC9 RID: 39881 RVA: 0x001E635C File Offset: 0x001E475C
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
		Toggle button = gameBind.GetComponent<Toggle>(this.mComRoot);
		if (button == null)
		{
			if (this.mGuideControl != null)
			{
				Logger.LogErrorFormat("Toggle is nil with path [{0}], GuideTaskID = {1}, currentIndex = {2}", new object[]
				{
					this.mComRoot,
					this.mGuideControl.GuideTaskID,
					this.mGuideControl.currentIndex
				});
			}
			else
			{
				Logger.LogErrorFormat("Toggle is nil with path [{0}]", new object[]
				{
					this.mComRoot
				});
			}
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject root = base.AddButtonTips(button.gameObject, delegate
		{
			button.isOn = true;
			button.onValueChanged.Invoke(true);
		}, null, 1f);
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
