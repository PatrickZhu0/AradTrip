using System;

// Token: 0x0200443D RID: 17469
public class Skill1203 : BeSkill
{
	// Token: 0x0601842A RID: 99370 RVA: 0x0078DFFA File Offset: 0x0078C3FA
	public Skill1203(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601842B RID: 99371 RVA: 0x0078E004 File Offset: 0x0078C404
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner != null)
		{
			this.RemoveHandle();
			this.handler = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
			{
				base.SetInnerState(BeSkill.InnerState.LAUNCH);
				BeProjectile beProjectile = args[0] as BeProjectile;
				if (beProjectile != null && beProjectile.m_iResID == 60030)
				{
					VInt3 position = beProjectile.GetPosition();
					if (base.owner.GetFace())
					{
						position.x = this.effectPos.x + VInt.Float2VIntValue(2.26f);
					}
					else
					{
						position.x = this.effectPos.x - VInt.Float2VIntValue(2.26f);
					}
					position.y = this.effectPos.y;
					beProjectile.SetPosition(position, false, true);
					beProjectile.SetFace(base.owner.GetFace(), true, false);
					this.RemoveHandle();
				}
			});
		}
	}

	// Token: 0x0601842C RID: 99372 RVA: 0x0078E03C File Offset: 0x0078C43C
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601842D RID: 99373 RVA: 0x0078E044 File Offset: 0x0078C444
	public override void OnCancel()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601842E RID: 99374 RVA: 0x0078E04C File Offset: 0x0078C44C
	private void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04011823 RID: 71715
	private BeEventHandle handler;
}
