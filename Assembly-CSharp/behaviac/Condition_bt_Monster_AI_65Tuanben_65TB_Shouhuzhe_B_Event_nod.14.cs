using System;

namespace behaviac
{
	// Token: 0x02002C79 RID: 11385
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node26 : Condition
	{
		// Token: 0x060141EB RID: 82411 RVA: 0x0060AB4A File Offset: 0x00608F4A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521978;
		}

		// Token: 0x060141EC RID: 82412 RVA: 0x0060AB6C File Offset: 0x00608F6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBAC RID: 56236
		private BE_Target opl_p0;

		// Token: 0x0400DBAD RID: 56237
		private BE_Equal opl_p1;

		// Token: 0x0400DBAE RID: 56238
		private int opl_p2;
	}
}
