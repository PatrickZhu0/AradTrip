using System;

namespace behaviac
{
	// Token: 0x0200319B RID: 12699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node16 : Condition
	{
		// Token: 0x06014BC9 RID: 84937 RVA: 0x0063EDD3 File Offset: 0x0063D1D3
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node16()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014BCA RID: 84938 RVA: 0x0063EDE8 File Offset: 0x0063D1E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E53A RID: 58682
		private float opl_p0;
	}
}
