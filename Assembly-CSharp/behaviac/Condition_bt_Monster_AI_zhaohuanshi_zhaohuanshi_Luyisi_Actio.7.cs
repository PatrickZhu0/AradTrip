using System;

namespace behaviac
{
	// Token: 0x02003FD5 RID: 16341
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node17 : Condition
	{
		// Token: 0x06016712 RID: 91922 RVA: 0x006CA6BA File Offset: 0x006C8ABA
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node17()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016713 RID: 91923 RVA: 0x006CA6D0 File Offset: 0x006C8AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF64 RID: 65380
		private float opl_p0;
	}
}
