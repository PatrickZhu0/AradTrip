using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043B1 RID: 17329
public class Mechanism2117 : BeMechanism
{
	// Token: 0x06018090 RID: 98448 RVA: 0x00775F10 File Offset: 0x00774310
	public Mechanism2117(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018091 RID: 98449 RVA: 0x00775F1C File Offset: 0x0077431C
	public override void OnInit()
	{
		base.OnInit();
		this.m_FallPreProtect = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.m_FallPostProtect = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018092 RID: 98450 RVA: 0x00775F93 File Offset: 0x00774393
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeHurtValue, new BeEventHandle.Del(this.OnHurt));
	}

	// Token: 0x06018093 RID: 98451 RVA: 0x00775FBC File Offset: 0x007743BC
	private void OnHurt(object[] args)
	{
		if (!this.Enable())
		{
			return;
		}
		int[] array = (int[])args[0];
		int i = array[0];
		VFactor fallProtectHurtFactor = this.GetFallProtectHurtFactor();
		array[0] = i * fallProtectHurtFactor;
		if (args[1] == null)
		{
			return;
		}
		List<int> list = args[1] as List<int>;
		if (list == null)
		{
			return;
		}
		for (int j = 0; j < list.Count; j++)
		{
			List<int> list2;
			int index;
			(list2 = list)[index = j] = list2[index] * fallProtectHurtFactor;
		}
		args[1] = list;
	}

	// Token: 0x06018094 RID: 98452 RVA: 0x00776048 File Offset: 0x00774448
	private bool Enable()
	{
		return base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.PKFallProtectHurtRate) && base.owner.isMainActor && base.owner.protectManager != null && base.owner.protectManager.IsEnable() && BattleMain.IsProtectFloat(base.battleType);
	}

	// Token: 0x06018095 RID: 98453 RVA: 0x007760C8 File Offset: 0x007744C8
	private VFactor GetFallProtectHurtFactor()
	{
		VFactor result = VFactor.one;
		BeProtect protectManager = base.owner.protectManager;
		if (protectManager == null)
		{
			return result;
		}
		if (protectManager.FallHurtCounting)
		{
			if (protectManager.FallHurtEffect > 0)
			{
				result = this.m_FallPostProtect;
			}
			else
			{
				result = this.m_FallPreProtect;
			}
		}
		return result;
	}

	// Token: 0x04011513 RID: 70931
	private VFactor m_FallPreProtect;

	// Token: 0x04011514 RID: 70932
	private VFactor m_FallPostProtect;
}
