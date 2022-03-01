using System;

// Token: 0x0200450A RID: 17674
public class DropTrail
{
	// Token: 0x06018976 RID: 100726 RVA: 0x007AE1A8 File Offset: 0x007AC5A8
	public DropTrail()
	{
		this.dead = false;
	}

	// Token: 0x06018977 RID: 100727 RVA: 0x007AE1B7 File Offset: 0x007AC5B7
	public bool IsDead()
	{
		return this.dead;
	}

	// Token: 0x06018978 RID: 100728 RVA: 0x007AE1C0 File Offset: 0x007AC5C0
	public void UpdatePosition(int delta)
	{
		if (this.dead || this.currentBeScene == null)
		{
			return;
		}
		float num = (float)delta;
		num /= 1000f;
		double num2 = (this.speed.x <= 0f) ? -1.0 : 1.0;
		this.speed.x = (float)((double)this.speed.x + num2 * (double)this.acc.x * (double)num);
		if (num2 > 0.0)
		{
			this.speed.x = Math.Max(0f, this.speed.x);
		}
		else if (num2 < 0.0)
		{
			this.speed.x = Math.Min(0f, this.speed.x);
		}
		double num3 = (this.speed.y <= 0f) ? -1.0 : 1.0;
		this.speed.y = (float)((double)this.speed.y + num3 * (double)this.acc.y * (double)num);
		if (num3 > 0.0)
		{
			this.speed.y = Math.Max(0f, this.speed.y);
		}
		else if (num3 < 0.0)
		{
			this.speed.y = Math.Min(0f, this.speed.y);
		}
		Vec3 vec = this.position;
		Vec3 vec2 = vec;
		vec2.x += this.speed.x * num;
		if (this.currentBeScene.IsInBlockPlayer(new VInt3(vec2)))
		{
			vec2.x = vec.x;
		}
		vec2.y += this.speed.y * num;
		if (this.currentBeScene.IsInBlockPlayer(new VInt3(vec2)))
		{
			vec2.y = vec.y;
		}
		this.position.x = vec2.x;
		this.position.y = vec2.y;
		if (this.position.z > 0f)
		{
			this.speed.z = this.speed.z - this.acc.z * num;
			this.position.z = this.position.z + this.speed.z * num;
			if (this.position.z <= 0f)
			{
				this.position.z = 0f;
				this.speed.z = 0f;
				if (this.touchGroundDelegate != null)
				{
					this.touchGroundDelegate();
				}
				this.dead = true;
				this.currentBeScene = null;
			}
		}
	}

	// Token: 0x04011BEE RID: 72686
	public Vec3 speed;

	// Token: 0x04011BEF RID: 72687
	public Vec3 acc;

	// Token: 0x04011BF0 RID: 72688
	public Vec3 position;

	// Token: 0x04011BF1 RID: 72689
	public BeScene currentBeScene;

	// Token: 0x04011BF2 RID: 72690
	public DropTrail.OnTouchGround touchGroundDelegate;

	// Token: 0x04011BF3 RID: 72691
	private bool dead;

	// Token: 0x0200450B RID: 17675
	// (Invoke) Token: 0x0601897A RID: 100730
	public delegate void OnTouchGround();
}
