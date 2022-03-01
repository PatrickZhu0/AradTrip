using System;

namespace behaviac
{
	// Token: 0x02001EDB RID: 7899
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node54 : Condition
	{
		// Token: 0x0601275B RID: 75611 RVA: 0x0056659B File Offset: 0x0056499B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node54()
		{
			this.opl_p0 = 3208;
		}

		// Token: 0x0601275C RID: 75612 RVA: 0x005665B0 File Offset: 0x005649B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C14F RID: 49487
		private int opl_p0;
	}
}
