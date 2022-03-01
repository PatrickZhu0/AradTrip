using System;

namespace behaviac
{
	// Token: 0x02001D0D RID: 7437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x060123DE RID: 74718 RVA: 0x005514FD File Offset: 0x0054F8FD
		public Condition_bt_APC_APC_Demian_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060123DF RID: 74719 RVA: 0x00551510 File Offset: 0x0054F910
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDD4 RID: 48596
		private float opl_p0;
	}
}
