using System;

namespace behaviac
{
	// Token: 0x02002BBF RID: 11199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5 : Condition
	{
		// Token: 0x06014082 RID: 82050 RVA: 0x0060430D File Offset: 0x0060270D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5()
		{
			this.opl_p0 = 87320031;
		}

		// Token: 0x06014083 RID: 82051 RVA: 0x00604320 File Offset: 0x00602720
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA75 RID: 55925
		private int opl_p0;
	}
}
