using System;

namespace behaviac
{
	// Token: 0x02002DDC RID: 11740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node34 : Condition
	{
		// Token: 0x06014495 RID: 83093 RVA: 0x006185FA File Offset: 0x006169FA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node34()
		{
			this.opl_p0 = 21629;
		}

		// Token: 0x06014496 RID: 83094 RVA: 0x00618610 File Offset: 0x00616A10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE4D RID: 56909
		private int opl_p0;
	}
}
