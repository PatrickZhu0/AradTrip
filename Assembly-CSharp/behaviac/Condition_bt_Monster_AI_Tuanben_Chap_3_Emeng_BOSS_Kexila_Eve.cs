using System;

namespace behaviac
{
	// Token: 0x0200389A RID: 14490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node13 : Condition
	{
		// Token: 0x06015916 RID: 88342 RVA: 0x00682F78 File Offset: 0x00681378
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521632;
		}

		// Token: 0x06015917 RID: 88343 RVA: 0x00682F9C File Offset: 0x0068139C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2A4 RID: 62116
		private BE_Target opl_p0;

		// Token: 0x0400F2A5 RID: 62117
		private BE_Equal opl_p1;

		// Token: 0x0400F2A6 RID: 62118
		private int opl_p2;
	}
}
