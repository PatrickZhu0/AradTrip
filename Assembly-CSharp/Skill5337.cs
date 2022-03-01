using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044DF RID: 17631
public class Skill5337 : BeSkill
{
	// Token: 0x060188A0 RID: 100512 RVA: 0x007A96C4 File Offset: 0x007A7AC4
	public Skill5337(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.mState = Skill5337.eState.onStart;
	}

	// Token: 0x060188A1 RID: 100513 RVA: 0x007A96F6 File Offset: 0x007A7AF6
	public override void OnStart()
	{
		this.mState = Skill5337.eState.onStart;
	}

	// Token: 0x060188A2 RID: 100514 RVA: 0x007A96FF File Offset: 0x007A7AFF
	private void _changeCB(int op)
	{
		if (op == 0)
		{
			if (base.FrameRandom.Random(3U) >= 1)
			{
				this._changeLeftOps(1);
			}
			else
			{
				this._changeLeftOps(2);
			}
		}
		else
		{
			this._changeLeftOps(op);
		}
	}

	// Token: 0x060188A3 RID: 100515 RVA: 0x007A9738 File Offset: 0x007A7B38
	private BeActor _findActor()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), 15, this.mCamp, 0);
		BeActor result = null;
		if (list.Count > 0)
		{
			result = list[0];
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x060188A4 RID: 100516 RVA: 0x007A9794 File Offset: 0x007A7B94
	public override void OnUpdate(int iDeltime)
	{
		if (this.mState == Skill5337.eState.onMove)
		{
			this.mFindTargetTime += iDeltime;
			if (this.mFindTargetTime > this.mFindTargetDelta)
			{
				this.mFindTargetTime = 0;
				this.mTarget = this._findActor();
			}
			this._moveUpdate();
			this._checkChanageUpdate();
		}
	}

	// Token: 0x060188A5 RID: 100517 RVA: 0x007A97EC File Offset: 0x007A7BEC
	private void _checkChanageUpdate()
	{
		VInt3 position = base.owner.GetPosition();
		int num = 0;
		position.x += Skill5337.kDelta.i;
		if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
		{
			num += 2;
		}
		position.x -= 2 * Skill5337.kDelta.i;
		if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
		{
			num++;
		}
		position.x += Skill5337.kDelta.i;
		position.y += Skill5337.kDelta.i;
		if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
		{
			num += 4;
		}
		position.y -= 2 * Skill5337.kDelta.i;
		if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
		{
			num += 8;
		}
		position.y += Skill5337.kDelta.i;
		if (num > 0)
		{
			this._changeCB(num);
		}
	}

	// Token: 0x060188A6 RID: 100518 RVA: 0x007A9928 File Offset: 0x007A7D28
	private void _move(VInt3 pos)
	{
		VFactor vfactor = new VFactor((long)pos.x, (long)pos.y);
		VFactor vfactor2 = new VFactor(33L, 100L);
		VFactor vfactor3 = new VFactor(400L, 100L);
		if (vfactor < vfactor2)
		{
			vfactor = vfactor2;
		}
		if (vfactor > vfactor3)
		{
			vfactor = vfactor3;
		}
		int integer = (VFactor.one + vfactor).integer;
		int integer2 = ((vfactor + VFactor.one) / vfactor).integer;
		for (int i = 0; i < this.mTotalStep; i++)
		{
			Skill5337.MoveOp item;
			item.cx = -1;
			item.cy = -1;
			if (i % integer == 0)
			{
				if (pos.x > VInt.zeroDotOne)
				{
					item.cx = 0;
				}
				else if (pos.x < VInt.zeroDotOne)
				{
					item.cx = 1;
				}
			}
			if (i % integer2 == 0)
			{
				if (pos.y > VInt.zeroDotOne)
				{
					item.cy = 2;
				}
				else if (pos.y < VInt.zeroDotOne)
				{
					item.cy = 3;
				}
			}
			this.mMoveOpQueue.Enqueue(item);
		}
	}

	// Token: 0x060188A7 RID: 100519 RVA: 0x007A9A98 File Offset: 0x007A7E98
	private void _moveUpdate()
	{
		if (this.mMoveOpQueue.Count > 0)
		{
			Skill5337.MoveOp moveOp = this.mMoveOpQueue.Dequeue();
			base.owner.ResetMoveCmd();
			if (moveOp.cx == 0)
			{
				base.owner.ModifyMoveCmd(0, true);
			}
			else if (moveOp.cx == 1)
			{
				base.owner.ModifyMoveCmd(1, true);
			}
			if (moveOp.cy == 2)
			{
				base.owner.ModifyMoveCmd(2, true);
			}
			else if (moveOp.cy == 3)
			{
				base.owner.ModifyMoveCmd(3, true);
			}
		}
		else
		{
			this._move(this.mTarget.GetPosition() - base.owner.GetPosition());
		}
	}

	// Token: 0x060188A8 RID: 100520 RVA: 0x007A9B64 File Offset: 0x007A7F64
	private void _changeLeftOps(int changex)
	{
		Skill5337.MoveOp[] array = this.mMoveOpQueue.ToArray();
		this.mMoveOpQueue.Clear();
		foreach (Skill5337.MoveOp item in array)
		{
			if ((changex & 1) > 0 && item.cx == 1)
			{
				item.cx = 0;
			}
			if ((changex & 2) > 0 && item.cx == 0)
			{
				item.cx = 1;
			}
			if ((changex & 4) > 0 && item.cy == 2)
			{
				item.cy = 3;
			}
			if ((changex & 8) > 0 && item.cy == 3)
			{
				item.cy = 2;
			}
			this.mMoveOpQueue.Enqueue(item);
		}
	}

	// Token: 0x060188A9 RID: 100521 RVA: 0x007A9C2C File Offset: 0x007A802C
	public override void OnFinish()
	{
		this._end();
	}

	// Token: 0x060188AA RID: 100522 RVA: 0x007A9C34 File Offset: 0x007A8034
	public override void OnCancel()
	{
		this._end();
	}

	// Token: 0x060188AB RID: 100523 RVA: 0x007A9C3C File Offset: 0x007A803C
	private void _unreachLimit()
	{
		if (this.mOnLimit != null)
		{
			base.owner.RemoveEvent(this.mOnLimit);
			this.mOnLimit = null;
		}
	}

	// Token: 0x060188AC RID: 100524 RVA: 0x007A9C61 File Offset: 0x007A8061
	private void _end()
	{
		this.mState = Skill5337.eState.onEnd;
		this._unreachLimit();
		this.mMoveOpQueue.Clear();
		base.owner.ResetMoveCmd();
		base.owner.aiManager.Start();
	}

	// Token: 0x060188AD RID: 100525 RVA: 0x007A9C98 File Offset: 0x007A8098
	public override void OnEnterPhase(int phase)
	{
		if (phase == 1)
		{
			this.mState = Skill5337.eState.onRotate;
		}
		else if (phase == 2)
		{
			this.mState = Skill5337.eState.onMove;
			this.mTarget = this._findActor();
			base.owner.aiManager.Stop();
		}
		else if (phase == 3)
		{
			this._end();
		}
	}

	// Token: 0x04011B44 RID: 72516
	private int mCamp;

	// Token: 0x04011B45 RID: 72517
	private Skill5337.eState mState;

	// Token: 0x04011B46 RID: 72518
	private BeEventHandle mOnLimit;

	// Token: 0x04011B47 RID: 72519
	private BeEventHandle mOnHit;

	// Token: 0x04011B48 RID: 72520
	private int mFindTargetDelta = 10000;

	// Token: 0x04011B49 RID: 72521
	private int mFindTargetTime;

	// Token: 0x04011B4A RID: 72522
	private BeActor mTarget;

	// Token: 0x04011B4B RID: 72523
	private Queue<Skill5337.MoveOp> mMoveOpQueue = new Queue<Skill5337.MoveOp>();

	// Token: 0x04011B4C RID: 72524
	private static readonly VInt kDelta = VInt.half;

	// Token: 0x04011B4D RID: 72525
	private int mTotalStep = 300;

	// Token: 0x020044E0 RID: 17632
	private enum eState
	{
		// Token: 0x04011B4F RID: 72527
		onStart,
		// Token: 0x04011B50 RID: 72528
		onRotate,
		// Token: 0x04011B51 RID: 72529
		onMove,
		// Token: 0x04011B52 RID: 72530
		onEnd
	}

	// Token: 0x020044E1 RID: 17633
	private struct MoveOp
	{
		// Token: 0x04011B53 RID: 72531
		public short cx;

		// Token: 0x04011B54 RID: 72532
		public short cy;
	}
}
