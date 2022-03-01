using System;

namespace behaviac
{
	// Token: 0x02001E45 RID: 7749
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node15 : Condition
	{
		// Token: 0x06012637 RID: 75319 RVA: 0x0055FAFD File Offset: 0x0055DEFD
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node15()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012638 RID: 75320 RVA: 0x0055FB10 File Offset: 0x0055DF10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C01F RID: 49183
		private float opl_p0;
	}
}
