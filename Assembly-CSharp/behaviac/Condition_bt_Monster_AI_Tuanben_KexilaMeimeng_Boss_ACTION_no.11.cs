using System;

namespace behaviac
{
	// Token: 0x02003A29 RID: 14889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node26 : Condition
	{
		// Token: 0x06015C1C RID: 89116 RVA: 0x006922DA File Offset: 0x006906DA
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570152;
		}

		// Token: 0x06015C1D RID: 89117 RVA: 0x006922FC File Offset: 0x006906FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F535 RID: 62773
		private BE_Target opl_p0;

		// Token: 0x0400F536 RID: 62774
		private BE_Equal opl_p1;

		// Token: 0x0400F537 RID: 62775
		private int opl_p2;
	}
}
