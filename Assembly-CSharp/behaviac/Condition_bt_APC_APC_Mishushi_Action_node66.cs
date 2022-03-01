using System;

namespace behaviac
{
	// Token: 0x02001DC5 RID: 7621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node66 : Condition
	{
		// Token: 0x06012542 RID: 75074 RVA: 0x0055A00F File Offset: 0x0055840F
		public Condition_bt_APC_APC_Mishushi_Action_node66()
		{
			this.opl_p0 = 9742;
		}

		// Token: 0x06012543 RID: 75075 RVA: 0x0055A024 File Offset: 0x00558424
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF37 RID: 48951
		private int opl_p0;
	}
}
