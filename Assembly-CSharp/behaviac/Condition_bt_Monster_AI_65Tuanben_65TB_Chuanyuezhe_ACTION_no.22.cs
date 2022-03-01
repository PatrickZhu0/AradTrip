using System;

namespace behaviac
{
	// Token: 0x02002B60 RID: 11104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node51 : Condition
	{
		// Token: 0x06013FCE RID: 81870 RVA: 0x005FFE2B File Offset: 0x005FE22B
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node51()
		{
			this.opl_p0 = 21846;
		}

		// Token: 0x06013FCF RID: 81871 RVA: 0x005FFE40 File Offset: 0x005FE240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9E7 RID: 55783
		private int opl_p0;
	}
}
