using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200433C RID: 17212
public class Mechanism2006 : BeMechanism
{
	// Token: 0x06017D1A RID: 97562 RVA: 0x0075B8E4 File Offset: 0x00759CE4
	public Mechanism2006(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D1B RID: 97563 RVA: 0x0075B964 File Offset: 0x00759D64
	public override void OnInit()
	{
		base.OnInit();
		this.hitMax = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.summonID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.radius = (float)TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) / 1000f;
		this.centerOffset = new VInt3((float)TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) / 1000f, (float)TableManager.GetValueFromUnionCell(this.data.ValueE[1], this.level, true) / 1000f, 0f);
	}

	// Token: 0x06017D1C RID: 97564 RVA: 0x0075BA80 File Offset: 0x00759E80
	public override void OnStart()
	{
		base.OnStart();
		this.SetMonsterPos();
		this.InitReadyFlag();
		this.hitNum = 0;
		this.summonList.Clear();
		this.flag = false;
		this.handleA = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			this.hitNum++;
			if (this.hitNum >= this.hitMax && !this.flag)
			{
				this.flag = true;
				base.owner.DoSummon(this.summonID, 60, EffectTable.eSummonPosType.ORIGIN, null, 3, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor actor = args[0] as BeActor;
			actor.RegisterEvent(BeEventType.onHit, delegate(object[] obj)
			{
				int num = (int)obj[0];
				BeActor beActor = obj[2] as BeActor;
				if (num >= actor.GetEntityData().GetHP() && beActor != null)
				{
					beActor.buffController.TryAddBuff(this.buffInfoId, null, false, null, 0);
				}
			});
			if (actor.aiManager != null)
			{
				actor.aiManager.Stop();
			}
			this.summonList.Add(actor);
			this.startFocus = (this.summonList.Count == 3);
		});
		this.handleC = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.buffID)
			{
				this.InitReadyFlag();
				this.hitNum = 0;
				this.summonList.Clear();
				this.flag = false;
			}
		});
	}

	// Token: 0x06017D1D RID: 97565 RVA: 0x0075BB18 File Offset: 0x00759F18
	private void InitReadyFlag()
	{
		for (int i = 0; i < this.readyFlag.Length; i++)
		{
			this.readyFlag[i] = false;
		}
	}

	// Token: 0x06017D1E RID: 97566 RVA: 0x0075BB48 File Offset: 0x00759F48
	private void SetMonsterPos()
	{
		VInt3 lhs = base.owner.CurrentBeScene.GetSceneCenterPosition() + this.centerOffset;
		this.pos[0] = lhs + VInt3.right * -this.radius;
		this.pos[1] = lhs + VInt3.right * this.radius;
		this.pos[2] = lhs + VInt3.up * -this.radius;
	}

	// Token: 0x06017D1F RID: 97567 RVA: 0x0075BBE8 File Offset: 0x00759FE8
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.startFocus)
		{
			this.timer += deltaTime;
			if (this.timer >= this.intervel && this.IsAllMonsterDead())
			{
				base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
				this.startFocus = false;
				this.summonList.Clear();
			}
		}
		this.MoveMonster();
	}

	// Token: 0x06017D20 RID: 97568 RVA: 0x0075BC64 File Offset: 0x0075A064
	private void MoveMonster()
	{
		if (this.summonList.Count > 0)
		{
			for (int i = 0; i < this.summonList.Count; i++)
			{
				if (!this.readyFlag[i])
				{
					BeActor beActor = this.summonList[i];
					if (beActor != null && !beActor.IsDead())
					{
						VInt3 vint = this.pos[i] - beActor.GetPosition();
						if (vint.magnitude <= this.tolerance.i)
						{
							beActor.SetMoveSpeedX(VInt.zero);
							beActor.SetMoveSpeedY(VInt.zero);
						}
						else
						{
							vint.NormalizeTo(vint.magnitude.i);
							beActor.SetMoveSpeedX(vint.x);
							beActor.SetMoveSpeedY(vint.y);
						}
						if (this.IsNearTargetPosition(beActor.GetPosition(), this.pos[i]))
						{
							this.readyFlag[i] = true;
						}
					}
				}
			}
		}
	}

	// Token: 0x06017D21 RID: 97569 RVA: 0x0075BD88 File Offset: 0x0075A188
	private bool IsNearTargetPosition(VInt3 pos, VInt3 targetPos)
	{
		int i = this.tolerance.i;
		int magnitude = (pos - targetPos).magnitude;
		return magnitude <= i;
	}

	// Token: 0x06017D22 RID: 97570 RVA: 0x0075BDB8 File Offset: 0x0075A1B8
	public override void OnFinish()
	{
		base.OnFinish();
		this.startFocus = false;
	}

	// Token: 0x06017D23 RID: 97571 RVA: 0x0075BDC8 File Offset: 0x0075A1C8
	private bool IsAllMonsterDead()
	{
		for (int i = 0; i < this.summonList.Count; i++)
		{
			BeActor beActor = this.summonList[i];
			if (beActor != null)
			{
				if (!beActor.IsDead())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x04011239 RID: 70201
	private int hitNum;

	// Token: 0x0401123A RID: 70202
	private int hitMax;

	// Token: 0x0401123B RID: 70203
	private int summonID;

	// Token: 0x0401123C RID: 70204
	private bool mStarted = true;

	// Token: 0x0401123D RID: 70205
	private int intervel = GlobalLogic.VALUE_500;

	// Token: 0x0401123E RID: 70206
	private VInt tolerance = VInt.Float2VIntValue(0.1f);

	// Token: 0x0401123F RID: 70207
	private List<BeActor> summonList = new List<BeActor>();

	// Token: 0x04011240 RID: 70208
	private VInt3[] pos = new VInt3[3];

	// Token: 0x04011241 RID: 70209
	private bool[] readyFlag = new bool[3];

	// Token: 0x04011242 RID: 70210
	private int buffID;

	// Token: 0x04011243 RID: 70211
	private bool startFocus;

	// Token: 0x04011244 RID: 70212
	private int buffInfoId = 568936;

	// Token: 0x04011245 RID: 70213
	private bool flag;

	// Token: 0x04011246 RID: 70214
	private float radius = 3f;

	// Token: 0x04011247 RID: 70215
	private VInt3 centerOffset = VInt3.zero;

	// Token: 0x04011248 RID: 70216
	private int timer;
}
