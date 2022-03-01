using System;

namespace behaviac
{
	// Token: 0x020031CB RID: 12747
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node66 : Condition
	{
		// Token: 0x06014C29 RID: 85033 RVA: 0x00640176 File Offset: 0x0063E576
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node66()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014C2A RID: 85034 RVA: 0x0064018C File Offset: 0x0063E58C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E57F RID: 58751
		private float opl_p0;
	}
}
