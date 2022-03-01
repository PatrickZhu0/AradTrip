using System;

namespace behaviac
{
	// Token: 0x02003F1B RID: 16155
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node9 : Condition
	{
		// Token: 0x060165A9 RID: 91561 RVA: 0x006C3366 File Offset: 0x006C1766
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x060165AA RID: 91562 RVA: 0x006C3388 File Offset: 0x006C1788
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDC4 RID: 64964
		private BE_Target opl_p0;

		// Token: 0x0400FDC5 RID: 64965
		private BE_Equal opl_p1;

		// Token: 0x0400FDC6 RID: 64966
		private int opl_p2;
	}
}
