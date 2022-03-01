using System;

namespace behaviac
{
	// Token: 0x02003F29 RID: 16169
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node8 : Condition
	{
		// Token: 0x060165C4 RID: 91588 RVA: 0x006C3AF3 File Offset: 0x006C1EF3
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165C5 RID: 91589 RVA: 0x006C3B14 File Offset: 0x006C1F14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDE5 RID: 64997
		private BE_Target opl_p0;

		// Token: 0x0400FDE6 RID: 64998
		private BE_Equal opl_p1;

		// Token: 0x0400FDE7 RID: 64999
		private int opl_p2;
	}
}
