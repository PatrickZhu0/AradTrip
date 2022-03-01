using System;

// Token: 0x0200425B RID: 16987
internal class Mechanism102 : BeMechanism
{
	// Token: 0x06017811 RID: 96273 RVA: 0x0073B2F6 File Offset: 0x007396F6
	public Mechanism102(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017812 RID: 96274 RVA: 0x0073B310 File Offset: 0x00739710
	public override void OnInit()
	{
		this.darkFactor = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.delayHideTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.delayShowTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.flag = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.isAlpha = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) == 0);
	}

	// Token: 0x06017813 RID: 96275 RVA: 0x0073B3F4 File Offset: 0x007397F4
	private void _switchSceneEffect(bool flag)
	{
		if (this.flag == 1 && !base.owner.isLocalActor)
		{
			return;
		}
		if (flag)
		{
			this.blackSceneID = base.owner.CurrentBeScene.currentGeScene.BlendSceneSceneColor((float)this.darkFactor / 1000f + 0.005f, (float)this.delayHideTime / 1000f, this.isAlpha);
			if (this.darkFactor == 0)
			{
				this.handle = base.owner.delayCaller.DelayCall(this.delayHideTime, delegate
				{
					base.owner.CurrentBeScene.currentGeScene.GetSceneObject().CustomActive(false);
					base.owner.CurrentBeScene.currentGeScene.GetSceneActorRoot().CustomActive(false);
				}, 0, 0, false);
			}
		}
		else
		{
			base.owner.CurrentBeScene.currentGeScene.RecoverSceneColor((float)this.delayShowTime / 1000f, this.blackSceneID);
			if (this.darkFactor == 0)
			{
				base.owner.CurrentBeScene.currentGeScene.GetSceneObject().CustomActive(true);
				base.owner.CurrentBeScene.currentGeScene.GetSceneActorRoot().CustomActive(true);
			}
		}
	}

	// Token: 0x06017814 RID: 96276 RVA: 0x0073B509 File Offset: 0x00739909
	public override void OnStart()
	{
		this._switchSceneEffect(true);
	}

	// Token: 0x06017815 RID: 96277 RVA: 0x0073B512 File Offset: 0x00739912
	public override void OnFinish()
	{
		this._switchSceneEffect(false);
		if (this.handle.IsValid())
		{
			this.handle.SetRemove(true);
		}
	}

	// Token: 0x04010E47 RID: 69191
	private int darkFactor;

	// Token: 0x04010E48 RID: 69192
	private int delayHideTime;

	// Token: 0x04010E49 RID: 69193
	private int delayShowTime;

	// Token: 0x04010E4A RID: 69194
	private int flag;

	// Token: 0x04010E4B RID: 69195
	private int blackSceneID = -1;

	// Token: 0x04010E4C RID: 69196
	private bool isAlpha = true;

	// Token: 0x04010E4D RID: 69197
	private DelayCallUnitHandle handle;
}
