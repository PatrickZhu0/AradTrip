using System;

namespace behaviac
{
	// Token: 0x02003201 RID: 12801
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15 : Condition
	{
		// Token: 0x06014C8C RID: 85132 RVA: 0x00642E57 File Offset: 0x00641257
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node15()
		{
			this.opl_p0 = 21561;
		}

		// Token: 0x06014C8D RID: 85133 RVA: 0x00642E6C File Offset: 0x0064126C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5DE RID: 58846
		private int opl_p0;
	}
}
