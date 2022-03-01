using System;

namespace behaviac
{
	// Token: 0x020031BB RID: 12731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node44 : Condition
	{
		// Token: 0x06014C09 RID: 85001 RVA: 0x0063FAEA File Offset: 0x0063DEEA
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node44()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014C0A RID: 85002 RVA: 0x0063FB00 File Offset: 0x0063DF00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E568 RID: 58728
		private float opl_p0;
	}
}
