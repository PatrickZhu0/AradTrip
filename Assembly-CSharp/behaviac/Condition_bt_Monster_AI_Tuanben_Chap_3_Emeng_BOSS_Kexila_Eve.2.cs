using System;

namespace behaviac
{
	// Token: 0x0200389B RID: 14491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node14 : Condition
	{
		// Token: 0x06015918 RID: 88344 RVA: 0x00682FDB File Offset: 0x006813DB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node14()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521642;
		}

		// Token: 0x06015919 RID: 88345 RVA: 0x00682FFC File Offset: 0x006813FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2A7 RID: 62119
		private BE_Target opl_p0;

		// Token: 0x0400F2A8 RID: 62120
		private BE_Equal opl_p1;

		// Token: 0x0400F2A9 RID: 62121
		private int opl_p2;
	}
}
