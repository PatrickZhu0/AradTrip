using System;

namespace behaviac
{
	// Token: 0x0200266F RID: 9839
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node38 : Condition
	{
		// Token: 0x06013623 RID: 79395 RVA: 0x005C49EF File Offset: 0x005C2DEF
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node38()
		{
			this.opl_p0 = 1014;
		}

		// Token: 0x06013624 RID: 79396 RVA: 0x005C4A04 File Offset: 0x005C2E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D076 RID: 53366
		private int opl_p0;
	}
}
