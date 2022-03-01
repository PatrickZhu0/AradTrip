using System;
using System.Collections.Generic;

// Token: 0x020042CD RID: 17101
public class Mechanism1157 : BeMechanism
{
	// Token: 0x06017AA1 RID: 96929 RVA: 0x0074B080 File Offset: 0x00749480
	public Mechanism1157(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AA2 RID: 96930 RVA: 0x0074B0A0 File Offset: 0x007494A0
	public override void OnInit()
	{
		base.OnInit();
		this._addSkillDamageDataList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1157.AddSkillDamageData item = default(Mechanism1157.AddSkillDamageData);
			item.SkillId = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.BuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this._addSkillDamageDataList.Add(item);
		}
	}

	// Token: 0x06017AA3 RID: 96931 RVA: 0x0074B145 File Offset: 0x00749545
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017AA4 RID: 96932 RVA: 0x0074B154 File Offset: 0x00749554
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onPassedDoor, new BeEventHandle.Del(this._OnPassedDoor));
		this.handleB = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, new BeEventHandle.Del(this._OnDeadTowerEnterNextLayer));
		this.handleC = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this._OnBeforeHit));
	}

	// Token: 0x06017AA5 RID: 96933 RVA: 0x0074B1BD File Offset: 0x007495BD
	private void _OnPassedDoor(object[] args)
	{
		this._attackTargetPidList.Clear();
	}

	// Token: 0x06017AA6 RID: 96934 RVA: 0x0074B1CA File Offset: 0x007495CA
	private void _OnDeadTowerEnterNextLayer(object[] args)
	{
		this._attackTargetPidList.Clear();
	}

	// Token: 0x06017AA7 RID: 96935 RVA: 0x0074B1D8 File Offset: 0x007495D8
	private void _OnBeforeHit(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor.attribute.GetHPRate() < VFactor.one)
		{
			return;
		}
		if (this._attackTargetPidList.Contains(beActor.GetPID()))
		{
			return;
		}
		int skillId = (int)args[3];
		if (!this._CheckAddBuffInfo(skillId))
		{
			return;
		}
		this._attackTargetPidList.Add(beActor.GetPID());
	}

	// Token: 0x06017AA8 RID: 96936 RVA: 0x0074B250 File Offset: 0x00749650
	private bool _CheckAddBuffInfo(int skillId)
	{
		for (int i = 0; i < this._addSkillDamageDataList.Count; i++)
		{
			Mechanism1157.AddSkillDamageData addSkillDamageData = this._addSkillDamageDataList[i];
			if (addSkillDamageData.SkillId == skillId)
			{
				base.owner.buffController.TryAddBuffInfo(addSkillDamageData.BuffInfoId, base.owner, this.level);
				return true;
			}
		}
		return false;
	}

	// Token: 0x04011016 RID: 69654
	private List<Mechanism1157.AddSkillDamageData> _addSkillDamageDataList = new List<Mechanism1157.AddSkillDamageData>();

	// Token: 0x04011017 RID: 69655
	private int _buffId;

	// Token: 0x04011018 RID: 69656
	private List<int> _attackTargetPidList = new List<int>();

	// Token: 0x020042CE RID: 17102
	private struct AddSkillDamageData
	{
		// Token: 0x04011019 RID: 69657
		public int SkillId;

		// Token: 0x0401101A RID: 69658
		public int BuffInfoId;
	}
}
