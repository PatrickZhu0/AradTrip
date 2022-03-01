using System;

namespace behaviac
{
	// Token: 0x02003BAE RID: 15278
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node49 : Condition
	{
		// Token: 0x06015F0C RID: 89868 RVA: 0x006A0C82 File Offset: 0x0069F082
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node49()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F0D RID: 89869 RVA: 0x006A0C94 File Offset: 0x0069F094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7B0 RID: 63408
		private int opl_p0;
	}
}
