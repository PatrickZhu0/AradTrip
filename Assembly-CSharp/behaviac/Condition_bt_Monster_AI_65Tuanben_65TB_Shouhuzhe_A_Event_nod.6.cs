using System;

namespace behaviac
{
	// Token: 0x02002C46 RID: 11334
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node4 : Condition
	{
		// Token: 0x06014188 RID: 82312 RVA: 0x00608E01 File Offset: 0x00607201
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014189 RID: 82313 RVA: 0x00608E24 File Offset: 0x00607224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB4F RID: 56143
		private HMType opl_p0;

		// Token: 0x0400DB50 RID: 56144
		private BE_Operation opl_p1;

		// Token: 0x0400DB51 RID: 56145
		private float opl_p2;
	}
}
