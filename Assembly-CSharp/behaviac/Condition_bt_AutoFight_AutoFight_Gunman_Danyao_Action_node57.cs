using System;

namespace behaviac
{
	// Token: 0x020025AF RID: 9647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node57 : Condition
	{
		// Token: 0x060134A5 RID: 79013 RVA: 0x005BC727 File Offset: 0x005BAB27
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node57()
		{
			this.opl_p0 = 1204;
		}

		// Token: 0x060134A6 RID: 79014 RVA: 0x005BC73C File Offset: 0x005BAB3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEDA RID: 52954
		private int opl_p0;
	}
}
