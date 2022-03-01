using System;

namespace behaviac
{
	// Token: 0x02003FF7 RID: 16375
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node4 : Condition
	{
		// Token: 0x06016753 RID: 91987 RVA: 0x006CBFC4 File Offset: 0x006CA3C4
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node4()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016754 RID: 91988 RVA: 0x006CBFD8 File Offset: 0x006CA3D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA3 RID: 65443
		private float opl_p0;
	}
}
