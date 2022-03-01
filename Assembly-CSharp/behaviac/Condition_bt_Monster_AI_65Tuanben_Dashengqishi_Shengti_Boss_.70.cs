using System;

namespace behaviac
{
	// Token: 0x02002E46 RID: 11846
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node88 : Condition
	{
		// Token: 0x06014569 RID: 83305 RVA: 0x0061AFA6 File Offset: 0x006193A6
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node88()
		{
			this.opl_p0 = 21653;
		}

		// Token: 0x0601456A RID: 83306 RVA: 0x0061AFBC File Offset: 0x006193BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEFB RID: 57083
		private int opl_p0;
	}
}
