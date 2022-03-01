using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044BC RID: 17596
public class Skill3112 : BeSkill
{
	// Token: 0x060187A9 RID: 100265 RVA: 0x007A42C6 File Offset: 0x007A26C6
	public Skill3112(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187AA RID: 100266 RVA: 0x007A42D0 File Offset: 0x007A26D0
	public override void OnInit()
	{
		base.OnInit();
		this.mIsActive = false;
		if (this.skillData.ValueA.Count > 0 && this.skillData.ValueB.Count > 0 && this.skillData.ValueC.Count > 0)
		{
			this.mIsActive = true;
			this.mMonsterID = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true));
			this.mBuffInfoID = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true));
			this.mAddBuffInfoID = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true));
			this.mHandleList = new List<BeEventHandle>();
		}
	}

	// Token: 0x060187AB RID: 100267 RVA: 0x007A4440 File Offset: 0x007A2840
	public override void OnStart()
	{
		base.OnStart();
		if (!this.mIsActive)
		{
			return;
		}
		this.pressMode = SkillPressMode.NORMAL;
		base.ResetButtonEffect();
		this.mTargetMonster = null;
		this.RemoveHandle();
		this.mHandleList.Add(base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.OnTargetMonsterSummon)));
	}

	// Token: 0x060187AC RID: 100268 RVA: 0x007A44A0 File Offset: 0x007A28A0
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.mTargetMonster == null || this.mTargetMonster.IsDead())
		{
			return;
		}
		base.owner.delayCaller.DelayCall(100, new DelayCaller.Del(this.SwitchState), 0, 0, false);
	}

	// Token: 0x060187AD RID: 100269 RVA: 0x007A44F4 File Offset: 0x007A28F4
	private void OnTargetMonsterSummon(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (!beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
		{
			return;
		}
		this.mTargetMonster = beActor;
		this.mHandleList.Add(this.mTargetMonster.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnMonsterDead)));
	}

	// Token: 0x060187AE RID: 100270 RVA: 0x007A454C File Offset: 0x007A294C
	private void OnMonsterDead(object[] args)
	{
		this.mTargetMonster = null;
		base.ResetButtonEffect();
	}

	// Token: 0x060187AF RID: 100271 RVA: 0x007A455C File Offset: 0x007A295C
	public override void OnClickAgain()
	{
		base.OnClickAgain();
		if (!this.mIsActive)
		{
			return;
		}
		base.ResetButtonEffect();
		if (this.mBuffInfoID <= 0 || this.mMonsterID <= 0)
		{
			return;
		}
		if (this.mTargetMonster == null)
		{
			return;
		}
		this.AddBuff();
		this.mTargetMonster.DoDead(false);
	}

	// Token: 0x060187B0 RID: 100272 RVA: 0x007A45B8 File Offset: 0x007A29B8
	private void AddBuff()
	{
		BuffInfoData buffInfoData = new BuffInfoData(this.mBuffInfoID, 0, 0);
		buffInfoData = this.mTargetMonster.buffController.GetTriggerBuff(buffInfoData);
		if (buffInfoData == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		list.Clear();
		BeUtility.GetAllFriendPlayers(base.owner, list);
		list.RemoveAll(delegate(BeActor player)
		{
			VInt3 position = player.GetPosition();
			VInt2 b = new VInt2(position.x, position.y);
			VInt3 position2 = this.mTargetMonster.GetPosition();
			VInt2 a = new VInt2(position2.x, position2.y);
			int magnitude = (a - b).magnitude;
			return !(magnitude < VInt.NewVInt((long)buffInfoData.buffRangeRadius, (long)GlobalLogic.VALUE_1000));
		});
		for (int i = 0; i < list.Count; i++)
		{
			list[i].buffController.TryAddBuffInfo(this.mAddBuffInfoID, base.owner, base.level);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060187B1 RID: 100273 RVA: 0x007A4679 File Offset: 0x007A2A79
	protected void SwitchState()
	{
		if (!this.mIsActive)
		{
			return;
		}
		if (this.mTargetMonster == null || this.mTargetMonster.IsDead())
		{
			return;
		}
		this.pressMode = SkillPressMode.TWO_PRESS_OUT;
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		base.ChangeButtonEffect();
	}

	// Token: 0x060187B2 RID: 100274 RVA: 0x007A46B8 File Offset: 0x007A2AB8
	protected void RemoveHandle()
	{
		if (this.mHandleList == null)
		{
			return;
		}
		for (int i = 0; i < this.mHandleList.Count; i++)
		{
			if (this.mHandleList[i] != null)
			{
				this.mHandleList[i].Remove();
				this.mHandleList[i] = null;
			}
		}
		this.mHandleList.Clear();
	}

	// Token: 0x04011A9D RID: 72349
	private int mBuffInfoID;

	// Token: 0x04011A9E RID: 72350
	private int mMonsterID;

	// Token: 0x04011A9F RID: 72351
	private int mAddBuffInfoID;

	// Token: 0x04011AA0 RID: 72352
	private bool mIsActive;

	// Token: 0x04011AA1 RID: 72353
	protected List<BeEventHandle> mHandleList;

	// Token: 0x04011AA2 RID: 72354
	private BeActor mTargetMonster;
}
