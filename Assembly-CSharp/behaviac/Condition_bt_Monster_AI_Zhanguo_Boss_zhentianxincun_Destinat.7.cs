using System;

namespace behaviac
{
	// Token: 0x02003ED8 RID: 16088
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node7 : Condition
	{
		// Token: 0x0601652C RID: 91436 RVA: 0x006C0BC5 File Offset: 0x006BEFC5
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node7()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601652D RID: 91437 RVA: 0x006C0BD8 File Offset: 0x006BEFD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD63 RID: 64867
		private float opl_p0;
	}
}
