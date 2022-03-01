using System;

namespace behaviac
{
	// Token: 0x02003CBB RID: 15547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node32 : Condition
	{
		// Token: 0x06016118 RID: 90392 RVA: 0x006AC176 File Offset: 0x006AA576
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node32()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016119 RID: 90393 RVA: 0x006AC18C File Offset: 0x006AA58C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9BC RID: 63932
		private int opl_p0;
	}
}
