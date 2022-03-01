using System;

namespace behaviac
{
	// Token: 0x020025C7 RID: 9671
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node21 : Condition
	{
		// Token: 0x060134D5 RID: 79061 RVA: 0x005BD0F7 File Offset: 0x005BB4F7
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node21()
		{
			this.opl_p0 = 1304;
		}

		// Token: 0x060134D6 RID: 79062 RVA: 0x005BD10C File Offset: 0x005BB50C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF12 RID: 53010
		private int opl_p0;
	}
}
