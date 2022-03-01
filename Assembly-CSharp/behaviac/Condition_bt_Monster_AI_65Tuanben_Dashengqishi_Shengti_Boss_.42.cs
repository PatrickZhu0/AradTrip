using System;

namespace behaviac
{
	// Token: 0x02002E15 RID: 11797
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node155 : Condition
	{
		// Token: 0x06014507 RID: 83207 RVA: 0x00619CE6 File Offset: 0x006180E6
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node155()
		{
			this.opl_p0 = 21637;
		}

		// Token: 0x06014508 RID: 83208 RVA: 0x00619CFC File Offset: 0x006180FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEAD RID: 57005
		private int opl_p0;
	}
}
