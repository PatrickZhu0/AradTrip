using System;

namespace behaviac
{
	// Token: 0x02001F5D RID: 8029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node73 : Condition
	{
		// Token: 0x0601285D RID: 75869 RVA: 0x0056B80B File Offset: 0x00569C0B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node73()
		{
			this.opl_p0 = 3005;
		}

		// Token: 0x0601285E RID: 75870 RVA: 0x0056B820 File Offset: 0x00569C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C257 RID: 49751
		private int opl_p0;
	}
}
