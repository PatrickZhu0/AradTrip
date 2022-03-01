using System;

namespace behaviac
{
	// Token: 0x02003C1A RID: 15386
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node37 : Condition
	{
		// Token: 0x06015FDF RID: 90079 RVA: 0x006A503A File Offset: 0x006A343A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015FE0 RID: 90080 RVA: 0x006A505C File Offset: 0x006A345C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F85C RID: 63580
		private BE_Target opl_p0;

		// Token: 0x0400F85D RID: 63581
		private BE_Equal opl_p1;

		// Token: 0x0400F85E RID: 63582
		private int opl_p2;
	}
}
