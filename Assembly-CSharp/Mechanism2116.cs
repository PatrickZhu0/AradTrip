using System;
using System.Collections.Generic;

// Token: 0x020043B0 RID: 17328
public class Mechanism2116 : BeMechanism
{
	// Token: 0x06018083 RID: 98435 RVA: 0x00775A00 File Offset: 0x00773E00
	public Mechanism2116(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018084 RID: 98436 RVA: 0x00775A2C File Offset: 0x00773E2C
	public override void OnInit()
	{
		this.m_MonsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_ActionID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_ActionDelay = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.m_ActionInterval = Math.Max(300, TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true));
		this.m_Type = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_SkillID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		for (int i = 0; i < this.data.ValueF.Count; i++)
		{
			this.m_IndexList.Add(TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true));
		}
	}

	// Token: 0x06018085 RID: 98437 RVA: 0x00775B81 File Offset: 0x00773F81
	public override void OnStart()
	{
		this.ResetData();
		this.SearchMonster();
		this.RegistEvent();
	}

	// Token: 0x06018086 RID: 98438 RVA: 0x00775B95 File Offset: 0x00773F95
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateAction(deltaTime);
	}

	// Token: 0x06018087 RID: 98439 RVA: 0x00775B9E File Offset: 0x00773F9E
	public override void OnFinish()
	{
		this.ResetData();
	}

	// Token: 0x06018088 RID: 98440 RVA: 0x00775BA8 File Offset: 0x00773FA8
	private void UpdateAction(int deltaTime)
	{
		if (this.m_EventBuffID <= 0)
		{
			return;
		}
		this.m_ActionDelayAcc += deltaTime;
		if (this.m_ActionDelayAcc >= this.m_ActionDelay)
		{
			this.m_ActionDelayAcc -= this.m_ActionInterval;
			this.DoMonsterAction();
		}
	}

	// Token: 0x06018089 RID: 98441 RVA: 0x00775BFC File Offset: 0x00773FFC
	private void DoMonsterAction()
	{
		if (this.m_Type == 1)
		{
			for (int i = 0; i < this.m_IndexList.Count; i++)
			{
				int num = this.m_IndexList[i];
				if (num >= 0 && num < this.m_MonsterList.Count)
				{
					this.m_MonsterList[num].UseSkill(this.m_SkillID, true);
				}
			}
		}
		else if (this.m_Type == 2)
		{
			if (this.m_IndexList.Count == 0)
			{
				return;
			}
			int num2 = this.m_IndexList[0];
			if (num2 < this.m_MonsterList.Count)
			{
				for (int j = 0; j < num2; j++)
				{
					int index = base.FrameRandom.InRange(j, this.m_MonsterList.Count);
					BeActor value = this.m_MonsterList[j];
					this.m_MonsterList[j] = this.m_MonsterList[index];
					this.m_MonsterList[index] = value;
				}
			}
			else
			{
				num2 = this.m_MonsterList.Count;
			}
			for (int k = 0; k < num2; k++)
			{
				this.m_MonsterList[k].UseSkill(this.m_SkillID, true);
			}
		}
	}

	// Token: 0x0601808A RID: 98442 RVA: 0x00775D59 File Offset: 0x00774159
	private void ResetData()
	{
		this.m_EventBuffID = 0;
		this.m_ActionDelayAcc = 0;
	}

	// Token: 0x0601808B RID: 98443 RVA: 0x00775D6C File Offset: 0x0077416C
	private void RegistEvent()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.OnAddBuffEvent));
			this.handleB = base.owner.RegisterEvent(BeEventType.onBuffCancel, new BeEventHandle.Del(this.OnCancelBuffEvent));
		}
	}

	// Token: 0x0601808C RID: 98444 RVA: 0x00775DC8 File Offset: 0x007741C8
	private void OnAddBuffEvent(object[] args)
	{
		if (this.m_EventBuffID > 0)
		{
			return;
		}
		if (args.Length == 0)
		{
			return;
		}
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff != null && this.m_ActionID == beBuff.buffID)
		{
			this.m_EventBuffID = beBuff.buffID;
		}
	}

	// Token: 0x0601808D RID: 98445 RVA: 0x00775E18 File Offset: 0x00774218
	private void OnCancelBuffEvent(object[] args)
	{
		if (this.m_EventBuffID <= 0)
		{
			return;
		}
		if (args.Length == 0)
		{
			return;
		}
		int num = (int)args[0];
		if (num == this.m_ActionID)
		{
			this.ResetData();
		}
	}

	// Token: 0x0601808E RID: 98446 RVA: 0x00775E58 File Offset: 0x00774258
	private void SearchMonster()
	{
		this.m_MonsterList.Clear();
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			base.owner.CurrentBeScene.FindActorById(this.m_MonsterList, this.m_MonsterID);
			this.m_MonsterList.Sort(new Comparison<BeActor>(this._SortMonster));
		}
	}

	// Token: 0x0601808F RID: 98447 RVA: 0x00775EC0 File Offset: 0x007742C0
	private int _SortMonster(BeActor left, BeActor right)
	{
		if (left == null)
		{
			return 1;
		}
		if (right == null)
		{
			return -1;
		}
		int num = left.GetPosition().x - right.GetPosition().x;
		if (num == 0)
		{
			return left.GetPID() - right.GetPID();
		}
		return num;
	}

	// Token: 0x04011509 RID: 70921
	protected int m_Type;

	// Token: 0x0401150A RID: 70922
	protected int m_SkillID;

	// Token: 0x0401150B RID: 70923
	protected List<int> m_IndexList = new List<int>();

	// Token: 0x0401150C RID: 70924
	protected int m_MonsterID;

	// Token: 0x0401150D RID: 70925
	protected List<BeActor> m_MonsterList = new List<BeActor>();

	// Token: 0x0401150E RID: 70926
	protected int m_ActionID;

	// Token: 0x0401150F RID: 70927
	protected int m_ActionDelay;

	// Token: 0x04011510 RID: 70928
	protected int m_ActionInterval = int.MaxValue;

	// Token: 0x04011511 RID: 70929
	protected int m_ActionDelayAcc;

	// Token: 0x04011512 RID: 70930
	protected int m_EventBuffID;
}
