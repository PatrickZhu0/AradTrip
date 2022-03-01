using System;

namespace behaviac
{
	// Token: 0x02003C51 RID: 15441
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node50 : Condition
	{
		// Token: 0x0601604A RID: 90186 RVA: 0x006A7B5D File Offset: 0x006A5F5D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node50()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570211;
		}

		// Token: 0x0601604B RID: 90187 RVA: 0x006A7B80 File Offset: 0x006A5F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8BE RID: 63678
		private BE_Target opl_p0;

		// Token: 0x0400F8BF RID: 63679
		private BE_Equal opl_p1;

		// Token: 0x0400F8C0 RID: 63680
		private int opl_p2;
	}
}
