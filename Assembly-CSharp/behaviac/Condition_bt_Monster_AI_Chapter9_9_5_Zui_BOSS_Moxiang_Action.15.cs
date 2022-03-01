using System;

namespace behaviac
{
	// Token: 0x020031AE RID: 12718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node31 : Condition
	{
		// Token: 0x06014BEF RID: 84975 RVA: 0x0063F59A File Offset: 0x0063D99A
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node31()
		{
			this.opl_p0 = 0.53f;
		}

		// Token: 0x06014BF0 RID: 84976 RVA: 0x0063F5B0 File Offset: 0x0063D9B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E555 RID: 58709
		private float opl_p0;
	}
}
