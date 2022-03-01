using System;

namespace behaviac
{
	// Token: 0x02002D98 RID: 11672
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node28 : Condition
	{
		// Token: 0x06014411 RID: 82961 RVA: 0x00615B13 File Offset: 0x00613F13
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node28()
		{
			this.opl_p0 = 21645;
		}

		// Token: 0x06014412 RID: 82962 RVA: 0x00615B28 File Offset: 0x00613F28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDDA RID: 56794
		private int opl_p0;
	}
}
