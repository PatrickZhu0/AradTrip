using System;

namespace behaviac
{
	// Token: 0x02001D2E RID: 7470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node3 : Condition
	{
		// Token: 0x0601241E RID: 74782 RVA: 0x00552EBF File Offset: 0x005512BF
		public Condition_bt_APC_APC_Guiqi_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601241F RID: 74783 RVA: 0x00552ED4 File Offset: 0x005512D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE10 RID: 48656
		private float opl_p0;
	}
}
