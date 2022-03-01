using System;

namespace behaviac
{
	// Token: 0x020034A7 RID: 13479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node31 : Condition
	{
		// Token: 0x06015196 RID: 86422 RVA: 0x0065B9E1 File Offset: 0x00659DE1
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node31()
		{
			this.opl_p0 = 6203;
		}

		// Token: 0x06015197 RID: 86423 RVA: 0x0065B9F4 File Offset: 0x00659DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA9A RID: 60058
		private int opl_p0;
	}
}
