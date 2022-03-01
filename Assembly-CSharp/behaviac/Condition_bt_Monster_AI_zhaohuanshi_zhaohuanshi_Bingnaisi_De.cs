using System;

namespace behaviac
{
	// Token: 0x02003F86 RID: 16262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node4 : Condition
	{
		// Token: 0x06016677 RID: 91767 RVA: 0x006C7270 File Offset: 0x006C5670
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node4()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06016678 RID: 91768 RVA: 0x006C7284 File Offset: 0x006C5684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FECB RID: 65227
		private float opl_p0;
	}
}
