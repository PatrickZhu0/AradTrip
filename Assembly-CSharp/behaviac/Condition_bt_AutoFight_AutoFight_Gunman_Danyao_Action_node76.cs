using System;

namespace behaviac
{
	// Token: 0x020025DB RID: 9691
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node76 : Condition
	{
		// Token: 0x060134FD RID: 79101 RVA: 0x005BD913 File Offset: 0x005BBD13
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node76()
		{
			this.opl_p0 = 1009;
		}

		// Token: 0x060134FE RID: 79102 RVA: 0x005BD928 File Offset: 0x005BBD28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF42 RID: 53058
		private int opl_p0;
	}
}
