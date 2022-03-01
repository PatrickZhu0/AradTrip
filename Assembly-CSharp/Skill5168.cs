using System;
using ProtoTable;

// Token: 0x020044DA RID: 17626
public class Skill5168 : BeSkill
{
	// Token: 0x0601888B RID: 100491 RVA: 0x007A8AE8 File Offset: 0x007A6EE8
	public Skill5168(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601888C RID: 100492 RVA: 0x007A8B08 File Offset: 0x007A6F08
	public override void OnInit()
	{
		if (this.skillData != null)
		{
			this.mDestructID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], 1, true);
			this.mDamageCount = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], 1, true);
		}
	}

	// Token: 0x0601888D RID: 100493 RVA: 0x007A8B5C File Offset: 0x007A6F5C
	public override void OnPostInit()
	{
	}

	// Token: 0x0601888E RID: 100494 RVA: 0x007A8B60 File Offset: 0x007A6F60
	public override void OnStart()
	{
		BeActor beActor = this._findTarget();
		if (beActor != null)
		{
			this._triggerEffect(beActor);
		}
	}

	// Token: 0x0601888F RID: 100495 RVA: 0x007A8B84 File Offset: 0x007A6F84
	private BeActor _findTarget()
	{
		return base.owner.CurrentBeScene.FindNearestFacedTarget(base.owner, new VInt2(10, 10));
	}

	// Token: 0x06018890 RID: 100496 RVA: 0x007A8BB4 File Offset: 0x007A6FB4
	private BeActor _createMonster(BeActor actor)
	{
		Skill5168.<_createMonster>c__AnonStorey0 <_createMonster>c__AnonStorey = new Skill5168.<_createMonster>c__AnonStorey0();
		<_createMonster>c__AnonStorey.actor = actor;
		<_createMonster>c__AnonStorey.$this = this;
		base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			if (args != null && args.Length >= 2)
			{
				BeActor summon = args[0] as BeActor;
				int num = (int)args[1];
				if (summon != null && <_createMonster>c__AnonStorey.$this.skillData.ID == num)
				{
					VInt3 pos = <_createMonster>c__AnonStorey.actor.GetPosition();
					pos.z = VInt.one.i * 5;
					summon.SetPosition(pos, false, true, false);
					summon.hasAI = false;
					summon.stateController.SetAbilityEnable(BeAbilityType.FLOAT, false);
					summon.stateController.SetAbilityEnable(BeAbilityType.BEGRAB, false);
					<_createMonster>c__AnonStorey.$this.mState = Skill5168.eState.Fall;
					<_createMonster>c__AnonStorey.$this.mHandle = summon.RegisterEvent(BeEventType.onHitOther, delegate(object[] hitOther)
					{
						if (<_createMonster>c__AnonStorey.mState == Skill5168.eState.Fall && hitOther != null && hitOther.Length >= 1)
						{
							BeActor beActor = hitOther[0] as BeActor;
							if (beActor == <_createMonster>c__AnonStorey.actor)
							{
								<_createMonster>c__AnonStorey.mState = Skill5168.eState.Traped;
								pos.z = 0;
								<_createMonster>c__AnonStorey.actor.SetPosition(pos, false, true, false);
								<_createMonster>c__AnonStorey._setBlockLayer(<_createMonster>c__AnonStorey.actor, true);
								if (<_createMonster>c__AnonStorey.mHandle != null)
								{
									<_createMonster>c__AnonStorey.mHandle.Remove();
								}
							}
						}
					});
					<_createMonster>c__AnonStorey.$this.mHandleTouchGround = summon.RegisterEvent(BeEventType.onTouchGround, delegate(object[] uarsg)
					{
						if (!summon.IsDead() && <_createMonster>c__AnonStorey.mState == Skill5168.eState.Fall)
						{
							<_createMonster>c__AnonStorey.mState = Skill5168.eState.Broken;
							summon.DoDead(false);
							<_createMonster>c__AnonStorey._setBlockLayer(<_createMonster>c__AnonStorey.actor, false);
							if (<_createMonster>c__AnonStorey.mHandleTouchGround == null)
							{
								<_createMonster>c__AnonStorey.mHandleTouchGround.Remove();
							}
						}
					});
					summon.RegisterEvent(BeEventType.onDead, delegate(object[] uarsg)
					{
						if (<_createMonster>c__AnonStorey.mState == Skill5168.eState.Traped)
						{
							<_createMonster>c__AnonStorey._setBlockLayer(<_createMonster>c__AnonStorey.actor, false);
							<_createMonster>c__AnonStorey._untriggerEffect(<_createMonster>c__AnonStorey.actor);
						}
					});
				}
			}
		});
		return null;
	}

	// Token: 0x06018891 RID: 100497 RVA: 0x007A8BF0 File Offset: 0x007A6FF0
	private void _triggerEffect(BeActor actor)
	{
		this._createMonster(actor);
	}

	// Token: 0x06018892 RID: 100498 RVA: 0x007A8BFC File Offset: 0x007A6FFC
	private void _untriggerEffect(BeActor actor)
	{
		EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(51681, string.Empty, string.Empty);
		if (tableItem != null)
		{
			BeBuff beBuff = actor.buffController.HasBuffByID(tableItem.BuffID);
			if (beBuff != null)
			{
				beBuff.Finish();
			}
		}
	}

	// Token: 0x06018893 RID: 100499 RVA: 0x007A8C48 File Offset: 0x007A7048
	private void _setBlockLayer(BeActor summon, bool block = true)
	{
		BeScene currentBeScene = base.owner.CurrentBeScene;
		if (currentBeScene == null)
		{
			return;
		}
		DGrid dgrid = currentBeScene.CalGridByPosition(summon.GetPosition());
		DGrid dgrid2 = new DGrid(3, 3);
		int x = dgrid.x;
		int y = dgrid.y;
		int num = x - dgrid2.x / 2;
		int num2 = y - dgrid2.y / 2;
		for (int i = num; i < num + dgrid2.x; i++)
		{
			for (int j = num2; j < num2 + dgrid2.y; j++)
			{
				currentBeScene.SetBlock(new DGrid(i, j), block);
			}
		}
	}

	// Token: 0x04011B29 RID: 72489
	protected int mDestructID = -1;

	// Token: 0x04011B2A RID: 72490
	protected int mDamageCount = 1;

	// Token: 0x04011B2B RID: 72491
	protected int mEffectID = -1;

	// Token: 0x04011B2C RID: 72492
	private const int cRange = 20;

	// Token: 0x04011B2D RID: 72493
	protected BeEventHandle mHandle;

	// Token: 0x04011B2E RID: 72494
	protected BeEventHandle mHandleTouchGround;

	// Token: 0x04011B2F RID: 72495
	private Skill5168.eState mState;

	// Token: 0x020044DB RID: 17627
	private enum eState
	{
		// Token: 0x04011B31 RID: 72497
		None,
		// Token: 0x04011B32 RID: 72498
		Fall,
		// Token: 0x04011B33 RID: 72499
		Traped,
		// Token: 0x04011B34 RID: 72500
		Broken
	}
}
