using System;

namespace behaviac
{
	// Token: 0x02004076 RID: 16502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node8 : Condition
	{
		// Token: 0x06016849 RID: 92233 RVA: 0x006D152F File Offset: 0x006CF92F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601684A RID: 92234 RVA: 0x006D1544 File Offset: 0x006CF944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010093 RID: 65683
		private float opl_p0;
	}
}
