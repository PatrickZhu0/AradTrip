using System;

namespace behaviac
{
	// Token: 0x0200360D RID: 13837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node40 : Condition
	{
		// Token: 0x06015440 RID: 87104 RVA: 0x00668D61 File Offset: 0x00667161
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node40()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06015441 RID: 87105 RVA: 0x00668D74 File Offset: 0x00667174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDFD RID: 60925
		private float opl_p0;
	}
}
