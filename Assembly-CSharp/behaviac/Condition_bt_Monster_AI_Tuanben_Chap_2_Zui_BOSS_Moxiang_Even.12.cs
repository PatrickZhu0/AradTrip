using System;

namespace behaviac
{
	// Token: 0x020037A2 RID: 14242
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node2 : Condition
	{
		// Token: 0x06015747 RID: 87879 RVA: 0x00679C55 File Offset: 0x00678055
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521627;
		}

		// Token: 0x06015748 RID: 87880 RVA: 0x00679C78 File Offset: 0x00678078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0F7 RID: 61687
		private BE_Target opl_p0;

		// Token: 0x0400F0F8 RID: 61688
		private BE_Equal opl_p1;

		// Token: 0x0400F0F9 RID: 61689
		private int opl_p2;
	}
}
