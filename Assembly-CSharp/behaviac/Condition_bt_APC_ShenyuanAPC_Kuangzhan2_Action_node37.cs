using System;

namespace behaviac
{
	// Token: 0x02001E67 RID: 7783
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node37 : Condition
	{
		// Token: 0x0601267A RID: 75386 RVA: 0x0056185D File Offset: 0x0055FC5D
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node37()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601267B RID: 75387 RVA: 0x00561870 File Offset: 0x0055FC70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C064 RID: 49252
		private float opl_p0;
	}
}
