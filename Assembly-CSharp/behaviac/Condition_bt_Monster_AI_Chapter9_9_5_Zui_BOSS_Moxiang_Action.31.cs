using System;

namespace behaviac
{
	// Token: 0x020031C5 RID: 12741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node58 : Condition
	{
		// Token: 0x06014C1D RID: 85021 RVA: 0x0063FEFE File Offset: 0x0063E2FE
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node58()
		{
			this.opl_p0 = 0.85f;
		}

		// Token: 0x06014C1E RID: 85022 RVA: 0x0063FF14 File Offset: 0x0063E314
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E577 RID: 58743
		private float opl_p0;
	}
}
