using System;

namespace behaviac
{
	// Token: 0x02003F16 RID: 16150
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node3 : Condition
	{
		// Token: 0x0601659F RID: 91551 RVA: 0x006C31E2 File Offset: 0x006C15E2
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x060165A0 RID: 91552 RVA: 0x006C3204 File Offset: 0x006C1604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDB9 RID: 64953
		private BE_Target opl_p0;

		// Token: 0x0400FDBA RID: 64954
		private BE_Equal opl_p1;

		// Token: 0x0400FDBB RID: 64955
		private int opl_p2;
	}
}
