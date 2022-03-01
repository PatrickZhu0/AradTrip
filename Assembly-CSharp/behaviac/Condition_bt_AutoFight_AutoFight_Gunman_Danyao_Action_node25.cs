using System;

namespace behaviac
{
	// Token: 0x020025BB RID: 9659
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node25 : Condition
	{
		// Token: 0x060134BD RID: 79037 RVA: 0x005BCBDB File Offset: 0x005BAFDB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node25()
		{
			this.opl_p0 = 1303;
		}

		// Token: 0x060134BE RID: 79038 RVA: 0x005BCBF0 File Offset: 0x005BAFF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEFA RID: 52986
		private int opl_p0;
	}
}
