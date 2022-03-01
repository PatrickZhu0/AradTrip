using System;

namespace behaviac
{
	// Token: 0x020035D3 RID: 13779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node14 : Condition
	{
		// Token: 0x060153D0 RID: 86992 RVA: 0x00666BC7 File Offset: 0x00664FC7
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node14()
		{
			this.opl_p0 = 25000;
			this.opl_p1 = 25000;
			this.opl_p2 = 25000;
			this.opl_p3 = 25000;
		}

		// Token: 0x060153D1 RID: 86993 RVA: 0x00666BFC File Offset: 0x00664FFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED93 RID: 60819
		private int opl_p0;

		// Token: 0x0400ED94 RID: 60820
		private int opl_p1;

		// Token: 0x0400ED95 RID: 60821
		private int opl_p2;

		// Token: 0x0400ED96 RID: 60822
		private int opl_p3;
	}
}
