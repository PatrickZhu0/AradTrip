using System;

namespace behaviac
{
	// Token: 0x02002F3E RID: 12094
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node16 : Condition
	{
		// Token: 0x0601474D RID: 83789 RVA: 0x006277EB File Offset: 0x00625BEB
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node16()
		{
			this.opl_p0 = 5000;
		}

		// Token: 0x0601474E RID: 83790 RVA: 0x00627800 File Offset: 0x00625C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0BE RID: 57534
		private int opl_p0;
	}
}
