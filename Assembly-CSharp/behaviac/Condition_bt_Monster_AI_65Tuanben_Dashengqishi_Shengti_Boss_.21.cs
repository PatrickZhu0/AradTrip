using System;

namespace behaviac
{
	// Token: 0x02002DED RID: 11757
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node15 : Condition
	{
		// Token: 0x060144B7 RID: 83127 RVA: 0x00618DE1 File Offset: 0x006171E1
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node15()
		{
			this.opl_p0 = 21624;
		}

		// Token: 0x060144B8 RID: 83128 RVA: 0x00618DF4 File Offset: 0x006171F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE71 RID: 56945
		private int opl_p0;
	}
}
