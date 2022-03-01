using System;

// Token: 0x0200436E RID: 17262
public class Mechanism2054 : BeMechanism
{
	// Token: 0x06017E8B RID: 97931 RVA: 0x007663DE File Offset: 0x007647DE
	public Mechanism2054(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E8C RID: 97932 RVA: 0x0076640C File Offset: 0x0076480C
	public override void OnInit()
	{
		base.OnInit();
		this.entityId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.angle = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.targetDist = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.flyTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.moveSpeedZ = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.targetRandomRange = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.offsetX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true), GlobalLogic.VALUE_1000);
		this.offsetZ = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueG[1], this.level, true), GlobalLogic.VALUE_1000);
		if (this.flyTime <= 0)
		{
			Logger.LogErrorFormat("Mechanism id {0} flyTime is invalid data", new object[]
			{
				this.mechianismID
			});
			this.flyTime = 100;
		}
	}

	// Token: 0x06017E8D RID: 97933 RVA: 0x007665AA File Offset: 0x007649AA
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this._createBullet();
	}

	// Token: 0x06017E8E RID: 97934 RVA: 0x007665C0 File Offset: 0x007649C0
	private void _createBullet()
	{
		VInt3 targetPosition = this.GetTargetPosition();
		BeProjectile beProjectile = base.owner.AddEntity(this.entityId, VInt3.zero, 1, 0) as BeProjectile;
		if (beProjectile != null)
		{
			VInt3 vint = this._getBirthPos();
			beProjectile.SetPosition(vint, false, true);
			VInt3 vint2 = targetPosition - vint;
			beProjectile.SetMoveSpeedX(vint2.x * 1000 / this.flyTime);
			beProjectile.SetMoveSpeedY(vint2.y * 1000 / this.flyTime);
			beProjectile.SetMoveSpeedZ(this.moveSpeedZ.i);
			int i = 2 * (this.moveSpeedZ.i * this.flyTime / 1000 + this.offsetZ.i) * 1000 / this.flyTime * 1000 / this.flyTime;
			beProjectile.SetMoveSpeedZAcc(i);
			beProjectile.onCollideDie = true;
		}
	}

	// Token: 0x06017E8F RID: 97935 RVA: 0x007666BC File Offset: 0x00764ABC
	private VInt3 _getBirthPos()
	{
		int x = base.owner.GetPosition().x + ((!base.owner.GetFace()) ? this.offsetX.i : (-this.offsetX.i));
		int y = base.owner.GetPosition().y;
		int z = base.owner.GetPosition().z + this.offsetZ.i;
		VInt3 result = new VInt3(x, y, z);
		return result;
	}

	// Token: 0x06017E90 RID: 97936 RVA: 0x00766750 File Offset: 0x00764B50
	private VInt3 GetTargetPosition()
	{
		if (base.owner.aiManager != null)
		{
			BeActor aiTarget = base.owner.aiManager.aiTarget;
			if (aiTarget != null)
			{
				VInt3 position = aiTarget.GetPosition();
				position.z = 0;
				int num = base.owner.FrameRandom.InRange(-this.targetRandomRange, this.targetRandomRange);
				int num2 = base.owner.FrameRandom.InRange(-this.targetRandomRange, this.targetRandomRange);
				position.x += num;
				position.y += num2;
				return position;
			}
		}
		VFactor vfactor = VFactor.pi * (long)this.angle / 180L;
		VFactor f = IntMath.sin(vfactor.nom, vfactor.den);
		VFactor f2 = IntMath.cos(vfactor.nom, vfactor.den);
		int num3 = this.targetDist * f;
		int num4 = this.targetDist * f2;
		if (base.owner.GetFace())
		{
			num3 = -num3;
			num4 = -num4;
		}
		int num5 = base.owner.FrameRandom.InRange(-this.targetRandomRange, this.targetRandomRange);
		int num6 = base.owner.FrameRandom.InRange(-this.targetRandomRange, this.targetRandomRange);
		VInt3 vint = base.owner.GetPosition();
		vint.y = vint.y + num3 + num6;
		vint.x = vint.x + num4 + num5;
		vint.z = 0;
		vint = BeAIManager.FindStandPositionNew(vint, base.owner.CurrentBeScene, false, false, 40);
		return vint;
	}

	// Token: 0x0401135E RID: 70494
	private int flyTime;

	// Token: 0x0401135F RID: 70495
	private int targetDist;

	// Token: 0x04011360 RID: 70496
	private int angle;

	// Token: 0x04011361 RID: 70497
	private VInt moveSpeedZ = VInt.zero;

	// Token: 0x04011362 RID: 70498
	private int targetRandomRange;

	// Token: 0x04011363 RID: 70499
	private int entityId;

	// Token: 0x04011364 RID: 70500
	private VInt offsetX = VInt.zero;

	// Token: 0x04011365 RID: 70501
	private VInt offsetZ = VInt.zero;
}
