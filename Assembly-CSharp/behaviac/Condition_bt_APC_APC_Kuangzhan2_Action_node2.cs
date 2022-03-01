using System;

namespace behaviac
{
	// Token: 0x02001D8F RID: 7567
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node2 : Condition
	{
		// Token: 0x060124D9 RID: 74969 RVA: 0x0055752F File Offset: 0x0055592F
		public Condition_bt_APC_APC_Kuangzhan2_Action_node2()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060124DA RID: 74970 RVA: 0x00557544 File Offset: 0x00555944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEC6 RID: 48838
		private float opl_p0;
	}
}
