using System;

namespace behaviac
{
	// Token: 0x02002D5E RID: 11614
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node15 : Condition
	{
		// Token: 0x0601439F RID: 82847 RVA: 0x0061366B File Offset: 0x00611A6B
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node15()
		{
			this.opl_p0 = 21857;
		}

		// Token: 0x060143A0 RID: 82848 RVA: 0x00613680 File Offset: 0x00611A80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD6B RID: 56683
		private int opl_p0;
	}
}
