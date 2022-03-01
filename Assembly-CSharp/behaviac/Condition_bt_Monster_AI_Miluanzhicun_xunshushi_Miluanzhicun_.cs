using System;

namespace behaviac
{
	// Token: 0x020035C9 RID: 13769
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node5 : Condition
	{
		// Token: 0x060153BC RID: 86972 RVA: 0x006668BA File Offset: 0x00664CBA
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060153BD RID: 86973 RVA: 0x006668D0 File Offset: 0x00664CD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED80 RID: 60800
		private float opl_p0;
	}
}
