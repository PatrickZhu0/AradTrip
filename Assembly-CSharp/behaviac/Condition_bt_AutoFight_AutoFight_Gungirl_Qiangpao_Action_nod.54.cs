using System;

namespace behaviac
{
	// Token: 0x0200255A RID: 9562
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node98 : Condition
	{
		// Token: 0x060133FD RID: 78845 RVA: 0x005B79BF File Offset: 0x005B5DBF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node98()
		{
			this.opl_p0 = 2509;
		}

		// Token: 0x060133FE RID: 78846 RVA: 0x005B79D4 File Offset: 0x005B5DD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE24 RID: 52772
		private int opl_p0;
	}
}
