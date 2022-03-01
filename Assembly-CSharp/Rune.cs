using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x020043CD RID: 17357
public class Rune
{
	// Token: 0x0601813E RID: 98622 RVA: 0x0077A5C8 File Offset: 0x007789C8
	public Rune(int lt, BeEntity owner, Mechanism22 m)
	{
		this.lifeTime = lt + 1300;
		this.owner = owner;
		this.mechanism = m;
		this.resIndex = Rune.Dequeue();
		this.CreateEffect();
	}

	// Token: 0x0601813F RID: 98623 RVA: 0x0077A65C File Offset: 0x00778A5C
	public static void InitQueue()
	{
		Rune.runeResIndexQueue.Clear();
		for (int i = 0; i < Rune.runeRes.Length; i++)
		{
			Rune.runeResIndexQueue.Enqueue(i);
		}
	}

	// Token: 0x06018140 RID: 98624 RVA: 0x0077A696 File Offset: 0x00778A96
	public static int Dequeue()
	{
		if (Rune.runeResIndexQueue.Count <= 0)
		{
			return 0;
		}
		return Rune.runeResIndexQueue.Dequeue();
	}

	// Token: 0x06018141 RID: 98625 RVA: 0x0077A6B4 File Offset: 0x00778AB4
	public static void Enqueue(int index)
	{
		Rune.runeResIndexQueue.Enqueue(index);
	}

