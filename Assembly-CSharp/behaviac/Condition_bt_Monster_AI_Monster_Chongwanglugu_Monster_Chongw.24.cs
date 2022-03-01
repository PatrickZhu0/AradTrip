using System;

namespace behaviac
{
	// Token: 0x02003611 RID: 13841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node33 : Condition
	{
		// Token: 0x06015448 RID: 87112 RVA: 0x00668F15 File Offset: 0x00667315
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node33()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015449 RID: 87113 RVA: 0x00668F28 File Offset: 0x00667328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE05 RID: 60933
		private float opl_p0;
	}
}
