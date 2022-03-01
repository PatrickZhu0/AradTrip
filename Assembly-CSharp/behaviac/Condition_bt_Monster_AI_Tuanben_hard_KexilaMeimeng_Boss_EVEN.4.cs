using System;

namespace behaviac
{
	// Token: 0x02003C57 RID: 15447
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node51 : Condition
	{
		// Token: 0x06016056 RID: 90198 RVA: 0x006A7D71 File Offset: 0x006A6171
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node51()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x06016057 RID: 90199 RVA: 0x006A7D94 File Offset: 0x006A6194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8D0 RID: 63696
		private BE_Target opl_p0;

		// Token: 0x0400F8D1 RID: 63697
		private BE_Equal opl_p1;

		// Token: 0x0400F8D2 RID: 63698
		private int opl_p2;
	}
}
