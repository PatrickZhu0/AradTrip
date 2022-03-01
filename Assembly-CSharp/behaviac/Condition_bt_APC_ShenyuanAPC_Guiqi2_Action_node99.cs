using System;

namespace behaviac
{
	// Token: 0x02001E4A RID: 7754
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node99 : Condition
	{
		// Token: 0x06012641 RID: 75329 RVA: 0x0055FCF7 File Offset: 0x0055E0F7
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node99()
		{
			this.opl_p0 = 9726;
		}

		// Token: 0x06012642 RID: 75330 RVA: 0x0055FD0C File Offset: 0x0055E10C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C028 RID: 49192
		private int opl_p0;
	}
}
