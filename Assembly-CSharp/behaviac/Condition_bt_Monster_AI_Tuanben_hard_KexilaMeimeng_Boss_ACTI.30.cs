using System;

namespace behaviac
{
	// Token: 0x02003C35 RID: 15413
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node49 : Condition
	{
		// Token: 0x06016014 RID: 90132 RVA: 0x006A671E File Offset: 0x006A4B1E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node49()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06016015 RID: 90133 RVA: 0x006A6740 File Offset: 0x006A4B40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F88D RID: 63629
		private BE_Target opl_p0;

		// Token: 0x0400F88E RID: 63630
		private BE_Equal opl_p1;

		// Token: 0x0400F88F RID: 63631
		private int opl_p2;
	}
}
