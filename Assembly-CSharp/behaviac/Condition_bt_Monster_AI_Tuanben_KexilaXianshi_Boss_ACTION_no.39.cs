using System;

namespace behaviac
{
	// Token: 0x02003A69 RID: 14953
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node52 : Condition
	{
		// Token: 0x06015C9B RID: 89243 RVA: 0x0069461D File Offset: 0x00692A1D
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node52()
		{
			this.opl_p0 = 21063;
		}

		// Token: 0x06015C9C RID: 89244 RVA: 0x00694630 File Offset: 0x00692A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5CF RID: 62927
		private int opl_p0;
	}
}
