using System;

namespace behaviac
{
	// Token: 0x020031B5 RID: 12725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node36 : Condition
	{
		// Token: 0x06014BFD RID: 84989 RVA: 0x0063F873 File Offset: 0x0063DC73
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node36()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014BFE RID: 84990 RVA: 0x0063F888 File Offset: 0x0063DC88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E560 RID: 58720
		private float opl_p0;
	}
}
