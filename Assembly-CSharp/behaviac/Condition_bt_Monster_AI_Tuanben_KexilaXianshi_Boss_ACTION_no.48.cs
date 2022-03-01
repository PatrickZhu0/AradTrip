using System;

namespace behaviac
{
	// Token: 0x02003A74 RID: 14964
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node65 : Condition
	{
		// Token: 0x06015CB1 RID: 89265 RVA: 0x00694AD5 File Offset: 0x00692ED5
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node65()
		{
			this.opl_p0 = 21050;
		}

		// Token: 0x06015CB2 RID: 89266 RVA: 0x00694AE8 File Offset: 0x00692EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5EC RID: 62956
		private int opl_p0;
	}
}
