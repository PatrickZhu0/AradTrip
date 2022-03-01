using System;

namespace behaviac
{
	// Token: 0x020035D2 RID: 13778
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node13 : Condition
	{
		// Token: 0x060153CE RID: 86990 RVA: 0x00666B7F File Offset: 0x00664F7F
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060153CF RID: 86991 RVA: 0x00666B94 File Offset: 0x00664F94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED92 RID: 60818
		private float opl_p0;
	}
}
