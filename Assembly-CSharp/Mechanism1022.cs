using System;

// Token: 0x0200425E RID: 16990
public class Mechanism1022 : BeMechanism
{
	// Token: 0x06017823 RID: 96291 RVA: 0x0073B8B9 File Offset: 0x00739CB9
	public Mechanism1022(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017824 RID: 96292 RVA: 0x0073B8C4 File Offset: 0x00739CC4
	public override void OnInit()
	{
		base.OnInit();
		this.skillArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.skillArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.skillCDArray = new int[this.data.ValueB.Length];
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.skillCDArray[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
	}

	// Token: 0x06017825 RID: 96293 RVA: 0x0073B9A4 File Offset: 0x00739DA4
	public override void OnStart()
	{
		base.OnStart();
		this.tmpSkillCDArray = new int[this.skillArray.Length];
		for (int i = 0; i < this.skillArray.Length; i++)
		{
			BeSkill skill = base.owner.GetSkill(this.skillArray[i]);
			if (skill != null)
			{
				this.tmpSkillCDArray[i] = skill.tableCD;
				skill.tableCD = this.skillCDArray[i];
			}
		}
	}

	// Token: 0x06017826 RID: 96294 RVA: 0x0073BA28 File Offset: 0x00739E28
	private void ResetSkillCD()
	{
		for (int i = 0; i < this.skillArray.Length; i++)
		{
			BeSkill skill = base.owner.GetSkill(this.skillArray[i]);
			if (skill != null)
			{
				skill.tableCD = this.tmpSkillCDArray[i];
			}
		}
	}

	// Token: 0x06017827 RID: 96295 RVA: 0x0073BA80 File Offset: 0x00739E80
	public override void OnFinish()
	{
		base.OnFinish();
		this.ResetSkillCD();
	}

	// Token: 0x06017828 RID: 96296 RVA: 0x0073BA8E File Offset: 0x00739E8E
	public override void OnDead()
	{
		base.OnDead();
		this.ResetSkillCD();
	}

	// Token: 0x04010E52 RID: 69202
	private int[] skillArray;

	// Token: 0x04010E53 RID: 69203
	private int[] skillCDArray;

	// Token: 0x04010E54 RID: 69204
	private int[] tmpSkillCDArray;
}
