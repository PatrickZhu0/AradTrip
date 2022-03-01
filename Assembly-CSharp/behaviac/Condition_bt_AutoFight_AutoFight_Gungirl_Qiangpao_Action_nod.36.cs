using System;

namespace behaviac
{
	// Token: 0x02002542 RID: 9538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node70 : Condition
	{
		// Token: 0x060133CD RID: 78797 RVA: 0x005B6F87 File Offset: 0x005B5387
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node70()
		{
			this.opl_p0 = 2509;
		}

		// Token: 0x060133CE RID: 78798 RVA: 0x005B6F9C File Offset: 0x005B539C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDF4 RID: 52724
		private int opl_p0;
	}
}
