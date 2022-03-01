using System;

namespace behaviac
{
	// Token: 0x02003C21 RID: 15393
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node26 : Condition
	{
		// Token: 0x06015FED RID: 90093 RVA: 0x006A5362 File Offset: 0x006A3762
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015FEE RID: 90094 RVA: 0x006A5384 File Offset: 0x006A3784
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F86C RID: 63596
		private BE_Target opl_p0;

		// Token: 0x0400F86D RID: 63597
		private BE_Equal opl_p1;

		// Token: 0x0400F86E RID: 63598
		private int opl_p2;
	}
}
