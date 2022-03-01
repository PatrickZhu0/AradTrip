using System;

namespace behaviac
{
	// Token: 0x02002552 RID: 9554
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node90 : Condition
	{
		// Token: 0x060133ED RID: 78829 RVA: 0x005B7657 File Offset: 0x005B5A57
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node90()
		{
			this.opl_p0 = 2512;
		}

		// Token: 0x060133EE RID: 78830 RVA: 0x005B766C File Offset: 0x005B5A6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE14 RID: 52756
		private int opl_p0;
	}
}
