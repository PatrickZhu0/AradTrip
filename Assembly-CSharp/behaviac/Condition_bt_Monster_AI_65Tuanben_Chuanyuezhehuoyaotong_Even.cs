using System;

namespace behaviac
{
	// Token: 0x02002D54 RID: 11604
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5 : Condition
	{
		// Token: 0x0601438B RID: 82827 RVA: 0x0061320C File Offset: 0x0061160C
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522215;
		}

		// Token: 0x0601438C RID: 82828 RVA: 0x00613230 File Offset: 0x00611630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD56 RID: 56662
		private BE_Target opl_p0;

		// Token: 0x0400DD57 RID: 56663
		private BE_Equal opl_p1;

		// Token: 0x0400DD58 RID: 56664
		private int opl_p2;
	}
}
