using System;

namespace behaviac
{
	// Token: 0x020031B4 RID: 12724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node4 : Condition
	{
		// Token: 0x06014BFB RID: 84987 RVA: 0x0063F812 File Offset: 0x0063DC12
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570272;
		}

		// Token: 0x06014BFC RID: 84988 RVA: 0x0063F834 File Offset: 0x0063DC34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E55D RID: 58717
		private BE_Target opl_p0;

		// Token: 0x0400E55E RID: 58718
		private BE_Equal opl_p1;

		// Token: 0x0400E55F RID: 58719
		private int opl_p2;
	}
}
