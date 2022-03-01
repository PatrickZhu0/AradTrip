using System;

namespace behaviac
{
	// Token: 0x02003754 RID: 14164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node28 : Condition
	{
		// Token: 0x060156AF RID: 87727 RVA: 0x006763CA File Offset: 0x006747CA
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060156B0 RID: 87728 RVA: 0x006763E0 File Offset: 0x006747E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F085 RID: 61573
		private float opl_p0;
	}
}
