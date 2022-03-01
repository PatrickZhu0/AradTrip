using System;

namespace behaviac
{
	// Token: 0x02002DB0 RID: 11696
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node20 : Condition
	{
		// Token: 0x06014441 RID: 83009 RVA: 0x006164B9 File Offset: 0x006148B9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node20()
		{
			this.opl_p0 = 21647;
		}

		// Token: 0x06014442 RID: 83010 RVA: 0x006164CC File Offset: 0x006148CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE09 RID: 56841
		private int opl_p0;
	}
}
