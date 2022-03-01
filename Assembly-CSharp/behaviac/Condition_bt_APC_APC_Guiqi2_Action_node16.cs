using System;

namespace behaviac
{
	// Token: 0x02001D14 RID: 7444
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node16 : Condition
	{
		// Token: 0x060123EB RID: 74731 RVA: 0x0055188F File Offset: 0x0054FC8F
		public Condition_bt_APC_APC_Guiqi2_Action_node16()
		{
			this.opl_p0 = 9732;
		}

		// Token: 0x060123EC RID: 74732 RVA: 0x005518A4 File Offset: 0x0054FCA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDDF RID: 48607
		private int opl_p0;
	}
}
