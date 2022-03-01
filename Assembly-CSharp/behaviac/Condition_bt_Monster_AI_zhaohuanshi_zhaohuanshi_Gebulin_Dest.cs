using System;

namespace behaviac
{
	// Token: 0x02003FBE RID: 16318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node5 : Condition
	{
		// Token: 0x060166E5 RID: 91877 RVA: 0x006C99B6 File Offset: 0x006C7DB6
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node5()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060166E6 RID: 91878 RVA: 0x006C99CC File Offset: 0x006C7DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF37 RID: 65335
		private float opl_p0;
	}
}
