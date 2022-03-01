using System;

namespace behaviac
{
	// Token: 0x02001EB7 RID: 7863
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node26 : Condition
	{
		// Token: 0x06012716 RID: 75542 RVA: 0x00564E2D File Offset: 0x0056322D
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node26()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012717 RID: 75543 RVA: 0x00564E40 File Offset: 0x00563240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C105 RID: 49413
		private float opl_p0;
	}
}
