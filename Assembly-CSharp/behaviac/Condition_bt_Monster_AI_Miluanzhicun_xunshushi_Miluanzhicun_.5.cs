using System;

namespace behaviac
{
	// Token: 0x020035CF RID: 13775
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node9 : Condition
	{
		// Token: 0x060153C8 RID: 86984 RVA: 0x00666A93 File Offset: 0x00664E93
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060153C9 RID: 86985 RVA: 0x00666AA8 File Offset: 0x00664EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED8C RID: 60812
		private float opl_p0;
	}
}
