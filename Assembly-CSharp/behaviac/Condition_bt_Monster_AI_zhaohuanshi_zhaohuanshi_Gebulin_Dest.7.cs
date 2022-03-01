using System;

namespace behaviac
{
	// Token: 0x02003FC7 RID: 16327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node17 : Condition
	{
		// Token: 0x060166F7 RID: 91895 RVA: 0x006C9C7B File Offset: 0x006C807B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node17()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060166F8 RID: 91896 RVA: 0x006C9C90 File Offset: 0x006C8090
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF49 RID: 65353
		private float opl_p0;
	}
}
