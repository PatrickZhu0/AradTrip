using System;

namespace behaviac
{
	// Token: 0x0200229E RID: 8862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node13 : Condition
	{
		// Token: 0x06012EB9 RID: 77497 RVA: 0x005950E0 File Offset: 0x005934E0
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node13()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x06012EBA RID: 77498 RVA: 0x005950F4 File Offset: 0x005934F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8C5 RID: 51397
		private float opl_p0;
	}
}
