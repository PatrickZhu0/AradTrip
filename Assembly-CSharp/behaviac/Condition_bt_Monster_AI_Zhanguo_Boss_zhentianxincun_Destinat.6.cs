using System;

namespace behaviac
{
	// Token: 0x02003ED6 RID: 16086
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node24 : Condition
	{
		// Token: 0x06016528 RID: 91432 RVA: 0x006C0B54 File Offset: 0x006BEF54
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016529 RID: 91433 RVA: 0x006C0B68 File Offset: 0x006BEF68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD61 RID: 64865
		private float opl_p0;
	}
}
