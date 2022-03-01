using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004116 RID: 16662
public class BeAIWalkCommand : BeAICommand
{
	// Token: 0x06016AEF RID: 92911 RVA: 0x006E0154 File Offset: 0x006DE554
	public BeAIWalkCommand(BeEntity e) : base(e, "AIWalkCommand")
	{
	}

	// Token: 0x06016AF0 RID: 92912 RVA: 0x006E018C File Offset: 0x006DE58C
	public override void Reset(BeEntity e)
	{
		base.Reset(e);
		this.targetPos = VInt3.zero;
		this.tolerance = 0;
		this.moveBack = false;
		this.isRun = false;
		this.pathFinding = false;
		this.bypass = false;
		this.stopable = true;
		this.handle = null;
		this.walkUpdateInterval = 500;
		this.walkTimeAcc = 500;
		this.lastPosition = VInt3.zero;
		this.start = false;
		this.stuckTimeAcc = 0;
		this.stuckInterval = 1000;
		this.steps = null;
		this.lastPos = VInt3.zero;
		this.lastDir = BeAIManager.MoveDir.COUNT;
		this.destinationType = BeAIManager.DestinationType.GO_TO_TARGET;
	}

	// Token: 0x06016AF1 RID: 92913 RVA: 0x006E023C File Offset: 0x006DE63C
	public void Init(int dur, VInt3 targetPosition, VInt tolerance, bool run = false, bool moveBack = false, bool pathFinding = false, bool bypass = false)
	{
		this.duraction = dur;
		this.targetPos = targetPosition;
		VInt2 vint = new VInt2(this.aiManager.owner.CurrentBeScene.sceneData.GetLogicXSize());
		VInt2 vint2 = new VInt2(this.aiManager.owner.CurrentBeScene.sceneData.GetLogicZSize());
		this.targetPos.x = Mathf.Clamp(this.targetPos.x, vint.x, vint.y);
		this.targetPos.y = Mathf.Clamp(this.targetPos.y, vint2.x, vint2.y);
		this.tolerance = tolerance;
		this.moveBack = moveBack;
		this.isRun = run;
		this.cmdType = AI_COMMAND.WALK;
		this.bypass = bypass;
		if (this.bypass)
		{
			this.walkUpdateInterval = 2000;
			this.walkTimeAcc = this.walkUpdateInterval;
		}
		this.lastDir = BeAIManager.MoveDir.COUNT;
		this.pathFinding = pathFinding;
		if (pathFinding)
		{
			BeActor owner = this.aiManager.owner;
			VInt3 position = owner.GetPosition();
			DGrid dgrid = owner.CurrentBeScene.CalGridByPosition(position);
			DGrid end = owner.CurrentBeScene.CalGridByPosition(this.targetPos);
			if (!this.aiManager.DoPathFinding(dgrid, end, this.aiManager.steps))
			{
				this.pathFinding = false;
			}
			else
			{
				this.steps = this.aiManager.steps;
				if (owner != null && owner.IsProcessRecord())
				{
					string text = string.Format("found path ==> count:{0}; values:", this.steps.Count);
					for (int i = 0; i < this.steps.Count; i++)
					{
						text += string.Format("{0} ", this.steps[i]);
					}
					if (owner.GetRecordServer().IsProcessRecord())
					{
						owner.GetRecordServer().Mark(142055312U, owner.GetEntityRecordAttribute(), new string[]
						{
							text,
							owner.GetName()
						});
					}
				}
			}
		}
	}

	// Token: 0x06016AF2 RID: 92914 RVA: 0x006E046C File Offset: 0x006DE86C
	public override void OnExecute()
	{
		if (this.entity != null)
		{
			BeActor beActor = this.entity as BeActor;
			if (beActor != null)
			{
				beActor.ResetMoveCmd();
				beActor.ChangeRunMode(this.isRun);
				this.DoNextMove();
			}
			else
			{
				Logger.LogError("entity is not BeActor!");
			}
		}
		else
		{
			Logger.LogErrorFormat("entity is null!", new object[0]);
		}
	}

