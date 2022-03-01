using System;

namespace behaviac
{
	// Token: 0x02003ED2 RID: 16082
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node4 : Condition
	{
		// Token: 0x06016520 RID: 91424 RVA: 0x006C09E8 File Offset: 0x006BEDE8
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node4()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016521 RID: 91425 RVA: 0x006C09FC File Offset: 0x006BEDFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD57 RID: 64855
		private float opl_p0;
	}
}
