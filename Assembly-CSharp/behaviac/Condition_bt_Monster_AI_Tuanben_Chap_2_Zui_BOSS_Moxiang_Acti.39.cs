using System;

namespace behaviac
{
	// Token: 0x02003781 RID: 14209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node67 : Condition
	{
		// Token: 0x06015709 RID: 87817 RVA: 0x00677632 File Offset: 0x00675A32
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node67()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x0601570A RID: 87818 RVA: 0x00677648 File Offset: 0x00675A48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0C6 RID: 61638
		private float opl_p0;
	}
}
