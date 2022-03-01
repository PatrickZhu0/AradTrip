using System;
using System.Collections.Generic;

// Token: 0x0200426D RID: 17005
public class Mechanism1036 : BeMechanism
{
	// Token: 0x06017889 RID: 96393 RVA: 0x0073DA87 File Offset: 0x0073BE87
	public Mechanism1036(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601788A RID: 96394 RVA: 0x0073DAB4 File Offset: 0x0073BEB4
	public override void OnInit()
	{
		this.xAddSpeedArr[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.xAddSpeedArr[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true), GlobalLogic.VALUE_1000);
		this.xSkillAddSpeedArr[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.xSkillAddSpeedArr[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
		this.useSkillId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x0601788B RID: 96395 RVA: 0x0073DC2C File Offset: 0x0073C02C
	public override void OnStart()
	{
		base.OnStart();
		if (this.skillIdList.Count > 0)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.OnSkillStart));
			this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnSkillFinish));
			this.handleC = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.OnSkillFinish));
		}
	}

	// Token: 0x0601788C RID: 96396 RVA: 0x0073DCAD File Offset: 0x0073C0AD
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateChangeXSpeed();
	}

	// Token: 0x0601788D RID: 96397 RVA: 0x0073DCBC File Offset: 0x0073C0BC
	private void OnSkillStart(object[] args)
	{
		if (!this.skillIdList.Contains((int)args[0]))
		{
			return;
		}
		this.useSkillFlag = true;
	}

	// Token: 0x0601788E RID: 96398 RVA: 0x0073DCDE File Offset: 0x0073C0DE
	private void OnSkillFinish(object[] args)
	{
		if (!this.skillIdList.Contains((int)args[0]))
		{
			return;
		}
		this.useSkillFlag = false;
	}

	// Token: 0x0601788F RID: 96399 RVA: 0x0073DD00 File Offset: 0x0073C100
	private void UpdateChangeXSpeed()
	{
		VInt[] array = (!this.useSkillFlag) ? this.xAddSpeedArr : this.xSkillAddSpeedArr;
		Mechanism1036.WindDir levelWindDir = this.GetLevelWindDir();
		int x = 0;
		if (levelWindDir != Mechanism1036.WindDir.NONE)
		{
			if (levelWindDir != Mechanism1036.WindDir.LEFT)
			{
				if (levelWindDir == Mechanism1036.WindDir.RIGHT)
				{
					x = ((!base.owner.GetFace()) ? array[0].i : array[1].i);
				}
			}
			else
			{
				x = ((!base.owner.GetFace()) ? (-array[1].i) : (-array[0].i));
			}
		}
		else
		{
			x = 0;
		}
		base.owner.extraSpeed.x = x;
		this.UseSkill(levelWindDir);
	}

	// Token: 0x06017890 RID: 96400 RVA: 0x0073DDD4 File Offset: 0x0073C1D4
	private void UseSkill(Mechanism1036.WindDir windDir)
	{
		if (this.useSkillId == 0)
		{
			return;
		}
		if (windDir == Mechanism1036.WindDir.NONE)
		{
			return;
		}
		if (!base.owner.CanUseSkill(this.useSkillId))
		{
			return;
		}
		if (windDir == Mechanism1036.WindDir.LEFT)
		{
			base.owner.SetFace(true, false, false);
		}
		else if (windDir == Mechanism1036.WindDir.RIGHT)
		{
			base.owner.SetFace(false, false, false);
		}
		if (!base.owner.IsDead())
		{
			base.owner.UseSkill(this.useSkillId, false);
		}
	}

	// Token: 0x06017891 RID: 96401 RVA: 0x0073DE60 File Offset: 0x0073C260
	private Mechanism1036.WindDir GetLevelWindDir()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return Mechanism1036.WindDir.NONE;
		}
		if (base.owner.CurrentBeBattle.LevelMgr == null)
		{
			return Mechanism1036.WindDir.NONE;
		}
		return (Mechanism1036.WindDir)base.owner.CurrentBeBattle.LevelMgr.GetCounter(1);
	}

	// Token: 0x04010E90 RID: 69264
	private VInt[] xAddSpeedArr = new VInt[2];

	// Token: 0x04010E91 RID: 69265
	private VInt[] xSkillAddSpeedArr = new VInt[2];

	// Token: 0x04010E92 RID: 69266
	private List<int> skillIdList = new List<int>();

	// Token: 0x04010E93 RID: 69267
	private int useSkillId;

	// Token: 0x04010E94 RID: 69268
	private bool useSkillFlag;

	// Token: 0x0200426E RID: 17006
	public enum WindDir
	{
		// Token: 0x04010E96 RID: 69270
		NONE = -1,
		// Token: 0x04010E97 RID: 69271
		LEFT,
		// Token: 0x04010E98 RID: 69272
		RIGHT
	}
}
