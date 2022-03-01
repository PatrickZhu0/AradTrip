using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02004348 RID: 17224
public class Mechanism2018 : BeMechanism
{
	// Token: 0x06017D89 RID: 97673 RVA: 0x0075E7BF File Offset: 0x0075CBBF
	public Mechanism2018(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D8A RID: 97674 RVA: 0x0075E7EC File Offset: 0x0075CBEC
	public override void OnInit()
	{
		base.OnInit();
		this.boxXY[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.boxXY[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true), GlobalLogic.VALUE_1000);
		this.xSpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int i = 0; i < this.data.ValueD.Count; i++)
		{
			this.monsterTypeList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true));
		}
	}

	// Token: 0x06017D8B RID: 97675 RVA: 0x0075E8F9 File Offset: 0x0075CCF9
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.CheckTarget(deltaTime);
	}

	// Token: 0x06017D8C RID: 97676 RVA: 0x0075E90C File Offset: 0x0075CD0C
	private void CheckTarget(int deltaTime)
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindFaceTargetsX(list, base.owner, this.boxXY[0]);
		for (int i = 0; i < list.Count; i++)
		{
			if (Mathf.Abs(list[i].GetPosition().y - base.owner.GetPosition().y) <= this.boxXY[1])
			{
				this.ChangeEnemySpeed(list[i]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017D8D RID: 97677 RVA: 0x0075E9DC File Offset: 0x0075CDDC
	private void ChangeEnemySpeed(BeActor actor)
	{
		if (actor == null || actor.IsDead())
		{
			return;
		}
		if (actor.IsMonster() && !this.monsterTypeList.Contains(actor.GetEntityData().type))
		{
			return;
		}
		if (actor.stateController == null)
		{
			return;
		}
		if (actor.stateController != null && (!actor.stateController.CanMove() || !actor.stateController.CanMoveX()))
		{
			return;
		}
		if (actor.stateController.CanNotAbsorbByBlockHole())
		{
			return;
		}
		if (actor.moveXSpeed.i * base.owner.moveXSpeed.i > 0)
		{
			return;
		}
		actor.ClearMoveSpeed(1);
		actor.extraSpeed.x = ((!base.owner.GetFace()) ? this.xSpeed : (-this.xSpeed)).i;
	}

	// Token: 0x0401128D RID: 70285
	protected VInt[] boxXY = new VInt[2];

	// Token: 0x0401128E RID: 70286
	private VInt xSpeed = 0;

	// Token: 0x0401128F RID: 70287
	private List<int> monsterTypeList = new List<int>();
}
