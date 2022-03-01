using System;

namespace behaviac
{
	// Token: 0x02002EAD RID: 11949
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node16 : Condition
	{
		// Token: 0x06014634 RID: 83508 RVA: 0x00621D33 File Offset: 0x00620133
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node16()
		{
			this.opl_p0 = 21595;
		}

		// Token: 0x06014635 RID: 83509 RVA: 0x00621D48 File Offset: 0x00620148
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFAA RID: 57258
		private int opl_p0;
	}
}
