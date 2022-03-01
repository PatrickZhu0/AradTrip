using System;

namespace behaviac
{
	// Token: 0x0200398C RID: 14732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node5 : Condition
	{
		// Token: 0x06015AED RID: 88813 RVA: 0x0068CB41 File Offset: 0x0068AF41
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node5()
		{
			this.opl_p0 = 21039;
		}

		// Token: 0x06015AEE RID: 88814 RVA: 0x0068CB54 File Offset: 0x0068AF54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F48A RID: 62602
		private int opl_p0;
	}
}
