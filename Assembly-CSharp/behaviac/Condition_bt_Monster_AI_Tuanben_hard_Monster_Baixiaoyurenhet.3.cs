using System;

namespace behaviac
{
	// Token: 0x02003D05 RID: 15621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node11 : Condition
	{
		// Token: 0x060161A8 RID: 90536 RVA: 0x006AE9E1 File Offset: 0x006ACDE1
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node11()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x060161A9 RID: 90537 RVA: 0x006AE9F4 File Offset: 0x006ACDF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA3B RID: 64059
		private int opl_p0;
	}
}
