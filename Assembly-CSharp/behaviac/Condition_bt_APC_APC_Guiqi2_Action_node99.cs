using System;

namespace behaviac
{
	// Token: 0x02001D1E RID: 7454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node99 : Condition
	{
		// Token: 0x060123FF RID: 74751 RVA: 0x00551FA1 File Offset: 0x005503A1
		public Condition_bt_APC_APC_Guiqi2_Action_node99()
		{
			this.opl_p0 = 9726;
		}

		// Token: 0x06012400 RID: 74752 RVA: 0x00551FB4 File Offset: 0x005503B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDEF RID: 48623
		private int opl_p0;
	}
}
