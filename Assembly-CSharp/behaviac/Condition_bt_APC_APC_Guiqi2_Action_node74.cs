using System;

namespace behaviac
{
	// Token: 0x02001D17 RID: 7447
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node74 : Condition
	{
		// Token: 0x060123F1 RID: 74737 RVA: 0x00551CAF File Offset: 0x005500AF
		public Condition_bt_APC_APC_Guiqi2_Action_node74()
		{
			this.opl_p0 = 9725;
		}

		// Token: 0x060123F2 RID: 74738 RVA: 0x00551CC4 File Offset: 0x005500C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE3 RID: 48611
		private int opl_p0;
	}
}
