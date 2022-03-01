using System;

namespace behaviac
{
	// Token: 0x0200377A RID: 14202
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node56 : Condition
	{
		// Token: 0x060156FB RID: 87803 RVA: 0x0067735A File Offset: 0x0067575A
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node56()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521627;
		}

		// Token: 0x060156FC RID: 87804 RVA: 0x0067737C File Offset: 0x0067577C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0BB RID: 61627
		private BE_Target opl_p0;

		// Token: 0x0400F0BC RID: 61628
		private BE_Equal opl_p1;

		// Token: 0x0400F0BD RID: 61629
		private int opl_p2;
	}
}
