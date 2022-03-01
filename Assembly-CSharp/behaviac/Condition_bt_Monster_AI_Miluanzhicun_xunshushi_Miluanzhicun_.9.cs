using System;

namespace behaviac
{
	// Token: 0x020035D5 RID: 13781
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node29 : Condition
	{
		// Token: 0x060153D4 RID: 86996 RVA: 0x00666C6B File Offset: 0x0066506B
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node29()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060153D5 RID: 86997 RVA: 0x00666C80 File Offset: 0x00665080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED98 RID: 60824
		private float opl_p0;
	}
}
