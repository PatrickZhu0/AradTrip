using System;

namespace behaviac
{
	// Token: 0x02002C9E RID: 11422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node20 : Condition
	{
		// Token: 0x06014233 RID: 82483 RVA: 0x0060C0C9 File Offset: 0x0060A4C9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node20()
		{
			this.opl_p0 = 20755;
		}

		// Token: 0x06014234 RID: 82484 RVA: 0x0060C0DC File Offset: 0x0060A4DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBED RID: 56301
		private int opl_p0;
	}
}
