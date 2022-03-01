using System;

namespace behaviac
{
	// Token: 0x02002C45 RID: 11333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node23 : Condition
	{
		// Token: 0x06014186 RID: 82310 RVA: 0x00608DAE File Offset: 0x006071AE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node23()
		{
			this.opl_p0 = 42690031;
			this.opl_p1 = 1;
		}

		// Token: 0x06014187 RID: 82311 RVA: 0x00608DC8 File Offset: 0x006071C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB4D RID: 56141
		private int opl_p0;

		// Token: 0x0400DB4E RID: 56142
		private int opl_p1;
	}
}
