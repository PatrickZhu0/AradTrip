using System;

namespace behaviac
{
	// Token: 0x02001DE9 RID: 7657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node5 : Condition
	{
		// Token: 0x06012588 RID: 75144 RVA: 0x0055B5FB File Offset: 0x005599FB
		public Condition_bt_APC_APC_Nianqishi_Action_node5()
		{
			this.opl_p0 = 9704;
		}

		// Token: 0x06012589 RID: 75145 RVA: 0x0055B610 File Offset: 0x00559A10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF7B RID: 49019
		private int opl_p0;
	}
}
