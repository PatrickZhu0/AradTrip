using System;

namespace behaviac
{
	// Token: 0x02004030 RID: 16432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node5 : Condition
	{
		// Token: 0x060167C0 RID: 92096 RVA: 0x006CE493 File Offset: 0x006CC893
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node5()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060167C1 RID: 92097 RVA: 0x006CE4C8 File Offset: 0x006CC8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401000B RID: 65547
		private int opl_p0;

		// Token: 0x0401000C RID: 65548
		private int opl_p1;

		// Token: 0x0401000D RID: 65549
		private int opl_p2;

		// Token: 0x0401000E RID: 65550
		private int opl_p3;
	}
}
