using System;

namespace behaviac
{
	// Token: 0x0200254A RID: 9546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node82 : Condition
	{
		// Token: 0x060133DD RID: 78813 RVA: 0x005B72EF File Offset: 0x005B56EF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node82()
		{
			this.opl_p0 = 2515;
		}

		// Token: 0x060133DE RID: 78814 RVA: 0x005B7304 File Offset: 0x005B5704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE04 RID: 52740
		private int opl_p0;
	}
}
