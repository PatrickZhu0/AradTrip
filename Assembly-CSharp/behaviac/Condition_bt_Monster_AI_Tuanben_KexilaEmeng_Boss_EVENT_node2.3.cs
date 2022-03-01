using System;

namespace behaviac
{
	// Token: 0x02003A0E RID: 14862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node25 : Condition
	{
		// Token: 0x06015BE9 RID: 89065 RVA: 0x00691007 File Offset: 0x0068F407
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node25()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06015BEA RID: 89066 RVA: 0x00691018 File Offset: 0x0068F418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 30000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F509 RID: 62729
		private int opl_p0;
	}
}
