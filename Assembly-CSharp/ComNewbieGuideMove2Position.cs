using System;
using UnityEngine;

// Token: 0x02000FF4 RID: 4084
public class ComNewbieGuideMove2Position : ComNewbieGuideBase
{
	// Token: 0x06009BA5 RID: 39845 RVA: 0x001E57F3 File Offset: 0x001E3BF3
	public override void StartInit(params object[] args)
	{
		this.mTryPauseBattleAI = true;
	}

	// Token: 0x06009BA6 RID: 39846 RVA: 0x001E57FC File Offset: 0x001E3BFC
	protected override ComNewbieGuideBase.GuideState _init()
	{
		BeScene main = BattleMain.instance.Main;
		if (main != null)
		{
			BeRegion beRegion = main.AddRegion(new DRegionInfo
			{
				resid = 1,
				position = new Vector3(-12.924f, 0f, 6.66f)
			}, null);
			beRegion.triggerRegion = delegate(ISceneRegionInfoData info, BeRegionTarget target)
			{
				this.mGuideControl.ControlComplete();
				return true;
			};
		}
		else
		{
			Logger.LogError("main is nil");
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
