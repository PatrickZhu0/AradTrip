using System;

namespace behaviac
{
	// Token: 0x02002F1B RID: 12059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node31 : Condition
	{
		// Token: 0x0601470C RID: 83724 RVA: 0x00626497 File Offset: 0x00624897
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node31()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570283;
		}

		// Token: 0x0601470D RID: 83725 RVA: 0x006264B8 File Offset: 0x006248B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E083 RID: 57475
		private BE_Target opl_p0;

		// Token: 0x0400E084 RID: 57476
		private BE_Equal opl_p1;

		// Token: 0x0400E085 RID: 57477
		private int opl_p2;
	}
}
