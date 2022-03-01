using System;

namespace behaviac
{
	// Token: 0x020031A7 RID: 12711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node13 : Condition
	{
		// Token: 0x06014BE1 RID: 84961 RVA: 0x0063F2C2 File Offset: 0x0063D6C2
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570271;
		}

		// Token: 0x06014BE2 RID: 84962 RVA: 0x0063F2E4 File Offset: 0x0063D6E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E54A RID: 58698
		private BE_Target opl_p0;

		// Token: 0x0400E54B RID: 58699
		private BE_Equal opl_p1;

		// Token: 0x0400E54C RID: 58700
		private int opl_p2;
	}
}
