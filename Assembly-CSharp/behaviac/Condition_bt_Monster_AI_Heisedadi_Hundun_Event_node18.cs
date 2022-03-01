using System;

namespace behaviac
{
	// Token: 0x02003462 RID: 13410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node18 : Condition
	{
		// Token: 0x06015110 RID: 86288 RVA: 0x00658A07 File Offset: 0x00656E07
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node18()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x06015111 RID: 86289 RVA: 0x00658A28 File Offset: 0x00656E28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA0C RID: 59916
		private HMType opl_p0;

		// Token: 0x0400EA0D RID: 59917
		private BE_Operation opl_p1;

		// Token: 0x0400EA0E RID: 59918
		private float opl_p2;
	}
}
