using System;

namespace behaviac
{
	// Token: 0x02003470 RID: 13424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node31 : Condition
	{
		// Token: 0x0601512B RID: 86315 RVA: 0x006598A1 File Offset: 0x00657CA1
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node31()
		{
			this.opl_p0 = 6214;
		}

		// Token: 0x0601512C RID: 86316 RVA: 0x006598B4 File Offset: 0x00657CB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA2F RID: 59951
		private int opl_p0;
	}
}
