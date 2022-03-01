using System;
using GameClient;

// Token: 0x02004438 RID: 17464
public class Skill1910 : Skill1107
{
	// Token: 0x06018403 RID: 99331 RVA: 0x0078D21D File Offset: 0x0078B61D
	public Skill1910(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018404 RID: 99332 RVA: 0x0078D228 File Offset: 0x0078B628
	public override void OnPostInit()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.ConfigCommand, delegate(object[] args)
		{
			if (this.skillData.ValueA.Count > 1)
			{
				int num = base.owner.backHitConfig ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true) : TableManager.GetValueFromUnionCell((!base.isPVP()) ? this.skillData.ValueA[1] : this.skillData.ValueA[0], base.level, true);
				if (num > 0 && base.owner != null)
				{
					base.owner.buffController.RemoveTriggerBuff(num);
					BuffInfoData buffInfo = new BuffInfoData(num, base.level, 0);
					base.owner.buffController.AddTriggerBuff(buffInfo);
				}
			}
		});
		this.range = VInt.Float2VIntValue((float)TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true) / 1000f);
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onBackHit, delegate(object[] args)
		{
			BeEntity beEntity = args[0] as BeEntity;
			if (beEntity != null)
			{
				if (beEntity is BeProjectile)
				{
					this.actor = beEntity.GetOwner();
				}
				else
				{
					this.actor = beEntity;
				}
			}
		});
	}

	// Token: 0x06018405 RID: 99333 RVA: 0x0078D2B0 File Offset: 0x0078B6B0
	public override bool CanUseSkill()
	{
		bool flag = true;
		if (base.owner.backHitConfig)
		{
			flag = (base.owner.GetCurrentBtnState() == ButtonState.PRESS);
		}
		base.owner.CurrentBeScene.FindActorInRange(this.actorList, base.owner.GetPosition(), this.range, (base.owner.GetCamp() != 0) ? 0 : 1, 0);
		bool flag2 = base.canUseSkill();
		return flag2 && base.owner.sgGetCurrentState() == 4 && base.owner.GetPosition().z <= 0 && this.actorList.Count > 0 && !base.owner.IsDead() && flag;
	}

	// Token: 0x06018406 RID: 99334 RVA: 0x0078D37A File Offset: 0x0078B77A
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x06018407 RID: 99335 RVA: 0x0078D39C File Offset: 0x0078B79C
	public override void OnStart()
	{
		base.OnStart();
		if (this.actor != null)
		{
			base.owner.SetFace(base.owner.GetPosition().x > this.actor.GetPosition().x, true, false);
		}
	}

	// Token: 0x04011803 RID: 71683
	private BeEntity actor;

	// Token: 0x04011804 RID: 71684
	private BeEventHandle handle;
}
