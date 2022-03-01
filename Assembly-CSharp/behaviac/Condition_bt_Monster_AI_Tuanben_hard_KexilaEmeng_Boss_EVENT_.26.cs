using System;

namespace behaviac
{
	// Token: 0x02003BFC RID: 15356
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node20 : Condition
	{
		// Token: 0x06015FA4 RID: 90020 RVA: 0x006A34D0 File Offset: 0x006A18D0
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node20()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570151;
		}

		// Token: 0x06015FA5 RID: 90021 RVA: 0x006A34F4 File Offset: 0x006A18F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F82C RID: 63532
		private BE_Target opl_p0;

		// Token: 0x0400F82D RID: 63533
		private BE_Equal opl_p1;

		// Token: 0x0400F82E RID: 63534
		private int opl_p2;
	}
}
