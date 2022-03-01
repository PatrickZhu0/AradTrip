using System;

namespace behaviac
{
	// Token: 0x02002EE8 RID: 12008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node81 : Condition
	{
		// Token: 0x060146AA RID: 83626 RVA: 0x0062339D File Offset: 0x0062179D
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node81()
		{
			this.opl_p0 = 21597;
		}

		// Token: 0x060146AB RID: 83627 RVA: 0x006233B0 File Offset: 0x006217B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E025 RID: 57381
		private int opl_p0;
	}
}
