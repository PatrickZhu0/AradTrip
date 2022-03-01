using System;

namespace behaviac
{
	// Token: 0x02001E1E RID: 7710
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node23 : Condition
	{
		// Token: 0x060125ED RID: 75245 RVA: 0x0055DC33 File Offset: 0x0055C033
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node23()
		{
			this.opl_p0 = 8013;
		}

		// Token: 0x060125EE RID: 75246 RVA: 0x0055DC48 File Offset: 0x0055C048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFD7 RID: 49111
		private int opl_p0;
	}
}
