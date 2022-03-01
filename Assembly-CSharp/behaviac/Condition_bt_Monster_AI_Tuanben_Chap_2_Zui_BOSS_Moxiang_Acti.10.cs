using System;

namespace behaviac
{
	// Token: 0x02003757 RID: 14167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node32 : Condition
	{
		// Token: 0x060156B5 RID: 87733 RVA: 0x00676506 File Offset: 0x00674906
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node32()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060156B6 RID: 87734 RVA: 0x0067651C File Offset: 0x0067491C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F089 RID: 61577
		private float opl_p0;
	}
}
