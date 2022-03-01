using System;

namespace behaviac
{
	// Token: 0x020040C7 RID: 16583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node6 : Condition
	{
		// Token: 0x060168E5 RID: 92389 RVA: 0x006D49E7 File Offset: 0x006D2DE7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node6()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060168E6 RID: 92390 RVA: 0x006D49FC File Offset: 0x006D2DFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401012B RID: 65835
		private float opl_p0;
	}
}
