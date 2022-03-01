using System;

namespace behaviac
{
	// Token: 0x02003585 RID: 13701
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601533C RID: 86844 RVA: 0x00663D87 File Offset: 0x00662187
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node13()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601533D RID: 86845 RVA: 0x00663D9C File Offset: 0x0066219C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECFE RID: 60670
		private float opl_p0;
	}
}
