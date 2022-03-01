using System;

namespace behaviac
{
	// Token: 0x02003EDF RID: 16095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node15 : Condition
	{
		// Token: 0x0601653A RID: 91450 RVA: 0x006C0D91 File Offset: 0x006BF191
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node15()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601653B RID: 91451 RVA: 0x006C0DA4 File Offset: 0x006BF1A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD6D RID: 64877
		private float opl_p0;
	}
}
