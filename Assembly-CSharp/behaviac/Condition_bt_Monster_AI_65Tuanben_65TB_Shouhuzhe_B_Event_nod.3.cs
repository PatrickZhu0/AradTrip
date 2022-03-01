using System;

namespace behaviac
{
	// Token: 0x02002C6A RID: 11370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node7 : Condition
	{
		// Token: 0x060141CD RID: 82381 RVA: 0x0060A5AB File Offset: 0x006089AB
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521984;
		}

		// Token: 0x060141CE RID: 82382 RVA: 0x0060A5CC File Offset: 0x006089CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB8A RID: 56202
		private BE_Target opl_p0;

		// Token: 0x0400DB8B RID: 56203
		private BE_Equal opl_p1;

		// Token: 0x0400DB8C RID: 56204
		private int opl_p2;
	}
}
