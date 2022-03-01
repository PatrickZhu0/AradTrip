using System;

namespace behaviac
{
	// Token: 0x020035A3 RID: 13731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node7 : Condition
	{
		// Token: 0x06015375 RID: 86901 RVA: 0x006650A3 File Offset: 0x006634A3
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node7()
		{
			this.opl_p0 = 5164;
		}

		// Token: 0x06015376 RID: 86902 RVA: 0x006650B8 File Offset: 0x006634B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED40 RID: 60736
		private int opl_p0;
	}
}
