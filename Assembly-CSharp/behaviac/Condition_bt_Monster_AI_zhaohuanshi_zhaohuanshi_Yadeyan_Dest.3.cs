using System;

namespace behaviac
{
	// Token: 0x02003FFA RID: 16378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node6 : Condition
	{
		// Token: 0x06016759 RID: 91993 RVA: 0x006CC0AF File Offset: 0x006CA4AF
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601675A RID: 91994 RVA: 0x006CC0C4 File Offset: 0x006CA4C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA9 RID: 65449
		private float opl_p0;
	}
}
