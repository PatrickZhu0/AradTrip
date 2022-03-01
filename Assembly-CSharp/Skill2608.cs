using System;
using System.Collections.Generic;

// Token: 0x020044B0 RID: 17584
public class Skill2608 : BeSkill
{
	// Token: 0x0601874A RID: 100170 RVA: 0x007A1229 File Offset: 0x0079F629
	public Skill2608(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601874B RID: 100171 RVA: 0x007A124C File Offset: 0x0079F64C
	public override void OnInit()
	{
		this.bulletResIdList.Clear();
		for (int i = 0; i < this.skillData.ValueB.Count; i++)
		{
			this.bulletResIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true));
		}
		this.m_EffectOffset = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x0601874C RID: 100172 RVA: 0x007A12D0 File Offset: 0x0079F6D0
	public override void OnStart()
	{
		int num = this.m_EffectOffset * GlobalLogic.VALUE_10;
		this.effectOffset = ((!base.owner.GetFace()) ? num : (-num));
		this.RemoveHandle();
		if (base.owner != null)
		{
			this.handler = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
			{
				base.SetInnerState(BeSkill.InnerState.LAUNCH);
				BeProjectile beProjectile = args[0] as BeProjectile;
				if (beProjectile != null && this.bulletResIdList.Contains(beProjectile.m_iResID))
				{
					VInt3 position = beProjectile.GetPosition();
					if (base.owner.GetFace())
					{
						position.x = this.effectPos.x;
					}
					else
					{
						position.x = this.effectPos.x;
					}
					position.y = this.effectPos.y;
					beProjectile.SetPosition(position, false, true);
					beProjectile.SetFace(base.owner.GetFace(), true, false);
					this.RemoveHandle();
				}
			});
		}
	}

	// Token: 0x0601874D RID: 100173 RVA: 0x007A1338 File Offset: 0x0079F738
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601874E RID: 100174 RVA: 0x007A1340 File Offset: 0x0079F740
	public override void OnCancel()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601874F RID: 100175 RVA: 0x007A1348 File Offset: 0x0079F748
	private void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04011A44 RID: 72260
	private List<int> bulletResIdList = new List<int>();

	// Token: 0x04011A45 RID: 72261
	protected int m_EffectOffset = 2000;

	// Token: 0x04011A46 RID: 72262
	private BeEventHandle handler;
}
