using System;

namespace behaviac
{
	// Token: 0x02002E41 RID: 11841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node207 : Condition
	{
		// Token: 0x0601455F RID: 83295 RVA: 0x0061AD5E File Offset: 0x0061915E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node207()
		{
			this.opl_p0 = 21641;
		}

		// Token: 0x06014560 RID: 83296 RVA: 0x0061AD74 File Offset: 0x00619174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEF2 RID: 57074
		private int opl_p0;
	}
}
