using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004359 RID: 17241
public class Mechanism2034 : BeMechanism
{
	// Token: 0x06017DF3 RID: 97779 RVA: 0x007618FC File Offset: 0x0075FCFC
	public Mechanism2034(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DF4 RID: 97780 RVA: 0x00761908 File Offset: 0x0075FD08
	public override void OnInit()
	{
		base.OnInit();
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.delayTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017DF5 RID: 97781 RVA: 0x00761993 File Offset: 0x0075FD93
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.GetFilterTarget(list, new BeMechanismFilter(base.GetMechanismIndex()), true);
			if (list.Count <= 0)
			{
				List<BeEntity> saveTempList = base.owner.CurrentBeScene.GetSaveTempList();
				for (int i = 0; i < saveTempList.Count; i++)
				{
					BeActor beActor = saveTempList[i] as BeActor;
					if (beActor != null)
					{
						Mechanism2032 mechanism = beActor.GetMechanismByIndex(2032) as Mechanism2032;
						if (mechanism != null)
						{
							mechanism.EndAirBattle(this.delayTime);
						}
					}
				}
				BeActor beActor2 = base.owner.CurrentBeScene.FindMonsterByID(this.monsterID);
				if (beActor2 != null)
				{
					beActor2.buffController.TryAddBuff(this.buffID, -1, 1);
				}
			}
			ListPool<BeActor>.Release(list);
		});
	}

	// Token: 0x06017DF6 RID: 97782 RVA: 0x007619BA File Offset: 0x0075FDBA
	public override void OnDead()
	{
		base.OnDead();
	}

	// Token: 0x06017DF7 RID: 97783 RVA: 0x007619C2 File Offset: 0x0075FDC2
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x040112E4 RID: 70372
	private int delayTime;

	// Token: 0x040112E5 RID: 70373
	private int monsterID;

	// Token: 0x040112E6 RID: 70374
	private int buffID;
}
