using System;

namespace behaviac
{
	// Token: 0x02002E7D RID: 11901
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node164 : Condition
	{
		// Token: 0x060145D7 RID: 83415 RVA: 0x0061C765 File Offset: 0x0061AB65
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node164()
		{
			this.opl_p0 = 21624;
		}

		// Token: 0x060145D8 RID: 83416 RVA: 0x0061C778 File Offset: 0x0061AB78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF63 RID: 57187
		private int opl_p0;
	}
}
