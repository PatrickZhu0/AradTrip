using System;

namespace behaviac
{
	// Token: 0x0200357F RID: 13695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node7 : Condition
	{
		// Token: 0x06015330 RID: 86832 RVA: 0x00663BAF File Offset: 0x00661FAF
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node7()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015331 RID: 86833 RVA: 0x00663BC4 File Offset: 0x00661FC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF2 RID: 60658
		private float opl_p0;
	}
}
