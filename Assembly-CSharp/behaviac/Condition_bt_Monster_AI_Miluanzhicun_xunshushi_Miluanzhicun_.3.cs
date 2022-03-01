using System;

namespace behaviac
{
	// Token: 0x020035CC RID: 13772
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node17 : Condition
	{
		// Token: 0x060153C2 RID: 86978 RVA: 0x006669A7 File Offset: 0x00664DA7
		public Condition_bt_Monster_AI_Miluanzhicun_xunshushi_Miluanzhicun_xunshushi_node17()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060153C3 RID: 86979 RVA: 0x006669BC File Offset: 0x00664DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED86 RID: 60806
		private float opl_p0;
	}
}
