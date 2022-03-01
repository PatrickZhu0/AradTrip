using System;

namespace behaviac
{
	// Token: 0x02003607 RID: 13831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10 : Condition
	{
		// Token: 0x06015434 RID: 87092 RVA: 0x00668A9F File Offset: 0x00666E9F
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node10()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06015435 RID: 87093 RVA: 0x00668AB4 File Offset: 0x00666EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDED RID: 60909
		private float opl_p0;
	}
}
