using System;

namespace behaviac
{
	// Token: 0x02001E4E RID: 7758
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node3 : Condition
	{
		// Token: 0x06012649 RID: 75337 RVA: 0x0055FEBF File Offset: 0x0055E2BF
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601264A RID: 75338 RVA: 0x0055FED4 File Offset: 0x0055E2D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C032 RID: 49202
		private float opl_p0;
	}
}
