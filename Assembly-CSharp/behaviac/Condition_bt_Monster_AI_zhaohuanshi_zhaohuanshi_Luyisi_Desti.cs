using System;

namespace behaviac
{
	// Token: 0x02003FDD RID: 16349
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node5 : Condition
	{
		// Token: 0x06016721 RID: 91937 RVA: 0x006CAE77 File Offset: 0x006C9277
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_DestinationSelect_node5()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016722 RID: 91938 RVA: 0x006CAE8C File Offset: 0x006C928C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF73 RID: 65395
		private float opl_p0;
	}
}
