using System;

namespace behaviac
{
	// Token: 0x020031C8 RID: 12744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node62 : Condition
	{
		// Token: 0x06014C23 RID: 85027 RVA: 0x0064003A File Offset: 0x0063E43A
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node62()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06014C24 RID: 85028 RVA: 0x00640050 File Offset: 0x0063E450
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E57B RID: 58747
		private float opl_p0;
	}
}
