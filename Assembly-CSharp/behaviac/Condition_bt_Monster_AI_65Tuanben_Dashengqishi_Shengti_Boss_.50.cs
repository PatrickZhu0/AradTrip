using System;

namespace behaviac
{
	// Token: 0x02002E21 RID: 11809
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node138 : Condition
	{
		// Token: 0x0601451F RID: 83231 RVA: 0x0061A281 File Offset: 0x00618681
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node138()
		{
			this.opl_p0 = 21625;
		}

		// Token: 0x06014520 RID: 83232 RVA: 0x0061A294 File Offset: 0x00618694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEC8 RID: 57032
		private int opl_p0;
	}
}
