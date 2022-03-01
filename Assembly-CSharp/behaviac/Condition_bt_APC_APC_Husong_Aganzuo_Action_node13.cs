using System;

namespace behaviac
{
	// Token: 0x02001D56 RID: 7510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node13 : Condition
	{
		// Token: 0x0601246B RID: 74859 RVA: 0x00554E73 File Offset: 0x00553273
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x0601246C RID: 74860 RVA: 0x00554E88 File Offset: 0x00553288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE5B RID: 48731
		private int opl_p0;
	}
}
