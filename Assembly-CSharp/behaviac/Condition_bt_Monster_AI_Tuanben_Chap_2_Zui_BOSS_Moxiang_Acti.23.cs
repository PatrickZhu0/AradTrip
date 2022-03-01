using System;

namespace behaviac
{
	// Token: 0x0200376A RID: 14186
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node4 : Condition
	{
		// Token: 0x060156DB RID: 87771 RVA: 0x00676CCE File Offset: 0x006750CE
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521626;
		}

		// Token: 0x060156DC RID: 87772 RVA: 0x00676CF0 File Offset: 0x006750F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0A4 RID: 61604
		private BE_Target opl_p0;

		// Token: 0x0400F0A5 RID: 61605
		private BE_Equal opl_p1;

		// Token: 0x0400F0A6 RID: 61606
		private int opl_p2;
	}
}
