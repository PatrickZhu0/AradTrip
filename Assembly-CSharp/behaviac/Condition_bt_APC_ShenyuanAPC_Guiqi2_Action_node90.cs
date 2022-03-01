using System;

namespace behaviac
{
	// Token: 0x02001E49 RID: 7753
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node90 : Condition
	{
		// Token: 0x0601263F RID: 75327 RVA: 0x0055FCB1 File Offset: 0x0055E0B1
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node90()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012640 RID: 75328 RVA: 0x0055FCC4 File Offset: 0x0055E0C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C027 RID: 49191
		private float opl_p0;
	}
}
