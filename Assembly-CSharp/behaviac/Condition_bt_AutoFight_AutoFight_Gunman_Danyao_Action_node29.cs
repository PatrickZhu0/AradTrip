using System;

namespace behaviac
{
	// Token: 0x020025D7 RID: 9687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node29 : Condition
	{
		// Token: 0x060134F5 RID: 79093 RVA: 0x005BD75F File Offset: 0x005BBB5F
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node29()
		{
			this.opl_p0 = 1305;
		}

		// Token: 0x060134F6 RID: 79094 RVA: 0x005BD774 File Offset: 0x005BBB74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF3A RID: 53050
		private int opl_p0;
	}
}
