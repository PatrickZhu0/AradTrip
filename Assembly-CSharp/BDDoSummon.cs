using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004104 RID: 16644
public class BDDoSummon : BDEventBase
{
	// Token: 0x06016A77 RID: 92791 RVA: 0x006DDDB4 File Offset: 0x006DC1B4
	public BDDoSummon(int sumID, int sumLv, bool growBySkill, int sumNum, int posType, List<int> posType2, bool isSameFace, int numLimit)
	{
		this.summonID = sumID;
		this.summonLevel = sumLv;
		this.levelGrowBySkill = growBySkill;
		this.summonNum = sumNum;
		this.posType = (EffectTable.eSummonPosType)posType;
		this.posType2 = posType2;
		this.isSameFace = isSameFace;
		this._numLimit = numLimit;
	}

	// Token: 0x06016A78 RID: 92792 RVA: 0x006DDE04 File Offset: 0x006DC204
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = pkEntity as BeActor;
		if (beActor != null && this.summonID != 0 && this.summonNum != 0)
		{
			int level = this.summonLevel;
			BeSkill curSkill = beActor.GetCurSkill();
			if (curSkill != null && this.levelGrowBySkill)
			{
				level = curSkill.level;
			}
			beActor.DoSummon(this.summonID, level, this.posType, this.posType2, this.summonNum, this._numLimit, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, this.isSameFace);
		}
	}

	// Token: 0x0401026D RID: 66157
	private int summonID;

	// Token: 0x0401026E RID: 66158
	private int summonLevel;

	// Token: 0x0401026F RID: 66159
	private bool levelGrowBySkill;

	// Token: 0x04010270 RID: 66160
	private int summonNum;

	// Token: 0x04010271 RID: 66161
	private EffectTable.eSummonPosType posType;

	// Token: 0x04010272 RID: 66162
	private List<int> posType2;

	// Token: 0x04010273 RID: 66163
	private bool isSameFace;

	// Token: 0x04010274 RID: 66164
	private int _numLimit;
}
