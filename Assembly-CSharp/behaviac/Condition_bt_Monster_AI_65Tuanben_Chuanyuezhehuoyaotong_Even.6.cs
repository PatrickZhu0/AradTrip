using System;

namespace behaviac
{
	// Token: 0x02002D5B RID: 11611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node12 : Condition
	{
		// Token: 0x06014399 RID: 82841 RVA: 0x00613517 File Offset: 0x00611917
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node12()
		{
			this.opl_p0 = 21856;
		}

		// Token: 0x0601439A RID: 82842 RVA: 0x0061352C File Offset: 0x0061192C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD65 RID: 56677
		private int opl_p0;
	}
}
