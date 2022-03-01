using System;
using System.Collections.Generic;

// Token: 0x020043F4 RID: 17396
public class Mechanism53 : BeMechanism
{
	// Token: 0x06018250 RID: 98896 RVA: 0x0078289F File Offset: 0x00780C9F
	public Mechanism53(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018251 RID: 98897 RVA: 0x007828B4 File Offset: 0x00780CB4
	public override void OnInit()
	{
		this.m_SkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				this.resIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
	}

	// Token: 0x06018252 RID: 98898 RVA: 0x0078294D File Offset: 0x00780D4D
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.RemoveHandle();
			this.m_AfterGenBulletHandler = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
			{
				BeSkill skill = base.owner.GetSkill(this.m_SkillId);
				if (skill != null)
				{
					BeProjectile beProjectile = args[0] as BeProjectile;
					if (beProjectile != null && this.resIdList.Contains(beProjectile.m_iResID))
					{
						skill.SetInnerState(BeSkill.InnerState.LAUNCH);
						VInt3 position = beProjectile.GetPosition();
						VInt3 effectPos = skill.GetEffectPos();
						if (base.owner.GetFace())
						{
							position.x = effectPos.x;
						}
						else
						{
							position.x = effectPos.x;
						}
						position.y = effectPos.y;
						beProjectile.SetPosition(position, false, true);
						beProjectile.SetFace(base.owner.GetFace(), true, false);
					}
				}
			});
		}
	}

	// Token: 0x06018253 RID: 98899 RVA: 0x0078297F File Offset: 0x00780D7F
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x06018254 RID: 98900 RVA: 0x00782987 File Offset: 0x00780D87
	protected void RemoveHandle()
	{
		if (this.m_AfterGenBulletHandler != null)
		{
			this.m_AfterGenBulletHandler.Remove();
			this.m_AfterGenBulletHandler = null;
		}
	}

	// Token: 0x040116AE RID: 71342
	protected int m_SkillId;

	// Token: 0x040116AF RID: 71343
	protected List<int> resIdList = new List<int>();

	// Token: 0x040116B0 RID: 71344
	protected BeEventHandle m_AfterGenBulletHandler;
}
