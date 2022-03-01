using System;

namespace behaviac
{
	// Token: 0x020033BF RID: 13247
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node5 : Condition
	{
		// Token: 0x06014FD6 RID: 85974 RVA: 0x00653189 File Offset: 0x00651589
		public Condition_bt_Monster_AI_GWGC_GWGC_qishiyuanjun_node5()
		{
			this.opl_p0 = 7477;
		}

		// Token: 0x06014FD7 RID: 85975 RVA: 0x0065319C File Offset: 0x0065159C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8C2 RID: 59586
		private int opl_p0;
	}
}
