using System;

namespace behaviac
{
	// Token: 0x02001D2F RID: 7471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node16 : Condition
	{
		// Token: 0x06012420 RID: 74784 RVA: 0x00552F07 File Offset: 0x00551307
		public Condition_bt_APC_APC_Guiqi_Action_node16()
		{
			this.opl_p0 = 7097;
		}

		// Token: 0x06012421 RID: 74785 RVA: 0x00552F1C File Offset: 0x0055131C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE11 RID: 48657
		private int opl_p0;
	}
}
