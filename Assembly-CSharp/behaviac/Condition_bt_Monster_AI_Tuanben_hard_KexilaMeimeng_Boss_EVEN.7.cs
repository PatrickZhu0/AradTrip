using System;

namespace behaviac
{
	// Token: 0x02003C5F RID: 15455
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node40 : Condition
	{
		// Token: 0x06016066 RID: 90214 RVA: 0x006A800B File Offset: 0x006A640B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node40()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016067 RID: 90215 RVA: 0x006A8020 File Offset: 0x006A6420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8E8 RID: 63720
		private int opl_p0;
	}
}
