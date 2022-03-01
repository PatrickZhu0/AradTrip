using System;

namespace behaviac
{
	// Token: 0x02001EBC RID: 7868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node12 : Condition
	{
		// Token: 0x06012720 RID: 75552 RVA: 0x00565047 File Offset: 0x00563447
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node12()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012721 RID: 75553 RVA: 0x0056505C File Offset: 0x0056345C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C110 RID: 49424
		private float opl_p0;
	}
}
