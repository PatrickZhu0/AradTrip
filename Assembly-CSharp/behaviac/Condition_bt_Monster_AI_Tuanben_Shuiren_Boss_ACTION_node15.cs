using System;

namespace behaviac
{
	// Token: 0x02003B66 RID: 15206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node15 : Condition
	{
		// Token: 0x06015E81 RID: 89729 RVA: 0x0069DEAB File Offset: 0x0069C2AB
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node15()
		{
			this.opl_p0 = 21080;
		}

		// Token: 0x06015E82 RID: 89730 RVA: 0x0069DEC0 File Offset: 0x0069C2C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F747 RID: 63303
		private int opl_p0;
	}
}
