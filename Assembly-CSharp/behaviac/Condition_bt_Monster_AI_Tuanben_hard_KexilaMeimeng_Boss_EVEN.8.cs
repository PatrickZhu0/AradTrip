using System;

namespace behaviac
{
	// Token: 0x02003C63 RID: 15459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node68 : Condition
	{
		// Token: 0x0601606E RID: 90222 RVA: 0x006A8119 File Offset: 0x006A6519
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node68()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570212;
		}

		// Token: 0x0601606F RID: 90223 RVA: 0x006A813C File Offset: 0x006A653C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8F0 RID: 63728
		private BE_Target opl_p0;

		// Token: 0x0400F8F1 RID: 63729
		private BE_Equal opl_p1;

		// Token: 0x0400F8F2 RID: 63730
		private int opl_p2;
	}
}
