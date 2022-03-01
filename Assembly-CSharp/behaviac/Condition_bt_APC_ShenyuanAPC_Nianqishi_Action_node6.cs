using System;

namespace behaviac
{
	// Token: 0x02001EB3 RID: 7859
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node6 : Condition
	{
		// Token: 0x0601270E RID: 75534 RVA: 0x00564C79 File Offset: 0x00563079
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node6()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601270F RID: 75535 RVA: 0x00564C8C File Offset: 0x0056308C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0FD RID: 49405
		private float opl_p0;
	}
}
