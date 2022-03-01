using System;

namespace behaviac
{
	// Token: 0x02003F0A RID: 16138
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node4 : Condition
	{
		// Token: 0x06016588 RID: 91528 RVA: 0x006C2B17 File Offset: 0x006C0F17
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss1_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x06016589 RID: 91529 RVA: 0x006C2B38 File Offset: 0x006C0F38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD9E RID: 64926
		private BE_Target opl_p0;

		// Token: 0x0400FD9F RID: 64927
		private BE_Equal opl_p1;

		// Token: 0x0400FDA0 RID: 64928
		private int opl_p2;
	}
}
