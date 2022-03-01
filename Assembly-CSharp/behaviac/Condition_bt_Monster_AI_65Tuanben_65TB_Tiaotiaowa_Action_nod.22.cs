using System;

namespace behaviac
{
	// Token: 0x02002CFD RID: 11517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node55 : Condition
	{
		// Token: 0x060142EA RID: 82666 RVA: 0x0060F53D File Offset: 0x0060D93D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node55()
		{
			this.opl_p0 = 20745;
		}

		// Token: 0x060142EB RID: 82667 RVA: 0x0060F550 File Offset: 0x0060D950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC93 RID: 56467
		private int opl_p0;
	}
}
