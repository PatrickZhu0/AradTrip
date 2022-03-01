using System;

namespace behaviac
{
	// Token: 0x02001E5F RID: 7775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node48 : Condition
	{
		// Token: 0x0601266A RID: 75370 RVA: 0x005611A5 File Offset: 0x0055F5A5
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node48()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601266B RID: 75371 RVA: 0x005611B8 File Offset: 0x0055F5B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C052 RID: 49234
		private float opl_p0;
	}
}