	// Token: 0x06018142 RID: 98626 RVA: 0x0077A6C4 File Offset: 0x00778AC4
	private GeEffectEx _CreateEffect(string res)
	{
		GeEffectEx geEffectEx = this.owner.m_pkGeActor.CreateEffect(res, null, 0f, new Vec3(0f, 0f, this.height), 1f, 1f, false, false, EffectTimeType.BUFF, false);
		geEffectEx.SetScale(this.scale);
		GeUtility.AttachTo(geEffectEx.GetRootNode(), this.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
		return geEffectEx;
	}

	// Token: 0x06018143 RID: 98627 RVA: 0x0077A738 File Offset: 0x00778B38
	private void CreateEffect()
	{
		GeEffectEx effectRune2 = this._CreateEffect(Rune.runeRes[this.resIndex]);
		effectRune2.SetTimeLen(700);
		this.owner.delayCaller.DelayCall(100, delegate
		{
			this._CreateEffect(this.resStart);
		}, 0, 0, false);
		this.owner.delayCaller.DelayCall(700, delegate
		{
			this.owner.m_pkGeActor.DestroyEffect(effectRune2);
			this.StartRotation();
		}, 0, 0, false);
		MonoSingleton<AudioManager>.instance.PlaySound(3026);
	}

	// Token: 0x06018144 RID: 98628 RVA: 0x0077A7D4 File Offset: 0x00778BD4
	private void StartRotation()
	{
		this.effectRune = this.owner.m_pkGeActor.CreateEffect(Rune.runeRes[this.resIndex], null, 100000f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.BUFF, false);
		this.effectRune.SetScale(this.scale);
		this.rotateDummy = new GameObject("rotateDummy");
		GeUtility.AttachTo(this.rotateDummy, this.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
		this.rotateDummy.transform.localPosition = new Vector3(this.initX, this.height, 0f);
		this.center = new Vector3(this.owner.GetPosition().fx, this.height, this.owner.GetPosition().fy);
		this.state = Rune.State.STAND;
		this.mechanism.RepositionRunes(false);
	}

	// Token: 0x06018145 RID: 98629 RVA: 0x0077A8DC File Offset: 0x00778CDC
	private void UpdateRotation(float specifyAngle = 0f, int delta = 0)
	{
		if (this.owner.m_pkGeActor != null)
		{
			GameObject entityNode = this.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
			if (entityNode != null)
			{
				this.center = entityNode.transform.position;
			}
			else
			{
				this.center = this.owner.m_pkGeActor.GetPosition();
			}
		}
		this.center.y = this.height;
		if (this.effectRune.isVisible())
		{
			float num = (specifyAngle <= 0f) ? this.rotateSpeed : specifyAngle;
			int num2 = 16;
			if (specifyAngle <= 0f)
			{
				num = this.rotateSpeed * (float)delta / (float)num2;
			}
			this.rotateDummy.transform.RotateAround(this.center, Vector3.up, -num);
			if (specifyAngle <= 0f)
			{
				this.angle += num;
			}
			if (this.angle >= 360f)
			{
				this.angle -= 360f;
			}
		}
		this.effectRune.SetPosition(this.rotateDummy.transform.position);
	}

	// Token: 0x06018146 RID: 98630 RVA: 0x0077AA0C File Offset: 0x00778E0C
	public void SetRotationAngle(float specifyAngle, bool force = false)
	{
		if (force && this.rotateDummy != null)
		{
			this.angle = 360f - this.rotateDummy.transform.localEulerAngles.y % 360f;
		}
		float num = specifyAngle - this.angle;
		num = ((num >= 0f) ? num : (360f + num));
		this.UpdateRotation(num, 0);
		this.angle = specifyAngle;
	}

	// Token: 0x06018147 RID: 98631 RVA: 0x0077AA8B File Offset: 0x00778E8B
	public void UpdateGraphic(int delta)
	{
		if (this.effectRune != null)
		{
			this.UpdateRotation(0f, delta);
		}
	}

	// Token: 0x06018148 RID: 98632 RVA: 0x0077AAA4 File Offset: 0x00778EA4
	public void OnRemove()
	{
		this.state = Rune.State.DEAD;
		if (this.effectRune != null)
		{
			if (this.isConsumed)
			{
				if (this.effectRune != null)
				{
					Rune.Enqueue(this.resIndex);
					this.owner.m_pkGeActor.DestroyEffect(this.effectRune);
					Object.Destroy(this.rotateDummy);
					this.effectRune = null;
				}
			}
			else
			{
				this.effectEnd = this.owner.m_pkGeActor.CreateEffect(this.resEnd, null, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.BUFF, false);
				this.owner.delayCaller.DelayCall(100, delegate
				{
					this.effectRune.SetVisible(false);
				}, 0, 0, false);
				this.rotateDummy.transform.localRotation = Quaternion.identity;
				GeUtility.AttachTo(this.effectEnd.GetRootNode(), this.rotateDummy, false);
				this.owner.delayCaller.DelayCall(700, delegate
				{
					if (this.effectEnd != null)
					{
						this.owner.m_pkGeActor.DestroyEffect(this.effectEnd);
						this.effectEnd = null;
					}
					if (this.effectRune != null)
					{
						Rune.Enqueue(this.resIndex);
						this.owner.m_pkGeActor.DestroyEffect(this.effectRune);
						Object.Destroy(this.rotateDummy);
						this.effectRune = null;
					}
					this.mechanism.RepositionRunes(false);
				}, 0, 0, false);
			}
		}
		MonoSingleton<AudioManager>.instance.PlaySound(3027);
	}

	// Token: 0x06018149 RID: 98633 RVA: 0x0077ABD8 File Offset: 0x00778FD8
	public void Update(int delta)
	{
		if (this.isDead)
		{
			return;
		}
		this.acc += delta;
		if (this.acc >= this.lifeTime)
		{
			this.acc = 0;
			this.isDead = true;
		}
	}

	// Token: 0x0601814A RID: 98634 RVA: 0x0077AC13 File Offset: 0x00779013
	public bool IsDead()
	{
		return this.isDead;
	}

	// Token: 0x0601814B RID: 98635 RVA: 0x0077AC1B File Offset: 0x0077901B
	public void SetDead(bool dead)
	{
		this.isDead = dead;
		this.isConsumed = true;
	}

	// Token: 0x04011596 RID: 71062
	private int acc;

	// Token: 0x04011597 RID: 71063
	private int lifeTime;

	// Token: 0x04011598 RID: 71064
	private bool isDead;

	// Token: 0x04011599 RID: 71065
	private bool isConsumed;

	// Token: 0x0401159A RID: 71066
	public Rune.State state;

	// Token: 0x0401159B RID: 71067
	private Mechanism22 mechanism;

	// Token: 0x0401159C RID: 71068
	private BeEntity owner;

	// Token: 0x0401159D RID: 71069
	private GameObject rotateDummy;

	// Token: 0x0401159E RID: 71070
	private Vector3 center = Vector3.zero;

	// Token: 0x0401159F RID: 71071
	private int resIndex = -1;

	// Token: 0x040115A0 RID: 71072
	private static string[] runeRes = new string[]
	{
		"Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_blue",
		"Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_red",
		"Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_yellow",
		"Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_green",
		"Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_brown"
	};

	// Token: 0x040115A1 RID: 71073
	public static Queue<int> runeResIndexQueue = new Queue<int>();

	// Token: 0x040115A2 RID: 71074
	private string resStart = "Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_fwfire";

	// Token: 0x040115A3 RID: 71075
	private string resEnd = "Effects/Hero_Axiuluo/bodongyinke/Perfab/Eff_bodongyinke_fwend";

	// Token: 0x040115A4 RID: 71076
	public GeEffectEx effectRune;

	// Token: 0x040115A5 RID: 71077
	private GeEffectEx effectEnd;

	// Token: 0x040115A6 RID: 71078
	public float angle;

	// Token: 0x040115A7 RID: 71079
	private float height = 2.4f;

	// Token: 0x040115A8 RID: 71080
	private float initX = -0.45f;

	// Token: 0x040115A9 RID: 71081
	private float rotateSpeed = 2f;

	// Token: 0x040115AA RID: 71082
	private float scale = 0.7f;

	// Token: 0x020043CE RID: 17358
	public enum State
	{
		// Token: 0x040115AC RID: 71084
		BORN,
		// Token: 0x040115AD RID: 71085
		STAND,
		// Token: 0x040115AE RID: 71086
		DEAD
	}
}
