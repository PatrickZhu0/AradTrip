using System;

namespace behaviac
{
	// Token: 0x020031BE RID: 12734
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node48 : Condition
	{
		// Token: 0x06014C0F RID: 85007 RVA: 0x0063FC26 File Offset: 0x0063E026
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node48()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014C10 RID: 85008 RVA: 0x0063FC3C File Offset: 0x0063E03C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E56C RID: 58732
		private float opl_p0;
	}
}
