using System;

namespace behaviac
{
	// Token: 0x020040BD RID: 16573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node12 : Condition
	{
		// Token: 0x060168D2 RID: 92370 RVA: 0x006D42C3 File Offset: 0x006D26C3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node12()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060168D3 RID: 92371 RVA: 0x006D42D8 File Offset: 0x006D26D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010119 RID: 65817
		private float opl_p0;
	}
}
