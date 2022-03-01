using System;

// Token: 0x0200445B RID: 17499
public class Skill1605 : BeSkill
{
	// Token: 0x06018502 RID: 99586 RVA: 0x00792389 File Offset: 0x00790789
	public Skill1605(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018503 RID: 99587 RVA: 0x007923C5 File Offset: 0x007907C5
	public override void OnStart()
	{
		this.RegisterEvent();
	}

	// Token: 0x06018504 RID: 99588 RVA: 0x007923CD File Offset: 0x007907CD
	protected void RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this.OnAfterGenBullet));
	}

	// Token: 0x06018505 RID: 99589 RVA: 0x007923F0 File Offset: 0x007907F0
	protected void OnAfterGenBullet(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		if (Array.IndexOf<int>(this.m_ResIdArr, beProjectile.m_iResID) < 0)
		{
			return;
		}
		VInt3 position = base.owner.GetPosition();
		position.x += ((!base.owner.GetFace()) ? this.m_Offset.x : (-this.m_Offset.x));
		position.z += this.m_Offset.z;
		beProjectile.SetPosition(position, false, true);
	}

	// Token: 0x040118B3 RID: 71859
	protected int[] m_ResIdArr = new int[]
	{
		60259,
		60203
	};

	// Token: 0x040118B4 RID: 71860
	protected VInt3 m_Offset = new VInt3(15500, 0, 10000);
}
