using System;

namespace behaviac
{
	// Token: 0x02003C1D RID: 15389
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node7 : Condition
	{
		// Token: 0x06015FE5 RID: 90085 RVA: 0x006A5192 File Offset: 0x006A3592
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015FE6 RID: 90086 RVA: 0x006A51B4 File Offset: 0x006A35B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F862 RID: 63586
		private BE_Target opl_p0;

		// Token: 0x0400F863 RID: 63587
		private BE_Equal opl_p1;

		// Token: 0x0400F864 RID: 63588
		private int opl_p2;
	}
}
