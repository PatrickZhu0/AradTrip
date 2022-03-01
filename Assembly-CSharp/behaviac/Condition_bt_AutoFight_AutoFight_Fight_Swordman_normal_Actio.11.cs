using System;

namespace behaviac
{
	// Token: 0x02002449 RID: 9289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node37 : Condition
	{
		// Token: 0x060131E6 RID: 78310 RVA: 0x005ABF26 File Offset: 0x005AA326
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node37()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060131E7 RID: 78311 RVA: 0x005ABF3C File Offset: 0x005AA33C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC0D RID: 52237
		private float opl_p0;
	}
}
