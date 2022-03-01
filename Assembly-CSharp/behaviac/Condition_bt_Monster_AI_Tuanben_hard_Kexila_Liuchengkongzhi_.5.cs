using System;

namespace behaviac
{
	// Token: 0x02003CF6 RID: 15606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node11 : Condition
	{
		// Token: 0x0601618B RID: 90507 RVA: 0x006AE073 File Offset: 0x006AC473
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node11()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x0601618C RID: 90508 RVA: 0x006AE084 File Offset: 0x006AC484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA26 RID: 64038
		private int opl_p0;
	}
}
