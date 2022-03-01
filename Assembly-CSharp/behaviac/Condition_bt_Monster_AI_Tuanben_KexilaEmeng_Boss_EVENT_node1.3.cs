using System;

namespace behaviac
{
	// Token: 0x02003A04 RID: 14852
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node12 : Condition
	{
		// Token: 0x06015BD6 RID: 89046 RVA: 0x00690DDA File Offset: 0x0068F1DA
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node12()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015BD7 RID: 89047 RVA: 0x00690DEC File Offset: 0x0068F1EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 42000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4FD RID: 62717
		private int opl_p0;
	}
}
