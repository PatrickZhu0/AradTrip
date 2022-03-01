using System;

namespace behaviac
{
	// Token: 0x02003965 RID: 14693
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node55 : Condition
	{
		// Token: 0x06015AA1 RID: 88737 RVA: 0x0068B243 File Offset: 0x00689643
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node55()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x06015AA2 RID: 88738 RVA: 0x0068B264 File Offset: 0x00689664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F445 RID: 62533
		private BE_Target opl_p0;

		// Token: 0x0400F446 RID: 62534
		private BE_Equal opl_p1;

		// Token: 0x0400F447 RID: 62535
		private int opl_p2;
	}
}
