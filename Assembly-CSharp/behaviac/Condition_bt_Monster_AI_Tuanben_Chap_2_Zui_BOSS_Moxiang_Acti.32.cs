using System;

namespace behaviac
{
	// Token: 0x02003777 RID: 14199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node52 : Condition
	{
		// Token: 0x060156F5 RID: 87797 RVA: 0x0067721E File Offset: 0x0067561E
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node52()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060156F6 RID: 87798 RVA: 0x00677234 File Offset: 0x00675634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0B7 RID: 61623
		private float opl_p0;
	}
}
