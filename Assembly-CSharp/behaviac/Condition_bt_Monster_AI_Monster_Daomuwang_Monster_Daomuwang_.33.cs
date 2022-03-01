using System;

namespace behaviac
{
	// Token: 0x02003647 RID: 13895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node19 : Condition
	{
		// Token: 0x060154B1 RID: 87217 RVA: 0x0066B7EF File Offset: 0x00669BEF
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node19()
		{
			this.opl_p0 = 5426;
		}

		// Token: 0x060154B2 RID: 87218 RVA: 0x0066B804 File Offset: 0x00669C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE6A RID: 61034
		private int opl_p0;
	}
}
