using System;

namespace behaviac
{
	// Token: 0x02003C53 RID: 15443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node58 : Condition
	{
		// Token: 0x0601604E RID: 90190 RVA: 0x006A7C12 File Offset: 0x006A6012
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node58()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601604F RID: 90191 RVA: 0x006A7C28 File Offset: 0x006A6028
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8C2 RID: 63682
		private int opl_p0;
	}
}
