using System;

namespace behaviac
{
	// Token: 0x0200210E RID: 8462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node17 : Condition
	{
		// Token: 0x06012BAF RID: 76719 RVA: 0x00580EC6 File Offset: 0x0057F2C6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node17()
		{
			this.opl_p0 = 0.36f;
		}

		// Token: 0x06012BB0 RID: 76720 RVA: 0x00580EDC File Offset: 0x0057F2DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5A2 RID: 50594
		private float opl_p0;
	}
}
