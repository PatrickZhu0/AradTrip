using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200421E RID: 16926
internal class Buff183211 : BeBuff
{
	// Token: 0x060176D9 RID: 95961 RVA: 0x007327B2 File Offset: 0x00730BB2
	public Buff183211(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176DA RID: 95962 RVA: 0x007327CC File Offset: 0x00730BCC
	public override void OnInit()
	{
		this.maxCount = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
		this.intervel = TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true);
		for (int i = 0; i < this.buffData.ValueC.Count; i++)
		{
			this.skillList.Add(TableManager.GetValueFromUnionCell(this.buffData.ValueC[i], this.level, true));
		}
	}

	// Token: 0x060176DB RID: 95963 RVA: 0x00732877 File Offset: 0x00730C77
	public override void OnStart()
	{
		this.count = this.maxCount;
		this.timer = 0;
		this.decreaseFlag = false;
		this.handle = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] args)
		{
			if (this.decreaseFlag)
			{
				base.owner.buffController.RemoveBuffByBuffInfoID(183206);
				base.owner.buffController.RemoveBuffByBuffInfoID(1832060);
				this.decreaseFlag = false;
			}
		});
	}

	// Token: 0x060176DC RID: 95964 RVA: 0x007328B4 File Offset: 0x00730CB4
	public override void OnUpdate(int delta)
	{
		if (base.owner != null && base.owner.isLocalActor && this.system == null)
		{
			this.system = (Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle);
			if (this.system != null)
			{
				this.system.SetMuscleShiftActive(true);
				this.system.SetMuscleShiftCount(this.count);
			}
		}
		if (this.count < this.maxCount)
		{
			this.timer += delta;
			if (this.system != null)
			{
				this.system.SetMuscleShiftCD((float)this.timer / (float)this.intervel);
			}
			if (this.timer >= this.intervel)
			{
				this.Increase();
				this.timer = 0;
			}
		}
	}

	// Token: 0x060176DD RID: 95965 RVA: 0x00732986 File Offset: 0x00730D86
	public void Increase()
	{
		if (this.count < this.maxCount)
		{
			this.count++;
			if (this.system != null)
			{
				this.system.SetMuscleShiftCount(this.count);
			}
		}
	}

	// Token: 0x060176DE RID: 95966 RVA: 0x007329C3 File Offset: 0x00730DC3
	public void Decrease(int curSkillId, int skillId)
	{
		if (this.count > 0)
		{
			this.count--;
			this.decreaseFlag = true;
			if (this.system != null)
			{
				this.system.SetMuscleShiftCount(this.count);
			}
		}
	}

	// Token: 0x060176DF RID: 95967 RVA: 0x00732A04 File Offset: 0x00730E04
	public override void OnFinish()
	{
		if (this.system != null)
		{
			this.system.SetMuscleShiftActive(false);
		}
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		this.skillList.Clear();
	}

	// Token: 0x060176E0 RID: 95968 RVA: 0x00732A50 File Offset: 0x00730E50
	public virtual bool CanUseSkill(int curSkillId, int skillId)
	{
		return this.count > 0 && curSkillId != skillId && this.skillList.Contains(curSkillId) && this.skillList.Contains(skillId) && (base.owner.GetPosition().z <= 0 || (base.owner.GetPosition().z > 0 && skillId == 3113));
	}

	// Token: 0x04010D21 RID: 68897
	protected int maxCount;

	// Token: 0x04010D22 RID: 68898
	private int intervel;

	// Token: 0x04010D23 RID: 68899
	private List<int> skillList = new List<int>();

	// Token: 0x04010D24 RID: 68900
	protected ClientSystemBattle system;

	// Token: 0x04010D25 RID: 68901
	private BeEventHandle handle;

	// Token: 0x04010D26 RID: 68902
	protected int count;

	// Token: 0x04010D27 RID: 68903
	private int timer;

	// Token: 0x04010D28 RID: 68904
	private bool decreaseFlag;
}
