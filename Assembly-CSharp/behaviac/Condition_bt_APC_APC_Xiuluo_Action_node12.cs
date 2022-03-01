using System;

namespace behaviac
{
	// Token: 0x02001E3C RID: 7740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node12 : Condition
	{
		// Token: 0x06012626 RID: 75302 RVA: 0x0055F375 File Offset: 0x0055D775
		public Condition_bt_APC_APC_Xiuluo_Action_node12()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012627 RID: 75303 RVA: 0x0055F388 File Offset: 0x0055D788
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C00F RID: 49167
		private float opl_p0;
	}
}
