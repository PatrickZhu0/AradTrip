using System;

namespace behaviac
{
	// Token: 0x0200354D RID: 13645
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node104 : Condition
	{
		// Token: 0x060152DA RID: 86746 RVA: 0x006621C7 File Offset: 0x006605C7
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Yinxingguai_Yiyan_node104()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521757;
		}

		// Token: 0x060152DB RID: 86747 RVA: 0x006621E8 File Offset: 0x006605E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC90 RID: 60560
		private BE_Target opl_p0;

		// Token: 0x0400EC91 RID: 60561
		private BE_Equal opl_p1;

		// Token: 0x0400EC92 RID: 60562
		private int opl_p2;
	}
}
