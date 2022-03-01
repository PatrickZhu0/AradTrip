using System;

namespace behaviac
{
	// Token: 0x0200346C RID: 13420
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node41 : Condition
	{
		// Token: 0x06015123 RID: 86307 RVA: 0x006596D1 File Offset: 0x00657AD1
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node41()
		{
			this.opl_p0 = 6211;
		}

		// Token: 0x06015124 RID: 86308 RVA: 0x006596E4 File Offset: 0x00657AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA25 RID: 59941
		private int opl_p0;
	}
}
