using System;

namespace behaviac
{
	// Token: 0x0200364B RID: 13899
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node24 : Condition
	{
		// Token: 0x060154B9 RID: 87225 RVA: 0x0066B9A3 File Offset: 0x00669DA3
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node24()
		{
			this.opl_p0 = 5424;
		}

		// Token: 0x060154BA RID: 87226 RVA: 0x0066B9B8 File Offset: 0x00669DB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE72 RID: 61042
		private int opl_p0;
	}
}
