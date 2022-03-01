using System;

namespace behaviac
{
	// Token: 0x02003BC7 RID: 15303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node58 : Condition
	{
		// Token: 0x06015F3B RID: 89915 RVA: 0x006A268A File Offset: 0x006A0A8A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node58()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015F3C RID: 89916 RVA: 0x006A26A0 File Offset: 0x006A0AA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C8 RID: 63432
		private int opl_p0;
	}
}
