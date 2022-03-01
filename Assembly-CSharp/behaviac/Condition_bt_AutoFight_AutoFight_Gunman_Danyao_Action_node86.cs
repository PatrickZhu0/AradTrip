using System;

namespace behaviac
{
	// Token: 0x020025C3 RID: 9667
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node86 : Condition
	{
		// Token: 0x060134CD RID: 79053 RVA: 0x005BCF43 File Offset: 0x005BB343
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node86()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x060134CE RID: 79054 RVA: 0x005BCF58 File Offset: 0x005BB358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF0A RID: 53002
		private int opl_p0;
	}
}
