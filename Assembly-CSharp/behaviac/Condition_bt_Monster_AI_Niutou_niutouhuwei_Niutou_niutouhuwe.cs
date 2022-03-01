using System;

namespace behaviac
{
	// Token: 0x0200370A RID: 14090
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node2 : Condition
	{
		// Token: 0x06015622 RID: 87586 RVA: 0x006739A2 File Offset: 0x00671DA2
		public Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node2()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06015623 RID: 87587 RVA: 0x006739B8 File Offset: 0x00671DB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFEA RID: 61418
		private float opl_p0;
	}
}
