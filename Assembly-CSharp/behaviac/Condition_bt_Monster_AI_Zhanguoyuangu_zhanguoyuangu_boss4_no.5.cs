using System;

namespace behaviac
{
	// Token: 0x02003F36 RID: 16182
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node8 : Condition
	{
		// Token: 0x060165DD RID: 91613 RVA: 0x006C421F File Offset: 0x006C261F
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165DE RID: 91614 RVA: 0x006C4240 File Offset: 0x006C2640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE03 RID: 65027
		private BE_Target opl_p0;

		// Token: 0x0400FE04 RID: 65028
		private BE_Equal opl_p1;

		// Token: 0x0400FE05 RID: 65029
		private int opl_p2;
	}
}
