using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF1 RID: 4081
public class ComNewbieGuideETCJoystick : ComNewbieGuideBase
{
	// Token: 0x06009B9A RID: 39834 RVA: 0x001E51E9 File Offset: 0x001E35E9
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		this.mPosX = -1f;
		this.mTryPauseBattleAI = true;
		if (args != null && args.Length >= 1)
		{
			this.mPosX = (float)args[0];
		}
	}

	// Token: 0x06009B9B RID: 39835 RVA: 0x001E5224 File Offset: 0x001E3624
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
		GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.MiddleLayer, "ETCJoystick", true);
		if (gameObject == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		ETCJoystick com = gameObject.GetComponent<ETCJoystick>();
		if (com == null || !com.isActiveAndEnabled)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject root = base.AddDragTips(gameObject, delegate(Vector2 move)
		{
			com.onMove.Invoke(move);
		}, delegate
		{
			com.onTouchUp.Invoke();
		}, ComNewbieGuideBase.eNewbieGuideAnchor.Center);
		base.AddTextTips(root, ComNewbieGuideBase.eNewbieGuideAnchor.Top, "拖动摇杆进行移动", TextTipType.TextTipType_One, default(Vector3));
		BeScene main = BattleMain.instance.Main;
		if (main != null)
		{
			BeRegion beRegion = main.AddRegion(new DRegionInfo
			{
				resid = 13,
				regiontype = DRegionInfo.RegionType.Rectangle,
				rect = new Vector2(2f, 20f),
				position = new Vector3(this.mPosX, 0f, 6.66f)
			}, null);
			beRegion.active = false;
			beRegion.activeEffect = false;
			beRegion.active = true;
			beRegion.activeEffect = true;
			bool isTrigger = false;
			beRegion.triggerRegion = delegate(ISceneRegionInfoData info, BeRegionTarget target)
			{
				if (!isTrigger)
				{
					isTrigger = true;
					com.onTouchUp.Invoke();
					this.mGuideControl.ControlComplete();
				}
				return true;
			};
		}
		else
		{
			Logger.LogError("main is nil");
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x04005516 RID: 21782
	public float mPosX;
}
