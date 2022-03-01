using System;

namespace behaviac
{
	// Token: 0x02001D71 RID: 7537
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node23 : Condition
	{
		// Token: 0x0601249F RID: 74911 RVA: 0x00555EB5 File Offset: 0x005542B5
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node23()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060124A0 RID: 74912 RVA: 0x00555EC8 File Offset: 0x005542C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE92 RID: 48786
		private float opl_p0;
	}
}