	// Token: 0x06016AF3 RID: 92915 RVA: 0x006E04D4 File Offset: 0x006DE8D4
	public bool DoNextMove()
	{
		if (!this.pathFinding)
		{
			if (this.bypass)
			{
				VInt3 position = this.aiManager.owner.GetPosition();
				if (this.lastDir == BeAIManager.MoveDir.COUNT)
				{
					BeAIManager.MoveDir dir;
					if (this.targetPos.x >= position.x)
					{
						if (this.targetPos.y >= position.y)
						{
							dir = BeAIManager.MoveDir.RIGHT_TOP;
						}
						else
						{
							dir = BeAIManager.MoveDir.RIGHT_DOWN;
						}
					}
					else if (this.targetPos.y >= position.y)
					{
						dir = BeAIManager.MoveDir.LEFT_TOP;
					}
					else
					{
						dir = BeAIManager.MoveDir.LEFT_DOWN;
					}
					this.lastDir = dir;
					this.aiManager.DoWalk(dir, true);
				}
				else
				{
					BeAIManager.MoveDir dir2 = BeAIManager.MoveDir.RIGHT_TOP;
					if (this.targetPos.x >= position.x)
					{
						if (this.lastDir == BeAIManager.MoveDir.RIGHT_TOP)
						{
							dir2 = BeAIManager.MoveDir.RIGHT_DOWN;
						}
						else if (this.lastDir == BeAIManager.MoveDir.RIGHT_DOWN)
						{
							dir2 = BeAIManager.MoveDir.RIGHT_TOP;
						}
					}
					else if (this.lastDir == BeAIManager.MoveDir.LEFT_DOWN)
					{
						dir2 = BeAIManager.MoveDir.LEFT_TOP;
					}
					else if (this.lastDir == BeAIManager.MoveDir.LEFT_TOP)
					{
						dir2 = BeAIManager.MoveDir.LEFT_DOWN;
					}
					this.lastDir = dir2;
					this.aiManager.DoWalk(dir2, true);
				}
			}
			return false;
		}
		if (this.steps == null)
		{
			Logger.LogError("do next move, steps is null!");
			return false;
		}
		if (this.steps.Count <= 0)
		{
			base.End();
			return false;
		}
		this.lastPos = this.aiManager.owner.GetPosition();
		int num = this.steps[0];
		this.steps.RemoveAt(0);
		this.lastDir = (BeAIManager.MoveDir)num;
		BeActor owner = this.aiManager.owner;
		if (owner != null && owner.IsProcessRecord())
		{
			owner.GetRecordServer().Mark(142055313U, new int[]
			{
				this.aiManager.owner.m_iID,
				this.lastPos.x,
				this.lastPos.y,
				this.lastPos.z,
				(int)this.lastDir
			}, new string[]
			{
				this.aiManager.owner.GetName()
			});
		}
		this.aiManager.DoWalk(this.lastDir, true);
		return true;
	}

	// Token: 0x06016AF4 RID: 92916 RVA: 0x006E0713 File Offset: 0x006DEB13
	public void DoOppositeMove()
	{
		base.End();
	}

	// Token: 0x06016AF5 RID: 92917 RVA: 0x006E071C File Offset: 0x006DEB1C
	public override void OnTick(int deltaTime)
	{
		if (this.pathFinding)
		{
			VInt3 position = this.aiManager.owner.GetPosition();
			VInt3 vint = position - this.lastPos;
			if (Mathf.Abs(vint.x) >= BeAIWalkCommand.grid.x || Mathf.Abs(vint.y) >= BeAIWalkCommand.grid.y)
			{
				this.DoNextMove();
			}
		}
		else
		{
			this.walkTimeAcc += deltaTime;
			if (this.walkTimeAcc > this.walkUpdateInterval)
			{
				this.walkTimeAcc -= this.walkUpdateInterval;
				if (!this.bypass)
				{
					this.aiManager.DoWalk(this.targetPos);
				}
			}
			this.CheckStuck(deltaTime);
		}
		if (this.IsNearTargetPosition())
		{
			base.End();
			if (this.entity != null && this.entity.aiManager != null)
			{
				BeActorAIManager beActorAIManager = this.entity.aiManager as BeActorAIManager;
				if (beActorAIManager != null)
				{
					beActorAIManager.ResetDestinationSelect();
				}
			}
		}
	}

