using System;

// Token: 0x02004260 RID: 16992
public class Mechanism1024 : BeMechanism
{
	// Token: 0x0601782F RID: 96303 RVA: 0x0073BCA2 File Offset: 0x0073A0A2
	public Mechanism1024(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017830 RID: 96304 RVA: 0x0073BCB8 File Offset: 0x0073A0B8
	public override void OnInit()
	{
		base.OnInit();
		this.monsterNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017831 RID: 96305 RVA: 0x0073BD1B File Offset: 0x0073A11B
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateBuffInfo(deltaTime);
	}

	// Token: 0x06017832 RID: 96306 RVA: 0x0073BD2C File Offset: 0x0073A12C
	private void UpdateBuffInfo(int deltaTime)
	{
		if (!this.CheckCD(deltaTime))
		{
			return;
		}
		if (base.owner.CurrentBeScene.GetMonsterCount() <= this.monsterNum)
		{
			base.owner.buffController.TryAddBuff(this.buffID, -1, this.level);
		}
		if (base.owner.CurrentBeScene.GetMonsterCount() > this.monsterNum)
		{
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
	}

	// Token: 0x06017833 RID: 96307 RVA: 0x0073BDB7 File Offset: 0x0073A1B7
	private bool CheckCD(int deltaTime)
	{
		if (this.curTimeAcc < this.timeAcc)
		{
			this.curTimeAcc += deltaTime;
			return false;
		}
		this.curTimeAcc = 0;
		return true;
	}

	// Token: 0x04010E57 RID: 69207
	private int monsterNum;

	// Token: 0x04010E58 RID: 69208
	private int buffID;

	// Token: 0x04010E59 RID: 69209
	private int curTimeAcc;

	// Token: 0x04010E5A RID: 69210
	private int timeAcc = 1000;
}
