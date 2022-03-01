using System;

namespace behaviac
{
	// Token: 0x02003BB8 RID: 15288
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node53 : Condition
	{
		// Token: 0x06015F20 RID: 89888 RVA: 0x006A0FE6 File Offset: 0x0069F3E6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node53()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F21 RID: 89889 RVA: 0x006A0FF8 File Offset: 0x0069F3F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7BA RID: 63418
		private int opl_p0;
	}
}
