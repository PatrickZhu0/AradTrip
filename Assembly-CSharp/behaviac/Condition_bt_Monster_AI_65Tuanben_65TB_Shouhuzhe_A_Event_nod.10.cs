using System;

namespace behaviac
{
	// Token: 0x02002C4B RID: 11339
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node24 : Condition
	{
		// Token: 0x06014192 RID: 82322 RVA: 0x00608FFE File Offset: 0x006073FE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node24()
		{
			this.opl_p0 = 42690031;
			this.opl_p1 = 1;
		}

		// Token: 0x06014193 RID: 82323 RVA: 0x00609018 File Offset: 0x00607418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB59 RID: 56153
		private int opl_p0;

		// Token: 0x0400DB5A RID: 56154
		private int opl_p1;
	}
}
