using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004338 RID: 17208
public class Mechanism2003 : BeMechanism
{
	// Token: 0x06017CF0 RID: 97520 RVA: 0x0075A736 File Offset: 0x00758B36
	public Mechanism2003(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CF1 RID: 97521 RVA: 0x0075A74C File Offset: 0x00758B4C
	public override void OnInit()
	{
		base.OnInit();
		this.type = (Mechanism2003.ResentmentType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.resentmentValue = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.stopUpdateResentment = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 1);
	}

	// Token: 0x06017CF2 RID: 97522 RVA: 0x0075A7DA File Offset: 0x00758BDA
	public override void OnStart()
	{
		base.OnStart();
		this._init();
	}

	// Token: 0x06017CF3 RID: 97523 RVA: 0x0075A7E8 File Offset: 0x00758BE8
	private void _init()
	{
		switch (this.type)
		{
		case Mechanism2003.ResentmentType.ATTACK_TARGET:
			this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.isMainActor)
				{
					this.ChangeActorResentment(beActor);
				}
			});
			break;
		case Mechanism2003.ResentmentType.RESENTMENT_HIGH:
			this.ChangeActorResentment(this.GetResentmentActor(true));
			break;
		case Mechanism2003.ResentmentType.RESENTMENT_LOW:
			this.ChangeActorResentment(this.GetResentmentActor(false));
			break;
		case Mechanism2003.ResentmentType.RANDOM:
			this.ChangePlayerResentment(true);
			break;
		case Mechanism2003.ResentmentType.ALL:
			this.ChangePlayerResentment(false);
			break;
		case Mechanism2003.ResentmentType.SELF:
			this.ChangeActorResentment(base.owner);
			break;
		}
	}

	// Token: 0x06017CF4 RID: 97524 RVA: 0x0075A898 File Offset: 0x00758C98
	private void ChangePlayerResentment(bool random = true)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMainActor(list);
		if (random)
		{
			int index = base.owner.FrameRandom.InRange(0, list.Count - 1);
			this.ChangeActorResentment(list[index]);
		}
		else
		{
			for (int i = 0; i < list.Count; i++)
			{
				this.ChangeActorResentment(list[i]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017CF5 RID: 97525 RVA: 0x0075A91C File Offset: 0x00758D1C
	private void ChangeActorResentment(BeActor actor)
	{
		if (actor != null)
		{
			Mechanism2004 mechanism = actor.GetMechanism(this.mechanismID) as Mechanism2004;
			if (mechanism != null)
			{
				if (this.resentmentValue <= 0 || !mechanism.IsBetray())
				{
					mechanism.OnChangeResentmentValue(this.resentmentValue);
				}
				if (this.stopUpdateResentment)
				{
					mechanism.SetUpdateFlag(false);
				}
				else
				{
					mechanism.SetUpdateFlag(true);
				}
			}
		}
	}

	// Token: 0x06017CF6 RID: 97526 RVA: 0x0075A98D File Offset: 0x00758D8D
	private BeActor GetResentmentActor(bool high = true)
	{
		return base.owner.CurrentBeScene.GetResentmentActor(high);
	}

	// Token: 0x04011213 RID: 70163
	private Mechanism2003.ResentmentType type;

	// Token: 0x04011214 RID: 70164
	private int resentmentValue;

	// Token: 0x04011215 RID: 70165
	private int mechanismID = 5300;

	// Token: 0x04011216 RID: 70166
	private bool stopUpdateResentment;

	// Token: 0x02004339 RID: 17209
	public enum ResentmentType
	{
		// Token: 0x04011218 RID: 70168
		ATTACK_TARGET,
		// Token: 0x04011219 RID: 70169
		RESENTMENT_HIGH,
		// Token: 0x0401121A RID: 70170
		RESENTMENT_LOW,
		// Token: 0x0401121B RID: 70171
		RANDOM,
		// Token: 0x0401121C RID: 70172
		ALL,
		// Token: 0x0401121D RID: 70173
		SELF
	}
}
