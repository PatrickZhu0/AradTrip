using System;

namespace behaviac
{
	// Token: 0x02002EC7 RID: 11975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node22 : Condition
	{
		// Token: 0x06014668 RID: 83560 RVA: 0x006225A3 File Offset: 0x006209A3
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node22()
		{
			this.opl_p0 = 21598;
		}

		// Token: 0x06014669 RID: 83561 RVA: 0x006225B8 File Offset: 0x006209B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFD3 RID: 57299
		private int opl_p0;
	}
}
