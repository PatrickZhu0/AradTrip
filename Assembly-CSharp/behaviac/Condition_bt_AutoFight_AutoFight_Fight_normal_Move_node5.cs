using System;

namespace behaviac
{
	// Token: 0x02002201 RID: 8705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_normal_Move_node5 : Condition
	{
		// Token: 0x06012D8D RID: 77197 RVA: 0x0058C89D File Offset: 0x0058AC9D
		public Condition_bt_AutoFight_AutoFight_Fight_normal_Move_node5()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012D8E RID: 77198 RVA: 0x0058C8B0 File Offset: 0x0058ACB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C779 RID: 51065
		private float opl_p0;
	}
}
