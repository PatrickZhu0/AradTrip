using System;

namespace behaviac
{
	// Token: 0x0200396F RID: 14703
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node1 : Condition
	{
		// Token: 0x06015AB5 RID: 88757 RVA: 0x0068B521 File Offset: 0x00689921
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521677;
		}

		// Token: 0x06015AB6 RID: 88758 RVA: 0x0068B544 File Offset: 0x00689944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F45B RID: 62555
		private BE_Target opl_p0;

		// Token: 0x0400F45C RID: 62556
		private BE_Equal opl_p1;

		// Token: 0x0400F45D RID: 62557
		private int opl_p2;
	}
}
