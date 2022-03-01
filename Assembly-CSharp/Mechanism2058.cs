using System;

// Token: 0x02004372 RID: 17266
public class Mechanism2058 : BeMechanism
{
	// Token: 0x06017EAE RID: 97966 RVA: 0x00767549 File Offset: 0x00765949
	public Mechanism2058(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017EAF RID: 97967 RVA: 0x0076756C File Offset: 0x0076596C
	public override void OnInit()
	{
		base.OnInit();
		this.scenePath = this.data.StringValueA[0];
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.reversTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.maxValue = (float)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000f;
	}

	// Token: 0x06017EB0 RID: 97968 RVA: 0x00767618 File Offset: 0x00765A18
	public override void OnStart()
	{
		base.owner.buffController.TryAddBuff(this.mechanismBuffID, -1, 1);
		base.owner.CurrentBeScene.DelayCaller.DelayCall(1000, delegate
		{
			if (base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null)
			{
				base.owner.CurrentBeScene.currentGeScene.LoadMagicScene(this.scenePath, this.time, this.reversTime, this.maxValue);
			}
		}, 0, 0, false);
	}

	// Token: 0x06017EB1 RID: 97969 RVA: 0x00767668 File Offset: 0x00765A68
	public override void OnFinish()
	{
		base.OnFinish();
		base.owner.CurrentBeScene.DelayCaller.DelayCall(this.reversTime, delegate
		{
			base.owner.buffController.RemoveBuff(this.mechanismBuffID, 0, 0);
			if (base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null)
			{
				base.owner.CurrentBeScene.currentGeScene.ReverseMaterialSpecialScene();
			}
		}, 0, 0, false);
	}

	// Token: 0x04011377 RID: 70519
	private string scenePath = string.Empty;

	// Token: 0x04011378 RID: 70520
	private int time;

	// Token: 0x04011379 RID: 70521
	private int reversTime;

	// Token: 0x0401137A RID: 70522
	private float maxValue;

	// Token: 0x0401137B RID: 70523
	private int mechanismBuffID = 521665;
}
