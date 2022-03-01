using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x020043A1 RID: 17313
public class Mechanism2106 : BeMechanism
{
	// Token: 0x06018014 RID: 98324 RVA: 0x00771004 File Offset: 0x0076F404
	public Mechanism2106(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018015 RID: 98325 RVA: 0x00771040 File Offset: 0x0076F440
	public override void OnInit()
	{
		this.mShadowPathEffect = this.data.StringValueA[0];
		this.mMonsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mWidth = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 2;
		this.mMaxWidth = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true) / 2;
		this.mBuffInfoID = new int[this.data.ValueC.Length];
		for (int i = 0; i < this.data.ValueC.Length; i++)
		{
			this.mBuffInfoID[i] = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
		}
		this.mMaxPlayerNum = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mLength = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.mMinLength = TableManager.GetValueFromUnionCell(this.data.ValueE[1], this.level, true);
		this.mMaxLength = TableManager.GetValueFromUnionCell(this.data.ValueE[2], this.level, true);
	}

	// Token: 0x06018016 RID: 98326 RVA: 0x007711E6 File Offset: 0x0076F5E6
	public override void OnStart()
	{
		this._InitData();
		this.CreateShadowEffect();
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnDeadEvent));
		}
	}

	// Token: 0x06018017 RID: 98327 RVA: 0x00771220 File Offset: 0x0076F620
	public override void OnUpdate(int deltaTime)
	{
		if (this.mStartFlag)
		{
			this.mUpdasteTimeAcc += deltaTime;
			if (this.mUpdasteTimeAcc >= this.mUpdateTime)
			{
				this.mUpdasteTimeAcc -= this.mUpdateTime;
				this._calcRotate();
			}
		}
	}

	// Token: 0x06018018 RID: 98328 RVA: 0x00771270 File Offset: 0x0076F670
	public override void OnFinish()
	{
		this.mStartFlag = false;
		this.mLight = null;
		this.RemoveShadowEffect();
	}

	// Token: 0x06018019 RID: 98329 RVA: 0x00771288 File Offset: 0x0076F688
	private void _InitData()
	{
		this.mDiffWidth = this.mMaxWidth - this.mWidth;
		if (base.owner != null && base.owner.CurrentBeScene != null && base.owner.CurrentBeBattle != null)
		{
			VInt3 position = base.owner.GetPosition();
			this.mLight = base.owner.CurrentBeScene.FindMonsterByID(this.mMonsterID);
			if (this.mLight != null)
			{
				this.mStartFlag = true;
			}
		}
	}

	// Token: 0x0601801A RID: 98330 RVA: 0x00771310 File Offset: 0x0076F710
	private void _calcRotate()
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		VInt3 position = this.mLight.GetPosition();
		VInt3 position2 = base.owner.GetPosition();
		VInt2 vint = new VInt2(position.x - position2.x, position.y - position2.y);
		vint = this.ClampLight(vint);
		this.RotateShadowEffect(vint);
		this.SetShadowScale(vint);
		List<int> list = ListPool<int>.Get();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !playerActor.IsDead())
			{
				VInt3 position3 = playerActor.GetPosition();
				VInt2 playerPos = new VInt2(position3.x - position2.x, position3.y - position2.y);
				if (this.isPlayerInShadow(vint, playerPos))
				{
					list.Add(i);
				}
			}
		}
		if (list.Count == this.mMaxPlayerNum)
		{
			for (int j = 0; j < this.mMaxPlayerNum; j++)
			{
				BeActor playerActor2 = allPlayers[list[j]].playerActor;
				if (playerActor2 != null)
				{
					for (int k = 0; k < this.mBuffInfoID.Length; k++)
					{
						playerActor2.buffController.TryAddBuffInfo(this.mBuffInfoID[k], base.owner, this.level);
					}
				}
			}
		}
		else if (list.Count > this.mMaxPlayerNum)
		{
			base.owner.DoDead(false);
		}
		ListPool<int>.Release(list);
	}

	// Token: 0x0601801B RID: 98331 RVA: 0x007714FD File Offset: 0x0076F8FD
	protected void OnDeadEvent(object args)
	{
		base.Finish();
	}

	// Token: 0x0601801C RID: 98332 RVA: 0x00771508 File Offset: 0x0076F908
	private bool isPlayerInShadow(VInt2 vecLight, VInt2 playerPos)
	{
		bool result = false;
		long num = (long)vecLight.magnitude;
		long num2 = (long)(playerPos.x + vecLight.x / 2) * (long)vecLight.x + (long)(playerPos.y + vecLight.y / 2) * (long)vecLight.y;
		long num3 = (long)(playerPos.x + vecLight.x / 2) * (long)vecLight.y - (long)(playerPos.y + vecLight.y / 2) * (long)vecLight.x;
		long num4 = num * num / 2L;
		if (num2 >= -num4 && num2 <= num4)
		{
			long num5 = 500L - num2 * 1000L / num / num;
			long num6 = (long)this.mWidth + num5 * (long)this.mDiffWidth / 1000L;
			if (num3 >= -num6 * num && num3 <= num6 * num)
			{
				return true;
			}
		}
		return result;
	}

	// Token: 0x0601801D RID: 98333 RVA: 0x007715F4 File Offset: 0x0076F9F4
	private VInt2 ClampLight(VInt2 vecLight)
	{
		int magnitude = vecLight.magnitude;
		if (magnitude < this.mMinLength)
		{
			if (magnitude == 0)
			{
				return vecLight;
			}
			return new VInt2((int)((long)vecLight.x * (long)this.mMinLength / (long)magnitude), (int)((long)vecLight.y * (long)this.mMinLength / (long)magnitude));
		}
		else
		{
			if (magnitude > this.mMaxLength)
			{
				return new VInt2((int)((long)vecLight.x * (long)this.mMaxLength / (long)magnitude), (int)((long)vecLight.y * (long)this.mMaxLength / (long)magnitude));
			}
			return vecLight;
		}
	}

	// Token: 0x0601801E RID: 98334 RVA: 0x00771688 File Offset: 0x0076FA88
	protected void CreateShadowEffect()
	{
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			this.mShadowEffect = base.owner.m_pkGeActor.CreateEffect(this.mShadowPathEffect, null, 99999f, base.owner.GetPosition().vec3, 1f, 1f, false, false, EffectTimeType.BUFF, false);
		}
	}

	// Token: 0x0601801F RID: 98335 RVA: 0x007716F4 File Offset: 0x0076FAF4
	protected void RotateShadowEffect(VInt2 vecLight)
	{
		if (this.mShadowEffect != null)
		{
			Vector2 vector;
			vector..ctor((float)vecLight.x, (float)vecLight.y);
			float num = 0f;
			if (vector.y != 0f)
			{
				num = Vector2.Angle(vector, new Vector2(1f, 0f));
			}
			if (vector.y < 0f)
			{
				num = -num;
			}
			if (vector.x >= 0f && vector.y == 0f)
			{
				num = 0f;
			}
			else if (vector.x < 0f && vector.y == 0f)
			{
				num = 180f;
			}
			this.mShadowEffect.SetLocalRotation(Quaternion.AngleAxis(num - 90f, Vector3.down));
		}
	}

	// Token: 0x06018020 RID: 98336 RVA: 0x007717D8 File Offset: 0x0076FBD8
	protected void SetShadowScale(VInt2 vecLight)
	{
		if (this.mShadowEffect != null)
		{
			float sz = (float)vecLight.magnitude / (float)this.mLength;
			this.mShadowEffect.SetScale(1f, 1f, sz);
		}
	}

	// Token: 0x06018021 RID: 98337 RVA: 0x00771818 File Offset: 0x0076FC18
	protected void RemoveShadowEffect()
	{
		if (base.owner != null && base.owner.m_pkGeActor != null && this.mShadowEffect != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.mShadowEffect);
			this.mShadowEffect = null;
		}
	}

	// Token: 0x040114A4 RID: 70820
	protected int mMonsterID;

	// Token: 0x040114A5 RID: 70821
	protected int mWidth;

	// Token: 0x040114A6 RID: 70822
	protected int mMaxWidth;

	// Token: 0x040114A7 RID: 70823
	protected int mDiffWidth;

	// Token: 0x040114A8 RID: 70824
	protected int mLength = 25000;

	// Token: 0x040114A9 RID: 70825
	protected int mMinLength = 12500;

	// Token: 0x040114AA RID: 70826
	protected int mMaxLength = 50000;

	// Token: 0x040114AB RID: 70827
	protected int[] mBuffInfoID;

	// Token: 0x040114AC RID: 70828
	protected int mMaxPlayerNum;

	// Token: 0x040114AD RID: 70829
	protected string mShadowPathEffect;

	// Token: 0x040114AE RID: 70830
	protected GeEffectEx mShadowEffect;

	// Token: 0x040114AF RID: 70831
	protected BeEntity mLight;

	// Token: 0x040114B0 RID: 70832
	protected bool mStartFlag;

	// Token: 0x040114B1 RID: 70833
	protected int mUpdateTime = 50;

	// Token: 0x040114B2 RID: 70834
	protected int mUpdasteTimeAcc = 50;
}
