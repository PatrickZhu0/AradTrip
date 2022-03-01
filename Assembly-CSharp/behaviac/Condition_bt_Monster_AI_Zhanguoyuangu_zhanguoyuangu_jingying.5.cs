using System;

namespace behaviac
{
	// Token: 0x02003F43 RID: 16195
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node8 : Condition
	{
		// Token: 0x060165F6 RID: 91638 RVA: 0x006C494B File Offset: 0x006C2D4B
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165F7 RID: 91639 RVA: 0x006C496C File Offset: 0x006C2D6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE21 RID: 65057
		private BE_Target opl_p0;

		// Token: 0x0400FE22 RID: 65058
		private BE_Equal opl_p1;

		// Token: 0x0400FE23 RID: 65059
		private int opl_p2;
	}
}
