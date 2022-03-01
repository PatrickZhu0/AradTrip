using System;

namespace behaviac
{
	// Token: 0x020038C3 RID: 14531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node14 : Condition
	{
		// Token: 0x06015965 RID: 88421 RVA: 0x006840AF File Offset: 0x006824AF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node14()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521642;
		}

		// Token: 0x06015966 RID: 88422 RVA: 0x006840D0 File Offset: 0x006824D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F310 RID: 62224
		private BE_Target opl_p0;

		// Token: 0x0400F311 RID: 62225
		private BE_Equal opl_p1;

		// Token: 0x0400F312 RID: 62226
		private int opl_p2;
	}
}
