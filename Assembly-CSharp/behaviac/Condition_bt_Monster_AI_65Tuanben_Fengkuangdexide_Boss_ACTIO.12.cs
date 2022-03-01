using System;

namespace behaviac
{
	// Token: 0x02002EBA RID: 11962
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node34 : Condition
	{
		// Token: 0x0601464E RID: 83534 RVA: 0x006221F3 File Offset: 0x006205F3
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node34()
		{
			this.opl_p0 = 21589;
		}

		// Token: 0x0601464F RID: 83535 RVA: 0x00622208 File Offset: 0x00620608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFC2 RID: 57282
		private int opl_p0;
	}
}
