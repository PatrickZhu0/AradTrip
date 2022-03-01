using System;

namespace behaviac
{
	// Token: 0x02001D1A RID: 7450
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node23 : Condition
	{
		// Token: 0x060123F7 RID: 74743 RVA: 0x00551DEB File Offset: 0x005501EB
		public Condition_bt_APC_APC_Guiqi2_Action_node23()
		{
			this.opl_p0 = 9724;
		}

		// Token: 0x060123F8 RID: 74744 RVA: 0x00551E00 File Offset: 0x00550200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE7 RID: 48615
		private int opl_p0;
	}
}
