using System;

namespace behaviac
{
	// Token: 0x0200363F RID: 13887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node14 : Condition
	{
		// Token: 0x060154A1 RID: 87201 RVA: 0x0066B487 File Offset: 0x00669887
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node14()
		{
			this.opl_p0 = 5659;
		}

		// Token: 0x060154A2 RID: 87202 RVA: 0x0066B49C File Offset: 0x0066989C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE5A RID: 61018
		private int opl_p0;
	}
}
