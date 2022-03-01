using System;

namespace behaviac
{
	// Token: 0x020040C4 RID: 16580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4 : Condition
	{
		// Token: 0x060168DF RID: 92383 RVA: 0x006D48FA File Offset: 0x006D2CFA
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node4()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060168E0 RID: 92384 RVA: 0x006D4910 File Offset: 0x006D2D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010125 RID: 65829
		private float opl_p0;
	}
}
