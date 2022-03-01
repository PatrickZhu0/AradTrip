using System;

namespace behaviac
{
	// Token: 0x02001D5A RID: 7514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node18 : Condition
	{
		// Token: 0x06012473 RID: 74867 RVA: 0x00555027 File Offset: 0x00553427
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node18()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06012474 RID: 74868 RVA: 0x0055503C File Offset: 0x0055343C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE63 RID: 48739
		private int opl_p0;
	}
}
