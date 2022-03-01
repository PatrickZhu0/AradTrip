using System;

namespace behaviac
{
	// Token: 0x02003EDA RID: 16090
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node12 : Condition
	{
		// Token: 0x06016530 RID: 91440 RVA: 0x006C0C35 File Offset: 0x006BF035
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06016531 RID: 91441 RVA: 0x006C0C48 File Offset: 0x006BF048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD65 RID: 64869
		private float opl_p0;
	}
}
