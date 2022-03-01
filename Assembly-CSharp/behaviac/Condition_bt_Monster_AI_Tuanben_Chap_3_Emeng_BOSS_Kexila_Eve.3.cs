using System;

namespace behaviac
{
	// Token: 0x020038A1 RID: 14497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node18 : Condition
	{
		// Token: 0x06015924 RID: 88356 RVA: 0x00683235 File Offset: 0x00681635
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node18()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521636;
		}

		// Token: 0x06015925 RID: 88357 RVA: 0x00683258 File Offset: 0x00681658
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2BA RID: 62138
		private BE_Target opl_p0;

		// Token: 0x0400F2BB RID: 62139
		private BE_Equal opl_p1;

		// Token: 0x0400F2BC RID: 62140
		private int opl_p2;
	}
}
