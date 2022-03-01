using System;

namespace behaviac
{
	// Token: 0x02003CF1 RID: 15601
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node85 : Condition
	{
		// Token: 0x06016181 RID: 90497 RVA: 0x006ADEC3 File Offset: 0x006AC2C3
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06016182 RID: 90498 RVA: 0x006ADED4 File Offset: 0x006AC2D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA1F RID: 64031
		private int opl_p0;
	}
}
