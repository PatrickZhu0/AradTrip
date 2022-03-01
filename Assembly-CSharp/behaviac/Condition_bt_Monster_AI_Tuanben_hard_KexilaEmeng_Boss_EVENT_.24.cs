using System;

namespace behaviac
{
	// Token: 0x02003BF6 RID: 15350
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node12 : Condition
	{
		// Token: 0x06015F99 RID: 90009 RVA: 0x006A33A2 File Offset: 0x006A17A2
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node12()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F9A RID: 90010 RVA: 0x006A33B4 File Offset: 0x006A17B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 42000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F828 RID: 63528
		private int opl_p0;
	}
}
