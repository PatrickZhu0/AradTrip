using System;

namespace behaviac
{
	// Token: 0x0200259F RID: 9631
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node41 : Condition
	{
		// Token: 0x06013485 RID: 78981 RVA: 0x005BC057 File Offset: 0x005BA457
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node41()
		{
			this.opl_p0 = 1308;
		}

		// Token: 0x06013486 RID: 78982 RVA: 0x005BC06C File Offset: 0x005BA46C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEBA RID: 52922
		private int opl_p0;
	}
}
