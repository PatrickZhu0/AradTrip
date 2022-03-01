using System;

namespace behaviac
{
	// Token: 0x0200395E RID: 14686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node51 : Condition
	{
		// Token: 0x06015A93 RID: 88723 RVA: 0x0068B009 File Offset: 0x00689409
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x06015A94 RID: 88724 RVA: 0x0068B02C File Offset: 0x0068942C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F430 RID: 62512
		private BE_Target opl_p0;

		// Token: 0x0400F431 RID: 62513
		private BE_Equal opl_p1;

		// Token: 0x0400F432 RID: 62514
		private int opl_p2;
	}
}
