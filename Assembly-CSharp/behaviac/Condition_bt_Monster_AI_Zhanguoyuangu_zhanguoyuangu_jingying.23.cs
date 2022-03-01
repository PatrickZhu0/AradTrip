using System;

namespace behaviac
{
	// Token: 0x02003F70 RID: 16240
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node8 : Condition
	{
		// Token: 0x0601664D RID: 91725 RVA: 0x006C62A7 File Offset: 0x006C46A7
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x0601664E RID: 91726 RVA: 0x006C62C8 File Offset: 0x006C46C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE99 RID: 65177
		private BE_Target opl_p0;

		// Token: 0x0400FE9A RID: 65178
		private BE_Equal opl_p1;

		// Token: 0x0400FE9B RID: 65179
		private int opl_p2;
	}
}
