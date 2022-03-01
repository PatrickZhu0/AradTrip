using System;

namespace behaviac
{
	// Token: 0x020031CF RID: 12751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node2 : Condition
	{
		// Token: 0x06014C30 RID: 85040 RVA: 0x00641467 File Offset: 0x0063F867
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570273;
		}

		// Token: 0x06014C31 RID: 85041 RVA: 0x00641488 File Offset: 0x0063F888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E583 RID: 58755
		private BE_Target opl_p0;

		// Token: 0x0400E584 RID: 58756
		private BE_Equal opl_p1;

		// Token: 0x0400E585 RID: 58757
		private int opl_p2;
	}
}
