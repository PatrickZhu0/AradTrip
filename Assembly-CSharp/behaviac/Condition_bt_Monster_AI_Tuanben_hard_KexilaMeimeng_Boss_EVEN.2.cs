using System;

namespace behaviac
{
	// Token: 0x02003C52 RID: 15442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node32 : Condition
	{
		// Token: 0x0601604C RID: 90188 RVA: 0x006A7BC2 File Offset: 0x006A5FC2
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node32()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601604D RID: 90189 RVA: 0x006A7BD8 File Offset: 0x006A5FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8C1 RID: 63681
		private int opl_p0;
	}
}
