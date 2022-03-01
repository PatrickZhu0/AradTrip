using System;

namespace behaviac
{
	// Token: 0x02002042 RID: 8258
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node12 : Condition
	{
		// Token: 0x06012A1E RID: 76318 RVA: 0x00577226 File Offset: 0x00575626
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node12()
		{
			this.opl_p0 = 0.51f;
		}

		// Token: 0x06012A1F RID: 76319 RVA: 0x0057723C File Offset: 0x0057563C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C411 RID: 50193
		private float opl_p0;
	}
}
