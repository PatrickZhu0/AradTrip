using System;

namespace behaviac
{
	// Token: 0x02003FC4 RID: 16324
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node13 : Condition
	{
		// Token: 0x060166F1 RID: 91889 RVA: 0x006C9B8F File Offset: 0x006C7F8F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node13()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060166F2 RID: 91890 RVA: 0x006C9BA4 File Offset: 0x006C7FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF43 RID: 65347
		private float opl_p0;
	}
}
