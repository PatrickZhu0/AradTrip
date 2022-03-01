using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200440F RID: 17423
public class Mechanism77 : BeMechanism
{
	// Token: 0x06018320 RID: 99104 RVA: 0x00788016 File Offset: 0x00786416
	public Mechanism77(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018321 RID: 99105 RVA: 0x00788020 File Offset: 0x00786420
	public override void OnInit()
	{
		this.effectPath = this.data.StringValueA[0];
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.pointCount = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.summonLimit = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.unitDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000).i;
	}

	// Token: 0x06018322 RID: 99106 RVA: 0x007880F8 File Offset: 0x007864F8
	public override void OnStart()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorById(list, this.monsterId);
		int num = IntMath.Min(this.pointCount, this.summonLimit - list.Count);
		if (num > 0)
		{
			VInt3[] points = this.GetPoints();
			object[] array = new object[num];
			for (int i = 0; i < num; i++)
			{
				if (base.owner.DoSummon(this.monsterId, this.level, EffectTable.eSummonPosType.ORIGIN, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, array, true) && array[0] != null)
				{
					BeActor beActor = (BeActor)array[0];
					beActor.SetPosition(points[i], false, true, false);
					Vec3 vec = points[i].vec3;
					base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 0f, vec, 1f, 1f, false, false);
				}
			}
		}
	}

	// Token: 0x06018323 RID: 99107 RVA: 0x00788200 File Offset: 0x00786600
	private VInt3[] GetPoints()
	{
		VInt3 position = base.owner.GetPosition();
		VInt3[] array = new VInt3[this.pointCount * 2 + 1];
		for (int i = 0; i < this.pointCount; i++)
		{
			array[i * 2] = position;
			VInt3[] array2 = array;
			int num = i * 2;
			array2[num].y = array2[num].y - (i + 1) * this.unitDis;
			array[i * 2 + 1] = position;
			VInt3[] array3 = array;
			int num2 = i * 2 + 1;
			array3[num2].y = array3[num2].y + (i + 1) * this.unitDis;
		}
		array[this.pointCount * 2] = position;
		VInt3[] array4 = new VInt3[this.pointCount];
		int j = 0;
		for (int k = 0; k < this.pointCount; k++)
		{
			for (int l = 0; l < array.Length; l++)
			{
				if (j >= this.pointCount)
				{
					break;
				}
				if (!base.owner.CurrentBeScene.IsInBlockPlayer(array[l]))
				{
					array4[j++] = array[l];
				}
			}
		}
		while (j < this.pointCount)
		{
			array4[j] = position;
			j++;
		}
		return array4;
	}

	// Token: 0x0401176B RID: 71531
	private string effectPath;

	// Token: 0x0401176C RID: 71532
	private int monsterId;

	// Token: 0x0401176D RID: 71533
	private int pointCount;

	// Token: 0x0401176E RID: 71534
	private int summonLimit;

	// Token: 0x0401176F RID: 71535
	private int unitDis;
}
