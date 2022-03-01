using System;

namespace behaviac
{
	// Token: 0x02003BF2 RID: 15346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node4 : Condition
	{
		// Token: 0x06015F91 RID: 90001 RVA: 0x006A32C2 File Offset: 0x006A16C2
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node4()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F92 RID: 90002 RVA: 0x006A32D4 File Offset: 0x006A16D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 40000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F825 RID: 63525
		private int opl_p0;
	}
}
