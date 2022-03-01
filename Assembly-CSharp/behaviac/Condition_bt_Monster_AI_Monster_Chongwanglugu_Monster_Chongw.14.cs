using System;

namespace behaviac
{
	// Token: 0x02003603 RID: 13827
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3 : Condition
	{
		// Token: 0x0601542C RID: 87084 RVA: 0x00668905 File Offset: 0x00666D05
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node3()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601542D RID: 87085 RVA: 0x00668918 File Offset: 0x00666D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDE6 RID: 60902
		private float opl_p0;
	}
}
