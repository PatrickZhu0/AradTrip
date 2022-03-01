using System;

namespace behaviac
{
	// Token: 0x020037A8 RID: 14248
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node8 : Condition
	{
		// Token: 0x06015753 RID: 87891 RVA: 0x00679E1D File Offset: 0x0067821D
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521627;
		}

		// Token: 0x06015754 RID: 87892 RVA: 0x00679E40 File Offset: 0x00678240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F103 RID: 61699
		private BE_Target opl_p0;

		// Token: 0x0400F104 RID: 61700
		private BE_Equal opl_p1;

		// Token: 0x0400F105 RID: 61701
		private int opl_p2;
	}
}
