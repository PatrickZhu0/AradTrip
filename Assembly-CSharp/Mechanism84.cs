using System;

// Token: 0x02004416 RID: 17430
public class Mechanism84 : BeMechanism
{
	// Token: 0x0601834E RID: 99150 RVA: 0x00789432 File Offset: 0x00787832
	public Mechanism84(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601834F RID: 99151 RVA: 0x0078943C File Offset: 0x0078783C
	public override void OnInit()
	{
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.duration = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.offsetX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
		this.offsetZ = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true), GlobalLogic.VALUE_1000);
		this.moveSpeedZ = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018350 RID: 99152 RVA: 0x0078952F File Offset: 0x0078792F
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this._createBullet();
	}

	// Token: 0x06018351 RID: 99153 RVA: 0x00789544 File Offset: 0x00787944
	private void _createBullet()
	{
		BeActor aiTarget = base.owner.aiManager.aiTarget;
		if (aiTarget != null)
		{
			BeProjectile beProjectile = base.owner.AddEntity(this.entityId, VInt3.zero, 1, 0) as BeProjectile;
			if (beProjectile != null)
			{
				beProjectile.SetFace(base.owner.GetFace(), false, false);
				VInt3 vint = this._getBirthPos();
				beProjectile.SetPosition(vint, false, true);
				VInt3 vint2 = aiTarget.GetPosition() - vint;
				beProjectile.SetMoveSpeedX(vint2.x * 1000 / this.duration);
				beProjectile.SetMoveSpeedY(vint2.y * 1000 / this.duration);
				beProjectile.SetMoveSpeedZ(this.moveSpeedZ.i);
				int i = 2 * (this.moveSpeedZ.i * this.duration / 1000 + this.offsetZ.i) * 1000 / this.duration * 1000 / this.duration;
				beProjectile.SetMoveSpeedZAcc(i);
				if (aiTarget.m_pkGeActor != null)
				{
					aiTarget.m_pkGeActor.CreateEffect("Effects/Hero_Zhaohuanshi/Luyisi/Prefab/Eff_Zhaohuanluyisi_jiaodi", null, (float)this.duration / 1000f, aiTarget.GetPosition().vec3, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
				}
			}
		}
	}

	// Token: 0x06018352 RID: 99154 RVA: 0x007896A8 File Offset: 0x00787AA8
	private VInt3 _getBirthPos()
	{
		int x = base.owner.GetPosition().x + ((!base.owner.GetFace()) ? this.offsetX.i : (-this.offsetX.i));
		int y = base.owner.GetPosition().y;
		int z = base.owner.GetPosition().z + this.offsetZ.i;
		VInt3 result = new VInt3(x, y, z);
		return result;
	}

	// Token: 0x04011789 RID: 71561
	private const string effectPath = "Effects/Hero_Zhaohuanshi/Luyisi/Prefab/Eff_Zhaohuanluyisi_jiaodi";

	// Token: 0x0401178A RID: 71562
	private int entityId;

	// Token: 0x0401178B RID: 71563
	private new int duration;

	// Token: 0x0401178C RID: 71564
	private VInt offsetX;

	// Token: 0x0401178D RID: 71565
	private VInt offsetZ;

	// Token: 0x0401178E RID: 71566
	private VInt moveSpeedZ;
}