	// Token: 0x06016AF6 RID: 92918 RVA: 0x006E083C File Offset: 0x006DEC3C
	public void CheckStuck(int delta)
	{
		VInt3 position = this.aiManager.owner.GetPosition();
		if (!this.start)
		{
			this.lastPosition = position;
			this.start = true;
		}
		else if (Mathf.Abs(position.x - this.lastPosition.x) < BeAIWalkCommand.tolerance001 && Mathf.Abs(position.y - this.lastPosition.y) < BeAIWalkCommand.tolerance001)
		{
			this.stuckTimeAcc += delta;
			if (this.stuckTimeAcc > this.stuckInterval)
			{
				if (this.bypass)
				{
					this.DoNextMove();
				}
				else
				{
					this.DoOppositeMove();
				}
				this.stuckTimeAcc = 0;
			}
		}
		else
		{
			this.lastPosition = position;
			this.stuckTimeAcc = 0;
		}
	}

	// Token: 0x06016AF7 RID: 92919 RVA: 0x006E0928 File Offset: 0x006DED28
	public bool IsNearTargetPosition()
	{
		int i = this.tolerance.i;
		VInt3 position = this.entity.GetPosition();
		return Mathf.Abs(this.targetPos.x - position.x) <= i && Mathf.Abs(this.targetPos.y - position.y) <= i;
	}

	// Token: 0x06016AF8 RID: 92920 RVA: 0x006E098C File Offset: 0x006DED8C
	public override void OnFinish()
	{
		if (this.entity != null && this.entity.aiManager != null && this.entity.aiManager != null)
		{
			this.entity.aiManager.ResetDestinationSelect();
		}
	}

	// Token: 0x06016AF9 RID: 92921 RVA: 0x006E09C9 File Offset: 0x006DEDC9
	public override void OnEnd()
	{
		this.RemoveHandle();
	}

	// Token: 0x06016AFA RID: 92922 RVA: 0x006E09D1 File Offset: 0x006DEDD1
	private void RemoveHandle()
	{
		if (this.entity != null && this.handle != null)
		{
			this.entity.RemoveEvent(this.handle);
			this.handle = null;
		}
	}

	// Token: 0x040102C9 RID: 66249
	public VInt3 targetPos;

	// Token: 0x040102CA RID: 66250
	public VInt tolerance;

	// Token: 0x040102CB RID: 66251
	public bool moveBack;

	// Token: 0x040102CC RID: 66252
	public bool isRun;

	// Token: 0x040102CD RID: 66253
	private bool pathFinding;

	// Token: 0x040102CE RID: 66254
	private bool bypass;

	// Token: 0x040102CF RID: 66255
	public bool stopable = true;

	// Token: 0x040102D0 RID: 66256
	private BeEventHandle handle;

	// Token: 0x040102D1 RID: 66257
	private int walkUpdateInterval = 500;

	// Token: 0x040102D2 RID: 66258
	private int walkTimeAcc = 500;

	// Token: 0x040102D3 RID: 66259
	private VInt3 lastPosition;

	// Token: 0x040102D4 RID: 66260
	private bool start;

	// Token: 0x040102D5 RID: 66261
	private int stuckTimeAcc;

	// Token: 0x040102D6 RID: 66262
	private int stuckInterval = 1000;

	// Token: 0x040102D7 RID: 66263
	private List<int> steps;

	// Token: 0x040102D8 RID: 66264
	private VInt3 lastPos;

	// Token: 0x040102D9 RID: 66265
	private BeAIManager.MoveDir lastDir;

	// Token: 0x040102DA RID: 66266
	public static readonly VInt2 grid = new VInt2(0.25f, 0.25f);

	// Token: 0x040102DB RID: 66267
	public BeAIManager.DestinationType destinationType;

	// Token: 0x040102DC RID: 66268
	private static readonly VInt tolerance001 = new VInt(0.01f);
}
