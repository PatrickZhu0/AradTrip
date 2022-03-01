using System;
using GameClient;
using UnityEngine;

// Token: 0x020010EB RID: 4331
public class BattlePvpFrame : ClientFrame
{
	// Token: 0x0600A436 RID: 42038 RVA: 0x0021C41A File Offset: 0x0021A81A
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/UIComponent/BattlePvpFrame";
	}

	// Token: 0x0600A437 RID: 42039 RVA: 0x0021C424 File Offset: 0x0021A824
	protected override void _bindExUI()
	{
		this.mPkResultRoot = this.mBind.GetGameObject("PkResultRoot");
		this.mObjWin = this.mBind.GetGameObject("objWin");
		this.mObjLost = this.mBind.GetGameObject("objLost");
		this.mObjDual = this.mBind.GetGameObject("objDual");
		this.mObjError = this.mBind.GetGameObject("objError");
	}

	// Token: 0x0600A438 RID: 42040 RVA: 0x0021C49F File Offset: 0x0021A89F
	protected override void _unbindExUI()
	{
		this.mPkResultRoot = null;
		this.mObjWin = null;
		this.mObjLost = null;
		this.mObjDual = null;
		this.mObjError = null;
	}

	// Token: 0x0600A439 RID: 42041 RVA: 0x0021C4C4 File Offset: 0x0021A8C4
	public void ShowPkResult(PKResult result)
	{
		if (this.mPkResultRoot == null)
		{
			return;
		}
		this.mPkResultRoot.CustomActive(true);
		this.mObjWin.CustomActive(false);
		this.mObjLost.CustomActive(false);
		this.mObjDual.CustomActive(false);
		if (result != PKResult.DRAW)
		{
			if (result != PKResult.LOSE)
			{
				if (result == PKResult.WIN)
				{
					this.mObjWin.CustomActive(true);
				}
			}
			else
			{
				this.mObjLost.CustomActive(true);
			}
		}
		else
		{
			this.mObjDual.CustomActive(true);
		}
	}

	// Token: 0x0600A43A RID: 42042 RVA: 0x0021C560 File Offset: 0x0021A960
	public void HiddenPkResult()
	{
		if (null == this.mPkResultRoot)
		{
			return;
		}
		this.mPkResultRoot.CustomActive(false);
	}

	// Token: 0x04005BD0 RID: 23504
	private GameObject mPkResultRoot;

	// Token: 0x04005BD1 RID: 23505
	private GameObject mObjWin;

	// Token: 0x04005BD2 RID: 23506
	private GameObject mObjLost;

	// Token: 0x04005BD3 RID: 23507
	private GameObject mObjDual;

	// Token: 0x04005BD4 RID: 23508
	private GameObject mObjError;
}
