using System;

namespace behaviac
{
	// Token: 0x020035FF RID: 13823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23 : Condition
	{
		// Token: 0x06015424 RID: 87076 RVA: 0x00668751 File Offset: 0x00666B51
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node23()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06015425 RID: 87077 RVA: 0x00668764 File Offset: 0x00666B64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDDE RID: 60894
		private float opl_p0;
	}
}
