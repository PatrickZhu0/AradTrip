using System;
using GameClient;

// Token: 0x02004229 RID: 16937
public class Buff521211 : BeBuff
{
	// Token: 0x0601772A RID: 96042 RVA: 0x0073458E File Offset: 0x0073298E
	public Buff521211(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x0601772B RID: 96043 RVA: 0x007345B4 File Offset: 0x007329B4
	public override void OnInit()
	{
		this.m_DoHurtToOwner = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
		this.m_HurtTime = TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true);
	}

	// Token: 0x0601772C RID: 96044 RVA: 0x00734616 File Offset: 0x00732A16
	public override void OnStart()
	{
		this.DoFunction();
	}

	// Token: 0x0601772D RID: 96045 RVA: 0x00734620 File Offset: 0x00732A20
	protected void DoFunction()
	{
		base.owner.SetTag(1, true);
		base.owner.SetTag(8, true);
		base.owner.moveZSpeed = 1;
		base.owner.buffController.TryAddBuff(2, null, false, null, 0);
		base.owner.delayCaller.DelayCall(this.m_HurtTime, delegate
		{
			if (base.owner.buffController.HasBuffByID(2) != null)
			{
				base.owner.buffController.RemoveBuff(2, 0, 0);
			}
			base.owner.moveZSpeed = 0;
			int maxHP = base.owner.GetEntityData().GetMaxHP();
			base.owner.DoHurt(maxHP * this.m_DoHurtToOwner.factor, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
			VInt3 birthPosition = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().GetBirthPosition();
			base.owner.SetTag(1, false);
			base.owner.SetTag(8, false);
			base.owner.SetPosition(birthPosition, false, true, false);
			base.owner.buffController.TryAddBuff(2, 1000, 1);
		}, 0, 0, false);
	}

	// Token: 0x04010D5A RID: 68954
	protected VRate m_DoHurtToOwner = VRate.half;

	// Token: 0x04010D5B RID: 68955
	protected int m_HurtTime = 1000;
}
