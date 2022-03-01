using System;
using ProtoTable;

// Token: 0x02004479 RID: 17529
public class Skill2007 : BeSkill
{
	// Token: 0x06018600 RID: 99840 RVA: 0x007985C5 File Offset: 0x007969C5
	public Skill2007(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018601 RID: 99841 RVA: 0x007985D0 File Offset: 0x007969D0
	public override void OnStart()
	{
		if (BattleMain.IsModePvP(base.owner.battleType))
		{
			this.RemoveHandler();
			this.hitEffectHandle = base.owner.RegisterEvent(BeEventType.onHitEffect, delegate(object[] args)
			{
				bool[] array = (bool[])args[0];
				int num = (int)args[1];
				EffectTable effectTable = args[2] as EffectTable;
				BeEntity beEntity = args[3] as BeEntity;
				if (effectTable == null || beEntity == null)
				{
					return;
				}
				if ((num == 20070 || num == 20071) && (effectTable.HitDeadFall <= 0 || !beEntity.IsDead()) && (!beEntity.HasTag(1) || beEntity.HasTag(4)) && beEntity.GetPosition().z <= 0)
				{
					array[0] = true;
				}
			});
		}
	}

	// Token: 0x06018602 RID: 99842 RVA: 0x0079862B File Offset: 0x00796A2B
	private void RemoveHandler()
	{
		if (this.hitEffectHandle != null)
		{
			this.hitEffectHandle.Remove();
			this.hitEffectHandle = null;
		}
	}

	// Token: 0x04011983 RID: 72067
	private BeEventHandle hitEffectHandle;
}
