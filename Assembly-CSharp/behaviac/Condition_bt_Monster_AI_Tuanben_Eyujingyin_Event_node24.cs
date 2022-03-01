using System;

namespace behaviac
{
	// Token: 0x0200399A RID: 14746
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node24 : Condition
	{
		// Token: 0x06015B09 RID: 88841 RVA: 0x0068CFA9 File Offset: 0x0068B3A9
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node24()
		{
			this.opl_p0 = 21039;
		}

		// Token: 0x06015B0A RID: 88842 RVA: 0x0068CFBC File Offset: 0x0068B3BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A0 RID: 62624
		private int opl_p0;
	}
}
