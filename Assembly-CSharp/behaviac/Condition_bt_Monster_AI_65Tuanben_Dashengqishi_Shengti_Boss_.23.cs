using System;

namespace behaviac
{
	// Token: 0x02002DF0 RID: 11760
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node20 : Condition
	{
		// Token: 0x060144BD RID: 83133 RVA: 0x00618F4D File Offset: 0x0061734D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node20()
		{
			this.opl_p0 = 21625;
		}

		// Token: 0x060144BE RID: 83134 RVA: 0x00618F60 File Offset: 0x00617360
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE78 RID: 56952
		private int opl_p0;
	}
}
