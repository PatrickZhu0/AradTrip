using System;
using System.Collections.Generic;

// Token: 0x0200433F RID: 17215
public class Mechanism2009 : BeMechanism
{
	// Token: 0x06017D3A RID: 97594 RVA: 0x0075C8B4 File Offset: 0x0075ACB4
	public Mechanism2009(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017D3B RID: 97595 RVA: 0x0075C924 File Offset: 0x0075AD24
	public override void OnInit()
	{
		base.OnInit();
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017D3C RID: 97596 RVA: 0x0075C9B0 File Offset: 0x0075ADB0
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindMainActor(list);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			BeEventHandle item = this.RegistAddHandle(beActor);
			BeEventHandle item2 = beActor.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor2 = args[0] as BeActor;
				if (this.MonsterIDEqual(beActor2))
				{
					BeEventHandle item3 = this.RegistAddHandle(beActor2);
					this.handleList.Add(item3);
				}
			});
			this.handleList.Add(item);
			this.handleList.Add(item2);
		}
	}

	// Token: 0x06017D3D RID: 97597 RVA: 0x0075CA34 File Offset: 0x0075AE34
	private bool MonsterIDEqual(BeActor monster)
	{
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			if (monster.GetEntityData().MonsterIDEqual(this.monsterIDs[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017D3E RID: 97598 RVA: 0x0075CA78 File Offset: 0x0075AE78
	private BeEventHandle RegistAddHandle(BeActor actor)
	{
		return actor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.buffID)
			{
				this.target.Add(actor);
				if (!this.isMoving)
				{
					this.MoveToTarget(this.target[0]);
				}
			}
		});
	}

	// Token: 0x06017D3F RID: 97599 RVA: 0x0075CAB4 File Offset: 0x0075AEB4
	private void MoveToTarget(BeActor target)
	{
		if (target == null)
		{
			return;
		}
		this.isMoving = true;
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			if (base.owner.aiManager != null)
			{
				base.owner.aiManager.Stop();
			}
			this.tmpPos = target.GetPosition();
			base.owner.SetFace(target.GetPosition().x - base.owner.GetPosition().x < 0, true, false);
			BeMoveTo action = BeMoveTo.Create(base.owner, this.time, base.owner.GetPosition(), target.GetPosition(), false, null, false);
			base.owner.actionManager.RunAction(action);
			base.owner.m_pkGeActor.ChangeAction("Anim_Walk", 1f, true, true, false);
		}
	}

	// Token: 0x06017D40 RID: 97600 RVA: 0x0075CBA0 File Offset: 0x0075AFA0
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.target.Count <= 0)
		{
			return;
		}
		if (this.target[0] == null || this.target[0].IsDead())
		{
			if (base.owner.aiManager != null)
			{
				base.owner.aiManager.Start();
			}
			return;
		}
		if (this.IsNearTargetPosition() && this.isMoving)
		{
			this.isMoving = false;
			base.owner.UseSkill(this.skillID, false);
			this.target.RemoveAt(0);
			if (this.target.Count > 0)
			{
				base.owner.delayCaller.DelayCall(4000, delegate
				{
					if (this.target.Count > 0)
					{
						this.MoveToTarget(this.target[0]);
					}
				}, 0, 0, false);
			}
			else if (base.owner.aiManager != null)
			{
				base.owner.aiManager.Start();
			}
		}
	}

	// Token: 0x06017D41 RID: 97601 RVA: 0x0075CCA8 File Offset: 0x0075B0A8
	public bool IsNearTargetPosition()
	{
		int i = this.tolerance.i;
		int magnitude = (base.owner.GetPosition() - this.tmpPos).magnitude;
		return magnitude <= i;
	}

	// Token: 0x06017D42 RID: 97602 RVA: 0x0075CCE7 File Offset: 0x0075B0E7
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandleList();
	}

	// Token: 0x06017D43 RID: 97603 RVA: 0x0075CCF8 File Offset: 0x0075B0F8
	private void RemoveHandleList()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x0401125E RID: 70238
	private int buffID;

	// Token: 0x0401125F RID: 70239
	private int actionSpeed = 250;

	// Token: 0x04011260 RID: 70240
	private int time = 5000;

	// Token: 0x04011261 RID: 70241
	private VInt tolerance = VInt.Float2VIntValue(0.5f);

	// Token: 0x04011262 RID: 70242
	private List<BeActor> target = new List<BeActor>();

	// Token: 0x04011263 RID: 70243
	private int skillID;

	// Token: 0x04011264 RID: 70244
	private bool isMoving;

	// Token: 0x04011265 RID: 70245
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011266 RID: 70246
	private int[] monsterIDs = new int[]
	{
		31140011,
		31130011,
		31150011,
		31160011,
		31170011
	};

	// Token: 0x04011267 RID: 70247
	private VInt3 tmpPos;
}
