using System;

namespace behaviac
{
	// Token: 0x02001D13 RID: 7443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node3 : Condition
	{
		// Token: 0x060123E9 RID: 74729 RVA: 0x00551847 File Offset: 0x0054FC47
		public Condition_bt_APC_APC_Guiqi2_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060123EA RID: 74730 RVA: 0x0055185C File Offset: 0x0054FC5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDDE RID: 48606
		private float opl_p0;
	}
}
