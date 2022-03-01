using System;

namespace behaviac
{
	// Token: 0x02003588 RID: 13704
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node16 : Condition
	{
		// Token: 0x06015342 RID: 86850 RVA: 0x00663E73 File Offset: 0x00662273
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node16()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015343 RID: 86851 RVA: 0x00663E88 File Offset: 0x00662288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED04 RID: 60676
		private float opl_p0;
	}
}
