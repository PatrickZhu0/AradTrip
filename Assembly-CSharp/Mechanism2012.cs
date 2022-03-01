using System;
using System.Collections.Generic;

// Token: 0x02004342 RID: 17218
public class Mechanism2012 : BeMechanism
{
	// Token: 0x06017D4F RID: 97615 RVA: 0x0075D160 File Offset: 0x0075B560
	public Mechanism2012(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D50 RID: 97616 RVA: 0x0075D1BA File Offset: 0x0075B5BA
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06017D51 RID: 97617 RVA: 0x0075D1C4 File Offset: 0x0075B5C4
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			BeActor beActor = args[2] as BeActor;
			if (beActor != null && beActor.isMainActor && beActor.isSpecialMonster)
			{
				for (int i = 0; i < this.buffList.Length; i++)
				{
					BeEntity owner = base.owner.GetOwner();
					if (owner != null)
					{
						BeActor beActor2 = owner as BeActor;
						if (beActor2 != null)
						{
							beActor2.buffController.RemoveBuff(this.buffList[i], 0, 0);
						}
					}
				}
				if (this.IsLastOneHaveBuff())
				{
					BeEntity owner2 = beActor.GetOwner();
					if (owner2 != null)
					{
						BeActor beActor3 = owner2 as BeActor;
						if (beActor3 != null)
						{
							for (int j = 0; j < this.buffArray.Length; j++)
							{
								beActor3.buffController.RemoveBuff(this.buffArray[j], 0, 0);
							}
						}
					}
				}
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor.GetEntityData().MonsterIDEqual(31140011))
			{
				beActor.AddMechanism(5361, this.level, MechanismSourceType.NONE, null, 0);
			}
		});
		this.handleC = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
		{
			int[] array = args[0] as int[];
			BeEntity beEntity = args[3] as BeEntity;
			if (beEntity != null)
			{
				BeActor beActor = beEntity as BeActor;
				if (beActor != null && beActor.isMainActor && beActor.isSpecialMonster)
				{
					array[0] = 0;
				}
			}
		});
	}

	// Token: 0x06017D52 RID: 97618 RVA: 0x0075D248 File Offset: 0x0075B648
	private bool IsLastOneHaveBuff()
	{
		int num = 0;
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			for (int j = 0; j < this.buffList.Length; j++)
			{
				if (this.HasBuff(allPlayers[i].playerActor, this.buffList[j]))
				{
					num++;
					break;
				}
			}
		}
		return num == 0;
	}

	// Token: 0x06017D53 RID: 97619 RVA: 0x0075D2D0 File Offset: 0x0075B6D0
	private bool HasBuff(BeActor entity, int buffID)
	{
		BeEntity owner = entity.GetOwner();
		if (owner != null)
		{
			BeActor beActor = owner as BeActor;
			if (beActor.buffController.HasBuffByID(buffID) != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017D54 RID: 97620 RVA: 0x0075D305 File Offset: 0x0075B705
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x0401126C RID: 70252
	private int[] buffList = new int[]
	{
		521828,
		521831,
		521830,
		521834
	};

	// Token: 0x0401126D RID: 70253
	private int[] buffArray = new int[]
	{
		521823,
		521824,
		521825
	};

	// Token: 0x0401126E RID: 70254
	private int[] monsterIDs = new int[]
	{
		30710011,
		30720011,
		30730011
	};
}
