using System;

namespace behaviac
{
	// Token: 0x02001D33 RID: 7475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node6 : Condition
	{
		// Token: 0x06012428 RID: 74792 RVA: 0x005533A3 File Offset: 0x005517A3
		public Condition_bt_APC_APC_Guiqi_Action_node6()
		{
			this.opl_p0 = 7091;
		}

		// Token: 0x06012429 RID: 74793 RVA: 0x005533B8 File Offset: 0x005517B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE19 RID: 48665
		private int opl_p0;
	}
}
