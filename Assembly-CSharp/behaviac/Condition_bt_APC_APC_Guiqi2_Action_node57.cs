using System;

namespace behaviac
{
	// Token: 0x02001D26 RID: 7462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node57 : Condition
	{
		// Token: 0x0601240F RID: 74767 RVA: 0x00552309 File Offset: 0x00550709
		public Condition_bt_APC_APC_Guiqi2_Action_node57()
		{
			this.opl_p0 = 9733;
		}

		// Token: 0x06012410 RID: 74768 RVA: 0x0055231C File Offset: 0x0055071C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDFF RID: 48639
		private int opl_p0;
	}
}
