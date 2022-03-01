using System;

namespace behaviac
{
	// Token: 0x0200215E RID: 8542
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node17 : Condition
	{
		// Token: 0x06012C4D RID: 76877 RVA: 0x00584AFE File Offset: 0x00582EFE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012C4E RID: 76878 RVA: 0x00584B14 File Offset: 0x00582F14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C640 RID: 50752
		private float opl_p0;
	}
}
