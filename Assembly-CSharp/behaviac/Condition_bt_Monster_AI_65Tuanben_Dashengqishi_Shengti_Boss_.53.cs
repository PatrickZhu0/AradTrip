using System;

namespace behaviac
{
	// Token: 0x02002E29 RID: 11817
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node188 : Condition
	{
		// Token: 0x0601452F RID: 83247 RVA: 0x0061A50D File Offset: 0x0061890D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node188()
		{
			this.opl_p0 = 21639;
		}

		// Token: 0x06014530 RID: 83248 RVA: 0x0061A520 File Offset: 0x00618920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DED1 RID: 57041
		private int opl_p0;
	}
}
