using System;

namespace behaviac
{
	// Token: 0x02003204 RID: 12804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node21 : Condition
	{
		// Token: 0x06014C92 RID: 85138 RVA: 0x00642F93 File Offset: 0x00641393
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node21()
		{
			this.opl_p0 = 21558;
		}

		// Token: 0x06014C93 RID: 85139 RVA: 0x00642FA8 File Offset: 0x006413A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E2 RID: 58850
		private int opl_p0;
	}
}
