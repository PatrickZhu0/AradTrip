using System;

namespace behaviac
{
	// Token: 0x020040C0 RID: 16576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node16 : Condition
	{
		// Token: 0x060168D8 RID: 92376 RVA: 0x006D43AF File Offset: 0x006D27AF
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node16()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060168D9 RID: 92377 RVA: 0x006D43C4 File Offset: 0x006D27C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401011F RID: 65823
		private float opl_p0;
	}
}
