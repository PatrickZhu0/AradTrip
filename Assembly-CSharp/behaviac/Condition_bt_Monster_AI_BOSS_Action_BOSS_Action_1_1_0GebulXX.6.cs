using System;

namespace behaviac
{
	// Token: 0x02002F3A RID: 12090
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node11 : Condition
	{
		// Token: 0x06014745 RID: 83781 RVA: 0x00627637 File Offset: 0x00625A37
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_1_1_0GebulXX_Action_node11()
		{
			this.opl_p0 = 5449;
		}

		// Token: 0x06014746 RID: 83782 RVA: 0x0062764C File Offset: 0x00625A4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0B6 RID: 57526
		private int opl_p0;
	}
}
