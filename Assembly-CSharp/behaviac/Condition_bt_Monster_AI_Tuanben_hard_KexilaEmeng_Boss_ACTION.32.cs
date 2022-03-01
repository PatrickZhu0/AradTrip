using System;

namespace behaviac
{
	// Token: 0x02003BC0 RID: 15296
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node70 : Condition
	{
		// Token: 0x06015F30 RID: 89904 RVA: 0x006A1259 File Offset: 0x0069F659
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node70()
		{
			this.opl_p0 = 21508;
		}

		// Token: 0x06015F31 RID: 89905 RVA: 0x006A126C File Offset: 0x0069F66C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7C1 RID: 63425
		private int opl_p0;
	}
}
