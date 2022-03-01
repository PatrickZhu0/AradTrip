using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x02004347 RID: 17223
public class Mechanism2017 : BeMechanism
{
	// Token: 0x06017D7D RID: 97661 RVA: 0x0075E40D File Offset: 0x0075C80D
	public Mechanism2017(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D7E RID: 97662 RVA: 0x0075E430 File Offset: 0x0075C830
	public override void OnInit()
	{
		base.OnInit();
		this.hurtMaxLimit = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.skillIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017D7F RID: 97663 RVA: 0x0075E4B9 File Offset: 0x0075C8B9
	public override void OnStart()
	{
		base.OnStart();
		this.SetEquipDataAdd();
		this.RegisterHurtEvent();
	}

	// Token: 0x06017D80 RID: 97664 RVA: 0x0075E4CD File Offset: 0x0075C8CD
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x06017D81 RID: 97665 RVA: 0x0075E4DC File Offset: 0x0075C8DC
	private void RegisterHurtEvent()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
		{
			int id = (int)args[1];
			EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(id, string.Empty, string.Empty);
			int[] damageArr = (int[])args[0];
			bool[] absorbDamage = (bool[])args[2];
			this.AbsorbHurt(damageArr, tableItem, absorbDamage);
		});
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.OnJudgeGrab, new BeEvent.BeEventHandleNew.Function(this._OnJudgeGrab));
	}

	// Token: 0x06017D82 RID: 97666 RVA: 0x0075E534 File Offset: 0x0075C934
	private void _OnJudgeGrab(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (!this.skillIdList.Contains(@int))
		{
			param.m_Bool = false;
		}
	}

	// Token: 0x06017D83 RID: 97667 RVA: 0x0075E560 File Offset: 0x0075C960
	private void AbsorbHurt(int[] damageArr, EffectTable hurtData, bool[] absorbDamage)
	{
		if (hurtData.DamageType == EffectTable.eDamageType.MAGIC)
		{
			return;
		}
		if (damageArr[0] == 0)
		{
			return;
		}
		EventParam eventParam = base.owner.TriggerEventNew(BeEventType.onShengguangshouhuAbsorbDamage, new EventParam
		{
			m_Obj = hurtData,
			m_Bool = false,
			m_Int = damageArr[0]
		});
		damageArr[0] = eventParam.m_Int;
		if (eventParam.m_Bool)
		{
			damageArr[0] = 0;
			absorbDamage[0] = true;
			return;
		}
		this.totalHurtValue += damageArr[0];
		damageArr[0] = 0;
		absorbDamage[0] = true;
		this.ShowHitNumber();
		if (this.totalHurtValue >= this.hurtMaxLimit)
		{
			this.RemoveAll();
		}
	}

	// Token: 0x06017D84 RID: 97668 RVA: 0x0075E60C File Offset: 0x0075CA0C
	private void ShowHitNumber()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			return;
		}
		if (clientSystemBattle.comShowHit == null)
		{
			return;
		}
		clientSystemBattle.comShowHit.ShowHitNumber(0, null, base.owner.m_iID, base.owner.GetGePosition(PositionType.OVERHEAD), base.owner.GetFace(), HitTextType.NORMAL, null, base.owner);
	}

	// Token: 0x06017D85 RID: 97669 RVA: 0x0075E673 File Offset: 0x0075CA73
	private void RemoveAll()
	{
		if (this.attachBuff != null)
		{
			base.owner.buffController.RemoveBuff(this.attachBuff);
		}
	}

	// Token: 0x06017D86 RID: 97670 RVA: 0x0075E698 File Offset: 0x0075CA98
	private void RemoveHandle()
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

	// Token: 0x06017D87 RID: 97671 RVA: 0x0075E6FC File Offset: 0x0075CAFC
	private void SetEquipDataAdd()
	{
		List<BeMechanism> mechanismList = base.owner.MechanismList;
		if (mechanismList == null)
		{
			return;
		}
		for (int i = 0; i < mechanismList.Count; i++)
		{
			Mechanism2030 mechanism = mechanismList[i] as Mechanism2030;
			if (mechanism != null)
			{
				this.hurtMaxLimit *= VFactor.one + VFactor.NewVFactor(mechanism.hurtMaxLimitAddRate, GlobalLogic.VALUE_1000);
			}
		}
	}

	// Token: 0x04011289 RID: 70281
	private int hurtMaxLimit;

	// Token: 0x0401128A RID: 70282
	private List<int> skillIdList = new List<int>();

	// Token: 0x0401128B RID: 70283
	private int totalHurtValue;

	// Token: 0x0401128C RID: 70284
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
