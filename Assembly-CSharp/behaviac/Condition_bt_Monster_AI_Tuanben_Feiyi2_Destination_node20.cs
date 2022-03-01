using System;

namespace behaviac
{
	// Token: 0x020039A9 RID: 14761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node20 : Condition
	{
		// Token: 0x06015B26 RID: 88870 RVA: 0x0068DA41 File Offset: 0x0068BE41
		public Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node20()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015B27 RID: 88871 RVA: 0x0068DA54 File Offset: 0x0068BE54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AA RID: 62634
		private float opl_p0;
	}
}
