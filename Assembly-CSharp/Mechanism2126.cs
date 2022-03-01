using System;
using GameClient;
using UnityEngine;

// Token: 0x020043BB RID: 17339
public class Mechanism2126 : BeMechanism
{
	// Token: 0x060180C2 RID: 98498 RVA: 0x007778D1 File Offset: 0x00775CD1
	public Mechanism2126(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180C3 RID: 98499 RVA: 0x007778DC File Offset: 0x00775CDC
	public override void OnInit()
	{
		this.mBulletResID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.minX = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.maxX = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.minY = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.maxY = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
	}

	// Token: 0x060180C4 RID: 98500 RVA: 0x007779B1 File Offset: 0x00775DB1
	public override void OnStart()
	{
		this.RegistEvent();
	}

	// Token: 0x060180C5 RID: 98501 RVA: 0x007779BC File Offset: 0x00775DBC
	protected void RegistEvent()
	{
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.OnHurtEntity));
		}
	}

	// Token: 0x060180C6 RID: 98502 RVA: 0x00777A08 File Offset: 0x00775E08
	protected void OnHurtEntity(BeEvent.BeEventParam param)
	{
		BeProjectile beProjectile = param.m_Obj as BeProjectile;
		if (beProjectile == null || beProjectile.m_iResID != this.mBulletResID)
		{
			return;
		}
		BeEntity beEntity = param.m_Obj2 as BeEntity;
		if (beEntity.GetPID() != base.owner.GetPID())
		{
			return;
		}
		VInt3 vint = param.m_Vint3;
		bool flag = false;
		if (base.owner.GetFace() && vint.x < base.owner.GetPosition().x)
		{
			flag = true;
		}
		else if (!base.owner.GetFace() && vint.x > base.owner.GetPosition().x)
		{
			flag = true;
		}
		if (flag)
		{
			this.ReflectBullet(beProjectile, vint);
			param.m_Int = 0;
		}
	}

	// Token: 0x060180C7 RID: 98503 RVA: 0x00777AE4 File Offset: 0x00775EE4
	protected void ReflectBullet(BeProjectile bullet, VInt3 hitPos)
	{
		if (bullet == null)
		{
			return;
		}
		int num = base.FrameRandom.InRange(this.minX, this.maxX);
		int num2 = base.FrameRandom.InRange(-this.minY, this.maxY);
		int i = bullet.moveXSpeed.i;
		if (num == 0 || num2 == 0)
		{
			num = this.maxX;
			num2 = this.maxY;
		}
		bullet.SetMoveSpeedX(-i * num / 1000);
		bullet.SetMoveSpeedY(i * num2 / 1000);
		bullet.ShowMissEffect(hitPos.vec3);
		if (bullet.m_pkGeActor != null && bullet.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root) != null)
		{
			float num3 = Vector2.Angle(new Vector2((float)bullet.moveXSpeed.i, (float)bullet.moveYSpeed.i), new Vector2(1f, 0f));
			if (bullet.moveYSpeed.i <= 0)
			{
				num3 = -num3;
			}
			bullet.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root).transform.localRotation = Quaternion.Euler(0f, -num3, 0f);
		}
	}

	// Token: 0x04011542 RID: 70978
	protected int mBulletResID;

	// Token: 0x04011543 RID: 70979
	protected int minX;

	// Token: 0x04011544 RID: 70980
	protected int maxX;

	// Token: 0x04011545 RID: 70981
	protected int minY;

	// Token: 0x04011546 RID: 70982
	protected int maxY;
}
