using System;

namespace behaviac
{
	// Token: 0x020040A3 RID: 16547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node6 : Condition
	{
		// Token: 0x060168A0 RID: 92320 RVA: 0x006D328B File Offset: 0x006D168B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yadeyan_DestinationSelect_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060168A1 RID: 92321 RVA: 0x006D32A0 File Offset: 0x006D16A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100E8 RID: 65768
		private float opl_p0;
	}
}
