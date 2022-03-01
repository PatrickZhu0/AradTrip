using System;

namespace behaviac
{
	// Token: 0x02001D4F RID: 7503
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node4 : Condition
	{
		// Token: 0x0601245D RID: 74845 RVA: 0x00554A9B File Offset: 0x00552E9B
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node4()
		{
			this.opl_p0 = 9036;
		}

		// Token: 0x0601245E RID: 74846 RVA: 0x00554AB0 File Offset: 0x00552EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE4C RID: 48716
		private int opl_p0;
	}
}
