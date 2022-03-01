using System;

namespace behaviac
{
	// Token: 0x02003C00 RID: 15360
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node25 : Condition
	{
		// Token: 0x06015FAC RID: 90028 RVA: 0x006A35CF File Offset: 0x006A19CF
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node25()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06015FAD RID: 90029 RVA: 0x006A35E0 File Offset: 0x006A19E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 30000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F834 RID: 63540
		private int opl_p0;
	}
}
