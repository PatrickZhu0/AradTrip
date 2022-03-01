using System;

namespace behaviac
{
	// Token: 0x020038B1 RID: 14513
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node51 : Condition
	{
		// Token: 0x06015941 RID: 88385 RVA: 0x00683B35 File Offset: 0x00681F35
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570218;
		}

		// Token: 0x06015942 RID: 88386 RVA: 0x00683B58 File Offset: 0x00681F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2E2 RID: 62178
		private BE_Target opl_p0;

		// Token: 0x0400F2E3 RID: 62179
		private BE_Equal opl_p1;

		// Token: 0x0400F2E4 RID: 62180
		private int opl_p2;
	}
}
