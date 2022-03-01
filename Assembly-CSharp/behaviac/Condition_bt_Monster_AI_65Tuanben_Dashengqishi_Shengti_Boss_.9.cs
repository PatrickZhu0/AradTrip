using System;

namespace behaviac
{
	// Token: 0x02002DDA RID: 11738
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node49 : Condition
	{
		// Token: 0x06014491 RID: 83089 RVA: 0x00618506 File Offset: 0x00616906
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node49()
		{
			this.opl_p0 = 21641;
		}

		// Token: 0x06014492 RID: 83090 RVA: 0x0061851C File Offset: 0x0061691C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE4A RID: 56906
		private int opl_p0;
	}
}
