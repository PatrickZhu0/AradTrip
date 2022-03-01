using System;

namespace behaviac
{
	// Token: 0x02003774 RID: 14196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node48 : Condition
	{
		// Token: 0x060156EF RID: 87791 RVA: 0x006770E2 File Offset: 0x006754E2
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node48()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060156F0 RID: 87792 RVA: 0x006770F8 File Offset: 0x006754F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B3 RID: 61619
		private float opl_p0;
	}
}
