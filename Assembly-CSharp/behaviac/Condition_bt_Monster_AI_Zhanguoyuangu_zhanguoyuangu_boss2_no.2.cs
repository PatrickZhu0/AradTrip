using System;

namespace behaviac
{
	// Token: 0x02003F17 RID: 16151
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node4 : Condition
	{
		// Token: 0x060165A1 RID: 91553 RVA: 0x006C3243 File Offset: 0x006C1643
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165A2 RID: 91554 RVA: 0x006C3264 File Offset: 0x006C1664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDBC RID: 64956
		private BE_Target opl_p0;

		// Token: 0x0400FDBD RID: 64957
		private BE_Equal opl_p1;

		// Token: 0x0400FDBE RID: 64958
		private int opl_p2;
	}
}
