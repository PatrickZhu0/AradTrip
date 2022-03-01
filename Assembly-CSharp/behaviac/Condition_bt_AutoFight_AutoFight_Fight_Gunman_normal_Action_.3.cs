using System;

namespace behaviac
{
	// Token: 0x020021CE RID: 8654
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node7 : Condition
	{
		// Token: 0x06012D2A RID: 77098 RVA: 0x0058A21A File Offset: 0x0058861A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node7()
		{
			this.opl_p0 = 0.48f;
		}

		// Token: 0x06012D2B RID: 77099 RVA: 0x0058A230 File Offset: 0x00588630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C71D RID: 50973
		private float opl_p0;
	}
}
