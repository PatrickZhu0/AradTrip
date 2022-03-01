using System;

namespace behaviac
{
	// Token: 0x02003996 RID: 14742
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node12 : Condition
	{
		// Token: 0x06015B01 RID: 88833 RVA: 0x0068CEA0 File Offset: 0x0068B2A0
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node12()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015B02 RID: 88834 RVA: 0x0068CEB0 File Offset: 0x0068B2B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F49A RID: 62618
		private int opl_p0;
	}
}
