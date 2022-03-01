using System;

namespace behaviac
{
	// Token: 0x02003787 RID: 14215
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node90 : Condition
	{
		// Token: 0x06015715 RID: 87829 RVA: 0x006778AA File Offset: 0x00675CAA
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node90()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015716 RID: 87830 RVA: 0x006778C0 File Offset: 0x00675CC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0CE RID: 61646
		private float opl_p0;
	}
}
