using System;

namespace behaviac
{
	// Token: 0x02001E5B RID: 7771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node9 : Condition
	{
		// Token: 0x06012663 RID: 75363 RVA: 0x00560707 File Offset: 0x0055EB07
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node9()
		{
			this.opl_p0 = 9728;
		}

		// Token: 0x06012664 RID: 75364 RVA: 0x0056071C File Offset: 0x0055EB1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C04B RID: 49227
		private int opl_p0;
	}
}
