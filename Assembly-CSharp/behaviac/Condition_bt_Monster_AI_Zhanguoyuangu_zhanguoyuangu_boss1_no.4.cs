using System;

namespace behaviac
{
	// Token: 0x02003F0E RID: 16142
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node9 : Condition
	{
		// Token: 0x06016590 RID: 91536 RVA: 0x006C2C3A File Offset: 0x006C103A
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x06016591 RID: 91537 RVA: 0x006C2C5C File Offset: 0x006C105C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDA6 RID: 64934
		private BE_Target opl_p0;

		// Token: 0x0400FDA7 RID: 64935
		private BE_Equal opl_p1;

		// Token: 0x0400FDA8 RID: 64936
		private int opl_p2;
	}
}
