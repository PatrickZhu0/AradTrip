using System;

namespace behaviac
{
	// Token: 0x02003AEE RID: 15086
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node8 : Condition
	{
		// Token: 0x06015D99 RID: 89497 RVA: 0x0069A4B5 File Offset: 0x006988B5
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node8()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x06015D9A RID: 89498 RVA: 0x0069A4C8 File Offset: 0x006988C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A0 RID: 63136
		private int opl_p0;
	}
}
