using System;

namespace behaviac
{
	// Token: 0x02002D55 RID: 11605
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6 : Condition
	{
		// Token: 0x0601438D RID: 82829 RVA: 0x0061326F File Offset: 0x0061166F
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node6()
		{
			this.opl_p0 = 21855;
		}

		// Token: 0x0601438E RID: 82830 RVA: 0x00613284 File Offset: 0x00611684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD59 RID: 56665
		private int opl_p0;
	}
}
