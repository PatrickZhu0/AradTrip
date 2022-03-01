using System;

namespace behaviac
{
	// Token: 0x02003D29 RID: 15657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node11 : Condition
	{
		// Token: 0x060161EC RID: 90604 RVA: 0x006AFDF9 File Offset: 0x006AE1F9
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node11()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x060161ED RID: 90605 RVA: 0x006AFE0C File Offset: 0x006AE20C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA65 RID: 64101
		private int opl_p0;
	}
}
