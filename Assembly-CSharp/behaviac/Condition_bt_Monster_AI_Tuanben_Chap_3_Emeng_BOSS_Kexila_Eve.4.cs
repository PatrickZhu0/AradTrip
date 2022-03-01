using System;

namespace behaviac
{
	// Token: 0x020038A2 RID: 14498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node19 : Condition
	{
		// Token: 0x06015926 RID: 88358 RVA: 0x00683297 File Offset: 0x00681697
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node19()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521642;
		}

		// Token: 0x06015927 RID: 88359 RVA: 0x006832B8 File Offset: 0x006816B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2BD RID: 62141
		private BE_Target opl_p0;

		// Token: 0x0400F2BE RID: 62142
		private BE_Equal opl_p1;

		// Token: 0x0400F2BF RID: 62143
		private int opl_p2;
	}
}
