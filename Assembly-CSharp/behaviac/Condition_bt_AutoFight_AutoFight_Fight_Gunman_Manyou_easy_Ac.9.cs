using System;

namespace behaviac
{
	// Token: 0x02002112 RID: 8466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node22 : Condition
	{
		// Token: 0x06012BB7 RID: 76727 RVA: 0x00581062 File Offset: 0x0057F462
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node22()
		{
			this.opl_p0 = 0.38f;
		}

		// Token: 0x06012BB8 RID: 76728 RVA: 0x00581078 File Offset: 0x0057F478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5AA RID: 50602
		private float opl_p0;
	}
}
