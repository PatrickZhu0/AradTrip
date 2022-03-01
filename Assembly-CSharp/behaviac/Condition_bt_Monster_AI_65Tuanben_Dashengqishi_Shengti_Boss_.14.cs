using System;

namespace behaviac
{
	// Token: 0x02002DE3 RID: 11747
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node46 : Condition
	{
		// Token: 0x060144A3 RID: 83107 RVA: 0x00618936 File Offset: 0x00616D36
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node46()
		{
			this.opl_p0 = 21640;
		}

		// Token: 0x060144A4 RID: 83108 RVA: 0x0061894C File Offset: 0x00616D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE59 RID: 56921
		private int opl_p0;
	}
}
