using System;

namespace behaviac
{
	// Token: 0x02002E51 RID: 11857
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node173 : Condition
	{
		// Token: 0x0601457F RID: 83327 RVA: 0x0061B4CD File Offset: 0x006198CD
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node173()
		{
			this.opl_p0 = 21623;
		}

		// Token: 0x06014580 RID: 83328 RVA: 0x0061B4E0 File Offset: 0x006198E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF12 RID: 57106
		private int opl_p0;
	}
}
