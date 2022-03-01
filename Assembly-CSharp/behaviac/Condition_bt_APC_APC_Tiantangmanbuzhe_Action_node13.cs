using System;

namespace behaviac
{
	// Token: 0x02001E23 RID: 7715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node13 : Condition
	{
		// Token: 0x060125F7 RID: 75255 RVA: 0x0055DE5B File Offset: 0x0055C25B
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node13()
		{
			this.opl_p0 = 8011;
		}

		// Token: 0x060125F8 RID: 75256 RVA: 0x0055DE70 File Offset: 0x0055C270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFE3 RID: 49123
		private int opl_p0;
	}
}
