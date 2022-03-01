using System;

namespace behaviac
{
	// Token: 0x02003F0F RID: 16143
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node8 : Condition
	{
		// Token: 0x06016592 RID: 91538 RVA: 0x006C2C9B File Offset: 0x006C109B
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x06016593 RID: 91539 RVA: 0x006C2CBC File Offset: 0x006C10BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDA9 RID: 64937
		private BE_Target opl_p0;

		// Token: 0x0400FDAA RID: 64938
		private BE_Equal opl_p1;

		// Token: 0x0400FDAB RID: 64939
		private int opl_p2;
	}
}
