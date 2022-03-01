using System;

namespace behaviac
{
	// Token: 0x02003F52 RID: 16210
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node8 : Condition
	{
		// Token: 0x06016613 RID: 91667 RVA: 0x006C51BF File Offset: 0x006C35BF
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying2_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x06016614 RID: 91668 RVA: 0x006C51E0 File Offset: 0x006C35E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE49 RID: 65097
		private BE_Target opl_p0;

		// Token: 0x0400FE4A RID: 65098
		private BE_Equal opl_p1;

		// Token: 0x0400FE4B RID: 65099
		private int opl_p2;
	}
}
