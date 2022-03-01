using System;

namespace behaviac
{
	// Token: 0x0200252A RID: 9514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node53 : Condition
	{
		// Token: 0x0601339D RID: 78749 RVA: 0x005B64EF File Offset: 0x005B48EF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node53()
		{
			this.opl_p0 = 2603;
		}

		// Token: 0x0601339E RID: 78750 RVA: 0x005B6504 File Offset: 0x005B4904
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC0 RID: 52672
		private int opl_p0;
	}
}
