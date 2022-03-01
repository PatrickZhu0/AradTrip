using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

// Token: 0x0200437B RID: 17275
public class Mechanism2068 : BeMechanism
{
	// Token: 0x06017F1F RID: 98079 RVA: 0x0076A247 File Offset: 0x00768647
	public Mechanism2068(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F20 RID: 98080 RVA: 0x0076A272 File Offset: 0x00768672
	public override void OnInit()
	{
		this.per = VFactor.NewVFactor(Mathf.Clamp(100 - TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), 0, 100), GlobalLogic.VALUE_100);
	}

	// Token: 0x06017F21 RID: 98081 RVA: 0x0076A2B1 File Offset: 0x007686B1
	public override void OnStart()
	{
		this.ClearEventHandle();
		this.ResetData();
		this.onReduceDamageEvent = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			VInt3 hitPos = (VInt3)args[5];
			int hurtID = (int)args[1];
			if (this.isAwakeSkill(hurtID))
			{
				return;
			}
			if (this.isFrontDamage(hitPos))
			{
				array[0] = array[0] * this.per;
			}
		});
	}

	// Token: 0x06017F22 RID: 98082 RVA: 0x0076A2DE File Offset: 0x007686DE
	public override void OnFinish()
	{
		this.ClearEventHandle();
		this.ResetData();
	}

	// Token: 0x06017F23 RID: 98083 RVA: 0x0076A2EC File Offset: 0x007686EC
	private void ClearEventHandle()
	{
		if (this.onReduceDamageEvent != null)
		{
			this.onReduceDamageEvent.Remove();
			this.onReduceDamageEvent = null;
		}
	}

	// Token: 0x06017F24 RID: 98084 RVA: 0x0076A30C File Offset: 0x0076870C
	private void ResetData()
	{
		if (this.hurtIDList != null)
		{
			this.hurtIDList.Clear();
		}
		else
		{
			this.hurtIDList = new List<int>();
		}
		if (this.hurtIDList1 != null)
		{
			this.hurtIDList1.Clear();
		}
		else
		{
			this.hurtIDList1 = new List<int>();
		}
	}

	// Token: 0x06017F25 RID: 98085 RVA: 0x0076A368 File Offset: 0x00768768
	private bool isFrontDamage(VInt3 hitPos)
	{
		if (!base.owner.GetFace())
		{
			if (hitPos.x - base.owner.GetPosition().x >= 0)
			{
				return true;
			}
		}
		else if (base.owner.GetPosition().x - hitPos.x >= 0)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06017F26 RID: 98086 RVA: 0x0076A3D4 File Offset: 0x007687D4
	private bool isAwakeSkill(int hurtID)
	{
		if (this.hurtIDList == null || this.hurtIDList1 == null)
		{
			return false;
		}
		if (this.hurtIDList.Contains(hurtID))
		{
			return true;
		}
		if (this.hurtIDList1.Contains(hurtID))
		{
			return false;
		}
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			this.hurtIDList1.Add(hurtID);
			return false;
		}
		SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(tableItem.SkillID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			this.hurtIDList1.Add(hurtID);
			return false;
		}
		if (tableItem2.SkillCategory == 4)
		{
			this.hurtIDList.Add(hurtID);
			return true;
		}
		this.hurtIDList1.Add(hurtID);
		return false;
	}

	// Token: 0x040113D8 RID: 70616
	private VFactor per = VFactor.zero;

	// Token: 0x040113D9 RID: 70617
	private BeEventHandle onReduceDamageEvent;

	// Token: 0x040113DA RID: 70618
	private List<int> hurtIDList = new List<int>();

	// Token: 0x040113DB RID: 70619
	private List<int> hurtIDList1 = new List<int>();
}
